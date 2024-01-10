using System.ComponentModel.DataAnnotations;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ikigai.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required(ErrorMessage="El campo nombre es obligatorio")]
        [stringlength(50)]
        public string  Nombre { get; set; }
    }
}