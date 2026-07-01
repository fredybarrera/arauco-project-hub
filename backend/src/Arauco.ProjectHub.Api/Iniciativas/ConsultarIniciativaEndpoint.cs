using System.Diagnostics;
using System.Security.Claims;
using Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;

namespace Arauco.ProjectHub.Api.Iniciativas;

public static class ConsultarIniciativaEndpoint
{
    public static IEndpointRouteBuilder MapConsultarIniciativa(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(
                "/api/iniciativas/{iniciativaId:guid}",
                EjecutarAsync)
            .RequireAuthorization();

        return endpoints;
    }

    private static async Task<IResult> EjecutarAsync(
        Guid iniciativaId,
        ClaimsPrincipal principal,
        ConsultarIniciativa consultarIniciativa,
        HttpContext httpContext,
        CancellationToken cancellationToken)
    {
        if (!TryObtenerIdentidadCorporativa(
                principal,
                out var identidadCorporativa))
        {
            return Results.Unauthorized();
        }

        var resultado = await consultarIniciativa.EjecutarAsync(
            iniciativaId,
            identidadCorporativa,
            cancellationToken);

        return resultado switch
        {
            ResultadoConsultaIniciativa.Encontrada encontrada =>
                Results.Ok(IniciativaRespuesta.Desde(encontrada.Iniciativa)),
            ResultadoConsultaIniciativa.NoEncontrada =>
                NoEncontrada(httpContext),
            ResultadoConsultaIniciativa.NoPermitida =>
                NoEncontrada(httpContext),
            _ => throw new UnreachableException()
        };
    }

    private static bool TryObtenerIdentidadCorporativa(
        ClaimsPrincipal principal,
        out IdentidadCorporativa identidadCorporativa)
    {
        var tenant = principal.FindFirstValue("tid");
        var objectIdentifier = principal.FindFirstValue("oid");

        if (Guid.TryParse(tenant, out var identificadorTenant) &&
            Guid.TryParse(objectIdentifier, out var identificadorObjeto))
        {
            identidadCorporativa =
                new IdentidadCorporativa(identificadorTenant, identificadorObjeto);
            return true;
        }

        identidadCorporativa = null!;
        return false;
    }

    private static IResult NoEncontrada(HttpContext context)
    {
        var correlacionId =
            Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier;

        return Results.NotFound(new ErrorRespuesta(
            "iniciativa_no_encontrada",
            "No fue posible encontrar la Iniciativa.",
            correlacionId));
    }

    private sealed record IniciativaRespuesta(
        Guid IniciativaId,
        NegocioRespuesta Negocio,
        string Nombre,
        string EstadoIniciativa)
    {
        public static IniciativaRespuesta Desde(IniciativaConsultada iniciativa)
        {
            return new IniciativaRespuesta(
                iniciativa.IniciativaIdentificador,
                new NegocioRespuesta(
                    iniciativa.NegocioIdentificador,
                    iniciativa.NombreNegocio),
                iniciativa.Nombre,
                iniciativa.EstadoIniciativa);
        }
    }

    private sealed record NegocioRespuesta(
        Guid NegocioId,
        string Nombre);

    private sealed record ErrorRespuesta(
        string Codigo,
        string Mensaje,
        string CorrelacionId);
}
