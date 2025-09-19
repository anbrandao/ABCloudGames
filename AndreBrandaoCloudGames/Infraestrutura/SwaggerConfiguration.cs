using Microsoft.OpenApi.Models;

namespace AndreBrandaoCloudGamesApi.Infraestrutura
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Informações da API
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Andre Brandao Cloud Games",
                    Version = "v1",
                    Description = "Esta é uma API da AB Cloud Games",
                    Contact = new OpenApiContact
                    {
                        Name = "Andre C Brandao",
                        Email = "andre.brandao@epe.gov.br",
                        Url = new Uri("https://www.epe.gov.br/pt")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Creative Commons Atribuição 4.0 Internacional (CC BY 4.0)",
                        Url = new Uri("https://creativecommons.org/licenses/by/4.0/deed.en")
                    }
                });

                // Autenticação JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta forma: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}

