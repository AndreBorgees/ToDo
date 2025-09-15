using FluentValidation.Results;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ToDo.API.Configuration
{
    public class IgnoreValidationResultSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context) 
        {
            if(context.Type == typeof(ValidationResult))
            {
                schema.Properties.Clear();
            }
        }
    }
}
