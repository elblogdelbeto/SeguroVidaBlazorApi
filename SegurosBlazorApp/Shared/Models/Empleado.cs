using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegurosBlazorApp.Shared.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }
        public string NumeroEmpleado { get; set; }


        public int? PersonaId { get; set; }
        public Persona? Persona { get; set; }

        
        public List<Beneficiario>? Beneficiarios { get; set; }

    }
}
