using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harkkatyo
{
    class Achievements
    {


        List<string> lista = new List<string>(); //Lista achievementtien ylläpitoon



        public string PrintAchievements() //Palauttaa string:in rivinvaihdolla listaten achievementit
        {
            string saavutukset = string.Join("\n", lista.ToArray());
            return saavutukset;
        }

        public bool is100(double money) //Tarkistaa onko 100 goldia tienattu
        {
            if (money >= 100 && (lista.Contains("Gain 100 gold") == false))
            {
                lista.Add("Gain 100 gold");
                return true;
            }
            return false;

        }

        public bool is500(double money) //Tarkistaa onko 500 goldia tienattu
        {
            if (money >= 500 && (lista.Contains("Gain 500 gold") == false))
            {
                lista.Add("Gain 500 gold");
                return true;
            }
            return false;

        }

        public bool is1000(double money) //Tarkistaa onko 1000 goldia tienattu
        {
            if (money >= 1000 && (lista.Contains("Gain 1000 gold") == false))
            {
                lista.Add("Gain 1000 gold");
                return true;
            }
            return false;

        }

        public bool isAriKlikit(double klikit) //Tarkistaa onko Ari klikannut 20 kertaa
        {
            if (klikit == 20 && (lista.Contains("Ari did 20 loops") == false))
            {
                lista.Add("Ari did 20 loops");
                return true;
            }
            return false;
        }

        public bool isNarsuKlikit(double klikit) //Tarkistaa onko Narsu klikannut 20 kertaa
        {
            if (klikit == 20 && (lista.Contains("Narsu did 20 loops") == false))
            {
                lista.Add("Narsu did 20 loops");
                return true;
            }
            return false;
        }
        public bool isJarmoKlikit(double klikit) //Tarkistaa onko Jarmo klikannut 20 kertaa
        {
            if (klikit == 20 && (lista.Contains("Jarmo did 20 loops") == false))
            {
                lista.Add("Jarmo did 20 loops");
                return true;
            }
            return false;
        }
        public bool isMieskolainenKlikit(double klikit) //Tarkistaa onko Matti klikannut 20 kertaa
        {
            if (klikit == 20 && (lista.Contains("Matti did 20 loops") == false))
            {
                lista.Add("Matti did 20 loops");
                return true;
            }
            return false;
        }







    }
}
