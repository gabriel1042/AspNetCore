namespace erp_usitronic.client.Forms
{
    partial class PersonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonForm));
            this.gridPeople = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnpjColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InscEstadualColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCustomerSupplier = new System.Windows.Forms.TableLayoutPanel();
            this.groupSupplier = new System.Windows.Forms.GroupBox();
            this.lblSupplierStateRegistration = new System.Windows.Forms.Label();
            this.txtSupplierStateRegistration = new System.Windows.Forms.TextBox();
            this.lblSupplierCompanyName = new System.Windows.Forms.Label();
            this.txtSupplierCompanyName = new System.Windows.Forms.TextBox();
            this.groupCustomer = new System.Windows.Forms.GroupBox();
            this.lblCustomerStateRegistration = new System.Windows.Forms.Label();
            this.txtCustomerStateRegistration = new System.Windows.Forms.TextBox();
            this.lblCustomerCompanyName = new System.Windows.Forms.Label();
            this.txtCustomerCompanyName = new System.Windows.Forms.TextBox();
            this.radioPhisycalPerson = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupKindPerson = new System.Windows.Forms.GroupBox();
            this.radioLegalPerson = new System.Windows.Forms.RadioButton();
            this.groupAddress = new System.Windows.Forms.GroupBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblNeighborhood = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.cboCities = new System.Windows.Forms.ComboBox();
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.txtNeighborhood = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.MaskedTextBox();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.chkIsCustomer = new System.Windows.Forms.CheckBox();
            this.chkIsSupplier = new System.Windows.Forms.CheckBox();
            this.lblFilterId = new System.Windows.Forms.Label();
            this.lblCompanyNameFilter = new System.Windows.Forms.Label();
            this.lblCnpjCpf = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkSupplierFilter = new System.Windows.Forms.CheckBox();
            this.chkCustomerFilter = new System.Windows.Forms.CheckBox();
            this.txtIdFilter = new System.Windows.Forms.TextBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.txtCnpjCpfFilter = new System.Windows.Forms.TextBox();
            this.btnCleanFilter = new System.Windows.Forms.Button();
            this.groupFields.SuspendLayout();
            this.groupFilters.SuspendLayout();
            this.groupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeople)).BeginInit();
            this.tblCustomerSupplier.SuspendLayout();
            this.groupSupplier.SuspendLayout();
            this.groupCustomer.SuspendLayout();
            this.groupKindPerson.SuspendLayout();
            this.groupAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFields
            // 
            this.groupFields.Controls.Add(this.chkIsCustomer);
            this.groupFields.Controls.Add(this.chkIsSupplier);
            this.groupFields.Controls.Add(this.btnPhoto);
            this.groupFields.Controls.Add(this.picPhoto);
            this.groupFields.Controls.Add(this.lblPhoto);
            this.groupFields.Controls.Add(this.lblTelephone);
            this.groupFields.Controls.Add(this.lblEmail);
            this.groupFields.Controls.Add(this.txtTelephone);
            this.groupFields.Controls.Add(this.txtEmail);
            this.groupFields.Controls.Add(this.groupAddress);
            this.groupFields.Controls.Add(this.groupKindPerson);
            this.groupFields.Controls.Add(this.txtId);
            this.groupFields.Controls.Add(this.txtCnpj);
            this.groupFields.Controls.Add(this.lblCnpj);
            this.groupFields.Controls.Add(this.lblName);
            this.groupFields.Controls.Add(this.lblId);
            this.groupFields.Controls.Add(this.txtName);
            this.groupFields.Controls.Add(this.tblCustomerSupplier);
            this.groupFields.Location = new System.Drawing.Point(4, 278);
            this.groupFields.Size = new System.Drawing.Size(1082, 415);
            // 
            // groupFilters
            // 
            this.groupFilters.Controls.Add(this.btnCleanFilter);
            this.groupFilters.Controls.Add(this.txtCnpjCpfFilter);
            this.groupFilters.Controls.Add(this.txtNameFilter);
            this.groupFilters.Controls.Add(this.txtIdFilter);
            this.groupFilters.Controls.Add(this.chkCustomerFilter);
            this.groupFilters.Controls.Add(this.chkSupplierFilter);
            this.groupFilters.Controls.Add(this.btnSearch);
            this.groupFilters.Controls.Add(this.lblCnpjCpf);
            this.groupFilters.Controls.Add(this.lblCompanyNameFilter);
            this.groupFilters.Controls.Add(this.lblFilterId);
            this.groupFilters.Size = new System.Drawing.Size(1082, 61);
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.gridPeople);
            this.groupGrid.Size = new System.Drawing.Size(1082, 197);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(498, 710);
            this.btnNew.TabIndex = 0;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(890, 710);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(792, 710);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(596, 709);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(694, 709);
            this.btnSave.TabIndex = 3;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(988, 710);
            this.btnExit.TabIndex = 5;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridPeople
            // 
            this.gridPeople.AllowUserToAddRows = false;
            this.gridPeople.AllowUserToDeleteRows = false;
            this.gridPeople.AllowUserToOrderColumns = true;
            this.gridPeople.AllowUserToResizeRows = false;
            this.gridPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn,
            this.CnpjColumn,
            this.InscEstadualColumn});
            this.gridPeople.Location = new System.Drawing.Point(6, 25);
            this.gridPeople.Name = "gridPeople";
            this.gridPeople.ReadOnly = true;
            this.gridPeople.RowHeadersWidth = 62;
            this.gridPeople.RowTemplate.Height = 28;
            this.gridPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPeople.Size = new System.Drawing.Size(1070, 166);
            this.gridPeople.TabIndex = 1;
            this.gridPeople.SelectionChanged += new System.EventHandler(this.gridPeople_SelectionChanged);
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
            // tblCustomerSupplier
            // 
            this.tblCustomerSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblCustomerSupplier.ColumnCount = 2;
            this.tblCustomerSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCustomerSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCustomerSupplier.Controls.Add(this.groupSupplier, 0, 0);
            this.tblCustomerSupplier.Controls.Add(this.groupCustomer, 0, 0);
            this.tblCustomerSupplier.Location = new System.Drawing.Point(1, 299);
            this.tblCustomerSupplier.Name = "tblCustomerSupplier";
            this.tblCustomerSupplier.RowCount = 2;
            this.tblCustomerSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCustomerSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tblCustomerSupplier.Size = new System.Drawing.Size(1072, 111);
            this.tblCustomerSupplier.TabIndex = 12;
            // 
            // groupSupplier
            // 
            this.groupSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSupplier.Controls.Add(this.lblSupplierStateRegistration);
            this.groupSupplier.Controls.Add(this.txtSupplierStateRegistration);
            this.groupSupplier.Controls.Add(this.lblSupplierCompanyName);
            this.groupSupplier.Controls.Add(this.txtSupplierCompanyName);
            this.groupSupplier.Enabled = false;
            this.groupSupplier.Location = new System.Drawing.Point(539, 14);
            this.groupSupplier.Name = "groupSupplier";
            this.groupSupplier.Size = new System.Drawing.Size(530, 85);
            this.groupSupplier.TabIndex = 1;
            this.groupSupplier.TabStop = false;
            // 
            // lblSupplierStateRegistration
            // 
            this.lblSupplierStateRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierStateRegistration.AutoSize = true;
            this.lblSupplierStateRegistration.Location = new System.Drawing.Point(335, 27);
            this.lblSupplierStateRegistration.Name = "lblSupplierStateRegistration";
            this.lblSupplierStateRegistration.Size = new System.Drawing.Size(144, 20);
            this.lblSupplierStateRegistration.TabIndex = 11;
            this.lblSupplierStateRegistration.Text = "Inscrição Estadual:";
            // 
            // txtSupplierStateRegistration
            // 
            this.txtSupplierStateRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierStateRegistration.Location = new System.Drawing.Point(336, 50);
            this.txtSupplierStateRegistration.MaxLength = 255;
            this.txtSupplierStateRegistration.Name = "txtSupplierStateRegistration";
            this.txtSupplierStateRegistration.Size = new System.Drawing.Size(188, 26);
            this.txtSupplierStateRegistration.TabIndex = 1;
            // 
            // lblSupplierCompanyName
            // 
            this.lblSupplierCompanyName.AutoSize = true;
            this.lblSupplierCompanyName.Location = new System.Drawing.Point(2, 27);
            this.lblSupplierCompanyName.Name = "lblSupplierCompanyName";
            this.lblSupplierCompanyName.Size = new System.Drawing.Size(107, 20);
            this.lblSupplierCompanyName.TabIndex = 9;
            this.lblSupplierCompanyName.Text = "Razão Social:";
            // 
            // txtSupplierCompanyName
            // 
            this.txtSupplierCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierCompanyName.Location = new System.Drawing.Point(6, 50);
            this.txtSupplierCompanyName.MaxLength = 255;
            this.txtSupplierCompanyName.Name = "txtSupplierCompanyName";
            this.txtSupplierCompanyName.Size = new System.Drawing.Size(307, 26);
            this.txtSupplierCompanyName.TabIndex = 0;
            // 
            // groupCustomer
            // 
            this.groupCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCustomer.Controls.Add(this.lblCustomerStateRegistration);
            this.groupCustomer.Controls.Add(this.txtCustomerStateRegistration);
            this.groupCustomer.Controls.Add(this.lblCustomerCompanyName);
            this.groupCustomer.Controls.Add(this.txtCustomerCompanyName);
            this.groupCustomer.Enabled = false;
            this.groupCustomer.Location = new System.Drawing.Point(3, 14);
            this.groupCustomer.Name = "groupCustomer";
            this.groupCustomer.Size = new System.Drawing.Size(530, 85);
            this.groupCustomer.TabIndex = 0;
            this.groupCustomer.TabStop = false;
            // 
            // lblCustomerStateRegistration
            // 
            this.lblCustomerStateRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerStateRegistration.AutoSize = true;
            this.lblCustomerStateRegistration.Location = new System.Drawing.Point(332, 27);
            this.lblCustomerStateRegistration.Name = "lblCustomerStateRegistration";
            this.lblCustomerStateRegistration.Size = new System.Drawing.Size(144, 20);
            this.lblCustomerStateRegistration.TabIndex = 12;
            this.lblCustomerStateRegistration.Text = "Inscrição Estadual:";
            // 
            // txtCustomerStateRegistration
            // 
            this.txtCustomerStateRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerStateRegistration.Location = new System.Drawing.Point(336, 50);
            this.txtCustomerStateRegistration.MaxLength = 255;
            this.txtCustomerStateRegistration.Name = "txtCustomerStateRegistration";
            this.txtCustomerStateRegistration.Size = new System.Drawing.Size(188, 26);
            this.txtCustomerStateRegistration.TabIndex = 1;
            // 
            // lblCustomerCompanyName
            // 
            this.lblCustomerCompanyName.AutoSize = true;
            this.lblCustomerCompanyName.Location = new System.Drawing.Point(2, 27);
            this.lblCustomerCompanyName.Name = "lblCustomerCompanyName";
            this.lblCustomerCompanyName.Size = new System.Drawing.Size(107, 20);
            this.lblCustomerCompanyName.TabIndex = 7;
            this.lblCustomerCompanyName.Text = "Razão Social:";
            // 
            // txtCustomerCompanyName
            // 
            this.txtCustomerCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerCompanyName.Location = new System.Drawing.Point(6, 50);
            this.txtCustomerCompanyName.MaxLength = 255;
            this.txtCustomerCompanyName.Name = "txtCustomerCompanyName";
            this.txtCustomerCompanyName.Size = new System.Drawing.Size(308, 26);
            this.txtCustomerCompanyName.TabIndex = 0;
            // 
            // radioPhisycalPerson
            // 
            this.radioPhisycalPerson.AutoSize = true;
            this.radioPhisycalPerson.Location = new System.Drawing.Point(20, 25);
            this.radioPhisycalPerson.Name = "radioPhisycalPerson";
            this.radioPhisycalPerson.Size = new System.Drawing.Size(75, 24);
            this.radioPhisycalPerson.TabIndex = 0;
            this.radioPhisycalPerson.TabStop = true;
            this.radioPhisycalPerson.Text = "Fisica";
            this.radioPhisycalPerson.UseVisualStyleBackColor = true;
            this.radioPhisycalPerson.CheckedChanged += new System.EventHandler(this.radioPhisycalPerson_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(10, 49);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(79, 26);
            this.txtId.TabIndex = 21;
            this.txtId.TabStop = false;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnpj.Location = new System.Drawing.Point(860, 49);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(193, 26);
            this.txtCnpj.TabIndex = 3;
            this.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCnpj
            // 
            this.lblCnpj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(856, 26);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(45, 20);
            this.lblCnpj.TabIndex = 2;
            this.lblCnpj.Text = "Cnpj:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(91, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 25;
            this.lblName.Text = "Nome:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(6, 26);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 24;
            this.lblId.Text = "Id:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(95, 49);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(454, 26);
            this.txtName.TabIndex = 0;
            // 
            // groupKindPerson
            // 
            this.groupKindPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKindPerson.Controls.Add(this.radioLegalPerson);
            this.groupKindPerson.Controls.Add(this.radioPhisycalPerson);
            this.groupKindPerson.Location = new System.Drawing.Point(578, 31);
            this.groupKindPerson.Name = "groupKindPerson";
            this.groupKindPerson.Size = new System.Drawing.Size(238, 58);
            this.groupKindPerson.TabIndex = 1;
            this.groupKindPerson.TabStop = false;
            this.groupKindPerson.Text = "Pessoa:";
            // 
            // radioLegalPerson
            // 
            this.radioLegalPerson.AutoSize = true;
            this.radioLegalPerson.Location = new System.Drawing.Point(117, 25);
            this.radioLegalPerson.Name = "radioLegalPerson";
            this.radioLegalPerson.Size = new System.Drawing.Size(88, 24);
            this.radioLegalPerson.TabIndex = 1;
            this.radioLegalPerson.TabStop = true;
            this.radioLegalPerson.Text = "Juridica";
            this.radioLegalPerson.UseVisualStyleBackColor = true;
            this.radioLegalPerson.CheckedChanged += new System.EventHandler(this.radioLegalPerson_CheckedChanged);
            // 
            // groupAddress
            // 
            this.groupAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAddress.Controls.Add(this.lblCity);
            this.groupAddress.Controls.Add(this.lblState);
            this.groupAddress.Controls.Add(this.lblNeighborhood);
            this.groupAddress.Controls.Add(this.lblNumber);
            this.groupAddress.Controls.Add(this.lblStreetName);
            this.groupAddress.Controls.Add(this.lblZipCode);
            this.groupAddress.Controls.Add(this.cboCities);
            this.groupAddress.Controls.Add(this.cboStates);
            this.groupAddress.Controls.Add(this.txtNeighborhood);
            this.groupAddress.Controls.Add(this.txtZipCode);
            this.groupAddress.Controls.Add(this.txtStreetName);
            this.groupAddress.Controls.Add(this.txtNumber);
            this.groupAddress.Location = new System.Drawing.Point(6, 154);
            this.groupAddress.Name = "groupAddress";
            this.groupAddress.Size = new System.Drawing.Size(777, 142);
            this.groupAddress.TabIndex = 8;
            this.groupAddress.TabStop = false;
            this.groupAddress.Text = "Endereço";
            // 
            // lblCity
            // 
            this.lblCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(408, 80);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(63, 20);
            this.lblCity.TabIndex = 18;
            this.lblCity.Text = "Cidade:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(302, 80);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 20);
            this.lblState.TabIndex = 17;
            this.lblState.Text = "UF:";
            // 
            // lblNeighborhood
            // 
            this.lblNeighborhood.AutoSize = true;
            this.lblNeighborhood.Location = new System.Drawing.Point(8, 82);
            this.lblNeighborhood.Name = "lblNeighborhood";
            this.lblNeighborhood.Size = new System.Drawing.Size(55, 20);
            this.lblNeighborhood.TabIndex = 16;
            this.lblNeighborhood.Text = "Bairro:";
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(626, 22);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(69, 20);
            this.lblNumber.TabIndex = 15;
            this.lblNumber.Text = "Número:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(139, 22);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(43, 20);
            this.lblStreetName.TabIndex = 14;
            this.lblStreetName.Text = "Rua:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(8, 22);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(42, 20);
            this.lblZipCode.TabIndex = 13;
            this.lblZipCode.Text = "Cep:";
            // 
            // cboCities
            // 
            this.cboCities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCities.FormattingEnabled = true;
            this.cboCities.Location = new System.Drawing.Point(404, 103);
            this.cboCities.Name = "cboCities";
            this.cboCities.Size = new System.Drawing.Size(327, 28);
            this.cboCities.TabIndex = 5;
            // 
            // cboStates
            // 
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(306, 103);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(92, 28);
            this.cboStates.TabIndex = 4;
            this.cboStates.Enter += new System.EventHandler(this.cboStates_Enter);
            this.cboStates.Leave += new System.EventHandler(this.cboStates_Leave);
            // 
            // txtNeighborhood
            // 
            this.txtNeighborhood.Location = new System.Drawing.Point(12, 105);
            this.txtNeighborhood.MaxLength = 80;
            this.txtNeighborhood.Name = "txtNeighborhood";
            this.txtNeighborhood.Size = new System.Drawing.Size(272, 26);
            this.txtNeighborhood.TabIndex = 3;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(12, 45);
            this.txtZipCode.Mask = "#####-###";
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(93, 26);
            this.txtZipCode.TabIndex = 0;
            this.txtZipCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtZipCode.Enter += new System.EventHandler(this.txtZipCode_Enter);
            this.txtZipCode.Leave += new System.EventHandler(this.txtZipCode_Leave);
            // 
            // txtStreetName
            // 
            this.txtStreetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreetName.Location = new System.Drawing.Point(143, 45);
            this.txtStreetName.MaxLength = 255;
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(478, 26);
            this.txtStreetName.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.Location = new System.Drawing.Point(630, 45);
            this.txtNumber.MaxLength = 10;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(101, 26);
            this.txtNumber.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(10, 122);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(384, 26);
            this.txtEmail.TabIndex = 5;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelephone.Location = new System.Drawing.Point(400, 122);
            this.txtTelephone.MaxLength = 20;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(149, 26);
            this.txtTelephone.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblTelephone
            // 
            this.lblTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(396, 99);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(75, 20);
            this.lblTelephone.TabIndex = 6;
            this.lblTelephone.Text = "Telefone:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(785, 106);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(46, 20);
            this.lblPhoto.TabIndex = 33;
            this.lblPhoto.Text = "Foto:";
            // 
            // picPhoto
            // 
            this.picPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Image = ((System.Drawing.Image)(resources.GetObject("picPhoto.Image")));
            this.picPhoto.Location = new System.Drawing.Point(789, 129);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(238, 158);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 34;
            this.picPhoto.TabStop = false;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhoto.Location = new System.Drawing.Point(1033, 129);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(39, 35);
            this.btnPhoto.TabIndex = 4;
            this.btnPhoto.Text = "...";
            this.btnPhoto.UseVisualStyleBackColor = true;
            // 
            // chkIsCustomer
            // 
            this.chkIsCustomer.AutoSize = true;
            this.chkIsCustomer.Location = new System.Drawing.Point(30, 305);
            this.chkIsCustomer.Name = "chkIsCustomer";
            this.chkIsCustomer.Size = new System.Drawing.Size(84, 24);
            this.chkIsCustomer.TabIndex = 35;
            this.chkIsCustomer.Text = "Cliente";
            this.chkIsCustomer.UseVisualStyleBackColor = true;
            this.chkIsCustomer.CheckedChanged += new System.EventHandler(this.chkIsCustomer_CheckedChanged);
            // 
            // chkIsSupplier
            // 
            this.chkIsSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsSupplier.AutoSize = true;
            this.chkIsSupplier.Location = new System.Drawing.Point(583, 305);
            this.chkIsSupplier.Name = "chkIsSupplier";
            this.chkIsSupplier.Size = new System.Drawing.Size(117, 24);
            this.chkIsSupplier.TabIndex = 39;
            this.chkIsSupplier.Text = "Fornecedor";
            this.chkIsSupplier.UseVisualStyleBackColor = true;
            this.chkIsSupplier.CheckedChanged += new System.EventHandler(this.chkIsSupplier_CheckedChanged);
            // 
            // lblFilterId
            // 
            this.lblFilterId.AutoSize = true;
            this.lblFilterId.Location = new System.Drawing.Point(11, 26);
            this.lblFilterId.Name = "lblFilterId";
            this.lblFilterId.Size = new System.Drawing.Size(63, 20);
            this.lblFilterId.TabIndex = 0;
            this.lblFilterId.Text = "Código:";
            // 
            // lblCompanyNameFilter
            // 
            this.lblCompanyNameFilter.AutoSize = true;
            this.lblCompanyNameFilter.Location = new System.Drawing.Point(165, 26);
            this.lblCompanyNameFilter.Name = "lblCompanyNameFilter";
            this.lblCompanyNameFilter.Size = new System.Drawing.Size(107, 20);
            this.lblCompanyNameFilter.TabIndex = 1;
            this.lblCompanyNameFilter.Text = "Razão Social:";
            // 
            // lblCnpjCpf
            // 
            this.lblCnpjCpf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCnpjCpf.AutoSize = true;
            this.lblCnpjCpf.Location = new System.Drawing.Point(587, 26);
            this.lblCnpjCpf.Name = "lblCnpjCpf";
            this.lblCnpjCpf.Size = new System.Drawing.Size(74, 20);
            this.lblCnpjCpf.TabIndex = 2;
            this.lblCnpjCpf.Text = "Cnpj/Cpf:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(891, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkSupplierFilter
            // 
            this.chkSupplierFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSupplierFilter.AutoSize = true;
            this.chkSupplierFilter.Location = new System.Drawing.Point(801, 12);
            this.chkSupplierFilter.Name = "chkSupplierFilter";
            this.chkSupplierFilter.Size = new System.Drawing.Size(85, 24);
            this.chkSupplierFilter.TabIndex = 3;
            this.chkSupplierFilter.Text = "Fornec";
            this.chkSupplierFilter.UseVisualStyleBackColor = true;
            // 
            // chkCustomerFilter
            // 
            this.chkCustomerFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCustomerFilter.AutoSize = true;
            this.chkCustomerFilter.Location = new System.Drawing.Point(801, 34);
            this.chkCustomerFilter.Name = "chkCustomerFilter";
            this.chkCustomerFilter.Size = new System.Drawing.Size(84, 24);
            this.chkCustomerFilter.TabIndex = 4;
            this.chkCustomerFilter.Text = "Cliente";
            this.chkCustomerFilter.UseVisualStyleBackColor = true;
            // 
            // txtIdFilter
            // 
            this.txtIdFilter.Location = new System.Drawing.Point(80, 23);
            this.txtIdFilter.MaxLength = 6;
            this.txtIdFilter.Name = "txtIdFilter";
            this.txtIdFilter.Size = new System.Drawing.Size(79, 26);
            this.txtIdFilter.TabIndex = 0;
            this.txtIdFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdFilter_KeyDown);
            this.txtIdFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdFilter_KeyPress);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameFilter.Location = new System.Drawing.Point(278, 23);
            this.txtNameFilter.MaxLength = 255;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(293, 26);
            this.txtNameFilter.TabIndex = 1;
            // 
            // txtCnpjCpfFilter
            // 
            this.txtCnpjCpfFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnpjCpfFilter.Location = new System.Drawing.Point(660, 23);
            this.txtCnpjCpfFilter.MaxLength = 14;
            this.txtCnpjCpfFilter.Name = "txtCnpjCpfFilter";
            this.txtCnpjCpfFilter.Size = new System.Drawing.Size(123, 26);
            this.txtCnpjCpfFilter.TabIndex = 2;
            this.txtCnpjCpfFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnpjCpfFilter_KeyPress);
            // 
            // btnCleanFilter
            // 
            this.btnCleanFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanFilter.Location = new System.Drawing.Point(984, 19);
            this.btnCleanFilter.Name = "btnCleanFilter";
            this.btnCleanFilter.Size = new System.Drawing.Size(87, 34);
            this.btnCleanFilter.TabIndex = 6;
            this.btnCleanFilter.Text = "&Limpar";
            this.btnCleanFilter.UseVisualStyleBackColor = true;
            this.btnCleanFilter.Click += new System.EventHandler(this.btnCleanFilter_Click);
            // 
            // PersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 761);
            this.MinimumSize = new System.Drawing.Size(1087, 817);
            this.Name = "PersonForm";
            this.Text = "Cadastro de Pessoas";
            this.Load += new System.EventHandler(this.PersonForm_Load);
            this.Shown += new System.EventHandler(this.PersonForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PersonForm_KeyDown);
            this.groupFields.ResumeLayout(false);
            this.groupFields.PerformLayout();
            this.groupFilters.ResumeLayout(false);
            this.groupFilters.PerformLayout();
            this.groupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPeople)).EndInit();
            this.tblCustomerSupplier.ResumeLayout(false);
            this.groupSupplier.ResumeLayout(false);
            this.groupSupplier.PerformLayout();
            this.groupCustomer.ResumeLayout(false);
            this.groupCustomer.PerformLayout();
            this.groupKindPerson.ResumeLayout(false);
            this.groupKindPerson.PerformLayout();
            this.groupAddress.ResumeLayout(false);
            this.groupAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnpjColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InscEstadualColumn;
        private System.Windows.Forms.TableLayoutPanel tblCustomerSupplier;
        private System.Windows.Forms.GroupBox groupSupplier;
        private System.Windows.Forms.Label lblSupplierCompanyName;
        private System.Windows.Forms.TextBox txtSupplierCompanyName;
        private System.Windows.Forms.GroupBox groupCustomer;
        private System.Windows.Forms.Label lblCustomerCompanyName;
        private System.Windows.Forms.TextBox txtCustomerCompanyName;
        private System.Windows.Forms.RadioButton radioPhisycalPerson;
        private System.Windows.Forms.GroupBox groupKindPerson;
        private System.Windows.Forms.RadioButton radioLegalPerson;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox groupAddress;
        private System.Windows.Forms.ComboBox cboCities;
        private System.Windows.Forms.ComboBox cboStates;
        private System.Windows.Forms.TextBox txtNeighborhood;
        private System.Windows.Forms.MaskedTextBox txtZipCode;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblSupplierStateRegistration;
        private System.Windows.Forms.TextBox txtSupplierStateRegistration;
        private System.Windows.Forms.Label lblCustomerStateRegistration;
        private System.Windows.Forms.TextBox txtCustomerStateRegistration;
        private System.Windows.Forms.Label lblZipCode;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblNeighborhood;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.CheckBox chkIsCustomer;
        private System.Windows.Forms.CheckBox chkIsSupplier;
        private System.Windows.Forms.CheckBox chkCustomerFilter;
        private System.Windows.Forms.CheckBox chkSupplierFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCnpjCpf;
        private System.Windows.Forms.Label lblCompanyNameFilter;
        private System.Windows.Forms.Label lblFilterId;
        private System.Windows.Forms.TextBox txtCnpjCpfFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.TextBox txtIdFilter;
        private System.Windows.Forms.Button btnCleanFilter;
    }
}