using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    [Table("Reactivo")]
    public class Reactivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cantidad { get; set; }
        [Required]
        [MaxLength(10)]
        public string Unidad { get; set; }
        [Required]
        [MaxLength(250)]
        public string Fabricante { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public long IdProveedor { get; set; }
    }
}
