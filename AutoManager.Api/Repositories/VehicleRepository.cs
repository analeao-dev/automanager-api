using AutoManager.Api.Data;
using AutoManager.Core.Models;
using AutoManager.Core.Requests;
using AutoManager.Core.Requests.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace AutoManager.Api.Repositories;

public class VehicleRepository(AppDbContext context) : IVehicleRepository
{
    public async Task<Vehicle?> AddAsync(Vehicle vehicle)
    {
        await context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> UpdateAsync(Vehicle vehicle)
    {
        context.Vehicles.Update(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> DeleteAsync(Vehicle vehicle)
    {
        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<List<Vehicle>> FilterAsync(FilterVehicleRequest request)
    {
        IQueryable<Vehicle> query = context.Vehicles.AsQueryable().OrderByDescending(v => v.CreatedAt);

        if (!string.IsNullOrWhiteSpace(request.Model))
        {
            query = query.Where(v => v.Model.Contains(request.Model));
        }

        if (request.Brand != null && request.Brand.Count != 0)
        {
            query = query.Where(v => request.Brand.Contains(v.Brand));
        }


        if (request.State != null && request.State.Count != 0)
        {
            query = query.Where(v => request.State.Contains(v.State));
        }

        if (request.Type.Count != 0)
        {
            query = query.Where(v => v.Type.HasValue && request.Type.Contains(v.Type.Value));
        }

        var count = await query.CountAsync();

        var vehicles = await query
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageSize)
        .ToListAsync();

        return vehicles;
    }

    public async Task<List<Vehicle>> GetAllAsync(PagedRequest request)
    {
        var query = context.Vehicles
               .AsNoTracking()
               .OrderByDescending(v => v.CreatedAt);

        var vehicles = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return vehicles;
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        var vehicle = await context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);

        return vehicle;
    }

    public async Task<Vehicle?> GetByPlateAsync(GetVehicleByPlateRequest request)
    {
        var vehicle = await context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Plate == request.Plate);

        return vehicle;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Vehicles.AnyAsync(v => v.Id == id);
    }
}
