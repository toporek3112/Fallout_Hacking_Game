using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswortRaten
{
    class Wort
    {
        public string Name { get; set; }
        public int Lenght { get; set; }
        public int temp { get; set; }

        public Wort(string n)
        {
            Name = n;
            foreach (char a in Name)
            {
                Lenght++;
            }
        }


        public string Ausgabe(Wort wort)
        {
            string a = wort.Name;
            Random r = new Random();

            while (wort.Lenght != 15)
            {
                a += Convert.ToChar(r.Next(33, 63));
                wort.Lenght++;
            }

            return a;
        }

        public string[] LikenessAusgabe(string Eingabe, int likeness)
        {
            string[] a = new string[3];

            a[0] = $" {Eingabe}";
            a[1] = "  Entry denied.";
            a[2] = $"  Likeness= {likeness}";

            return a;
        }
    }
}
