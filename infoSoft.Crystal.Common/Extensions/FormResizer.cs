#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 20.06.2015
// Created By  : Noble
// Description : Class for define form resizing code
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using System;
using System.Windows.Forms;
using System.Drawing;

#endregion

namespace tv.Crystal.Common.Constants
{
    public class FormResizer
    {
        #region Variables

        float f_HeightRatio = new float();
        float f_WidthRatio = new float();

        #endregion

        #region Public method(ResizeForm)

        /// <summary>
        /// For resizing the form
        /// </summary>
        /// <param name="ObjForm"></param>
        /// <param name="DesignerHeight"></param>
        /// <param name="DesignerWidth"></param>
        public void ResizeForm(Form ObjForm, int DesignerHeight, int DesignerWidth)
        {
            //Specify Here the Resolution Y component in which this form is designed
            //For Example if the Form is Designed at 800 * 600 Resolution then DesignerHeight=600
            int i_StandardHeight = DesignerHeight;
            //Specify Here the Resolution X component in which this form is designed
            //For Example if the Form is Designed at 800 * 600 Resolution then DesignerWidth=800
            int i_StandardWidth = DesignerWidth;
            int i_PresentHeight = Screen.PrimaryScreen.Bounds.Height; // Present Resolution Height
            int i_PresentWidth = Screen.PrimaryScreen.Bounds.Width; // Presnet Resolution Width

            f_HeightRatio = (float)((float)i_PresentHeight / (float)i_StandardHeight);
            f_WidthRatio = (float)((float)i_PresentWidth / (float)i_StandardWidth);

            ObjForm.AutoScaleMode = AutoScaleMode.None; // Make the Autoscale Mode=None
            ObjForm.Scale(new SizeF(f_WidthRatio, f_HeightRatio));

            // To change the font of each control in the screen
            foreach (Control c in ObjForm.Controls)
            {
                if (c.HasChildren)
                {
                    ResizeControlStore(c);
                }
                else
                {
                    c.Font = new Font(c.Font.FontFamily, c.Font.Size * f_HeightRatio, c.Font.Style, c.Font.Unit, ((byte)(0)));
                }
            }

            // To change the font of the form (screen)
            ObjForm.Font = new Font(ObjForm.Font.FontFamily, ObjForm.Font.Size * f_HeightRatio, ObjForm.Font.Style, ObjForm.Font.Unit, ((byte)(0)));
        }

        #endregion

        #region Private method(ResizeControlStore)

        /// <summary>
        /// This Function is Used to Change the Font of Controls that are Nested in Other Controls.
        /// </summary>
        /// <param name="objCtl"></param>
        private void ResizeControlStore(Control objCtl)
        {
            if (objCtl.HasChildren)
            {
                foreach (Control cChildren in objCtl.Controls)
                {
                    if (cChildren.HasChildren)
                    {
                        ResizeControlStore(cChildren);
                    }
                    else
                    {
                        cChildren.Font = new Font(cChildren.Font.FontFamily, cChildren.Font.Size * f_HeightRatio, cChildren.Font.Style, cChildren.Font.Unit,
                            ((byte)(0)));
                    }
                }

                objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
            }
            else
            {
                objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
            }
        }

        #endregion
    }
}
