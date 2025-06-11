using AutoManager.Api.Repositories;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;

namespace AutoManager.Api.Services;

public class VehicleService(IVehicleRepository repository) : IVehicleService
{
    public async Task<Response<Vehicle?>> CreateVehicleAsync(CreateVehicleRequest request)
    {
        try
        {
            var vehicle = new Vehicle
            {
                Plate = request.Plate,
                Type = request.Type,
                Brand = request.Brand,
                Model = request.Model,
                Year = request.Year,
                Mileage = request.Mileage,
                Image = request.Image,
                LastMaintenanceDate = request.LastMaintenanceDate,
                State = request.State,
            };

            await repository.AddAsync(vehicle);

            return new Response<Vehicle?>(vehicle, 201, "Veículo cadastrado com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível cadastrar veículo");
        }
    }

    public async Task<Response<Vehicle?>> UpdateVehicleAsync(UpdateVehicleRequest request)
    {
        try
        {
            if (!await repository.ExistsAsync(request.Id))
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            var vehicle = new Vehicle
            {
                Id = request.Id,
                Plate = request.Plate,
                Type = request.Type,
                Brand = request.Brand,
                Model = request.Model,
                Year = request.Year,
                Mileage = request.Mileage,
                Image = request.Image,
                LastMaintenanceDate = request.LastMaintenanceDate,
                State = request.State
            };

            await repository.UpdateAsync(vehicle);

            return new Response<Vehicle?>(vehicle, 200, "Veículo atualizado com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível atualizar veículo");
        }
    }

    public async Task<Response<Vehicle?>> DeleteVehicleAsync(DeleteVehicleRequest request)
    {
        try
        {
            var vehicle = await repository.GetByIdAsync(request.Id);
            
            if (vehicle == null)
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            await repository.DeleteAsync(vehicle);

            return new Response<Vehicle?>(vehicle, 200, "Veículo exluído com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível excluir veículo");
        }
    }

    public async Task<Response<Vehicle?>> GetVehicleByIdAsync(GetVehicleByIdRequest request)
    {
        try
        {
            var vehicle = await repository.GetByIdAsync(request.Id);
            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            return new Response<Vehicle?>(vehicle);
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível retornar informações do veículo");
        }
    }

    public async Task<PagedResponse<List<Vehicle>?>> GetAllVehiclesAsync(GetAllVehiclesRequest request)
    {
        try
        {
            var vehicles = await repository.GetAllAsync(request);
            var count = vehicles.Count; 

            return new PagedResponse<List<Vehicle>?>(vehicles, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Vehicle>?>(null, 500, "Não foi possível retornar informações dos veículos");
        }
    }

    public async Task<Response<Vehicle?>> GetVehicleByPlateAsync(GetVehicleByPlateRequest request)
    {
        try
        {

            var vehicle = await repository.GetByPlateAsync(request);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, $"Veículo com placa {request.Plate} não encontrado");

            return new Response<Vehicle?>(vehicle);
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível retornar informações do veículo");
        }
    }

    public async Task<PagedResponse<List<Vehicle>?>> FilterVehiclesAsync(FilterVehicleRequest request)
    {
        try
        {
            if (request == null)
                return new PagedResponse<List<Vehicle>?>(null, 400, "Informe ao menos um parâmetro de busca");

            var vehicles = await repository.FilterAsync(request);
            var count = vehicles.Count;

            return new PagedResponse<List<Vehicle>?>(vehicles, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Vehicle>?>(null, 500, "Não foi possível retornar informações do veículo");
        }
    }
}
