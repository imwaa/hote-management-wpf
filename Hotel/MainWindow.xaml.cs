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

namespace Hotel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChambreViewModel chambreViewModel;
        public MainWindow()
        {
            chambreViewModel = new ChambreViewModel();
            this.DataContext = chambreViewModel;
            InitializeComponent();
        }

        private void ChambreView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ChambreViewModel();
        }

        private void ClientsView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientViewModel();

        }

        private void ReservationView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ReservationViewModel();
        }

        private void CheckoutView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CheckoutViewModel();

        }

        private void MailView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MailPublicitaireViewModel();
        }
    }
}
