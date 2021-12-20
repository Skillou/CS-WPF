using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class ViperMKII : Vaisseau
    {
        public ViperMKII(bool appartientAuJoueur) : base("ViperMKII", 10, 15, appartientAuJoueur)
        {
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "Mitrailleuse").FirstOrDefault()));
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "EMG").FirstOrDefault()));
            AjouterArme(Armurerie.CreerArme(Armurerie.Instance.Armes.Where(x => x.Nom == "Missile").FirstOrDefault()));
        }
    }
}
