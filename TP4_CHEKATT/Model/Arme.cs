using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT
{
    public class Arme
    {
        public string Nom { get; private set; }

        public int DegatMinimum { get; private set; }

        public int DegatMaximum { get; private set; }

        public double DegatsMoyen => (DegatMinimum + DegatMaximum) / 2;

        public double TempsRechargement { get; set; } // En nombre de tour

        public double TempsAvantRecharge { get; set; }

        public bool EstRecharger => TempsAvantRecharge <= 0;

        public ArmeType ArmeType { get; private set; }

        internal Arme() { }

        public Arme(string nom, int degatMin, int degatMax, ArmeType armeType, double tpsRecharge) // Avec temps de recharge 
        {
            Nom = nom;
            DegatMinimum = degatMin;
            DegatMaximum = degatMax;
            ArmeType = armeType;
            TempsRechargement = tpsRecharge;
        }
        internal Arme(Arme arme)
        {
            Nom = arme.Nom;
            ArmeType = arme.ArmeType;
            DegatMinimum = arme.DegatMinimum;
            DegatMaximum = arme.DegatMaximum;
            TempsRechargement = arme.TempsRechargement;
            TempsAvantRecharge = arme.TempsAvantRecharge;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Nom: {Nom}\n\t");
            sb.Append($"Dégats Minimum: {DegatMinimum}\n\t");
            sb.Append($"Dégats Maximum: {DegatMaximum}\n\t");
            sb.Append($"Arme Type: {ArmeType}\n");

            return sb.ToString();
        }

        public double Tirer()
        {
            if (!EstRecharger) return 0;
            double degat = 0;
            Random r = new Random();
            switch (ArmeType)
            {
                case ArmeType.Direct:
                    degat = AvoirUnTir(10) ? GetDamage() : 0;
                    break;
                case ArmeType.Explosif:
                    degat = AvoirUnTir(4) ? GetDamage() : 0;
                    TempsAvantRecharge = TempsRechargement * 2;
                    break;
                case ArmeType.Guide:
                    degat = EstRecharger ? DegatMinimum : 0;
                    break;
                default:
                    degat = 0;
                    break;
            }
            if (TempsAvantRecharge <= 0) TempsAvantRecharge = TempsRechargement;
            return degat;
        }

        private bool AvoirUnTir(int uneChanceDe)
        {
            Random r = new Random();
            return r.Next(1, uneChanceDe) != r.Next(1, uneChanceDe);
        }

        private double GetDamage()
        {
            return EstRecharger ? Math.Round(DegatMinimum + (new Random().NextDouble() * (DegatMaximum - DegatMinimum)), 2) : 0;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Arme);
        }
        public bool Equals(Arme autre)
        {
            return autre != null;
        }
    }
}
