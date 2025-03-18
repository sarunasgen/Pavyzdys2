using AutoParkas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Contracts
{
    public interface IAutoNuoma
    {
        void PridetiAutomobili(Automobilis automobilis);
        Automobilis[] GautiVisusAutomobilius();
        Automobilis[] GautiAutomobiliusPagalMarke(string marke);
        Automobilis GautiAutomobiliPagalMakreModeli(string marke, string modelis);
        void IsnuomuotiAutomobili(Automobilis automobilis, Klientas nuomininkas);
        void PridetiKlienta(Klientas naujasKlientas);
        Klientas[] GautiVisusKlientus();
        Klientas GautiKlientaPagalAsmensKoda(long ak);
        Klientas[] GautiKlientusSuAktyviomisNuomomis();
        List<Klientas> GautiKlientusPagalVardaPavarde(string vardasPavarde);
        Klientas GautiKlientaPagalId(int id);
        bool IstrintiKlientaPagalId(int id);
    }
}
