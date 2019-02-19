using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Surging.Core.Caching.Configurations;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusKafka.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.services.server
{
    public class Startup
    {
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
            ServiceLocator.Current = builder.Build();
            return ServiceLocator.Current;
        }

        public void Configure(IContainer app)
        {

        }

        #region private method
        /// <summary>
        /// 配置日志服务
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {

        }

        private static void ConfigureEventBus(IConfigurationBuilder build)
        {
            build.AddEventBusFile("eventBusSettings.json", optional: false);
        }

        private void ConfigureCache(IConfigurationBuilder build)
        {
            build.AddCacheFile("cacheSettings.json", optional: false);
        }
        #endregion
    }
}
