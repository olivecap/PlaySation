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
    public partial class JoueursForm : TournoisBaseForm
    {
        //Joueurs
        Joueurs _joueurs = new Joueurs();

        public JoueursForm()
        {
            InitializeComponent();
        }

        private void JoueursForm_Load(object sender, EventArgs e)
        {
            //Set collection linked with binding source
            bindingListJoueurSource.DataSource = _joueurs;
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
            _joueurs = new Joueurs();
            _joueurs = _tournoisReference.JoueursTournois;

            //Check joueurs value
            if ((_joueurs == null) || (_joueurs.Count == 0))
                throw new ApplicationException("Impossible de recuperer la liste des joueurs");

            //Set collection linked with binding source
            bindingListJoueurSource.DataSource = _joueurs;

            return true;
        }

        private void dataGridJoueurs_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Check if value not null
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridJoueurs.Rows[e.RowIndex].ErrorText =
                    "Vous devez entrez une valeur";
                e.Cancel = true;
            }
        }

        private void dataGridJoueurs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridJoueurs.Rows[e.RowIndex].ErrorText = String.Empty;
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
            AddNumberInHeaderRow(e, dataGridJoueurs);
        }

        /// <summary>
        /// Modification management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridJoueurs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Propagate modification
            if (_mainView != null)
                _mainView.PropagateModification(TypeModification.ModifListJoueurs, true);
        }
    }
}
