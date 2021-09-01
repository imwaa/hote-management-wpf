using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Hotel.Models;
using Hotel.Commands;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows;

namespace Hotel.ViewModels
{
    class MailPublicitaireViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        Client_Service client_Service;

        public MailPublicitaireViewModel()
        {
            clientData = new Client_wpf();
            client_Service = new Client_Service();

            SendCommand = new RelayCommand(EnvoyerMail);
        }

        private Client_wpf clientData;
        public Client_wpf ClientData
        {
            get { return clientData; }
            set { clientData = value; onPropertyChanged("ClientData"); }
        }

        private string object2send;

        public string Object2send
        {
            get { return object2send; }
            set { object2send = value; onPropertyChanged("Object2send"); }
        }

        private string message2send;

        public string Message2send
        {
            get { return message2send; }
            set { message2send = value; onPropertyChanged("Message2send"); }
        }

        #region commande qui permet d'envoyer un mail a tous les clients

        private RelayCommand sendCommand;

        public RelayCommand SendCommand
        {
            get { return sendCommand; }
            set { sendCommand = value; }
        }

        public void EnvoyerMail()
        {
            List<Client_wpf> listeDeClients = new List<Client_wpf>();

            listeDeClients = client_Service.RecupererClients();

            foreach (Client_wpf client in listeDeClients)
            {
                EnvoyerMail(client.Mail);
            }
        }

        #endregion

        #region Methode qui permet d'envoyer par mail la facture generee
        public void EnvoyerMail(string mail2envoyer)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.office365.com");
            mail.From = new MailAddress("walid.salhibelkacem@student.hel.be");
            mail.To.Add(mail2envoyer);
            mail.Subject = Object2send;
            mail.Body = Message2send;

            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("walid.salhibelkacem@student.hel.be", "Lidwa17893");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Mail envoyé avec succés");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        #endregion
    }
}
