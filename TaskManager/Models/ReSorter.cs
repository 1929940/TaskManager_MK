using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskManager.Models
{
    //Reapplies sorting critera after an element has been modified or added

    public class ReSorter
    {
        private bool Flag = false;
        private readonly DataGrid DataGrid;
        private SortDescription SortDescription;

        public ReSorter(DataGrid dataGrid)
        {
            DataGrid = dataGrid;
        }

        //Gathers the needed data in order to maintain the set sorting
        public void PrepareToReSort()
        {
            if (DataGrid.Items.SortDescriptions.Count >= 1)
            {
                SortDescription = DataGrid.Items.SortDescriptions[0];
                Flag = true;
            }
        }

        //Reapplies the previously gathered sorting criteria
        public void ReSort()
        {
            if (Flag)
            {
                DataGrid.Items.SortDescriptions.Add(SortDescription);
            }
        }
    }
}
