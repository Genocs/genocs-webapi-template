using Genocs.Core.Builders;
using Genocs.WebApi.Security;

namespace Genocs.Library.Template.WebApi;

public static class Extensions
{
    public static IGenocsBuilder AddServices(this IGenocsBuilder builder)
    {
        builder.AddCertificateAuthentication();

        // TODO: Add your services here
        // builder.Services.AddSingleton<IOrderServiceClient, OrderServiceClient>();
        // builder.Services.AddSingleton<IProductServiceClient, ProductServiceClient>();
        return builder;
    }
}
