using AutoManager.Api.Commom.Api;
using AutoManager.Core;
using AutoManager.Core.Enums;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoManager.Api.Endpoints.Vehicles;

public class FilterVehiclesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/filter", HandleAsync)
           .WithName("Vehicles: Filter")
           .WithSummary("Filtra veículos por parâmetros")
           .WithDescription("Filtra veículos via query string")
           .WithOrder(7)
           .Produces<PagedResponse<Vehicle?>>();


    private static async Task<IResult> HandleAsync(
    IVehicleService handler,
    [FromQuery] string? model,
    [FromQuery] int[]? state,
    [FromQuery] string[]? brand,
    [FromQuery] EVehicleType[]? type,
    [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
    [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new FilterVehicleRequest
        {
            Model = model ?? string.Empty,
            State = state?.ToList() ?? new(),
            Brand = brand?.ToList() ?? new(),
            Type = type?.ToList() ?? new(),
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.FilterVehiclesAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }

}
