using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int ProID { get; set; } // Autonum(1,1)
        [MaxLength(50)]
        [Required]
        public string ProDesc { get; set; } // (50)
        [Column(TypeName = "money")]
        public decimal ProValor { get; set; } // money

        public List<Pedido> Pedidos { get; set; }
    }
}
