using System;
using System.Collections.Generic;

namespace testI.BD
{
    public partial class Clase
    {
        public int IdClase { get; set; }
        public string NombreClase { get; set; } = null!;
        public int IdMaestro { get; set; }

        public virtual Maestro IdMaestroNavigation { get; set; } = null!;
    }
}
