using AutoManager.Api.Data;
using AutoManager.Core.Models;
using AutoManager.Core.Requests.Vehicles;
using AutoManager.Core.Responses;
using AutoManager.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoManager.Api.Services;

public class VehicleService(AppDbContext context) : IVehicleService
{
    public async Task<Response<Vehicle?>> CreateAsync(CreateVehicleRequest request)
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
            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(vehicle, 201, "Veículo cadastrado com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível cadastrar veículo");
        }
    }

    public async Task<Response<Vehicle?>> UpdateAsync(UpdateVehicleRequest request)
    {
        try
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.Id == request.Id);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            vehicle.Plate = request.Plate;
            vehicle.Type = request.Type;
            vehicle.Brand = request.Brand;
            vehicle.Model = request.Model;
            vehicle.Year = request.Year;
            vehicle.Mileage = request.Mileage;
            vehicle.Image = request.Image;
            vehicle.LastMaintenanceDate = request.LastMaintenanceDate;

            context.Vehicles.Update(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(vehicle, 200, "Veículo atualizado com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível atualizar veículo");
        }
    }

    public async Task<Response<Vehicle?>> DeleteAsync(DeleteVehicleRequest request)
    {
        try
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.Id == request.Id);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(vehicle, 200, "Veículo exluído com sucesso");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível excluir veículo");
        }
    }

    public async Task<Response<Vehicle?>> GetByIdAsync(GetVehicleById request)
    {
        try
        {
            var vehicle = await context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == request.Id);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, "Veículo não encontrado");

            return new Response<Vehicle?>(vehicle);
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível retornar informações do veículo");
        }
    }

    public async Task<PagedResponse<List<Vehicle>?>> GetAllAsync(GetAllVehiclesRequest request)
    {
        try
        {
            var query = context.Vehicles
                .AsNoTracking()
                .OrderBy(v => v.CreatedAt);

            var vehicles = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Vehicle>?>(vehicles, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Vehicle>?>(null, 500, "Não foi possível retornar informações dos veículos");
        }
    }

    public async Task<Response<Vehicle?>> GetByPlateAsync(GetVehicleByPlateRequest request)
    {
        try
        {
            var vehicle = await context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Plate == request.Plate);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 404, $"Veículo com placa {request.Plate} não encontrado");

            return new Response<Vehicle?>(vehicle);
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Não foi possível retornar informações do veículo");
        }
    }
}
