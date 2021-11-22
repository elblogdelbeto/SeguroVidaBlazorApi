using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APImaxillc.Models
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }        
        public string CURP { get; set; }
        public string SSN { get; set; }
        public string Telefono { get; set; }
        public string Nacionalidad { get; set; }

        public Beneficiario? Beneficiario { get; set; }
        public Empleado? Empleado { get; set; }

    }
}
