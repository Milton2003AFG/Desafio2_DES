using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Dtos
{
    public class InscripcionDto
    {
        public int CodigoInscripcion { get; set; }

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        [Required]
        public int CodigoEstudiante { get; set; }

        [Required]
        public int CodigoCurso { get; set; }

        public string? NombreEstudiante { get; set; }
        public string? TituloCurso { get; set; }
    }
}
