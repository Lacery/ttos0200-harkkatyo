using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace harkkatyo
{
    class Opettaja
    {
        private double palkka;
        private double rahat = 0;
        private int klikit;



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
        public int Klikit
        {
            get { return klikit; }
            set { klikit = value; }
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
