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
    class Client_Service
    {
        G_Clients_ g_clients = new G_Clients_();

        /// <summary>
        /// Methode permettant d'appeler la methode qui ajoute un client a la BD
        /// </summary>
        /// <param name="Client2ajouter"></param>
        /// <returns></returns>
        public bool Ajouter(C_Clients_ Client2ajouter)
        {
            try
            {
                int res = g_clients.Ajouter(Client2ajouter.Nom,Client2ajouter.Prenom,Client2ajouter.Naissance_Date,Client2ajouter.Adresse,Client2ajouter.Mail,Client2ajouter.GSM,Client2ajouter.Profession);

                if (res != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }


        /// <summary>
        /// Methode permettant d'appeler la methode qui supprimer le client de la BD
        /// </summary>
        /// <param name="Client_ID"></param>
        /// <returns></returns>
        public bool Supprimer(int Client_ID)
        {
            try
            {
                int res = g_clients.Supprimer(Client_ID);
                if (res != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Methode permettant d'appeler la methode qui modifier le client de la BD
        /// </summary>
        /// <param name="Client2modifier"></param>
        /// <returns></returns>
        public bool Modifier(C_Clients_ Client2modifier)
        {
            try
            {
                int res = g_clients.Modifier(Client2modifier.Client_ID, Client2modifier.Nom, Client2modifier.Prenom, Client2modifier.Naissance_Date, Client2modifier.Adresse, Client2modifier.Mail, Client2modifier.GSM, Client2modifier.Profession);
                if (res == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }


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

    }
}
