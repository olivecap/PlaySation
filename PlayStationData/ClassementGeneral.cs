using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class SortClassementGeneralParMeilleurAttaque : IComparer<ClassementGeneralItem>
    {
        //-----------------------
        //- IComparer interface -
        //-----------------------
        #region IComparer Members

        public int Compare(ClassementGeneralItem itemClass1, ClassementGeneralItem itemClass2)
        {
            //---------------
            //- Comparaison -
            //---------------
            //But pour
            if (itemClass1.NombreButsPour > itemClass2.NombreButsPour)
                return Constants.cst_greater;
            else if (itemClass1.NombreButsPour < itemClass2.NombreButsPour)
                return Constants.cst_less;

            //Sinon nom equipe
            return String.Compare(itemClass1.Joueur.Nom, itemClass2.Joueur.Nom);
        }

        #endregion
    }

    public class SortClassementGeneralParMeilleurDefense : IComparer<ClassementGeneralItem>
    {
        //-----------------------
        //- IComparer interface -
        //-----------------------
        #region IComparer Members

        public int Compare(ClassementGeneralItem itemClass1, ClassementGeneralItem itemClass2)
        {
            //---------------
            //- Comparaison -
            //---------------
            //But pour
            if (itemClass1.NombreButsContre < itemClass2.NombreButsContre)
                return Constants.cst_greater;
            else if (itemClass1.NombreButsContre > itemClass2.NombreButsContre)
                return Constants.cst_less;

            //Sinon nom equipe
            return String.Compare(itemClass1.Joueur.Nom, itemClass2.Joueur.Nom);
        }

        #endregion
    }

    public class ClassementGeneral
    {
        #region fields

        /// <summary>
        /// Check if current tournoi classement is used
        /// </summary>
        private bool isCurrentClassementAdded = false;

        public bool IsCurrentClassementAdded
        {
            get
            {
                return isCurrentClassementAdded;
            }

            set
            {
                isCurrentClassementAdded = value;
            }
        }

        /// <summary>
        /// Check if classement general is up to date
        /// </summary>
        private bool isUpToDate = true;
        public bool IsUpToDate
        {
            get { return isUpToDate; }
            set { isUpToDate = value; }
        }


        /// <summary>
        /// List of classement file items
        /// </summary>
        private ClassementGeneralFileItems listClassementGeneralFileItem = new ClassementGeneralFileItems();

        public ClassementGeneralFileItems ListClassementGeneralFileItem
        {
            get { return listClassementGeneralFileItem; }
            set { listClassementGeneralFileItem = value; }
        }

        /// <summary>
        /// List of classement item
        /// </summary>
        private ClassementGeneralItems listClassementGeneralItem = new ClassementGeneralItems();

        public ClassementGeneralItems ListClassementGeneralItem
        {
            get { return listClassementGeneralItem; }
            set { listClassementGeneralItem = value; }
        }

        #endregion fields

        #region constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClassementGeneral()
        {
        }

        #endregion constructors

        #region Generate classement

        public void GenerateClassement()
        {
            //---------------
            //- Clear value -
            //---------------
            listClassementGeneralItem.Clear();

            //---------------------
            //- Update classement -
            //---------------------
            // Iterate thraugh classement file item
            foreach (ClassementGeneralFileItem item in listClassementGeneralFileItem)
            {
                // Manage item
                ManageClassementFromFileItem(item.Classement);

                // Update item

                item.IsUpToDate = true;
            }

            //-------------------------
            //- Set number of tournoi -
            //-------------------------
            // Get number of tournois
            int nbTournois = listClassementGeneralFileItem.Count;

            // Iterate thraugh classement item
            foreach (ClassementGeneralItem item in listClassementGeneralItem)
            {
                item.NombreTournois = (uint)nbTournois;
            }

            // Up to dat classement
            IsUpToDate = true;
        }

        /// <summary>
        /// Manage classement from file item
        /// </summary>
        /// <param name="classItem"></param>
        protected void ManageClassementFromFileItem(Classement classement)
        {
            // Loop thraugh classemeent item
            int classPos = 1;
            foreach (ClassementItem classItem in classement)
            {
                // Check if joueur already add
                ClassementGeneralItem classGenItem = ListClassementGeneralItem.GetClassementItemFromJoueurId(classItem.Joueur.Id);

                // Check if player already added
                if (classGenItem == null)
                {
                    // Create new class gen item from classement item
                    classGenItem = new ClassementGeneralItem(classItem, classPos);

                    // Add new classement general item
                    ListClassementGeneralItem.Add(classGenItem);
                }
                else
                {
                    // Update classement
                    classGenItem.UpdateClassement(classItem, classPos);
                }

                // Update value
                classPos++;
            }
        }

        #endregion Generate classement
    }
}
