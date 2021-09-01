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
    /// Logique d'interaction pour CheckOut.xaml
    /// </summary>
    public partial class CheckOut : UserControl
    {
        CheckoutViewModel checkoutViewModel = new CheckoutViewModel();

        public CheckOut()
        {
            DataContext = checkoutViewModel;

            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Chambre.SelectedIndex >= 0)
            {
                checkoutViewModel.RemplissageDuFormDg();
            }
        }
    }
}
