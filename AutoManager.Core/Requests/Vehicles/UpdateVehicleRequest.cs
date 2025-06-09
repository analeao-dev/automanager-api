using AutoManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AutoManager.Core.Requests.Vehicles;
public class UpdateVehicleRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Placa de veículo inválida")]
    public required string Plate { get; set; }

    [Required(ErrorMessage = "Tipo do veículo inválido")]
    public EVehicleType Type { get; set; }

    [Required(ErrorMessage = "Marca do veículo é obrigatória")]
    public required string Brand { get; set; }

    [Required(ErrorMessage = "Modelo do veículo é obrigatório")]
    public required string Model { get; set; }

    [Required(ErrorMessage = "Ano do veículo inválido")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Quilometragem do veículo inválida")]
    public int Mileage { get; set; }

    public string? Image { get; set; }

    public DateOnly? LastMaintenanceDate { get; set; }
    
    public int State { get; set; }
}
