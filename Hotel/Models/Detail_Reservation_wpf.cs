using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Hotel.Models
{
    class Detail_Reservation_wpf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int detail_Reservation_ID;
        public int Detail_Reservation_ID
        {
            get { return detail_Reservation_ID; }
            set { detail_Reservation_ID = value; OnPropertyChanged("Detail_Reservation_ID"); }
        }


        private int service_ID;
        public int Service_ID
        {
            get { return service_ID; }
            set { service_ID = value; OnPropertyChanged("Service_ID"); }
        }

        private int reservation_ID;
        public int Reservation_ID
        {
            get { return reservation_ID; }
            set { reservation_ID = value; OnPropertyChanged("Reservation_ID"); }
        }


        private decimal dR_Prix;
        public decimal DR_Prix
        {
            get { return dR_Prix; }
            set { dR_Prix = value; OnPropertyChanged("DR_Prix"); }
        }

        private int dR_Quantite;
        public int DR_Quantite
        {
            get { return dR_Quantite; }
            set { dR_Quantite = value; OnPropertyChanged("DR_Quantite"); }
        }
    }
}
