using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCantor.Model
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
        public DateTime DataTime { get; set; }

        public Currency() { }
        /*public Currency(int id, string name, string shortName, decimal value)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Value = value;
        }*/
        public Currency(string name, string shortName, decimal value, DateTime dataTime)
        {
            Name = name;
            ShortName = shortName;
            Value = value;
            DataTime = dataTime;
        }

    }
}
