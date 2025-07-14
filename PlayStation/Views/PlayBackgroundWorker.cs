using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PlayStation.Views
{
    public enum EnumDoWork
    {
        Default,
        Create_Project,
        Open_project,
        Close_roject,
        Save_project,
        SaveAs_project,
        Generate_classement_general
    }

    public class PlayBackgroundWorker: BackgroundWorker
    {
        #region fields

        private EnumDoWork doWorkType;
        public EnumDoWork DoWorkType
        {
            get
            {
                return doWorkType;
            }

            set
            {
                doWorkType = value;
            }
        }

        #endregion fields

        #region constructor

        public PlayBackgroundWorker(): base()
        {
            DoWorkType = EnumDoWork.Default;
        }

        #endregion constructor


    }
}
