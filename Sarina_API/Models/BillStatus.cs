using System.ComponentModel.DataAnnotations.Schema;

namespace Sarina_API.Models
{
    public class BillStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
