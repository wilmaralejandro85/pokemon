using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Servicios.Api.Helpers;

using Servicios.Core.Entities;

using Servicios.Core.Interfaces;


using Servicios.Core.Services;

using Servicios.Infrastructure.Filters;
using Servicios.Infrastructure.Repositories;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "-myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://apicloud.emtelco.co")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
//
// Add services to the container.
//

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Referencias Circulares y Filtro de excepciones globales
builder.Services.AddControllers(options =>
{
    // Filto de excepciones globales
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    // Eliminar referencias circulares
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = null;
});

// config swagger
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API_POKEMON",
        Version = "v1",
        Description = "Api para consultar habilidades pokemon"
    });

    // config to show auth in swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

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

// Eliminar referencias circulares
/*builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});*/


// Fluent Validation
builder.Services.AddMvc().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



async Task<string> GetDbConexionDecrypt(string connectionString)
{

    DecryptText resp = new DecryptText();
    using (var client = new HttpClient())
    {
        var reqjson = builder.Configuration[connectionString];
        var url = builder.Configuration["AppSettings:url_decryptText"];
        
        client.DefaultRequestHeaders.Accept.Clear();
        var content = new StringContent(reqjson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(url, content);
        var input = response.Content.ReadAsStringAsync().Result;

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //se agrega nuget Microsoft.AspNetCore.Mvc.NewtonsoftJson para poder hacer esta instruccion
            resp = Newtonsoft.Json.JsonConvert.DeserializeObject<DecryptText>(input);
            return resp.data;
        }
        else
        {
            return null;
        }

    }
}



builder.Services.AddTransient<ITokenRepository, TokenRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IEncryptHelper, EncryptHelper>(); // to use encrypt services
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();

// Inyección de dependencia de Helpers
builder.Services.AddScoped<IEncryptHelper, EncryptHelper>(); // to use encrypt servies
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();


builder.Services.AddTransient<IConsultarPokemonRepository, ConsultarPokemonRepository>();
builder.Services.AddTransient<IConsultarPokemonService, ConsultarPokemonService>();

// Autenticación
//
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
});


//configurar CORS para permitir peticiones del cliente
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);
//--------------------------------------------------
var app = builder.Build();



//llamados de los CORS
app.UseCors();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Autenticación 
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
