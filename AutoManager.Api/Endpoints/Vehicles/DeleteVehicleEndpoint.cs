using AutoManager.Api.Commom.Api;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Endpoints.Vehicles;

public class DeleteVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Vehicles: Delete")
            .WithSummary("Exclui um veículo")
            .WithDescription("Exclui veículo")
            .WithOrder(5)
            .Produces<Response<Vehicle?>>();

    private static async Task<IResult> HandleAsync(IVehicleService handler, int id)
    {
        var request = new DeleteVehicleRequest
        {
            Id = id
        };

        var result = await handler.DeleteVehicleAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
