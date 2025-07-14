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
    public partial class ConfigurationForm : TournoisBaseForm
    {
        //Region champs prives
        #region fields

        // Internal boolean to chack if modification done
        bool _listJoueurSaisonChanged = false;

        public bool ListJoueurSaisonChanged
        {
            get { return _listJoueurSaisonChanged; }
            set { _listJoueurSaisonChanged = value; }
        }

        // Ref list
        private JoueursConfigures _joueursConfigures;
        protected JoueursConfigures JoueursConfigures
        {
            get { return _joueursConfigures; }
        }

        //Liste de joueurs
        private Joueurs _joueurs = new Joueurs();
        public Joueurs Joueurs
        {
            get { return _joueurs; }
        }

        //Type de tournois (matchs aller / matchs aller-retour)
        private bool _matchAllerRetour = true;
        public bool MatchAllerRetour
        {
            get { return _matchAllerRetour; }
        }

        /// <summary>
        /// Check if tournoi initialize
        /// </summary>
        bool _btournoiInitialize = false;

        #endregion fields

        //Constructeur / Destructeur
        #region Constructeur / Destructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        #endregion Constructeur / Destructeur

        //Form messages
        #region Form messages

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            //Set collection linked with binding source
            bindingSourceJoueurs.DataSource = _joueurs;

            //Check if tournoi generated
            if (_btournoiInitialize == false)
            {
                //Initilize name
                DateTime date = DateTime.Now;
                textBoxNomTournois.Text = "Tournois Play du " + date.Day + "_" + date.Month + "_" + date.Year;
            }
            else
            {
                //Name
                textBoxNomTournois.Text = _tournoisReference.NomTournois;

                //Type tournoi
                if (_tournoisReference.MatchAllerRetour == true)
                    radioBtnAllerRetour.Checked = true;
                else
                    radioBtnAller.Checked = true;
            }
        }

        /// <summary>
        /// Initialize data to start a tournment
        ///     Delete old data
        ///     Recalculate data
        /// </summary>
        /// <returns></returns>
        public override bool InitializeDataForTournment(ref Tournois tournoisdata)
        {
            //----------------
            //- Check params -
            //----------------
            //Check argument value
            if (tournoisdata == null)
                throw new ApplicationException("Impossible de recuperer la liste des joueurs");

            //---------------------------------
            //- Current tournoi intialization -
            //---------------------------------
            //Set default value
            _tournoisReference = tournoisdata;

            //Get list of players
            _joueurs = new Joueurs();
            _joueurs = _tournoisReference.JoueursTournois;

            //Set collection linked with binding source
            bindingSourceJoueurs.DataSource = _joueurs;

            //Set initialization
            _btournoiInitialize = true;

            return true;
        }
      
        #endregion Form messages

        //Liste joueurs boutons
        #region Liste joueurs boutons

        /// <summary>
        /// Ajout nouveau joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddJoueur_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewPlayerInTournamentFromOfficialList();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ajout joueur(s) tournois");
            }
        }

        /// <summary>
        /// Supprimer un/ou plusieurs joueur(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEffacerJoueur_Click(object sender, EventArgs e)
        {
            //Efface collection
            foreach (DataGridViewRow row in dataGridJoueursTournoi.SelectedRows)
	        {
		        //Delete row
                dataGridJoueursTournoi.Rows.Remove(row);
	        }
         }

        /// <summary>
        /// Supprimer ous les joueurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEffacerAllJoueurs_Click(object sender, EventArgs e)
        {
            //suppression de tous les joueurs
            bindingSourceJoueurs.Clear();
        }

        #endregion Liste joueurs boutons

        //Datagrid manipulation
        #region Datagrid manipulation

        /// <summary>
        /// Click to sort ramdomly list of players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortListPlayersTournois_Click(object sender, EventArgs e)
        {
            // Sort list
            SortPlayerListRandomly();
        }

        /// <summary>
        /// Destruction de ligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueurs_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Update row number (player number)
            for (int i = e.RowIndex; i < dataGridJoueursTournoi.Rows.Count; i++)
			{
                //Set new number
                _joueurs[i].Numero = i+1;
            }
        }

        /// <summary>
        /// Alow to Enable /Disable Effacer bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueurs_SelectionChanged(object sender, EventArgs e)
        {
            //check if rows selected
            if (dataGridJoueursTournoi.SelectedRows.Count > 0)
                btnEffacerJoueur.Enabled = true;
            else
                btnEffacerJoueur.Enabled = false;
        }

        /// <summary>
        /// this method overrides the DataGridView's RowPostPaint event 
        /// in order to automatically draw numbers on the row header cells
        /// and to automatically adjust the width of the column containing
        /// the row header cells so that it can accommodate the new row
        /// numbers,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueurs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Add number in header row
            AddNumberInHeaderRow(e, dataGridJoueursTournoi);
        }

        #endregion Datagrid manipulation

        //Public services
        #region Protected services

        /// <summary>
        /// Add new player in curreent tournament player list from season player list selected
        /// </summary>
        /// <returns></returns>
        protected void AddNewPlayerInTournamentFromOfficialList()
        {
            // Iterate thraugh season plyaers selection
            string errMessage = null;
            foreach (DataGridViewRow item in dataGridJoueursSaison.SelectedRows)
            {
                // Get object
                Joueur playerToAdd = (Joueur)dataGridJoueursSaison.Rows[item.Index].DataBoundItem;

                // Check error
                if (playerToAdd != null)
                {
                    // Check if object already added
                    bool bValidJoueur = _joueurs.IsValidPlayer(playerToAdd, false);

                    if (bValidJoueur)
                    {
                        //Add joueur
                        _joueurs.AddNewPlayer(playerToAdd, false);
                    }
                    else
                    {
                        // Check if error already added
                        if (!String.IsNullOrEmpty(errMessage))
                            errMessage += "\n";

                        // Format message
                        string lineMessage = String.Format("Le joueur {0} n'a pas été ajouté car il est déjà présent", playerToAdd.Nom);
                        errMessage += lineMessage;
                    }
                }
            }

            // Update data grid view
            bindingSourceJoueurs.ResetBindings(false);

            // Display error
            if (!String.IsNullOrEmpty(errMessage))
                throw new ApplicationException(errMessage);
        }

        //Public services
        #endregion Protected services

        //Public services
        #region Public services

        /// <summary>
        /// Sort randomly player list
        /// </summary>
        public void SortPlayerListRandomly()
        {
            // Sort list
            _joueurs.SortRandomlyListOfPlayers();

            // Update data grid
            bindingSourceJoueurs.ResetBindings(false);
        }

        /// <summary>
        /// Get tournement name
        /// </summary>
        /// <returns></returns>
        public string NomTournois()
        {
            //Return name
            return textBoxNomTournois.Text;
        }

        /// <summary>
        /// Validate configuration
        /// </summary>
        /// <param name="strErrorMessage"></param>
        /// <returns></returns>
        public bool ValidateConfiguration()
        {
            //Check name
            if (textBoxNomTournois.Text.Length == 0)
                throw new ApplicationException("Vous devez entrer un nom de tournoi");

            //Check number of players
            if (_joueurs.Count <= 1)
                throw new ApplicationException("Vous devez ajouter au moins deux joueurs dans la liste des joueurs pour commencer le tournoi");
            
            return true;
        }

        /// <summary>
        /// Check if data change (liste des joueurs)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueurs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Propagate modification
            MainView mainView = GetMainView();
            if (mainView != null)
                mainView.PropagateModification(TypeModification.ModifListJoueurs, true);
        }

        #endregion Public services

        //Tournement type
        #region Tournement type

        /// <summary>
        /// Set value of _matchallerretour according to radio buton value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnAllerRetour_CheckedChanged(object sender, EventArgs e)
        {
            _matchAllerRetour = radioBtnAllerRetour.Checked;
        }

        /// <summary>
        /// Text box modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNomTournois_TextChanged(object sender, EventArgs e)
        {
            //Set modification
            if (_mainView != null)
                _mainView.ProjectModified = true;
        }

        #endregion Tournement type

        #region private service

        /// <summary>
        /// Return main view (playstation form)
        /// </summary>
        /// <returns></returns>
        protected MainView GetMainView()
        {
            return (MainView)MdiParent;
        }

        #endregion private service

        //------------------------
        //- Configuration saison -
        //------------------------

        #region Configuration saison

        /// <summary>
        /// Initialize data to start a tournment
        ///     Delete old data
        ///     Recalculate data
        /// </summary>
        /// <returns></returns>
        public bool InitializeDataForTournment(ref JoueursConfigures joueursConfigures)
        {
            //Check argument value
            if (joueursConfigures == null)
                throw new ApplicationException("Impossible de recuperer la liste des joueurs configurés");

            //Set default value
            _joueursConfigures = joueursConfigures;

            //Set collection linked with binding source
            bindingSourceJoueurSaison.DataSource = joueursConfigures.Joueurs;

            // Initialize new valid id player
            tbxIdJoueurSaison.Text = _joueursConfigures.NewValidId.ToString();

            return true;
        }

        /// <summary>
        /// this method overrides the DataGridView's RowPostPaint event 
        /// in order to automatically draw numbers on the row header cells
        /// and to automatically adjust the width of the column containing
        /// the row header cells so that it can accommodate the new row
        /// numbers,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueursSaison_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Add number in header row
            AddNumberInHeaderRow(e, dataGridJoueursSaison);
        }

        /// <summary>
        /// Alow to Enable /Disable Effacer bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueursSaison_SelectionChanged(object sender, EventArgs e)
        {
            //check if rows selected
            if (dataGridJoueursSaison.SelectedRows.Count > 0)
            {
                btnRemoveJoueurSaison.Enabled = true;
                btnAddJoueur.Enabled = true;
            }
            else
            {
                btnRemoveJoueurSaison.Enabled = false;
                btnAddJoueur.Enabled = false;
            }
        }

        /// <summary>
        /// Click to add new year player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddJoueurSaison_Click(object sender, EventArgs e)
        {
            try
            {
                // Add new player
                _joueursConfigures.AddNewPlayer(tbxNomJoueurSaison.Text, tbxTeamJoeurSaison.Text, int.Parse(tbxIdJoueurSaison.Text));

                // Update new player value
                UpdateValueAfterAdd();
            }
            catch (PlayStationException err)
            {
                // Display message
                MessageBox.Show(err.Message, "Ajout nouveau joueur");

                // Set focus
                switch(err.ErrNumber)
                {
                    case Err.invalid_player_name:
                        tbxNomJoueurSaison.Focus();
                        break;
                    case Err.invalid_player_team:
                        tbxTeamJoeurSaison.Focus();
                        break;
                    case Err.invalid_player_id:
                        tbxIdJoueurSaison.Focus();
                        break;
                    default:
                        break;
                }

                return;
            }
            catch (Exception err)
            {
                // Display message
                MessageBox.Show(err.Message, "Ajout nouveau joueur");
            }
        }

        /// <summary>
        /// Suppression joueur(s) saison selectionné(s) dta grid delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueursSaison_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Validation pour destruction joueurs
            e.Cancel = (ValidateSuppressionJoueursSaison() == false);
        }

        /// <summary>
        /// Suppression joueur(s) saison selectionné(s) click button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveJoueurSaison_Click(object sender, EventArgs e)
        {
            // Suppression joueur
            if (ValidateSuppressionJoueursSaison() == true)
            {
                // Remove players
                foreach (DataGridViewRow item in this.dataGridJoueursSaison.SelectedRows)
                {
                    // Remove player
                    dataGridJoueursSaison.Rows.RemoveAt(item.Index);

                    // Set value
                    _listJoueurSaisonChanged = true;
                }
            }
        }

        #endregion Configuration saison

        #region Protected functions

        /// <summary>
        /// Update value after add
        /// </summary>
        protected void  UpdateValueAfterAdd()
        {
            // Update list using binding source
            bindingSourceJoueurSaison.ResetBindings(false);

            // Clean values
            tbxNomJoueurSaison.Text = String.Empty;
            tbxTeamJoeurSaison.Text = String.Empty;

            // Update value
            tbxIdJoueurSaison.Text = _joueursConfigures.NewValidId.ToString();

            // Set value
            _listJoueurSaisonChanged = true;
        }

        /// <summary>
        /// Validation avant suppression des joueurs saison selectionnés
        /// </summary>
        protected bool ValidateSuppressionJoueursSaison()
        {
            // Show validation
            DialogResult dlgRes = MessageBox.Show("Confirmez vous la suppression des joueurw", "Suppression joueur(s) saison", MessageBoxButtons.OKCancel);

            // Check if delete is confirmed
            return (dlgRes == DialogResult.OK);
        }

        #endregion Protected functions

        #region drag and drop

        int cst_drag_from_grid_official_players = 150;
        /// <summary>
        /// Class to manage drag and drop exchange value
        /// </summary>
        public partial class DragAndDropObject : Object
        {
            int dragRefType = 0;

            public int DragRefType
            {
                get { return dragRefType; }
                set { dragRefType = value; }
            }

            int nbRowsSelected = 0;

            public int NbRowsSelected
            {
                get { return nbRowsSelected; }
                set { nbRowsSelected = value; }
            }
        }

        /// <summary>
        /// Event during end of drag and drop to copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueursTournoi_DragDrop(object sender, DragEventArgs e)
        {

            // Check if good data to drop
            if (e.Data.GetDataPresent(typeof(DragAndDropObject)) == true)
            {
                // Get drag and drop object
                DragAndDropObject DragInfo = e.Data.GetData(typeof(DragAndDropObject)) as DragAndDropObject;

                // Check value
                if ((DragInfo.DragRefType == cst_drag_from_grid_official_players) &&
                    (DragInfo.NbRowsSelected > 0))
                {
                    try
                    {
                        AddNewPlayerInTournamentFromOfficialList();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Ajout joueur(s) tournois");
                    }
                }
            }
        }

        /// <summary>
        /// Event received when 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueursTournoi_DragEnter(object sender, DragEventArgs e)
        {
            // Check if good data to drop
            if (e.Data.GetDataPresent(typeof(DragAndDropObject)) == true)
            {
                // Get drag and drop object
                DragAndDropObject DragInfo = e.Data.GetData(typeof(DragAndDropObject)) as DragAndDropObject;

                // Check value
                if ((DragInfo.DragRefType == cst_drag_from_grid_official_players) &&
                    (DragInfo.NbRowsSelected > 0))
                    e.Effect = DragDropEffects.Copy;
            } 
        }

        private void dataGridJoueursTournoi_DragOver(object sender, DragEventArgs e)
        {
            // Check if good data to drop
            if (e.Data.GetDataPresent(typeof(DragAndDropObject)) == true)
            {
                // Get drag and drop object
                DragAndDropObject DragInfo = e.Data.GetData(typeof(DragAndDropObject)) as DragAndDropObject;

                // Check value
                if ((DragInfo.DragRefType == cst_drag_from_grid_official_players) &&
                    (DragInfo.NbRowsSelected > 0))
                    e.Effect = DragDropEffects.Copy;
            } 
        }

        private void dataGridJoueursSaison_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if rows selected
                int rowsSelected = dataGridJoueursSaison.SelectedRows.Count;
                if (rowsSelected > 0)
                {
                    // Create object
                    DragAndDropObject DragInfo = new DragAndDropObject();
                    DragInfo.DragRefType = cst_drag_from_grid_official_players;
                    DragInfo.NbRowsSelected = rowsSelected;

                    // Init drag and drop sequence
                    dataGridJoueursSaison.DoDragDrop(DragInfo, DragDropEffects.Copy);
                }
            }
        }

        #endregion drag and drop
        
    }
}
