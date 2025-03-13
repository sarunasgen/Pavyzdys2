//using Autoparkas.Contracts;
//using Autoparkas.Models;
//using Autoparkas.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Autoparkas.Services
//{
//    public class AutoParkasServiceSarasai : IAutoNuoma
//    {
//        private readonly FailuRepozitorija _duomenys;

//        private List<Automobilis> Automobiliai;
//        private List<Klientas> Klientai;

//        public AutoParkasServiceSarasai(FailuRepozitorija duomenuRepo)
//        {
//            Automobiliai = new List<Automobilis>();
//            Klientai = new List<Klientas>();
//            _duomenys = duomenuRepo;

//            Automobiliai = _duomenys.NuskaitytiAutomobiliusISarasa();
//            Klientai = _duomenys.NuskaitytiKlientus().ToList<Klientas>();
//        }

//        public Automobilis GautiAutomobiliPagalMakreModeli(string marke, string modelis)
//        {
//            return Automobiliai.Where(x => x.Marke == marke && x.Modelis == modelis).FirstOrDefault();
//        }

//        public Automobilis[] GautiAutomobiliusPagalMarke(string marke)
//        {
//            return Automobiliai.Where(x => x.Marke == marke).ToArray();
//        }

//        public Klientas GautiKlientaPagalAsmensKoda(long ak)
//        {
//            Klientas rastasKlientas = null;
//            foreach(Klientas k in Klientai)
//            {
//                if (k.AsmensKodas == ak)
//                {
//                    rastasKlientas = k;
//                    break;
//                }
//            }
//            return rastasKlientas;
//        }

//        public Klientas[] GautiKlientusSuAktyviomisNuomomis()
//        {
//            return Klientai.Where(x => x.NuomuojamasAuto != null).ToArray();
//        }

//        public Automobilis[] GautiVisusAutomobilius()
//        {
//            return Automobiliai.ToArray();
//        }

//        public Klientas[] GautiVisusKlientus()
//        {
//            return Klientai.ToArray();
//        }

//        public void IsnuomuotiAutomobili(Automobilis automobilis, Klientas nuomininkas)
//        {
//            //Priskiriu automobili klientui
//            nuomininkas.NuomuojamasAuto = automobilis;

//            //Pasalinu automobili is preinamu automobiliu saraso
//            Automobiliai.Remove(automobilis);
//        }

//        public void PridetiAutomobili(Automobilis automobilis)
//        {
//            Automobiliai.Add(automobilis);
//            _duomenys.IssaugotiAutomobilius(Automobiliai.ToArray());
//        }

//        public void PridetiKlienta(Klientas naujasKlientas)
//        {
//            Klientai.Add(naujasKlientas);
//        }
//    }
//}
