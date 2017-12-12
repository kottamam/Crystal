#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 14.06.2015
// Created By  : Noble
// Description : Class for define common structure of messages
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace tv.Crystal.Common.Constants
{
    public class Messages
    {
        /// <summary>
        /// Show exception message
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void ShowExceptionMessage(ref Exception ex)
        {
            MessageBox.Show("Error occured.\nError message: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Shows information message
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows confirmation message
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>returns true if yes, otherwise no</returns>
        public static Boolean ShowConfirmation(string message)
        {
            DialogResult result = new DialogResult();

            result = MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Shows confirmation message with a default button
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="button">default button</param>
        /// <returns>True if yes, False if no</returns>
        public static Boolean ShowConfirmation(string message, MessageBoxDefaultButton button)
        {
            DialogResult result = new DialogResult();

            result = MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, button);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            else return false;
        }
    }
}
