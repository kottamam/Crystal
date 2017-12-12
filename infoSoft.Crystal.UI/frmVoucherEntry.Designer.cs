namespace tv.Crystal.UI
{
    partial class frmVoucherEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherEntry));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbxVoucherDescription = new System.Windows.Forms.GroupBox();
            this.lblVoucherDescriptionDetails = new System.Windows.Forms.Label();
            this.lblVoucherDescriptionTitle = new System.Windows.Forms.Label();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnContra = new System.Windows.Forms.Button();
            this.lblVoucherTypeTitle = new System.Windows.Forms.Label();
            this.panelVoucherTypeHeader = new System.Windows.Forms.Panel();
            this.gbxVoucherDetails = new System.Windows.Forms.GroupBox();
            this.mcVoucherDate = new System.Windows.Forms.MonthCalendar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvVoucherDetails = new tv.Crystal.UI.CustomControls.nDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.txtCreditTotal = new tv.Crystal.UI.nTextBox(this.components);
            this.lblCreditTotal = new System.Windows.Forms.Label();
            this.rtbNarration = new System.Windows.Forms.RichTextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLedgerHistory = new tv.Crystal.UI.CustomControls.nDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radWithdrawal = new System.Windows.Forms.RadioButton();
            this.radDeposit = new System.Windows.Forms.RadioButton();
            this.txtPrimaryAccount = new tv.Crystal.UI.nTextBox(this.components);
            this.btnVoucherNoSearch = new System.Windows.Forms.Button();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblVoucherDate = new System.Windows.Forms.Label();
            this.btnSelectDate = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtVoucherDate = new tv.Crystal.UI.nTextBox(this.components);
            this.txtVoucherNo = new tv.Crystal.UI.nTextBox(this.components);
            this.gbxButtons = new System.Windows.Forms.GroupBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbxVoucherDescription.SuspendLayout();
            this.gbxVoucherDetails.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherDetails)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbxButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbxVoucherDescription);
            this.splitContainer.Panel1.Controls.Add(this.btnJournal);
            this.splitContainer.Panel1.Controls.Add(this.btnPayment);
            this.splitContainer.Panel1.Controls.Add(this.btnReceipt);
            this.splitContainer.Panel1.Controls.Add(this.btnContra);
            this.splitContainer.Panel1.Controls.Add(this.lblVoucherTypeTitle);
            this.splitContainer.Panel1.Controls.Add(this.panelVoucherTypeHeader);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gbxVoucherDetails);
            this.splitContainer.Panel2.Controls.Add(this.gbxButtons);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.splitContainer.Size = new System.Drawing.Size(1184, 806);
            this.splitContainer.SplitterDistance = 262;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // gbxVoucherDescription
            // 
            this.gbxVoucherDescription.Controls.Add(this.lblVoucherDescriptionDetails);
            this.gbxVoucherDescription.Controls.Add(this.lblVoucherDescriptionTitle);
            this.gbxVoucherDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxVoucherDescription.Location = new System.Drawing.Point(3, 356);
            this.gbxVoucherDescription.Name = "gbxVoucherDescription";
            this.gbxVoucherDescription.Size = new System.Drawing.Size(259, 447);
            this.gbxVoucherDescription.TabIndex = 6;
            this.gbxVoucherDescription.TabStop = false;
            // 
            // lblVoucherDescriptionDetails
            // 
            this.lblVoucherDescriptionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoucherDescriptionDetails.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDescriptionDetails.ForeColor = System.Drawing.Color.White;
            this.lblVoucherDescriptionDetails.Location = new System.Drawing.Point(3, 59);
            this.lblVoucherDescriptionDetails.Name = "lblVoucherDescriptionDetails";
            this.lblVoucherDescriptionDetails.Size = new System.Drawing.Size(253, 385);
            this.lblVoucherDescriptionDetails.TabIndex = 1;
            this.lblVoucherDescriptionDetails.Text = "Contra entry is an adjustment entry between banker and customer. When we do trans" +
    "action by cash or we transfer balance from one bank a/c to another bank a/c is c" +
    "alled contra entry.";
            // 
            // lblVoucherDescriptionTitle
            // 
            this.lblVoucherDescriptionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVoucherDescriptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDescriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblVoucherDescriptionTitle.Location = new System.Drawing.Point(3, 16);
            this.lblVoucherDescriptionTitle.Name = "lblVoucherDescriptionTitle";
            this.lblVoucherDescriptionTitle.Size = new System.Drawing.Size(253, 43);
            this.lblVoucherDescriptionTitle.TabIndex = 0;
            this.lblVoucherDescriptionTitle.Text = "Contra Entry";
            this.lblVoucherDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnJournal
            // 
            this.btnJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnJournal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnJournal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJournal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJournal.Location = new System.Drawing.Point(3, 289);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(259, 67);
            this.btnJournal.TabIndex = 3;
            this.btnJournal.Text = "Journal";
            this.btnJournal.UseVisualStyleBackColor = false;
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(3, 222);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(259, 67);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReceipt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnReceipt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.Location = new System.Drawing.Point(3, 155);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(259, 67);
            this.btnReceipt.TabIndex = 1;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.UseVisualStyleBackColor = false;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnContra
            // 
            this.btnContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnContra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnContra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContra.Location = new System.Drawing.Point(3, 88);
            this.btnContra.Name = "btnContra";
            this.btnContra.Size = new System.Drawing.Size(259, 67);
            this.btnContra.TabIndex = 0;
            this.btnContra.Text = "Contra";
            this.btnContra.UseVisualStyleBackColor = false;
            this.btnContra.Click += new System.EventHandler(this.btnContra_Click);
            // 
            // lblVoucherTypeTitle
            // 
            this.lblVoucherTypeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVoucherTypeTitle.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherTypeTitle.ForeColor = System.Drawing.Color.White;
            this.lblVoucherTypeTitle.Location = new System.Drawing.Point(3, 34);
            this.lblVoucherTypeTitle.Name = "lblVoucherTypeTitle";
            this.lblVoucherTypeTitle.Size = new System.Drawing.Size(259, 54);
            this.lblVoucherTypeTitle.TabIndex = 2;
            this.lblVoucherTypeTitle.Text = "Voucher Type";
            this.lblVoucherTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelVoucherTypeHeader
            // 
            this.panelVoucherTypeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVoucherTypeHeader.Location = new System.Drawing.Point(3, 0);
            this.panelVoucherTypeHeader.Name = "panelVoucherTypeHeader";
            this.panelVoucherTypeHeader.Size = new System.Drawing.Size(259, 34);
            this.panelVoucherTypeHeader.TabIndex = 1;
            // 
            // gbxVoucherDetails
            // 
            this.gbxVoucherDetails.Controls.Add(this.mcVoucherDate);
            this.gbxVoucherDetails.Controls.Add(this.panel3);
            this.gbxVoucherDetails.Controls.Add(this.panel4);
            this.gbxVoucherDetails.Controls.Add(this.panel2);
            this.gbxVoucherDetails.Controls.Add(this.panel1);
            this.gbxVoucherDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxVoucherDetails.Location = new System.Drawing.Point(0, 0);
            this.gbxVoucherDetails.Name = "gbxVoucherDetails";
            this.gbxVoucherDetails.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gbxVoucherDetails.Size = new System.Drawing.Size(915, 741);
            this.gbxVoucherDetails.TabIndex = 0;
            this.gbxVoucherDetails.TabStop = false;
            // 
            // mcVoucherDate
            // 
            this.mcVoucherDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mcVoucherDate.Location = new System.Drawing.Point(540, 64);
            this.mcVoucherDate.Margin = new System.Windows.Forms.Padding(9, 14, 9, 14);
            this.mcVoucherDate.MaxSelectionCount = 1;
            this.mcVoucherDate.Name = "mcVoucherDate";
            this.mcVoucherDate.TabIndex = 3;
            this.mcVoucherDate.Visible = false;
            this.mcVoucherDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcVoucherDate_DateSelected);
            this.mcVoucherDate.Leave += new System.EventHandler(this.mcVoucherDate_Leave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvVoucherDetails);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(909, 284);
            this.panel3.TabIndex = 1;
            // 
            // dgvVoucherDetails
            // 
            this.dgvVoucherDetails.AllowUserToResizeRows = false;
            this.dgvVoucherDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoucherDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucherDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvVoucherDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.734375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucherDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoucherDetails.ColumnHeadersHeight = 25;
            this.dgvVoucherDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(238)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 7.734375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(202)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVoucherDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVoucherDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVoucherDetails.EnableHeadersVisualStyles = false;
            this.dgvVoucherDetails.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvVoucherDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvVoucherDetails.Name = "dgvVoucherDetails";
            this.dgvVoucherDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 7.734375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(133)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoucherDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVoucherDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVoucherDetails.Size = new System.Drawing.Size(909, 284);
            this.dgvVoucherDetails.TabIndex = 7;
            this.dgvVoucherDetails.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucherDetails_CellLeave);
            this.dgvVoucherDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvVoucherDetails_CellValidating);
            this.dgvVoucherDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucherDetails_CellValueChanged);
            this.dgvVoucherDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVoucherDetails_DataError);
            this.dgvVoucherDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvVoucherDetails_EditingControlShowing);
            this.dgvVoucherDetails.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvVoucherDetails_RowsAdded);
            this.dgvVoucherDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvVoucherDetails_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblRemove);
            this.panel4.Controls.Add(this.txtCreditTotal);
            this.panel4.Controls.Add(this.lblCreditTotal);
            this.panel4.Controls.Add(this.rtbNarration);
            this.panel4.Controls.Add(this.lblNarration);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 378);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(909, 181);
            this.panel4.TabIndex = 2;
            // 
            // lblRemove
            // 
            this.lblRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemove.LinkColor = System.Drawing.Color.Yellow;
            this.lblRemove.Location = new System.Drawing.Point(740, 3);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(147, 17);
            this.lblRemove.TabIndex = 2;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "Remove";
            this.lblRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // txtCreditTotal
            // 
            this.txtCreditTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditTotal.BackColor = System.Drawing.Color.White;
            this.txtCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditTotal.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
            this.txtCreditTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditTotal.Location = new System.Drawing.Point(740, 145);
            this.txtCreditTotal.Name = "txtCreditTotal";
            this.txtCreditTotal.RangeFrom = new System.DateTime(((long)(0)));
            this.txtCreditTotal.RangeTo = new System.DateTime(((long)(0)));
            this.txtCreditTotal.ReadOnly = true;
            this.txtCreditTotal.Size = new System.Drawing.Size(147, 20);
            this.txtCreditTotal.TabIndex = 5;
            this.txtCreditTotal.TabStop = false;
            this.txtCreditTotal.Text = "0.00";
            this.txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCreditTotal
            // 
            this.lblCreditTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreditTotal.Location = new System.Drawing.Point(625, 140);
            this.lblCreditTotal.Name = "lblCreditTotal";
            this.lblCreditTotal.Size = new System.Drawing.Size(114, 28);
            this.lblCreditTotal.TabIndex = 4;
            this.lblCreditTotal.Text = "Amount:";
            this.lblCreditTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtbNarration
            // 
            this.rtbNarration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbNarration.BackColor = System.Drawing.Color.White;
            this.rtbNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbNarration.Location = new System.Drawing.Point(111, 77);
            this.rtbNarration.Name = "rtbNarration";
            this.rtbNarration.Size = new System.Drawing.Size(351, 88);
            this.rtbNarration.TabIndex = 8;
            this.rtbNarration.Text = "";
            this.rtbNarration.Enter += new System.EventHandler(this.rtbNarration_Enter);
            this.rtbNarration.Leave += new System.EventHandler(this.rtbNarration_Leave);
            // 
            // lblNarration
            // 
            this.lblNarration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNarration.Location = new System.Drawing.Point(23, 77);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(87, 18);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration:";
            this.lblNarration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvLedgerHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 559);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 179);
            this.panel2.TabIndex = 1;
            // 
            // dgvLedgerHistory
            // 
            this.dgvLedgerHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedgerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedgerHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvLedgerHistory.Name = "dgvLedgerHistory";
            this.dgvLedgerHistory.Size = new System.Drawing.Size(905, 175);
            this.dgvLedgerHistory.TabIndex = 0;
            this.dgvLedgerHistory.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radWithdrawal);
            this.panel1.Controls.Add(this.radDeposit);
            this.panel1.Controls.Add(this.txtPrimaryAccount);
            this.panel1.Controls.Add(this.btnVoucherNoSearch);
            this.panel1.Controls.Add(this.lblVoucherNo);
            this.panel1.Controls.Add(this.btnAddAccount);
            this.panel1.Controls.Add(this.lblVoucherDate);
            this.panel1.Controls.Add(this.btnSelectDate);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.txtVoucherDate);
            this.panel1.Controls.Add(this.txtVoucherNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 81);
            this.panel1.TabIndex = 0;
            // 
            // radWithdrawal
            // 
            this.radWithdrawal.ForeColor = System.Drawing.Color.White;
            this.radWithdrawal.Location = new System.Drawing.Point(300, 3);
            this.radWithdrawal.Name = "radWithdrawal";
            this.radWithdrawal.Size = new System.Drawing.Size(102, 24);
            this.radWithdrawal.TabIndex = 1;
            this.radWithdrawal.TabStop = true;
            this.radWithdrawal.Text = "Withdrawal";
            this.radWithdrawal.UseVisualStyleBackColor = true;
            // 
            // radDeposit
            // 
            this.radDeposit.ForeColor = System.Drawing.Color.White;
            this.radDeposit.Location = new System.Drawing.Point(190, 3);
            this.radDeposit.Name = "radDeposit";
            this.radDeposit.Size = new System.Drawing.Size(102, 24);
            this.radDeposit.TabIndex = 0;
            this.radDeposit.TabStop = true;
            this.radDeposit.Text = "Deposit";
            this.radDeposit.UseVisualStyleBackColor = true;
            // 
            // txtPrimaryAccount
            // 
            this.txtPrimaryAccount.BackColor = System.Drawing.Color.White;
            this.txtPrimaryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrimaryAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrimaryAccount.Location = new System.Drawing.Point(190, 55);
            this.txtPrimaryAccount.MaxLength = 50;
            this.txtPrimaryAccount.Name = "txtPrimaryAccount";
            this.txtPrimaryAccount.RangeFrom = new System.DateTime(((long)(0)));
            this.txtPrimaryAccount.RangeTo = new System.DateTime(((long)(0)));
            this.txtPrimaryAccount.Size = new System.Drawing.Size(249, 20);
            this.txtPrimaryAccount.TabIndex = 6;
            // 
            // btnVoucherNoSearch
            // 
            this.btnVoucherNoSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoucherNoSearch.BackgroundImage")));
            this.btnVoucherNoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoucherNoSearch.FlatAppearance.BorderSize = 0;
            this.btnVoucherNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherNoSearch.Location = new System.Drawing.Point(291, 27);
            this.btnVoucherNoSearch.Name = "btnVoucherNoSearch";
            this.btnVoucherNoSearch.Size = new System.Drawing.Size(23, 23);
            this.btnVoucherNoSearch.TabIndex = 3;
            this.btnVoucherNoSearch.TabStop = false;
            this.btnVoucherNoSearch.UseVisualStyleBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.Location = new System.Drawing.Point(63, 29);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(121, 18);
            this.lblVoucherNo.TabIndex = 0;
            this.lblVoucherNo.Text = "Voucher No:";
            this.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAccount.BackgroundImage")));
            this.btnAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddAccount.FlatAppearance.BorderSize = 0;
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddAccount.Location = new System.Drawing.Point(455, 52);
            this.btnAddAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(23, 23);
            this.btnAddAccount.TabIndex = 7;
            this.btnAddAccount.TabStop = false;
            this.btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVoucherDate.Location = new System.Drawing.Point(512, 29);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(121, 18);
            this.lblVoucherDate.TabIndex = 0;
            this.lblVoucherDate.Text = "Voucher Date:";
            this.lblVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectDate
            // 
            this.btnSelectDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectDate.BackgroundImage")));
            this.btnSelectDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectDate.FlatAppearance.BorderSize = 0;
            this.btnSelectDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectDate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSelectDate.Location = new System.Drawing.Point(740, 28);
            this.btnSelectDate.Name = "btnSelectDate";
            this.btnSelectDate.Size = new System.Drawing.Size(23, 23);
            this.btnSelectDate.TabIndex = 5;
            this.btnSelectDate.TabStop = false;
            this.btnSelectDate.UseVisualStyleBackColor = true;
            this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
            this.btnSelectDate.Leave += new System.EventHandler(this.btnSelectDate_Leave);
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(63, 54);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(121, 18);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "Bank/Cash a/c:";
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVoucherDate
            // 
            this.txtVoucherDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherDate.BackColor = System.Drawing.Color.White;
            this.txtVoucherDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherDate.ContentType = tv.Crystal.UI.nTextBox.nType.Date;
            this.txtVoucherDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherDate.Location = new System.Drawing.Point(639, 30);
            this.txtVoucherDate.MaxLength = 11;
            this.txtVoucherDate.Name = "txtVoucherDate";
            this.txtVoucherDate.RangeFrom = new System.DateTime(((long)(0)));
            this.txtVoucherDate.RangeTo = new System.DateTime(((long)(0)));
            this.txtVoucherDate.Size = new System.Drawing.Size(100, 20);
            this.txtVoucherDate.TabIndex = 4;
            this.txtVoucherDate.Leave += new System.EventHandler(this.txtVoucherDate_Leave);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNo.Location = new System.Drawing.Point(190, 30);
            this.txtVoucherNo.MaxLength = 10;
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.RangeFrom = new System.DateTime(((long)(0)));
            this.txtVoucherNo.RangeTo = new System.DateTime(((long)(0)));
            this.txtVoucherNo.Size = new System.Drawing.Size(100, 20);
            this.txtVoucherNo.TabIndex = 2;
            // 
            // gbxButtons
            // 
            this.gbxButtons.Controls.Add(this.chkPrint);
            this.gbxButtons.Controls.Add(this.btnClose);
            this.gbxButtons.Controls.Add(this.btnClear);
            this.gbxButtons.Controls.Add(this.btnSave);
            this.gbxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxButtons.Location = new System.Drawing.Point(0, 741);
            this.gbxButtons.Name = "gbxButtons";
            this.gbxButtons.Size = new System.Drawing.Size(915, 62);
            this.gbxButtons.TabIndex = 9;
            this.gbxButtons.TabStop = false;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.White;
            this.chkPrint.Location = new System.Drawing.Point(73, 27);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(114, 17);
            this.chkPrint.TabIndex = 9;
            this.chkPrint.Text = "Print after save";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(493, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(418, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(343, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmVoucherEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 806);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Verdana", 7.734375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmVoucherEntry";
            this.Text = "Voucher Entry";
            this.Load += new System.EventHandler(this.frmVoucherEntry_Load);
            this.Click += new System.EventHandler(this.frmVoucherEntry_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVoucherEntry_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbxVoucherDescription.ResumeLayout(false);
            this.gbxVoucherDetails.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherDetails)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxButtons.ResumeLayout(false);
            this.gbxButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblVoucherTypeTitle;
        private System.Windows.Forms.Panel panelVoucherTypeHeader;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnContra;
        private System.Windows.Forms.GroupBox gbxButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxVoucherDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbxVoucherDescription;
        private System.Windows.Forms.Label lblVoucherDescriptionDetails;
        private System.Windows.Forms.Label lblVoucherDescriptionTitle;
        private nTextBox txtVoucherNo;
        private System.Windows.Forms.Label lblVoucherDate;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.MonthCalendar mcVoucherDate;
        private System.Windows.Forms.Button btnVoucherNoSearch;
        private System.Windows.Forms.Button btnSelectDate;
        private nTextBox txtVoucherDate;
        private nTextBox txtPrimaryAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private CustomControls.nDataGridView dgvVoucherDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.RichTextBox rtbNarration;
        private System.Windows.Forms.Label lblNarration;
        private CustomControls.nDataGridView dgvLedgerHistory;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Label lblCreditTotal;
        private nTextBox txtCreditTotal;
        private System.Windows.Forms.RadioButton radWithdrawal;
        private System.Windows.Forms.RadioButton radDeposit;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Panel panel3;
    }
}