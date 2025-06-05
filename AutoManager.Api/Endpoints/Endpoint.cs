using AutoManager.Api.Commom.Api;
using AutoManager.Api.Endpoints.Vehicles;

namespace AutoManager.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("")
            .WithTags("Health Check")
            .MapGet("api/v1/status", () => new { message = "OK" });

        endpoints.MapGroup("/api/v1/vehicles")
            .WithTags("Vehicles")
            .MapEndpoint<CreateVehicleEndpoint>()
            .MapEndpoint<DeleteVehicleEndpoint>()
            .MapEndpoint<GetAllVehiclesEndpoint>()
            .MapEndpoint<GetVehicleByIdEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
