using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Modeles
{
    public class Article
    {
        public string RefArticle { get;  set; }   
        public string Description { get;  set; }
        public SousFamille SousFamilleArticle { get;  set; }
        public Marque MarqueArticle { get;  set; }
        public decimal PrixHT { get;  set; }
        public int Quantite { get;  set; }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Article</b>
        /// </summary>
        public Article()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Article</b> avec des paramètres 
        /// </summary>
        /// <param name="ref_article"></param>
        /// <param name="description_article"></param>
        /// <param name="sous_famille_article"></param>
        /// <param name="marque_article"></param>
        /// <param name="prix"></param>
        /// <param name="quantite"></param>
        public Article(string ref_article, string description_article, SousFamille sous_famille_article, Marque marque_article, decimal prix, int quantite)
        {
            RefArticle = ref_article;
            Description = description_article;
            SousFamilleArticle = sous_famille_article;
            MarqueArticle = marque_article;
            PrixHT = prix;
            Quantite = quantite;
        }
    }
}
