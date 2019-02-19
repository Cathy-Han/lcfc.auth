using Autofac;
using lcfc.auth.IModules.Domain;
using lcfc.auth.Modules.Domain;
using Microsoft.Extensions.Logging;
using Surging.Core.Caching.Configurations;
using Surging.Core.Codec.MessagePack;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.ProxyGenerator;
using Surging.Core.ServiceHosting;
using Surging.Core.ServiceHosting.Internal.Implementation;
using System;
using System.Text;

namespace lcfc.auth.services.server
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var host = new ServiceHostBuilder()
                .RegisterServices(builder =>
                {
                    builder.AddMicroService(option =>
                    {
                        option.AddServiceRuntime()
                        .AddRelateService()
                        .AddConfigurationWatch();
                        option.UseMessagePackCodec(); //基于MessagePack序列化传输，比json.net快很多
                        builder.Register(p => new CPlatformContainer(ServiceLocator.Current));
                    });
                })
                .ConfigureLogging(logger =>
                {
                    logger.AddConfiguration(
                        Surging.Core.CPlatform.AppConfig.GetSection("Logging"));
                })
                .UseServer(option => { })
                .UseConsoleLifetime()
                .Configure(build => build.AddCacheFile("${cachepath}|cacheSettings.json", optional: false, reloadOnChange: true))
                .Configure(build => build.AddCPlatformFile("${surgingpath}|surgingSettings.json", optional: false, reloadOnChange: true))
                .UseStartup<Startup>()
                .Build();

            using (host.Run())
            {
                Console.WriteLine($"服务端启动成功,{ DateTime.Now}。");
                //IDomainCreate domainService = new DomainCreateService(new Modules.Repositories.DomainRepository());
                //IDomain model = new data.Domain
                //{
                //    Id = "LCFC",
                //    Name = "LCFC",
                //    Description = "LCFC Company",
                //    CreateTime = DateTime.Now,
                //    TimeStamp = DateTime.Now.TimeOfDay,
                //};
                //var res = domainService.Create(model).Result;
                //Console.WriteLine("Create domain success");
            }
        }
    }
}
