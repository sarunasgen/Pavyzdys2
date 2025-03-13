using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Services
{
    public class AutoParkasService : IAutoNuoma
    {
        private Automobilis[] Automobiliai;
        private Klientas[] Klientai;

        public AutoParkasService()
        {
            Automobiliai = new Automobilis[0];
            Klientai = new Klientas[0];

        }
        public void PridetiAutomobili(Automobilis automobilis)
        {
            Automobilis[] naujasMasyvas = new Automobilis[Automobiliai.Length + 1];
            int index = 0;
            foreach (Automobilis a in Automobiliai)
            {
                naujasMasyvas[index] = a;
                index++;
            }
            naujasMasyvas[index] = automobilis;
            Automobiliai = naujasMasyvas;


        }
        public Automobilis[] GautiVisusAutomobilius()
        {
            return Automobiliai;
        }
        public Automobilis[] GautiAutomobiliusPagalMarke(string marke)
        {
            Automobilis[] automobiliai;

            int kiekis = 0;
            foreach (Automobilis a in Automobiliai)
            {
                if (a.Marke == marke)
                    kiekis++;
            }
            automobiliai = new Automobilis[kiekis];
            int index = 0;
            foreach (Automobilis a in Automobiliai)
            {
                if (a.Marke == marke)
                {
                    automobiliai[index] = a;
                    index++;
                }
            }

            return automobiliai;
        }
        public Automobilis GautiAutomobiliPagalMakreModeli(string marke, string modelis)
        {
            foreach (Automobilis a in Automobiliai)
            {
                if (a.Marke == marke && a.Modelis == modelis)
                {
                    return a;
                }
            }

            return null;
        }

        public void IsnuomuotiAutomobili(Automobilis automobilis, Klientas nuomininkas)
        {
            //Priskiriu automobili klientui
            nuomininkas.NuomuojamasAuto = automobilis;

            //Pasalinu automobili is preinamu automobiliu saraso
            PasalintiAutomobiliIsSaraso(automobilis);
        }

        private void PasalintiAutomobiliIsSaraso(Automobilis automobilis)
        {
            //Sukuriam vienu elementu trumpesni masyva
            Automobilis[] atnaujintasAutomobiliai = new Automobilis[Automobiliai.Length - 1];
            int index = 0;
            //perkopijuojame visus elementus isskyrus elementa, kuri norime pasalinti
            for (int i = 0; i < Automobiliai.Length; i++)
            {
                if (Automobiliai[i] != automobilis)
                {
                    atnaujintasAutomobiliai[index] = Automobiliai[i];
                    index++;
                }
            }
            //Nauja masyva, priskiriame klases AutoParkas savybei - Automobiliu sarasui
            Automobiliai = atnaujintasAutomobiliai;
        }

        public void PridetiKlienta(Klientas naujasKlientas)
        {
            Klientas[] naujasMasyvas = new Klientas[Klientai.Length + 1];
            int index = 0;
            foreach (Klientas a in Klientai)
            {
                naujasMasyvas[index] = a;
                index++;
            }
            naujasMasyvas[index] = naujasKlientas;
            Klientai = naujasMasyvas;

        }
        public Klientas[] GautiVisusKlientus()
        {
            return Klientai;
        }
        public Klientas GautiKlientaPagalAsmensKoda(long ak)
        {
            foreach (Klientas k in Klientai)
            {
                if (k.AsmensKodas == ak)
                    return k;
            }
            return null;
        }
        public Klientas[] GautiKlientusSuAktyviomisNuomomis()
        {
            int kiekis = 0;
            foreach (Klientas k in Klientai)
            {
                if (k.NuomuojamasAuto != null)
                    kiekis++;
            }
            Klientas[] klientaiSuAktyviaNuoma = new Klientas[kiekis];
            int index = 0;
            foreach (Klientas k in Klientai)
            {
                if (k.NuomuojamasAuto != null)
                {
                    klientaiSuAktyviaNuoma[index] = k;
                    index++;
                }

            }
            return klientaiSuAktyviaNuoma;
        }
    }
}
