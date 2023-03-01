using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hector
{
    public class ListViewColumnSorter : IComparer
    {
        public int ColumnToSort { get; set; }

        public SortOrder OrderOfSort { get; set; }

        public CaseInsensitiveComparer ObjectCompare { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de l'objet <b>ListViewColumnSorter</b>
        /// </summary>
        public ListViewColumnSorter()
        {
            ColumnToSort = 0;

            OrderOfSort = SortOrder.None;

            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Méthode comparaison de deux éléments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int ResultatComparaison;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            ResultatComparaison = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            if (OrderOfSort == SortOrder.Ascending)
            {
                return ResultatComparaison;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-ResultatComparaison);
            }
            else
            {
                return 0;
            }
        }

    }
}
