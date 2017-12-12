#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Constants used in the application
// ------------------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion

#region User directives

#endregion

using System.Drawing;
namespace tv.Crystal.Common.Constants
{
    public class CrystalConstants
    {
        /// <summary>
        /// Connection key for database connectivity
        /// </summary>
        public const string CONNECTION_KEY = "Crystal";
        /// <summary>
        /// Database connection time out
        /// </summary>
        public const int DEFAULT_COMMAND_TIME_OUT = 0;
        /// <summary>
        /// Control focus color
        /// </summary>
        public const string CONTROL_FOCUS_COLOR = "#DAC000";
        /// <summary>
        /// Control normal color
        /// </summary>
        public const string CONTROL_NORMAL_COLOR = "#FFFFFF";
        /// <summary>
        /// Company web site url
        /// </summary>
        public const string tv_WEB_SITE = "";
        /// <summary>
        /// Hight of base form
        /// </summary>
        public const int FORM_HEIGHT = 960;
        /// <summary>
        /// Width of base form
        /// </summary>
        public const int FORM_WIDTH = 1280;
        /// <summary>
        /// Wrong text color
        /// </summary>
        public static Color WRONG_TEXT_COLOR = Color.IndianRed;
        /// <summary>
        /// Normal text color
        /// </summary>
        public static Color NORMAL_TEXT_COLOR = Color.Black;
    }
}
