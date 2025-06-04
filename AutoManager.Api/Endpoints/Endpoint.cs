﻿using AutoManager.Api.Commom.Api;
using AutoManager.Api.Endpoints.Vehicles;

namespace AutoManager.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/vehicles")
            .WithTags("Vehicles")
            .MapEndpoint<CreateVehicleEndpoint>()
            .MapEndpoint<DeleteVehicleEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
