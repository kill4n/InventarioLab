using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    [Table("Rol")]

    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdRol { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
