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
            ChambreTypeObjet = new List<C_TypeChambre_>();
            ListeTypeDeChambre = new List<string>();

            RecupererChambres();
            recupererTypeChambre();
            ChambreData.Chambre_Ocupation = "disponible";

            /// Commandes
            ajouterCommande = new RelayCommand(Ajouter);
            supprimerCommande = new RelayCommand(Supprimer);
            modifierChambre = new RelayCommand(Modifier);


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

        private ChambreType_wpf chambreTypeData;
        public ChambreType_wpf ChambreTypeData
        {
            get { return chambreTypeData; }
            set { chambreTypeData = value; onPropertyChanged("ChambreSelectionner"); }
        }

        #region Methode qui clear la variable ChambreData
        public void Clear()
        {
            ChambreData.Chambre_ID = 0;
            ChambreData.Chambre_Num = string.Empty;
            ChambreData.Chambre_Ocupation = "Disponible";
            ChambreData.Chambre_Type = string.Empty;
            ChambreData.Chambre_Prix = 0;
        }

        #endregion

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
                    Clear();
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
                C_Chambres_ Chambre2supprimer = new C_Chambres_();
                Chambre2supprimer = Mapping.Map(ChambreData, Chambre2supprimer);

                bool IsDeleted = chambre_Service.Supprimer(Chambre2supprimer.Chambre_ID);

                if (IsDeleted)
                {
                    RecupererChambres();
                    MessageBox.Show("Chambre Supprimée avec succées", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Clear();
                }
                else
                {
                    MessageBox.Show("La chambre n'a pas été supprimée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

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
                C_Chambres_ Chambre2modifier = new C_Chambres_();
                Chambre2modifier = Mapping.Map(ChambreData, Chambre2modifier);

                bool IsModified = chambre_Service.Modifier(Chambre2modifier);

                if (IsModified)
                {
                    RecupererChambres();
                    MessageBox.Show("Chambre Modifiée avec succées", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Clear();
                }
                else
                {
                    MessageBox.Show("La chambre n'a pas été Modifiée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        #endregion


        #region Methode permettant d'ajouter des chambre Type dans la comboBox

        //private ObservableCollection<ChambreType_wpf> listeTypeDeChambre;

        //public ObservableCollection<ChambreType_wpf> ListeTypeDeChambre
        //{
        //    get { return listeTypeDeChambre; }
        //    set { listeTypeDeChambre = value; onPropertyChanged("ListeTypeDeChambre"); }
        //}

        private List<string> myVlisteTypeDeChambrear;



        public List<string> ListeTypeDeChambre
        {
            get { return myVlisteTypeDeChambrear; }
            set { myVlisteTypeDeChambrear = value; onPropertyChanged("ListeTypeDeChambre"); }
        }

        private string chambreTypeSelectionner;
        public string ChambreTypeSelectionner
        {
            get { return chambreTypeSelectionner; }
            set { chambreTypeSelectionner = value; onPropertyChanged("ChambreTypeSelectionner"); }
        }
        public void recupererIdChambreType()
        {
            foreach (C_TypeChambre_ chambreType in chambreTypeObjet)
            {
                if (chambreType.Type_De_Chambre == ChambreTypeSelectionner)
                {
                    ChambreData.Chambre_Type_ID = chambreType.Chambre_Type_ID;
                    break;
                }
            }
        }



        private List<C_TypeChambre_> chambreTypeObjet;

        public List<C_TypeChambre_> ChambreTypeObjet
        {
            get { return chambreTypeObjet; }
            set { chambreTypeObjet = value; onPropertyChanged("ChambreTypeObjet"); }
        }


        public void recupererTypeChambre()
        {
            chambreTypeObjet = chambre_Service.recupererTypeChambre();

            foreach (C_TypeChambre_ chambreType in chambreTypeObjet)
            {
                //ChambreType_wpf tmp = new ChambreType_wpf();
                //tmp = Mapping.Map(chambreType, tmp);
                ListeTypeDeChambre.Add(chambreType.Type_De_Chambre);
            }
        }

        #endregion

    }
}
