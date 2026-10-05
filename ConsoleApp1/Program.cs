using System;
using System.Collections;

namespace MoneyMaker
{
    public class Proj
    {

        interface Opcenito
        {
           
            public string Name { get; set; }

            public string Address { get; set; }
            public string OIb { get; set; }

            public void Izreci();
        }

        public class Student : Opcenito
        {
            public string name;
            public string address;
            public int OIB;

            public Student(string Name, string Address, int OIb)
            {
                name = Name;
                address = Address;
                OIB = OIb;

            }

            public string Name { get; set; }
            public string Address { get; set; }
            public string OIb { get; set; }

            public virtual void Izreci() {

                Console.WriteLine("Dobrodošli!");
                Console.WriteLine("OIB: " + OIB);
            }

        }

        public class Student_Popravni : Student
        {
            public Student_Popravni(string inname, string ina, int inoib) : base(inname, ina, inoib) { }
            public override void Izreci()
            {
                base.Izreci();
                Console.WriteLine("Ali za popravnog");
            }
        }





        static void Main(string[] args)
        {

            Student Marko = new Student("Marko", "Osijek 1", 1235423);
            Marko.Izreci();
            Marko.Address = "Strizivojna";

            Student_Popravni Ivan = new Student_Popravni("Ivan", "Osijek", 23412123);
            Ivan.Izreci();


            
        }
    }
}