using Hector.Modeles;
using Hector.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hector
{
    public partial class FormMain : Form
    {
        public const int ENTER = 13; //numéro touche entrée
        public string PathDB { get; set; } //chemin vers le fichier de BDD
        public bool PremiereOuverture { get; set; } //caractérise la première ouverture ou non de l'application
        public Import_Form ImportFormObject { get; set; } //formulaire d'import
        public Export_Form ExportFormObject { get; set; } //formulaire d'export
        public Donnees DonneesBDD { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public TreeNode TousLesArticles { get; set; } //noeud articles du TreeViewElements
        public TreeNode Marques { get; set; } //noeud marques du TreeViewElements
        public TreeNode Familles { get; set; } //noeud familles du TreeViewElements
        public ListViewColumnSorter LvwColumnSorter { get; set; } //représente l'objet permettant de trier notre ListViewElements
        public Update_Article_Form UpdateArticleFormObject { get; set; }
        public Update_Famille_Form UpdateFamilleFormObject { get; set; }
        public Update_Marque_Form UpdateMarqueFormObject { get; set; }
        public Update_Sous_Famille_Form UpdateSousFamilleFormObject { get; set; }


        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>FormMain</b>
        /// </summary>
        public FormMain()
        {
            PremiereOuverture = true;

            PathDB = Path.GetFullPath("Hector.SQLite"); //Récupère le path dynamiquement de la BDD

            DonneesBDD = new Donnees();

            InitializeComponent();

            LvwColumnSorter = new ListViewColumnSorter();
            this.ListViewElements.ListViewItemSorter = LvwColumnSorter;

            TousLesArticles = new TreeNode("Tous les articles");
            Familles = new TreeNode("Familles");
            Marques = new TreeNode("Marques");

            // Initialisation du TreeView
            TreeViewElements.Nodes.Add(TousLesArticles);
            TreeViewElements.Nodes.Add(Familles);
            TreeViewElements.Nodes.Add(Marques);

            ActualiserBDD();
            PremiereOuverture = false;

        }

        /// <summary>
        /// Déclenche l'évènement Importer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFormObject = new Import_Form(DonneesBDD); //on initialise l"ovjet Import_Form
            ImportFormObject.ShowDialog(this); //on lance celui-ci en mode modal

            if (ImportFormObject.ImportedEcraser == true) //s'il y a eu import en mode écrasement
            {
                DonneesBDD = ImportFormObject.DonneesBDD; //on récupère les données issues de cet import
                ActualiserBDD(); //on actualise la BDD
                ImportFormObject.ImportedEcraser = false; //on remet à jour le détecteur
            }

            if (ImportFormObject.ImportedAjouterModifier == true) //s'il y'a eu import en mode ajouter/modifier
            {
                DonneesBDD = ImportFormObject.DonneesBDD; //même principe que précédemment
                ActualiserBDD();
                ImportFormObject.ImportedAjouterModifier = false;
            }
        }

        /// <summary>
        /// Déclenche l'évènement Exporter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFormObject = new Export_Form(DonneesBDD); //on initialise l'objet Export_Form
            ExportFormObject.ShowDialog(this); //on lance celui-ci en mode modal
        }

        /// <summary>
        /// Fonction d'actualisation de l'application
        /// </summary>
        private void ActualiserBDD()
        {
            try
            {
                if ((ImportFormObject != null) && (ImportFormObject.ImportedEcraser || ImportFormObject.ImportedAjouterModifier))
                {
                    Familles.Nodes.Clear();
                    Marques.Nodes.Clear();

                    // Ajout des familles et sous familles
                    for (int i = 0; i < DonneesBDD.ListeFamilles.Count(); i++)
                    {
                        Familles.Nodes.Add(DonneesBDD.ListeFamilles[i].Nom);

                        for (int j = 0; j < DonneesBDD.ListSousFamilles.Count(); j++)
                        {
                            if (DonneesBDD.ListSousFamilles[j].Famille.Nom == DonneesBDD.ListeFamilles[i].Nom)
                            {
                                Familles.Nodes[i].Nodes.Add(DonneesBDD.ListSousFamilles[j].Nom);
                            }
                        }

                    }

                    //Ajout des marques
                    for (int i = 0; i < DonneesBDD.ListeMarques.Count(); i++)
                    {
                        Marques.Nodes.Add(DonneesBDD.ListeMarques[i].NomMarque);
                    }
                }
                else
                {

                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        DB.Open();

                        DonneesBDD.ListeArticles = DAO.ArticleDAO.GetAllArticles(DB);
                        DonneesBDD.ListeFamilles = DAO.FamilleDAO.GetAllFamilles(DB);
                        DonneesBDD.ListeMarques = DAO.MarqueDAO.GetAllMarques(DB);
                        DonneesBDD.ListSousFamilles = DAO.SousFamilleDAO.GetAllSousFamilles(DB);

                        //On supprime tous les noeuds
                        Familles.Nodes.Clear();
                        Marques.Nodes.Clear();

                        // Ajout des familles et sous familles
                        for (int i = 0; i < DonneesBDD.ListeFamilles.Count(); i++)
                        {
                            Familles.Nodes.Add(DonneesBDD.ListeFamilles[i].Nom);

                            List<SousFamille> listeSousFamilles = DAO.SousFamilleDAO.GetSousFamillesByRefFamille(DB, DonneesBDD.ListeFamilles[i].RefFamille);

                            for (int j = 0; j < listeSousFamilles.Count(); j++)
                            {
                                Familles.Nodes[i].Nodes.Add(listeSousFamilles[j].Nom);
                            }

                        }


                        //Ajout des marques
                        for (int i = 0; i < DonneesBDD.ListeMarques.Count(); i++)
                        {
                            Marques.Nodes.Add(DonneesBDD.ListeMarques[i].NomMarque);
                        }


                        DB.Close();
                    }


                    //On déplie tous les éléments
                    TreeViewElements.CollapseAll();
                    Familles.Collapse();
                    Marques.Collapse();
                    TreeViewElements.SelectedNode = TousLesArticles;
                }

                string Statut = "Présent en BDD : " + DonneesBDD.ListeArticles.Count().ToString() + " articles | " + DonneesBDD.ListeFamilles.Count().ToString() + " familles | " + DonneesBDD.ListSousFamilles.Count().ToString() + " sous-familles | " + DonneesBDD.ListeMarques.Count().ToString() + " marques";
                ToolStripStatusLabelBDD.Text = Statut;

                if (!PremiereOuverture)
                {
                    MessageBox.Show("Données actualisées dans l'application. \n\nPensez à cliquer à nouveau sur l'un des noeuds du treeview pour mettre l'affichage à jour ;) !", "Actualisation terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
            }
        }


        /// <summary>
        /// Déclenche l'évènement Actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualiserBDD();
        }


        /// <summary>
        /// Déclenche l'évènement de sélection sur TreeViewElements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //On supprime tout ce qui touche à la ListViewElements (les items à l'intérieur, et les colonnes)
            ListViewElements.Items.Clear();
            ListViewElements.Columns.Clear();

            if (TreeViewElements.SelectedNode.Text == "Tous les articles")
            {
                ListViewElements.Columns.Add("Description");
                ListViewElements.Columns.Add("Familles");
                ListViewElements.Columns.Add("Sous-familles");
                ListViewElements.Columns.Add("Marques");
                ListViewElements.Columns.Add("Quantité");
                ListViewElements.Columns.Add("PrixHT");
                ListViewElements.Columns.Add("Référence");

                for (int iBoucle = 0; iBoucle < DonneesBDD.ListeArticles.Count(); iBoucle++)
                {
                    string[] Tab = new string[7];
                    Tab[0] = DonneesBDD.ListeArticles[iBoucle].Description;
                    Tab[1] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom;
                    Tab[2] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom;
                    Tab[3] = DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque;
                    Tab[4] = DonneesBDD.ListeArticles[iBoucle].Quantite.ToString();
                    Tab[5] = DonneesBDD.ListeArticles[iBoucle].PrixHT.ToString();
                    Tab[6] = DonneesBDD.ListeArticles[iBoucle].RefArticle;

                    ListViewItem Item = new ListViewItem(Tab);

                    Item.Tag = DonneesBDD.ListeArticles[iBoucle];

                    ListViewElements.Items.Add(Item);

                }
                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            else if (TreeViewElements.SelectedNode.Text == "Familles")
            {
                ListViewElements.Columns.Add("Description");

                for (int iBoucle = 0; iBoucle < DonneesBDD.ListeFamilles.Count(); iBoucle++)
                {
                    string[] tab = new string[1];
                    tab[0] = DonneesBDD.ListeFamilles[iBoucle].Nom;

                    ListViewItem Item = new ListViewItem(tab);
                    Item.Tag = DonneesBDD.ListeFamilles[iBoucle];

                    ListViewElements.Items.Add(Item);

                }

                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            else if (TreeViewElements.SelectedNode.Text == "Marques")
            {
                ListViewElements.Columns.Add("Description");

                for (int iBoucle = 0; iBoucle < DonneesBDD.ListeMarques.Count(); iBoucle++)
                {
                    string[] tab = new string[1];
                    tab[0] = DonneesBDD.ListeMarques[iBoucle].NomMarque;

                    ListViewItem Item = new ListViewItem(tab);
                    Item.Tag = DonneesBDD.ListeMarques[iBoucle];

                    ListViewElements.Items.Add(Item);
                }

                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            else
            {
                if (TreeViewElements.SelectedNode.Parent.Text == "Marques")
                {
                    ListViewElements.Columns.Add("Description");
                    ListViewElements.Columns.Add("Familles");
                    ListViewElements.Columns.Add("Sous-familles");
                    ListViewElements.Columns.Add("Marques");
                    ListViewElements.Columns.Add("Quantité");
                    ListViewElements.Columns.Add("PrixHT");
                    ListViewElements.Columns.Add("Référence");

                    for (int iBoucle = 0; iBoucle < DonneesBDD.ListeArticles.Count(); iBoucle++)
                    {
                        if (DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque == TreeViewElements.SelectedNode.Text)
                        {
                            string[] Tab = new string[7];
                            Tab[0] = DonneesBDD.ListeArticles[iBoucle].Description;
                            Tab[1] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom;
                            Tab[2] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom;
                            Tab[3] = DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque;
                            Tab[4] = DonneesBDD.ListeArticles[iBoucle].Quantite.ToString();
                            Tab[5] = DonneesBDD.ListeArticles[iBoucle].PrixHT.ToString();
                            Tab[6] = DonneesBDD.ListeArticles[iBoucle].RefArticle;

                            ListViewItem Item = new ListViewItem(Tab);
                            Item.Tag = DonneesBDD.ListeArticles[iBoucle];

                            ListViewElements.Items.Add(Item);
                        }
                    }
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else if (TreeViewElements.SelectedNode.Parent.Text == "Familles")
                {
                    ListViewElements.Columns.Add("Description");
                    ListViewElements.Columns.Add("Familles");
                    ListViewElements.Columns.Add("Sous-familles");
                    ListViewElements.Columns.Add("Marques");
                    ListViewElements.Columns.Add("Quantite");
                    ListViewElements.Columns.Add("PrixHT");
                    ListViewElements.Columns.Add("Référence");

                    for (int iBoucle = 0; iBoucle < DonneesBDD.ListeArticles.Count(); iBoucle++)
                    {
                        if (DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom == TreeViewElements.SelectedNode.Text)
                        {
                            string[] Tab = new string[7];
                            Tab[0] = DonneesBDD.ListeArticles[iBoucle].Description;
                            Tab[1] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom;
                            Tab[2] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom;
                            Tab[3] = DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque;
                            Tab[4] = DonneesBDD.ListeArticles[iBoucle].Quantite.ToString();
                            Tab[5] = DonneesBDD.ListeArticles[iBoucle].PrixHT.ToString();
                            Tab[6] = DonneesBDD.ListeArticles[iBoucle].RefArticle;

                            ListViewItem Item = new ListViewItem(Tab);
                            Item.Tag = DonneesBDD.ListeArticles[iBoucle];

                            ListViewElements.Items.Add(Item);
                        }
                    }
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else if (TreeViewElements.SelectedNode.Parent.Parent.Text == "Familles")
                {
                    ListViewElements.Columns.Add("Description");
                    ListViewElements.Columns.Add("Familles");
                    ListViewElements.Columns.Add("Sous-familles");
                    ListViewElements.Columns.Add("Marques");
                    ListViewElements.Columns.Add("Quantité");
                    ListViewElements.Columns.Add("PrixHT");
                    ListViewElements.Columns.Add("Référence");

                    for (int iBoucle = 0; iBoucle < DonneesBDD.ListeArticles.Count(); iBoucle++)
                    {
                        if (DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom == TreeViewElements.SelectedNode.Text)
                        {
                            string[] Tab = new string[7];
                            Tab[0] = DonneesBDD.ListeArticles[iBoucle].Description;
                            Tab[1] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Famille.Nom;
                            Tab[2] = DonneesBDD.ListeArticles[iBoucle].SousFamilleArticle.Nom;
                            Tab[3] = DonneesBDD.ListeArticles[iBoucle].MarqueArticle.NomMarque;
                            Tab[4] = DonneesBDD.ListeArticles[iBoucle].Quantite.ToString();
                            Tab[5] = DonneesBDD.ListeArticles[iBoucle].PrixHT.ToString();
                            Tab[6] = DonneesBDD.ListeArticles[iBoucle].RefArticle;

                            ListViewItem Item = new ListViewItem(Tab);
                            Item.Tag = DonneesBDD.ListeArticles[iBoucle];

                            ListViewElements.Items.Add(Item);
                        }
                    }
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ListViewElements.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        /// <summary>
        /// Déclenchement de l'évènement à la fermeture de <b>FormMain</b>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
             * Enregistrez la position de votre fenêtre principale quand vous la fermez. Pour cela, utilisez
                « ConfigurationManager » comme vous pouvez le voir dans le slide 3, le statut « Maximisé »
                ne doit pas être oublié. « AppPath » doit être renseigné avec le chemin complet de
                l’exécutable final et de manière dynamique, utilisez « Assembly… ».
                • Puisque maintenant nous avons cette information, replacez votre fenêtre principale lors de
                son lancement à son dernier emplacement/état tout en évitant les débordements. La
                fenêtre doit rester dans la zone de l’écran à son ouverture.
            */
        }


        /// <summary>
        /// Déclenchement de l'évènement de double clique sur la <b>ListViewElements</b>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewElements_DoubleClick(object sender, EventArgs e)
        {
            UpdateArticleFormObject = new Update_Article_Form(DonneesBDD, PathDB);
            UpdateFamilleFormObject = new Update_Famille_Form(DonneesBDD, PathDB);
            UpdateMarqueFormObject = new Update_Marque_Form(DonneesBDD, PathDB);
            UpdateSousFamilleFormObject = new Update_Sous_Famille_Form(DonneesBDD, PathDB);

            try
            {
                ListView.SelectedListViewItemCollection Items = ListViewElements.SelectedItems;
                Type Type = Items[0].Tag.GetType();

                Article ArticleObjet = new Article();
                Famille FamilleObjet = new Famille();
                Marque MarqueObjet = new Marque();
                SousFamille SFamilleObjet = new SousFamille();

                if (Type == typeof(Article)) //type.Equals(article))
                {
                    ArticleObjet = (Article)Items[0].Tag;
                    UpdateArticleFormObject.ModifierArticle(ArticleObjet);
                    UpdateArticleFormObject.ShowDialog(this);

                    if (UpdateArticleFormObject.Modification || UpdateArticleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }

                else if (Type == typeof(Famille)) //type.Equals(article))
                {
                    FamilleObjet = (Famille)Items[0].Tag;
                    UpdateFamilleFormObject.ModifierFamille(FamilleObjet);
                    UpdateFamilleFormObject.ShowDialog(this);
                    if (UpdateFamilleFormObject.Modification || UpdateSousFamilleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
                else if (Type == typeof(SousFamille)) //type.Equals(article))
                {
                    SFamilleObjet = (SousFamille)Items[0].Tag;
                    UpdateSousFamilleFormObject.ModifierSousFamille(SFamilleObjet);
                    UpdateSousFamilleFormObject.ShowDialog(this);
                    if (UpdateSousFamilleFormObject.Modification || UpdateSousFamilleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
                else if (Type == typeof(Marque)) //type.Equals(article))
                {
                    MarqueObjet = (Marque)Items[0].Tag;
                    UpdateMarqueFormObject.ModifierMarque(MarqueObjet);
                    UpdateMarqueFormObject.ShowDialog(this);
                    if (UpdateMarqueFormObject.Modification || UpdateMarqueFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
            }
            catch (Exception E)
            {

            }
        }

        /// <summary>
        /// Déclenchement de l'évènement de clique sur une colonne de la <b>ListViewElements</b>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewElements_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == LvwColumnSorter.ColumnToSort)
            {
                if (LvwColumnSorter.OrderOfSort == SortOrder.Ascending)
                {
                    LvwColumnSorter.OrderOfSort = SortOrder.Descending;
                }
                else
                {
                    LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }
            }
            else
            {
                LvwColumnSorter.ColumnToSort = e.Column;
                LvwColumnSorter.OrderOfSort = SortOrder.Ascending;
            }

            this.ListViewElements.Sort();
        }

        /// <summary>
        /// Déclenchement de l'évènement de clique sur une touche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewElements_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ENTER) //TOUCHE ENTREE
            {
                ModifierElement();
            }
        }

        private void ListViewElements_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                SupprimerElement();
            }

            if (e.KeyCode == Keys.F5)
            {
                ActualiserBDD();
            }

            if (e.KeyCode == Keys.Space)
            {
                ModifierElement();
            }
        }

        /// <summary>
        /// Fonction modifier élément
        /// </summary>
        private void ModifierElement()
        {
            UpdateArticleFormObject = new Update_Article_Form(DonneesBDD, PathDB);
            UpdateFamilleFormObject = new Update_Famille_Form(DonneesBDD, PathDB);
            UpdateMarqueFormObject = new Update_Marque_Form(DonneesBDD, PathDB);
            UpdateSousFamilleFormObject = new Update_Sous_Famille_Form(DonneesBDD, PathDB);
            try
            {
                ListView.SelectedListViewItemCollection Items = ListViewElements.SelectedItems;
                Type Type = Items[0].Tag.GetType();

                Article ArticleObjet = new Article();
                Famille FamilleObjet = new Famille();
                Marque MarqueObjet = new Marque();
                SousFamille SFamilleObjet = new SousFamille();

                if (Type == typeof(Article)) //type.Equals(article))
                {
                    ArticleObjet = (Article)Items[0].Tag;
                    UpdateArticleFormObject.ModifierArticle(ArticleObjet);
                    UpdateArticleFormObject.ShowDialog(this);

                    if (UpdateArticleFormObject.Modification || UpdateArticleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }

                else if (Type == typeof(Famille)) //type.Equals(article))
                {
                    FamilleObjet = (Famille)Items[0].Tag;
                    UpdateFamilleFormObject.ModifierFamille(FamilleObjet);
                    UpdateFamilleFormObject.ShowDialog(this);
                    if (UpdateFamilleFormObject.Modification || UpdateFamilleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
                else if (Type == typeof(SousFamille)) //type.Equals(article))
                {
                    SFamilleObjet = (SousFamille)Items[0].Tag;
                    UpdateSousFamilleFormObject.ModifierSousFamille(SFamilleObjet);
                    UpdateSousFamilleFormObject.ShowDialog(this);
                    if (UpdateSousFamilleFormObject.Modification || UpdateSousFamilleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
                else if (Type == typeof(Marque)) //type.Equals(article))
                {
                    MarqueObjet = (Marque)Items[0].Tag;
                    UpdateMarqueFormObject.ModifierMarque(MarqueObjet);
                    UpdateMarqueFormObject.ShowDialog(this);
                    if (UpdateMarqueFormObject.Modification || UpdateSousFamilleFormObject.Suppression)
                    {
                        ActualiserBDD();
                    }
                }
            }
            catch (Exception E)
            {
            }
        }

        /// <summary>
        /// Fonction suppression élément
        /// </summary>
        private void SupprimerElement()
        {
            try
            {
                ListView.SelectedListViewItemCollection Items = ListViewElements.SelectedItems;
                Type Type = Items[0].Tag.GetType();

                Article ArticleObjet = new Article();
                Famille FamilleObjet = new Famille();
                SousFamille SFamilleObjet = new SousFamille();
                Marque MarqueObjet = new Marque();


                if (Type == typeof(Article)) //type.Equals(article))
                {
                    ArticleObjet = (Article)Items[0].Tag;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        DB.Open();
                        try
                        {
                            ArticleDAO.SupprimerArticle(DB, ArticleObjet);
                            MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualiserBDD();
                        }

                        catch (Exception E)
                        {
                            MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                else if (Type == typeof(Famille)) //type.Equals(article))
                {
                    FamilleObjet = (Famille)Items[0].Tag;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        DB.Open();
                        try
                        {
                            if (FamilleDAO.SupprimerFamille(DB, FamilleObjet))
                            {
                                MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualiserBDD();
                            }
                            else
                            {
                                MessageBox.Show("Suppression impossible. Famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception E)
                        {
                            MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                else if (Type == typeof(SousFamille)) //type.Equals(article))
                {
                    SFamilleObjet = (SousFamille)Items[0].Tag;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        DB.Open();
                        try
                        {
                            if (SousFamilleDAO.SupprimerSousFamille(DB, SFamilleObjet))
                            {
                                MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualiserBDD();
                            }
                            else
                            {
                                MessageBox.Show("Suppression impossible. Sous-famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception E)
                        {
                            MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else if (Type == typeof(Marque)) //type.Equals(article))
                {
                    MarqueObjet = (Marque)Items[0].Tag;
                    using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                    {
                        DB.Open();
                        try
                        {
                            if (MarqueDAO.SupprimerMarque(DB, MarqueObjet))
                            {
                                MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualiserBDD();
                            }
                            else
                            {
                                MessageBox.Show("Suppression impossible. Marque liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception E)
                        {
                            MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception E)
            {

            }

        }

        /// <summary>
        /// Event de suppression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventSuppression(object sender, EventArgs e)
        {
            SupprimerElement();
        }

        /// <summary>
        /// Fonction modifier élément
        /// </summary>
        private void AjouterElement()
        {
            UpdateArticleFormObject = new Update_Article_Form(DonneesBDD, PathDB);
            UpdateFamilleFormObject = new Update_Famille_Form(DonneesBDD, PathDB);
            UpdateMarqueFormObject = new Update_Marque_Form(DonneesBDD, PathDB);
            UpdateSousFamilleFormObject = new Update_Sous_Famille_Form(DonneesBDD, PathDB);

            try
            {
                if (ListViewElements.SelectedItems.Count != 0)
                {
                    ListView.SelectedListViewItemCollection Items = ListViewElements.SelectedItems;
                    Type Type = Items[0].Tag.GetType();

                    Article ArticleObjet = new Article();
                    Famille FamilleObjet = new Famille();
                    Marque MarqueObjet = new Marque();
                    SousFamille SFamilleObjet = new SousFamille();

                    if (Type == typeof(Article)) //type.Equals(article))
                    {
                        ArticleObjet = (Article)Items[0].Tag;
                        UpdateArticleFormObject.AjouterArticle();
                        UpdateArticleFormObject.ShowDialog(this);

                        if (UpdateArticleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                    }

                    else if (Type == typeof(Famille)) //type.Equals(article))
                    {
                        FamilleObjet = (Famille)Items[0].Tag;
                        UpdateFamilleFormObject.AjouterFamille();
                        UpdateFamilleFormObject.ShowDialog(this);
                        if (UpdateFamilleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                    }
                    else if (Type == typeof(SousFamille)) //type.Equals(article))
                    {
                        SFamilleObjet = (SousFamille)Items[0].Tag;
                        UpdateSousFamilleFormObject.AjouterSousFamille(SFamilleObjet);
                        UpdateSousFamilleFormObject.ShowDialog(this);
                        if (UpdateSousFamilleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                    }
                    else if (Type == typeof(Marque)) //type.Equals(article))
                    {
                        MarqueObjet = (Marque)Items[0].Tag;
                        UpdateMarqueFormObject.AjoutMarque();
                        UpdateMarqueFormObject.ShowDialog(this);
                        if (UpdateMarqueFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                    }
                }
                else
                {

                }

            }
            catch (Exception E)
            {
            }
        }

        /// <summary>
        /// Déclenchement évènement ajouter du context menu listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection items = ListViewElements.SelectedItems;

            if (ListViewElements.SelectedItems.Count != 0)
            {
                AjouterElement();
            }
            else
            {
                switch (TreeViewElements.SelectedNode.Text)
                {
                    case "Tous les articles":

                        UpdateArticleFormObject = new Update_Article_Form(DonneesBDD, PathDB);
                        UpdateArticleFormObject.AjouterArticle();
                        UpdateArticleFormObject.ShowDialog(this);

                        if (UpdateArticleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }

                        break;

                    case "Marques":

                        UpdateMarqueFormObject = new Update_Marque_Form(DonneesBDD, PathDB);
                        UpdateMarqueFormObject.AjoutMarque();
                        UpdateMarqueFormObject.ShowDialog(this);

                        if (UpdateMarqueFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                        break;

                    case "Familles":
                        UpdateFamilleFormObject = new Update_Famille_Form(DonneesBDD, PathDB);
                        UpdateFamilleFormObject.AjouterFamille();
                        UpdateFamilleFormObject.ShowDialog(this);

                        if (UpdateFamilleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }
                        break;

                    default:
                        /*UpdateSousFamilleFormObject = new Update_Sous_Famille_Form(DonneesBDD, PathDB);
                        //UpdateSousFamilleFormObject.AjouterSousFamille(SFamilleObjet);
                        UpdateSousFamilleFormObject.ShowDialog(this);

                        if (UpdateSousFamilleFormObject.Ajout)
                        {
                            ActualiserBDD();
                        }*/
                        break;
                }
            }
        }

        /// <summary>
        /// Déclenchement évènement modifier du context menu listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierElement();
        }

        /// <summary>
        /// Déclenchement évènement supprimer du context menu listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprimerElement();
        }

        /// <summary>
        /// Déclenchement ouverture du context menu listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ListViewElements.SelectedItems.Count == 0 || ListViewElements.SelectedItems.Count > 1)
            {
                ajouterToolStripMenuItem.Enabled = true;
                modifierToolStripMenuItem.Enabled = false;
                supprimerToolStripMenuItem.Enabled = false;
            }
            else
            {
                ajouterToolStripMenuItem.Enabled = true;
                modifierToolStripMenuItem.Enabled = true;
                supprimerToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Déclenchement ajouter context menu treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (TreeViewElements.SelectedNode.Text)
            {
                case "Tous les articles":

                    UpdateArticleFormObject = new Update_Article_Form(DonneesBDD, PathDB);
                    UpdateArticleFormObject.AjouterArticle();
                    UpdateArticleFormObject.ShowDialog(this);

                    if (UpdateArticleFormObject.Ajout)
                    {
                        ActualiserBDD();
                    }

                    break;

                case "Marques":

                    UpdateMarqueFormObject = new Update_Marque_Form(DonneesBDD, PathDB);
                    UpdateMarqueFormObject.AjoutMarque();
                    UpdateMarqueFormObject.ShowDialog(this);

                    if (UpdateMarqueFormObject.Ajout)
                    {
                        ActualiserBDD();
                    }
                    break;

                case "Familles":
                    UpdateFamilleFormObject = new Update_Famille_Form(DonneesBDD, PathDB);
                    UpdateFamilleFormObject.AjouterFamille();
                    UpdateFamilleFormObject.ShowDialog(this);

                    if (UpdateFamilleFormObject.Ajout)
                    {
                        ActualiserBDD();
                    }
                    break;

                default:
                    UpdateSousFamilleFormObject = new Update_Sous_Famille_Form(DonneesBDD, PathDB);
                    //UpdateSousFamilleFormObject.AjouterSousFamille(SFamilleObjet);
                    UpdateSousFamilleFormObject.ShowDialog(this);

                    if (UpdateSousFamilleFormObject.Ajout)
                    {
                        ActualiserBDD();
                    }
                    break;
            }
        }

        /// <summary>
        /// Déclenchement modifier context menu treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            ModifierElement();

        }

        /// <summary>
        /// Déclenchement supprimer context menu treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Article ArticleObjet = new Article();
            Famille FamilleObjet = new Famille();
            SousFamille SFamilleObjet = new SousFamille();
            Marque MarqueObjet = new Marque();

            ListView.SelectedListViewItemCollection Items = ListViewElements.SelectedItems;
            Type Type = Items[0].Tag.GetType();

            if (Type == typeof(Article)) //type.Equals(article))
            {
                ArticleObjet = (Article)Items[0].Tag;
                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    DB.Open();
                    try
                    {
                        ArticleDAO.SupprimerArticle(DB, ArticleObjet);
                        MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualiserBDD();
                    }

                    catch (Exception E)
                    {
                        MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (Type == typeof(Famille)) //type.Equals(article))
            {
                FamilleObjet = (Famille)Items[0].Tag;
                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    DB.Open();
                    try
                    {
                        if (FamilleDAO.SupprimerFamille(DB, FamilleObjet))
                        {
                            MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualiserBDD();
                        }
                        else
                        {
                            MessageBox.Show("Suppression impossible. Famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception E)
                    {
                        MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (Type == typeof(SousFamille)) //type.Equals(article))
            {
                SFamilleObjet = (SousFamille)Items[0].Tag;
                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    DB.Open();
                    try
                    {
                        if (SousFamilleDAO.SupprimerSousFamille(DB, SFamilleObjet))
                        {
                            MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualiserBDD();
                        }
                        else
                        {
                            MessageBox.Show("Suppression impossible. Sous-famille liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception E)
                    {
                        MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (Type == typeof(Marque)) //type.Equals(article))
            {
                MarqueObjet = (Marque)Items[0].Tag;
                using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                {
                    DB.Open();
                    try
                    {
                        if (MarqueDAO.SupprimerMarque(DB, MarqueObjet))
                        {
                            MessageBox.Show("Suppression prise en compte.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualiserBDD();
                        }
                        else
                        {
                            MessageBox.Show("Suppression impossible. Marque liée à des articles.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception E)
                    {
                        MessageBox.Show("Suppression impossible.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
