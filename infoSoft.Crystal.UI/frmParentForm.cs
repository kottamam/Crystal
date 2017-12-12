#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 18.06.2015
// Created By   : Noble
// Description  : MDI container form
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using directives

using tv.Crystal.Business;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

#endregion Using Directives

namespace tv.Crystal.UI
{
    public partial class frmParentForm : Form
    {
        #region Constructor

        public frmParentForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        public static frmParentForm MDIObj;

        #endregion

        #region Form Events

        private void frmParentForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                Left = 0;
                Top = 0;
                MDIObj = this;
                BindMenu();
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void frmParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Messages.ShowConfirmation("Are you sure to close " + Application.ProductName + " ?",MessageBoxDefaultButton.Button2))
                {
                    GeneralBLL.InsertEventLog("Application closed.", EventLogType.Application, EventLogMode.General);
                    Dispose();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To bind the menu items which the user have permission.
        /// </summary>
        internal void BindMenu()
        {
            // Setting menu according to the user role. Module id is hardcoded as 1.
            DataTable dtMenuItems = UserBLL.GetUserRoleMenuItemPermissions(ActiveUserSession.UserRoleId, 1);

            if (dtMenuItems.Rows.Count > 0)
            {
                IEnumerable<DataRow> drMenuList = from r in dtMenuItems.AsEnumerable() where r.Field<int>("MenuParent") == 0 select (r);
                DataTable dtCommonParentMenu = drMenuList.CopyToDataTable<DataRow>();
                if (dtCommonParentMenu.Rows.Count > 0)
                {
                    foreach (DataRow drCommonParentMenu in dtCommonParentMenu.Rows)
                    {
                        ToolStripMenuItem childMenu = new ToolStripMenuItem(Convert.ToString(drCommonParentMenu[1]));
                        if (Convert.ToString(drCommonParentMenu[1]).Trim().Equals("Windows"))
                        {
                            mnuMenu.MdiWindowListItem = childMenu;
                        }
                        mnuMenu.Items.Add(childMenu);
                        PopulateChildMenu(childMenu, Convert.ToInt32(drCommonParentMenu[0]), ref dtMenuItems);
                    }
                    dtCommonParentMenu.Dispose();
                    dtMenuItems.Dispose();
                }
            }
            else
            {
                Messages.ShowInformationMessage(Application.ProductName + " could not locate menu permissions for this user.");
                Dispose();
                Application.Exit();
            }
        }

        /// <summary>
        /// Populating child menu
        /// </summary>
        /// <param name="mainMenu">Menu</param>
        /// <param name="menuParent">Menu parent</param>        
        private void PopulateChildMenu(ToolStripMenuItem mainMenu, int menuParent, ref DataTable dtMenuItem)
        {
            try
            {
                IEnumerable<DataRow> drMenuList = from r in dtMenuItem.AsEnumerable() where r.Field<int>("MenuParent") == menuParent select (r);
                if (drMenuList.Count() > 0)
                {
                    DataTable dtChildMenu = drMenuList.CopyToDataTable<DataRow>();

                    foreach (DataRow drChildMenu in dtChildMenu.Rows)
                    {
                        if (string.Compare(drChildMenu["MenuURL"].ToString().ToLower().Trim(), "separator") == 0)
                        {
                            ToolStripSeparator separator = new ToolStripSeparator();
                            separator.Name = Convert.ToString(drChildMenu["MenuURL"]);
                            mainMenu.DropDownItems.Add(separator);
                        }
                        else
                        {
                            ToolStripMenuItem childMenu = new ToolStripMenuItem(Convert.ToString(drChildMenu["MenuName"]));
                            if (drChildMenu["MenuShortcutKey"].ToString().Trim() != string.Empty)
                            {
                                if (drChildMenu["MenuShortcutKeyModifier"].ToString().Trim() != "None")
                                {
                                    childMenu.ShortcutKeys = ((Keys)((Keys)Enum.Parse(typeof(Keys), drChildMenu["MenuShortcutKeyModifier"].ToString().Trim()) | (Keys)Enum.Parse(typeof(Keys), drChildMenu["MenuShortcutKey"].ToString().Trim())));
                                }
                                else
                                {
                                    childMenu.ShortcutKeys = (Keys)Enum.Parse(typeof(Keys), drChildMenu["MenuShortcutKey"].ToString().Trim());
                                }
                                childMenu.ShowShortcutKeys = true;
                            }
                            childMenu.Name = Convert.ToString(drChildMenu["MenuURL"]);
                            childMenu.Tag = Convert.ToInt32(drChildMenu["MenuID"]);
                            // Setting click event for child menu
                            if (string.Compare(childMenu.Name, "#") != 0)
                            {
                                childMenu.Click += new EventHandler(childMenu_Click);
                                mainMenu.DropDownItems.Add(childMenu);
                                PopulateChildMenu(childMenu, Convert.ToInt32(drChildMenu["MenuID"]), ref dtMenuItem);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Shows the form according to the invoking menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void childMenu_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem sourceMenuItem = (ToolStripMenuItem)sender;
                // Checking whether the menu item is exit or not
                if (string.Compare(sourceMenuItem.Name.ToLower().Trim(), "exit") == 0)
                {
                    FormClosingEventArgs eg = new FormClosingEventArgs(CloseReason.ApplicationExitCall, false);
                    // Close the form
                    frmParentForm_FormClosing(sender, eg);
                }
                else if (string.Compare(sourceMenuItem.Name.Trim(), "Cascade") == 0)
                {
                    LayoutMdi(MdiLayout.Cascade);
                }
                else if (string.Compare(sourceMenuItem.Name.Trim(), "Close All") == 0)
                {
                    if (Messages.ShowConfirmation("Are you sure to close all screens?"))
                    {
                        foreach (Form childForm in MdiChildren)
                        {
                            childForm.Close();
                        }
                    }
                }
                else
                {
                    FormProperties formProperties = new FormProperties();
                    formProperties.MenuName = sourceMenuItem.Text;
                    formProperties.MenuId = Convert.ToInt32(sourceMenuItem.Tag);

                    //Loading respective child menu form
                    LoadChildMenuForm(sourceMenuItem.Name, formProperties);
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// Loads child menu form
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="menuName"></param>
        private void LoadChildMenuForm(string obj, FormProperties formProperties)
        {
            Form frmForm = null;
            try
            {
                foreach (Form frmMDIChildForm in this.MdiChildren)
                {
                    // if (frmMDIChildForm.Name.Equals(obj) && (frmMDIChildForm.Tag ?? string.Empty).Equals(menuName))
                    if (frmMDIChildForm.Name.Equals(obj) && (((FormProperties)frmMDIChildForm.Tag).MenuName ?? string.Empty).Equals(formProperties.MenuName))
                    {
                        frmForm = (Form)frmMDIChildForm;
                        break;
                    }
                }
                if (frmForm != null)
                {
                    frmForm.Tag = formProperties;
                    frmForm.Show();
                    frmForm.WindowState = FormWindowState.Normal;
                    frmForm.Focus();
                }
                else
                {
                    string formName = obj;
                    string form = this.GetType().Namespace + "." + formName;
                    frmForm = (Form)this.GetType().Assembly.CreateInstance(form);
                    frmForm.MdiParent = this;
                    frmForm.Tag = formProperties;
                    frmForm.Show();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
