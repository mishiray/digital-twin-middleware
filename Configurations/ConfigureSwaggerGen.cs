﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace DigitalTwinMiddleware.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }
        private OpenApiInfo CreateVersionInfo(
                ApiVersionDescription description)
        {

            var info = new OpenApiInfo()
            {
                Title = "Digital Twin Middleware API",
                Version = description.ApiVersion.ToString(),
                Description = "The Official Swagger Documentation for Digital Twin Middlware API.",
                Contact = new OpenApiContact() { Email = "woroumishael@gmail.com", Name = "Abiola Mishael" }
            };
    
            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
