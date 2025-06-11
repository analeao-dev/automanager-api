using AutoManager.Api.Commom.Api;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Endpoints.Vehicles;

public class CreateVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Vehicles: Create")
            .WithSummary("Cria um novo veículo")
            .WithDescription("Cria um novo veículo")
            .WithOrder(1)
            .Produces<Response<Vehicle?>>();

    private static async Task<IResult> HandleAsync(IVehicleService handler, CreateVehicleRequest request)
    {
        var response = await handler.CreateVehicleAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/vehicles/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}
