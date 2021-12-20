using TP4_CHEKATT;
using Microsoft.Win32;
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
using System.Data;
using System.Collections.ObjectModel;

namespace TP4_CHEKATT.View
{
    /// <summary>
    /// Logique d'interaction pour HelloWorldView.xaml
    /// </summary>
    public partial class HelloWorldView : Window
    {
        private List<Joueur> Joueurs { get; set; } = new List<Joueur>();

        private Joueur joueurSelectionner = new Joueur();

        private ImageSource image;


        public HelloWorldView()
        {
            InitializeComponent();
            InitialiseJoueur();
            InitialiseLabel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Fichier texte (*.txt)|*.txt";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Veuillez choisir un document texte s'il vous plaît";

            if (dialog.ShowDialog() == true) { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images (*.png, *.jpg, ...) | *.jpg; *.jpeg; *.png; *.svg;";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Veuillez choisir une image s'il vous plaît";

            if (dialog.ShowDialog() == true)
            {
                if (joueurSelectionner != null)
                {
                    image = new BitmapImage(new Uri(dialog.FileName));
                    joueurSelectionner.Vaisseau.Image = image;
                    imgVaisseau.Source = image;
                }
                
            }
        }

        private void btnAjouterJoueur_Click(object sender, RoutedEventArgs e)
        {
            JoueurView windowJoueurView = new JoueurView();

            if ((bool)windowJoueurView.ShowDialog())
            {
                string nom = windowJoueurView.Nom;
                string prenom = windowJoueurView.Prenom;
                string pseudo = windowJoueurView.Pseudo;

                Joueur joueurCreer = new Joueur(windowJoueurView.Nom, windowJoueurView.Prenom, windowJoueurView.Pseudo);
                lbxJoueurs.Items.Add(joueurCreer);
            }
        }

        private void btnSupprimerJoueur_Click(object sender, RoutedEventArgs e)
        {
            lbxJoueurs.Items.Remove(lbxJoueurs.SelectedItem);
        }

        public void InitialiseJoueur()
        {
            Joueurs = new List<Joueur>
            {
                new Joueur("Rayane", "CHEKATT", "Skillou"),
                new Joueur("Benzema", "Karim","KbNueve9"),
                new Joueur("Cristiano", "Ronaldo", "CR7"),
                new Joueur("JUL", "OVNI", "LaMachine")
            };

            foreach (Joueur joueur in Joueurs)
            {
                lbxJoueurs.Items.Add(joueur);
            }
        }

        public void InitialiseLabel()
        {
            lblNomJoueur.Content = "";

            lblVaisseauJoueur.Content = "";
            lblStructureVaisseau.Content = "";
            lblBouclierVaisseau.Content = "";
            lblDegatMoyenVaisseau.Content = "";
        }

        private void lbxJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Joueur joueur in lbxJoueurs.SelectedItems)
            {
                string nomJoueur = joueur.PseudoJoueur;
                string nomVaisseau = joueur.Vaisseau.Nom;
                string structureVaisseau = joueur.Vaisseau.PointStructureMaximum.ToString();
                string bouclierVaisseau = joueur.Vaisseau.PointBouclierMaximum.ToString();
                string degatMoyenVaisseau = joueur.Vaisseau.DegatsMoyen().ToString();

                lblNomJoueur.Content = nomJoueur;

                lblVaisseauJoueur.Content = nomVaisseau;
                lblStructureVaisseau.Content = structureVaisseau;
                lblBouclierVaisseau.Content = bouclierVaisseau;
                lblDegatMoyenVaisseau.Content = degatMoyenVaisseau;

                joueurSelectionner = joueur;

                List<Arme> armesVaisseau = joueurSelectionner.Vaisseau.ArmesVaisseau;

                dgArmes.ItemsSource = armesVaisseau;
            }
        }

        private void btnSupprimerArme_Click(object sender, RoutedEventArgs e)
        {
            dgArmes.ItemsSource = joueurSelectionner.Vaisseau.ArmesVaisseau;
            joueurSelectionner.Vaisseau.RetirerArme((Arme)dgArmes.SelectedItem);
        }

        private void btnAjouterArme_Click(object sender, RoutedEventArgs e)
        {
            // Faire la logique
            ArmurerieView windowArmurerieView = new ArmurerieView();

            if ((bool)windowArmurerieView.ShowDialog())
            {
                dgArmes.ItemsSource = joueurSelectionner.Vaisseau.ArmesVaisseau;

                Arme arme = windowArmurerieView.armeAjouter;

                joueurSelectionner.Vaisseau.AjouterArme(arme);
            }
        }
        private void btnEnrengister_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
