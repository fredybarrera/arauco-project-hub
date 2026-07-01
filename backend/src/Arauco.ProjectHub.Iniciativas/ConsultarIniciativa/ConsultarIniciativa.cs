namespace Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

public sealed class ConsultarIniciativa(
    IRecuperarIniciativaParaConsulta recuperarIniciativa)
{
    public async Task<ResultadoConsultaIniciativa> EjecutarAsync(
        Guid iniciativaIdentificador,
        IdentidadCorporativa identidadCorporativa,
        CancellationToken cancellationToken)
    {
        var resultado = await recuperarIniciativa.RecuperarAsync(
            iniciativaIdentificador,
            identidadCorporativa,
            cancellationToken);

        if (resultado is null)
        {
            return new ResultadoConsultaIniciativa.NoEncontrada();
        }

        if (!resultado.ParticipacionVerificada || resultado.Iniciativa is null)
        {
            return new ResultadoConsultaIniciativa.NoPermitida();
        }

        return new ResultadoConsultaIniciativa.Encontrada(resultado.Iniciativa);
    }
}
