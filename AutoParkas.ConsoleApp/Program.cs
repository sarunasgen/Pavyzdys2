using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using AutoParkas.Core.Services;
using System;

namespace AutoParkas.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {        
            IAutoNuoma manoAutoparkas = new AutoParkasService();

            while (true)
            {
                Console.WriteLine("1. Prideti Automobili");
                Console.WriteLine("2. Rodyti Visus Automobilius");
                Console.WriteLine("3. Rasti Automobili Pagal Marke");
                Console.WriteLine("4. Prideti Klienta");
                Console.WriteLine("5. Rodyti visus Klientus");
                Console.WriteLine("6. Isnuomuoti Automobili");
                Console.WriteLine("7. Rodyti Klientus su ju nuomojamu automobiliu");
                Console.WriteLine("0. Baigti Darba");
                if (int.TryParse(Console.ReadLine(), out int pasirinkimas))
                {
                    switch (pasirinkimas)
                    {
                        case 1:
                            Console.WriteLine("Iveskite marke:");
                            string marke = Console.ReadLine();

                            Console.WriteLine("Iveskite modeli:");
                            string modelis = Console.ReadLine();

                            Console.WriteLine("Iveskite pirmosios registracijos data:");
                            DateOnly pirmRegData = DateOnly.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite paros kaina:");
                            decimal parosKaina = decimal.Parse(Console.ReadLine());

                            Automobilis naujasAuto = new Automobilis
                            {
                                Marke = marke,
                                Modelis = modelis,
                                PirmosRegData = pirmRegData,
                                ParosKaina = parosKaina
                            };

                            manoAutoparkas.PridetiAutomobili(naujasAuto);
                            break;
                        case 2:
                            Automobilis[] visiAuto = manoAutoparkas.GautiVisusAutomobilius();
                            foreach (Automobilis a in visiAuto)
                            {
                                Console.WriteLine($"{a.Marke} {a.Modelis} {a.PirmosRegData} {a.ParosKaina}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Iveskite marke:");
                            string ieskomaMarke = Console.ReadLine();

                            Automobilis[] rastiAuto = manoAutoparkas.GautiAutomobiliusPagalMarke(ieskomaMarke);
                            foreach (Automobilis a in rastiAuto)
                            {
                                Console.WriteLine($"{a.Marke} {a.Modelis} {a.PirmosRegData} {a.ParosKaina}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Iveskite Asmens Koda:");
                            long ak = long.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite varda ir pavarde:");
                            string vardasPavarde = Console.ReadLine();

                            manoAutoparkas.PridetiKlienta(new Klientas { AsmensKodas = ak, VardasPavarde = vardasPavarde });
                            break;
                        case 5:
                            foreach (Klientas k in manoAutoparkas.GautiVisusKlientus())
                            {
                                Console.WriteLine($"{k.AsmensKodas} {k.VardasPavarde}");
                            }
                            break;
                        case 6:
                            foreach (Klientas k in manoAutoparkas.GautiVisusKlientus())
                            {
                                Console.WriteLine($"{k.AsmensKodas} {k.VardasPavarde}");
                            }
                            Console.WriteLine("Iveskite kliento asmens koda: ");
                            Klientas pasirinktasKlientas = manoAutoparkas.GautiKlientaPagalAsmensKoda(long.Parse(Console.ReadLine()));
                            if (pasirinktasKlientas == null)
                            {
                                Console.WriteLine("Neteisingas kliento asmens kodas");
                                break;
                            }
                            if (pasirinktasKlientas.NuomuojamasAuto != null)
                            {
                                Console.WriteLine("KLIENTAS JAU TURI AKTYVIA NUOMA!!!");
                                break;
                            }
                            Automobilis[] prieinamiAuto = manoAutoparkas.GautiVisusAutomobilius();
                            for (int i = 0; i < prieinamiAuto.Length; i++)
                            {
                                Console.WriteLine($"#{i + 1} {prieinamiAuto[i].Marke} {prieinamiAuto[i].Modelis} {prieinamiAuto[i].PirmosRegData} {prieinamiAuto[i].ParosKaina}");
                            }
                            Console.WriteLine("Pasirinkite automobili pagal eiles numeri is saraso: ");
                            int pasirinktasAutoIndex = int.Parse(Console.ReadLine()) - 1;
                            Automobilis pasirinktasAutomobilisNuomai = prieinamiAuto[pasirinktasAutoIndex];

                            manoAutoparkas.IsnuomuotiAutomobili(pasirinktasAutomobilisNuomai, pasirinktasKlientas);

                            break;
                        case 7:
                            foreach (Klientas k in manoAutoparkas.GautiKlientusSuAktyviomisNuomomis())
                            {
                                Console.WriteLine($"{k.AsmensKodas} {k.VardasPavarde} {k.NuomuojamasAuto.Marke} {k.NuomuojamasAuto.Modelis} {k.NuomuojamasAuto.PirmosRegData}");
                            }
                            break;
                        case 0:
                            return;
                            break;
                    }
                }
            }
        }
    }
}