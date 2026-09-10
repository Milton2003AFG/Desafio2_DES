using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Dtos
{
    public class CursoDto
    {
        public int CodigoCurso { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; } = string.Empty; // Validado en BL

        [Required]
        public int CodigoInstructor { get; set; }

        public string? NombreInstructor { get; set; }
    }
}
