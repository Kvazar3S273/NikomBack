using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nikom.Entities.Products
{
    [Table("tblSubCategory")]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string? Name { get; set; }


    }
}
