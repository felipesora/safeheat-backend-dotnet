using Microsoft.EntityFrameworkCore;
using safeheat_backend_dotnet.Domain.Entities;

namespace safeheat_backend_dotnet.Infrastructure.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    public DbSet<AbrigoEntity> Abrigo { get; set; }
    public DbSet<RecursoDisponivelEntity> RecursoDisponivel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RecursoDisponivelEntity>()
            .HasOne(r => r.Abrigo)
            .WithMany(a => a.RecursosDisponiveis)
            .HasForeignKey(r => r.AbrigoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
