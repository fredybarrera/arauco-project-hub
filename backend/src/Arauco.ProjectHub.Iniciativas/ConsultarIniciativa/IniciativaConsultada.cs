namespace Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

public sealed record IniciativaConsultada(
    Guid IniciativaIdentificador,
    Guid NegocioIdentificador,
    string NombreNegocio,
    string Nombre,
    string EstadoIniciativa);
