using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegurosBlazorApp.Shared.Models
{
    public class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DireccionId { get; set; }
        public string Calle { get; set; } = null!;
               
        public Persona? Persona { get; set; }
    }
}
