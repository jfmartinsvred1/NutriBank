using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NutriBank.Data;
using NutriBank.Models;
using NutriBank.Services;
using System.Text;

var myAllowSpecifOrigins = "myAllowSpecifOrigins";

var builder = WebApplication.CreateBuilder(args);

var Conn = builder.Configuration.GetConnectionString("NutriBankConn");
// Add services to the container.

builder.Services.AddDbContext<NutriBankContext>(opts=>opts.UseMySql(Conn,ServerVersion.AutoDetect(Conn)));
builder.Services
    .AddIdentity<Usuario, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<NutriBankContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(name: myAllowSpecifOrigins, builder => 
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson
    (opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSUBFSUF(*F8YfbbfdIFBUFDBHS()*F8fYSBFYB")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero

    };
});
builder.Services.AddAuthorization();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ContaBancariaService>();
builder.Services.AddScoped<TransacaoService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecifOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
