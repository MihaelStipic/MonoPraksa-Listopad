using System;
using System.Collections;

namespace MoneyMaker
{
    public class Proj
    {

        public interface Opcenito
        {
           
            public string Name { get; set; }

            public string Address { get; set; }
            public string OIB { get; set; }
            public int godina_faksa { get; set; }

            public void Dug_referadi_za_upis();
        }

        public class Student : Opcenito
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string OIB { get; set; }

            public int godina_faksa { get; set; }

            public Student(string name, string address, string OIb, int godina)
            {
                Name = name;
                Address = address;
                OIB = OIb;
                godina_faksa = godina;

            }

            

            public virtual void Dug_referadi_za_upis() {

                Console.WriteLine("Dug je 34.00 EUR");
            }

        }

        public class Student_Popravni : Student
        {
            public Student_Popravni(string inname, string ina, string inoib, int godina) : base(inname, ina, inoib, godina) { }
            public override void Dug_referadi_za_upis()
            {
                Console.WriteLine("Dug je 62.50 EUR");
            }
        }





        static void Main(string[] args)
        {

            Console.WriteLine("Odaberite jedno od ponuđenih polja: ");
            Console.WriteLine("1. Kreiraj Studenta");
            Console.WriteLine("2. Kreiraj ponavljajućeg studenta");


            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Unesite ime studenta: ");
                string ime = Console.ReadLine();
                Console.WriteLine("Unesite adresu studenta: ");
                string adresa = Console.ReadLine();
                Console.WriteLine("Unesite OIB studenta: ");
                string OIB = Console.ReadLine();
                Console.WriteLine("Unesite godinu faksa studenta: ");
                string godina = Console.ReadLine();
                if (int.TryParse(godina, out int god))
                {

                    Student noviStudent = new Student(ime, adresa, OIB, god);

                    Console.WriteLine("Kreiran je novi student!");
                    noviStudent.Dug_referadi_za_upis();
                   

                }
                else
                {
                    Console.WriteLine("Pogrešan unos godine! Molimo unesite broj.");
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Unesite ime studenta: ");
                string ime = Console.ReadLine();
                Console.WriteLine("Unesite adresu studenta: ");
                string adresa = Console.ReadLine();
                Console.WriteLine("Unesite OIB studenta: ");
                string OIB = Console.ReadLine();
                Console.WriteLine("Unesite godinu faksa studenta: ");
                string godina = Console.ReadLine();
                if (int.TryParse(godina, out int god))
                {

                    Student_Popravni noviStudent = new Student_Popravni(ime, adresa, OIB, god);

                    Console.WriteLine("Kreiran je novi student!");
                    noviStudent.Dug_referadi_za_upis();
                }
                else
                {
                    Console.WriteLine("Pogrešan unos godine! Molimo unesite broj.");
                }
            }




        }
    }
}