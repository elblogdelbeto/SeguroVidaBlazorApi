using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegurosBlazorApp.Shared.Models
{
    public class Beneficiario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeneficiarioId { get; set; }
        public int PorcentajeParticipacion { get; set; }

        public int? PersonaId { get; set; }
        public Persona? Persona { get; set; }

        public int? EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }



    }
}
