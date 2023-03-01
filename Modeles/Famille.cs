using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Modeles
{
    public class Famille
    {
        public int RefFamille {get; set ; } //INT AUTO INCREMENT NOT NULL
        public String Nom {get; set;}

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Famille</b>
        /// </summary>
        public Famille()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Famille</b>
        /// </summary>
        /// <param name="ref_famille"></param>
        /// <param name="nom"></param>
        public Famille(int ref_famille, String nom)
        {
            RefFamille = ref_famille;
            Nom = nom;
        }
    }
}
