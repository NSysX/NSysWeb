using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace WebAPI.Core.Swagger
{
    public class DocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var endpoints = swaggerDoc.Paths.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //var paths = swaggerDoc.Paths;

            //var paths2 = endpoints as OpenApiPaths;

            //swaggerDoc.Paths = (OpenApiPaths)endpoints;


        }
    }
}
