using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sarina_API.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
    }
}
