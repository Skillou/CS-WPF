using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Vaisseaux
{
    internal class Tardis : Vaisseau, IAptitude
    {
        public Tardis(bool belongsPlayer) : base("Tardis", 1, 0, belongsPlayer)
        {
        }

        public void Utilise(List<Vaisseau> vaisseaux)
        {
            Random r = new Random();
            int indexA = r.Next(0, vaisseaux.Count), indexB = r.Next(0, vaisseaux.Count);
            Vaisseau tmp = vaisseaux[indexA];
            vaisseaux[indexA] = vaisseaux[indexB];
            vaisseaux[indexB] = tmp;
        }
    }
}
