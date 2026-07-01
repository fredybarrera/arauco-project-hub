using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Arauco.ProjectHub.Api.Tests.Iniciativas;

public sealed class ConsultarIniciativaEndpointTests
{
    private static readonly Guid IniciativaIdentificador = Guid.NewGuid();
    private static readonly Guid NegocioIdentificador = Guid.NewGuid();

    [Fact]
    public async Task Devuelve_el_contrato_aprobado_para_una_consulta_permitida()
    {
        var iniciativa = new IniciativaConsultada(
            IniciativaIdentificador,
            NegocioIdentificador,
            "Celulosa",
            "Optimización Operacional",
            "Idea");
        await using var aplicacion =
            new AplicacionCu002(new IniciativaParaConsulta(true, iniciativa));
        using var cliente = CrearClienteAutenticado(aplicacion);

        var respuesta = await cliente.GetAsync(
            $"/api/iniciativas/{IniciativaIdentificador}");
        var contenido = await respuesta.Content.ReadFromJsonAsync<IniciativaRespuesta>();

        Assert.Equal(HttpStatusCode.OK, respuesta.StatusCode);
        Assert.NotNull(contenido);
        Assert.Equal(IniciativaIdentificador, contenido.IniciativaId);
        Assert.Equal(NegocioIdentificador, contenido.Negocio.NegocioId);
        Assert.Equal("Celulosa", contenido.Negocio.Nombre);
        Assert.Equal("Optimización Operacional", contenido.Nombre);
        Assert.Equal("Idea", contenido.EstadoIniciativa);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Usa_la_misma_respuesta_publica_para_ausencia_y_falta_de_participacion(
        bool iniciativaExiste)
    {
        var resultado = iniciativaExiste
            ? new IniciativaParaConsulta(false, null)
            : null;
        await using var aplicacion = new AplicacionCu002(resultado);
        using var cliente = CrearClienteAutenticado(aplicacion);

        var respuesta = await cliente.GetAsync(
            $"/api/iniciativas/{IniciativaIdentificador}");
        var contenido = await respuesta.Content.ReadFromJsonAsync<ErrorRespuesta>();

        Assert.Equal(HttpStatusCode.NotFound, respuesta.StatusCode);
        Assert.NotNull(contenido);
        Assert.Equal("iniciativa_no_encontrada", contenido.Codigo);
        Assert.Equal("No fue posible encontrar la Iniciativa.", contenido.Mensaje);
        Assert.False(string.IsNullOrWhiteSpace(contenido.CorrelacionId));
    }

    [Fact]
    public async Task Rechaza_una_solicitud_sin_identidad_autenticada()
    {
        await using var aplicacion = new AplicacionCu002(null);
        using var cliente = aplicacion.CreateClient(
            new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

        var respuesta = await cliente.GetAsync(
            $"/api/iniciativas/{IniciativaIdentificador}");

        Assert.Equal(HttpStatusCode.Unauthorized, respuesta.StatusCode);
    }

    private static HttpClient CrearClienteAutenticado(AplicacionCu002 aplicacion)
    {
        var cliente = aplicacion.CreateClient(
            new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        cliente.DefaultRequestHeaders.Add("X-Identidad-Prueba", "presente");
        return cliente;
    }

    private sealed class AplicacionCu002(IniciativaParaConsulta? resultado)
        : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configuration =>
            {
                configuration.AddInMemoryCollection(
                    new Dictionary<string, string?>
                    {
                        ["ConnectionStrings:AraucoProjectHub"] =
                            "Server=localhost;Database=AraucoProjectHubTests;Integrated Security=true;TrustServerCertificate=true",
                        ["MicrosoftEntra:Authority"] =
                            "https://login.microsoftonline.com/pruebas/v2.0",
                        ["MicrosoftEntra:Audience"] = "api://pruebas"
                    });
            });

            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IRecuperarIniciativaParaConsulta>();
                services.AddSingleton<IRecuperarIniciativaParaConsulta>(
                    new RecuperacionControlada(resultado));
                services
                    .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme =
                            AutenticacionPruebas.Esquema;
                        options.DefaultChallengeScheme =
                            AutenticacionPruebas.Esquema;
                    })
                    .AddScheme<AuthenticationSchemeOptions, AutenticacionPruebas>(
                        AutenticacionPruebas.Esquema,
                        _ => { });
            });
        }
    }

    private sealed class RecuperacionControlada(IniciativaParaConsulta? resultado)
        : IRecuperarIniciativaParaConsulta
    {
        public Task<IniciativaParaConsulta?> RecuperarAsync(
            Guid iniciativaIdentificador,
            IdentidadCorporativa identidadCorporativa,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(resultado);
        }
    }

    private sealed class AutenticacionPruebas(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : AuthenticationHandler<AuthenticationSchemeOptions>(
            options,
            logger,
            encoder)
    {
        public const string Esquema = "Pruebas";

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("X-Identidad-Prueba"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var claims = new[]
            {
                new Claim("tid", Guid.NewGuid().ToString()),
                new Claim("oid", Guid.NewGuid().ToString())
            };
            var identidad = new ClaimsIdentity(claims, Esquema);
            var principal = new ClaimsPrincipal(identidad);
            var ticket = new AuthenticationTicket(principal, Esquema);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }

    private sealed record IniciativaRespuesta(
        Guid IniciativaId,
        NegocioRespuesta Negocio,
        string Nombre,
        string EstadoIniciativa);

    private sealed record NegocioRespuesta(
        Guid NegocioId,
        string Nombre);

    private sealed record ErrorRespuesta(
        string Codigo,
        string Mensaje,
        string CorrelacionId);
}
