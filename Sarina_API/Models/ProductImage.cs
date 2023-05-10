using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sarina_API.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ModifiedDate { get; set; }

    }
}
