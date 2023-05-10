using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarina_API.Models
{
    public class EcomProduct
    {
        public int Id { get; set; }

        [ForeignKey("ProductImage")]
        public int? ImageURLId { get; set; }
        public virtual ProductImage ProductImage { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsBestSeller { get; set; }
        public bool? IsTopCollection { get; set; }
        public bool? IsNew { get; set; }
        public bool? Isfeatured { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
