using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;

namespace AutoManager.Core.Services;
public interface IVehicleService
{
    Task<Response<Vehicle?>> CreateVehicleAsync(CreateVehicleRequest request);
    Task<Response<Vehicle?>> UpdateVehicleAsync(UpdateVehicleRequest request);
    Task<Response<Vehicle?>> DeleteVehicleAsync(DeleteVehicleRequest request);
    Task<Response<Vehicle?>> GetVehicleByIdAsync(GetVehicleByIdRequest request);
    Task<Response<Vehicle?>> GetVehicleByPlateAsync(GetVehicleByPlateRequest request);
    Task<PagedResponse<List<Vehicle>?>> GetAllVehiclesAsync(GetAllVehiclesRequest request);
    Task<PagedResponse<List<Vehicle>?>> FilterVehiclesAsync(FilterVehicleRequest request);
}
