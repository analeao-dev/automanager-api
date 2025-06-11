using AutoManager.Api.Commom.Api;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Endpoints.Vehicles;

public class UpdateVehicleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandleAsync)
            .WithName("Vehicles: Update")
            .WithSummary("Atualiza informações do veículo")
            .WithDescription("Atualiza informações do veículo")
            .WithOrder(2)
            .Produces<Response<Vehicle?>>();

    private static async Task<IResult> HandleAsync(IVehicleService handler, UpdateVehicleRequest request, int id)
    {
        request.Id = id;

        var result = await handler.UpdateVehicleAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
