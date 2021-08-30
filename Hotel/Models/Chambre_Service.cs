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
        /// Methode permettant d'ajouter une chambre a la BD
        /// </summary>
        /// <param name="Chambre2ajouter"></param>
        /// <returns></returns>
        public bool Ajouter( C_Chambres_ Chambre2ajouter)
        {
            try
            {
                int res = g_chambres.Ajouter(Chambre2ajouter.Chambre_Type,Chambre2ajouter.Chambre_Num,Chambre2ajouter.Chambre_Ocupation,Chambre2ajouter.Chambre_Prix);

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
    }
}
