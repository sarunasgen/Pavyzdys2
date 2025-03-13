using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Models
{
    public class Klientas
    {
        [Key]
        public int KlientoId { get; set; }
        public long AsmensKodas { get; set; }
        public string VardasPavarde { get; set; }
        public Automobilis? NuomuojamasAuto { get; set; }

    }
}
