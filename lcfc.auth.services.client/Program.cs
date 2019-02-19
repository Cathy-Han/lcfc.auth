using Autofac;
using Microsoft.Extensions.Logging;
using Surging.Core.Caching;
using Surging.Core.Caching.Configurations;
using Surging.Core.Codec.MessagePack;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusKafka.Configurations;
using Surging.Core.ProxyGenerator;
using Surging.Core.ServiceHosting;
using Surging.Core.ServiceHosting.Internal.Implementation;
using System;
using System.Text;

namespace lcfc.auth.services.client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var host = new ServiceHostBuilder()
                    .RegisterServices(builder =>
                    {
                        builder.AddMicroService(option =>
                        {
                            option.UseMessagePackCodec();
                            option.AddClient()
                            .AddCache();
                            builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                        });
                    })
                    .ConfigureLogging(logger =>
                    {
                        logger.AddConfiguration(
                           Surging.Core.CPlatform.AppConfig.GetSection("Logging"));
                    })
                    .Configure(build => build.AddEventBusFile("eventBusSettings.json", optional: false))
                    .Configure(build => build.AddCacheFile("cacheSettings.json", optional: false, reloadOnChange: true))
                    .Configure(build => build.AddCPlatformFile("${surgingpath}|surgingSettings.json", optional: false, reloadOnChange: true))
                    .UseClient()
                    .UseStartup<Startup>()
                    .Build();

                using (host.Run())
                {
                    Startup.Test(ServiceLocator.GetService<IServiceProxyFactory>());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
        }
    }
}
