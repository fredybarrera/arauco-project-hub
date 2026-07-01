namespace Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

public sealed record IniciativaParaConsulta(
    bool ParticipacionVerificada,
    IniciativaConsultada? Iniciativa);
