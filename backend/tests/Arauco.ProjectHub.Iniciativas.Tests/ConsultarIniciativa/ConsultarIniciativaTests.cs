using Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

namespace Arauco.ProjectHub.Iniciativas.Tests.ConsultarIniciativa;

public sealed class ConsultarIniciativaTests
{
    private static readonly Guid IniciativaIdentificador = Guid.NewGuid();
    private static readonly IdentidadCorporativa IdentidadCorporativa =
        new(Guid.NewGuid(), Guid.NewGuid());

    [Fact]
    public async Task Devuelve_iniciativa_cuando_la_participacion_esta_verificada()
    {
        var iniciativa = new IniciativaConsultada(
            IniciativaIdentificador,
            Guid.NewGuid(),
            "Celulosa",
            "Optimización Operacional",
            "Idea");
        var consulta = CrearConsulta(new IniciativaParaConsulta(true, iniciativa));

        var resultado = await consulta.EjecutarAsync(
            IniciativaIdentificador,
            IdentidadCorporativa,
            CancellationToken.None);

        var encontrada = Assert.IsType<ResultadoConsultaIniciativa.Encontrada>(resultado);
        Assert.Equal(iniciativa, encontrada.Iniciativa);
    }

    [Fact]
    public async Task Distingue_iniciativa_inexistente()
    {
        var consulta = CrearConsulta(null);

        var resultado = await consulta.EjecutarAsync(
            IniciativaIdentificador,
            IdentidadCorporativa,
            CancellationToken.None);

        Assert.IsType<ResultadoConsultaIniciativa.NoEncontrada>(resultado);
    }

    [Fact]
    public async Task No_expone_informacion_cuando_el_actor_no_participa()
    {
        var consulta = CrearConsulta(new IniciativaParaConsulta(false, null));

        var resultado = await consulta.EjecutarAsync(
            IniciativaIdentificador,
            IdentidadCorporativa,
            CancellationToken.None);

        Assert.IsType<ResultadoConsultaIniciativa.NoPermitida>(resultado);
    }

    private static Iniciativas.ConsultarIniciativa.ConsultarIniciativa CrearConsulta(
        IniciativaParaConsulta? resultado)
    {
        return new(new RecuperacionControlada(resultado));
    }

    private sealed class RecuperacionControlada(IniciativaParaConsulta? resultado)
        : IRecuperarIniciativaParaConsulta
    {
        public Task<IniciativaParaConsulta?> RecuperarAsync(
            Guid iniciativaIdentificador,
            IdentidadCorporativa identidadCorporativa,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(resultado);
        }
    }
}
