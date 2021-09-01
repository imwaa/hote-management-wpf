using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Helpers;
using Hotel.Commands;
using System.Collections.ObjectModel;
using Projet_Hotel_Management_.Classes;
using System.Windows;

namespace Hotel.ViewModels
{
    class CheckoutViewModel : INotifyPropertyChanged
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

        public CheckoutViewModel()
        {
            chambre_Service = new Chambre_Service();
            chambreData = new Chambre_wpf();
            chambreSelectionner = new Chambre_wpf();
            RecupererChambres();

            modifycommand = new RelayCommand(modifierOcupation);

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


        private RelayCommand modifycommand;

        public RelayCommand ModifyCommand
        {
            get { return modifycommand; }
            set { modifycommand = value; onPropertyChanged("ModifyCommand"); }
        }

        public void modifierOcupation()
        {
            chambre_Service.changerOcupationChambre(ChambreData,"disponible");
            MessageBox.Show("Check Out réalisé, la chambre " + ChambreData.Chambre_Num + " est libre");
        }

    }

}
