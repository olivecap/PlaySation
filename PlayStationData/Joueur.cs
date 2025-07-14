using System;
using System.Collections.Generic;
using System.Text;

namespace PlayStationData
{
    public class Joueur
    {
        #region fields

        //Id
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Numero
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        //Name
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                UpdateNomJoueur();
            }
        }

        //Equipe
        private string _equipe;
        public string Equipe
        {
            get { return _equipe; }
            set 
            { 
                _equipe = value;
                UpdateNomJoueur();
            }
        }

        //nom joueur
        private string _nomComplet;
        public string NomComplet
        {
            get { return _nomComplet; }
        }

        //Update nom joueur affiche
        private void UpdateNomJoueur()
        {
            _nomComplet = _equipe;
            if (!string.IsNullOrEmpty(_nom))
            {
                _nomComplet += " (";
                _nomComplet += _nom;
                _nomComplet += ")";
            }
        }

        #endregion fields

        #region Override function

        /// <summary>
        /// Override string default value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Nom;
        }

        #endregion Override function
    }
}
