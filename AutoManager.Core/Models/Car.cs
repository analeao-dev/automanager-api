namespace AutoManager.Core.Models;
public class Car
{
    public int Id { get; set; }
    public int NumberOfDoors { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
}
