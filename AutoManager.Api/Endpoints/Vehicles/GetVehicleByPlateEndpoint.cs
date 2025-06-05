using AutoManager.Api.Commom.Api;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Endpoints.Vehicles;

public class GetVehicleByPlateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/by-plate/{plate}", HandleAsync)
            .WithName("Vehicles: GetByPlate")
            .WithSummary("Retorna um veículo por placa")
            .WithDescription("Retorna um veículo por placa")
            .WithOrder(6)
            .Produces<Response<Vehicle?>>();

    private static async Task<IResult> HandleAsync(IVehicleService handler, string plate)
    {
        var request = new GetVehicleByPlateRequest
        {
            Plate = plate
        };

        var result = await handler.GetByPlateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
