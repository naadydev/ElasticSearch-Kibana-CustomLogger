using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace ElasticSearch
{
    public static class ConfigExtensions
    {
        public static void AddElasticSearchHelper(this IServiceCollection services, Action<ESConfigModel> setupAction)
        {
            services.Configure(setupAction);
            services.AddSingleton<IElasticSearchHelper>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ESConfigModel>>();
                return new ElasticSearchHelper(eSUrl: options.Value.ESURL, indexName: options.Value.IndexName);
            });
        }

        public class ESConfigModel
        {
            public string IndexName { get; set; }
            public string ESURL { get; set; }
        }

    }
}
