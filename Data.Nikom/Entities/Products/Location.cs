using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nikom.Entities.Products
{
    [Table("tblLocation")]
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string? Name { get; set; }
        [Required, StringLength(10)]
        public string? Box { get; set; }
        //public virtual ICollection<Box>? Boxes { get; set; }
    }
}
