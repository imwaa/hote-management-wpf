using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Hotel.Models
{
    class Reservation_wpf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int reservation_ID;
        public int Reservation_ID
        {
            get { return reservation_ID; }
            set { reservation_ID = value; OnPropertyChanged("Reservation_ID"); }
        }

        private int client_ID;
        public int Client_ID
        {
            get { return client_ID; }
            set { client_ID = value; OnPropertyChanged("Client_ID"); }
        }

        private int chambre_ID;
        public int Chambre_ID
        {
            get { return chambre_ID; }
            set { chambre_ID = value; OnPropertyChanged("Chambre_ID"); }
        }

        private DateTime reservation_Date;
        public DateTime Reservation_Date
        {
            get { return reservation_Date; }
            set { reservation_Date = value; OnPropertyChanged("Reservation_Date"); }
        }

        private DateTime fin_Reservation_Date;
        public DateTime Fin_Reservation_Date
        {
            get { return fin_Reservation_Date; }
            set { fin_Reservation_Date = value; OnPropertyChanged("Fin_Reservation_Date"); }
        }
    }
}
