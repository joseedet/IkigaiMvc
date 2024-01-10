using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ikigai.Models
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }

        public string  Nombre { get; set; }

        public int ClienteId { get; set; }
        
        public Cliente Cliente { get; set; }
    }
}