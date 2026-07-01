namespace Arauco.ProjectHub.Infrastructure.Persistencia.Modelo;

internal sealed class Iniciativa
{
    public Guid Identificador { get; private set; }

    public Guid NegocioIdentificador { get; private set; }

    public string Nombre { get; private set; } = string.Empty;

    public string Objetivo { get; private set; } = string.Empty;

    public string Justificacion { get; private set; } = string.Empty;

    public string BeneficioEsperado { get; private set; } = string.Empty;

    public string Estado { get; private set; } = string.Empty;

    public DateTime FechaCreacion { get; private set; }

    public byte[] Version { get; private set; } = [];

    public Negocio Negocio { get; private set; } = null!;

    public ICollection<Participante> Participantes { get; } = [];
}
