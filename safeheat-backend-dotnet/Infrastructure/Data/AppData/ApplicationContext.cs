using Microsoft.EntityFrameworkCore;
using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Infrastructure.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    public DbSet<AbrigoEntity> Abrigo { get; set; }
    public DbSet<RegistroDeEntradaEntity> RegistroDeEntrada { get; set; }
}
