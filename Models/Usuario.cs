using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ikigai.Models
{
    public class Usuario 
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage="El nombre es obligatorio")]
        [stringlength(50)]
        public string  Nombre { get; set; }

        [Required(ErrorMessage="El número de telélfono es obligatorio")]
        [stringlength(9)]
        public string  Telefono { get; set; }

        [Required(ErrorMessage="El email es obligatorio")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string  Correo { get; set; }
        
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Rol  Rol { get; set; }

    }
}