namespace Arauco.ProjectHub.Api.Tests;

public sealed class AssemblyTests
{
    [Fact]
    public void ApiAssemblyIsAvailable()
    {
        Assert.Equal("Arauco.ProjectHub.Api", typeof(Program).Assembly.GetName().Name);
    }
}
