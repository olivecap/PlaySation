using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStation
{
    public class Journee
    {
        string s = "";

        public string S
        {
            get { return s; }
            set { s = value; }
        }


        //Fields
        #region Fields

        //Number
        int _number;

        public int Number
        {
            get { return _number; }
            set {
                    if (value <= 0)
                        throw new ApplicationException("Numero de journee incorrect");
                    _number = value;
                }
        }
       
        //Type la journee (matchs aller ou retour
        bool _JourneeAller = true;

        public bool JourneeAller
        {
            get { return _JourneeAller; }
            set { _JourneeAller = value; }
        }

        //Liste matchs
        Matchs _listMatch = null;

        public Matchs ListMatch
        {
            get { return _listMatch; }
        }

        //Joueur exempt
        Joueur _joueurExempt = null;

        public Joueur JoueurExempt
        {
            get { return _joueurExempt; }
            set { _joueurExempt = value; }
        }

        //Index de joueur de base
        int _indexJoueurDepart = -1;

        public int IndexJoueurDepart
        {
            get { return _indexJoueurDepart; }
            set { _indexJoueurDepart = value; }
        }

        #endregion Fields

        //Constructeur / Destructeur
        #region Constructeur / Destructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="numerojournee"></param>
        public Journee()
        {
        }

        #endregion Constructeur / Destructeur

        //Public service
        #region Public services

        /// <summary>
        /// Initialisaion journee
        ///     Numero
        ///     Matchs
        ///     ...
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        public bool IitializeJournee(int numerojournee, Joueurs joueurstournois, bool joueurexempt)
        {
            //Set parameter
            Number = numerojournee;

            //Test validite joueur
            if (joueurstournois.Count <= 1)
                throw new ApplicationException("Erreur: Le nombre de joueurs es insuffisants");

            //Initialize l'indice de depart
            //Test si joueur exempt
//            _indexJoueurDepart = (numerojournee - 1) % (joueurstournois.Count);
            _indexJoueurDepart = 0;
            
            //Mise a jour joueur de depart
            if (joueurexempt)
                _indexJoueurDepart = _indexJoueurDepart + 1;

            //Test si journee aller
            if (numerojournee >= joueurstournois.Count)
                JourneeAller = false;

            //Create match
            return CreateMatchs(joueurstournois);
        }

        #endregion Public services

        //Public service
        #region Private services

        /// <summary>
        /// Joueurs
        /// Algorythme
        ///     Initialise nombre de macth = nombre de journee / 2
        ///     Initialise indice de depart d'indice de joueur pour commencer algo
        ///         Si pas de joueur exempt
        ///             Indice de depart = numero de journee - 1 MODULO nombre de 
        ///         Sinon
        ///             Indice de depart = numero de journee
        /// </summary>
        /// <param name="joueurstournois"></param>
        /// <returns></returns>
        bool CreateMatchs(Joueurs joueurstournois)
        {
            //Iterate to CreateMatchs match
            int nbJoueurs = joueurstournois.Count;
            int nbMatchs = nbJoueurs / 2;
            int indexTemp = _indexJoueurDepart;
            for (int i = 0; i < nbMatchs; i++)
            {
                //Recupere joueur 1
                 int indiceJoueur1 = (indexTemp++) % (nbJoueurs);
                Joueur joueur1 = joueurstournois[indiceJoueur1];

                //Recupere joueur 2
                int indiceJoueur2 = (indexTemp++) % (nbJoueurs);
                Joueur joueur2 = joueurstournois[indiceJoueur2];

                //Cree match
                Match match = new Match();

                //Initialize numero match
                match.NumeroMatch = i + 1;

                //Test si match aller
                if (_JourneeAller)
                {
                    //Set matchs
                    match.JoueurDomicile = joueur1;
                    match.JoueurExterieur = joueur2;
                }
                else
                {
                    //Set matchs
                    match.JoueurDomicile = joueur2;
                    match.JoueurExterieur = joueur1;
                }

                s += match.JoueurDomicile.Nom + " - " + match.JoueurExterieur.Nom + "\n";
            }

            return true;
        }

        #endregion Private service
    }
}
