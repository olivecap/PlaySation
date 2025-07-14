using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;

///********************************************************************************
/// Principe :
/// *******************************************************************************
/// - pour n equipes (n pair)
/// - constituer un tableau T1 de 2 colonnes et n/2 lignes
/// - remplir le tableau en commencant en haut a gauche dans le sens anti-horaire
///     1   n
///     2   n-1
///     3   n-2
///     ...
///     n/2 n/2 +1
/// - a partir de T1, on cree T2 en gardant 1 fixe en haut a gauche
/// - et en faisant tourner les autres d'un cran dans le sens horaire
///     1   2     
///     3   n  
///     n-2 n-1  
///     ...
///     n/2 n/2+1
/// - on repete l'operation pour avoir n-1 tableaux
/// - la correspondance entre les tableaux Ti et les journees de championnat Ji
/// est alors :
///     J1 -> T1
///     J2 -> Tn/2
///     J3 -> Tn-1
///     J4 -> Tn/2-1
///     J5 -> Tn-2
///     J6 -> Tn/2-2
///     ...
///     Jn-2 -> T2
///     Jn-1 -> Tn/2+1
/// - pour les journees paires, pour le 1er match de la journee, on inverse
/// Domicile et Exterieur (donc pour l'equipe n). Sinon, elle ferait tous ses matchs aller
/// a l'exterieur... 
///********************************************************************************
namespace PlayStationData
{
    public class Tournois
    {
        //-------------
        //- Varaibles -
        //-------------
        #region Fields

        //Nom
        string _nomTournois;
        public string NomTournois
        {
            get { return _nomTournois; }
            set { _nomTournois = value; }
        }

        //Date
        DateTime _dateTimeTournois;
        public DateTime DateTime
        {
            get { return _dateTimeTournois; }
            set { _dateTimeTournois = value; }
        } 
        
        //Type tournois
        bool _matchAllerRetour;
        public bool MatchAllerRetour
        {
            get { return _matchAllerRetour; }
            set { _matchAllerRetour = value; }
        }

        //Liste des joueurs
        Joueurs _joueursTournois = new Joueurs();
        public Joueurs JoueursTournois
        {
            get { return _joueursTournois; }
        }

        //Joueur exempt
        bool _bJoueurExempt = false;
        public bool JoueurExempt
        {
          get { return _bJoueurExempt; }
          set { _bJoueurExempt = value; }
        }

        //Nombre de journee
        int _nbJournee = -1;
        public int NbJournee
        {
            get { return _nbJournee; }
            set {
                    if (value == 0)
                        throw new ApplicationException("Erreur de calcul du nombre de journées du tournois");
                    _nbJournee = value;
                }
        }

        //Nombre match par journee
        int _nbMatchsJournee = 0;
        public int NbMatchsJournee
        {
            get { return _nbMatchsJournee; }
            set {
                    if (value == 0)
                        throw new ApplicationException("Erreur de calcul du nombre de matchs par journée du tournois"); 
                    _nbMatchsJournee = value;
                }
        }

        //Matrice initiale de calcul de match
        Array _matriceMatchInit;

        //Calendrier
        Journees _journeesTournois = new Journees();
        public Journees JourneesTournois
        {
            get { return _journeesTournois; }
            set { _journeesTournois = value; }
        }
        
        //Classement
        Classement _classementTournois = new Classement();
        public Classement ClassementTournois
        {
            get { return _classementTournois; }
            set { _classementTournois = value; }
        }

        /// <summary>
        /// Test si tournoi genere
        /// </summary>
        bool _bTournoiGenere = false;

        public bool TournoiGenere
        {
            get { return _bTournoiGenere; }
            set { _bTournoiGenere = value; }
        }

        //Objet Classement general
        ClassementGeneral _ClassementGeneral = new ClassementGeneral();

        public ClassementGeneral ClassementGeneral
        {
            get { return _ClassementGeneral; }
            set { _ClassementGeneral = value; }
        }

        #endregion Fields

        //----------------------------
        //- Constructor / Destructor -
        //----------------------------
        #region Constructor / Destructor

        public Tournois()
        {
            //Initialize date and time
            _dateTimeTournois = DateTime.Now;
        }

        #endregion Constructor / Destructor

        //------------------------
        //- Public services      - 
        //-     GenererTournois  -
        //-     UpdateClassement -
        //------------------------
        #region Public services

        /// <summary>
        /// Genere les donnees du tournois
        /// Initialise 
        ///     Les joueurs
        ///     le calendrier
        ///     le classement
        ///     ...
        /// </summary>
        /// <param name="joueurs"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public bool GenererTournois(Joueurs joueurs, string nom, bool matchallerretour)
        {
            //Set name
            NomTournois = nom;

            //Initialize date and time
            _dateTimeTournois = DateTime.Now;

            //Set tournement type
            MatchAllerRetour = matchallerretour;

            //Initialize player list
            _joueursTournois = new Joueurs();
            _joueursTournois.AddRange(joueurs.ToArray());
         
            //Test si joueur exempt
            if (_joueursTournois.Count % 2 == 0)
                _bJoueurExempt = false;
            else
            {
                //Set joueur tournoi
                _bJoueurExempt = true;

                //CreateJournee joueur exempt
                Joueur joueurExempt = new Joueur();
                joueurExempt.Equipe = "Exempt";
                joueurExempt.Numero = _joueursTournois.Count + 1;

                //Set in joueurs class
                _joueursTournois.JoueurExempt = joueurExempt;

            }

            //Calcul nombre de matchs par journee
            NbMatchsJournee = CalculNombreMatchParJournee();

            //Generation matrice de match intiale
            if (!GenerationTableBergerInitial())
                return false;

            //Create calendrier
            _journeesTournois = new Journees();
            if (!GenerateCalendrier())
                return false;

            //Create classement
            _classementTournois = new Classement();
            if (!GenerateClassement())
                return false;

            //Positionne données tournoi genere
            _bTournoiGenere = true;

            return true;
        }

