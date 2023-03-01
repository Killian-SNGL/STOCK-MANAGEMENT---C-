using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Modeles
{
    public class Marque
    {
        public int RefMarque { get; set; } //INT AUTO INCREMENT NOT NULL
        public string NomMarque { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Marque</b>
        /// </summary>
        /// <param name="nom_marque"></param>
        public Marque(string nom_marque)
        {
            this.NomMarque = nom_marque;
        }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>Marque</b>
        /// </summary>
        public Marque()
        {
        }
    }
}
