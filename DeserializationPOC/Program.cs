using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Owin;

namespace DeserializationPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<StartUp>("http://localhost:8085");
            Console.WriteLine("Server is up");
            Console.ReadKey();
        }

        public class StartUp
        {
            public void Configuration(IAppBuilder builder)
            {
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                config.MapHttpAttributeRoutes();
                config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
                config.Formatters.JsonFormatter.SerializerSettings = new
                    JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                builder.UseWebApi(config);
            }
        }
    }
}
