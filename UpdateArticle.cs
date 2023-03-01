using Hector.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hector.DAO;
namespace Hector
{
    public partial class Update_Article_Form : Form
    {
        public Donnees DonneesDB { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public bool Modification { get; set; } //détecteur de modification
        public bool Suppression { get; set; } //détecteur de suppression
        public bool Ajout { get; set; } //détecteur d'ajout
        public Article ArticleObjet { get; set; }
        public List<SousFamille> ListeSousFamilles { get; set; }
        public int IndexInListeFamilles { get; set; }
        public int IndexInListeSFamilles { get; set; }
        public int IndexInListeMarques { get; set; }
        public string PathDB { get; set; } //chemin de la BDD

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Update_Article_Form</b>
        /// </summary>
        /// <param name="donnees"></param>
        /// <param name="pathDB"></param>
        public Update_Article_Form(Donnees donnees, String pathDB)
        {
            Modification = false;
            Suppression = false;
            Ajout = false;
            DonneesDB = donnees;
            PathDB = pathDB;
            ListeSousFamilles = new List<SousFamille>();
            InitializeComponent();
            SelecteurMarque.DataSource = DonneesDB.ListeMarques;
            SelecteurFamille.DataSource = DonneesDB.ListeFamilles;
        }

        /// <summary>
        /// Préparer le formulaire pour ajout
        /// </summary>
        public void AjouterArticle()
        {
            this.Text = "Ajout d'un article";

            Bouton1.Enabled = false;
            Bouton1.Hide();
            Bouton1.Text = "";
            Bouton2.Text = "Ajouter";
        }

        /// <summary>
        /// Préparer le formulaire pour modifier
        /// </summary>
        /// <param name="article"></param>
        public void ModifierArticle(Article article)
        {

            ArticleObjet = article;

            this.Text = "Modification Article : " + ArticleObjet.Description;

            Bouton1.Enabled = true;
            Bouton1.Show();
            Bouton1.Text = "Supprimer";
            Bouton2.Text = "Modifier";

            TextboxRefArticle.Text = article.RefArticle;
            TextboxDescription.Text = article.Description;
            SelecteurPrix.Value = article.PrixHT;
            SelecteurQuantite.Value = article.Quantite;


            IndexInListeMarques = DonneesDB.ListeMarques.FindIndex(item => item.NomMarque == article.MarqueArticle.NomMarque);
            IndexInListeFamilles = DonneesDB.ListeFamilles.FindIndex(item => item.Nom == article.SousFamilleArticle.Famille.Nom);
            ActualiserSelecteurSFamille(DonneesDB.ListeFamilles[IndexInListeFamilles]);
            IndexInListeSFamilles = ListeSousFamilles.FindIndex(item => item.Nom == article.SousFamilleArticle.Nom);

            SelecteurSFamille.SelectedIndex = IndexInListeSFamilles;
            SelecteurFamille.SelectedIndex = IndexInListeFamilles;
            SelecteurMarque.SelectedIndex = IndexInListeMarques;
        }

        /// <summary>
        /// Déclencher suppression
        /// </summary>
        private void SupprimerArticle()
        {
            using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
            {
                DB.Open();
                try
                {
                    ArticleDAO.SupprimerArticle(DB, ArticleObjet);
                    MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int IndexInListeArticles = DonneesDB.ListeArticles.FindIndex(item => item.RefArticle == ArticleObjet.RefArticle);
                    DonneesDB.ListeArticles.RemoveAt(IndexInListeFamilles);
                    Suppression = true;
                }

                catch (Exception E)
                {
                    MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        /// <summary>
        /// Gère l'actualisation du sélecteur de sous-famille
        /// </summary>
        public void ActualiserSelecteurSFamille(Famille famille)
        {
            ListeSousFamilles.Clear();
            foreach (SousFamille SFamilleBoucle in DonneesDB.ListSousFamilles)
            {
                if (SFamilleBoucle.Famille.RefFamille == famille.RefFamille)
                {
                    ListeSousFamilles.Add(SFamilleBoucle);
                }
            }

            SelecteurSFamille.DataSource = null;
            SelecteurSFamille.DataSource = ListeSousFamilles;
            SelecteurSFamille.DisplayMember = "Nom";

        }

        /// <summary>
        /// Gère l'actualisation du sélecteur de sous-famille
        /// </summary>
        private void SelecteurFamille_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexInListeFamilles = DonneesDB.ListeFamilles.FindIndex(item => item.Nom == SelecteurFamille.Text);
            ActualiserSelecteurSFamille(DonneesDB.ListeFamilles[IndexInListeFamilles]);
        }

        /// <summary>
        /// Déclenchement évènement bouton 1
        /// </summary>
        private void Bouton1_Click(object sender, EventArgs e)
        {
            if (Bouton1.Text == "Supprimer")
            {
                SupprimerArticle();
            }
        }

        /// <summary>
        /// Déclenchement évènement bouton 2
        /// </summary>
        private void Bouton2_Click(object sender, EventArgs e)
        {

            if (Bouton2.Text == "Ajouter")
            {
                ArticleObjet = new Article();

                ArticleObjet.Description = TextboxDescription.Text;
                ArticleObjet.RefArticle = TextboxRefArticle.Text;
                ArticleObjet.PrixHT = SelecteurPrix.Value;
                ArticleObjet.Quantite = (int)SelecteurQuantite.Value;
                ArticleObjet.MarqueArticle = (Marque)SelecteurMarque.SelectedItem;
                ArticleObjet.SousFamilleArticle = (SousFamille)SelecteurSFamille.SelectedItem;

                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    try
                    {
                        if (ArticleObjet.RefArticle == "" || ArticleObjet.Description == "" || ArticleObjet.MarqueArticle == null || ArticleObjet.SousFamilleArticle == null)
                        {
                            MessageBox.Show("Au moins un des champs est vide.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DB.Open();
                            ArticleDAO.AjouterArticle(DB, ArticleObjet);
                            MessageBox.Show("Ajout pris en compte.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DonneesDB.ListeArticles.Add(ArticleObjet);
                            Ajout = true;
                            DB.Close();
                        }

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Ajout non pris en compte.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
            }

            if (Bouton2.Text == "Modifier")
            {
                ArticleObjet = new Article();

                ArticleObjet.RefArticle = TextboxRefArticle.Text;
                ArticleObjet.Description = TextboxDescription.Text;
                ArticleObjet.RefArticle = TextboxRefArticle.Text;
                ArticleObjet.PrixHT = SelecteurPrix.Value;
                ArticleObjet.Quantite = (int)SelecteurQuantite.Value;
                ArticleObjet.MarqueArticle = (Marque)SelecteurMarque.SelectedItem;
                ArticleObjet.SousFamilleArticle = (SousFamille)SelecteurSFamille.SelectedItem;

                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    try
                    {
                        if (ArticleObjet.RefArticle == "" || ArticleObjet.Description == "" || ArticleObjet.MarqueArticle == null || ArticleObjet.SousFamilleArticle == null)
                        {
                            MessageBox.Show("Au moins un des champs est vide.", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DB.Open();
                            ArticleDAO.UpdateArticle(DB, ArticleObjet);
                            MessageBox.Show("Modification prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int IndexInListeArticles = DonneesDB.ListeArticles.FindIndex(item => item.RefArticle == ArticleObjet.RefArticle);
                            DonneesDB.ListeArticles[IndexInListeArticles] = ArticleObjet;
                            Modification = true;
                            DB.Close();
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Modification non prise en compte.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();

            }
        }

        /// <summary>
        /// Déclenchement évènement bouton 3
        /// </summary>
        private void Bouton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
