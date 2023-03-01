using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Modeles
{
    public class Donnees
    {
       public List<Article> ListeArticles { get; set; }
       public List<Famille> ListeFamilles { get; set; }
       public List<Marque> ListeMarques { get; set; }
       public List<SousFamille> ListSousFamilles { get; set; }

       /// <summary>
       /// Initialise une nouvelle instance de l'objet <b>Donnees</b>
       /// </summary>
       public Donnees()
       {
           ListeArticles = new List<Article>(); //stocke tous les articles qu'il faudra ajouter en BDD
           ListeFamilles = new List<Famille>(); //stocke toutes les familles  qu'il faudra ajouter en BDD
           ListeMarques = new List<Marque>(); //stocke toutes les marques qu'il faudra ajouter en BDD
           ListSousFamilles = new List<SousFamille>(); //stocke toutes les sous familles qu'il faudra ajouter en BDD
       }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Donnees</b> avec des paramètrees
        /// </summary>
        /// <param name="listeArticles"></param>
        /// <param name="listeFamilles"></param>
        /// <param name="listeMarques"></param>
        /// <param name="listSousFamilles"></param>
        public Donnees(List<Article> listeArticles, List<Famille> listeFamilles, List<Marque> listeMarques, List<SousFamille> listSousFamilles)
        {
           ListeArticles = listeArticles ?? throw new ArgumentNullException(nameof(listeArticles));
           ListeFamilles = listeFamilles ?? throw new ArgumentNullException(nameof(listeFamilles));
           ListeMarques = listeMarques ?? throw new ArgumentNullException(nameof(listeMarques));
           ListSousFamilles = listSousFamilles ?? throw new ArgumentNullException(nameof(listSousFamilles));
        }

    }
}
