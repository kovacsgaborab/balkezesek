using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Program
    {
        static List<balkezesek> balosak = new List<balkezesek>();

        static void Beolvas()
        {
            StreamReader sr = new StreamReader("balkezesek.csv");

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                balosak.Add(new balkezesek(sr.ReadLine()));
            }

            sr.Close();

        }

        static void Main(string[] args)
        {
            Beolvas();

            foreach (var b in balosak)
            {
                Console.WriteLine($"{b.Nev, 20}  {b.Elso}  {b.Utolso}  {b.Suly}  {b.Magassag}");
            }

            Console.ReadLine();
        }
    }
}
