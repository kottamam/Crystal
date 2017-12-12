#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 14.07.2015
// Created By   : Noble
// Description  : Class for define utility functions
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using Directives

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#endregion

namespace tv.Crystal.Common.Extensions
{
    public class Utilities
    {
        /// <summary>
        /// Validate decimal number. Allow to enter only valid inputs.
        /// </summary>
        /// <param name="sender">Control</param>
        /// <param name="e">Event</param>
        /// <param name="isNegativeAllowed">Negative number allowed or not</param>
        public static void DecimalValidation(object sender, KeyPressEventArgs e, bool isNegativeAllowed)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                if (e.KeyChar == 46)
                {
                    if (txt.Text.Contains(".") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if (txt.Text == "" || txt.SelectionStart == 0)
                        {
                            txt.Clear();
                            txt.Text = "0.";
                            txt.SelectionStart = txt.Text.Length;
                        }
                        else
                        {
                            txt.Text = txt.Text + ".";
                            txt.SelectionStart = txt.Text.Length;
                        }
                    }
                }
                else if (e.KeyChar == 45 && (isNegativeAllowed))
                {
                    if (txt.Text.Contains("-") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        txt.Clear();
                        txt.Text = "-";
                        txt.SelectionStart = txt.Text.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Convert Image to byte
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns></returns>
        public static byte[] ConvertImageToByte(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            System.Drawing.Imaging.ImageFormat imageFormat = imageIn.RawFormat;
            imageIn.Save(ms, imageFormat);
            return ms.ToArray();
        }

        /// <summary>
        /// Convert Byte to Image
        /// </summary>
        /// <param name="byteImage"></param>
        /// <returns></returns>
        public static System.Drawing.Image ConvertByteToImage(byte[] byteImage)
        {
            MemoryStream stmBLOBData = new MemoryStream(byteImage);  // To save stream image
            Image image = null;		// To save image
            if (stmBLOBData != null)
            {
                image = Image.FromStream(stmBLOBData, false, false);
            }
            return image;
        }
    }
}
