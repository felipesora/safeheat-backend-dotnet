using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using safeheat_backend_dotnet.Application.Interfaces;
using safeheat_backend_dotnet.Application.Services;
using safeheat_backend_dotnet.Domain.Interfaces;
using safeheat_backend_dotnet.Infrastructure.Data.AppData;
using safeheat_backend_dotnet.Infrastructure.Data.Repositores;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IAbrigoRepository, AbrigoRepository>();
builder.Services.AddTransient<IAbrigoApplication, AbrigoApplication>();
builder.Services.AddTransient<IRecursoDisponivelRepository, RecursoDisponivelRepository>();
builder.Services.AddTransient<IRecursoDisponivelApplication, RecursoDisponivelApplication>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Serviços MVC + Swagger
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeHeat API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AbrigosWeb}/{action=Index}/{id?}");

app.Run();
