using System.ComponentModel.DataAnnotations.Schema;

namespace Sarina_API.Models
{
    public class CreditType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
