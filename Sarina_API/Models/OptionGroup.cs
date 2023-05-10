﻿using Sarina_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sarina_API.Models
{
    public class OptionGroup
     {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OptionGroupType { get; set; }
        public int MinimumSelectable { get; set; }
        public int MaximumSelectable { get; set; }
        public int SortOrder { get; set; }
        public bool IsSynced { get; set; }
        public bool isactive { get; set; }
        public bool Updated { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public List<Option> Options { get; set; }
    }
}
