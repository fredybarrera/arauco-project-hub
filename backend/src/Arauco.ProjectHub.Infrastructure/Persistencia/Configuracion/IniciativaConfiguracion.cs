using Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arauco.ProjectHub.Infrastructure.Persistencia.Configuracion;

internal sealed class IniciativaConfiguracion : IEntityTypeConfiguration<Iniciativa>
{
    public void Configure(EntityTypeBuilder<Iniciativa> builder)
    {
        builder.ToTable("iniciativa");

        builder.HasKey(iniciativa => iniciativa.Identificador);

        builder.Property(iniciativa => iniciativa.Identificador)
            .HasColumnName("identificador")
            .HasColumnType("uniqueidentifier")
            .ValueGeneratedNever();

        builder.Property(iniciativa => iniciativa.NegocioIdentificador)
            .HasColumnName("negocio_identificador")
            .HasColumnType("uniqueidentifier");

        ConfigurarTexto(builder.Property(iniciativa => iniciativa.Nombre), "nombre", 200);
        ConfigurarTexto(builder.Property(iniciativa => iniciativa.Objetivo), "objetivo", 2000);
        ConfigurarTexto(builder.Property(iniciativa => iniciativa.Justificacion), "justificacion", 4000);
        ConfigurarTexto(builder.Property(iniciativa => iniciativa.BeneficioEsperado), "beneficio_esperado", 4000);
        ConfigurarTexto(builder.Property(iniciativa => iniciativa.Estado), "estado", 50);

        builder.Property(iniciativa => iniciativa.FechaCreacion)
            .HasColumnName("fecha_creacion")
            .HasColumnType("datetime2(7)");

        builder.Property(iniciativa => iniciativa.Version)
            .HasColumnName("version")
            .IsRowVersion();

        builder.HasOne(iniciativa => iniciativa.Negocio)
            .WithMany(negocio => negocio.Iniciativas)
            .HasForeignKey(iniciativa => iniciativa.NegocioIdentificador)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(iniciativa => iniciativa.NegocioIdentificador)
            .HasDatabaseName("IX_iniciativa_negocio_identificador");

        builder.ToTable(tabla =>
        {
            tabla.HasCheckConstraint(
                "CK_iniciativa_nombre_no_vacio",
                "LEN(LTRIM(RTRIM([nombre]))) > 0");
            tabla.HasCheckConstraint(
                "CK_iniciativa_objetivo_no_vacio",
                "LEN(LTRIM(RTRIM([objetivo]))) > 0");
        });
    }

    private static void ConfigurarTexto(
        PropertyBuilder<string> propiedad,
        string columna,
        int longitud)
    {
        propiedad
            .HasColumnName(columna)
            .HasColumnType($"nvarchar({longitud})")
            .HasMaxLength(longitud)
            .IsRequired();
    }
}
