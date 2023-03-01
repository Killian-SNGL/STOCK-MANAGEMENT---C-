using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hector.Modeles;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Hector.DAO
{
    /// <summary>
    /// DAO des objets <b>Articles</b>
    /// </summary>
    class ArticleDAO
    {
        /// <summary>
        /// Récupère tous les articles de la BDD et les transforme en objet <b>Article</b> sous formes d'une <b>List<Article></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <returns></returns>
        public static List<Article> GetAllArticles(SQLiteConnection objetConnection)
        {
            List<Article> ListeArticles = new List<Article>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Articles ORDER BY Description";

            try
            {
                SQLiteDataReader reader = SelectCommandObject.ExecuteReader();
                while (reader.Read())
                {
                    Article article = new Article();

                    article.RefArticle = Convert.ToString(reader["RefArticle"]);
                    article.Description = Convert.ToString(reader["Description"]);
                    article.PrixHT = Convert.ToDecimal(reader["PrixHT"]);
                    article.Quantite = Convert.ToInt32(reader["Quantite"]);

                    article.SousFamilleArticle = SousFamilleDAO.GetSousFamillesByRef(objetConnection, Convert.ToInt32(reader["RefSousFamille"]));
                    article.MarqueArticle = MarqueDAO.GetMarqueByRef(objetConnection, Convert.ToInt32(reader["RefMarque"]));

                    ListeArticles.Add(article);
                }

                return ListeArticles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///Récupère tous les articles de la BDD en fonction d'un nom précis et les transforme en objets <b>Article</b> sous forme d'une <b>List<Article></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static List<Article> GetArticlesByName(SQLiteConnection objetConnection, string nom)
        {
            List<Article> ListeArticles = new List<Article>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Articles WHERE Description = @nom ORDER BY Description";
            SelectCommandObject.Parameters.AddWithValue("@nom", nom);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    Article Article = new Article();

                    Article.RefArticle = Convert.ToString(Reader["RefArticle"]);
                    Article.Description = Convert.ToString(Reader["Description"]);
                    Article.PrixHT = Convert.ToDecimal(Reader["PrixHT"]);
                    Article.Quantite = Convert.ToInt32(Reader["Quantite"]);

                    Article.SousFamilleArticle = SousFamilleDAO.GetSousFamillesByRef(objetConnection, Convert.ToInt32(Reader["RefSousFamille"]));
                    Article.MarqueArticle = MarqueDAO.GetMarqueByRef(objetConnection, Convert.ToInt32(Reader["RefMarque"]));

                    ListeArticles.Add(Article);
                }

                return ListeArticles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Récupère tous les articles de la BDD en fonction d'une RefMarque précise et les transforme en objets <b>Article</b> sous forme d'une <b>List<Article></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="refMarque"></param>
        /// <returns></returns>
        public static List<Article> GetArticlesByRefMarque(SQLiteConnection objetConnection, int refMarque)
        {
            List<Article> ListeArticles = new List<Article>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Articles WHERE RefMarque = @nom ORDER BY Description";
            SelectCommandObject.Parameters.AddWithValue("@nom", refMarque);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    Article Article = new Article();

                    Article.RefArticle = Convert.ToString(Reader["RefArticle"]);
                    Article.Description = Convert.ToString(Reader["Description"]);
                    Article.PrixHT = Convert.ToDecimal(Reader["PrixHT"]);
                    Article.Quantite = Convert.ToInt32(Reader["Quantite"]);

                    Article.SousFamilleArticle = SousFamilleDAO.GetSousFamillesByRef(objetConnection, Convert.ToInt32(Reader["RefSousFamille"]));
                    Article.MarqueArticle = MarqueDAO.GetMarqueByRef(objetConnection, Convert.ToInt32(Reader["RefMarque"]));

                    ListeArticles.Add(Article);
                }

                return ListeArticles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Récupère tous les articles de la BDD en fonction d'une RefSousFamille précise et les transforme en objets <b>Article</b> sous forme d'une <b>List<Articles></Articles></b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="refSousFamille"></param>
        /// <returns></returns>
        public static List<Article> GetArticlesByRefSousFamille(SQLiteConnection objetConnection, int refSousFamille)
        {
            List<Article> ListeArticles = new List<Article>();

            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Articles WHERE RefSousFamille = @nom ORDER BY Description";
            SelectCommandObject.Parameters.AddWithValue("@nom", refSousFamille);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                while (Reader.Read())
                {
                    Article Article = new Article();

                    Article.RefArticle = Convert.ToString(Reader["RefArticle"]);
                    Article.Description = Convert.ToString(Reader["Description"]);
                    Article.PrixHT = Convert.ToDecimal(Reader["PrixHT"]);
                    Article.Quantite = Convert.ToInt32(Reader["Quantite"]);

                    Article.SousFamilleArticle = SousFamilleDAO.GetSousFamillesByRef(objetConnection, Convert.ToInt32(Reader["RefSousFamille"]));
                    Article.MarqueArticle = MarqueDAO.GetMarqueByRef(objetConnection, Convert.ToInt32(Reader["RefMarque"]));

                    ListeArticles.Add(Article);
                }

                return ListeArticles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Récupère un article précis dans la BDD en fonction de sa référence et le transforme en objet <b>Article</b>
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public static Article GetArticleByRef(SQLiteConnection objetConnection, string Ref)
        {
            SQLiteCommand SelectCommandObject = new SQLiteCommand();
            SelectCommandObject.Connection = objetConnection;
            SelectCommandObject.CommandText = "SELECT * FROM Articles WHERE RefArticle = @ref ORDER BY Description";
            SelectCommandObject.Parameters.AddWithValue("@ref", Ref);

            try
            {
                SQLiteDataReader Reader = SelectCommandObject.ExecuteReader();
                if (Reader.Read())
                {
                    Article Article = new Article();

                    Article.RefArticle = Convert.ToString(Reader["RefArticle"]);
                    Article.Description = Convert.ToString(Reader["Description"]);
                    Article.PrixHT = Convert.ToDecimal(Reader["PrixHT"]);
                    Article.Quantite = Convert.ToInt32(Reader["Quantite"]);

                    Article.SousFamilleArticle = SousFamilleDAO.GetSousFamillesByRef(objetConnection, Convert.ToInt32(Reader["RefSousFamille"]));
                    Article.MarqueArticle = MarqueDAO.GetMarqueByRef(objetConnection, Convert.ToInt32(Reader["RefMarque"]));

                    return Article;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ajout d'un article dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="article"></param>
        public static void AjouterArticle(SQLiteConnection objetConnection, Article article)
        {
            SQLiteCommand insertCommand = new SQLiteCommand();
            insertCommand.Connection = objetConnection;
            insertCommand.CommandText = "INSERT INTO Articles(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES(@Entry1, @Entry2, @Entry3, @Entry4, @Entry5, @Entry6)";
            insertCommand.Parameters.AddWithValue("@Entry1", article.RefArticle);
            insertCommand.Parameters.AddWithValue("@Entry2", article.Description);
            insertCommand.Parameters.AddWithValue("@Entry3", article.SousFamilleArticle.RefSousFamille);
            insertCommand.Parameters.AddWithValue("@Entry4", article.MarqueArticle.RefMarque);
            insertCommand.Parameters.AddWithValue("@Entry5", article.PrixHT);
            insertCommand.Parameters.AddWithValue("@Entry6", 1);
            try
            {
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Modification d'un article dans la BDD
        /// METHODE 2
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="article"></param>
        public static void UpdateArticle(SQLiteConnection objetConnection, Article article)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            UpdateCommand.CommandText = "UPDATE Articles SET Description = @Entry1, RefSousFamille = @Entry2, RefMarque = @Entry3, PrixHT = @Entry4, Quantite = @Entry5 WHERE RefArticle == @Entry6";
            UpdateCommand.Parameters.AddWithValue("@Entry1", article.Description);
            UpdateCommand.Parameters.AddWithValue("@Entry2", article.SousFamilleArticle.RefSousFamille);
            UpdateCommand.Parameters.AddWithValue("@Entry3", article.MarqueArticle.RefMarque);
            UpdateCommand.Parameters.AddWithValue("@Entry4", article.PrixHT);
            UpdateCommand.Parameters.AddWithValue("@Entry5", article.Quantite);
            UpdateCommand.Parameters.AddWithValue("@Entry6", article.RefArticle);

            try
            {
                UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Modification d'un article dans la BDD
        /// METHODE 1
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="article"></param>
        public static void UpdateArticle(SQLiteConnection objetConnection, Article articlePre, Article article)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            if (articlePre.Description != article.Description)
            {
                UpdateCommand.CommandText = "UPDATE Articles SET Description = @Entry1 WHERE RefArticle == @Entry2";
                UpdateCommand.Parameters.AddWithValue("@Entry1", article.Description);
                UpdateCommand.Parameters.AddWithValue("@Entry2", articlePre.RefArticle);
                try
                {
                    UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (articlePre.SousFamilleArticle.Famille.Nom != article.SousFamilleArticle.Famille.Nom)
            {
                UpdateCommand.CommandText = "UPDATE Articles SET RefSousFamille = @Entry1 WHERE RefArticle == @Entry2";
                UpdateCommand.Parameters.AddWithValue("@Entry1", article.SousFamilleArticle.RefSousFamille);
                UpdateCommand.Parameters.AddWithValue("@Entry2", articlePre.RefArticle);
                try
                {
                    UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (articlePre.MarqueArticle.NomMarque != article.MarqueArticle.NomMarque)
            {
                UpdateCommand.CommandText = "UPDATE Articles SET RefMarque = @Entry1 WHERE RefArticle == @Entry2";
                UpdateCommand.Parameters.AddWithValue("@Entry1", article.MarqueArticle.RefMarque);
                UpdateCommand.Parameters.AddWithValue("@Entry2", articlePre.RefArticle);
                try
                {
                    UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (articlePre.PrixHT != article.PrixHT)
            {
                UpdateCommand.CommandText = "UPDATE Articles SET PrixHT = @Entry1 WHERE RefArticle == @Entry2";
                UpdateCommand.Parameters.AddWithValue("@Entry1", article.PrixHT);
                UpdateCommand.Parameters.AddWithValue("@Entry2", articlePre.RefArticle);
                UpdateCommand.ExecuteNonQuery();

            }
            if (articlePre.Quantite != article.Quantite)
            {
                UpdateCommand.CommandText = "UPDATE Articles SET Quantite = @Entry1 WHERE RefArticle == @Entry2";
                UpdateCommand.Parameters.AddWithValue("@Entry1", article.Quantite);
                UpdateCommand.Parameters.AddWithValue("@Entry2", articlePre.RefArticle);
                try
                {
                    UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        /// <summary>
        /// Suppression d'un article dans la BDD
        /// </summary>
        /// <param name="objetConnection"></param>
        /// <param name="article"></param>
        public static void SupprimerArticle(SQLiteConnection objetConnection, Article article)
        {
            SQLiteCommand UpdateCommand = new SQLiteCommand();
            UpdateCommand.Connection = objetConnection;

            UpdateCommand.CommandText = "DELETE FROM Articles WHERE RefArticle == @Entry6";
            UpdateCommand.Parameters.AddWithValue("@Entry6", article.RefArticle);

            try
            {
                UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
