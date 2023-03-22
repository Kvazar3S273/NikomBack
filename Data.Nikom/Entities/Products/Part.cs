using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Nikom.Entities.Products
{
    [Table("tblPart")]
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? Name { get; set; }

        public virtual ICollection<PartPhoto> PartPhoto { get; set; }

        [Required]
        public float Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
