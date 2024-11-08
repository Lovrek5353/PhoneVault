using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneVault.Data;
using PhoneVault.Enums;
using PhoneVault.Models;
using PhoneVault.Repositories;
using PhoneVault.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure SQL Server and EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhoneVaultContext>(options =>
    options.UseSqlServer(connectionString));

/*builder.Services.AddDbContext<PhoneVaultContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);*/

// Register repositories and services for dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<IAdminLogRepository, AdminLogRepository>();
builder.Services.AddScoped<AdminLogService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<InventoryService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddScoped<IShippingRepository, ShippingRepository>();
builder.Services.AddScoped<ShippingService>();

builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<ShoppingCartService>();

builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<OrderItemService>();

builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
builder.Services.AddScoped<ShoppingCartItemService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// Register Swagger services for API documentation
builder.Services.AddSwaggerGen();

var secret = builder.Configuration["Jwt:Secret"];
if (string.IsNullOrEmpty(secret))
{
    throw new ArgumentException("JWT secret is missing");
}

var privateKey = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(privateKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("admin", p => p.RequireRole(UserTypes.Admin))
    .AddPolicy("user", p => p.RequireRole(UserTypes.Customer, UserTypes.Admin));


// Add additional repositories and services as needed
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint
    app.UseSwagger();

    // Enable middleware to serve Swagger UI
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder => policyBuilder
    .AllowCredentials()
    .WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();