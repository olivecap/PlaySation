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
    public partial class ClassementBaseForm : TournoisBaseForm
    {
        //-------------
        //- Variables -
        //-------------
        #region Field

        /// <summary>
        /// Classement variable
        /// </summary>
        protected Classement _classement = new Classement();

        #endregion field

        //---------------------------
        //- Services initialisation -
        //---------------------------
        #region Services initialisation

        public ClassementBaseForm()
        {
            InitializeComponent();
        }

        private void ClassementForm_Load(object sender, EventArgs e)
        {
            //Set collection linked with binding source
            bindingClassementSource.DataSource = _classement;
        }

        /// <summary>
        /// Initialize data to start a tournment
        ///     Delete old data
        ///     Recalculate data
        /// </summary>
        /// <returns></returns>
        public override bool InitializeDataForTournment(ref Tournois tournoisdata)
        {
            //Check argument value
            if (tournoisdata == null)
                throw new ApplicationException("Impossible de recuperer la liste des joueurs");
            
            //Set default value
            _tournoisReference = tournoisdata;

            //Get list of players
            _classement = new Classement();
            _classement = _tournoisReference.ClassementTournois;

            //Check joueurs value
            if ((_classement == null) || (_classement.Count == 0))
                throw new ApplicationException("Impossible de recuperer le classement");

            //Set collection linked with binding source
            bindingClassementSource.DataSource = _classement;

            return true;
        }

        #endregion Services initialisation

        //------------------------
        //- Services events form -
        //------------------------
        #region Services events grille

        /// <summary>
        /// Activation form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassementForm_Activated(object sender, EventArgs e)
        {
        }

        #endregion Services events grille

        //--------------------------
        //- Services events grille -
        //--------------------------
        #region Services events grille

        /// <summary>
        /// this method overrides the DataGridView's RowPostPaint event 
        /// in order to automatically draw numbers on the row header cells
        /// and to automatically adjust the width of the column containing
        /// the row header cells so that it can accommodate the new row
        /// numbers,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewClassement_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Add number in header row
            AddNumberInHeaderRow(e, dataGridViewClassement);
        }

        #endregion Services events grille

        #region generic services

        /// <summary>
        /// Sort classement
        /// </summary>
        virtual public void SortClassement(SortEnum enSortType)
        {
            // Check parameter
            if (_classement == null)
                return;

            // Default sort classment
            switch (enSortType)
            {
                case SortEnum.Meilleur_Attaque:
                    //Sort par meilleur attaque
                    //Sort par meilleur attaque
                    IComparer<ClassementItem> ComparerClassementParMeilleurAttaque = new SortClassementParMeilleurAttaque();
                    _classement.Sort(ComparerClassementParMeilleurAttaque);
                    break;
                case SortEnum.Meilleur_Defense:
                    //Sort par meilleur attaque
                    IComparer<ClassementItem> ComparerClassementParMeilleurDefense = new SortClassementParMeilleurDefense();
                    _classement.Sort(ComparerClassementParMeilleurDefense);
                    break;
                default:
                    // Default sort
                    _classement.Sort();
                    break;
            }

            //Update value 
            bindingClassementSource.ResetBindings(false);
        }

        #endregion generic services
    }
}
