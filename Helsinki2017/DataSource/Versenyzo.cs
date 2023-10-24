using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017.DataSource
{
    internal class Versenyzo
    {
        string nev;
        string orszagkod;
        double technikaiPont;
        double komponensPont;
        int hibapont;

        public Versenyzo(string nev, string orszagkod, double technikaiPont, double komponensPont, int hibapont)
        {
            this.nev = nev;
            this.orszagkod = orszagkod;
            this.technikaiPont = technikaiPont;
            this.komponensPont = komponensPont;
            this.hibapont = hibapont;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Orszagkod { get => orszagkod; set => orszagkod = value; }
        public double TechnikaiPont { get => technikaiPont; set => technikaiPont = value; }
        public double KomponensPont { get => komponensPont; set => komponensPont = value; }
        public int Hibapont { get => hibapont; set => hibapont = value; }
    }


}
