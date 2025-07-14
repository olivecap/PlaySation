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
    public partial class ClassementForm : ClassementBaseForm
    {
        //-----------------------
        //- Initialisation form -
        //-----------------------
        #region Initialisation form

        public ClassementForm()
        {
            InitializeComponent();
        }
         
        #endregion Initialisation form

        //---------------------
        //- Fonction virtual  -
        //---------------------
        #region Fonction virtual

        ///// <summary>
        ///// Sort classement
        ///// </summary>
        ///// <returns></returns>
        //protected override bool SortClassement()
        //{
        //    //Standard classement sort
        //    _classement.Sort();

        //    return true;
        //}
        
        #endregion Fonction virtual
    }
}
