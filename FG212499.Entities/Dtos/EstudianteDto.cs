using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Dtos
{
    public class EstudianteDto
    {
        public int CodigoEstudiante { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
