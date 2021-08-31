using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Hotel.Models
{
    public class Client_wpf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        private int client_ID;
        public int Client_ID
        {
            get { return client_ID; }
            set { client_ID = value; OnPropertyChanged("Client_ID"); }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }


        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; OnPropertyChanged("Prenom"); }
        }



        private string adresse;
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; OnPropertyChanged("Adresse"); }
        }


        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; OnPropertyChanged("Mail"); }
        }


        private string gSM;
        public string GSM
        {
            get { return gSM; }
            set { gSM = value; OnPropertyChanged("GSM"); }
        }



    }
}
