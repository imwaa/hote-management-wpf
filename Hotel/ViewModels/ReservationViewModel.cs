using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Hotel.Models;
using Hotel.Helpers;
using Hotel.Commands;
using System.Collections.ObjectModel;
using Projet_Hotel_Management_.Classes;
using System.Windows;

namespace Hotel.ViewModels
{
    class ReservationViewModel : INotifyPropertyChanged
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

        #region Services
        Client_Service client_Service;
        Chambre_Service chambre_Service;
        Reservation_Service reservation_Service;

        #endregion

        public ReservationViewModel()
        {
            clientData = new Client_wpf();
            //Clear();
            client_Service = new Client_Service();
            clientSelectionner = new Client_wpf();
            TypesDeChambre = new List<string> { "simple", "double", "triple", "suite" };
            RecupererClients();
            /// Commandes
            //ajouterCommande = new RelayCommand(Ajouter);

        }
        #region Proprietes

        private Client_wpf clientData;
        public Client_wpf ClientData
        {
            get { return clientData; }
            set { clientData = value; onPropertyChanged("ClientData"); }
        }

        private Chambre_wpf chambreData;
        public Chambre_wpf ChambreData
        {
            get { return chambreData; }
            set { chambreData = value; onPropertyChanged("ChambreData"); }
        }

        private Client_wpf clientSelectionner;
        public Client_wpf ClientSelectionner
        {
            get { return clientSelectionner; }
            set { clientSelectionner = value; onPropertyChanged("ClientSelectionner"); }
        }


        private string type_Chambre_Selectionner;
        public string Type_Chambre_Selectionner
        {
            get { return type_Chambre_Selectionner; }
            set { type_Chambre_Selectionner = value; onPropertyChanged("Type_Chambre_Selectionner"); }
        }

        private List<string> typesDeChambre;
        public List<string> TypesDeChambre
        {
            get {return typesDeChambre; }
            set { typesDeChambre = value; onPropertyChanged("TypesDeChambre"); }
        }

        private int prixChambre;

        public int PrixChambre
        {
            get { return prixChambre; }
            set { prixChambre = value; onPropertyChanged("PrixChambre"); }
        }





        #endregion

        #region Recuperation des clients depuis la BD

        private ObservableCollection<Client_wpf> listeDeClients;

        public ObservableCollection<Client_wpf> ListeDeClients
        {
            get { return listeDeClients; }
            set { listeDeClients = value; onPropertyChanged("ListeDeClients"); }
        }

        public void RecupererClients()
        {
            ListeDeClients = new ObservableCollection<Client_wpf>(client_Service.RecupererClients());
        }

        #endregion


        #region Remplissage du formulaire apartir de la Datagrid

        public void RemplissageDuFormDg()
        {
            ClientData = Mapping.Map(ClientSelectionner, ClientData);
        }

        #endregion

        #region Remplissage du prix dans l'interface en fonction du type de chambre selectionner

        public void AffichagePrixChambre()
        {
            switch (Type_Chambre_Selectionner)
            {
                case "simple":
                    PrixChambre = 79;
                    break;

                case "double":
                    PrixChambre = 110;
                    break;

                case "triple":
                    PrixChambre = 145;
                    break;

                case "suite":
                    PrixChambre = 250;
                    break;

                default:
                    break;

            }
            
        }



        #endregion
    }
}
