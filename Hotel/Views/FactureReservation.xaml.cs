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
        public FactureReservation(FlowDocument facture_gen,string cheminAccessFichier, string Mail)
        {
            InitializeComponent();
            mail2envoyer = Mail;
            document2envoyer = facture_gen;
            cheminAcces = cheminAccessFichier;


            //MailMessage mail = new MailMessage();
            //SmtpClient smtp = new SmtpClient("smtp.office365.com");
            //mail.From = new MailAddress("walid.salhibelkacem@student.hel.be");
            //mail.To.Add(mail2envoyer);
            //mail.Subject = "Facture DarkBlue Hotel";
            //mail.Body = "Merci d'avoir reservé chez DarkBlue Hotel, vous trouverez la facture en piece jointe";
            //mail.Attachments.Add(new Attachment(cheminAcces));


            //smtp.Port = 587;
            //smtp.Credentials = new NetworkCredential("walid.salhibelkacem@student.hel.be", "Lidwa17893");
            //smtp.EnableSsl = true;
            //try
            //{
            //    smtp.Send(mail);
            //    MessageBox.Show("Mail envoyé avec succés");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}


            facture_doc.Document = facture_gen;

            //TextRange tr = new TextRange(facture_doc.Document.ContentStart, facture_doc.Document.ContentEnd);
            //tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void isclicked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
