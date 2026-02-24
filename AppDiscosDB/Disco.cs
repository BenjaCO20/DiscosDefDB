using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiscosDB
{
    internal class Disco
    {
        public string Titulo { get; set; }
        public DateTime FechaDeLanzamiento { get; set; }

        public int CantCanciones { get; set; }

        public string UrlImagen { get; set; }

        public Elemento Estilo { get; set; }

        public Elemento TipoEdicion { get; set; }
    }
}
