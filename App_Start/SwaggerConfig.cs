using System.Web.Http;
using WebActivatorEx;
using WebApplication3;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApplication3
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {

                        c.SingleApiVersion("v1", "WebApplication3");

                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
