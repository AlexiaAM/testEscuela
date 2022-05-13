using System;
using System.Collections.Generic;

namespace testI.BD
{
    public partial class Clasehasalumno
    {
        public int IdClase { get; set; }
        public int IdAlumno { get; set; }
        public int Calificacion { get; set; }
        public int Unidad { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; } = null!;
        public virtual Clase IdClaseNavigation { get; set; } = null!;
    }
}
