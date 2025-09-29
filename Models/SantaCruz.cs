using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComidasTipicasAPI.Models;

public class SantaCruz
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Nombre { get; set; } = null!;                  // ej. "Majadito"

    [Required, StringLength(120)]
    public string IngredientePrincipal { get; set; } = null!;    // ej. "Charque de res"

    [Required, StringLength(120)]
    public string Restaurante { get; set; } = null!;             // ej. "Fogón Cruceño"

    [Range(0, 1000)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }                           // ej. 45.00
}