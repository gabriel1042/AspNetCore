namespace erp_usitronic.client.Forms
{
    partial class BankForm
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.chkEntersCashFlow = new System.Windows.Forms.CheckBox();
            this.gridBanks = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnpjColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InscEstadualColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFields.SuspendLayout();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBanks)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFields
            // 
            this.groupFields.Controls.Add(this.chkEntersCashFlow);
            this.groupFields.Controls.Add(this.txtBalance);
            this.groupFields.Controls.Add(this.txtCode);
            this.groupFields.Controls.Add(this.lblBalance);
            this.groupFields.Controls.Add(this.lblCode);
            this.groupFields.Controls.Add(this.txtId);
            this.groupFields.Controls.Add(this.lblName);
            this.groupFields.Controls.Add(this.lblId);
            this.groupFields.Controls.Add(this.txtName);
            this.groupFields.Location = new System.Drawing.Point(4, 237);
            this.groupFields.Size = new System.Drawing.Size(927, 226);
            // 
            // groupFilters
            // 
            this.groupFilters.Size = new System.Drawing.Size(927, 61);
            this.groupFilters.Visible = false;
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.gridBanks);
            this.groupGrid.Location = new System.Drawing.Point(4, 12);
            this.groupGrid.Size = new System.Drawing.Size(926, 217);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(344, 479);
            this.btnNew.TabIndex = 0;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(736, 479);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(638, 479);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(442, 478);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(540, 478);
            this.btnSave.TabIndex = 2;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(834, 479);
            this.btnExit.TabIndex = 5;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(14, 66);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(79, 26);
            this.txtId.TabIndex = 0;
            this.txtId.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(95, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Nome:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(10, 43);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Id:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(99, 66);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(734, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(144, 141);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(63, 20);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Código:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(351, 141);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(54, 20);
            this.lblBalance.TabIndex = 11;
            this.lblBalance.Text = "Saldo:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(148, 164);
            this.txtCode.MaxLength = 3;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(134, 26);
            this.txtCode.TabIndex = 2;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(355, 164);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(147, 26);
            this.txtBalance.TabIndex = 3;
            // 
            // chkEntersCashFlow
            // 
            this.chkEntersCashFlow.AutoSize = true;
            this.chkEntersCashFlow.Location = new System.Drawing.Point(623, 166);
            this.chkEntersCashFlow.Name = "chkEntersCashFlow";
            this.chkEntersCashFlow.Size = new System.Drawing.Size(215, 24);
            this.chkEntersCashFlow.TabIndex = 4;
            this.chkEntersCashFlow.Text = "Compõe o Fluxo de Caixa";
            this.chkEntersCashFlow.UseVisualStyleBackColor = true;
            // 
            // gridBanks
            // 
            this.gridBanks.AllowUserToAddRows = false;
            this.gridBanks.AllowUserToDeleteRows = false;
            this.gridBanks.AllowUserToOrderColumns = true;
            this.gridBanks.AllowUserToResizeRows = false;
            this.gridBanks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBanks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBanks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn,
            this.CnpjColumn,
            this.InscEstadualColumn});
            this.gridBanks.Location = new System.Drawing.Point(6, 25);
            this.gridBanks.Name = "gridBanks";
            this.gridBanks.ReadOnly = true;
            this.gridBanks.RowHeadersWidth = 62;
            this.gridBanks.RowTemplate.Height = 28;
            this.gridBanks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBanks.Size = new System.Drawing.Size(914, 180);
            this.gridBanks.TabIndex = 1;
            this.gridBanks.SelectionChanged += new System.EventHandler(this.gridBanks_SelectionChanged);
            // 
            // IdColumn
            // 
            this.IdColumn.FillWeight = 30F;
            this.IdColumn.HeaderText = "Código";
            this.IdColumn.MinimumWidth = 8;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Razão Social";
            this.NameColumn.MinimumWidth = 8;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // CnpjColumn
            // 
            this.CnpjColumn.FillWeight = 45F;
            this.CnpjColumn.HeaderText = "CNPJ";
            this.CnpjColumn.MinimumWidth = 8;
            this.CnpjColumn.Name = "CnpjColumn";
            this.CnpjColumn.ReadOnly = true;
            // 
            // InscEstadualColumn
            // 
            this.InscEstadualColumn.FillWeight = 45F;
            this.InscEstadualColumn.HeaderText = "Insc. Estadual";
            this.InscEstadualColumn.MinimumWidth = 8;
            this.InscEstadualColumn.Name = "InscEstadualColumn";
            this.InscEstadualColumn.ReadOnly = true;
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 523);
            this.MaximumSize = new System.Drawing.Size(1033, 646);
            this.Name = "BankForm";
            this.Text = "Cadastro de Bancos";
            this.Load += new System.EventHandler(this.BankForm_Load);
            this.Shown += new System.EventHandler(this.BankForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BankForm_KeyDown);
            this.groupFields.ResumeLayout(false);
            this.groupFields.PerformLayout();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBanks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEntersCashFlow;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DataGridView gridBanks;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnpjColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InscEstadualColumn;
    }
}