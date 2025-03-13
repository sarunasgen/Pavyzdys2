using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Models
{
    public class Automobilis
    {
        [Key]
        public int AutomobilioId { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public DateOnly PirmosRegData { get; set; }
        public decimal ParosKaina { get; set; }
        
    }
}
