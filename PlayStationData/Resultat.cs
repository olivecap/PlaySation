using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class Resultat
    {
        //Fields
        #region Fields

        //But joueur domicile
        int _butJoueurDomicile;

        public int ButJoueurDomicile
        {
            get { return _butJoueurDomicile; }
            set { _butJoueurDomicile = value; }
        }

        //But joueur exterieur
        int _butJoueurExterieur;

        public int ButJoueurExterieur
        {
            get { return _butJoueurExterieur; }
            set { _butJoueurExterieur = value; }
        }

        #endregion Fields
    }
}
