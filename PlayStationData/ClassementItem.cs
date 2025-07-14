using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class ClassementItem : IComparable
    {
        //--------------
        //- Constantes -
        //--------------
        #region Constantes

        //points selon resultat
        const int cst_point_victoire = 3;
        const int cst_point_nul = 1;
        const int cst_point_defaite = 0;

        #endregion Constantes

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

        /// <summary>
        /// Nom equipe
        /// </summary>
        string _nomEquipe;

        public string NomEquipe
        {
            get { return _joueur.NomComplet; }
            set { _nomEquipe = value; }
        }

        //Nombre de point
        int _nombrePoint;

        public int NombrePoint
        {
            get { return _nombrePoint; }
            set { _nombrePoint = value; }
        }

        //Nombre de match joues
        int _nombreMatchJoues;

        public int NombreMatchJoues
        {
            get { return _nombreMatchJoues; }
            set { _nombreMatchJoues = value; }
        }

        //Nombre de victoires
        int _nombreVicoire;

        public int NombreVicoire
        {
            get { return _nombreVicoire; }
            set { _nombreVicoire = value; }
        }

        //Nombre de nuls
        int _nombreNul;

        public int NombreNul
        {
            get { return _nombreNul; }
            set { _nombreNul = value; }
        }

        //Nombre de defaites
        int _nombreDefaite;

        public int NombreDefaite
        {
            get { return _nombreDefaite; }
            set { _nombreDefaite = value; }
        }

        //Nombre but pour
        int _nombreButPour;

        public int NombreButPour
        {
            get { return _nombreButPour; }
            set { _nombreButPour = value; }
        }

        //Nombre but contre
        int _nombreButContre;

        public int NombreButContre
        {
            get { return _nombreButContre; }
            set { _nombreButContre = value; }
        }

        //Golaverage
        int _goalaverage;

        public int Goalaverage
        {
            get { return _goalaverage; }
            set { _goalaverage = value; }
        }

        #endregion Fileds

        //-------------------------
        //- IComparable interface -
        //-------------------------
        #region IComparable Members

        /// <summary>
        /// Implmente interface IComparable pour lancer une comparaison implicite
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            //Test si bonne classe
            ClassementItem classToCompare = (ClassementItem) obj;
            if (classToCompare == null)
                throw new ApplicationException("L'objet a comparer est invalide");

            //Comparaison nombre de points
            if (this.NombrePoint > classToCompare.NombrePoint)
                return Constants.cst_greater;
            else if (this._nombrePoint < classToCompare._nombrePoint)
                return Constants.cst_less;

            //Sinon compare golaverage
            if (this.Goalaverage > classToCompare.Goalaverage)
                return Constants.cst_greater;
            if (this.Goalaverage < classToCompare.Goalaverage)
                return Constants.cst_less;

            //Sinon compare nombre buts pour
            if (this.NombreButPour > classToCompare.NombreButPour)
                return Constants.cst_greater;
            if (this.NombreButPour < classToCompare.NombreButPour)
                return Constants.cst_less;

            //Sinon compare nombre match joués
            if (this.NombreMatchJoues < classToCompare.NombreMatchJoues)
                return Constants.cst_less;
            if (this.NombreMatchJoues > classToCompare.NombreMatchJoues)
                return Constants.cst_greater;

            //Sinon compare nom equipe
            return String.Compare(this.NomEquipe, classToCompare.NomEquipe);
        }

        #endregion

        //-------------------
        //- Public services -
        //-------------------
        #region Public services

        /// <summary>
        /// Reset value
        /// </summary>
        public void ResetValue()
        {
            //reset data
            _nombrePoint = 0;
            _nombreMatchJoues = 0;
            _nombreVicoire = 0;
            _nombreNul = 0;
            _nombreDefaite = 0;
            _nombreButContre = 0;
            _nombreButPour = 0;
            _goalaverage = 0;
        }

        public void UpdateClassementItem(TypeJoueur eTypeJoueur, Resultat resultat)
        {
            //Incremente nombre de match
            _nombreMatchJoues += 1;

            //Set nombre de but
            int ibutPour = 0;
            int ibutContre = 0;
            if (eTypeJoueur == TypeJoueur.joueurDomicile)
            {
                //Set value
                ibutPour = resultat.ButJoueurDomicile;
                ibutContre = resultat.ButJoueurExterieur;
            }
            else
            {
                //Set value
                ibutPour = resultat.ButJoueurExterieur;
                ibutContre = resultat.ButJoueurDomicile;
            }

            //Calcul nombre de points / Match
            //Victoire
            if (ibutPour > ibutContre)
            {
                _nombrePoint += cst_point_victoire;
                _nombreVicoire += 1;
            }
            //Nul
            else if (ibutPour == ibutContre)
            {
                _nombrePoint += cst_point_nul;
                _nombreNul += 1;
            }
            //Defaite
            else
            {
                _nombrePoint += cst_point_defaite;
                _nombreDefaite += 1;
            }

            //Update nombre de buts
            _nombreButPour += ibutPour;
            _nombreButContre += ibutContre;

            //Update goalaverage
            _goalaverage = _nombreButPour - _nombreButContre;
        }

        #endregion Public services       
    }
}
