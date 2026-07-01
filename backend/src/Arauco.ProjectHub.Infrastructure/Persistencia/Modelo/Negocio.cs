namespace Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;

internal sealed class Negocio
{
    public Guid Identificador { get; private set; }

    public string Nombre { get; private set; } = string.Empty;

    public ICollection<Iniciativa> Iniciativas { get; } = [];
}
