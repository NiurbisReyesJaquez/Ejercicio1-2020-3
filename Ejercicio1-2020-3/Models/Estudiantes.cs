using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio1_2020_3.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        [Required (ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }
        [Range (minimum:1, maximum:10, ErrorMessage ="Seleccione un semestre")]
        public int Semestre { get; set; }
       
    }
}
 