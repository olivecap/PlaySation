using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PlayStation
{
    public interface ITournoiDBRecord
    {
        /// <summary>
        /// Save tournoi data
        /// </summary>
        /// <param name="tournoi"></param>
        /// <returns></returns>
        bool SaveData(Tournois tournoi);

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="tournoi"></param>
        /// <returns></returns>
        bool LoadData(ref Tournois tournoi);
    }

    class TournoiDBRecord : ITournoiDBRecord
    {
        //-------------
        //- Variables -
        //-------------
        #region Variables

        /// <summary>
        /// File path
        /// </summary>
        string _filePath = "";

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        #endregion Variables

        //----------------
        //- Constructeur -
        //----------------
        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="filePath"></param>
        public TournoiDBRecord(string filePath)
        {
            //Set file path
            FilePath = filePath;
        }

        #endregion Constructeur

        //------------------------------
        //- ITournoiDBRecord interface -
        //------------------------------
        #region ITournoiDBRecord Members

        /// <summary>
        /// Save tournoi data
        /// </summary>
        /// <param name="tournoi"></param>
        /// <returns></returns>
        public bool SaveData(Tournois tournoi)
        {
            try
            {
                //Open file
                FileStream file = File.Open(_filePath, FileMode.Create);
                if (file == null)
                    throw new ApplicationException("Fichier de sauvegarde non valide");

                //XML declaration
                
                return true;
            }
            catch (Exception err)
            {
                //Display error
                MessageBox.Show(err.Message, "Save");

                //Return error
                return false;
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="tournoi"></param>
        /// <returns></returns>
        public bool LoadData(ref Tournois tournoi)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
