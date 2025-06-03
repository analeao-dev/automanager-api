using AutoManager.Core.Enums;

namespace AutoManager.Core.Models;
public class Vehicle
{
    public int Id { get; set; }
    public required string Plate { get; set; }
    public EVehicleType Type { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public DateOnly? LastMaintenanceDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
