using HealFit.Models;

namespace HealFit.DTO; 
public class DadosDTO {
    public int DadosId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public double? Altura { get; set; }
    public double? Peso { get; set; }
    public int? Cep { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Bairro { get; set; }
    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
