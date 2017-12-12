#region Copy Right

// © Copy Right 2015, tv Software Pvt Ltd,  All rights reserved.
// Created 2015 (or earlier)

#endregion Copy Right

#region Code History

// Created On   : 04/07/2015
// Created By   : Noble M O
// Description  : Base form control
// =======================================
// Modified By  :
// Modified Date:
// Description  :

#endregion Code History

#region Using Controls

using tv.Crystal.Common.Constants;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace tv.Crystal.UI.CustomControls
{
    public partial class BaseForm : Form
    {
        #region Constructor

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Declarations

        private bool showOnTopLeft = true;
        private bool autoResize = true;
        private bool inheritSize = true;

        #endregion

        #region Properties

        [Category("Appearance")]
        [Description("Indicate whether the form should load on top left or not.")]
        [MonitoringDescription("Indicate whether the form should load on top left or not.")]
        [DefaultValue(true)]
        public virtual bool ShowOnTopLeft
        {
            get
            {
                return showOnTopLeft;
            }
            set
            {
                showOnTopLeft = value;
            }
        }

        [Category("Design")]
        [Description("Indicate whether the form should resize to compatable size with the screen resolution.")]
        [MonitoringDescription("Indicate whether the form should resize to compatable size with the screen resolution.")]
        [DefaultValue(false)]
        public virtual bool AutoResize
        {
            get
            {
                return autoResize;
            }
            set
            {
                autoResize = value;
            }
        }

        [Category("Design")]
        [Description("Indicate whether the form need inherit the size from the base form.")]
        [MonitoringDescription("Indicate whether the form need inherit the size from the base form.")]
        [DefaultValue(true)]
        public virtual bool InheritSize
        {
            get
            {
                return inheritSize;
            }
            set
            {
                inheritSize = value;
            }
        }

        #endregion

        #region Overriden Methods

        /// <summary>
        /// On form load
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if(ShowOnTopLeft)
                {
                    Top = 0;
                    Left = 0;
                }
                //if (InheritSize)
                //{
                //    Width = 1200;
                //    Height = 600;
                //}
                //if(AutoResize)
                //{
                //    GeneralMethods.ResizeForm(this);
                //}
                base.OnLoad(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
