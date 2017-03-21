using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace harkkatyo
{
    class Opettaja
    {
        private double palkka;
        private double rahat = 0;



        public string Nimi;

        public double Palkka
        {
            get { return palkka; }
            set { palkka = value;  }
        }
        public double Rahat
        {
            get { return rahat; }
            set { rahat = value; }
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
            Rahat += numero;
            return Palkka;
        }
        
        

    }
}
