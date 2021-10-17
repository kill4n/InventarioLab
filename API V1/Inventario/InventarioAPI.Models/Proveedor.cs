using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string NIT { get; set; }
        [Required]
        [MaxLength(50)]
        public string RazonSocial { get; set; }
        [MaxLength(50)]
        public string NombreContacto { get; set; }
        [MaxLength(50)]
        public string EmailContacto { get; set; }
        [MaxLength(20)]
        public string NumeroContacto { get; set; }
    }
}
