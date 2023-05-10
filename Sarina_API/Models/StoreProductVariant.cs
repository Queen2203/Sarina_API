﻿using Sarina_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sarina_API.Models
{
    public class StoreProductVariant
    {
        public int Id { get; set; }
        public bool Updated { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

         [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }
        public virtual Variant Variant { get; set; }

        public double? Price { get; set; }
        public double? TakeawayPrice { get; set; }
        public double? DeliveryPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int ProductVariantId { get; set; }
    }
}