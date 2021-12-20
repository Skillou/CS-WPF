using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class B_Wings : Vaisseau
    {
        public B_Wings(bool appartientAuJoueur) : base("B-Wings", 30, 0, appartientAuJoueur)
        {
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "Hammer").FirstOrDefault()));

            foreach (var arme in ArmesVaisseau)
            {
                if (arme.ArmeType == ArmeType.Explosif)
                {
                    arme.TempsAvantRecharge = 1;
                    arme.TempsRechargement = 1;
                }
            }
        }
    }
}
