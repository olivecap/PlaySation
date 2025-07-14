using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayStationData
{
    public class PlayStationException: ApplicationException
    {
        #region fields

        // Ref list
        int _errNumber;

        public int ErrNumber
        {
            get { return _errNumber; }
            set { _errNumber = value; }
        }


        #endregion fields

        #region Constructor

        public PlayStationException(string message): base(message)
        {
            // Set value
            _errNumber = Err.default_value;
        }

        public PlayStationException(string message, int errNumber): base(message)
        {
            // Set value
            _errNumber = errNumber;
        }


        #endregion Constructore
    }
}
