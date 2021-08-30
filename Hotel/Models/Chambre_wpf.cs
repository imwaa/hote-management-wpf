using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Hotel.Models
{
    class Chambre_wpf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private int chambre_ID;
        public int Chambre_ID
        {
            get { return chambre_ID; }
            set { chambre_ID = value; OnPropertyChanged("Chambre_ID"); }
        }



        private string chambre_Type;
        public string Chambre_Type
        {
            get { return chambre_Type; }
            set { chambre_Type = value; OnPropertyChanged("Chambre_Type"); }
        }



        private string chambre_Num;
        public string Chambre_Num
        {
            get { return chambre_Num; }
            set { chambre_Num = value; OnPropertyChanged("Chambre_Num"); }
        }



        private string chambre_Ocupation;
        public string Chambre_Ocupation
        {
            get { return chambre_Ocupation; }
            set { chambre_Ocupation = value; OnPropertyChanged("Chambre_Ocupation"); }
        }


        private decimal chambre_Prix;
        public decimal Chambre_Prix
        {
            get { return chambre_Prix; }
            set { chambre_Prix = value; OnPropertyChanged("Chambre_Prix"); }
        }

    }
}
