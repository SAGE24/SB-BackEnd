using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration ConfigOcelot = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true).Build();

builder.Services.AddOcelot(ConfigOcelot);

string[] Origins = builder.Configuration["CorsConfiguration:Origins"]!.Split(',');
string[] Methods = builder.Configuration["CorsConfiguration:Methods"]!.Split(',');

//builder.Services.AddCors(options => {
//    options.AddPolicy("MyPolicy", builder => { builder.WithOrigins(Origins).WithMethods(Methods).AllowAnyHeader(); });
//});

// Add Authentication
string jwtSecurityKey = builder.Configuration["JwtConfiguration:Secret"]!;
byte[] keyGeneral = Encoding.UTF8.GetBytes(jwtSecurityKey);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options => {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyGeneral)
        };
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SB GATEWAY V1"); });
}

app.UseCors(builder =>
{
    builder.WithOrigins(Origins).WithMethods(Methods).AllowAnyHeader().Build();
}
);

app.UseCors();

app.UseOcelot().Wait();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
