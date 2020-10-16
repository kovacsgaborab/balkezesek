using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class balkezesek
    {
        public string Nev { get; private set; }
        public string Elso { get; private set; }
        public string Utolso { get; private set; }
        public int Suly { get; private set; }
        public int Magassag { get; private set; }

        public balkezesek(string sor)
        {
            string[] a = sor.Split(';');

            Nev = a[0];
            Elso = a[1];
            Utolso = a[2];
            Suly = Convert.ToInt32(a[3]);
            Magassag = Convert.ToInt32(a[4]);
        }
    }
}
