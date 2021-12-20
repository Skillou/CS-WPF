using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TP4_CHEKATT.View
{
    /// <summary>
    /// Logique d'interaction pour JoueurView.xaml
    /// </summary>
    public partial class JoueurView : Window
    {
        public JoueurView()
        {
            InitializeComponent();
        }

        public string Nom { get => txtNom.Text; set => txtNom.Text = value; }
        public string Prenom { get => txtPrenom.Text; set => txtPrenom.Text = value; }
        public string Pseudo { get => txtPseudo.Text; set => txtPseudo.Text = value; }

        private void btnEnrengister_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}