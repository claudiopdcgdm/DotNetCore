using System;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Proeventos.API.Utils
{
    public class RemoveIdFromRequestFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.RequestBody == null)
                return;

            var method = context.ApiDescription.HttpMethod;

            if (method != "POST" && method != "PUT")
                return;

            foreach (var content in operation.RequestBody.Content)
            {
                var schema = content.Value.Schema;

                if (schema.Reference != null)
                {
                    var schemaName = schema.Reference.Id;

                    if (context.SchemaRepository.Schemas.ContainsKey(schemaName))
                    {
                        var referencedSchema = context.SchemaRepository.Schemas[schemaName];

                        if (referencedSchema.Properties.ContainsKey("id"))
                        {
                            Console.WriteLine("Removeu id do schema referenciado");
                            referencedSchema.Properties.Remove("id");
                        }
                    }
                }
                else
                {
                    if (schema.Properties.ContainsKey("id"))
                    {
                        Console.WriteLine("Removeu id direto");
                        schema.Properties.Remove("id");
                    }
                }
            }
        }
    }
}