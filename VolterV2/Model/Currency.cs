using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolterV2.Model
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Range(0.00, 100.00)]
        public decimal Value { get; set; }
    }
}
