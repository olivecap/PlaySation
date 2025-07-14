using PlayStationData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlayStation.Views
{
    public partial class JoueurForm : Form
    {
//------------------------
//- Region champs prives -
//------------------------
#region fields

        //Add ask by user
        private bool _ajouterClicked = false;

        //Joueur
        private Joueur _joueur = new Joueur();
        public Joueur Joueur
        {
            get { return _joueur; }
        } 

#endregion fields

//------------------------------
//- Constructeur / Destructeur -
//------------------------------
#region Constructeur / Destructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public JoueurForm()
        {
            InitializeComponent();
        }

#endregion Constructeur / Destructeur

//-------------------
//- Private methods -
//-------------------
#region Private methods

        /// <summary>
        /// Update player name displayed in all forms
        /// </summary>
        private void UpdateNomComplet()
        {
            //Set entire player name displayed in all forms
            textNomComplet.Text = _joueur.NomComplet;
        }

        /// <summary>
        /// Validate control when user ask OnOK
        /// </summary>
        /// <param name="control"></param>
        /// <param name="stringerror"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool ValidateControl(Control control, string stringerror, FormClosingEventArgs e)
        {
            //Test nom equipe
            if (string.IsNullOrEmpty(control.Text))
            {
                //Display error
                errorProviderNouveauJoueur.SetError(control, stringerror);

                //Set focus
                control.Select();

                //Cancel
                e.Cancel = true;

                //Reset value
                _ajouterClicked = false;

                return false; 
            }

            return true;
        }

#endregion Private methods

//-----------------
//- Form messages -
//-----------------
#region Form messages

        /// <summary>
        /// Ask validation before closing form if OnOk is asked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JoueurForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Validation asked
            if (_ajouterClicked == true)
            {
                //Validate nom equipe
                if (!ValidateControl(textNomEquipe, "Le nom de l'equipe ne peut pas etre null.", e))
                    return;
                
                //Validate nom joueur
                ValidateControl(textNomJoueur, "Le nom du joueur ne peut pas etre null.", e);
            }
        }

        private void JoueurForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Reset error
            errorProviderNouveauJoueur.Clear();
        }

#endregion Form messages

//-------------------
//- Nom joueur mngt -
//-------------------
#region Nom joueur mngt

        /// <summary>
        /// Leave nom joueur
        /// Set player name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomJoueur_Leave(object sender, EventArgs e)
        {
            //Set nouveau nom
            _joueur.Nom = textNomJoueur.Text;

            //Update nom complet
            UpdateNomComplet();
        }

        /// <summary>
        /// Validation nom joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomJoueur_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textNomJoueur.Text))
            {
                //Display error
                errorProviderNouveauJoueur.SetError(textNomJoueur, "Le nom du joueur ne peut pas etre null.");

                //Cancel
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Fin validation nom joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomJoueur_Validated(object sender, EventArgs e)
        {
            //Reset error
            //errorProviderNouveauJoueur.SetError(textNomJoueur, "");
            errorProviderNouveauJoueur.Clear();
        }

#endregion Nom joueur mngt

//-------------------
//- Nom equipe mngt -
//-------------------
#region Nom equipe mngt

        /// <summary>
        /// Leave nom equipe
        /// Set player team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomEquipe_Leave(object sender, EventArgs e)
        {
            //Set nouveau nom
            _joueur.Equipe = textNomEquipe.Text;

            //Update nom complet
            UpdateNomComplet();
        }       

        /// <summary>
        /// Validation nom equipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomEquipe_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textNomEquipe.Text))
            {
                //Display error
                errorProviderNouveauJoueur.SetError(textNomEquipe, "Le nom de l'equipe ne peut pas etre null.");

                //Cancel
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Fin validation nom equipe 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNomEquipe_Validated(object sender, EventArgs e)
        {
            //Reset error
            errorProviderNouveauJoueur.Clear();
        }

#endregion Nom equipe mngt

//------------
//- Add mngt -
//------------
#region Add mngt

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            //Set value
            _ajouterClicked = true;
        }

#endregion Add mngt
    }
}
