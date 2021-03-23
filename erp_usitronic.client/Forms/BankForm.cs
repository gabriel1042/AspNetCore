using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.business;
using erp_usitronic.business.models;
using erp_usitronic.client.Forms.LoadingSplash;
using erp_usitronic.client.HttpResources;
using Newtonsoft.Json;

namespace erp_usitronic.client.Forms
{
    public partial class BankForm : FormBase
    {
        private List<Bank> Banks = new List<Bank>();
        private bool loadingForm = true;
        private bool buildingDataSource = false;

        public BankForm()
        {
            InitializeComponent();
        }

        #region Events
        private void BankForm_Load(object sender, EventArgs e)
        {
            base.FormBase_Load(sender, e);
            BuildGrid();
            loadingForm = false;
        }
        private async void BankForm_Shown(object sender, EventArgs e)
        {
            using (var waiting = Wait.Start(this))
            {
                await LoadGridAsync();
                await SetToRowAsync(gridBanks.SelectedRows.Count);
            }
        }
        private void BankForm_KeyDown(object sender, KeyEventArgs e)
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
            var Bank = new Bank()
            {
                Id = txtId.ToNumber(),
                Code = txtCode.ToNumber(),
                Balance = txtBalance.ToDecimal(),
                EntersCashFlow = chkEntersCashFlow.Checked,
                Name = txtName.Text
            };
            bool newBank = Bank.Id == 0;

            if (newBank)
                response = await HttpUtilities.PostAsync(EndPoints.BANKS, Bank);
            else
                response = await HttpUtilities.PutAsync($"{EndPoints.BANKS}/{Bank.Id}", Bank);

            var result = await FormUtils.ProcessHttpReturnAsync(response);

            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Banco gravada com sucesso!");
                if (newBank)
                    await AddOnGridAsync(JsonConvert.DeserializeObject<Bank>(result.Data.ToString()));
                else
                    await UpdateOnGridAsync(JsonConvert.DeserializeObject<Bank>(result.Data.ToString()));
                base.btnSave_Click(sender, e);
            }
        }
        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = gridBanks.GetIdCurrentRow();
            if (id == null) return;
            if (MessageBoxWrapper.ShowYesNo("Deseja excluir esta banco?") == DialogResult.No) return;

            var response = await HttpUtilities.DeleteAsync($"{EndPoints.BANKS}/{id}");
            var result = await FormUtils.ProcessHttpReturnAsync(response);
            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Banco removida com sucesso!");
                await RemoveOnGridAsync(JsonConvert.DeserializeObject<Bank>(result.Data.ToString()));
                base.btnDelete_Click(sender, e);
            }
        }
        protected override async void btnCancel_Click(object sender, EventArgs e)
        {
            base.btnCancel_Click(sender, e);
            SetDataSource();
            await SetToRowAsync(gridBanks.Rows.Count);
        }
        protected override void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
            base.btnExit_Click(sender, e);
        }
        private async void gridBanks_SelectionChanged(object sender, EventArgs e)
        {
            if (loadingForm || buildingDataSource) return;
            var Bank = await GetBankSelectedOnGridAsync();
            if (Bank != null)
                LoadFields(Bank);
        }
        #endregion

        #region Private Methods
        private async Task<Bank> GetBankSelectedOnGridAsync()
        {
            var id = gridBanks.GetIdCurrentRow();
            if (id == null) return null;

            var result = await HttpUtilities.GetAsync($"{EndPoints.BANKS}/{id}");
            var json = result.Content.ReadAsStringAsync().Result;
            var Bank = JsonConvert.DeserializeObject<Bank>(json);
            return Bank;
        }
        private void CloseForm()
        {
            if (btnNew.Enabled)
            {
                Close();
            }
        }
        private void LoadFields(Bank Bank)
        {
            groupFields.ClearControls();
            txtId.Text = Bank.Id.ToText(6);
            txtCode.Text = Bank.Code.ToText();
            txtName.Text = Bank.Name;
            txtBalance.Text = Bank.Balance.ToText();
            chkEntersCashFlow.Checked = Bank.EntersCashFlow;
        }
        private void BuildGrid()
        {
            FormUtils.BuildGrid(gridBanks);

            var IdColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                FillWeight = 30,
                DataPropertyName = nameof(Bank.Id),
                Name = "IdColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, BackColor = Color.Gainsboro, Format = "000000" },
                ReadOnly = true,
                ValueType = typeof(int),
                Visible = true
            };

            var NameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome",
                FillWeight = 70,
                DataPropertyName = nameof(Bank.Name),
                Name = "NameColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            var CodeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Codigo",
                FillWeight = 30,
                DataPropertyName = nameof(Bank.Code),
                Name = "CodeColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, BackColor = Color.Gainsboro, Format = "000" },
                ReadOnly = true,
                ValueType = typeof(int),
                Visible = true
            };

            var BalanceColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Saldo",
                FillWeight = 30,
                DataPropertyName = nameof(Bank.Balance),
                Name = "BalanceColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(decimal),
                Visible = true
            };

            var EntersCashFlowColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Fluxo de Caixa",
                FillWeight = 25,
                DataPropertyName = nameof(Bank.EntersCashFlow),
                Name = "EntersCashFlowColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(bool),
                Visible = true
            };

            gridBanks.Columns.AddRange(IdColumn,
                                           NameColumn,
                                           CodeColumn,
                                           BalanceColumn,
                                           EntersCashFlowColumn);
        }
        private async Task LoadGridAsync()
        {
            var response = await HttpUtilities.GetAsync(EndPoints.BANKS);
            var json = response.Content.ReadAsStringAsync().Result;
            Banks = JsonConvert.DeserializeObject<List<Bank>>(json);
            SetDataSource();
        }
        private void SetDataSource()
        {
            try
            {
                if (Banks.Count > 0)
                {
                    buildingDataSource = true;
                    Banks = Banks.OrderBy(x => x.Id).ToList();
                    gridBanks.DataSource = Banks.ConvertToDatatable<Bank>(c => c.Id);
                }
            }
            finally
            {
                buildingDataSource = false;
            }
        }
        private async Task AddOnGridAsync(Bank Bank)
        {
            Banks.Add(Bank);
            SetDataSource();
            await SetToRowAsync(gridBanks.Rows.Count);
        }
        private async Task UpdateOnGridAsync(Bank Bank)
        {
            var BankToUpdate = Banks.Where(x => x.Id == Bank.Id).FirstOrDefault();
            Bank.CopyAllTo(BankToUpdate);

            var rowIndex = gridBanks.Rows.IndexOf(gridBanks.GetSelectedRow());
            SetDataSource();
            await SetToRowAsync(rowIndex);
        }
        private async Task RemoveOnGridAsync(Bank Bank)
        {
            var BankToDelete = Banks.Where(x => x.Id == Bank.Id).FirstOrDefault();
            Banks.Remove(BankToDelete);
            SetDataSource();
            await SetToRowAsync(gridBanks.Rows.Count);
        }
        private async Task SetToRowAsync(int indexRow)
        {
            gridBanks.EnsureVisibleRow(indexRow);
            if (gridBanks.Rows.Count == 1)
            {
                var Bank = await GetBankSelectedOnGridAsync();
                LoadFields(Bank);
            }
        }
        #endregion

        #region Public Methods

        #endregion
    }
}
