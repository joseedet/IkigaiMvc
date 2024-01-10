using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ikigai.Models
{
    public class DetalleCliente
    {
        [Key]
        public int DetalleClienteId { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente  Cliente { get; set; }

        public int PlaninId { get; set; }

        [ForeignKey("PlaninId")]
        public Planin  Planin  { get; set; }

        public int TipoConsultaId {get;set;}

        [ForeignKey("TipoId")]
        public Categoria CategoriaId {get;set;}        
      

        public int Descripcion {get;set;}

        public string Observaciones {get;set;}

    }
}