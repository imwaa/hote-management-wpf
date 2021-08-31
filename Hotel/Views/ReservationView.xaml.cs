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
using Hotel.ViewModels;


namespace Hotel.Views
{
    /// <summary>
    /// Logique d'interaction pour ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        ReservationViewModel reservationViewModel = new ReservationViewModel();
        public ReservationView()
        {
            DataContext = reservationViewModel;
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Client.SelectedIndex >= 0)
            {
                reservationViewModel.RemplissageDuFormDg();
            }
        }

        private void TypeChambre_SelectrionChanged(object sender, SelectionChangedEventArgs e)
        {
            reservationViewModel.AffichagePrixChambre();
        }
    }
}
