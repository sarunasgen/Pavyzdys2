using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using AutoParkas.Core.Utils;
using Microsoft.Identity.Client;
using Serilog;
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
        private AppDatabaseContext _dbContext;
        public AutoParkasService(AppDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
            Automobiliai = _dbContext.Automobiliai.ToArray<Automobilis>();
            Klientai = _dbContext.Klientai.ToArray<Klientas>();

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
            _dbContext.Automobiliai.Add(automobilis);
            _dbContext.SaveChanges();

        }
        public Automobilis[] GautiVisusAutomobilius()
        {
            return _dbContext.Automobiliai.ToArray();
        }
        public Automobilis[] GautiAutomobiliusPagalMarke(string marke)
        {
            return _dbContext.Automobiliai.Where(x => x.Marke == marke).ToArray();
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
            _dbContext.Klientai.Add(naujasKlientas);
            _dbContext.SaveChanges();
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
        public Klientas GautiKlientaPagalId(int id)
        {
            //Su ciklu
            foreach(Klientas k in _dbContext.Klientai)
            {
                if (k.KlientoId == id)
                    return k;
            }

            //Su lambda expression
            return _dbContext.Klientai.Where(x => x.KlientoId == id).FirstOrDefault();
        }
        public List<Klientas> GautiKlientusPagalVardaPavarde(string vardasPavarde)
        {
            //Su ciklu
            List<Klientas> rastiKlientai = new List<Klientas>();
            foreach (Klientas k in _dbContext.Klientai)
            {
                if (k.VardasPavarde == vardasPavarde)
                    rastiKlientai.Add(k);
            }
            return rastiKlientai;

            //Su Lamba expression
            return _dbContext.Klientai.Where(x => x.VardasPavarde == vardasPavarde).ToList();
        }

        public bool IstrintiKlientaPagalId(int id)
        {
            Klientas klientasIstrinti = GautiKlientaPagalId(id);
            if (klientasIstrinti == null)
                return false;

            _dbContext.Klientai.Remove(klientasIstrinti);
            _dbContext.SaveChanges();
            return true;
        }
        
    }
}
