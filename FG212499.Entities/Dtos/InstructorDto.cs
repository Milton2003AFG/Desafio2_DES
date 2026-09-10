using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Dtos
{
    public class InstructorDto
    {
        public int CodigoInstructor { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es requerida")]
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;
    }
}
