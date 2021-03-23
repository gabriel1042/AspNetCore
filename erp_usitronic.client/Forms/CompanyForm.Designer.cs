namespace erp_usitronic.client.Forms
{ 
    partial class CompanyForm
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
            this.gridCompanies = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnpjColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InscEstadualColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStateRegistration = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.lblStateRegistration = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.groupFields.SuspendLayout();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFields
            // 
            this.groupFields.Controls.Add(this.txtId);
            this.groupFields.Controls.Add(this.txtCnpj);
            this.groupFields.Controls.Add(this.lblStateRegistration);
            this.groupFields.Controls.Add(this.lblCnpj);
            this.groupFields.Controls.Add(this.lblName);
            this.groupFields.Controls.Add(this.lblId);
            this.groupFields.Controls.Add(this.txtStateRegistration);
            this.groupFields.Controls.Add(this.txtName);
            this.groupFields.Location = new System.Drawing.Point(4, 282);
            this.groupFields.Size = new System.Drawing.Size(914, 204);
            // 
            // groupFilters
            // 
            this.groupFilters.Size = new System.Drawing.Size(916, 61);
            this.groupFilters.Visible = false;
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.gridCompanies);
            this.groupGrid.Location = new System.Drawing.Point(4, 12);
            this.groupGrid.Size = new System.Drawing.Size(916, 255);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(330, 502);
            this.btnNew.TabIndex = 1;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(624, 502);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(722, 502);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(428, 502);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(526, 502);
            this.btnSave.TabIndex = 3;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(820, 502);
            this.btnExit.TabIndex = 6;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridCompanies
            // 
            this.gridCompanies.AllowUserToAddRows = false;
            this.gridCompanies.AllowUserToDeleteRows = false;
            this.gridCompanies.AllowUserToOrderColumns = true;
            this.gridCompanies.AllowUserToResizeRows = false;
            this.gridCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCompanies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn,
            this.CnpjColumn,
            this.InscEstadualColumn});
            this.gridCompanies.Location = new System.Drawing.Point(8, 25);
            this.gridCompanies.Name = "gridCompanies";
            this.gridCompanies.ReadOnly = true;
            this.gridCompanies.RowHeadersWidth = 62;
            this.gridCompanies.RowTemplate.Height = 28;
            this.gridCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCompanies.Size = new System.Drawing.Size(900, 205);
            this.gridCompanies.TabIndex = 0;
            this.gridCompanies.SelectionChanged += new System.EventHandler(this.gridCompanies_SelectionChanged);
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
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(19, 54);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(79, 26);
            this.txtId.TabIndex = 1;
            this.txtId.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(104, 54);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(804, 26);
            this.txtName.TabIndex = 2;
            // 
            // txtStateRegistration
            // 
            this.txtStateRegistration.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtStateRegistration.Location = new System.Drawing.Point(564, 152);
            this.txtStateRegistration.MaxLength = 20;
            this.txtStateRegistration.Name = "txtStateRegistration";
            this.txtStateRegistration.Size = new System.Drawing.Size(148, 26);
            this.txtStateRegistration.TabIndex = 4;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 31);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Id:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(100, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Razão Social:";
            // 
            // lblCnpj
            // 
            this.lblCnpj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(183, 129);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(45, 20);
            this.lblCnpj.TabIndex = 6;
            this.lblCnpj.Text = "Cnpj:";
            // 
            // lblStateRegistration
            // 
            this.lblStateRegistration.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStateRegistration.AutoSize = true;
            this.lblStateRegistration.Location = new System.Drawing.Point(563, 129);
            this.lblStateRegistration.Name = "lblStateRegistration";
            this.lblStateRegistration.Size = new System.Drawing.Size(114, 20);
            this.lblStateRegistration.TabIndex = 7;
            this.lblStateRegistration.Text = "Insc. Estadual:";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCnpj.Location = new System.Drawing.Point(187, 152);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(193, 26);
            this.txtCnpj.TabIndex = 3;
            this.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 551);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(946, 607);
            this.Name = "CompanyForm";
            this.Text = "Cadastro de Empresa";
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            this.Shown += new System.EventHandler(this.CompanyForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanyForm_KeyDown);
            this.groupFields.ResumeLayout(false);
            this.groupFields.PerformLayout();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblStateRegistration;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtStateRegistration;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView gridCompanies;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnpjColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InscEstadualColumn;
    }
}