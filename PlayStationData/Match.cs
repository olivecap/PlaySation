using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStationData
{
    public class Match
    {
        //Fields
        #region Fields

        //Numero macth
        int _numeroMatch = 0;

        public int NumeroMatch
        {
            get { return _numeroMatch; }
            set { _numeroMatch = value; }
        }

        /// <summary>
        /// Joueur exempt
        /// </summary>
        bool _joueurExempt = false;

        public bool JoueurExempt
        {
            get { return _joueurExempt; }
            set { _joueurExempt = value; }
        }

        //Match joue
        bool _matchJoue;

        public bool MatchJoue
        {
            get { return _matchJoue; }
            set { _matchJoue = value; }
        }

        //Joueur domicile
        Joueur _joueurDomicile;

        public Joueur JoueurDomicile
        {
            get { return _joueurDomicile; }
            set { _joueurDomicile = value; }
        }

        //Joueur exterieur
        Joueur _joueurExterieur;

        public Joueur JoueurExterieur
        {
            get { return _joueurExterieur; }
            set { _joueurExterieur = value; }
        }

        //Resultat
        Resultat _resultatMatch = new Resultat();

        public Resultat ResultatMatch
        {
            get { return _resultatMatch; }
            set { _resultatMatch = value; }
        }
        #endregion Fields
    }
}
