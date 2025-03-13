using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Models
{
    public class Klientas
    {
        public long AsmensKodas { get; set; }
        public string VardasPavarde { get; set; }
        public Automobilis? NuomuojamasAuto { get; set; }

    }
}
