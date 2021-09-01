using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projet_Hotel_Management_.Gestion;
using Projet_Hotel_Management_.Classes;
using Hotel.Helpers;

namespace Hotel.Models
{
    class Reservation_Service
    {

        G_Clients_ g_clients = new G_Clients_();
        G_Chambres_ g_chambres = new G_Chambres_();
        G_Reservation_ g_reservation = new G_Reservation_();
        G_Detail_Reservation_ g_Detail_Reservation_ = new G_Detail_Reservation_();



        /// <summary>
        /// Methode permettant de recuperer tous les clients de la BD
        /// </summary>
        /// 
        public List<Client_wpf> RecupererClients()
        {
            try
            {
                var clientsRecup = new List<C_Clients_>(g_clients.Lire(""));
                List<Client_wpf> ObjListeClients = new List<Client_wpf>();

                foreach (C_Clients_ clientRecup in clientsRecup)
                {
                    Client_wpf client2mapper = new Client_wpf();
                    client2mapper = Mapping.Map(clientRecup, client2mapper);

                    ObjListeClients.Add(client2mapper);
                }

                return ObjListeClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public List<string> RecupererNumeroDesChambres(string typeChambre)
        {
            try
            {
                return g_chambres.Chercher_Chambre_Num(typeChambre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public int RecuperationIdChambre(string chambreNum)
        {
            try
            {
                return g_chambres.Chercher_Chambre_ID(chambreNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        public List<string> RecuperationIdPrixService(string serviceType)
        {
            try
            {
                return g_Detail_Reservation_.Chercher_Service_ID(serviceType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }


        public int AjouterReservation(Reservation_wpf reservation2ajouter)
        {
            try
            {
                C_Reservation_ c_Reservation_ = new C_Reservation_();
                c_Reservation_ = Mapping.Map(reservation2ajouter, c_Reservation_);

                return g_reservation.Ajouter(c_Reservation_.Client_ID, c_Reservation_.Chambre_ID, c_Reservation_.Reservation_Date, c_Reservation_.Fin_Reservation_Date);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        public void Ajouter_Detail_Reservation(Detail_Reservation_wpf detailReservation2ajouter)
        {
            try
            {
                g_Detail_Reservation_.Ajouter(detailReservation2ajouter.Service_ID, detailReservation2ajouter.Reservation_ID, detailReservation2ajouter.DR_Prix, detailReservation2ajouter.DR_Quantite);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
