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
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Hotel.Views
{
    /// <summary>
    /// Logique d'interaction pour FactureReservation.xaml
    /// </summary>
    public partial class FactureReservation : Window
    {
        public string mail2envoyer;
        public FlowDocument document2envoyer;
        public string cheminAcces;
        public FactureReservation(FlowDocument facture_gen)
        {
            InitializeComponent();

            facture_doc.Document = facture_gen;

        }
    }
}
