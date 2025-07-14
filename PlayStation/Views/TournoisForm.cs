using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PlayStationData;

namespace PlayStation.Views
{
    public partial class TournoisForm : TournoisBaseForm
    {
        //--------------
        //- Constantes -
        //--------------
        #region Constantes

        const int iColNumero = 0;
        const int iColMatchJoue = 1;
        const int iColEquipe1 = 2;
        const int iColResEquipe1 = 3;
        const int iColResEquipe2 = 4;
        const int iColEquipe2 = 5;
        const int iColTV = 6;
        const int iNbCol = 7;

        #endregion Constantes

        //-------------
        //- Variables -
        //-------------
        #region Fields

        /// <summary>
        /// Check if grid already initialize
        /// </summary>
        bool _bGridInitialized = false;

        /// <summary>
        /// Test if fill grid is running
        /// </summary>
        bool _bGridfillRunning = false;

        #endregion fields

        //--------------------------------------
        //- Fonction initialisation de la form -
        //--------------------------------------
        #region Fonction initialisation

        public TournoisForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TournoisForm_Load(object sender, EventArgs e)
        {
            gridTournois.AutoResizeColumns();
        }

        #endregion Fonction initialisation

        //-------------------------
        //- Evenements de la Form -
        //-------------------------
        #region Evenements de la Form

        /// <summary>
        /// Activation of view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TournoisForm_Activated(object sender, EventArgs e)
        {
            //gridTournois.Dock = DockStyle.Fill;

            //Check if tournement data is modified
            if (_bModificationListJoueurs == true)
                FillGrid();
        }

        /// <summary>
        /// Desactivation of view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TournoisForm_Deactivate(object sender, EventArgs e)
        {
            try
            {
                //U^pdate classement
                ForceUpdateClassement();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "UpdateClassement");
            }
        }

        #endregion Evenements de la Form

        //Public services (InitializeDataForTournment, ...)
        #region Public services

