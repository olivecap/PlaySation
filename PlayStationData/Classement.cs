using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PlayStationData
{
    /// <summary>
    /// Type de joueur
    /// </summary>
    public enum TypeJoueur
    {
        joueurDomicile = 0,
        joueurExterieur = 1
    }

    public class SortClassementParMeilleurAttaque : IComparer<ClassementItem>
    {
        //-----------------------
        //- IComparer interface -
        //-----------------------
        #region IComparer Members

        public int Compare(ClassementItem itemClass1, ClassementItem itemClass2)
        {            
            //---------------
            //- Comparaison -
            //---------------
            //But pour
            if (itemClass1.NombreButPour > itemClass2.NombreButPour)
                return -1;
            else if (itemClass1.NombreButPour < itemClass2.NombreButPour)
                return 1;

            //Sinon nom equipe
            return String.Compare(itemClass1.NomEquipe, itemClass2.NomEquipe);
        }

        #endregion
    }

    public class SortClassementParMeilleurDefense : IComparer<ClassementItem>
    {
        //-----------------------
        //- IComparer interface -
        //-----------------------
        #region IComparer Members

        public int Compare(ClassementItem itemClass1, ClassementItem itemClass2)
        {
            //---------------
            //- Comparaison -
            //---------------
            //But pour
            if (itemClass1.NombreButContre < itemClass2.NombreButContre)
                return -1;
            else if (itemClass1.NombreButContre > itemClass2.NombreButContre)
                return 1;

            //Sinon nom equipe
            return String.Compare(itemClass1.NomEquipe, itemClass2.NomEquipe);
        }

        #endregion
    }

    public class Classement : List<ClassementItem>
    {
        //-------------------
        //- Public services -
        //-------------------
        #region Public services

        /// <summary>
        /// Mise a jour du classement
        /// </summary>
        /// <param name="journeesTournois"></param>
        public void UpdateClassementValue(Journees journeesTournois)
        {
            //iteration sur le nombre de journee
            foreach (Journee itemJournee in journeesTournois)
            {
                //Test journee
                if (itemJournee == null)
                    throw new ApplicationException("Erreur sur la recuperaton d'une journee");

                //Iteration sur le nombre de match
                foreach (Match itemMatch in itemJournee.ListMatch)
                {
                    //Test journee
                    if (itemMatch == null)
                        throw new ApplicationException("Erreur sur la recuperaton d'une match");

                    //Test si match valide
                    if ((itemMatch.JoueurExempt == false) &&
                        (itemMatch.MatchJoue == true))
                    {
                        //-------------------
                        //- Joueur domicile -
                        //-------------------
                        //Retrouve numero joueur domiciel
                        int NumeroJoueurDomicile = itemMatch.JoueurDomicile.Numero;

                        //Get classement item domicile
                        ClassementItem itemt = new ClassementItem();
                        ClassementItem itemClassementDom = Find(delegate(ClassementItem itemttt) { return itemttt.Joueur.Numero == NumeroJoueurDomicile; });
                        if (itemClassementDom == null)
                            throw new ApplicationException("Impossible de mettre a jour le classement");

                        //Mise a jour classement
                        itemClassementDom.UpdateClassementItem(TypeJoueur.joueurDomicile, itemMatch.ResultatMatch);

                        //--------------------
                        //- Joueur exterieur -
                        //--------------------
                        //Retrouve numero joueur exterieur
                        int NumeroJoueurExterieur = itemMatch.JoueurExterieur.Numero;

                        //Get classement item domicile
                        ClassementItem itemClassementExt = Find(delegate(ClassementItem itemttt) { return itemttt.Joueur.Numero == NumeroJoueurExterieur; });
                        if (itemClassementExt == null)
                            throw new ApplicationException("Impossible de mettre a jour le classement");

                        //Mise a jour classement
                        itemClassementExt.UpdateClassementItem(TypeJoueur.joueurExterieur, itemMatch.ResultatMatch);
                    }
                }
            } 
        }

        #endregion Public services
    }
}
