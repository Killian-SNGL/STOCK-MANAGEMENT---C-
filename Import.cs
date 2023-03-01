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
using Hector.Modeles;
using Hector.DAO;
using Hector.Modeles;

namespace Hector
{
    public partial class Import_Form : Form
    {
        public string FilePathCSV { get; set; } //path du fichier csv qui sera ou non sélectionné
        public FileStream FileStream { get; set; } //fichier de flux de fichier (pour lire ou écrire)
        public string FileTitleCSV { get; set; } //nom du fichier csv qui sera ou non sélectionné
        public bool FileSelected { get; set; } //détecteur de sélection du fichier
        public string FileContent { get; set; } //contenu du fichier csv qui sera ou non sélectionné
        public string PathDB { get; set; } //chemin de la BDD
        public Donnees DonneesBDD { get; set; } //représente les données de notre application à savoir liste d'articles, familles, sous-familles marques
        public bool ImportedEcraser { get; set; } //détecteur d'import avec écrasement
        public bool ImportedAjouterModifier { get; set; } //détecteur d'import avec ajouts et modifications

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Import_Form</b>
        /// </summary>
        /// <param name="donnees"></param>
        public Import_Form(Donnees donnees)
        {
            DonneesBDD = donnees;
            FileSelected = false;
            PathDB = Path.GetFullPath("Hector.SQLite");
            InitializeComponent();
        } 

        /// <summary>
        /// Déclenchement de l'élément Ajouter Fichier CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Ajouter_CSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialogObject = new OpenFileDialog(); //on ouvre l'explorateur de fichiers
            {
                OpenFileDialogObject.InitialDirectory = PathDB;
                OpenFileDialogObject.Filter = "csv files (*.csv)|*.csv*";
                OpenFileDialogObject.FilterIndex = 1;
                OpenFileDialogObject.RestoreDirectory = true;

                if (OpenFileDialogObject.ShowDialog() == DialogResult.OK)
                {
                    //Récupère le path du fichier spécifié
                    FilePathCSV = OpenFileDialogObject.FileName;
                    FileTitleCSV = Path.GetFileName(FilePathCSV);
                    Textbox_Fichier_CSV.Text = FileTitleCSV;
                    FileSelected = true;
                }

            }
        }

