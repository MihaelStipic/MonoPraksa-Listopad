using System;
using System.Linq
using System.Collections.Generic;

namespace MoneyMaker
{
    public class Proj
    {

        public interface IVozilo
        {
            public string Registracija { get; set; }
            public string Vlasnik { get; set; }
            public void Istek_Reg();
            void PrikaziKm();
        }
        

        public class Automobil : IVozilo{

            private int predeni_kilometri;
            protected DateTime Pocetak_registracije;
            public string Registracija { get; set; }
            public string Vlasnik { get; set; }

            public Automobil(DateTime pocetak, string registracija, string vlasnik, int km)
            {
                Pocetak_registracije = pocetak;
                Registracija = registracija;
                Vlasnik = vlasnik;
                predeni_kilometri = km;
            }
            public virtual void Istek_Reg()
            {
                int godina = Pocetak_registracije.Year+4;
                int mjesec = Pocetak_registracije.Month;
                int dan = Pocetak_registracije.Day;

                Console.WriteLine("Registracija za vozilo " + Registracija + " istjece " + dan + "." + mjesec + "." + godina);
            }

            public void DodajKilometre(int km)
            {
                if (km > 0)
                {
                    predeni_kilometri += km;
                }
                else
                {
                    Console.WriteLine("Unos nije valjan!");
                }
            }

            public void PrikaziKm()
            {
                Console.WriteLine("Vozilo "+ Registracija +" je prešlo: "+predeni_kilometri + " km");
            }

        }

        public class Skuter : Automobil
        {
            public Skuter(DateTime pocetak, string registracija, string vlasnik, int km) : base(pocetak, registracija, vlasnik,km) { }
            public override void Istek_Reg()
            {
                int godina = Pocetak_registracije.Year +10;
                int mjesec = Pocetak_registracije.Month;
                int dan = Pocetak_registracije.Day;

                Console.WriteLine("Registracija za vozilo " + Registracija+ " istjece " + dan + "." + mjesec + "." + godina);
            }

        }





        static void Main(string[] args)
        {
            List<IVozilo> vozila = new List<IVozilo>();
            while (true)
            {

                Console.WriteLine("1. Unesi Automobil u sustav");
                Console.WriteLine("2. Unesi Skuter u sustav");
                Console.WriteLine("3. Pronadi vozilo");
                string broj = Console.ReadLine();
                if (broj == "1")
                {
                    Console.WriteLine("Unesi godinu registracije");
                    string godina1 = Console.ReadLine();
                    int godina = int.Parse(godina1);
                    Console.WriteLine("Unesi mjesec registracije");
                    string mjesec1 = Console.ReadLine();
                    int mjesec = int.Parse(mjesec1);
                    Console.WriteLine("Unesi dan registracije");
                    string dan1 = Console.ReadLine();
                    int dan = int.Parse(dan1);

                    DateTime datumreg = new DateTime(godina, mjesec, dan);

                    Console.WriteLine("Unesi registraciju: ");
                    string reg = Console.ReadLine();

                    Console.WriteLine("Unesi ime vlasnika: ");
                    string vlasnik = Console.ReadLine();

                    Console.WriteLine("Unesi predjene km: ");
                    int km = int.Parse(Console.ReadLine());

                    Automobil auto = new Automobil(datumreg, reg, vlasnik, km);
                    Console.WriteLine("Vozilo je uneseno u sustav.");
                    vozila.Add(auto);


                }
                else if (broj == "2")
                {
                    Console.WriteLine("Unesi godinu registracije");
                    string godina1 = Console.ReadLine();
                    int godina = int.Parse(godina1);
                    Console.WriteLine("Unesi mjesec registracije");
                    string mjesec1 = Console.ReadLine();
                    int mjesec = int.Parse(mjesec1);
                    Console.WriteLine("Unesi dan registracije");
                    string dan1 = Console.ReadLine();
                    int dan = int.Parse(dan1);

                    DateTime datumreg = new DateTime(godina, mjesec, dan);

                    Console.WriteLine("Unesi registraciju: ");
                    string reg = Console.ReadLine();

                    Console.WriteLine("Unesi ime vlasnika: ");
                    string vlasnik = Console.ReadLine();

                    Console.WriteLine("Unesi predjene km: ");
                    int km = int.Parse(Console.ReadLine());

                    Skuter skuter = new Skuter(datumreg, reg, vlasnik, km);
                    Console.WriteLine("Vozilo je uneseno u sustav.");

                    vozila.Add(skuter);
                } else if (broj =="3"){
                    Console.WriteLine("Unesite registraciju");
                    string reg = Console.ReadLine();
                    IVozilo vozilo = vozila.FirstOrDefault(x => x.Registracija == reg);
                    if(vozilo != null)
                    {
                        Console.WriteLine("Vlasnik je " + vozilo.Vlasnik);
                    }
                    
                    



                }
                else
                {
                    Console.WriteLine("Nevaljan unos!");
                }
            }
            








        }
    }
}