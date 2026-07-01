namespace Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

public interface IRecuperarIniciativaParaConsulta
{
    Task<IniciativaParaConsulta?> RecuperarAsync(
        Guid iniciativaIdentificador,
        IdentidadCorporativa identidadCorporativa,
        CancellationToken cancellationToken);
}
