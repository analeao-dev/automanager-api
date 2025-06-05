using AutoManager.Api.Commom.Api;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Endpoints.Vehicles;

public class GetVehicleByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandleAsync)
            .WithName("Vehicles: GetById")
            .WithSummary("Retorna um veículo por Id")
            .WithDescription("Retorna um veículo por Id")
            .WithOrder(3)
            .Produces<Response<Vehicle?>>();

    private static async Task<IResult> HandleAsync(IVehicleService handler, int id)
    {
        var request = new GetVehicleByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
