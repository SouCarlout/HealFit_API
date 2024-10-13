using System.ComponentModel.DataAnnotations;

namespace HealFit.Models; 
public class Consumo {

    [Key]
    public int ConsumoId { get; set; }
    public DateTime Data { get; set; }
    public double Quantidade { get; set; }

    [StringLength(50)]
    public string Produto { get; set; }
    public int ServingId { get; set; }
    [StringLength(50)]
    public string ServingDescription { get; set; }
    [StringLength(10)]
    public string MetricServingAmount { get; set; }
    [StringLength(8)]
    public string MetricServingUnit { get; set; }
    [StringLength(8)]
    public string NumberOfUnits { get; set; }
    [StringLength(50)]
    public string MeasurementDescription { get; set; }
    [StringLength(8)]
    public string? Calories { get; set; }
    [StringLength(8)]
    public string? Carbohydrate { get; set; }
    [StringLength(8)]
    public string? Protein { get; set; }
    [StringLength(8)]
    public string? Fat { get; set; }
    [StringLength(8)]
    public string? SaturatedFat { get; set; }
    [StringLength(8)]
    public string? PolyunsaturatedFat { get; set; }
    [StringLength(8)]
    public string? MonounsaturatedFat { get; set; }
    [StringLength(8)]
    public string? Cholesterol { get; set; }
    [StringLength(8)]
    public string? Sodium { get; set; }
    [StringLength(8)]
    public string? Potassium { get; set; }
    [StringLength(8)]
    public string? Fiber { get; set; }
    [StringLength(8)]
    public string? Sugar { get; set; }
    [StringLength(8)]
    public string? VitaminA { get; set; }
    [StringLength(8)]
    public string? VitaminC { get; set; }
    [StringLength(8)]
    public string? Calcium { get; set; }
    [StringLength(8)]
    public string? Iron { get; set; }
    [StringLength(8)]
    public string? TransFat { get; set; }
    [StringLength(8)]
    public string? AddedSugars { get; set; }
    [StringLength(8)]
    public string? VitaminD { get; set; }
    [StringLength(8)]
    public int UsuarioId { get; set; }
}
