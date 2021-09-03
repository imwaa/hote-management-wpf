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
    class Chambre_Service
    {
        G_Chambres_ g_chambres = new G_Chambres_();


        /// <summary>
        /// Methode permettant d'appeler la methode qui ajoute une chambre a la BD
        /// </summary>
        /// <param name="Chambre2ajouter"></param>
        /// <returns></returns>
        public bool Ajouter( C_Chambres_ Chambre2ajouter)
        {
            try
            {
                int res = g_chambres.Ajouter(Chambre2ajouter.Chambre_Type,Chambre2ajouter.Chambre_Num,Chambre2ajouter.Chambre_Ocupation,Chambre2ajouter.Chambre_Prix,Chambre2ajouter.Chambre_Type_ID);

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
        /// Methode permettant d'appeler la methode qui supprimer la chambre de la BD
        /// </summary>
        /// <param name="Chambre_ID"></param>
        /// <returns></returns>
        public bool Supprimer(int Chambre_ID)
        {
            try
            {
                int res = g_chambres.Supprimer(Chambre_ID);
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
        /// Methode permettant d'appeler la methode qui modifier la chambre de la BD
        /// </summary>
        /// <param name="Chambre2modifier"></param>
        /// <returns></returns>
        public bool Modifier(C_Chambres_ Chambre2modifier)
        {
            try
            {
                int res = g_chambres.Modifier(Chambre2modifier.Chambre_ID, Chambre2modifier.Chambre_Type, Chambre2modifier.Chambre_Num, Chambre2modifier.Chambre_Ocupation, Chambre2modifier.Chambre_Prix,Chambre2modifier.Chambre_Type_ID);
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
        /// Methode permettant de recuperer tous les chambres de la BD
        /// </summary>
        /// 
        //List<Chambre_wpf> ObjListeChambres;
        public List<Chambre_wpf> RecupererChambres()
        {
            try
            {
                var chambresRecup = new List<C_Chambres_>(g_chambres.Lire(""));
                //ObjListeChambres = new List<Chambre_wpf>(Mapping.Map(chambresRecup, ObjListeChambres));
                List<Chambre_wpf> ObjListeChambres = new List<Chambre_wpf>();

                foreach (C_Chambres_ chambresrecup in chambresRecup)
                {
                    Chambre_wpf chambre2mapper = new Chambre_wpf();
                    chambre2mapper= Mapping.Map(chambresrecup, chambre2mapper);

                    ObjListeChambres.Add(chambre2mapper);
                }

                return ObjListeChambres;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        public void changerOcupationChambre(Chambre_wpf chambre2changer,string ocupation)
        {
            try
            {
                int res = g_chambres.ModifierOcupation(chambre2changer.Chambre_ID, ocupation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }



        public List<C_TypeChambre_> recupererTypeChambre()
        {
            try
            {

                return g_chambres.LireTypeChambre("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
