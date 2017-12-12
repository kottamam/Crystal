using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Extensions;

namespace tv.Crystal.UI.CustomControls
{
    public partial class PopupControl : UserControl
    {
        #region Constructor

        public PopupControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public variables

        public string[] SelectedItem;                   //For string the selected row of itmes

        #endregion

        #region Private variables

        bool close = false;                     //Default value is false ie not selected.
        DataTable dtFillPop = null;             // Datatable

        #endregion

        #region Public Methods

        /// <summary>
        /// Method for closing popup
        /// </summary>
        /// <returns></returns>
        public bool AcceptPopupClosing()
        {
            try
            {
                //If false popup will be closed.
                if (close == true)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillPopup(DataTable dtFill, int[] count, string popupTitle)
        {
            try
            {
                btnSelect.Left = (Width / 2) - 80;
                btnCancel.Left = (Width / 2) + 5;
                lblPopupTitle.Text = popupTitle;             //Popup title
                dtFillPop = new DataTable();
                dtFillPop = dtFill;
                dgvPopup.DataSource = null;
                dgvPopup.Columns.Clear();
                dgvPopup.Rows.Clear();
                dgvPopup.RowTemplate.Height = 21;
                dgvPopup.DataSource = dtFillPop;
                if (dgvPopup.Rows.Count > 0)
                {
                    int i = 0;
                    for (; i < count.Length; i++)
                    {
                        dgvPopup.Columns[i].Width = count[i];
                        dgvPopup.Columns[i].Visible = true;
                        dgvPopup.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (count[i] == 0)
                        {
                            dgvPopup.Columns[i].Visible = false;
                        }
                    }
                    for (int gridrowcount = i; gridrowcount < dgvPopup.Columns.Count; gridrowcount++)
                    {
                        dgvPopup.Columns[gridrowcount].Visible = false;
                    }
                }
                else
                {
                    btnCancel.Focus();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }


        public void FillImagePopup(DataTable dtFill, int[] count, string popupTitle)
        {
            try
            {
                btnSelect.Left = (Width / 2) - 80;
                btnCancel.Left = (Width / 2) + 5;
                lblPopupTitle.Text = popupTitle;             //Popup title
                dtFillPop = new DataTable();
                dtFillPop = dtFill;
                if (dtFillPop.Rows.Count > 0)
                {
                    dgvPopup.DataSource = null;
                    dgvPopup.Columns.Clear();
                    dgvPopup.Rows.Clear();
                    dgvPopup.RowTemplate.Height = 50;
                    foreach (DataColumn column in dtFillPop.Columns)
                    {
                        if (column.DataType == typeof(byte[]))
                        {
                            DataGridViewImageColumn dynamicColumn = new DataGridViewImageColumn();
                            dynamicColumn.Name = column.ColumnName.Split(' ')[0];
                            dynamicColumn.HeaderText = column.ColumnName;
                            dynamicColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            dgvPopup.Columns.Add(dynamicColumn);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn dynamicColumn = new DataGridViewTextBoxColumn();
                            dynamicColumn.Name = column.ColumnName.Split(' ')[0];
                            dynamicColumn.HeaderText = column.ColumnName;
                            dgvPopup.Columns.Add(dynamicColumn);
                        }
                    }
                    int columnIndex = 0;
                    foreach (DataRow row in dtFillPop.Rows)
                    {
                        dgvPopup.Rows.Add();
                        columnIndex = 0;
                        foreach (object column in row.ItemArray)
                        {
                            if (column.GetType() == typeof(byte[]))
                            {
                                byte[] image = (byte[])column;
                                if (image.Length > 0)
                                {
                                    dgvPopup[columnIndex, dtFillPop.Rows.IndexOf(row)].Value = Utilities.ConvertByteToImage((byte[])column);
                                }
                            }
                            else
                            {
                                dgvPopup[columnIndex, dtFillPop.Rows.IndexOf(row)].Value = column.ToString();
                            }
                            columnIndex++;
                        }
                    }
                    int i = 0;
                    for (; i < count.Length; i++)
                    {
                        dgvPopup.Columns[i].Width = count[i];
                        dgvPopup.Columns[i].Visible = true;
                        dgvPopup.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (count[i] == 0)
                        {
                            dgvPopup.Columns[i].Visible = false;
                        }
                    }
                    for (int gridrowcount = i; gridrowcount < dgvPopup.Columns.Count; gridrowcount++)
                    {
                        dgvPopup.Columns[gridrowcount].Visible = false;
                    }
                }
                else
                {
                    btnCancel.Focus();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// Cancel button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                close = false; //To close popup
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Select button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedItem = new string[dgvPopup.Columns.Count];
                int rowindex = dgvPopup.CurrentCell.RowIndex;
                for (int i = 0; i < dgvPopup.Columns.Count; i++)
                {
                    SelectedItem[i] = (dgvPopup[i, rowindex].Value ?? string.Empty).ToString();
                }
                close = false; //To close popup
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Grid Events

        /// <summary>
        /// Grid keydown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGrid_KeyDown(object sender, KeyEventArgs e)
        {
            //Checking if the enter key is pressed.
            if (e.KeyCode == Keys.Enter)
            {
                btnSelect.PerformClick();
            }
            //Checking if escape key is pressed.
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick(); //to close the popup
            }
        }

        /// <summary>
        /// Grid Cell Double Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSelect.PerformClick();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
