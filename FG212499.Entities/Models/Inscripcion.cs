using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.Entities.Models
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public string? NombreEstudiante { get; set; }
        public string? TituloCurso { get; set; }
    }
}
