
using CropDealWebAPI.Configurations;
using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200",
                                              "http://localhost:3000").AllowCredentials().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders();
                      });
});



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CropDealContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection01")));
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<IRepository<UserProfile,int>, UserProfileRepository>();
builder.Services.AddScoped<UserProfileService, UserProfileService>();
builder.Services.AddScoped<IRepository<Crop, int>, CropRepository>();
builder.Services.AddScoped<CropService, CropService>();
builder.Services.AddScoped<IRepository<CropOnSale, int>, CropOnSaleRepository>();
builder.Services.AddScoped<CropOnSaleService, CropOnSaleService>();
builder.Services.AddScoped<IRepository<CropOnSale, int>, CropOnSaleRepository>();
builder.Services.AddScoped<CropOnSaleService, CropOnSaleService>();
builder.Services.AddScoped<IViewCropRepository, ViewCrops>();
builder.Services.AddScoped<ViewCropService,ViewCropService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepo>();
builder.Services.AddScoped<PaymentService, PaymentService>();
builder.Services.AddScoped<IRegisterRepository<CreateUserDto, UserProfile>,RegisterRepo>();
builder.Services.AddScoped<RegisterService, RegisterService>();
builder.Services.AddScoped<ILoginRepository<Login, int>, LoginRepo>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<IToken,TokenRepo>();
builder.Services.AddScoped<ExceptionRepositry ,ExceptionRepositry>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
      Description ="Standard Authorization header using the Bearer scheme(\"bearer {token}\")", 
      In =ParameterLocation.Header,
      Name = "authorization",
      Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer=false,
            ValidateAudience=false,
        };
    });
   
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseRouting(); 


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
