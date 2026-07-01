using Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;
using Microsoft.EntityFrameworkCore;

namespace Arauco.ProjectHub.Infrastructure.Persistencia.Consultas;

public sealed class RecuperarIniciativaParaConsulta(
    IniciativasDbContext context)
    : IRecuperarIniciativaParaConsulta
{
    public Task<IniciativaParaConsulta?> RecuperarAsync(
        Guid iniciativaIdentificador,
        IdentidadCorporativa identidadCorporativa,
        CancellationToken cancellationToken)
    {
        return context.Iniciativas
            .AsNoTracking()
            .Where(iniciativa => iniciativa.Identificador == iniciativaIdentificador)
            .Select(iniciativa => new IniciativaParaConsulta(
                iniciativa.Participantes.Any(participante =>
                    participante.IdentificadorTenant ==
                    identidadCorporativa.IdentificadorTenant &&
                    participante.ObjectIdentifier ==
                    identidadCorporativa.ObjectIdentifier),
                iniciativa.Participantes.Any(participante =>
                    participante.IdentificadorTenant ==
                    identidadCorporativa.IdentificadorTenant &&
                    participante.ObjectIdentifier ==
                    identidadCorporativa.ObjectIdentifier)
                    ? new IniciativaConsultada(
                        iniciativa.Identificador,
                        iniciativa.NegocioIdentificador,
                        iniciativa.Negocio.Nombre,
                        iniciativa.Nombre,
                        iniciativa.Estado)
                    : null))
            .SingleOrDefaultAsync(cancellationToken);
    }
}
