using Hector.Modeles;
using Hector.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class Export_Form : Form
    {

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Export_Form</b>
        /// </summary>
        /// <param name="donnees"></param>
        public Export_Form(Donnees donnees)
        {
            DonneesBDD = donnees;
            InitializeComponent();
        }

        public string FilePathCSV { get; set; } //path du fichier csv qui sera ou non sélectionné
        public string FileTitleCSV { get; set; } //nom du fichier csv qui sera ou non sélectionné
        public bool PathOpened { get; set; } //détecteur de sélection du fichier
        public string Separator { get; set; } //caractérise le séparateur entre les éléments du fichier qui sera écrit
        public string PathDB { get; set; } //chemin de la BDD
        public object Output { get; set; } //représente le buffer qui stockera le contenu de notre fichier à écrire
        public Donnees DonneesBDD { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques

        /// <summary>
        /// Déclenchement de l'élément Localisation Fichier CSV à exporter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Localisation_Export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
            {
                SaveFileDialog.InitialDirectory = Path.GetFullPath("Hector.SQLite");
                SaveFileDialog.Filter = "csv files (*.csv)|*.csv";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Récupère le path du fichier en question
                    FilePathCSV = SaveFileDialog.FileName;
                    FileTitleCSV = Path.GetFullPath(FilePathCSV);
                    Text_box_FichierCSV_Export.Text = FileTitleCSV; //on affiche à l'écran le path du fichier sélectionné
                }
            }
        }

        /// <summary>
        /// Déclenchement de l'élément Exporter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exporter_Click(object sender, EventArgs e)
        {
            string Path = Text_box_FichierCSV_Export.Text;

            if (Path == "")
            {
                MessageBox.Show("Aucun emplacement selectionné", "Erreur export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FilePathCSV = @Path;
                Separator = ";";
                StringBuilder Output = new StringBuilder();
                string Temp = "";

                Output.AppendLine("Description;Ref;Marque;Famille;Sous-Famille;Prix H.T.;Quantité"); //Création du header du fichier CSB
                int LengthListeArticles = DonneesBDD.ListeArticles.Count();

                File.WriteAllText(FilePathCSV, Output.ToString(), Encoding.Default); //On écrit d'abord le header du fichier CSV

                Output.Clear();

                ProgressBar_Export.Visible = true;
                ProgressBar_Export.Minimum = 0;
                ProgressBar_Export.Maximum = LengthListeArticles;
                ProgressBar_Export.Value = 0;
                ProgressBar_Export.Step = 1;

                for (int iBoucle = 0; iBoucle < LengthListeArticles; iBoucle++)
                {
                    Temp = DonneesBDD.ListeArticles[iBoucle].Description + Separator + DonneesBDD.ListeArticles[iBoucle].RefArticle + Separator + DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque + Separator + DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom + Separator + DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom + Separator + DonneesBDD.ListeArticles[iBoucle].PrixHT + Separator + DonneesBDD.ListeArticles[iBoucle].Quantite + Separator;
                    Output.AppendLine(Temp);
                    Temp = "";
                    ProgressBar_Export.PerformStep();
                }
                
                File.AppendAllText(FilePathCSV, Output.ToString(), Encoding.Default); //On ajoute tous les derniers éléments dans le fichier CSV

                DialogResult Result = MessageBox.Show("Données exportées avec succès.\nVoulez-vous ouvrir automatiquement ce fichier ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", FilePathCSV);
                }
                this.Close(); //On ferme le formulaire Export_Form
            }
        }
    }
}
