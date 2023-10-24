using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    internal class Vegeredmeny
    {


        int helyezes;
        string nev;
        string orszagkod;
        double osszpontszam;

        public int Helyezes { get => helyezes; set => helyezes = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Orszagkod { get => orszagkod; set => orszagkod = value; }
        public double Osszpontszam { get => osszpontszam; set => osszpontszam = value; }

        public Vegeredmeny(int helyezes, string nev, string orszagkod, double osszpontszam)
        {
            this.helyezes = helyezes;
            this.nev = nev;
            this.orszagkod = orszagkod;
            this.osszpontszam = osszpontszam;
        }
    }
}
