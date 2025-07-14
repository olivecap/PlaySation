using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PlayStation
{
    public class Tournois
    {

        string sss = "";

        //Fields
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

        //Modificatin mngt
        bool _modify;
        public bool Modify
        {
            get { return _modify; }
            set { _modify = value; }
        }

        //Liste des joueurs
        Joueurs _joueursTournois;

        public Joueurs JoueursTournois
        {
            get { return _joueursTournois; }
        }

        //Joueur exempt
        bool _joueurExempt;

        public bool JoueurExempt
        {
          get { return _joueurExempt; }
          set { _joueurExempt = value; }
        }

        //Nombre de journee
        int _nbJournee;

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
        int _nbMatchsJournee;

        public int NbMatchsJournee
        {
            get { return _nbMatchsJournee; }
            set {
                    if (value == 0)
                        throw new ApplicationException("Erreur de calcul du nombre de matchs par journée du tournois"); 
                    _nbMatchsJournee = value;
                }
        }

        //Calendrier
        Journees _journeesTournois;

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

        #endregion Fields

        //Constructor / Destructor
        #region Constructor / Destructor

        public Tournois()
        {
            //Initialize date and time
            _dateTimeTournois = DateTime.Now;

            //Initialize modif mngt
            Modify = false;
        }

        #endregion Constructor / Destructor

        //Public services (generer tournois)
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
                _joueurExempt = false;
            else
                _joueurExempt = true;

            //Calcul nombre de matchs par journee
            NbMatchsJournee = CalculNombreMatchParJournee();

            //Create calendrier
            if (!GenerateCalendrier())
                return false;

            return true;
        }

        #endregion Public services

        //private services
        #region private services

        private bool GenerateCalendrier()
        {
            try
            {
                //Calcul nombre journee
                NbJournee = CalculNombreJournee();
                
                //Creation calnedrier
                for (int i = 1; i <= NbJournee; i++)
                {
                    //Create journee
                    CreateJournee(i);
                }


                MessageBox.Show(sss);
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
        /// Calcul le nombre de journee a jouer
        /// </summary>
        /// <returns></returns>
        int CalculNombreJournee()
        {
            //Get nb  joueurs
            int nbJournee = _joueursTournois.Count - 1;

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

            MessageBox.Show(nbmatchs.ToString(), "matchs");
            //Retourne le nombre de journees
            return nbmatchs;
        }

        /// <summary>
        /// Creation journee
        /// </summary>
        /// <param name="inumerojournee"></param>
        void CreateJournee(int inumerojournee)
        {
sss += "journee " + inumerojournee.ToString() + "\n";

            //Create journee;
            Journee journee = new Journee();

            //Create match
            journee.IitializeJournee(inumerojournee, _joueursTournois, JoueurExempt);

sss += "index joueur depart " + journee.IndexJoueurDepart + "\n";
sss += journee.S;
        }
        #endregion private services
    }
}
