#region Copy Right

// © Copy Right 2015, tv Software Pvt Ltd,  All rights reserved.
// Created 2015 (or earlier)

#endregion Copy Right

#region Code History

// Created On   : 15/06/2015
// Created By   : Nobil M O
// Description  : Custom text box control.
// =======================================
// Modified By  :
// Modified Date:
// Description  :

#endregion Code History

#region Using Directives

using tv.Crystal.Business;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Extensions;
using tv.Crystal.Common.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion Using Directives

namespace tv.Crystal.UI
{
    public partial class nTextBox : TextBox
    {
        #region Declarations

        public event EventHandler TypeChanged;
        private nType _Type;
        private bool select_OnClick;
        private bool _RangeValidate;
        private DateTime _RangeFrom = ActiveUserSession.ServerDateTime;
        private DateTime _RangeTo = ActiveUserSession.ServerDateTime;

        #endregion Declarations

        #region Enum

        [ComVisible(true)]
        public enum nType
        {
            String = 0,
            Number = 1,
            Amount = 2,
            Date = 3
        }

        #endregion Enum

        #region Properties

        [Category("Data")]
        [Description("Indicate the type of data contained in component.")]
        [MonitoringDescription("Indicate the type of data contained in component.")]
        [DefaultValue(nType.String)]
        public virtual nType ContentType
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                OnTypeChanged(EventArgs.Empty);
            }
        }

        [Category("Data")]
        [Description("Indicate whether the contents should be on selected mode or not in mouse click.")]
        [MonitoringDescription("Indicate whether the contents should be on selected mode or not in mouse click.")]
        [DefaultValue(false)]
        public virtual bool Select_OnClick
        {
            get
            {
                return select_OnClick;
            }
            set
            {
                select_OnClick = value;
            }
        }

        [Category("Data")]
        [Description("Indicate whether the contents should be with in the range or not.")]
        [MonitoringDescription("Indicate whether the contents should be with in the range or not.")]
        [DefaultValue(false)]
        public virtual bool RangeValidate
        {
            get
            {
                return _RangeValidate;
            }
            set
            {
                _RangeValidate = value;
            }
        }

        [Category("Data")]
        [Description("Indicate the content value range from.")]
        [MonitoringDescription("Indicate the content value range from.")]
        public virtual DateTime RangeFrom
        {
            get
            {
                return _RangeFrom;
            }
            set
            {
                _RangeFrom = value;
            }
        }

        [Category("Data")]
        [Description("Indicate the content value range to.")]
        [MonitoringDescription("Indicate the content value range to.")]
        public virtual DateTime RangeTo
        {
            get
            {
                return _RangeTo;
            }
            set
            {
                _RangeTo = value;
            }
        }

        #endregion Properties

        #region Constructors

        public nTextBox()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public nTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Trigger on Type property change
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTypeChanged(EventArgs e)
        {
            EventHandler temp = this.TypeChanged;
            // make sure that there is an event handler attached
            if (temp != null)
            {
                temp(this, e);
            }
            if (ContentType == nType.Amount)
            {
                TextAlign = HorizontalAlignment.Right;
                if (Text.Trim() == string.Empty)
                    Text = "0.00";
            }
            else
            {
                TextAlign = HorizontalAlignment.Left;
            }
        }

        #endregion Events

        #region Overriden Methods

        /// <summary>
        /// Change back color of text box on enter
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            try
            {
                SelectAll();
                BackColor = ColorTranslator.FromHtml(CrystalConstants.CONTROL_FOCUS_COLOR);
                base.OnEnter(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Change back color of text box on leave
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            try
            {
                if (ContentType == nType.Date)
                {
                    ActiveUserSession.ServerDateTime = GeneralBLL.GetServerDateAndTime();
                    DateValidation obj = new DateValidation();
                    bool isValid;
                    Text = obj.DateValidationFunction(this.Text, out isValid);
                    if (RangeValidate && Text.Trim().Length > 0)
                    {
                        ValidateRange(Convert.ToDateTime(Text), ref isValid);
                    }
                    if (Text == string.Empty)
                    {
                        ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                        Text = ActiveUserSession.ServerDateTime.ToString("dd-MMM-yyyy");
                    }
                    Tag = Convert.ToDateTime(Text.ToString());
                }
                BackColor = ColorTranslator.FromHtml(CrystalConstants.CONTROL_NORMAL_COLOR);
                base.OnLeave(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converting to decimal values
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValidating(CancelEventArgs e)
        {
            try
            {
                if (ContentType == nType.Amount)
                {
                    Text = Convert.ToDecimal(Text.Trim() == string.Empty || Text.Trim() == "." ? "0" : Text.Trim()).ToString("F");
                }
                base.OnValidating(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Select contents of text box on click
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            try
            {
                if (select_OnClick)
                    SelectAll();
                base.OnClick(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///// <summary>
        ///// To avoid pasing in text box
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <param name="keyData"></param>
        ///// <returns></returns>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if ((keyData == (Keys.Control | Keys.V)))
        //    {

        //        return true;
        //    }


        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        /// <summary>
        /// Convert text to upper case
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (ContentType == nType.Number || ContentType == nType.Amount)
                {
                    NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                    string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
                    string groupSeparator = numberFormatInfo.NumberGroupSeparator;
                    string negativeSign = numberFormatInfo.NegativeSign;

                    string keyInput = e.KeyChar.ToString();

                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter)
                    {
                    }
                    else if (keyInput.Equals(decimalSeparator) && ContentType != nType.Number)
                    {
                        if (Text.Trim().Contains("."))
                        {
                            e.Handled = true;
                            Messages.ShowInformationMessage("Only one '.' is allowded in this field.");
                        }
                    }
                    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
                    {
                    }
                    else
                    {
                        // Swallow this invalid key and beep
                        e.Handled = true;
                    }
                }
                else if(ContentType == nType.Date)
                {
                    ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                }

                base.OnKeyPress(e);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To suppress beep sound on keydown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
                base.OnKeyDown(e);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Overriden Methods

        #region Private Methods

        /// <summary>
        /// Check wether the range with in the range
        /// </summary>
        private void ValidateRange(DateTime dateString, ref bool isValid)
        {
            if (dateString >= RangeFrom && dateString <= RangeTo)
            {
                if (dateString == ActiveUserSession.ServerDateTime.Date)
                {
                    if (isValid)
                    {
                        ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                    }
                    else
                    {
                        ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                    }
                    Text = dateString.ToString("dd-MMM-yyyy");
                }
                else
                {
                    isValid = true;
                    ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                    Text = dateString.ToString("dd-MMM-yyyy");
                }
            }
            else
            {
                isValid = false;
                ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                Text = "";
            }
        }

        #endregion
    }
}
