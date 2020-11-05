using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuID { get; set; }// Autonum (1,1)
        [MaxLength(50)]
        [Required]
        public string UsuNombre { get; set; }// (50)
        [MaxLength(20)]
        [Required]
        public string UsuPass { get; set; }// (20)
        public List<Pedido> Pedidos { get; set; }
    }
}
