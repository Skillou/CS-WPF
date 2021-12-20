using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT
{
    internal class Armurerie // Singleton
    {
        public List<Arme> Armes { get; set; } = new List<Arme>();

        private static readonly Lazy<Armurerie> lazy = new Lazy<Armurerie>(() => new Armurerie()); // Implémentation thread safe du patern singleton
        public static Armurerie Instance { get { return lazy.Value; } }

        private Armurerie()
        {
            Init(); // Créer et Ajoute les armes dans l'armurie
        }

        private void Init() // Rempli l'armurerie
        {
            Armes = new List<Arme>
            {
                new Arme("Foncer", 80, 115, ArmeType.Direct, 4),
                new Arme("Rocket", 5, 200, ArmeType.Explosif, 1.5),
                new Arme("DMR14", 0, 15, ArmeType.Guide, 2),
                new Arme("Laser", 2, 3, ArmeType.Direct, 4),
                new Arme("Hammer", 1, 8, ArmeType.Explosif, 1.5),
                new Arme("Torpille", 3, 3, ArmeType.Guide, 2),
                new Arme("Mitrailleuse", 6, 8, ArmeType.Direct, 1),
                new Arme("EMG", 15, 37, ArmeType.Explosif, 3),
                new Arme("Missile", 7, 100, ArmeType.Direct, 4)
            };
        }

        internal static void AfficherArmurerie() // Affiche toute les armes de l'armurerie
        {
            Console.WriteLine("=====            Armurerie            =====");
            Console.WriteLine("========     Liste des armes       ========");

            foreach (Arme arme in Instance.Armes)
            {
                Console.WriteLine(arme);
            }
            Console.WriteLine();
        }

        public static bool EstArmeArmurerie(Arme arme)
        {
            return Instance.Armes.Contains(arme);
        }

        public static Arme CreerArme(Arme nouvelleArme)
        {
            Arme arme = new Arme(nouvelleArme);

            if (!EstArmeArmurerie(arme)) { throw new ArmurerieException(); }
            return arme;
        }

        public static Arme CreerArmeImporter(string nom, int degatMin, int degatMax, ArmeType type, double tpsRecharge)
        {
            Arme arme = new Arme(nom, degatMin, degatMax, type, tpsRecharge);
            Instance.Armes.Add(arme);
            return arme;
        }
    }
}