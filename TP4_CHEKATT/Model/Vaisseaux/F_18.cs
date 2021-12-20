using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class F_18 : Vaisseau, IAptitude
    {
        public F_18(bool belongsPlayer) : base("F-18", 15, 0, belongsPlayer)
        {
        }

        public void Utilise(List<Vaisseaux.Vaisseau> vaisseaux)
        {
            int position = vaisseaux.IndexOf(this);
            int positionJoueur = vaisseaux.IndexOf(vaisseaux.Where(x => x.AppartientJoueur).FirstOrDefault());
            //on cherche a déffinir si le vaisseau du joueur est contigu avec le F18
            if (Math.Abs(position - positionJoueur) <= 1)
            {
                Console.WriteLine("Salut les mecs ... c'est moi!");
                vaisseaux[positionJoueur].DegatSubit(10);
                this.DegatSubit(1000000000);
            }
        }
    }
}
