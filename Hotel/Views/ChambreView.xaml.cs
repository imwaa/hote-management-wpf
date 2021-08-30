using Hotel.Models;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.Views
{
    /// <summary>
    /// Logique d'interaction pour ChambreView.xaml
    /// </summary>
    public partial class ChambreView : UserControl
    {
        ChambreViewModel chambreViewModel = new ChambreViewModel();


        public ChambreView()
        {
            DataContext = chambreViewModel;
            InitializeComponent();
        }


        /// <summary>
        /// Recupere la valeur de l'item selectionner dans la Datagrid et l'envoi via une
        /// methode du ViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(dg_Chambre.SelectedIndex >=0)
            {
                chambreViewModel.RemplissageDuFormDg();
            }

        }
    }
}
