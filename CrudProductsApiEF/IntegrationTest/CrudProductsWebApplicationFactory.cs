using CrudProductsApiEF.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public class CrudProductsWebApplicationFactory : WebApplicationFactory<Program>
{
    public AppDbContext Context { get; }

    private IServiceScope scope;

    public CrudProductsWebApplicationFactory()
    {
        this.scope = Services.CreateScope();
        Context =
            scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }
}
