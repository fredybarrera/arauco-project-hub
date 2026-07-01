using Arauco.ProjectHub.Api.Iniciativas;
using Arauco.ProjectHub.Infrastructure.Persistencia;
using Arauco.ProjectHub.Infrastructure.Persistencia.Consultas;
using Arauco.ProjectHub.Iniciativas.ConsultarIniciativa;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;
        options.Authority = builder.Configuration["MicrosoftEntra:Authority"];
        options.Audience = builder.Configuration["MicrosoftEntra:Audience"];
        options.RequireHttpsMetadata = true;
    });
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddDbContext<IniciativasDbContext>((services, options) =>
{
    var configuration = services.GetRequiredService<IConfiguration>();
    var connectionString =
        configuration.GetConnectionString("AraucoProjectHub")
        ?? throw new InvalidOperationException(
            "No se configuró la conexión de Arauco Project Hub.");

    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<
    IRecuperarIniciativaParaConsulta,
    RecuperarIniciativaParaConsulta>();
builder.Services.AddScoped<ConsultarIniciativa>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health").AllowAnonymous();
app.MapConsultarIniciativa();

app.Run();
public partial class Program
{
}
