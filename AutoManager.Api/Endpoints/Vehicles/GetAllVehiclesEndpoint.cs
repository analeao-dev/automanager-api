using AutoManager.Api.Commom.Api;
using AutoManager.Core;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoManager.Api.Endpoints.Vehicles;

public class GetAllVehiclesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Vehicles: GetAll")
            .WithSummary("Lista todos os veículos")
            .WithDescription("Lista todos os veículos de forma paginada")
            .WithOrder(4)
            .Produces<PagedResponse<List<Vehicle>?>>();

    private static async Task<IResult> HandleAsync(
        IVehicleService handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllVehiclesRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.GetAllVehiclesAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
