using System.ComponentModel.DataAnnotations;
namespace ComidasTipicasAPI.Models;
public class Cochabamba
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string IngredientePrincipal { get; set; } = null!;
    public string Restaurante { get; set; } = null!;
    public decimal Precio { get; set; }
}