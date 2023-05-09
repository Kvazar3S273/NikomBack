using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nikom.Entities.Products
{
    [Table("tblBox")]
    public class Box
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string? Name { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }
    }
}
