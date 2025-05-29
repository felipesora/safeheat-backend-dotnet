using Microsoft.EntityFrameworkCore;
using safeheat_backend_dotnet.Application.Interfaces;
using safeheat_backend_dotnet.Application.Services;
using safeheat_backend_dotnet.Domain.Interfaces;
using safeheat_backend_dotnet.Infrastructure.Data.AppData;
using safeheat_backend_dotnet.Infrastructure.Data.Repositores;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IAbrigoRepository, AbrigoRepository>();
builder.Services.AddTransient<IAbrigoApplication, AbrigoApplication>();
builder.Services.AddTransient<IRecursoDisponivelRepository, RecursoDisponivelRepository>();
builder.Services.AddTransient<IRecursoDisponivelApplication, RecursoDisponivelApplication>();

// Serviços MVC + Swagger
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
