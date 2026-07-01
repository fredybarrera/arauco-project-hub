using Arauco.ProjectHub.Iniciativas;

namespace Arauco.ProjectHub.Iniciativas.Tests;

public sealed class DependencyTests
{
    [Theory]
    [InlineData("Microsoft.AspNetCore")]
    [InlineData("Microsoft.EntityFrameworkCore")]
    [InlineData("Azure")]
    public void IniciativasDoesNotReferenceInfrastructure(string prohibitedPrefix)
    {
        var references = typeof(IniciativasAssembly).Assembly.GetReferencedAssemblies();

        Assert.DoesNotContain(references, reference =>
            reference.Name?.StartsWith(prohibitedPrefix, StringComparison.Ordinal) == true);
    }
}
