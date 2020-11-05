using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    [Table("ApiUsers")]
    public class ApiUser
    {
        [Key]
        public int ApUsuId { get; set; }
        [Required]
        public string ApUsuName { get; set; }
        [Required]
        public string ApUsuPass { get; set; }
        public int? ApUsuRol { get; set; }
    }
}
