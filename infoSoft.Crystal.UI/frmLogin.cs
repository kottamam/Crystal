#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Login form to Crystal
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion Using Directives

namespace tv.Crystal.UI
{
    public partial class frmLogin : Form
    {
        #region Constructor

        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Private variables

        private int passwordValidity = 0; // 0 - incorrect password, 1- correct password 

        #endregion

        #region Private methods

        /// <summary>
        /// Check whether the given user exist in database or not.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True or False based on the existance of user</returns>
        private Boolean AuthenticateLogin(string userName, string password)
        {
            // True if user already exists and data is returned from query
            Boolean isExistingUser = false;
            try
            {
                DataTable dtLogin = UserBLL.AuthenticateLogin(userName, password);
                if (dtLogin != null)
                {
                    if (dtLogin.Rows.Count > 0)
                    {
                        ActiveUserSession.UserId = Convert.ToInt32(dtLogin.Rows[0]["UserID"]);
                        ActiveUserSession.UserName = dtLogin.Rows[0]["UserName"].ToString();
                        ActiveUserSession.UserFullName = dtLogin.Rows[0]["Fullname"].ToString();
                        ActiveUserSession.UserRoleId = Convert.ToInt32(dtLogin.Rows[0]["RoleID"]);
                        passwordValidity = Convert.ToInt32(dtLogin.Rows[0]["Validity"]);

                        isExistingUser = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isExistingUser;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            try
            {
                txtUserName.Focus();
                txtUserName.SelectAll();
                txtUserName.Text = Properties.Settings.Default.LastLoginUser;
            }
            catch(Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// Form key down events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    switch (ActiveControl.Name.Trim())
                    {
                        case "txtPassword":
                            btnLogin.PerformClick();
                            break;
                        default:
                            SelectNextControl(ActiveControl, true, true, true, true);
                            break;
                    }
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
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// Getting the login if username is not empty,Password is not empty and the reader contains the data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim().Length == 0 ? "without username" : "with the username";
                if (!AuthenticateLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    Messages.ShowInformationMessage("Invalid username.");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                    GeneralBLL.InsertEventLog("Invalid login attempt " + userName + " " + txtUserName.Text.Trim() + ".", EventLogType.Login, EventLogMode.General);
                }
                else if (passwordValidity == 0)
                {
                    Messages.ShowInformationMessage("Invalid password.");
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    GeneralBLL.InsertEventLog("Invalid login attempt " + userName + " " + txtUserName.Text.Trim() + ".", EventLogType.Login, EventLogMode.General);
                }
                else
                {                    
                    // Calling business method for getting general setting details
                    DataTable dtGeneralSettings = GeneralBLL.GetGeneralSettings();
                    if (dtGeneralSettings.Rows.Count > 0)
                    {
                        ActiveUserSession.CompanyId = Convert.ToInt32(dtGeneralSettings.Rows[0]["CompanyID"]);
                        ActiveUserSession.CompanyName = dtGeneralSettings.Rows[0]["CompanyName"].ToString().Trim();
                        ActiveUserSession.CompanyNameForPrint = dtGeneralSettings.Rows[0]["CompanyNameForPrint"].ToString().Trim();
                        ActiveUserSession.CompanyAddress1 = dtGeneralSettings.Rows[0]["CompanyAddress1"].ToString().Trim();
                        ActiveUserSession.CompanyAddress2 = dtGeneralSettings.Rows[0]["CompanyAddress2"].ToString().Trim();
                        ActiveUserSession.CompanyAddress3 = dtGeneralSettings.Rows[0]["CompanyAddress3"].ToString().Trim();
                        ActiveUserSession.CompanyPhone = dtGeneralSettings.Rows[0]["CompanyPhone"].ToString().Trim();
                        ActiveUserSession.CompanyEmail = dtGeneralSettings.Rows[0]["CompanyEmail"].ToString().Trim();
                        ActiveUserSession.CurrencyNoOfDecimalPlaces = Convert.ToInt32(dtGeneralSettings.Rows[0]["CurrencyNoOfDecimalPlaces"]);
					}

                    Properties.Settings.Default.LastLoginUser = txtUserName.Text;
                    Properties.Settings.Default.Save();

                    frmParentForm parentForm = new frmParentForm();
                    parentForm.Show();

                    // Auditing the action
                    GeneralBLL.InsertEventLog("Successfull Login -  UserName : " + txtUserName.Text.Trim() + " Password:  " + "********"
                                              + ".", EventLogType.Login, EventLogMode.General);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        #endregion

        #region Textbox events

        /// <summary>
        /// For setting key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        
        /// <summary>
        /// For setting text Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

    }
}
