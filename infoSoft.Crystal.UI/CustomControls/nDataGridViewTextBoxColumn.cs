
using tv.Crystal.Common.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace tv.Crystal.UI.CustomControls
{
    public partial class nDataGridViewTextBoxColumn : DataGridViewTextBoxColumn
    {
        #region Declaration

        private CellContentType _ContentType;
        private bool _IsNegativeAllowed = false;
        private bool _IsPopupColumn = false;
        private bool _RangeValidate;
        private DateTime _RangeFrom = ActiveUserSession.ServerDateTime;
        private DateTime _RangeTo = ActiveUserSession.ServerDateTime;

        #endregion

        #region Properties

        [Category("Data")]
        [Description("Indicate the expected content type of the cell.")]
        [MonitoringDescription("Indicate the expected content type of the cell.")]
        [DefaultValue(CellContentType.String)]
        public virtual CellContentType CellContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                _ContentType = value;
            }
        }

        [Category("Data")]
        [Description("Indicate whether the content allowed negative number.")]
        [MonitoringDescription("Indicate whether the content allowed negative number.")]
        [DefaultValue(false)]
        public virtual bool IsNegativeAllowed
        {
            get
            {
                return _IsNegativeAllowed;
            }
            set
            {
                _IsNegativeAllowed = value;
            }
        }

        [Category("Behavior")]
        [Description("Indicate whether the column is popup enabled.")]
        [MonitoringDescription("Indicate whether the column is popup enabled.")]
        [DefaultValue(false)]
        public virtual bool IsPopupColumn
        {
            get
            {
                return _IsPopupColumn;
            }
            set
            {
                _IsPopupColumn = value;
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

        #endregion
    }
}
