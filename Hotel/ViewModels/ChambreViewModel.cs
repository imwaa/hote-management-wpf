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
    class ChambreViewModel : INotifyPropertyChanged
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

        Chambre_Service chambre_Service;

        public ChambreViewModel()
        {
            chambreData = new Chambre_wpf();
            chambre_Service = new Chambre_Service();
            chambreSelectionner = new Chambre_wpf();
            RecupererChambres();
            ChambreData.Chambre_Ocupation = "disponible";

            /// Commandes
            ajouterCommande = new RelayCommand(Ajouter);


        }

        private Chambre_wpf chambreData;
        public Chambre_wpf ChambreData
        {
            get { return chambreData; }
            set { chambreData = value; onPropertyChanged("ChambreData"); }
        }

        private Chambre_wpf chambreSelectionner;
        public Chambre_wpf ChambreSelectionner
        {
            get { return chambreSelectionner; }
            set { chambreSelectionner = value; onPropertyChanged("ChambreSelectionner"); }
        }


        #region Remplissage du formulaire apartir de la Datagrid

        public void RemplissageDuFormDg()
        {
            ChambreData = Mapping.Map(ChambreSelectionner, ChambreData);
        }



        #endregion

        #region Recuperation des chambres depuis la BD

        private ObservableCollection<Chambre_wpf> listeDeChambres;

        public ObservableCollection<Chambre_wpf> ListeDeChambres
        {
            get { return listeDeChambres; }
            set { listeDeChambres = value; onPropertyChanged("ListeDeChambres"); }
        }

        public void RecupererChambres()
        {
            ListeDeChambres = new ObservableCollection<Chambre_wpf>(chambre_Service.RecupererChambres());
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
                C_Chambres_ Chambre2ajouter = new C_Chambres_();
                Chambre2ajouter = Mapping.Map(ChambreData, Chambre2ajouter);

                bool IsSaved = chambre_Service.Ajouter(Chambre2ajouter);
                if (IsSaved)
                {
                    RecupererChambres();
                    MessageBox.Show("Chambre Ajoutée avec succées","Succées",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("La chambre n'a pas été ajoutée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }



        #endregion


    }
}
