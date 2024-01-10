using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ikigai.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public required string Nombre { get; set; }

        ICollection<DetalleCliente> DetalleClientesLink {get;set;}
        ICollection<TipoSubConsulta> TipoSubConsulta {get;set;}
    }
}