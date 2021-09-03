using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    class ChambreType_wpf : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int chambre_Type_ID;
        public int Chambre_Type_ID
        {
            get { return chambre_Type_ID; }
            set { chambre_Type_ID = value; OnPropertyChanged("Chambre_Type_ID"); }
        }


        private string type_De_Chambre;
        public string Type_De_Chambre
        {
            get { return type_De_Chambre; }
            set { type_De_Chambre = value; OnPropertyChanged("Type_De_Chambre"); }
        }
    }
}
