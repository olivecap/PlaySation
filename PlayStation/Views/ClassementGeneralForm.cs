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
    /// <summary>
    /// Enum to define sort type
    /// </summary>
    public enum SortEnum
    {
        Default,
        Meilleur_Attaque,
        Meilleur_Defense
    }
    public partial class ClassementGeneralForm : TournoisBaseForm
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

        // Constructeurs
        #region construteurs

        public ClassementGeneralForm()
        {
            InitializeComponent();
        }

        #endregion construteurs

        // Generic services
        #region generic services

        private void ClassementGeneralBaseForm_Load(object sender, EventArgs e)
        {
            // Set collection linked with binding source
            bindingSourceClassementGeneral.DataSource = classementGeneral.ListClassementGeneralItem;

            // Default classement
            SortClassement(SortEnum.Default);
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
                throw new ApplicationException("Impossible de recuperer le classement general");

            // Set value
            classementGeneral = tournoisdata.ClassementGeneral;

            // Set collection linked with binding source
            bindingSourceClassementGeneral.DataSource = classementGeneral.ListClassementGeneralItem;

            // Customiz data grid
            CustomizedDatagrid();

            //----------------------------------------------------------
            //- Update liste of tounoi taken into account in class gen -
            //----------------------------------------------------------
            UpdateListOfTournoi();

            return true;
        }

        /// <summary>
        /// Activation form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassementGeneralBaseForm_Activated(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sort classement
        /// </summary>
        virtual public void SortClassement(SortEnum enSortType)
        {
            // Check parameter
            if (classementGeneral == null)
                return;

            // Default sort classment
            switch (enSortType)
            {
                case SortEnum.Meilleur_Attaque:
                    //Sort par meilleur attaque
                    IComparer<ClassementGeneralItem> ComparerClassementParMeilleurAttaque = new SortClassementGeneralParMeilleurAttaque();
                    classementGeneral.ListClassementGeneralItem.Sort(ComparerClassementParMeilleurAttaque);
                    break;
                case SortEnum.Meilleur_Defense:
                    //Sort par meilleur attaque
                    IComparer<ClassementGeneralItem> ComparerClassementParMeilleurDefense = new SortClassementGeneralParMeilleurDefense();
                    classementGeneral.ListClassementGeneralItem.Sort(ComparerClassementParMeilleurDefense);
                    break;
                default:
                    // Default sort
                    classementGeneral.ListClassementGeneralItem.Sort();
                    break;
            }

            //Update value 
            bindingSourceClassementGeneral.ResetBindings(false);
        }

        #endregion generic services

        #region Override functions

        /// <summary>
        /// Classement modification event
        /// </summary>
        /// <param name="modifType"></param>
        /// <param name="value"></param>
        public override void PropagateModificaion(TypeModification modifType, bool value)
        {
            // Basis servie
            base.PropagateModificaion(modifType, value);

            // Hide/Show label
            if (modifType == TypeModification.ClassementItemFileUpToDate)
            {
                //-----------------------------
                //- Update classement general -
                //-----------------------------
                UpdateControlsAfterModif(value);
            }
            else if (modifType == TypeModification.ModifClassement)
            {
                // Hide/show text to notify modif
                lblClassGenModified.Visible = value;
            }
        }

        /// <summary>
        /// Update controls after modificationor up to date
        /// </summary>
        /// <param name="modified"></param>
        protected void UpdateControlsAfterModif(bool upToDate)
        {
            //-----------------------------
            //- Update classement general -
            //-----------------------------
            // Update content
            if (upToDate == true)
            {
                // Update binding source
                bindingSourceClassementGeneral.ResetBindings(false);

                //----------------------------------------------------------
                //- Update liste of tounoi taken into account in class gen -
                //----------------------------------------------------------
                UpdateListOfTournoi();

                // Show text to notify modif
                lblClassGenModified.Visible = false;
            }
            else
                // Hide text to notify modif
                lblClassGenModified.Visible = true;
        }

        /// <summary>
        /// Update list of tournoi
        /// </summary>
        protected void UpdateListOfTournoi()
        {
            //----------------------------------------------------------
            //- Update liste of tounoi taken into account in class gen -
            //----------------------------------------------------------
            // Update combo content
            FillCombobox();

            // Select combobox
            if (comboSelectTournoi.Items.Count > 0)
                comboSelectTournoi.SelectedIndex = 0;
            else
            {
                bindingSourceClassementTournoi.DataSource = null;
                bindingSourceClassementTournoi.ResetBindings(false);
            }
        }
        #endregion Override functions

        #region Datagrid customization services

        protected void CustomizedDatagrid()
        {
        }

        #endregion Datagrid customization services

        //--------------------------
        //- Services events grille -
        //--------------------------
        #region Datagrid event service

        /// <summary>
        /// this method overrides the DataGridView's RowPostPaint event 
        /// in order to automatically draw numbers on the row header cells
        /// and to automatically adjust the width of the column containing
        /// the row header cells so that it can accommodate the new row
        /// numbers,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewClassGen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Add number in header row
            AddNumberInHeaderRow(e, dataGridViewClassGen);

            
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
        private void dataGridViewClass_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Add number in header row
            AddNumberInHeaderRow(e, dataGridViewClass);
        }

        #endregion Datagrid event service

        #region Combo box Selection tournoi

        /// <summary>
        /// Fill combo box
        /// </summary>
        protected void FillCombobox()
        {
            //  Check param
            if (classementGeneral == null)
                return;

            // Clear value
            comboSelectTournoi.Items.Clear();

            // Iterate thraugh selection file
            foreach (ClassementGeneralFileItem item in classementGeneral.ListClassementGeneralFileItem)
            {
                // Check if current project
                comboSelectTournoi.Items.Add(item.FileName);
            }
        }

        /// <summary>
        /// Combo box selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboSelectTournoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get index
            int index = comboSelectTournoi.SelectedIndex;

            // Get classement from gen list file item
            Classement classTournoi = classementGeneral.ListClassementGeneralFileItem[index].Classement;

            // Set data binding
            bindingSourceClassementTournoi.DataSource = classTournoi;
        }

        #endregion Combo box Selection tournoi

    }
}


