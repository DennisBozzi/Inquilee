using Microsoft.OpenApi.Models;

namespace Inquilee.Configurations;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        // services.AddScoped<IAuthInterface, AuthService>();
        // services.AddScoped<IProdutoInterface, ProdutoService>();
        // services.AddScoped<IVendaInterface, VendaService>();

        services.AddHttpClient<string>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseNpgsql(connectionString));

        // services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        // {
        //     options.Authority = firebaseValidIssuer;
        //     options.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidIssuer = firebaseValidIssuer,
        //         ValidAudience = firebaseAudience,
        //     };
        // });
        
        // using (var scope = services.CreateScope())
        // {
        //     var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //     dbContext.Database.Migrate();
        // }

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor, insira o token JWT com o prefixo 'Bearer '",
                Name = "Authorization",
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
                    new string[] { }
                }
            });
        });
        
        
    }
}