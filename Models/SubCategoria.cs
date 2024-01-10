using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ikigai.Models
{
    public class SubCategoria
    {
        [Key]
        public int SubCategoriaId { get; set; }

        public int CategoriaId { get; set; }

        [Required(ErrorMessage="La Descripción es obligatoria")]
        [stringlength(100)]

        public string  Descripcion { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria CategoriaId {get;set;}

        
    }
}