using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PlayStationData
{
    public class ClassementGeneralFileItem
    {
        #region fields

        /// <summary>
        /// Check if current tournoi
        /// </summary>
        private bool isCurrentTournoi = false;

        public bool IsCurrentTournoi
        {
            get { return isCurrentTournoi; }
            set { isCurrentTournoi = value; }
        }

        /// <summary>
        /// Full path name (path + file name)
        /// </summary>
        private string fullPathName;

        public string FullPathName
        {
            get { return fullPathName; }
            set
            {
                // If current clasement
                if (isCurrentTournoi)
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        fileName = "Classement du tournoi en cours";
                    }
                    else
                    {
                        // Get name
                        fileName = Path.GetFileName(value);
                    }
                }
                else
                {
                    // Get name
                    fileName = Path.GetFileName(value);
                }

                // Check if file exist
                fullPathName = value;
            }
        }

        /// <summary>
        /// File name
        /// </summary>
        private string fileName;

        public string FileName
        {
            get { return fileName; }
        }

        /// <summary>
        /// Is up to date
        /// </summary>
        private bool isUpToDate;

        public bool IsUpToDate
        {
            get { return isUpToDate; }
            set { isUpToDate = value; }
        }

        /// <summary>
        /// Classement
        /// </summary>
        private Classement _classement = new Classement();
        public Classement Classement
        {
            get {
                return _classement;
            }
            set {
                // Sort vclassement
                value.Sort();

                // Assign value
                _classement = value;
            }
        }

        #endregion fields

        #region constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClassementGeneralFileItem()
        {
            isCurrentTournoi = false;
            fileName = "";
            fullPathName = "";
        }

        /// <summary>
        /// Constructor with full file name
        /// </summary>
        /// <param name="fullfileName"></param>
        /// <param name="bEqualToCurrentTournoi"></param>
        public ClassementGeneralFileItem(string fullfileName, bool currentTournoi = false)
        {
            // Set value
            isCurrentTournoi = currentTournoi;
            FullPathName = fullfileName;

            // Load classemet from file
            if (!currentTournoi)
                InitClassementByLoadingFile(fullfileName);
        }

        #endregion constructors

        #region Private services

        /// <summary>
        /// Check if full file name is valid
        /// </summary>
        /// <param name="fullFileName"></param>
        protected void CheckFullFileName(string fullFileName)
        {
            // Check param
            if (String.IsNullOrEmpty(fullFileName))
                throw (new ApplicationException("Impossible de créer l'objet ClassementGeneralItem (Parametre null)"));

            // Check extension
            string fileExtension = Path.GetExtension(fullFileName);
            if (!String.Equals(fileExtension, ".xml", StringComparison.OrdinalIgnoreCase))
                throw (new ApplicationException(String.Format("Impossible d'ajouter le fichier {0} ({1} Extension invalide)", fullFileName, fileExtension)));

            // Check full file name
            if (!File.Exists(fullFileName))
                throw (new FileNotFoundException(String.Format("Impossible d'ajouter le fichier {0} (Fichier introuvable)", fullFileName)));
        }

        protected void InitClassementByLoadingFile(string fullFileName)
        {
            // Load classement from file
            // Serialization
            System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
            using (TextReader w = new StreamReader(fullFileName))
            {
                Tournois tournoi = (Tournois)s.Deserialize(w);
                Classement = tournoi.ClassementTournois;
            }
        }

        #endregion Private services
    }
}
