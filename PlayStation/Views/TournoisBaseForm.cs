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
    public partial class TournoisBaseForm : Form
    {
        //-------------
        //- Variables -
        //-------------
        #region Field

        /// <summary>
        /// Poiteur sur la fenetre mere
        /// </summary>
        protected MainView _mainView = null;

        /// <summary>
        /// Reference sur l'element tournois global
        /// </summary>
        protected Tournois _tournoisReference = new Tournois();

        //Gestion Modification liste joueurs
        protected bool _bModificationListJoueurs = false;
        public bool ModificationListJoueur
        {
            get { return _bModificationListJoueurs; }
            set { _bModificationListJoueurs = value; }
        }

        //
        /// <summary>
        /// Gestion Modification classement
        /// </summary>
        protected bool _bModificationclassement = false;
        public bool Modificationclassement
        {
            get { return _bModificationclassement; }
            set { _bModificationclassement = value; }
        }

        #endregion Field

        //------------------
        //- Initialisation -
        //------------------
        #region Initialisation

        public TournoisBaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize data to start a tournment
        ///     Delete old data
        ///     Recalculate data
        /// </summary>
        /// <returns></returns>
        public virtual bool InitializeDataForTournment(ref Tournois tournoisdata)
        {
            return true;
        }

        private void TournoisBaseForm_Load(object sender, EventArgs e)
        {
            //Set main view variable
            if (_mainView == null)
                _mainView = (MainView)MdiParent;
        }

        #endregion Initialisation

        /// <summary>
        /// Ajout numero en en tete de ligne
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dataGrid"></param>
        protected void AddNumberInHeaderRow(DataGridViewRowPostPaintEventArgs e, DataGridView dataGrid)
        {
            //store a string representation of the row number in 'strRowNumber'
            string strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            while (strRowNumber.Length < dataGrid.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, dataGrid.Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (dataGrid.RowHeadersWidth < (int)(size.Width + 20)) dataGrid.RowHeadersWidth = (int)(size.Width + 20);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            Brush b = SystemBrushes.ControlText;

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, dataGrid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        #region Public basic service

        /// <summary>
        /// Propagate modification
        /// </summary>
        /// <param name="modifType"></param>
        /// <param name="value"></param>
        virtual public void PropagateModificaion(TypeModification modifType, bool value)
        {
            if (modifType == TypeModification.ModifClassement)
            {
                Modificationclassement = value;
            }
            else if (modifType == TypeModification.ModifListJoueurs)
            {
                ModificationListJoueur = value;
            }
        }
        
        /// <summary>
        ///  Propagate modification
        /// </summary>
        /// <param name="modiType"></param>
        /// <param name="value"></param>
        virtual public void PropagateModificaion(TypeModification modiType, string value)
        {

        }

        #endregion Public basic service
    }
}
