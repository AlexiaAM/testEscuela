using System;
using System.Collections.Generic;

namespace testI.BD
{
    public partial class Maestro
    {
        public Maestro()
        {
            Clases = new HashSet<Clase>();
        }

        public int IdMaestro { get; set; }
        public string NombreMaestro { get; set; } = null!;

        public virtual ICollection<Clase> Clases { get; set; }
    }
}
