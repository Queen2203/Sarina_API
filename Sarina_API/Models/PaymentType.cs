using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sarina_API.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
