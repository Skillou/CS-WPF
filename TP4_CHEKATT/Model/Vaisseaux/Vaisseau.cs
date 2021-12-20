using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TP4_CHEKATT.Vaisseaux
{
    internal abstract class Vaisseau
    {
        public string Nom { get; set; }
        public double PointStructureMaximum { get; }

        public double PointBouclierMaximum { get; set; }

        public double PointStructureCourante { get; set; }

        public double PointBouclierCourant { get; set; }

        public bool EstDetruit => PointBouclierCourant + PointStructureCourante <= 0;

        public List<Arme> ArmesVaisseau = new List<Arme>(3);

        public ImageSource Image { get; set; }

        //public double DegatsMoyen => (ArmesVaisseau.Sum(x => x.DegatMinimum) + ArmesVaisseau.Sum(x => x.DegatMaximum)) / 2; // essayer de comprendre

        public bool AppartientJoueur { get; private set; }

        public Vaisseau(string nom, int maxPtStructure, int maxPtBouclier, bool appartientJoueur)
        {
            Nom = nom;
            PointStructureMaximum = maxPtStructure;
            PointBouclierMaximum = maxPtBouclier;
            AppartientJoueur = appartientJoueur;
        }

        public void DegatSubit(double degats)
        {
            Console.WriteLine(Nom + " encaisse " + degats + " de dommages");
            if (PointBouclierCourant >= degats)
            {
                PointBouclierCourant -= degats;
            }
            else
            {
                PointStructureCourante -= (degats - PointBouclierCourant);
                PointBouclierCourant = 0;
            }

            Console.WriteLine("Boucliers restants : " + PointBouclierCourant);
            Console.WriteLine("Structure restante : " + PointStructureCourante);

            if (EstDetruit)
            {
                Console.WriteLine(Nom + " est détruit !");
            }
        }

        public void ReparerBouclier(double repair)
        {
            PointBouclierCourant += repair;
            if (PointBouclierCourant > PointBouclierMaximum) { PointBouclierCourant = PointBouclierMaximum; }
        }

        public void Attaquer(Vaisseau cible)
        {
            //on cherche toutes les armes qui sont rechargées
            List<Arme> temp = ArmesVaisseau.Where(x => x.EstRecharger).ToList();
            if (temp.Count == 0)
            {
                Console.WriteLine("Le " + Nom + " n'a pas d'armes rechargées");
                return;
            }
            //on cherche l'arme rechargée avec le plus de dommage moyen
            Arme w = temp.Where(x => x.DegatsMoyen == temp.Max(y => y.DegatsMoyen)).FirstOrDefault();
            //on l'utilise
            Console.WriteLine(Nom + " tire sur " + cible.Nom + " avec l'arme " + w.ToString());
            cible.DegatSubit(w.Tirer());
        }
        public void AjouterArme(Arme arme)
        {
            // test si l'arme provien bien de l'armurerie mais c'est quasiment impossible avec les visibilités utilisées
            if (Armurerie.EstArmeArmurerie(arme))
            {
                // évite de dépasser le nombre maximum d'arme sur le vaisseau
                if (ArmesVaisseau.Count < 3)
                {
                    ArmesVaisseau.Add(arme);
                }
                else
                {
                    throw new Exception("Maximum d'arme atteinte sur le vaisseau");
                }
            }
            else
            {
                Console.WriteLine("L'arme que vous voulez ajouter n'est pas dans l'armurerie");
            }
        }

        public void RetirerArme(string arme)
        {
            for (int i = 0; i < ArmesVaisseau.Count; i++)
            {
                if (ArmesVaisseau[i].Nom.Equals(arme, StringComparison.OrdinalIgnoreCase)) // Regarde si l'arme du vaisseau est egal à l'arme en fonction du nom de l'arme (s'en fiche des majuscules minuscules)
                {
                    ArmesVaisseau.RemoveAt(i);
                }
            }
        }

        //internal void RetirerArme(Arme arme)
        //{
        //    if (ArmesVaisseau.Count > 0)
        //    {
        //        ArmesVaisseau.Remove(arme);
        //    }
        //}

        internal void RetirerArme(Arme arme)
        {
            if (ArmesVaisseau.Contains(arme))
            {
                ArmesVaisseau.Remove(arme);
            }
        }

        public void ClearArmes()
        {
            ArmesVaisseau.Clear(); // Supprime toute les armes du vaisseau.
        }


        public void RechargerArme()
        {
            foreach (var item in ArmesVaisseau)
            {
                item.TempsAvantRecharge--;
            }
        }

        public float DegatsMoyen()
        {
            float degatMoyen = 0;

            for (int i = 0; i < ArmesVaisseau.Count; i++)
            {
                degatMoyen += (ArmesVaisseau[i].DegatMinimum + ArmesVaisseau[i].DegatMaximum) / 2;
            }

            return degatMoyen / ArmesVaisseau.Count;
        }

        public void AfficherArmurerie() // Affiche toute les armes de l'armurerie
        {
            var sb = new StringBuilder();

            sb.Append($"---------Armes du Vaisseau---------\n");

            foreach (var arme in ArmesVaisseau)
            {
                sb.Append($"{arme}\n");
            }

            sb.Append($"{string.Join(string.Empty, Enumerable.Repeat("-", 35))}");

            Console.WriteLine(sb.ToString());
        }

        //public override string ToString()
        //{
        //    var sb = new StringBuilder();

        //    sb.Append($"##### Vaisseau Spatial  #####\n");

        //    sb.Append($"Point de structure Maximum: {PointStructureMaximum}\n");
        //    sb.Append($"Point de bouclier Maximum: {PointBouclierMaximum}\n");

        //    return sb.ToString();
        //}

        public void AfficherVaisseau()
        {
            Console.WriteLine("========         INFOS VAISSEAU         ========");
            Console.WriteLine("Nom : " + Nom);
            Console.WriteLine("Points de vie : " + PointStructureMaximum);
            Console.WriteLine("Bouclier : " + PointBouclierMaximum);
            AfficherArmurerie();
            Console.WriteLine("Dommages moyens: " + DegatsMoyen());
            Console.WriteLine();
        }

    }
}