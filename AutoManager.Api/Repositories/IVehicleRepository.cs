using AutoManager.Core.Models;
using AutoManager.Core.Requests;
using AutoManager.Core.Requests.Vehicles;

namespace AutoManager.Api.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle?> AddAsync(Vehicle vehicle);
    Task<Vehicle?> UpdateAsync(Vehicle vehicle);
    Task<Vehicle?> DeleteAsync(Vehicle vehicle);
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle?> GetByPlateAsync( GetVehicleByPlateRequest request);
    Task<List<Vehicle>> GetAllAsync(PagedRequest request);
    Task<List<Vehicle>> FilterAsync(FilterVehicleRequest request);
    Task<bool> ExistsAsync(int id);
}
