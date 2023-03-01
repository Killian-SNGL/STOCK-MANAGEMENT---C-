using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Modeles
{
    public class SousFamille:Famille
    {
        public int RefSousFamille { get; set;} //INT AUTO INCREMENT NOT NULL
        public Famille Famille { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>SousFamille</b>
        /// </summary>
        public SousFamille()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>SousFamille</b> avec des paramètres 
        /// </summary>
        /// <param name="refSousFamille"></param>
        /// <param name="famille"></param>
        public SousFamille(int refSousFamille, Famille famille)
        {
            RefSousFamille = refSousFamille;
            Famille = famille ?? throw new ArgumentNullException(nameof(famille));
        }
    }
}
