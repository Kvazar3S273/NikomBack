using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nikom.Entities.Products
{
    [Table("tblPartPhoto")]
    public class PartPhoto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? Name { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }

        public virtual Part Part { get; set; }
    }
}