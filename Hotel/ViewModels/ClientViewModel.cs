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
    public class ClientViewModel : INotifyPropertyChanged
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

        public ClientViewModel()
        {
            clientData = new Client_wpf();
            Clear();
            client_Service = new Client_Service();
            clientSelectionner = new Client_wpf();
            RecupererClients();

            /// Commandes
            ajouterCommande = new RelayCommand(Ajouter);
            supprimerCommande = new RelayCommand(Supprimer);
            modifierChambre = new RelayCommand(Modifier);
        }

        private Client_wpf clientData;
        public Client_wpf ClientData 
        {
            get { return clientData; }
            set { clientData = value; onPropertyChanged("ClientData"); }
        }

        private Client_wpf clientSelectionner;
        public Client_wpf ClientSelectionner
        {
            get { return clientSelectionner; }
            set { clientSelectionner = value; onPropertyChanged("ClientSelectionner"); }
        }

        #region Methode qui clear la variable ChambreData
        public void Clear()
        {
            ClientData.Client_ID = 0;
            ClientData.Nom = string.Empty;
            ClientData.Prenom = string.Empty;
            ClientData.Naissance_Date = DateTime.Today;
            ClientData.Mail = string.Empty;
            ClientData.GSM = string.Empty;
            ClientData.Profession = string.Empty;
        }

        #endregion

        #region Remplissage du formulaire apartir de la Datagrid

        public void RemplissageDuFormDg()
        {
            ClientData = Mapping.Map(ClientSelectionner, ClientData);
        }



        #endregion

        #region Recuperation des chambres depuis la BD

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


        #region Ajout des Chambres dans la BD

        private RelayCommand ajouterCommande;
        public RelayCommand AjouterCommande
        {
            get { return ajouterCommande; }
        }

        public void Ajouter()
        {
            try
            {
                C_Clients_ Client2ajouter = new C_Clients_();
                Client2ajouter = Mapping.Map(ClientData, Client2ajouter);

                bool IsSaved = client_Service.Ajouter(Client2ajouter);
                if (IsSaved)
                {
                    RecupererClients();
                    MessageBox.Show("Client Ajouté avec succées", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Le Client n'a pas été ajouté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }



        #endregion

        #region Suppression des Chambres de la BD

        private RelayCommand supprimerCommande;
        public RelayCommand SupprimerCommande
        {
            get { return supprimerCommande; }
        }

        public void Supprimer()
        {
            try
            {
                C_Clients_ Client2supprimer = new C_Clients_();
                Client2supprimer = Mapping.Map(ClientData, Client2supprimer);

                bool IsDeleted = client_Service.Supprimer(Client2supprimer.Client_ID);

                if (IsDeleted)
                {
                    RecupererClients();
                    MessageBox.Show("Client Supprimée avec succées", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Le Client n'a pas été supprimé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }



        #endregion

        #region Modification des Chambres de la BD

        private RelayCommand modifierChambre;

        public RelayCommand ModifierChambre
        {
            get { return modifierChambre; }
        }

        public void Modifier()
        {
            try
            {
                C_Clients_ Client2modifier = new C_Clients_();
                Client2modifier = Mapping.Map(ClientData, Client2modifier);

                bool IsModified = client_Service.Modifier(Client2modifier);

                if (IsModified)
                {
                    RecupererClients();
                    MessageBox.Show("Client Modifiée avec succées", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Le Client n'a pas été Modifiée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        #endregion
    }
}