        /// <summary>
        /// Initialize data to start a tournment
        ///     Delete old data
        ///     Recalculate data
        /// </summary>
        /// <returns></returns>
        public override bool InitializeDataForTournment(ref Tournois tournoisdata)
        {
            try
            {
                //Check argument value
                if (tournoisdata == null)
                    throw new ApplicationException("Impossible de recuperer la liste des joueurs");

                //Set default value
                _tournoisReference = tournoisdata;

                //fill grid
                FillGrid();       
         
                //Set grid initialized
                _bGridInitialized = true;
            }
            catch (Exception e)
            {
                //display msg
                MessageBox.Show(e.Message, "InitializeDataForTournment");

                //Clear data
                gridTournois.Rows.Clear();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Force update classement
        /// </summary>
        public void ForceUpdateClassement()
        {
            //Test si modification classement
            if (_bModificationclassement == true)
            {
                //Update le classement
                _tournoisReference.UpdateClassement();

                //Propagate modification
                if (_mainView != null)
                    _mainView.PropagateModification(TypeModification.ModifClassement, true);

                //set modif
                _bModificationclassement = false;
            }
        }

        #endregion Public services

        #region Private services

        /// <summary>
        /// Fill new data in grid
        /// </summary>
        void FillGrid()
        {
            try
            {
                //Set fill grid is running
                _bGridfillRunning = true;

                //Delete old value
                gridTournois.Rows.Clear();

                //Loop journeess
                for (int i = 0; i < _tournoisReference.NbJournee; i++)
                {
                    //Get journee
                    //Journee journee = _tournoisReference.JourneesTournois[i];

                    //Add line journee
                    AjoutLigneJournee(_tournoisReference.JourneesTournois[i]);

                    //Loop match par journee
                    for (int j = 0; j < _tournoisReference.JourneesTournois[i].NbMatchsParJournee; j++)
                        AjoutMatchsJournee(_tournoisReference.JourneesTournois[i].ListMatch[j]);
                }

                //Update modification value
                _bModificationListJoueurs = false;

                //Set fill grid is running
                _bGridfillRunning = false;
            }
            catch (Exception e)
            {
                //display msg
                MessageBox.Show(e.Message, "Le remplissage des données est en erreur");

                //Clear data
                gridTournois.Rows.Clear();

                //Set fill grid is running
                _bGridfillRunning = false;
            }
        }

        /// <summary>
        /// Ajout ligne journee
        /// </summary>
        /// <param name="p"></param>
        private void AjoutLigneJournee(Journee journee)
        {
            //Test param
            if (journee == null)
                throw new ApplicationException("Erreur: Journée introuvable");

            //Ajout ligne journee
            int irow = gridTournois.Rows.Add();
            gridTournois.Rows[irow].Cells[iColNumero].Value = "Journee" + journee.NumeroJournee.ToString();
            
            //Change columns type
            //DataGridViewCellStyle p = new DataGridViewCellStyle();
            //p.
            //DataGridViewCell cell = new DataGridViewTextBoxCell();
            //gridTournois.Rows[irow].Cells[iColMatchJoue] = cell;
            //gridTournois.Columns[iColMatchJoue].CellTemplate = cell;

            //Cell in read only
            for (int i = 0; i < iNbCol; i++)
            {
                //Read only mode except for check button
                if (i != iColMatchJoue)
                    gridTournois.Rows[irow].Cells[i].ReadOnly = true;
            }
                  
            //Couleur pour journee aller / retour
            if (journee.JourneeAller == true)
                gridTournois.Rows[irow].DefaultCellStyle.BackColor = Color.Blue;
            else
                gridTournois.Rows[irow].DefaultCellStyle.BackColor = Color.BlueViolet;

            //Alignement
            gridTournois.Rows[irow].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Ajout list de match
        /// </summary>
        /// <param name="journee"></param>
        private void AjoutMatchsJournee(PlayStationData.Match match)
        {
            //Test param
            if (match == null)
                throw new ApplicationException("Erreur: Match introuvable");
            
            //Ajout ligne
            int irow = gridTournois.Rows.Add(match.NumeroMatch, match.MatchJoue, match.JoueurDomicile.NomComplet, match.ResultatMatch.ButJoueurDomicile, match.ResultatMatch.ButJoueurExterieur, match.JoueurExterieur.NomComplet);

            //Specifique management pour joueur exempt
            if (match.JoueurExempt == true)
                ChangeAspectMatchJoueurExempt(irow);
        }

        /// <summary>
        /// Change aspect ligne joueur exempt
        /// </summary>
        private void ChangeAspectMatchJoueurExempt(int irow)
        {
            //iColMatchJoue
            ChangeAspectCellJoueurExempt(irow, iColMatchJoue);

            //iColEquipe1
            ChangeAspectCellJoueurExempt(irow, iColEquipe1);

            //iColResEquipe1
            ChangeAspectCellJoueurExempt(irow, iColResEquipe1);

            //iColResEquipe2
            ChangeAspectCellJoueurExempt(irow, iColResEquipe2);

            //iColEquipe2
            ChangeAspectCellJoueurExempt(irow, iColEquipe2);

            //TV
            ChangeAspectCellJoueurExempt(irow, iColTV);
        }

        /// <summary>
        /// Change aspect cell match joureur exempt
        /// </summary>
        /// <param name="iColEquipe1"></param>
        private void ChangeAspectCellJoueurExempt(int irow, int icol)
        {
            //Get cell
            DataGridViewCell eCell = gridTournois.Rows[irow].Cells[icol];

            //Check cell
            if (eCell == null)
 	            throw new ApplicationException("Cellule invalide");

            //Change style
            eCell.Style.BackColor = Color.LightGray;
            eCell.ReadOnly = true;
        }

        /// <summary>
        /// Check if string contain only numeric value
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool IsNumeric(string strToCheck)
        {
            //Expression reguliere
            return Regex.IsMatch(strToCheck, "^\\d+(\\.\\d+)?$");
        }

        #endregion Private services

        #region Cell validation

        /// <summary>
        /// Occurs when the cell is validating
        /// Valide uniquement des chars numeriques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTournois_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Check if read-only cell
            if (gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                return;

            //Selon column
            switch (e.ColumnIndex)
            {
                //Nombre de but
                case iColResEquipe1:
                case iColResEquipe2:
                    //Check if numeric value
                    if (!IsNumeric(e.FormattedValue.ToString()))
                    {
                        //Selectionne text
                        DataGridViewTextBoxEditingControl editControl = (DataGridViewTextBoxEditingControl)gridTournois.EditingControl;
                        if (editControl != null)
                        {
                            //selects all the text
                            editControl.SelectionStart = 0;
                            editControl.SelectionLength = editControl.Text.Length;
                        }

                        //Display error
                        MessageBox.Show("Vous devez entrer un nombre positif valide");

                        //Cancel service
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Occurs after the cell has finished validating
        /// Reformate le nombre pour enlever les zeros inutiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTournois_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Check if read-only cell
            if (gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                return;

            //Selon column
            switch (e.ColumnIndex)
            {
                //Nombre de but
                case iColResEquipe1:
                case iColResEquipe2:
                    //Cast en int
                    string sCellValue = gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    int i = int.Parse(sCellValue);
                    
                    //Reaffecte la nouvelle valeur
                    if (i.ToString() != sCellValue)
                        gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = i;

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Occurs when cell value changes
        /// Enregistre les modifications dans les données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTournois_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Check if tournoi grid initialize
            if (_bGridInitialized == false)
                return;

            //Check if fill grid is performing
            if (_bGridfillRunning == true)
                return;

            //Check if read-only cell
            if (gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                return;

            //Check si ligne journée ou ligne match
            if (gridTournois.Rows[e.RowIndex].Cells[iColResEquipe1].ReadOnly == true)
            {
                //Get value
                bool bValue = (bool)gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                //Loop sur les match de la journée
                int iNbMatchs = _tournoisReference.NbMatchsJournee;
                for (int iInd = 1; iInd <= iNbMatchs; iInd++)
                {
                    //Check if col in read only (Exempt)
                    if (gridTournois.Rows[e.RowIndex + iInd].Cells[iColMatchJoue].ReadOnly == false)
                        gridTournois.Rows[e.RowIndex + iInd].Cells[iColMatchJoue].Value = bValue;
                }
            }
            else
            {
                //Get indice journee
                int iIndiceJournee = e.RowIndex / (_tournoisReference.NbMatchsJournee + 1);

                //Check indice journee
                if (iIndiceJournee >= _tournoisReference.NbJournee)
                    throw new ApplicationException("Indice journee invalide, update tournoi impossible");

                //Get indice match de la journee
                int iIndiceMatch = int.Parse(gridTournois.Rows[e.RowIndex].Cells[iColNumero].Value.ToString());
                iIndiceMatch -= 1;

                //Selon column
                switch (e.ColumnIndex)
                {
                    //Match joue
                    case iColMatchJoue:
                        {
                            //mise a jour
                            _tournoisReference.JourneesTournois[iIndiceJournee].ListMatch[iIndiceMatch].MatchJoue = (bool)gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                            //Modification
                            _bModificationclassement = true;
                            break;
                        }
                    //Nombre de but
                    case iColResEquipe1:
                        {
                            //mise a jour
                            _tournoisReference.JourneesTournois[iIndiceJournee].ListMatch[iIndiceMatch].ResultatMatch.ButJoueurDomicile = int.Parse(gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                            //Modification
                            _bModificationclassement = true;
                            break;
                        }
                    case iColResEquipe2:
                        {
                            //mise a jour
                            _tournoisReference.JourneesTournois[iIndiceJournee].ListMatch[iIndiceMatch].ResultatMatch.ButJoueurExterieur = int.Parse(gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                            //Modification
                            _bModificationclassement = true;
                            break;
                        }
                    default:
                        break;
                }

                //Set impact modification
                if (_bModificationclassement == true)
                {
                    if (_mainView != null)
                    {
                        _mainView.ProjectModified = true;
                        _mainView.PropagateModification(TypeModification.ModifClassement, true);
                    }
                } 
            }
        }
        #endregion Cell validation                 

        /// <summary>
        /// Occurs when user click in cell
        /// Override method to manage check box cell and fix work around
        /// CellValueChanged for check box cell is only called when you leave cell
        /// Force to call CellValueChanged when check box cell is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTournois_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check if tournoi grid initialize
            if (_bGridInitialized == false)
                return;

            //Check if fill grid is performing
            if (_bGridfillRunning == true)
                return;

            //Check if read-only cell
            if (gridTournois.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                return;

            //Check si ligne journée ou ligne match
            if (gridTournois.Rows[e.RowIndex].Cells[iColResEquipe1].ReadOnly == true)
            {
                gridTournois.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
