#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On   : 20.06.2015
// Created By   : Noble
// Description  : Custom combo box
// ------------------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
   
#endregion

namespace tv.Crystal.UI.CustomControls
{
    public partial class nCombobox : ComboBox
    {
        #region Private Fields

        private static int WM_PAINT = 0x000F;

        #endregion

        #region Constructors

        public nCombobox()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ForeColor = SystemColors.WindowText;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public nCombobox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #endregion

        #region Overriden Methods

        /// <summary>
        /// Change back color of combobox.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                SolidBrush myBrush = new SolidBrush(this.ForeColor);
                e.DrawBackground();
                Graphics g = e.Graphics;
                g.FillRectangle(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                             new SolidBrush(ColorTranslator.FromHtml(CrystalConstants.CONTROL_FOCUS_COLOR)) : new SolidBrush(e.BackColor), e.Bounds);
                if (e.Index >= 0)
                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                }
                base.OnDrawItem(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// For drawing border.
        /// </summary>
        /// <param name="message"></param>
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
                ControlPaint.DrawBorder(g, bounds, Color.Black, ButtonBorderStyle.Solid);
            }
        }
        #endregion        
    }
}
