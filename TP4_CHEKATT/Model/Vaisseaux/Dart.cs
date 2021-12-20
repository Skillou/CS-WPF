using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class Dart : Vaisseau
    {
        public Dart(bool appartientAuJoueur) : base("Dart", 10, 3, appartientAuJoueur)
        {
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "Laser").FirstOrDefault()));

            foreach (var arme in ArmesVaisseau)
            {
                if (arme.ArmeType == ArmeType.Direct)
                {
                    arme.TempsAvantRecharge = 1;
                    arme.TempsRechargement = 1;
                }
            }
        }
    }
}
