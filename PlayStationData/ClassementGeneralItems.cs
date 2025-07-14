using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class ClassementGeneralItems: List<ClassementGeneralItem>
    {
        #region Public services

        /// <summary>
        /// Get object contain in list from joueur id
        /// </summary>
        /// <returns></returns>
        public ClassementGeneralItem GetClassementItemFromJoueurId(int id)
        {
            return this.Find(item => item.Joueur.Id == id);
        }
        #endregion Public services
    }
}