        /// <summary>
        /// Update classement
        /// </summary>
        /// <returns></returns>
        public bool UpdateClassement()
        {
            //Test si tournoi genere
            if (_bTournoiGenere == false)
                throw new ApplicationException("Impossible de mettre a jour le classement. Le tournoi n'est pas initialisé");

            //Remise a zero des calculs de classement
            ResetClassementValue();

            //Mise a jour du classement
            _classementTournois.UpdateClassementValue(_journeesTournois);

            return true;
        }

        #endregion Public services


        //--------------------
        //- private services -
        //--------------------
        #region private services

        /// <summary>
        /// Generation de la matrice de match de depart pour creer un championnate
        /// Basee sur la methode TABLE DE BERGER POUR LA GESTION DE CHAMPIONNAT
        /// # Principe :
        /// - pour n equipes (n pair)
        /// - constituer un tableau T1 de 2 colonnes et n/2 lignes
        /// - remplir le tableau en commencant en haut a gauche dans le sens anti-horaire
        ///     1 n
        ///     2 n-1
        ///     3 n-2
        ///     ...
        ///     n/2 n/2 +1 
        /// </summary>
        /// <returns></returns>
        private bool GenerationTableBergerInitial()
        {
            //Initialise nombre de joueur
            int nbJoueurs = JoueursTournois.Count;

            //Create array
            _matriceMatchInit = Array.CreateInstance(typeof(Int32), 2, NbMatchsJournee);
            
            //Cas joueur impair augmente le nombre de joeur temporairement
            if (JoueurExempt)
                nbJoueurs += 1;

            //Initialize array
            //Loop on column
            for (int i = 0; i < 2; i++)
			{
                //Loop on lines
                for (int j = 0; j < NbMatchsJournee; j++)
                {
                    //Colonne 0
                    if (i == 0)
                    {
                        //Set numero equipe
                        _matriceMatchInit.SetValue(i+j, i, j);
                    }

                    //Colonne 1
                    else
                    {
                        //Set numero equipe
                        _matriceMatchInit.SetValue(nbJoueurs - 1 - j, i, j);
                    }
                }				 
			}

            return true;
	    }

        /// <summary>
        /// Generation calendrier
        /// </summary>
        /// <returns></returns>
        private bool GenerateCalendrier()
        {
            try
            {
                //Calcul nombre journee
                NbJournee = CalculNombreJournee();
                
                //Creation calnedrier
                for (int i = 1; i <= NbJournee; i++)
                {
                    //Table berger
                    Array tableBerger;

                    //Initialise table berger
                    if (i == 1)
                        tableBerger = _matriceMatchInit;
                    else
                    {
                        //Recupere journee precedente
                        tableBerger = _journeesTournois[i - 2].MatriceBergerJournee;
                    }

                    //Create journee
                    CreateJournee(i, tableBerger);
                }
            }
            catch(Exception e)
            {
                //Release object
                if (_journeesTournois != null)
                    _journeesTournois.Clear();

                throw e;
            }
            return true;
        }

        /// <summary>
        /// Generation classement
        /// </summary>
        /// <returns></returns>
        private bool GenerateClassement()
        {
            try
            {
                //Iterate thraught list of players
                foreach (Joueur joueur in _joueursTournois)
	            {
		            //Create classement item
                    ClassementItem classementItem = new ClassementItem();

                    //Initialize joueur
                    classementItem.Joueur = joueur;

                    //Add classement item
                    _classementTournois.Add(classementItem);
	            }          
            }
            catch(Exception e)
            {
                //Release object
                if (_classementTournois != null)
                    _classementTournois.Clear();

                throw e;
            }
            return true;
        }

        /// <summary>
        /// Calcul le nombre de journee a jouer
        /// </summary>
        /// <returns></returns>
        int CalculNombreJournee()
        {          
            //Get nb  joueurs
            int nbJournee = _joueursTournois.Count - 1;

            //Check si joueur exempt
            if (_bJoueurExempt == true)
                nbJournee += 1;

            //Calcul nombre journees en fonction type de tournois
            if (MatchAllerRetour == true)
                nbJournee = nbJournee * 2;
            
            return nbJournee;
        }

        //Calcul le nombre de match par journee
        int CalculNombreMatchParJournee()
        {
            //Calcul nombre journées en focntion joueurs
            int nbmatchs = _joueursTournois.Count / 2;

            //Test cas joueur exempt
            if (JoueurExempt)
                nbmatchs += 1;

            //Retourne le nombre de journees
            return nbmatchs;
        }

        /// <summary>
        /// Creation journee
        /// </summary>
        /// <param name="inumerojournee"></param>
        void CreateJournee(int numerojournee, Array tableBerger)
        {
            //Create journee;
            Journee journee = new Journee();

            //Initialise journee
            journee.IitializeJournee(numerojournee, _joueursTournois, NbJournee, NbMatchsJournee, JoueurExempt, tableBerger);

            //Ajout journee
            _journeesTournois.Add(journee);
        }

        /// <summary>
        /// Reset classement
        /// </summary>
        private void ResetClassementValue()
        {
            //Iteration sur classement
            foreach (ClassementItem item in _classementTournois)
            {
                //Reset value
                item.ResetValue(); 
            }
        }

        #endregion private services
    }
}
