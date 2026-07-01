using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arauco.ProjectHub.Infrastructure.Persistencia;

public sealed class IniciativasDbContextFactory
    : IDesignTimeDbContextFactory<IniciativasDbContext>
{
    public IniciativasDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<IniciativasDbContext>()
            .UseSqlServer(
                "Server=localhost;Database=AraucoProjectHub;Integrated Security=true;TrustServerCertificate=true")
            .Options;

        return new IniciativasDbContext(options);
    }
}
