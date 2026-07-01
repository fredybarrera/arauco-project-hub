using Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arauco.ProjectHub.Infrastructure.Persistencia.Configuracion;

internal sealed class NegocioConfiguracion : IEntityTypeConfiguration<Negocio>
{
    public void Configure(EntityTypeBuilder<Negocio> builder)
    {
        builder.ToTable("negocio");

        builder.HasKey(negocio => negocio.Identificador);

        builder.Property(negocio => negocio.Identificador)
            .HasColumnName("identificador")
            .HasColumnType("uniqueidentifier")
            .ValueGeneratedNever();

        builder.Property(negocio => negocio.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("nvarchar(200)")
            .HasMaxLength(200)
            .IsRequired();

        builder.ToTable(tabla =>
            tabla.HasCheckConstraint(
                "CK_negocio_nombre_no_vacio",
                "LEN(LTRIM(RTRIM([nombre]))) > 0"));
    }
}
