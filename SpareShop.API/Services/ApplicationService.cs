using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpareShop.API.Helpers;
using SpareShop.API.Services.Auth;
using SpareShop.API.Services.Token;
using SpareShop.Data;
using SpareShop.Data.Managers.Brands;
using SpareShop.Data.Managers.Categoties;
using SpareShop.Data.Managers.Products;
using SpareShop.Data.Managers.ShoppingCart;
using SpareShop.Data.Repository._0_UnitOfWork;
using SpareShop.Data.Repository.BrandRepo;
using SpareShop.Data.Repository.CategoryRepo;
using SpareShop.Data.Repository.ProductRepo;
using SpareShop.Data.Repository.ShoppingCartRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.API.Services;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        #region Database

        //var connectionString = config.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
        var dbPath = Path.Join(Environment.CurrentDirectory, "SpareShopDatabase.db");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

        #endregion

        #region Identity Managers

        services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                options.User.RequireUniqueEmail = false;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        #endregion

        #region JWT & Authentication

        services.AddScoped<IAuthService, AuthService>();

        services.Configure<Jwt>(config.GetSection("JWT"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = config["JWT:Issuer"],
                ValidAudience = config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!))
            };
        });

        #endregion

        #region Authorization

        services.AddAuthorization(options =>
            {
                options.AddPolicy("Manager",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Manager"));
                options.AddPolicy("Vendor",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Manager", "Vendor"));
                options.AddPolicy("Client",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Manager", "Client"));
                options.AddPolicy("User",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Manager", "Client", "User"));

            }
        );

        #endregion

        #region Swagger

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Spare Parts API", Version = "v1" });
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {jwtSecurityScheme, Array.Empty<string>()}
            });

        });

        #endregion

        #region Repos & AutoMapper

        services.AddAutoMapper(typeof(ApplicationProfile).Assembly);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IProductRepo, ProductRepo>();
        services.AddScoped<IProductsManager, ProductsManager>();
        
        services.AddScoped<ICategoryRepo, CategoryRepo>();
        services.AddScoped<ICategoriesManager, CategoriesManager>();
        
        services.AddScoped<IBrandRepo, BrandRepo>();
        services.AddScoped<IBrandsManager, BrandsManager>();

        services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
        services.AddScoped<IShoppingCartsManager, ShoppingCartsManager>();

        #endregion

        return services;
    }
}