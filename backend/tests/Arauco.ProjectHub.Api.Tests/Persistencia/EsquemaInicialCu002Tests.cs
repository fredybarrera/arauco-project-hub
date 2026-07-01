using Arauco.ProjectHub.Infrastructure.Persistencia;
using Arauco.ProjectHub.Infrastructure.Persistencia.Migraciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Arauco.ProjectHub.Api.Tests.Persistencia;

public sealed class EsquemaInicialCu002Tests
{
    [Fact]
    public void Modelo_contiene_solo_las_tres_estructuras_aprobadas()
    {
        using var context = CrearContexto();

        var tablas = context.Model.GetEntityTypes()
            .Select(tipo => tipo.GetTableName()!)
            .Order()
            .ToArray();

        Assert.Equal(["iniciativa", "negocio", "participante"], tablas);
    }

    [Fact]
    public void Iniciativa_configura_relacion_restrictiva_y_version_de_concurrencia()
    {
        using var context = CrearContexto();

        var iniciativa = ObtenerEntidad(context, "iniciativa");
        var negocio = iniciativa.FindProperty("NegocioIdentificador");
        var version = iniciativa.FindProperty("Version");
        var relacion = Assert.Single(iniciativa.GetForeignKeys());

        Assert.Equal("uniqueidentifier", negocio?.GetColumnType());
        Assert.Equal(DeleteBehavior.Restrict, relacion.DeleteBehavior);
        Assert.True(version?.IsConcurrencyToken);
        Assert.Equal(ValueGenerated.OnAddOrUpdate, version?.ValueGenerated);
        Assert.Equal("rowversion", version?.GetColumnType());
    }

    [Fact]
    public void Participante_configura_identidad_corporativa_conjunta_y_unica()
    {
        using var context = CrearContexto();

        var modelo = context.GetService<IDesignTimeModel>().Model;
        var participante = ObtenerEntidad(modelo, "participante");
        var tabla = StoreObjectIdentifier.Table("participante");
        var restricciones = participante.GetCheckConstraints();
        var indice = participante.GetIndexes()
            .Single(indice => indice.GetDatabaseName() == "UX_participante_identidad_corporativa");

        Assert.Contains(
            restricciones,
            restriccion => restriccion.Name == "CK_participante_identidad_corporativa_conjunta");
        Assert.True(indice.IsUnique);
        Assert.Equal(
            "[identificador_tenant] IS NOT NULL AND [object_identifier] IS NOT NULL",
            indice.GetFilter(tabla));
    }

    [Fact]
    public void Migracion_inicial_no_contiene_datos_semilla()
    {
        var migracion = new EsquemaInicialCu002();

        Assert.Empty(migracion.UpOperations.OfType<InsertDataOperation>());
    }

    private static IniciativasDbContext CrearContexto()
    {
        var options = new DbContextOptionsBuilder<IniciativasDbContext>()
            .UseSqlServer(
                "Server=localhost;Database=AraucoProjectHubTests;Integrated Security=true;TrustServerCertificate=true")
            .Options;

        return new IniciativasDbContext(options);
    }

    private static IReadOnlyEntityType ObtenerEntidad(
        IniciativasDbContext context,
        string tabla)
    {
        return ObtenerEntidad(context.Model, tabla);
    }

    private static IReadOnlyEntityType ObtenerEntidad(
        IModel modelo,
        string tabla)
    {
        return modelo.GetEntityTypes()
            .Single(tipo => tipo.GetTableName() == tabla);
    }
}
