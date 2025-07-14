using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class ClassementGeneralFileItems : List<ClassementGeneralFileItem>
    {
        #region Construcor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClassementGeneralFileItems()
        {
        }

        #endregion Construcor

        #region Public services

        public new void Add(ClassementGeneralFileItem item)
        {
            // Check if file name already added
            IsItemAlreadyAdded(item.FullPathName, true);

            // Base class
            base.Add(item);
        }

        /// <summary>
        /// Delete classement courant
        /// </summary>
        public void DeleteCurrentClassement()
        {
            // Find object
            ClassementGeneralFileItem itemToDel = this.Find(item => item.IsCurrentTournoi == true);

            // Delete object
            this.Remove(itemToDel);
        }

        /// <summary>
        /// Update current classeùent
        /// </summary>
        /// <param name="value"></param>
        public void UpToDateCurrentClassement(bool value)
        {
            // Find object
            ClassementGeneralFileItem itemFound = this.Find(item => item.IsCurrentTournoi == true);

            if (itemFound != null)
                itemFound.IsUpToDate = value;
        }

        /// <summary>
        /// Check if joueur already added
        /// </summary>
        /// <param name="joueurToCheck"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool IsItemAlreadyAdded(string fullFileName, bool throwException)
        {
            // Check if name already added
            bool bFound = this.Any(item => String.Equals(item.FullPathName, fullFileName, StringComparison.OrdinalIgnoreCase));

            // Check if found
            if (bFound == true)
            {
                if (throwException == true)
                    throw new PlayStationException(String.Format("Le fichier {0} a déjà été ajouté dans la liste", fullFileName), Err.default_value);
                else
                    return true;
            };

            return false;
        }

        /// <summary>
        /// Update classement name of current torunois
        /// </summary>
        /// <param name="fullFilePath"></param>
        public void UpdateClassementTournoiName(string fullFilePath)
        {
            // Find object
            ClassementGeneralFileItem itemTournoi = this.Find(item => item.IsCurrentTournoi == true);

            // Update name
            itemTournoi.FullPathName = fullFilePath;
        }

        #endregion Public services
    }
}
