using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PlayStationData
{
    public class Journee
    {
        string s = "";

        [XmlIgnore]
        public string S
        {
            get { return s; }
            set { s = value; }
        }


        //Fields
        #region Fields

        //Number
        int _numeroJournee;

        public int NumeroJournee
        {
            get { return _numeroJournee; }
            set {
                    if (value <= 0)
                        throw new ApplicationException("Numero de journee incorrect");
                    _numeroJournee = value;
                }
        }
       
        //Nombre de matchs par journee
        int _nbMatchsParJournee = 0;

        public int NbMatchsParJournee
        {
            get { return _nbMatchsParJournee; }
            set { _nbMatchsParJournee = value; }
        }

        //Type la journee (matchs aller ou retour
        bool _JourneeAller = true;

        public bool JourneeAller
        {
            get { return _JourneeAller; }
            set { _JourneeAller = value; }
        }

        //Table berger
        Array _matriceBergerJournee;
        [XmlIgnore]
        public Array MatriceBergerJournee
        {
            get { return _matriceBergerJournee; }
            set { _matriceBergerJournee = value; }
        }

        //Liste matchs
        Matchs _listMatch = new Matchs();

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
        public bool IitializeJournee(int numerojournee, Joueurs joueurstournois, int nbJournee, int nbMatchJournee, bool bJoueurExempt, Array tableBergerInit)
        {
            //Set parameter
            NumeroJournee = numerojournee;

            //Test validite joueur
            if (joueurstournois.Count <= 1)
                throw new ApplicationException("Erreur: Le nombre de joueurs es insuffisants");
            
            //Cas joueur impair augmente le nombre de joeur temporairement
            int iNbJoueurs = joueurstournois.Count;
            if (bJoueurExempt)
                iNbJoueurs += 1;

            //Test si journee aller
            if (numerojournee >= iNbJoueurs)
                JourneeAller = false;

            //Set nombre de match par journee
            NbMatchsParJournee = nbMatchJournee;

            //Test si table berger valide
            if (tableBergerInit == null)
                throw new ApplicationException("Erreur: Parametre necessaire à la generation des matchs de la journéé non valide");

            //Initialise table berger
            //if ((NumeroJournee == 1) || (NumeroJournee == (nbJournee / 2) + 1))
            if (NumeroJournee == 1)
            {
                if (!CopyTableBerger(joueurstournois, tableBergerInit))
                    return false;
            }
            else
            {
                if (!GenerationTableBergerJournee(joueurstournois, tableBergerInit))
                    return false;
            }

            //Create match
            if (!CreateMatchs(joueurstournois, nbJournee, nbMatchJournee, bJoueurExempt))
                return false;

            //Set joueur exempt
            if (bJoueurExempt)
            {
                if (JourneeAller)
                    _joueurExempt = _listMatch[0].JoueurExterieur;
                else
                    _joueurExempt = _listMatch[0].JoueurDomicile;
            }

            return true;
        }

        #endregion Public services

        //Public service
        #region Private services

        /// <summary>
        /// Copy table de berger
        /// </summary>
        /// <param name="joueurstournois"></param>
        /// <param name="tableBergerInit"></param>
        private bool CopyTableBerger(Joueurs joueurstournois, Array tableBergerInit)
        {
            //Create array
            _matriceBergerJournee = Array.CreateInstance(typeof(Int32), 2, NbMatchsParJournee);

            //Loop sur colonnes
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < NbMatchsParJournee; j++)
                    _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), i, j);
            }

            for (int j = 0; j < NbMatchsParJournee; j++)
            {
                s += "Match" + (j + 1).ToString() + " ===> ";
                for (int i = 0; i < 2; i++)
                {
                    int numeroEquipe = (int)_matriceBergerJournee.GetValue(i, j);
                    if ((numeroEquipe == (joueurstournois.Count)) && (JoueurExempt != null))
                        numeroEquipe = -1;

                    if (i == 0)
                    {
                        s += "Equipe" + numeroEquipe.ToString() + " - ";
                    }
                    else
                        s += "Equipe" + numeroEquipe.ToString() + "\n";
                }
            }

            return true;
        }

        /// <summary>
        /// Generation table berger en fonction table init
        /// </summary>
        /// <returns></returns>
        bool GenerationTableBergerJournee(Joueurs joueurstournois, Array tableBergerInit)
        {
            //Create array
            _matriceBergerJournee = Array.CreateInstance(typeof(Int32), 2, NbMatchsParJournee);

            //Loop sur colonnes
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < NbMatchsParJournee; j++)
                {
                    //Column 1
                    if (i == 0)
                    {
                        //Ligne 1
                        if (j == 0)
                            _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), i, j);
                        //Ligne 2
                        else if (j == 1)
                        {
                            _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), j, i);
                        }
                        else
                        {
                            _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), i, j-1);
                        }
                    }
                    //Colonne 2
                    else
                    {
                        //Ligne n
                        if (j == NbMatchsParJournee - 1)
                            _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), i-1, j);
                        else
                            _matriceBergerJournee.SetValue(tableBergerInit.GetValue(i, j), i, j+1);
                    }
                }
            }

            for (int j = 0; j < NbMatchsParJournee; j++)
            {
                s += "Match" + (j + 1).ToString() + " ===> ";
                for (int i = 0; i < 2; i++)
                {
                    int numeroEquipe = (int)_matriceBergerJournee.GetValue(i, j);
                    if ((numeroEquipe == (joueurstournois.Count)) && (JoueurExempt != null))
                        numeroEquipe = -1;

                    if (i == 0)
                    {
                        s += "Equipe" + numeroEquipe.ToString() + " - ";
                    }
                    else
                        s += "Equipe" + numeroEquipe.ToString() + "\n";
                }
            }

            return true;
	    }

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
        bool CreateMatchs(Joueurs joueurstournois, int nbJournee, int nbMatchJournee, bool bJoueurEexempt)
        {
            //Loop on journee
            for (int i = 0; i < nbMatchJournee; i++)
            {
                //Cree match
                Match match = new Match();

                //Initialize numero match
                match.NumeroMatch = i + 1;

                //Test si joueur exempt dans le tournois
                if (bJoueurEexempt == false)
                    InittialiseMatchSansJoueurExempt(ref match, joueurstournois, i);
                else
                    InittialiseMatchAvecJoueurExempt(ref match, joueurstournois, i);

                //Ajout match
                _listMatch.Add(match);
            }

            return true;
        }

        /// <summary>
        /// Initialise le macth sans joueur exempt dans le tournoi
        /// </summary>
        /// <param name="match"></param>
        /// <param name="joueurstournois"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool InittialiseMatchSansJoueurExempt(ref Match match, Joueurs joueurstournois, int i)
        {
            //Test si match aller
            if (_JourneeAller)
            {
                //Set match domicile
                match.JoueurDomicile = joueurstournois[(int)_matriceBergerJournee.GetValue(0, i)];
                match.JoueurExterieur = joueurstournois[(int)_matriceBergerJournee.GetValue(1, i)];
            }
            else
            {
                //Set match exterieur
                match.JoueurDomicile = joueurstournois[(int)_matriceBergerJournee.GetValue(1, i)];
                match.JoueurExterieur = joueurstournois[(int)_matriceBergerJournee.GetValue(0, i)];
            }

            return true;
        }

        /// <summary>
        /// Initialise le macth sans joueur exempt dans le tournoi
        /// </summary>
        /// <param name="match"></param>
        /// <param name="joueurstournois"></param>
        /// <param name="i"></param>
        private void InittialiseMatchAvecJoueurExempt(ref Match match, Joueurs joueurstournois, int i)
        {
            //Test si match aller
            if (_JourneeAller)
            {
                //------------------
                //- Match domicile -
                //------------------
                //Get numero joueur domicile
                int iNumJoueurDomicile = (int)_matriceBergerJournee.GetValue(0, i);

                //test numero joueur pour positionner match exterieur
                if (iNumJoueurDomicile == joueurstournois.Count)
                {
                    match.JoueurDomicile = joueurstournois.JoueurExempt;
                    match.JoueurExempt = true;
                }
                else
                    match.JoueurDomicile = joueurstournois[iNumJoueurDomicile];

                //-------------------
                //- Match exterieur -
                //-------------------
                //Get numero joueur exterieur
                int iNumJoueurExterieur = (int)_matriceBergerJournee.GetValue(1, i);

                //test numero joueur pour positionner match exterieur
                if (iNumJoueurExterieur == joueurstournois.Count)
                {
                    match.JoueurExterieur = joueurstournois.JoueurExempt;
                    match.JoueurExempt = true;
                }
                else
                    match.JoueurExterieur = joueurstournois[iNumJoueurExterieur];
            }
            else
            {
                //------------------
                //- Match domicile -
                //------------------
                //Get numero joueur domicile
                int iNumJoueurDomicile = (int)_matriceBergerJournee.GetValue(1, i);

                //test numero joueur pour positionner match exterieur
                if (iNumJoueurDomicile == joueurstournois.Count)
                {
                    match.JoueurDomicile = joueurstournois.JoueurExempt;
                    match.JoueurExempt = true;
                }
                else
                    match.JoueurDomicile = joueurstournois[iNumJoueurDomicile];

                //-------------------
                //- Match exterieur -
                //-------------------
                //Get numero joueur exterieur
                int iNumJoueurExterieur = (int)_matriceBergerJournee.GetValue(0, i);

                //test numero joueur pour positionner match exterieur
                if (iNumJoueurExterieur == joueurstournois.Count)
                {
                    match.JoueurExterieur = joueurstournois.JoueurExempt;
                    match.JoueurExempt = true;
                }
                else
                    match.JoueurExterieur = joueurstournois[iNumJoueurExterieur];
            }
        }

        #endregion Private service
    }
}
