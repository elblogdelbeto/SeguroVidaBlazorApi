using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APImaxillc.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }
        public int NumeroEmpleado { get; set; }


        public int? PersonaId { get; set; }
        public Persona? Persona { get; set; }

        
        public List<Beneficiario>? Beneficiarios { get; set; }

    }
}
