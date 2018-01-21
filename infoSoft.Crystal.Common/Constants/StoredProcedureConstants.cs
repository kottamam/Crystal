#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Constants declared for stored procedures in database
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

#endregion

namespace tv.Crystal.Common.Constants
{
    public class StoredProcedureConstants
    {
        #region Account

        public const string GET_ACCOUNT_GROUPS = "[dbo].[cmsGetAccountGroups]";
        public const string GET_ACCOUNTS = "[dbo].[cmsGetAccounts]";
        public const string GET_ACCOUNT_NAMES = "[dbo].[cmsGetAccountNames]";
        public const string GET_ACCOUNT_DETAILS_BY_ACCOUNT_ID = "[dbo].[cmsGetAccountDetailsByAccountID]";
        public const string CHECK_DUPLICATE_ACCOUNT_NAME = "[dbo].[cmsCheckDuplicateAccountName]";
        public const string INSERT_UPDATE_ACCOUNT_DETAILS = "[dbo].[cmsInsertUpdateAccountDetails]";
        public const string GET_BANK_CASH_ACCOUNTS = "[dbo].[cmsGetBankCashAccounts]";
        public const string GET_BANK_CASH_ACCOUNTS_BY_ACCOUNT_NAME = "[dbo].[cmsGetBankCashAccountsByAccountName]";
        public const string GET_ACCOUNTS_BY_ACCOUNT_NAME = "[dbo].[cmsGetAccountsByAccountName]";
        public const string GET_CURRENCY_APPLICABLE_ON_DATE = "[dbo].[cmsGetCurrencyApplicableOnDate]";
        public const string CHECK_IS_BANK_ACCOUNT = "[dbo].[cmsCheckIsBankAccount]";
        public const string INSERT_UPDATE_CONTRA_ENTRY = "[dbo].[cmsInsertUpdateContraEntry]";
        public const string INSERT_UPDATE_RECEIPT_ENTRY = "[dbo].[cmsInsertUpdateReceiptEntry]";

        #endregion

        #region Counter

        public const string GET_COUNTER_DETAILS = "[dbo].[cmsGetCounterDetails]";

		#endregion

		#region Customers

		public const string GET_CUSTOMER_LIST = "[dbo].[cmsGetCustomerList]";
		public const string GET_CUSTOMER_DETAILS = "[dbo].[cmsGetCustomerDetails]";
		public const string GET_CUSTOMER_PENDING_AMOUNT_USING_NAME = "[dbo].[cmsGetCustomerPendingAmountUsingName]";
		public const string GET_CUSTOMER_PENDING_AMOUNT_USING_VEHICLE_NO = "[dbo].[cmsGetCustomerPendingAmountUsingVehicleNo]";
        public const string CHECK_DUPLICATE_CUSTOMER_NAME = "[dbo].[cmsCheckDuplicateCustomerName]";
        public const string CHECK_DUPLICATE_VEHICLE_NO = "[dbo].[cmsCheckDuplicateVehicleNo]";
		public const string INSERT_UPDATE_CUSTOMER = "[dbo].[cmsInsertUpdateCustomer]";
		public const string DELETE_CUSTOMER = "[dbo].[cmsDeleteCustomer]";

		#endregion

		#region Financial Year

		public const string GET_CURRENT_FINANCIAL_YEAR_DETAILS = "[dbo].[cmsGetCurrentFinancialYearDetails]";

        #endregion

        #region General

        public const string GET_APPLICATION_VERSION = "[dbo].[cmsGetApplicationVersion]";
        public const string INSERT_EVENT_LOG = "[dbo].[cmsInsertEventLog]";
        public const string AUTHENTICATE_LOGIN = "[dbo].[cmsAuthenticateLogin]";
        public const string GET_SERVER_DATE_AND_TIME = "[dbo].[cmsGetServerDateAndTime]";
        public const string GET_GENERAL_SETTINGS = "[dbo].[cmsGetGeneralSettings]";

        #endregion

        #region Privilege

        public const string GET_USER_ACCESS_RIGHTS_BY_MENU_ID = "[dbo].[cmsGetUserAccessRightsByMenuID]";

		#endregion

		#region Product Model

		public const string GET_PRODUCT_MODEL_LIST = "[dbo].[cmsGetProductModelList]";
		public const string GET_PRODUCT_MODEL_DETAILS = "[dbo].[cmsGetProductModelDetails]";
		public const string GET_PRODUCT_MODEL_RATE = "[dbo].[cmsGetProductModelRate]";
		public const string UPDATE_PRODUCT_MODEL_RATE = "[dbo].[cmsUpdateProductModelRate]";

		#endregion

		#region Reports

		public const string GET_SALES_VOUCHER_REPORT_DETAILED = "[dbo].[cmsGetSalesVoucherReportDetailed]";

		#endregion

		#region Sales Voucher

		public const string INSERT_SALES_VOUCHER = "[dbo].[cmsInsertSalesVoucher]";
		public const string GET_SALES_VOUCHER_HISTORY = "[dbo].[cmsGetSalesVoucherHistory]";
		public const string UPDATE_SALES_VOUCHER_SETTLEMENT_AMOUNT = "[dbo].[cmsUpdateSalesVoucherSettlementAmount]";
		public const string CHECK_IS_LAST_SALE_TO_THE_CUSTOMER = "[dbo].[cmsCheckIsLastSaleToTheCustomer]";
		public const string GET_SALES_VOUCHER_DETAILS_BY_SALES_NO = "[dbo].[cmsGetSalesVoucherDetailsBySalesNo]";
		public const string DELETE_SALES_VOUCHER = "[dbo].[cmsDeleteSalesVoucher]";

		#endregion

		#region User

		public const string GET_USER_ROLE_MENU_ITEM_PERMISSIONS = "[dbo].[cmsGetUserRoleMenuItemPermissions]";
		public const string GET_USER_LIST = "[dbo].[cmsGetUserList]";

		#endregion
	}
}
