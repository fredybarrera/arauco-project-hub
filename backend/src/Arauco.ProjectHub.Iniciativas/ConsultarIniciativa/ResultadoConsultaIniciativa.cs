namespace Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

public abstract record ResultadoConsultaIniciativa
{
    private ResultadoConsultaIniciativa()
    {
    }

    public sealed record Encontrada(IniciativaConsultada Iniciativa)
        : ResultadoConsultaIniciativa;

    public sealed record NoEncontrada : ResultadoConsultaIniciativa;

    public sealed record NoPermitida : ResultadoConsultaIniciativa;
}
