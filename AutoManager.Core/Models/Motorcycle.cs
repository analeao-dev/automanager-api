namespace AutoManager.Core.Models;
internal class Motorcycle
{
    public int Id { get; set; }
    public int EngineDisplacement { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
}
