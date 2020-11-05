using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Model
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedID { get; set; }

        public int UsuID { get; set; }
        
        [ForeignKey("UsuID")]
        public Usuario PedUsu { get; set; }

        public int ProID { get; set; }
        
        [ForeignKey("ProID")]
        public Producto PedProd { get; set; }

        [Column(TypeName = "money")]
        public decimal PedVrUnit { get; set; }
        
        public float PedCant { get; set; }
        
        [Column(TypeName = "money")]
        public decimal PedSubTot { get; set; }
        
        public float PedIVA { get; set; }
        
        [Column(TypeName = "money")]
        public decimal PedTotal { get; set; }
    }
}