        /// <summary>
        /// Déclement de l'élément Importer avec ajouts et modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Import_Ajouter_Modifier_Click(object sender, EventArgs e)
        {
            if (FileSelected)
            {
                //Lit le contenu du fichier et le met dans notre objet <b>FileStreamObject</b> 
                using (FileStream FileStreamObject = File.Open(FilePathCSV, FileMode.Open))
                {
                    using (StreamReader ReaderObject = new StreamReader(FileStreamObject, Encoding.Default))
                    {
                        ReaderObject.ReadLine(); //première ligne

                        int NbArticlesAjoutes = 0;
                        int NbAnomaliesArticles = 0;

                        int NbFamillesAjoutees = 0;
                        int NbAnomaliesFamilles = 0;

                        int NbSousFamillesAjoutees = 0;
                        int NbAnomaliesSousFamilles = 0;

                        int NbMarquesAjoutees = 0;
                        int NbAnomaliesMarques = 0;

                        int NbArticlesModifies = 0;
                        int NbFamillesModifiees = 0;
                        int NbSousFamillesModifiees = 0;
                        int NbMarquesModifiees = 0;

                        List<Article> ListeArticlesAjout = new List<Article>(); //liste d'articles à ajouter
                        List<SousFamille> ListeSousFamillesAjout = new List<SousFamille>(); //liste de sous familles à ajouter
                        List<Marque> ListeMarquesAjout = new List<Marque>(); //liste de marques à ajouter
                        List<Famille> ListeFamillesAjout = new List<Famille>(); //liste de familles à ajouter


                        try
                        {
                            while (!ReaderObject.EndOfStream) //tant qu'on a pas tout lu
                            {
                                string fileCurrentLine = ReaderObject.ReadLine();
                                var Values = fileCurrentLine.Split(';');
                                //Values[0] = description
                                //Values[1]= ref
                                //Values[2] = marque
                                //Values[3] = famille
                                //Values[4] = sous famille
                                //Values[5] = prix H.T.

                                bool ArticleAjoute = false;
                                bool MarqueAjoutee = false;
                                bool SousFamilleAjoutee = false;
                                bool FamilleAjoutee = false;

                                Famille FamilleObjet = new Famille();
                                FamilleObjet.Nom = Values[3];

                                int IndexInListFamilles = DonneesBDD.ListeFamilles.FindIndex(item => item.Nom == Values[3]);
                                if (0 > IndexInListFamilles) //si l'élément n'est pas déjà présent dans notre liste
                                {
                                    ListeFamillesAjout.Add(FamilleObjet);
                                    IndexInListFamilles = ListeFamillesAjout.Count - 1;
                                    FamilleAjoutee = true;
                                }

                                SousFamille SFamilleObjet = new SousFamille();
                                SFamilleObjet.Nom = Values[4];
                                int IndexInListSousFamilles = DonneesBDD.ListSousFamilles.FindIndex(item => item.Nom == Values[4]);
                                if (0 > IndexInListSousFamilles) //si l'élément n'est pas déjà présent dans notre liste
                                {

                                    if (FamilleAjoutee)
                                    {
                                        SFamilleObjet.Famille = ListeFamillesAjout[IndexInListFamilles];
                                    }
                                    else
                                    {
                                        SFamilleObjet.Famille = DonneesBDD.ListeFamilles[IndexInListFamilles];
                                    }

                                    ListeSousFamillesAjout.Add(SFamilleObjet);
                                    IndexInListSousFamilles = ListeSousFamillesAjout.Count - 1;
                                    SousFamilleAjoutee = true;
                                }
                                else
                                {
                                    if (FamilleAjoutee)
                                    {
                                        DonneesBDD.ListSousFamilles[IndexInListSousFamilles].Famille = ListeFamillesAjout[IndexInListFamilles];
                                    }
                                    else
                                    {
                                        DonneesBDD.ListSousFamilles[IndexInListSousFamilles].Famille = DonneesBDD.ListeFamilles[IndexInListFamilles];
                                    }
                                    NbSousFamillesModifiees++;
                                }


                                Marque MarqueObject = new Marque();
                                MarqueObject.NomMarque = Values[2];
                                int IndexInListMarques = DonneesBDD.ListeMarques.FindIndex(item => item.NomMarque == Values[2]);
                                if (0 > IndexInListMarques) //si l'élément n'est pas déjà présent dans notre liste
                                {
                                    ListeMarquesAjout.Add(MarqueObject);
                                    NbMarquesAjoutees++;
                                    IndexInListMarques = ListeMarquesAjout.Count - 1;
                                    MarqueAjoutee = true;
                                }

                                Article ArticleObjet = new Article();
                                ArticleObjet.RefArticle = Values[1];
                                int IndexInListArticles = DonneesBDD.ListeArticles.FindIndex(item => item.RefArticle == Values[1]);
                                if (0 > IndexInListArticles) //si l'élément n'est pas déjà présent dans notre liste
                                {
                                    if (SousFamilleAjoutee)
                                    {
                                        ArticleObjet.SousFamilleArticle = ListeSousFamillesAjout[IndexInListSousFamilles];
                                    }
                                    else
                                    {
                                        ArticleObjet.SousFamilleArticle = DonneesBDD.ListSousFamilles[IndexInListSousFamilles];
                                    }

                                    if (MarqueAjoutee)
                                    {
                                        ArticleObjet.MarqueArticle = ListeMarquesAjout[IndexInListMarques];
                                    }
                                    else
                                    {
                                        ArticleObjet.MarqueArticle = DonneesBDD.ListeMarques[IndexInListMarques];
                                    }

                                    ArticleObjet.Description = Values[0];
                                    ArticleObjet.RefArticle = Values[1];
                                    ArticleObjet.PrixHT = decimal.Parse(Values[5]);
                                    ArticleObjet.Quantite = 1;
                                    ListeArticlesAjout.Add(ArticleObjet);
                                    IndexInListArticles = ListeArticlesAjout.Count - 1;
                                    ArticleAjoute = true;
                                }
                                else
                                {
                                    if (SousFamilleAjoutee)
                                    {
                                        DonneesBDD.ListeArticles[IndexInListArticles].SousFamilleArticle = ListeSousFamillesAjout[IndexInListSousFamilles];
                                    }
                                    else
                                    {
                                        DonneesBDD.ListeArticles[IndexInListArticles].SousFamilleArticle = DonneesBDD.ListSousFamilles[IndexInListSousFamilles];
                                    }

                                    if (MarqueAjoutee)
                                    {
                                        DonneesBDD.ListeArticles[IndexInListArticles].MarqueArticle = ListeMarquesAjout[IndexInListMarques];
                                    }
                                    else
                                    {
                                        DonneesBDD.ListeArticles[IndexInListArticles].MarqueArticle = DonneesBDD.ListeMarques[IndexInListMarques];
                                    }

                                    DonneesBDD.ListeArticles[IndexInListArticles].RefArticle = Values[1];
                                    DonneesBDD.ListeArticles[IndexInListArticles].Description = Values[0];
                                    DonneesBDD.ListeArticles[IndexInListArticles].PrixHT = decimal.Parse(Values[5]);
                                    DonneesBDD.ListeArticles[IndexInListArticles].Quantite++;
                                    NbArticlesModifies++;
                                }

                            }

                        }
                        catch(Exception E)
                        {
                            MessageBox.Show("Lecture du fichier compromise. Assurez-vous de respecter son format et de ne laisser aucun champ vide.", "Erreur import", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        Progress_Bar_Import.Value = 10;

                        using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                        {
                            try
                            {
                                DB.Open();
                                //AJOUT DES DIFFERENTS ELEMENTS DANS LA BDD

                                foreach (Marque MarqueBoucle in ListeMarquesAjout)
                                {
                                    try
                                    {
                                        MarqueDAO.AjouterMarque(DB, MarqueBoucle);
                                        MarqueBoucle.RefMarque = DAO.General.GetLastInsertedID(DB);
                                        NbMarquesAjoutees++;
                                        DonneesBDD.ListeMarques.Add(MarqueBoucle);
                                    }
                                    catch (Exception ExceptionObjet)
                                    {
                                        NbAnomaliesMarques++;
                                    }

                                }

                                Progress_Bar_Import.Value = 25;

                                foreach (Famille FamilleBoucle in ListeFamillesAjout)
                                {
                                    try
                                    {
                                        FamilleDAO.AjouterFamille(DB, FamilleBoucle);
                                        FamilleBoucle.RefFamille = DAO.General.GetLastInsertedID(DB);
                                        NbFamillesAjoutees++;
                                        DonneesBDD.ListeFamilles.Add(FamilleBoucle);
                                    }
                                    catch (Exception ExceptionObjet)
                                    {
                                        NbAnomaliesFamilles++;
                                    }
                                }

                                foreach (SousFamille SFamilleBoucle in ListeSousFamillesAjout)
                                {
                                    try
                                    {
                                        SousFamilleDAO.AjouterSousFamille(DB, SFamilleBoucle);
                                        SFamilleBoucle.RefSousFamille = DAO.General.GetLastInsertedID(DB);
                                        NbSousFamillesAjoutees++;
                                        DonneesBDD.ListSousFamilles.Add(SFamilleBoucle);
                                    }
                                    catch (Exception ExceptionObjet)
                                    {
                                        NbAnomaliesSousFamilles++;
                                    }
                                }

                                foreach (Article ArticleBoucle in ListeArticlesAjout)
                                {
                                    try
                                    {
                                        ArticleDAO.AjouterArticle(DB, ArticleBoucle);
                                        NbArticlesAjoutes++;
                                        DonneesBDD.ListeArticles.Add(ArticleBoucle);
                                    }
                                    catch (Exception ExceptionObjet)
                                    {
                                        NbAnomaliesArticles++;
                                    }
                                }

                                Progress_Bar_Import.Value = 50;

                                //MODIFICATION DES ELEMENTS DANS LA BDD

                                foreach (SousFamille sf in DonneesBDD.ListSousFamilles)
                                {
                                    try
                                    {
                                        SousFamilleDAO.UpdateSousFamille(DB, sf);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                                foreach (Article a in DonneesBDD.ListeArticles)
                                {
                                    try
                                    {
                                        ArticleDAO.UpdateArticle(DB, a);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                                Progress_Bar_Import.Value = 100;

                                DB.Open();
                            }
                            catch (Exception ex)
                            {
                           
                            }


                        }

                        Progress_Bar_Import.Value = 0;
                        ImportedAjouterModifier = true;

                        NbAnomaliesArticles = NbArticlesAjoutes - ListeArticlesAjout.Count();
                        NbAnomaliesFamilles = NbFamillesAjoutees - ListeFamillesAjout.Count();
                        NbAnomaliesMarques = NbMarquesAjoutees - ListeMarquesAjout.Count();
                        NbAnomaliesSousFamilles = NbSousFamillesAjoutees - ListeSousFamillesAjout.Count();


                        string InformationFinImport = "" +
                           " Nombre d'articles ajoutés : " + NbArticlesAjoutes.ToString() + "/" + ListeArticlesAjout.Count().ToString() + " lus" + "\n" +
                           " Nombre d'objets marque ajoutés : " + NbMarquesAjoutees.ToString() + "/" + ListeMarquesAjout.Count().ToString() + " lus" + "\n" +
                           " Nombre d'objets sous-famille ajoutés : " + NbSousFamillesAjoutees.ToString() + "/" + ListeSousFamillesAjout.Count().ToString() + " lus" + "\n" +
                           " Nombre d'objets famille ajoutés : " + NbFamillesAjoutees.ToString() + "/" + ListeFamillesAjout.Count().ToString() + " lus" + "\n" +

                           " Nombre d'articles modifiés : " + NbArticlesModifies + "\n" +
                           " Nombre d'objets sous-famille modifiés : " + NbSousFamillesModifiees;

                        DialogResult Result = MessageBox.Show(InformationFinImport, "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Result == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun fichier choisi pour l'import.", "Erreur import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Déclenchement de l'évènement Importer avec écrasement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Import_Ecraser_Click(object sender, EventArgs e)
        {
            if (FileSelected)
            {
                //Read the contents of the file into a stream
                using (FileStream FileStreamObject = File.Open(FilePathCSV, FileMode.Open))
                {
                    using (StreamReader ReaderObject = new StreamReader(FileStreamObject, Encoding.Default))
                    {
                        ReaderObject.ReadLine(); //première ligne

                        int NbArticlesAjoutes = 0;
                        int NbAnomaliesArticles = 0;
                        int NbAnomaliesFamilles = 0;
                        int NbAnomaliesSousFamilles = 0;
                        int NbAnomaliesMarques = 0;

                        DonneesBDD.ListeArticles.Clear();
                        DonneesBDD.ListeFamilles.Clear();
                        DonneesBDD.ListeMarques.Clear();
                        DonneesBDD.ListSousFamilles.Clear();

                        while (!ReaderObject.EndOfStream) //tant qu'on a pas tout lu
                        {
                            string fileCurrentLine = ReaderObject.ReadLine();
                            var values = fileCurrentLine.Split(';');
                            //values[0] = description
                            //values[1]= ref
                            //values[2] = marque
                            //values[3] = famille
                            //values[4] = sous famille
                            //values[5] = prix H.T.

                            Famille familleObjet = new Famille();
                            familleObjet.Nom = values[3];

                            int indexInListFamilles = DonneesBDD.ListeFamilles.FindIndex(item => item.Nom == values[3]);
                            if (0 > indexInListFamilles) //si l'élément n'est pas déjà présent dans notre liste
                            {
                                DonneesBDD.ListeFamilles.Add(familleObjet);
                                indexInListFamilles = DonneesBDD.ListeFamilles.Count - 1;
                            }

                            SousFamille sFamilleObjet = new SousFamille();
                            sFamilleObjet.Nom = values[4];
                            sFamilleObjet.Famille = DonneesBDD.ListeFamilles[indexInListFamilles];

                            int indexInListSousFamilles = DonneesBDD.ListSousFamilles.FindIndex(item => item.Nom == values[4]);
                            if (0 > indexInListSousFamilles) //si l'élément n'est pas déjà présent dans notre liste
                            {
                                DonneesBDD.ListSousFamilles.Add(sFamilleObjet);
                                indexInListSousFamilles = DonneesBDD.ListSousFamilles.Count - 1;
                            }

                            Marque marqueObject = new Marque();
                            marqueObject.NomMarque = values[2];
                            int indexInListMarques = DonneesBDD.ListeMarques.FindIndex(item => item.NomMarque == values[2]);
                            if (0 > indexInListMarques) //si l'élément n'est pas déjà présent dans notre liste
                            {
                                DonneesBDD.ListeMarques.Add(marqueObject);
                                indexInListMarques = DonneesBDD.ListeMarques.Count - 1;
                            }
            
                            Article articleObjet = new Article();
                            articleObjet.SousFamilleArticle = DonneesBDD.ListSousFamilles[indexInListSousFamilles];
                            articleObjet.MarqueArticle = DonneesBDD.ListeMarques[indexInListMarques];
                            articleObjet.Description = values[0];
                            articleObjet.RefArticle = values[1];
                            articleObjet.PrixHT = decimal.Parse(values[5]);
                            articleObjet.Quantite = 1;
                            DonneesBDD.ListeArticles.Add(articleObjet);
                        }

                        Progress_Bar_Import.Value = 10;

                        using (SQLiteConnection DB = new SQLiteConnection(@"Data Source =" + PathDB + ";Version=3;"))
                        {
                            try
                            {
                                DB.Open();


                                //Effacer table BDD
                                bool BDCleared = DAO.General.ClearAllTables(DB);

                                SQLiteCommand insertCommand = new SQLiteCommand();

                                foreach (Marque m in DonneesBDD.ListeMarques)
                                {

                                    try
                                    {
                                        MarqueDAO.AjouterMarque(DB, m);
                                        m.RefMarque = DAO.General.GetLastInsertedID(DB);
                                    }
                                    catch (Exception ex)
                                    {
                                        NbAnomaliesMarques++;
                                    }
                                }

                                Progress_Bar_Import.Value = 25;

                                foreach (Famille f in DonneesBDD.ListeFamilles)
                                {
                                    try
                                    {
                                        FamilleDAO.AjouterFamille(DB, f);
                                        f.RefFamille = DAO.General.GetLastInsertedID(DB);
                                    }
                                    catch (Exception ex)
                                    {
                                        NbAnomaliesFamilles++;
                                    }
                                }

                                Progress_Bar_Import.Value = 50;

                                foreach (SousFamille sf in DonneesBDD.ListSousFamilles)
                                {
                                    try
                                    {
                                        SousFamilleDAO.AjouterSousFamille(DB, sf);
                                        sf.RefSousFamille = DAO.General.GetLastInsertedID(DB);
                                    }
                                    catch (Exception ex)
                                    {
                                        NbAnomaliesSousFamilles++;
                                    }
                                }

                                Progress_Bar_Import.Value = 75;

                                foreach (Article a in DonneesBDD.ListeArticles)
                                {
                                    try
                                    {
                                        ArticleDAO.AjouterArticle(DB, a);
                                        NbArticlesAjoutes++;
                                    }
                                    catch (Exception ex)
                                    {
                                        ///
                                    }
                                }

                                Progress_Bar_Import.Value = 100;

                                DB.Close();
                            }
                            catch(Exception ex)
                            {

                            }

                        }

                        string InformationFinImport = ""+
                            " Nombre d'articles ajoutés : "+NbArticlesAjoutes.ToString()+"/"+ DonneesBDD.ListeArticles.Count().ToString()+" lus"+"\n"+
                            " Nombre d'objets marque ajoutés : "+(DonneesBDD.ListeMarques.Count()-NbAnomaliesMarques).ToString()+"/"+ DonneesBDD.ListeMarques.Count().ToString()+" lus" +"\n"+
                            " Nombre d'objets sous-famille ajoutés : "+(DonneesBDD.ListSousFamilles.Count()-NbAnomaliesSousFamilles).ToString()+"/"+ DonneesBDD.ListSousFamilles.Count().ToString()+" lus" +"\n"+
                            " Nombre d'objets famille ajoutés : "+(DonneesBDD.ListeFamilles.Count() - NbAnomaliesFamilles).ToString() + "/" + DonneesBDD.ListeFamilles.Count().ToString() + " lus";                        
                        
                        Progress_Bar_Import.Value = 0;
                        ImportedEcraser = true;

                        DialogResult Result = MessageBox.Show(InformationFinImport, "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Result == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }

                    }

                }
            }

            else
            {
                MessageBox.Show("Aucun fichier choisi pour l'import.", "Erreur import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
