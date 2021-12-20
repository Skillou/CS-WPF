using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour ArmurerieView.xaml
    /// </summary>
    public partial class ArmurerieView : Window
    {
        public Arme armeAjouter;

        public ArmurerieView()
        {
            InitializeComponent();
            InitialiseArmurerie();
        }

        private void cbxArmurerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // à voir par la suite quoi faire
        }

        private void InitialiseArmurerie()
        {
            for (int i = 0; i < Armurerie.Instance.Armes.Count; i++)
            {
                cbxArmurerie.Items.Add(Armurerie.Instance.Armes[i]);
            }
        }

        private void btnEnrengistrer_Click(object sender, RoutedEventArgs e)
        {
            armeAjouter = new Arme((Arme)cbxArmurerie.SelectedItem);
            this.DialogResult = true;
        }
    }
}
