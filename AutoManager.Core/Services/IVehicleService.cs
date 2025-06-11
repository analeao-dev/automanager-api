using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;

namespace AutoManager.Core.Services;
public interface IVehicleService
{
    Task<Response<Vehicle?>> CreateAsync(CreateVehicleRequest request);
    Task<Response<Vehicle?>> UpdateAsync(UpdateVehicleRequest request);
    Task<Response<Vehicle?>> DeleteAsync(DeleteVehicleRequest request);
    Task<Response<Vehicle?>> GetByIdAsync(GetVehicleByIdRequest request);
    Task<Response<Vehicle?>> GetByPlateAsync(GetVehicleByPlateRequest request);
    Task<PagedResponse<List<Vehicle>?>> GetAllAsync(GetAllVehiclesRequest request);
    Task<PagedResponse<List<Vehicle>?>> FilterVehiclesAsync(FilterVehicleRequest request);
}
