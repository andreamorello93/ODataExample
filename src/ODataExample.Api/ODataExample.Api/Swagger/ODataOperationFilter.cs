using Azure;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ODataExample.Api.Swagger
{
    public class ODataOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null && descriptor.Parameters.Any(p => p.ParameterType.BaseType == typeof(ODataQueryOptions)))
            {
                context.ApiDescription.ActionDescriptor.AttributeRouteInfo.Name += context.ApiDescription.HttpMethod;

                if (descriptor.AttributeRouteInfo.Name.Contains("$count")) return;
               
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$select",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    Description = "Returns only the selected properties. (ex. FirstName, LastName, City)",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$expand",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    Description = "Include only the selected objects. (ex. Childrens, Locations)",
                    Required = false
                });

                if (descriptor.MethodInfo.ReturnType.BaseType == typeof(SingleResult)) return;

                operation.Parameters.Add(new ()
                {
                    Name = "$filter",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    Description = "Filter the response with OData filter queries.",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$top",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"                        
                    },                    
                    Description = "Number of objects to return. (ex. 10)",
                    Required = false,
                    Example = new OpenApiInteger(10)
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$skip",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    Description = "Number of objects to skip in the current order (ex. 50)",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$count",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "bool",
                    },
                    Description = "Return count of the items based on query",
                    Required = false
                });

                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$orderby",
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                    },
                    Description = "Define the order by one or more fields (ex. LastModified)",
                    Required = false
                });

            }
        }
    }
}
