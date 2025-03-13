using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using AutoParkas.Core.Services;

namespace AutoParkas.Tests
{
    public class AutoNuomaTests
    {
        [Fact]
        public void PridetiAutomobili_Test()
        {
            //Arrange
            IAutoNuoma manoAutoparkas = new AutoParkasService();
            Automobilis automobilis1 = new Automobilis
            {
                Marke = "BMW",
                Modelis = "745Li",
                PirmosRegData = DateOnly.Parse("2000-01-01"),
                ParosKaina = 39.99M
            };
            Automobilis automobilis2 = new Automobilis
            {
                Marke = "Audi",
                Modelis = "S8",
                PirmosRegData = DateOnly.Parse("1996-01-01"),
                ParosKaina = 49.99M
            };
            //Act
            manoAutoparkas.PridetiAutomobili(automobilis1);
            manoAutoparkas.PridetiAutomobili(automobilis2);
            //Assert
            var visiAuto = manoAutoparkas.GautiVisusAutomobilius().ToList();

            Assert.Contains<Automobilis>(automobilis1, visiAuto);
            Assert.Contains<Automobilis>(automobilis2, visiAuto);
        }
        [Fact]
        public void IsnuomuotiAutomobili_Test()
        {
            //Arrange
            IAutoNuoma manoAutoparkas = new AutoParkasService();
            Automobilis automobilis1 = new Automobilis
            {
                Marke = "BMW",
                Modelis = "745Li",
                PirmosRegData = DateOnly.Parse("2000-01-01"),
                ParosKaina = 39.99M
            };
            Automobilis automobilis2 = new Automobilis
            {
                Marke = "Audi",
                Modelis = "S8",
                PirmosRegData = DateOnly.Parse("1996-01-01"),
                ParosKaina = 49.99M
            };
            Klientas klientas1 = new Klientas
            {
                AsmensKodas = 39823432422,
                NuomuojamasAuto = null,
                VardasPavarde = "Test Test"
            };

            //Act
            manoAutoparkas.PridetiAutomobili(automobilis1);
            manoAutoparkas.PridetiAutomobili(automobilis2);
            manoAutoparkas.PridetiKlienta(klientas1);
            manoAutoparkas.IsnuomuotiAutomobili(automobilis1, klientas1);

            //Assert
            var klientaiSuAktyviomisNuomomis = manoAutoparkas.GautiKlientusSuAktyviomisNuomomis().ToList();
            Assert.NotNull(klientaiSuAktyviomisNuomomis);
            Assert.Equal(1, klientaiSuAktyviomisNuomomis.Count);
            Assert.DoesNotContain<Automobilis>(automobilis1, manoAutoparkas.GautiVisusAutomobilius());

        }
    }
}