using TP4_CHEKATT.Vaisseaux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT
{
    internal class Joueur
    {
        private string Nom { get; }

        private string Prenom { get; }

        private string Pseudo { get; }

        public Vaisseau Vaisseau { get; set; }

        public Joueur(string last_name, string first_name, string username)
        {
            Nom = StringTools.Format(last_name); 
            Prenom = StringTools.Format(first_name);
            Pseudo = username;
            Vaisseau = new ViperMKII(true);
        }

        public Joueur()
        {
        }

        public string Identite => $"{Nom} {Prenom}";

        public string PseudoJoueur => $"{Pseudo}";

        public override string ToString() => $"{Pseudo} ({Identite})"; // Redefinition de la methode ToString (Expression body)

        public override bool Equals(object obj)
        {
            var other = obj as Joueur; // autre joueur

            if (other == null) // Si l'autre joueur est null renvoie faux
            {
                return false;
            }

            return Pseudo == other.Pseudo; // retourne true si le pseudo = autre pseudo
        }

        public void SetVaisseau(Vaisseau vaisseau)
        {
            Vaisseau = vaisseau;
        }

    }


}
