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
    }
}
