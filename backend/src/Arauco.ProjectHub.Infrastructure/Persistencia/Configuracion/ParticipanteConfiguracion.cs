using Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arauco.ProjectHub.Infrastructure.Persistencia.Configuracion;

internal sealed class ParticipanteConfiguracion : IEntityTypeConfiguration<Participante>
{
    public void Configure(EntityTypeBuilder<Participante> builder)
    {
        builder.ToTable("participante");

        builder.HasKey(participante => participante.Identificador);

        builder.Property(participante => participante.Identificador)
            .HasColumnName("identificador")
            .HasColumnType("uniqueidentifier")
            .ValueGeneratedNever();

        builder.Property(participante => participante.IniciativaIdentificador)
            .HasColumnName("iniciativa_identificador")
            .HasColumnType("uniqueidentifier");

        ConfigurarTexto(
            builder.Property(participante => participante.IdentificacionPersonaOEquipo),
            "identificacion_persona_o_equipo",
            200);
        ConfigurarTexto(builder.Property(participante => participante.Nombre), "nombre", 200);
        ConfigurarTexto(
            builder.Property(participante => participante.RolParticipacion),
            "rol_participacion",
            100);

        builder.Property(participante => participante.IdentificadorTenant)
            .HasColumnName("identificador_tenant")
            .HasColumnType("uniqueidentifier");

        builder.Property(participante => participante.ObjectIdentifier)
            .HasColumnName("object_identifier")
            .HasColumnType("uniqueidentifier");

        builder.HasOne(participante => participante.Iniciativa)
            .WithMany(iniciativa => iniciativa.Participantes)
            .HasForeignKey(participante => participante.IniciativaIdentificador)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(participante => participante.IniciativaIdentificador)
            .HasDatabaseName("IX_participante_iniciativa_identificador");

        builder.HasIndex(
                participante => new
                {
                    participante.IniciativaIdentificador,
                    participante.IdentificadorTenant,
                    participante.ObjectIdentifier
                })
            .IsUnique()
            .HasFilter(
                "[identificador_tenant] IS NOT NULL AND [object_identifier] IS NOT NULL")
            .HasDatabaseName("UX_participante_identidad_corporativa");

        builder.ToTable(tabla =>
            tabla.HasCheckConstraint(
                "CK_participante_identidad_corporativa_conjunta",
                "([identificador_tenant] IS NULL AND [object_identifier] IS NULL) OR " +
                "([identificador_tenant] IS NOT NULL AND [object_identifier] IS NOT NULL)"));
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
