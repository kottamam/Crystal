#region Using Directives

using tv.Crystal.Business;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Extensions;
using tv.Crystal.Common.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace tv.Crystal.UI.CustomControls
{
    public partial class nDataGridView : DataGridView
    {
        #region Overriden Methods

        /// <summary>
        /// This override causes the DataGridView to use the enter key in a similar way as the tab key
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Enter)
            {
                if (base.CurrentCell.OwningColumn.GetType() == typeof(nDataGridViewTextBoxColumn) && ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).IsPopupColumn)
                {
                    KeyEventArgs ee = new KeyEventArgs(keyData);
                    base.OnKeyDown(ee);
                    return true;
                }
                else
                {
                    return this.ProcessRightKey(keyData);
                }
            }
            else if (key == Keys.Back && base.CurrentCell != null)
            {
                if (base.CurrentCell.OwningColumn.CellType.ToString() == "System.Windows.Forms.DataGridViewTextBoxCell" && base.CurrentCell.ReadOnly == false)
                {
                    if (base.CurrentCell.Value == null || base.CurrentCell.Value.ToString() == "")
                    {
                        base.EndEdit();
                        return this.ProcessLeftKey(keyData);
                    }
                    else
                    {
                        base.BeginEdit(true);
                        DataGridViewTextBoxEditingControl editControl = (DataGridViewTextBoxEditingControl)base.EditingControl;
                        if ((editControl != null) && (editControl.Text.Length == 0 || editControl.SelectionStart == 0))
                        {
                            base.EndEdit();
                            return this.ProcessLeftKey(keyData);
                        }
                        else
                        {
                            string str = base.CurrentCell.Value.ToString();
                            if (editControl == null)
                                return this.ProcessLeftKey(keyData);
                            else if (str.Length > 0)
                            {
                            }
                            else
                            {
                                base.EndEdit();
                                return this.ProcessLeftKey(keyData);
                            }
                        }
                    }
                }
                else
                {
                    base.EndEdit();
                    return this.ProcessLeftKey(keyData);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// This causes the DataGridView to make the Enter key move the focus to the right
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public new bool ProcessRightKey(Keys keyData)
        {
            try
            {
                Keys key = (keyData & Keys.KeyCode);
                if (key == Keys.Enter)
                {
                    if (base.CurrentCell != null)
                    {
                        int index = base.CurrentCell.ColumnIndex;
                        if (base.Columns[base.Columns.Count - 1].Visible == false && index == base.Columns[base.Columns.Count - 1].Index - 1)
                        {
                            index++;
                        }
                        else if (index == base.Columns.Count - 3 && !(base.Columns[base.Columns.Count - 2].Visible) && (!base.Columns[base.Columns.Count - 1].Visible))
                        {
                            index += 2;
                        }
                        else if (index == base.Columns.Count - 4 && !(base.Columns[base.Columns.Count - 3].Visible) && !(base.Columns[base.Columns.Count - 2].Visible) && (!base.Columns[base.Columns.Count - 1].Visible))
                        {
                            index += 3;
                        }
                        if (index == (base.ColumnCount - 1) && (base.CurrentCell.RowIndex == (base.RowCount - 1)))
                        {
                            //This causes the last cell to be checked for errors
                            base.EndEdit();
                            if (base.DataSource != null)
                            {
                                ((BindingSource)base.DataSource).AddNew();
                                base.CurrentCell = base.Rows[base.RowCount - 1].Cells[0];
                            }
                            else
                            {
                            }
                            return true;
                        }
                        if (index == base.Columns.Count - 1)
                        {
                            int inCurrRow = base.CurrentCell.RowIndex + 1;
                            while (!base.Rows[inCurrRow].Visible)
                            {
                                if (inCurrRow < base.RowCount - 1)
                                {
                                    inCurrRow++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (inCurrRow < base.RowCount)
                            {
                                int inCurr = 0;
                                while (!base.Rows[inCurrRow].Cells[inCurr].Visible || base.Columns[inCurr].Frozen)
                                {
                                    inCurr++;
                                }
                                base.CurrentCell = base.Rows[inCurrRow].Cells[inCurr];
                                return true;
                            }
                        }
                        return base.ProcessRightKey(keyData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return base.ProcessRightKey(keyData);
            //{
            //    try
            //    {
            //        Keys key = (keyData & Keys.KeyCode);
            //        if (key == Keys.Enter)
            //        {
            //            if ((base.CurrentCell.ColumnIndex == (base.ColumnCount - 1)) && (base.CurrentCell.RowIndex == (base.RowCount - 1)))
            //            {
            //                //This causes the last cell to be checked for errors
            //                base.EndEdit();
            //                ((BindingSource)base.DataSource).AddNew();
            //                base.CurrentCell = base.Rows[base.RowCount - 1].Cells[0];
            //                return true;
            //            }
            //            if (base.CurrentCell.ColumnIndex == base.Columns.Count - 2)
            //            {
            //                if (base.CurrentCell.RowIndex + 1 < base.RowCount)
            //                {
            //                    if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[0].Visible)
            //                    {
            //                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[0];
            //                        return true;
            //                    }
            //                    else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[1].Visible)
            //                    {
            //                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[1];
            //                        return true;
            //                    }
            //                    else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[2].Visible)
            //                    {
            //                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[2];
            //                        return true;
            //                    }
            //                    else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[3].Visible)
            //                    {
            //                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[3];
            //                        return true;
            //                    }
            //                    else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[4].Visible)
            //                    {
            //                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[4];
            //                        return true;
            //                    }
            //                }
            //            }
            //            return base.ProcessRightKey(keyData);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        /// <summary>
        /// This causes the DataGridView to make the Enter key move the focus to the left
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public new bool ProcessLeftKey(Keys keyData)
        {
            // For back space navigation
            try
            {
                Keys key = (keyData & Keys.KeyCode);
                if (key == Keys.Back)
                {
                    if (base.CurrentCell.ColumnIndex == 0 || (base.CurrentCell.ColumnIndex == 1 && base.Columns[0].Visible && base.Columns[0].Frozen) || (base.CurrentCell.ColumnIndex == 2 && !base.Columns[0].Visible && !base.Columns[1].Visible) || (base.CurrentCell.ColumnIndex == 2 && !base.Columns[1].Visible && base.Columns[0].Frozen) || (base.CurrentCell.ColumnIndex == 3 && !base.Columns[0].Visible && !base.Columns[1].Visible && base.Columns[2].Frozen) || (base.CurrentCell.ColumnIndex == 2 && !base.Columns[0].Visible && base.Columns[1].Frozen))
                    {
                        if (base.CurrentCell.RowIndex > 0)
                        {
                            int inCurrRow = base.CurrentCell.RowIndex - 1;
                            while (!base.Rows[inCurrRow].Visible)
                            {
                                if (inCurrRow >= 1)
                                {
                                    inCurrRow--;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (inCurrRow >= 0 && base.Rows[inCurrRow].Visible)
                            {
                                if (base.Rows[inCurrRow].Cells[base.ColumnCount - 1].Visible)
                                {
                                    base.CurrentCell = base.Rows[inCurrRow].Cells[base.ColumnCount - 1];
                                    return true;
                                }
                                else if (base.Rows[inCurrRow].Cells[base.ColumnCount - 2].Visible)
                                {
                                    base.CurrentCell = base.Rows[inCurrRow].Cells[base.ColumnCount - 2];
                                    return true;
                                }
                                else if (base.Rows[inCurrRow].Cells[base.ColumnCount - 3].Visible)
                                {
                                    base.CurrentCell = base.Rows[inCurrRow].Cells[base.ColumnCount - 3];
                                    return true;
                                }
                                else if (base.Rows[inCurrRow].Cells[base.ColumnCount - 4].Visible)
                                {
                                    base.CurrentCell = base.Rows[inCurrRow].Cells[base.ColumnCount - 4];
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("invisible");
                                }
                            }
                            else
                            {
                                if (base.TabIndex != 0)
                                {
                                    SendKeys.Send("+{Tab}");
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (base.TabIndex != 0)
                            {
                                SendKeys.Send("+{Tab}");
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (base.CurrentCell.ColumnIndex != 0)
                        {
                            int inInvisibleAndFrozen = 0;
                            for (int inI = 0; inI < base.CurrentCell.ColumnIndex; inI++)
                            {
                                if (!base.Columns[inInvisibleAndFrozen].Visible || base.Columns[inInvisibleAndFrozen].Frozen)
                                {
                                    inInvisibleAndFrozen++;
                                }
                            }
                            if (base.CurrentCell.ColumnIndex - inInvisibleAndFrozen == 0)
                            {
                                if (base.CurrentCell.RowIndex > 0)
                                {
                                    if (base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 1].Visible)
                                    {
                                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 1];
                                        return true;
                                    }
                                    else if (base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 2].Visible)
                                    {
                                        base.CurrentCell = base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 2];
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("invisible");
                                    }
                                }
                                else
                                {
                                    if (base.TabIndex != 0)
                                    {
                                        SendKeys.Send("+{Tab}");
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    return base.ProcessLeftKey(keyData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return base.ProcessLeftKey(keyData);
        }

        /// <summary>
        /// This overrides the ProcessDataGridViewKey methods
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return this.ProcessRightKey(e.KeyData);
            }
            else if (e.KeyCode == Keys.Back)
            {
                return this.ProcessLeftKey(e.KeyData);
            }
            return base.ProcessDataGridViewKey(e);
        }

        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
            {
                this.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            else
            {
                this.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            }
            if (this.CurrentCell.OwningColumn.GetType() == typeof(nDataGridViewTextBoxColumn) && ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).CellContentType == CellContentType.Date)
            {
                this.CurrentCell.Style.ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
            }
            base.OnCellEnter(e);
        }

        protected override void OnCellLeave(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell.OwningColumn.GetType() == typeof(nDataGridViewTextBoxColumn) && ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).CellContentType == CellContentType.Date)
            {
                if ((this.CurrentCell.EditedFormattedValue ?? string.Empty).ToString().Trim().Length > 0)
                {
                    this.EndEdit(DataGridViewDataErrorContexts.Commit);
                    ActiveUserSession.ServerDateTime = GeneralBLL.GetServerDateAndTime();
                    DateValidation obj = new DateValidation();
                    bool isValid;
                    this.CurrentCell.Value = obj.DateValidationFunction(this.CurrentCell.EditedFormattedValue.ToString(), out isValid);
                    if (((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).RangeValidate && Text.Trim().Length > 0)
                    {
                        ValidateRange(Convert.ToDateTime(this.CurrentCell.Value), ref isValid);
                    }
                    if (this.CurrentCell.Value.ToString() == string.Empty)
                    {
                        this.CurrentCell.Style.ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                        this.CurrentCell.Value = ActiveUserSession.ServerDateTime.ToString("dd-MMM-yyyy");
                    }
                    this.CurrentCell.Tag = Convert.ToDateTime(this.CurrentCell.Value);
                }
                else
                {
                    this.EndEdit(DataGridViewDataErrorContexts.Commit);
                    this.CurrentCell.Style.ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                    this.CurrentCell.Value = string.Empty;
                    this.CurrentCell.Tag = null;
                }
            }
            else if (this.CurrentCell.OwningColumn.GetType() == typeof(nDataGridViewTextBoxColumn) && ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).CellContentType == CellContentType.Amount)
            {
                this.EndEdit(DataGridViewDataErrorContexts.Commit);
                if (this.CurrentCell.Value.ToString().Trim().Length > 0)
                {
                    decimal amountValue = Math.Round(Convert.ToDecimal(this.CurrentCell.Value), ActiveUserSession.CurrencyNoOfDecimalPlaces);
                    if(ActiveUserSession.CurrencyNoOfDecimalPlaces == 1)
                    {
                        this.CurrentCell.Value = string.Format("{0:0.0}", amountValue);
                    }
                    else if (ActiveUserSession.CurrencyNoOfDecimalPlaces == 2)
                    {
                        this.CurrentCell.Value = string.Format("{0:0.00}", amountValue);
                    }
                    else if (ActiveUserSession.CurrencyNoOfDecimalPlaces == 3)
                    {
                        this.CurrentCell.Value = string.Format("{0:0.000}", amountValue);
                    }
                    else
                    {
                        this.CurrentCell.Value = amountValue.ToString();
                    }
                }
            }
            base.OnCellLeave(e);
        }

        #region Override OnKeyPress

        protected override void OnControlAdded(ControlEventArgs e)
        {
            SubscribeEvents(e.Control);
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            UnsubscribeEvents(e.Control);
            base.OnControlRemoved(e);
        }

        private void SubscribeEvents(Control control)
        {
            control.KeyPress += new KeyPressEventHandler(control_KeyPress);
            control.ControlAdded += new ControlEventHandler(control_ControlAdded);
            control.ControlRemoved += new ControlEventHandler(control_ControlRemoved);

            foreach (Control innerControl in control.Controls)
            {
                SubscribeEvents(innerControl);
            }
        }

        private void UnsubscribeEvents(Control control)
        {
            control.KeyPress -= new KeyPressEventHandler(control_KeyPress);
            control.ControlAdded -= new ControlEventHandler(control_ControlAdded);
            control.ControlRemoved -= new ControlEventHandler(control_ControlRemoved);

            foreach (Control innerControl in control.Controls)
            {
                UnsubscribeEvents(innerControl);
            }
        }

        private void control_ControlAdded(object sender, ControlEventArgs e)
        {
            SubscribeEvents(e.Control);
        }

        private void control_ControlRemoved(object sender, ControlEventArgs e)
        {
            UnsubscribeEvents(e.Control);
        }

        private void control_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (SelectedCells != null)
                {
                    if (this.CurrentCell.OwningColumn.GetType() == typeof(nDataGridViewTextBoxColumn))
                    {
                        if (((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).CellContentType == CellContentType.Amount)
                        {
                            Utilities.DecimalValidation(sender, e, ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).IsNegativeAllowed);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Check wether the range with in the range
        /// </summary>
        private void ValidateRange(DateTime dateString, ref bool isValid)
        {
            if (dateString >= ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).RangeFrom && dateString <= ((nDataGridViewTextBoxColumn)this.CurrentCell.OwningColumn).RangeTo)
            {
                if (dateString == ActiveUserSession.ServerDateTime.Date)
                {
                    if (isValid)
                    {
                        this.CurrentCell.Style.ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                    }
                    else
                    {
                        this.CurrentCell.Style.ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                    }
                        this.CurrentCell.Value = dateString.ToString("dd-MMM-yyyy");
                }
                else
                {
                    isValid = true;
                    this.CurrentCell.Style.ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                    this.CurrentCell.Value = dateString.ToString("dd-MMM-yyyy");
                }
            }
            else
            {
                isValid = false;
                this.CurrentCell.Style.ForeColor = CrystalConstants.WRONG_TEXT_COLOR;
                this.CurrentCell.Value = "";
            }
        }

        #endregion
    }
}
