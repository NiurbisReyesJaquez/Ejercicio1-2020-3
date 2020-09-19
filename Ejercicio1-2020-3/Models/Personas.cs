using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio1_2020_3.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        [Required (ErrorMessage = "Es obligatorio introducir un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;

    }
}
