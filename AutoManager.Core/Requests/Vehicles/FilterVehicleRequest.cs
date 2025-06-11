using AutoManager.Core.Enums;

namespace AutoManager.Core.Requests.Vehicles;
public class FilterVehicleRequest : PagedRequest
{
    public string Model { get; set; } = string.Empty;
    public List<int> State { get; set; } = new List<int>();
    public List<string> Brand { get; set; } = new List<string>();
    public List<EVehicleType> Type { get; set; } = new List<EVehicleType>();
}
