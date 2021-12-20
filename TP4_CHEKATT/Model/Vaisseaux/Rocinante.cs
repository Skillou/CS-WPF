using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class Rocinante : Vaisseau
    {
        public Rocinante(bool appartientAuJoueur) : base("Rocinante", 3, 5, appartientAuJoueur)
        {
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "Torpille").FirstOrDefault()));
        }
    }
}
