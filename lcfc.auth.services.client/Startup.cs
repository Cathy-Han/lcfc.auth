using Autofac;
using Autofac.Extensions.DependencyInjection;
using lcfc.auth.IModules.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusKafka.Configurations;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.services.client
{
    public class Startup
    {
        private ContainerBuilder _builder;

        public Startup(IConfigurationBuilder config)
        {
            ConfigureEventBus(config);
            ConfigureCache(config);
        }

        public IContainer ConfigureServices(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            ConfigureLogging(services);
            builder.Populate(services);
            _builder = builder;
            ServiceLocator.Current = builder.Build();
            return ServiceLocator.Current;
        }

        public void Configure(IContainer app)
        {

        }

        #region 私有方法
        /// <summary>
        /// 配置日志服务
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging();
        }

        private static void ConfigureEventBus(IConfigurationBuilder build)
        {
            build.AddEventBusFile("eventBusSettings.json", optional: false);
        }

        /// <summary>
        /// 配置缓存服务
        /// </summary>
        private void ConfigureCache(IConfigurationBuilder build)
        {
            build.AddCacheFile("cacheSettings.json", optional: false);
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="serviceProxyFactory"></param>
        public static void Test(IServiceProxyFactory serviceProxyFactory)
        {
            Task.Run(async () =>
            {
                IDomain model = new data.Domain
                {
                    Id = "CSG",
                    Name = "CSG",
                    Description = "CSG Company",
                    CreateTime = DateTime.Now,
                    TimeStamp = DateTime.Now.TimeOfDay,
                };
                var domainProxy = serviceProxyFactory.CreateProxy<IDomainCreate>("Domain");
                var domain = await domainProxy.Create(model);
                Console.WriteLine($"创建domain success");
            }).Wait();
        }

        public static void TestRabbitMq(IServiceProxyFactory serviceProxyFactory)
        {
            //serviceProxyFactory.CreateProxy<IUserService>("User").PublishThroughEventBusAsync(new UserEvent()
            //{
            //    Age = 18,
            //    Name = "fanly",
            //    UserId = 1
            //});
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public static void TestForRoutePath(IServiceProxyProvider serviceProxyProvider)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("user", JsonConvert.SerializeObject(new
            {
                Name = "fanly",
                Age = 18,
                UserId = 1
            }));
            string path = "api/user/getuser";
            string serviceKey = "User";

            var userProxy = serviceProxyProvider.Invoke<object>(model, path, serviceKey);
            var s = userProxy.Result;
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
        #endregion
    }
}
