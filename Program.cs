using AzaliaJwellery.Data;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    //options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;


});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("?? No connection string provided. Running without DB.");
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AzaliaJewellery API", Version = "v1" });

//    // Map IFormFile to binary in Swagger
//    c.MapType<IFormFile>(() => new OpenApiSchema
//    {
//        Type = "string",
//        Format = "binary"
//    });
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "YourIssuer",
        ValidAudience = "YourAudience",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("YourVeryLongAndStrongSecretKey123456")) // Must match the AuthController key
    };
});
builder.Services.AddScoped<GetProductsByCategoryIdEngagementQueryHandler>();

builder.Services.AddAuthorization();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICustomOptionRepository, CustomOptionRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IJewelleryTypeRepository, JewelleryTypeRepository>();
builder.Services.AddScoped<IProductJewelleryTypeRepository, ProductJewelleryTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();



//Handlers
builder.Services.AddTransient<CreateProductHandler>();
builder.Services.AddTransient<UpdateProductHandler>();
builder.Services.AddTransient<DeleteProductHandler>();
builder.Services.AddTransient<GetProductByIdHandler>();
builder.Services.AddTransient<GetAllProductsHandler>();


builder.Services.AddTransient<CreateAddressHandler>();
builder.Services.AddTransient<CreateCustomOptionHandler>();
builder.Services.AddTransient<CreateOrderHandler>();
builder.Services.AddTransient<CreatePaymentHandler>();
builder.Services.AddTransient<CreateUserHandler>();
builder.Services.AddTransient<DeleteAddressHandler>();
builder.Services.AddTransient<DeleteCustomOptionHandler>();
builder.Services.AddTransient<DeleteOrderHandler>();
builder.Services.AddTransient<DeletePaymentHandler>();
builder.Services.AddTransient<DeleteUserHandler>();
builder.Services.AddTransient<GetAddressByIdHandler>();
builder.Services.AddTransient<GetAllAddressesByUserIdHandler>();
builder.Services.AddTransient<GetAllCustomOptionesByUserIdHandler>();
builder.Services.AddTransient<GetAllOrderHandler>();
builder.Services.AddTransient<GetAllPaymentHandler>();
builder.Services.AddTransient<GetAllUserHandler>();
builder.Services.AddTransient<GetCustomOptionByIdHandler>();
builder.Services.AddTransient<GetOrderByIdHandler>();
builder.Services.AddTransient<GetPaymentByIdHandler>();
builder.Services.AddTransient<GetUserByIdHandler>();
builder.Services.AddTransient<UpdateAddressHandler>();
builder.Services.AddTransient<UpdateCustomOptionHandler>();
builder.Services.AddTransient<UpdateOrderHandler>();
builder.Services.AddTransient<UpdatePaymentHandler>();
builder.Services.AddTransient<UpdateUserHandler>();
builder.Services.AddTransient<GetAllJewelleryTypesHandler>();

builder.WebHost.CaptureStartupErrors(true)
               .UseSetting("detailedErrors", "true");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AzaliaJwelleryContext>();

Console.WriteLine("Connection string:");
Console.WriteLine(connectionString);

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
