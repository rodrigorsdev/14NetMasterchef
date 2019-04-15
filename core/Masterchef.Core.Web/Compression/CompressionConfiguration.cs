using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Masterchef.Core.Web.Compression
{
    public static class CompressionConfiguration
    {
        public static void AddCompression(this IServiceCollection services, CompressionLevel compressionLevel)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = compressionLevel);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
        }
    }
}