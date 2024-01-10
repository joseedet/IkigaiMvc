using System.ComponentModel.DataAnnotations;

namespace Ikigai.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }    

        public int TipoDocumentoId { get; set; }  

        [Required(ErrorMessage="El número de documento es obligatorio")]
        public string  Documento { get; set; }    

        [Required(ErrorMessage="El campo Nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage="El campo Apellidos es obligatorio")]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage="El campo Dirección es obligatorio")]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Required(ErrorMessage="El campo Población es obligatorio")]
        [MaxLength(100)]
        public string Poblacion { get; set; }

        [Required(ErrorMessage="El campo Código Postal es obligatorio")]
        [MaxLength(5)]
        public string CodPostal { get; set; }

        [Required(ErrorMessage="El campo Provincia es obligatorio")]
        [MaxLength(50)]
        public string Provincia { get; set; }

        [Required(ErrorMessage="El campo Teléfono es obligatorio")]
        [MaxLength(9)]
        public string Telefono { get; set; }

        [Required(ErrorMessage="El campo Correo es obligatorio")]
        [stringlength(255)]
        public string Correo { get; set; }

        [stringlength(MaxLength)]
        public string Observaciones { get; set; }

        public bool Activo { get; set; }=true;
        
        [ForeignKey("TipoDocumentoId")] 
        public TipoDocumento TipoDocumento {get;set;} 


        ICollection<DetalleCliente> ListaDetalleCliente {get;set;}
        ICollection<TipoDocumento> ListaDocumento {get;set;}

    }
}