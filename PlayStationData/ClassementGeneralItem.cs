using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class ClassementGeneralItem : IComparable
    {
        //-------------
        //- Variables -
        //-------------
        #region Fileds

        //Joueur
        Joueur _joueur;

        public Joueur Joueur
        {
            get { return _joueur; }
            set { _joueur = value; }
        }

        //Nombre de point
        uint _nombrePoints;

        public uint NombrePoints
        {
            get { return (_nombrePoints + NombrePointsBonus); }
            set { _nombrePoints = value; }
        }

        /// <summary>
        /// Nombre de points bonus
        ///  NB Victoires tournois / cst_pts_nb_tournois_bonus
        /// </summary>
        public uint NombrePointsBonus
        {
            get { return NombreTournoisGagnes / Constants.cst_pts_nb_tournois_bonus; }
        }

        //Nombre de point
        int _nombreTotalPoints;

        public int NombreTotalPoints
        {
            get { return _nombreTotalPoints; }
            set { _nombreTotalPoints = value; }
        }

        //Nombre de match joues
        int _nombreMatchJoues;

        public int NombreMatchJoues
        {
            get { return _nombreMatchJoues; }
            set { _nombreMatchJoues = value; }
        }

        //Nombre de victoires
        int _nombreVicoires;

        public int NombreVicoires
        {
            get { return _nombreVicoires; }
            set { _nombreVicoires = value; }
        }

        //Nombre de nuls
        int _nombreNuls;

        public int NombreNuls
        {
            get { return _nombreNuls; }
            set { _nombreNuls = value; }
        }

        //Nombre de defaites
        int _nombreDefaites;

        public int NombreDefaites
        {
            get { return _nombreDefaites; }
            set { _nombreDefaites = value; }
        }

        //Nombre but pour
        int _nombreButsPour;

        public int NombreButsPour
        {
            get { return _nombreButsPour; }
            set { _nombreButsPour = value; }
        }

        //Nombre but contre
        int _nombreButsContre;

        public int NombreButsContre
        {
            get { return _nombreButsContre; }
            set { _nombreButsContre = value; }
        }

        //Golaverage
        int _goalaverage;

        public int Goalaverage
        {
            get { return _goalaverage; }
            set { _goalaverage = value; }
        }

        /// <summary>
        /// Nombre de tournois
        /// </summary>
        uint _nombreTournois;

        public uint NombreTournois
        {
            get { return _nombreTournois; }
            set { _nombreTournois = value; }
        }

        /// <summary>
        /// Nombre de tournois joués
        /// </summary>
        uint _nombreTournoisJoues;

        public uint NombreTournoisJoues
        {
            get { return _nombreTournoisJoues; }
            set { _nombreTournoisJoues = value; }
        }
        
        /// <summary>
        /// Nombre de tournois gagnes
        /// </summary>
        uint _nombreTournoisGagnes;

        public uint NombreTournoisGagnes
        {
            get { return _nombreTournoisGagnes; }
            set { _nombreTournoisGagnes = value; }
        }

        /// <summary>
        /// % de victoires
        /// </summary>
        float _pourcentageVictoires;

        public float PourcentageVictoires
        {
            get { return _pourcentageVictoires; }
            set { _pourcentageVictoires = value; }
        }

        /// <summary>
        /// % de matchs nuls
        /// </summary>
        float _pourcentageNuls;

        public float PourcentageNuls
        {
            get { return _pourcentageNuls; }
            set { _pourcentageNuls = value; }
        }

        /// <summary>
        /// % de matchs defaites
        /// </summary>
        float _pourcentageDefaites;

        public float PourcentageDefaites
        {
            get { return _pourcentageDefaites; }
            set { _pourcentageDefaites = value; }
        }

        /// <summary>
        /// Moyenne points joues / Match joues
        /// </summary>
        float _moyennePointsMatchJoues;

        public float MoyennePointsMatchJoues
        {
            get { return _moyennePointsMatchJoues; }
            set { _moyennePointsMatchJoues = value; }
        }

        /// <summary>
        /// Moyenne points joues / Match joues
        /// </summary>
        float _moyenneButsPourMatchJoues;

        public float MoyenneButsPourMatchJoues
        {
            get { return _moyenneButsPourMatchJoues; }
            set { _moyenneButsPourMatchJoues = value; }
        }

        /// <summary>
        /// Moyenne points joues / Match joues
        /// </summary>
        float _moyenneButsContreMatchJoues;

        public float MoyenneButsContreMatchJoues
        {
            get { return _moyenneButsContreMatchJoues; }
            set { _moyenneButsContreMatchJoues = value; }
        }

        #endregion Fileds

        #region Constructeurs

        /// <summary>
        /// Construct object from classement item
        /// </summary>
        /// <param name="classItem"></param>
        public ClassementGeneralItem()
        {
            // Default values
            _joueur = new Joueur();
            _nombrePoints = 0;
            _nombreTotalPoints = 0;
            _nombreMatchJoues = 0;
            _nombreVicoires = 0;
            _nombreNuls = 0;
            _nombreDefaites = 0;
            _nombreButsPour = 0;
            _nombreButsContre = 0;
            _goalaverage = 0;
            _nombreTournois = 0;
            _nombreTournoisJoues = 0;
            _nombreTournoisGagnes = 0;
            _pourcentageVictoires = 0;
            _pourcentageNuls = 0;
            _pourcentageDefaites = 0;
            _moyennePointsMatchJoues = 0;
            _moyenneButsPourMatchJoues = 0;
            _moyenneButsContreMatchJoues = 0;
        }

        /// <summary>
        /// Construct object from classement item
        /// </summary>
        /// <param name="classItem"></param>
        /// <param name="classPos"></param>
        public ClassementGeneralItem(ClassementItem classItem, int classPos) : base()
        {
            // Set element
            _joueur = classItem.Joueur;           
            _nombreTotalPoints = classItem.NombrePoint;
            _nombreMatchJoues = classItem.NombreMatchJoues;
            _nombreVicoires = classItem.NombreVicoire;
            _nombreNuls = classItem.NombreNul;
            _nombreDefaites = classItem.NombreDefaite;
            _nombreButsPour = classItem.NombreButPour;
            _nombreButsContre = classItem.NombreButContre;
            _nombreTournoisJoues = 1;

            // Update data
            UpdateData(classPos);
        }

        #endregion Constructeurs

        #region Public services

        /// <summary>
        /// Update classement
        /// </summary>
        /// <param name="classItem"></param>
        /// <param name="classPos"></param>
        public void UpdateClassement(ClassementItem classItem, int classPos)
        {
            // Set element
            _nombreTotalPoints += classItem.NombrePoint;
            _nombreMatchJoues += classItem.NombreMatchJoues;
            _nombreVicoires += classItem.NombreVicoire;
            _nombreNuls += classItem.NombreNul;
            _nombreDefaites += classItem.NombreDefaite;
            _nombreButsPour += classItem.NombreButPour;
            _nombreButsContre += classItem.NombreButContre;
            _nombreTournoisJoues += 1;

            // Update data
            UpdateData(classPos);
        }

        #endregion Public services

        #region Protected services

        /// <summary>
        /// Update data depending of other data
        /// </summary>
        /// <param name="classPos"></param>
        public void UpdateData(int classPos)
        {
            // Check number of matchs
            if (_nombreMatchJoues == 0)
                return;

            //----------------
            //- Pourcentages -
            //----------------
            // Victoires
            _pourcentageVictoires = ((float)_nombreVicoires / (float)_nombreMatchJoues) * 100;
            // Nuls
            _pourcentageNuls = ((float)_nombreNuls / (float)_nombreMatchJoues) * 100;
            // Defaites
            _pourcentageDefaites = ((float)_nombreDefaites / (float)_nombreMatchJoues) * 100;

            //---------------
            //- Goalaverage -
            //---------------
            _goalaverage = _nombreButsPour - _nombreButsContre;

            //------------
            //- Moyennes -
            //------------
            // Moyenne points / matchs joues
            _moyennePointsMatchJoues = (float)_nombreTotalPoints / (float)_nombreMatchJoues;
            // Moyenne buts pour / matchs joues
            _moyenneButsPourMatchJoues = (float)_nombreButsPour / (float)_nombreMatchJoues;
            // Moyenne buts contre / matchs joues
            _moyenneButsContreMatchJoues = (float)_nombreButsContre / (float)_nombreMatchJoues;

            //--------------
            //- Classement -
            //--------------
           switch(classPos)
            {
                case 1:
                    _nombreTournoisGagnes += 1;
                    _nombrePoints += Constants.cst_pts_for_pos_1;
                    break;
                case 2:
                    _nombrePoints += Constants.cst_pts_for_pos_2;
                    break;
                case 3:
                    _nombrePoints += Constants.cst_pts_for_pos_3;
                    break;
                case 4:
                    _nombrePoints += Constants.cst_pts_for_pos_4;
                    break;
                case 5:
                    _nombrePoints += Constants.cst_pts_for_pos_5;
                    break;
                default:
                    break;
            }
        }

        #endregion  Protected services

        #region  IComparable

        /// <summary>
        /// Implmente interface IComparable pour lancer une comparaison implicite
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            //Test si bonne classe
            ClassementGeneralItem classToCompare = (ClassementGeneralItem) obj;
            if (classToCompare == null)
                throw new ApplicationException("L'objet a comparer est invalide");

            //Comparaison nombre de points
            if (this.NombrePoints > classToCompare.NombrePoints)
                return Constants.cst_greater;
            else if (this.NombrePoints < classToCompare.NombrePoints)
                return Constants.cst_less;

            //Sinon compare golaverage
            if (this.Goalaverage > classToCompare.Goalaverage)
                return Constants.cst_greater;
            if (this.Goalaverage < classToCompare.Goalaverage)
                return Constants.cst_less;

            //Sinon compare nombre buts pour
            if (this.NombreButsPour > classToCompare.NombreButsPour)
                return Constants.cst_greater;
            if (this.NombreButsPour < classToCompare.NombreButsPour)
                return Constants.cst_less;

            //Sinon compare nombre match joués
            if (this.NombreMatchJoues < classToCompare.NombreMatchJoues)
                return Constants.cst_less;
            if (this.NombreMatchJoues > classToCompare.NombreMatchJoues)
                return Constants.cst_greater;

            //Sinon compare nombre tournois joues
            if (this.NombreTournoisGagnes < classToCompare.NombreTournoisGagnes)
                return Constants.cst_less;
            if (this.NombreTournoisGagnes > classToCompare.NombreTournoisGagnes)
                return Constants.cst_greater;

            //Sinon compare nom equipe
            return String.Compare(this.Joueur.Nom, classToCompare.Joueur.Nom);
        }

        #endregion  IComparable

    }
}
