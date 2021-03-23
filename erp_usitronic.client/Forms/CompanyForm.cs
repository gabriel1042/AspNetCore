using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.business.models;
using erp_usitronic.client.HttpResources;
using Newtonsoft.Json;
using erp_usitronic.business;
using System.Net.Http;
using erp_usitronic.client.Forms.LoadingSplash;

namespace erp_usitronic.client.Forms
{
    public partial class CompanyForm : FormBase
    {
        private List<Company> companies = new List<Company>();
        private bool loadingForm = true;
        private bool buildingDataSource = false;

        public CompanyForm()
        {
            InitializeComponent();
        }

        #region Events
        private void CompanyForm_Load(object sender, EventArgs e)
        {
            base.FormBase_Load(sender, e);
            BuildGrid();
            loadingForm = false;
        }
        private async void CompanyForm_Shown(object sender, EventArgs e)
        {
            using (var waiting = Wait.Start(this))
            {
                await LoadGridAsync();
                await SetToRowAsync(gridCompanies.SelectedRows.Count);
            }
        }
        private void CompanyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
                CloseForm();

            if ((Keys)e.KeyValue == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        protected override void btnNew_Click(object sender, EventArgs e)
        {
            base.btnNew_Click(sender, e);
            txtName.Focus();
        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            base.btnEdit_Click(sender, e);
            txtName.Focus();
        }
        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response;
            var company = new Company()
            {
                Id = txtId.ToNumber(),
                CnpjNumber = txtCnpj.Text,
                StateRegistration = txtStateRegistration.Text,
                CompanyName = txtName.Text
            };
            bool newCompany = company.Id == 0;

            if (newCompany)
                response = await HttpUtilities.PostAsync(EndPoints.COMPANIES, company);
            else
                response = await HttpUtilities.PutAsync($"{EndPoints.COMPANIES}/{company.Id}", company);
            
            var result = await FormUtils.ProcessHttpReturnAsync(response);

            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Empresa gravada com sucesso!");
                if(newCompany)
                    await AddOnGridAsync(JsonConvert.DeserializeObject<Company>(result.Data.ToString()));
                else
                    await UpdateOnGridAsync(JsonConvert.DeserializeObject<Company>(result.Data.ToString()));
                base.btnSave_Click(sender, e);
            }
        }
        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = gridCompanies.GetIdCurrentRow();
            if (id == null) return;
            if (MessageBoxWrapper.ShowYesNo("Deseja excluir esta empresa?") == DialogResult.No) return;
            
            var response = await HttpUtilities.DeleteAsync($"{EndPoints.COMPANIES}/{id}");
            var result = await FormUtils.ProcessHttpReturnAsync(response);
            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Empresa removida com sucesso!");
                await RemoveOnGridAsync(JsonConvert.DeserializeObject<Company>(result.Data.ToString()));
                base.btnDelete_Click(sender, e);
            }            
        }
        protected override async void btnCancel_Click(object sender, EventArgs e)
        {            
            base.btnCancel_Click(sender, e);
            SetDataSource();
            await SetToRowAsync(gridCompanies.Rows.Count);
        }
        protected override void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
            base.btnExit_Click(sender, e);
        }
        private async void gridCompanies_SelectionChanged(object sender, EventArgs e)
        {
            if (loadingForm || buildingDataSource) return;
            var company = await GetCompanySelectedOnGridAsync();
            if(company != null)
                LoadFields(company);
        }        
        #endregion

        #region Private Methods
        private async Task<Company> GetCompanySelectedOnGridAsync()
        {
            var id = gridCompanies.GetIdCurrentRow();
            if (id == null) return null;

            var result = await HttpUtilities.GetAsync($"{EndPoints.COMPANIES}/{id}");
            var json = result.Content.ReadAsStringAsync().Result;
            var company = JsonConvert.DeserializeObject<Company>(json);
            return company;
        }
        private void CloseForm()
        {
            if (btnNew.Enabled)
            {
                Close();
            }
        }
        private void LoadFields(Company company)
        {
            groupFields.ClearControls();
            txtId.Text = company.Id.ToText(6);
            txtCnpj.Text = company.CnpjNumber;
            txtName.Text = company.CompanyName;
            txtStateRegistration.Text = company.StateRegistration;
        }
        private void BuildGrid()
        {
            FormUtils.BuildGrid(gridCompanies);

            var IdColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Código",
                FillWeight = 30,
                DataPropertyName = nameof(Company.Id),
                Name = "IdColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, BackColor = Color.Gainsboro, Format = "000000" },
                ReadOnly = true,
                ValueType = typeof(int),
                Visible = true
            };

            var NameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Razão Social ",
                FillWeight = 100,
                DataPropertyName = nameof(Company.CompanyName),
                Name = "NameColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            var CnpjColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "CNPJ",
                FillWeight = 45,
                DataPropertyName = nameof(Company.CnpjNumber),
                Name = "CnpjColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, BackColor = Color.Gainsboro},                
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            var InscEstadualColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Insc. Estadual",
                FillWeight = 45,
                DataPropertyName = nameof(Company.StateRegistration),
                Name = "InscEstadualColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            gridCompanies.Columns.AddRange(IdColumn,
                                           NameColumn,
                                           CnpjColumn,
                                           InscEstadualColumn);
        }
        private async Task LoadGridAsync()
        {
            var response = await HttpUtilities.GetAsync(EndPoints.COMPANIES);
            var json = response.Content.ReadAsStringAsync().Result;
            companies = JsonConvert.DeserializeObject<List<Company>>(json);
            SetDataSource();
        }
        private void SetDataSource()
        {
            try
            {
                if (companies.Count > 0)
                {
                    buildingDataSource = true;
                    companies.ForEach(x => x.CnpjNumber = Convert.ToUInt64(x.CnpjNumber.Replace(".","").Replace("-","").Replace("/","")).ToString(@"00\.000\.000\/0000\-00"));
                    companies = companies.OrderBy(x => x.Id).ToList();
                    gridCompanies.DataSource = companies.ConvertToDatatable<Company>(c => c.Id);
                }
            }
            finally
            {
                buildingDataSource = false;
            }            
        }
        private async Task AddOnGridAsync(Company company)
        {
            companies.Add(company);
            SetDataSource();
            await SetToRowAsync(gridCompanies.Rows.Count);
        }
        private async Task UpdateOnGridAsync(Company company)
        {
            var companyToUpdate = companies.Where(x => x.Id == company.Id).FirstOrDefault();
            company.CopyAllTo(companyToUpdate);

            var rowIndex = gridCompanies.Rows.IndexOf(gridCompanies.GetSelectedRow());
            SetDataSource();
            await SetToRowAsync(rowIndex);
        }
        private async Task RemoveOnGridAsync(Company company)
        {
            var companyToDelete = companies.Where(x => x.Id == company.Id).FirstOrDefault();
            companies.Remove(companyToDelete);
            SetDataSource();
            await SetToRowAsync(gridCompanies.Rows.Count);
        }
        private async Task SetToRowAsync(int indexRow)
        {
            gridCompanies.EnsureVisibleRow(indexRow);
            if (gridCompanies.Rows.Count == 1)
            {
                var company = await GetCompanySelectedOnGridAsync();
                LoadFields(company);
            }
        }
        #endregion

        #region Public Methods

        #endregion
    }
}
