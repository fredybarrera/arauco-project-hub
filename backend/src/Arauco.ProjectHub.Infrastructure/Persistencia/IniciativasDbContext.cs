using Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Arauco.ProjectHub.Infrastructure.Persistencia;

public sealed class IniciativasDbContext(DbContextOptions<IniciativasDbContext> options)
    : DbContext(options)
{
    internal DbSet<Negocio> Negocios => Set<Negocio>();

    internal DbSet<Iniciativa> Iniciativas => Set<Iniciativa>();

    internal DbSet<Participante> Participantes => Set<Participante>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IniciativasDbContext).Assembly);
    }
}
