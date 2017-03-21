using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harkkatyo
{
    class Opettaja
    {
        private double palkka = 2000;



        public string Nimi;

        public double Palkka
        {
            get { return palkka; }
            set { palkka = value;  }
        }


        public Opettaja()
        {

        }

        public Opettaja(string nimi, double palkka)
        {
            Nimi = nimi;
            Palkka = palkka;
        }

        public double PalkanLasku(double numero)
        {
            return numero+100;
        }





    }
}
