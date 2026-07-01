namespace Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;

internal sealed class Participante
{
    public Guid Identificador { get; private set; }

    public Guid IniciativaIdentificador { get; private set; }

    public string IdentificacionPersonaOEquipo { get; private set; } = string.Empty;

    public string Nombre { get; private set; } = string.Empty;

    public string RolParticipacion { get; private set; } = string.Empty;

    public Guid? IdentificadorTenant { get; private set; }

    public Guid? ObjectIdentifier { get; private set; }

    public Iniciativa Iniciativa { get; private set; } = null!;
}
