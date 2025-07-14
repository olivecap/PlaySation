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
    public partial class GeneralSelectionFileForm : TournoisBaseForm
    {
        //Region champs prives
        #region fields

        /// <summary>
        /// List of classement items
        /// </summary>
        protected ClassementGeneral classementGeneral;

        public ClassementGeneral ClassementGeneral
        {
            get { return classementGeneral; }
            set { classementGeneral = value; }
        }
        
        #endregion fields

        //Constructeur / Destructeur
        #region Constructeur / Destructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public GeneralSelectionFileForm()
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

            // Set value
            classementGeneral = tournoisdata.ClassementGeneral;
            checkBoxTournoiClassement.Checked = classementGeneral.IsCurrentClassementAdded;
            
            // Set collection linked with binding source
            bindingSourceClassementItems.DataSource = classementGeneral.ListClassementGeneralFileItem;
            
            return true;
        }

        /// <summary>
        /// Return main view (playstation form)
        /// </summary>
        /// <returns></returns>
        protected MainView GetMainView()
        {
            return (MainView)MdiParent;
        }
      
        #endregion Form messages

        #region Gestion controls

        /// <summary>
        /// Ajout fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Open dialog file
                OpenFileDialog openFileDialog = new OpenFileDialog();

                //Initialize save file dialog
                openFileDialog.InitialDirectory = Application.ExecutablePath;
                openFileDialog.Filter = "Text Files (*.xml)|*.xml";
                openFileDialog.Multiselect = true;
                openFileDialog.CheckFileExists = true;

                // Display dialog
                string errMessage = null;
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Iterate thraugh selection
                    foreach (string item in openFileDialog.FileNames)
                    {
                        try
                        {
                            // Check if current file
                            MainView mainView = GetMainView();
                            if (mainView != null)
                            {
                                if (String.Equals(mainView.FilePath, item, StringComparison.OrdinalIgnoreCase))
                                    throw new ApplicationException(String.Format("Impossible d'ajouter le fichier {0} (Fichier du tournois en cours)", item));
                            }

                            // Add item
                            ClassementGeneralFileItem newItem = new ClassementGeneralFileItem(item);
                            classementGeneral.ListClassementGeneralFileItem.Add(newItem);
                        }
                        catch (Exception err)
                        {
                            // Add line
                            if (!String.IsNullOrEmpty(errMessage))
                                errMessage += "\n";

                            // Add new error
                            errMessage += err.Message;
                        }
                    }

                    // Check error
                    if (!String.IsNullOrEmpty(errMessage))
                        throw new ApplicationException(errMessage);

                    // Update data binding
                    bindingSourceClassementItems.ResetBindings(false);
                    GetMainView().PropagateModification(TypeModification.ClassementItemFileUpToDate, false);
                }
            }
            catch (Exception err)
            {
                // Display message
                MessageBox.Show(err.Message, "Erreur ajout fichier(s)");
            }
        }

        /// <summary>
        /// Effacer fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEffacerFile_Click(object sender, EventArgs e)
        {
            //Efface collection
            foreach (DataGridViewRow row in dataGridFiles.SelectedRows)
            {
                // Check if contain current project
                ClassementGeneralFileItem item = row.DataBoundItem as ClassementGeneralFileItem;
                if (item.IsCurrentTournoi)
                    checkBoxTournoiClassement.Checked = false;

                //Delete row
                dataGridFiles.Rows.Remove(row);
            }

            // Update data binding
            GetMainView().PropagateModification(TypeModification.ClassementItemFileUpToDate, false);
        }

        /// <summary>
        /// Effacer tous les fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEffacerAllFiles_Click(object sender, EventArgs e)
        {
            // Remove selection current tournoi
            checkBoxTournoiClassement.Checked = false;

            // Remove rows
            bindingSourceClassementItems.Clear();
            GetMainView().PropagateModification(TypeModification.ClassementItemFileUpToDate, false);
        }

        /// <summary>
        /// Linked with check box property Auto check = false
        /// Allow to validate modification state and cancel modif
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTournoiClassement_Click(object sender, EventArgs e)
        {
            try
            {
                // Add current tournoi
                if (!checkBoxTournoiClassement.Checked)
                {
                    // Ajout classement tournoi courant
                    AddCurrentClassement();

                    // Change value
                    checkBoxTournoiClassement.Checked = true;
                    classementGeneral.IsCurrentClassementAdded = true;
                }
                else
                {
                    // Delete classement tournoi courant
                    DeleteCurrentClassement();

                    // Change value
                    checkBoxTournoiClassement.Checked = false;
                    classementGeneral.IsCurrentClassementAdded = false;
                }

                // Update view
                bindingSourceClassementItems.ResetBindings(false);
                GetMainView().PropagateModification(TypeModification.ClassementItemFileUpToDate, false);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erreur durant l'ajout du nouveau tournoi courant");
            }
        }

        #endregion Gestion controls

        #region Gestion classement

        /// <summary>
        /// Add current tournoi classement
        /// </summary>
        protected void AddCurrentClassement()
        {
            // Get parameters
            Classement currentClassement = GetMainView().TournoisData.ClassementTournois;
            String fullFileName = GetMainView().FilePath;

            // Create new object
            ClassementGeneralFileItem newItem = new ClassementGeneralFileItem(fullFileName, true);

            // Set param
            newItem.Classement = currentClassement;

            // Add object
            classementGeneral.ListClassementGeneralFileItem.Add(newItem);
        }

        /// <summary>
        /// Delete current tournoi classement
        /// </summary>
        protected void DeleteCurrentClassement()
        {
            // Add object
            classementGeneral.ListClassementGeneralFileItem.DeleteCurrentClassement();
        }

        #endregion Gestion controls

        #region Data grid manipulation

        /// <summary>
        /// Selection chage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridFiles_SelectionChanged(object sender, EventArgs e)
        {
            //check if rows selected
            if (dataGridFiles.SelectedRows.Count > 0)
            {
                btnEffacerFile.Enabled = true;
                btnEffacerAllFiles.Enabled = true;
            }
            else
            {
                btnEffacerFile.Enabled = false;
                btnEffacerAllFiles.Enabled = false;
            }
        }

        #endregion Data grid manipulation

        #region Update value

        /// <summary>
        /// Receive modification
        /// </summary>
        /// <param name="modiType"></param>
        /// <param name="value"></param>
        public override void PropagateModificaion(TypeModification modiType, bool value)
        {
            // Base class for feneric mngt
            base.PropagateModificaion(modiType, value);

            // Specific management
            if (modiType == TypeModification.TournoiGenerated)
            {
                btnAddFile.Enabled = value;
                checkBoxTournoiClassement.Enabled = value;
            }
            else if (modiType == TypeModification.ModifClassement)
            {
                classementGeneral.ListClassementGeneralFileItem.UpToDateCurrentClassement(!value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modiType"></param>
        /// <param name="value"></param>
        public override void PropagateModificaion(TypeModification modiType, string value)
        {
            // Base class for feneric mngt
            base.PropagateModificaion(modiType, value);

            // Check modif type
            if (modiType == TypeModification.ModifUpdateTournoiFileName)
            {
                // Check if current tournaoi is added
                if (checkBoxTournoiClassement.Checked)
                {
                    // Update item
                    classementGeneral.ListClassementGeneralFileItem.UpdateClassementTournoiName(value);

                    // Update view Row removed is receive and has to be blocked
                    bindingSourceClassementItems.ResetBindings(false);
                }
            }
        }

        /// <summary>
        /// Generate classement
        /// </summary>
        public void GenerateClassement()
        {
            // Generate classement
            classementGeneral.GenerateClassement();

            // Update view
            bindingSourceClassementItems.ResetBindings(false);
        }

        #endregion Update value
    }
}


