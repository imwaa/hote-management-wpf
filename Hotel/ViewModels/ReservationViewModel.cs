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
using System.IO;
using System.Windows.Documents;
using System.Windows.Media;
using Hotel.Views;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

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
            reservationData = new Reservation_wpf();
            ReservationData.Reservation_Date = DateTime.Now;
            ReservationData.Fin_Reservation_Date = DateTime.Now;
            clientData = new Client_wpf();
            chambreData = new Chambre_wpf();
            //Clear();
            client_Service = new Client_Service();
            reservation_Service = new Reservation_Service();
            
            Detail_Reservation_Data = new Detail_Reservation_wpf();
            chambre_Service = new Chambre_Service();
            clientSelectionner = new Client_wpf();
            TypesDeChambre = new List<string> { "simple", "double", "triple", "suite" };
            TypesDeService = new List<string> { "Petit-Dej", "All-Inclusive", "SPA", "Petit-Dej+SPA", "All-Inclusive+SPA" };



            RecupererClients();
            /// Commandes
            ajouterCommande = new RelayCommand(Ajouter);

        }
        #region Proprietes

        private Reservation_wpf reservationData;
        public Reservation_wpf ReservationData
        {
            get { return reservationData; }
            set { reservationData = value; onPropertyChanged("ReservationData"); }
        }

        private Detail_Reservation_wpf detail_Reservation_Data;

        public Detail_Reservation_wpf Detail_Reservation_Data
        {
            get { return detail_Reservation_Data; }
            set { detail_Reservation_Data = value; onPropertyChanged("Detail_Reservation_Data"); }
        }


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

        private List<string> typesDeService;
        public List<string> TypesDeService
        {
            get { return typesDeService; }
            set { typesDeService = value; onPropertyChanged("TypesDeService"); }
        }

        private string serviceSelectionner;
                
        public string ServiceSelectionner
        {
            get { return serviceSelectionner; }
            set { serviceSelectionner = value; onPropertyChanged("ServiceSelectionner"); }
        }

        private int quantiteService;
        public int QuantiteService
        {
            get { return quantiteService; }
            set { quantiteService = value; onPropertyChanged("QuantiteService"); }
        }


        private int quantiteTotalPayer;
        public int QuantiteTotalPayer
        {
            get { return quantiteTotalPayer; }
            set { quantiteTotalPayer = value; onPropertyChanged("QuantiteTotalPayer"); }
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

        #region Recuperation et Remplissage du formulaire avec les numero de chambre en fonction du Type de chambre
        private List<string> listeDeNumeroDeChambres;

        public List<string> ListeDeNumeroDeChambres
        {
            get { return listeDeNumeroDeChambres; }
            set { listeDeNumeroDeChambres = value; onPropertyChanged("ListeDeNumeroDeChambres"); }
        }

        public void RecupererNumerosDesChambres()
        {
            ListeDeNumeroDeChambres = reservation_Service.RecupererNumeroDesChambres(Type_Chambre_Selectionner);
        }

        #endregion

        #region Remplissage du formulaire apartir de la Datagrid

        public void RemplissageDuFormDg()
        {
            ClientData = Mapping.Map(ClientSelectionner, ClientData);
        }

        #endregion

        #region Remplissage du prix dans l'interface en fonction du type de chambre selectionner
        private int prixChambre;
        public int PrixChambre
        {
            get { return prixChambre; }
            set { prixChambre = value; onPropertyChanged("PrixChambre"); }
        }

        public void AffichagePrixChambre()
        {
            switch (Type_Chambre_Selectionner)
            {
                case "simple":
                    PrixChambre = 79;
                    QuantiteTotalPayer = PrixChambre + quantiteService;
                    break;

                case "double":
                    PrixChambre = 110;
                    QuantiteTotalPayer = PrixChambre + quantiteService;
                    break;

                case "triple":
                    PrixChambre = 145;
                    QuantiteTotalPayer = PrixChambre + quantiteService;
                    break;

                case "suite":
                    PrixChambre = 250;
                    QuantiteTotalPayer = PrixChambre + quantiteService;
                    break;

                default:
                    break;

            }
            
        }



        #endregion

        #region Recuperation de l'id de la chambre en fonction du num de chambre chosi
        
        private string numeroChambre;
        public string NumeroChambre
        {
            get { return numeroChambre; }
            set { numeroChambre = value; onPropertyChanged("NumeroChambre"); }
        }

        public void RecuperererIdChambre()
        {
            chambreData.Chambre_ID = reservation_Service.RecuperationIdChambre(NumeroChambre);
        }


        #endregion

        #region Recuperation de l'ID et du prix du service choisi

        private decimal servicePrix;
        public decimal ServicePrix
        {
            get { return servicePrix; }
            set { servicePrix = value; onPropertyChanged("ServicePrix"); }
        }

        private int serviceID;
        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; onPropertyChanged("ServiceID"); }
        }

        public void RecuperationIdPrixService()
        {
            List<string> tmp = new List<string>();
            tmp = reservation_Service.RecuperationIdPrixService(ServiceSelectionner);

            ServicePrix = decimal.Parse(tmp[1]);
            ServiceID = int.Parse(tmp[0]);
            QuantiteTotalPayer = (int)(PrixChambre + servicePrix);


        }
        #endregion

        #region Ajouter reservation

        private RelayCommand ajouterCommande;

        public RelayCommand AjouterCommande
        {
            get { return ajouterCommande; }
            set { ajouterCommande = value; }
        }

        public void Ajouter()
        {
            try
            {
                /// reservation
                ReservationData.Client_ID = ClientData.Client_ID;
                ReservationData.Chambre_ID = ChambreData.Chambre_ID;

                int reservation_id = reservation_Service.AjouterReservation(ReservationData);
                if(reservation_id == 0)
                {
                    MessageBox.Show("La reservation n'a pas été ajouté", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    /// ocupation chambre
                    ChambreData.Chambre_Ocupation = "occupée";
                    chambre_Service.changerOcupationChambre(ChambreData,"ocupée");

                    ///detail_reservation
                    Detail_Reservation_Data.Service_ID = ServiceID;
                    Detail_Reservation_Data.Reservation_ID = reservation_id;
                    Detail_Reservation_Data.DR_Prix = QuantiteTotalPayer;
                    Detail_Reservation_Data.DR_Quantite = QuantiteService;

                    reservation_Service.Ajouter_Detail_Reservation(Detail_Reservation_Data);

                    MessageBox.Show("Reservation ajoutée avec success", "Succées", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    GenererFacture();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); ;
                throw;
            }

        }

        #endregion


        #region Ajouter Facture

        public void GenererFacture()
        {
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph(new Run("DarkBlue HOTEL"));
            p.FontSize = 20;
            p.TextAlignment = TextAlignment.Left;
            p.Foreground = Brushes.DarkBlue;
            fd.Blocks.Add(p);

             p = new Paragraph(new Bold(new Run("FACTURE")));
            p.FontSize = 18;
            p.TextAlignment = TextAlignment.Center;
            p.FontStyle = FontStyles.Italic;
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("         "+ClientData.Nom + " " + ClientData.Prenom));
            p.FontSize = 17;
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("         Type de Chambre: " + Type_Chambre_Selectionner + " " + NumeroChambre));
            p.FontSize = 13;
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("         Type de Service: " + serviceSelectionner));
            p.FontSize = 13;
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("          Prix Totale: " + QuantiteTotalPayer+" €"));
            p.FontSize = 15;
            fd.Blocks.Add(p);

            FileStream fs = new FileStream(@"D:\Facture"+ClientData.Nom+".rtf", FileMode.Create);

            fs.Close();
            

            string filename = "D:\\Facture" + ClientData.Nom + ".rtf";
            EnvoyerMail(filename);

            FactureReservation facture = new FactureReservation(fd,filename,ClientData.Mail);

            facture.ShowDialog();
            


        }


        #endregion

        #region Methode qui permet d'envoyer par mail la facture generee
        public void EnvoyerMail(string cheminAccessFichier)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.office365.com");
            mail.From = new MailAddress("walid.salhibelkacem@student.hel.be");
            mail.To.Add(ClientData.Mail);
            mail.Subject = "Facture DarkBlue Hotel";
            mail.Body = "Merci d'avoir reservé chez DarkBlue Hotel, vous trouverez la facture en piece jointe";
            mail.Attachments.Add(new Attachment(cheminAccessFichier));


            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("walid.salhibelkacem@student.hel.be", "Lidwa17893");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Mail envoyé avec succés");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        #endregion

    }
}
