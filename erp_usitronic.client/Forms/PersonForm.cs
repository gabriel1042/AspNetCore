using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.business;
using erp_usitronic.business.models;
using erp_usitronic.client.Forms.LoadingSplash;
using erp_usitronic.client.HttpResources;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace erp_usitronic.client.Forms
{
    public partial class PersonForm : FormBase
    {
        private List<Person> people = new List<Person>();
        private bool loadingForm = true;
        private bool buildingDataSource = false;
        private string zipCodeChange = "";
        private int stateIndexChange = 0;
        private Person selectedPerson = null;

        public PersonForm()
        {
            InitializeComponent();
        }

        #region Events
        private void PersonForm_Load(object sender, EventArgs e)
        {
            base.FormBase_Load(sender, e);
            BuildGrid();
            loadingForm = false;
        }
        private async void PersonForm_Shown(object sender, EventArgs e)
        {
            using (var waiting = Wait.Start(this))
            {
                LoadStates();
                await LoadGridAsync();
                await SetToRowAsync(people.Count);
            }
        }
        private void PersonForm_KeyDown(object sender, KeyEventArgs e)
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
            groupFilters.ClearControls();
            txtName.Focus();
        }
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            base.btnEdit_Click(sender, e);
            groupFilters.ClearControls();
            LoadCities(cboStates.GetSelectedValue());
            if(selectedPerson.FirstAddress!=null)
                cboCities.SetSelectedValue(selectedPerson.FirstAddress.CityId);
            txtName.Focus();
        }
        protected override async void btnSave_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response;
            var person = await BuildEntityAsync();
            bool newPerson = person.Id == 0;

            if (newPerson)
                response = await HttpUtilities.PostAsync(EndPoints.PEOPLE, person);
            else
                response = await HttpUtilities.PutAsync($"{EndPoints.PEOPLE}/{person.Id}", person);

            var result = await FormUtils.ProcessHttpReturnAsync(response);

            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Pessoa gravada com sucesso!");
                if (newPerson)
                    await AddOnGrid(JsonConvert.DeserializeObject<Person>(result.Data.ToString()));
                else
                    await UpdateOnGridAsync(JsonConvert.DeserializeObject<Person>(result.Data.ToString()));
                base.btnSave_Click(sender, e);
            }
        }
        protected override async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = gridPeople.GetIdCurrentRow();
            if (id == null) return;
            if (MessageBoxWrapper.ShowYesNo("Deseja excluir esta pessoa?") == DialogResult.No) return;

            var response = await HttpUtilities.DeleteAsync($"{EndPoints.PEOPLE}/{id}");
            var result = await FormUtils.ProcessHttpReturnAsync(response);
            if (result.Success)
            {
                MessageBoxWrapper.ShowInformation("Pessoa removida com sucesso!");
                await RemoveOnGridAsync(JsonConvert.DeserializeObject<Person>(result.Data.ToString()));
                base.btnDelete_Click(sender, e);
            }
        }
        protected override async void btnCancel_Click(object sender, EventArgs e)
        {
            base.btnCancel_Click(sender, e);
            ApplyFilter();
            await SetToRowAsync(people.Count);
        }
        protected override void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
            base.btnExit_Click(sender, e);
        }
        private async void gridPeople_SelectionChanged(object sender, EventArgs e)
        {
            if (loadingForm || buildingDataSource) return;
            selectedPerson = await GetPersonSelectedOnGridAsync();
            if (selectedPerson != null)
                LoadFields(selectedPerson);
        }

        private void radioPhisycalPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPhisycalPerson.Checked)
            {
                lblCnpj.Text = "CPF:";
                txtCnpj.Mask = "###.###.###-##";
            }
            else
            {
                lblCnpj.Text = "CNPJ:";
                txtCnpj.Mask = "##.###.###/####-##";
            }
            txtCnpj.Text = "";
        }

        private void radioLegalPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioLegalPerson.Checked)
            {
                lblCnpj.Text = "CPF:";
                txtCnpj.Mask = "###.###.###-##";
            }
            else
            {
                lblCnpj.Text = "CNPJ:";
                txtCnpj.Mask = "##.###.###/####-##";
            }
            txtCnpj.Text = "";
        }

        private void chkIsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            groupCustomer.Enabled = chkIsCustomer.Checked;
        }

        private void chkIsSupplier_CheckedChanged(object sender, EventArgs e)
        {
            groupSupplier.Enabled = chkIsSupplier.Checked;
        }

        private void txtZipCode_Leave(object sender, EventArgs e)
        {
            if (txtZipCode.Text == zipCodeChange) return;
            using (var wait = Wait.Start(this))
            {
                var zipCodeModel = HttpUtilities.GetZipCode(txtZipCode.Text);
                if (zipCodeModel != null)
                {
                    txtStreetName.Text = zipCodeModel.StreetName;
                    txtNeighborhood.Text = zipCodeModel.Neightborhood;
                    cboStates.SetPositionByDisplayName(zipCodeModel.State);
                    LoadCities(cboStates.GetSelectedValue());
                    cboCities.SetPositionByDisplayName(zipCodeModel.City);
                }
            }
        }

        private void txtZipCode_Enter(object sender, EventArgs e)
        {
            zipCodeChange = txtZipCode.Text;
        }

        private void cboStates_Enter(object sender, EventArgs e)
        {
            stateIndexChange = cboStates.SelectedIndex;
        }

        private void txtIdFilter_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtIdFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void picCleanFilter_Click(object sender, EventArgs e)
        {
            groupFilters.ClearControls();
        }

        private async void cboStates_Leave(object sender, EventArgs e)
        {
            if (stateIndexChange == cboStates.SelectedIndex) return;
            var stateIndex = cboStates.GetSelectedValue();
            if (stateIndex > -1)
            {
                using (var wait = Wait.Start(this))
                {
                    await LoadCities(stateIndex);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnCleanFilter_Click(object sender, EventArgs e)
        {
            groupFilters.ClearControls();
            await LoadGridAsync();
        }

        private void txtCnpjCpfFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Private Methods
        private void ApplyFilter()
        {
            var idFilter = txtIdFilter.ToNumber();
            var nameFilter = txtNameFilter.Text;
            var cnpjCpfFilter = txtCnpjCpfFilter.Text;
            var isCustomer = chkCustomerFilter.Checked;
            var isSupplier = chkSupplierFilter.Checked;
            List<Person> peopleFiltered = people;

            if (!(isCustomer && isSupplier))
            {
                if (isCustomer)
                    peopleFiltered = peopleFiltered.Where(x => x.IsCustomer == isCustomer).ToList();
                if (isSupplier)
                    peopleFiltered = peopleFiltered.Where(x => x.IsSupplier == isSupplier).ToList();
            }

            if (!string.IsNullOrEmpty(nameFilter))
                peopleFiltered = peopleFiltered.Where(x => x.Name.Contains(nameFilter)).ToList();

            if (!string.IsNullOrEmpty(cnpjCpfFilter))
                peopleFiltered = peopleFiltered.Where(x => x.IdNumber.RemoveSpecialCharacters().Contains(cnpjCpfFilter)).ToList();

            if (idFilter > 0)
                peopleFiltered = peopleFiltered.Where(x => x.Id == idFilter).ToList();

            SetDataSource(peopleFiltered);
        }
        private async         Task
LoadCities(int stateIndex)
        {
            var result = await HttpUtilities.GetAsync($"{EndPoints.STATES}/{stateIndex}");
            var json = await result.Content.ReadAsStringAsync();
            var state = JsonConvert.DeserializeObject<State>(json);
            cboCities.Build(nameof(City.Id), nameof(City.Name), state.Cities);
            cboCities.SetFirstPosition();
        }

        private async void LoadStates()
        {
            var response = await HttpUtilities.GetAsync(EndPoints.STATES);
            var json = await response.Content.ReadAsStringAsync();
            var states = JsonConvert.DeserializeObject<List<State>>(json);
            cboStates.Build(nameof(State.Id), nameof(State.Initial), states);
        }

        private async Task<Person> BuildEntityAsync()
        {
            var id = txtId.ToNumber();
            int idAddress = 0;
            int idEmail = 0;
            int idTelephone = 0;
            int idCustomer = 0;
            int idSupplier = 0;

            if (id > 0)
            {
                var personIds = await GetPersonSelectedOnGridAsync();
                if(personIds.FirstAddress != null)
                    idAddress = personIds.FirstAddress.Id;
                if(personIds.FirstEmail != null)
                    idEmail = personIds.FirstEmail.Id;
                if(personIds.FirstTelephone != null)
                    idTelephone = personIds.FirstTelephone.Id;
                if(personIds.Customers != null )
                    idCustomer = personIds.Customers.First().Id;
                if(personIds.Supplier != null)
                    idSupplier = personIds.Supplier.Id;
            }

            var person = new Person
            {
                Id = id,
                Adresses = new List<Address>(),
                Name = txtName.Text,
                KindPerson = radioLegalPerson.Checked ? 'J' : 'F',
                IdNumber = txtCnpj.Text,
                Emails = new List<Email>(),
                Telephones = new List<Telephone>(),                
            };

            var address = new Address
            {
                Id = idAddress,
                StreetName = txtStreetName.Text,
                Number = txtNumber.Text,
                Neighborhood = txtNeighborhood.Text,
                PersonId = id,
                ZipCode = txtZipCode.Text,
                CityId = cboCities.GetSelectedValue()
            };

            person.Adresses.Add(address);

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                var email = new Email
                {
                    Description = txtEmail.Text,
                    PersonId = id,
                    Id = idEmail
                };
                person.Emails.Add(email);
            }

            if (!string.IsNullOrEmpty(txtTelephone.Text))
            {
                var telephone = new Telephone
                {
                    Number = txtTelephone.Text,
                    Id = idTelephone,
                    PersonId = id
                };
                person.Telephones.Add(telephone);
            }

            if (chkIsCustomer.Checked)
            {
                var customer = new Customer
                {
                    Id = idCustomer,
                    StateRegistration = txtCustomerStateRegistration.Text,
                    CompanyName = txtCustomerCompanyName.Text,
                    PersonId = id
                };
                person.Customers.Add(customer);
            }

            if (chkIsSupplier.Checked)
            {
                var supplier = new Supplier
                {
                    Id = idSupplier,
                    StateRegistration = txtSupplierStateRegistration.Text,
                    CompanyName = txtSupplierCompanyName.Text,
                    PersonId = id
                };
                person.Supplier = supplier;
            }
            return person;
        }

        private async Task<Person> GetPersonSelectedOnGridAsync()
        {
            var id = gridPeople.GetIdCurrentRow();
            if (id == null) return null;

            var result = await HttpUtilities.GetAsync($"{EndPoints.PEOPLE}/{id}");
            var json = await result.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<Person>(json);
            return person;
        }
        private void CloseForm()
        {
            if (btnNew.Enabled)
            {
                Close();
            }
        }
        private void LoadFields(Person person)
        {
            groupFields.ClearControls();
            txtId.Text = person.Id.ToText(6);
            txtName.Text = person.Name;
            if(person.FirstEmail != null)
                txtEmail.Text = person.FirstEmail.Description;
            if(person.FirstTelephone != null)
                txtTelephone.Text = person.FirstTelephone.Number;
            if (person.KindPerson == 'J')
                radioLegalPerson.Checked = true;
            else
                radioPhisycalPerson.Checked = true;
            txtCnpj.Text = person.IdNumber;
            var address = person.FirstAddress;
            if (address != null)
            {
                txtZipCode.Text = address.ZipCode;
                txtStreetName.Text = address.StreetName;
                txtNumber.Text = address.Number;
                txtNeighborhood.Text = address.Neighborhood;
                if (address.City != null)
                {
                    cboStates.SetSelectedValue(address.City.StateId);
                    cboCities.Text = address.City.Name;
                }
            }

            chkIsCustomer.Checked = person.IsCustomer;
            chkIsSupplier.Checked = person.IsSupplier;
            groupCustomer.Enabled = person.IsCustomer;
            groupSupplier.Enabled = person.IsSupplier;

            if (person.IsCustomer)
            {
                txtCustomerCompanyName.Text = person.Customers.First().CompanyName;
                txtCustomerStateRegistration.Text = person.Customers.First().StateRegistration;
            }
            if (person.IsSupplier)
            {
                txtSupplierCompanyName.Text = person.Supplier.CompanyName;
                txtSupplierStateRegistration.Text = person.Supplier.StateRegistration;
            }

        }
        private void BuildGrid()
        {
            FormUtils.BuildGrid(gridPeople);

            var IdColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Código",
                FillWeight = 30,
                DataPropertyName = nameof(Person.Id),
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
                FillWeight = 100,
                DataPropertyName = nameof(Person.Name),
                Name = "NameColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            var TelephoneColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cnpj/Cpf",
                FillWeight = 40,
                DataPropertyName = nameof(Person.IdNumber),
                Name = "CnpjCpfColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(string),
                Visible = true
            };

            var IsCustomerColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Cliente",
                FillWeight = 15,
                DataPropertyName = nameof(Person.IsCustomer),
                Name = "IsCustomerColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(bool),
                Visible = true
            };

            var IsSupplierColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Fornec.",
                FillWeight = 15,
                DataPropertyName = nameof(Person.IsSupplier),
                Name = "IsSupplierColumn",
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                ReadOnly = true,
                ValueType = typeof(bool),
                Visible = true
            };
            
            gridPeople.Columns.AddRange(IdColumn,
                                        NameColumn,
                                        TelephoneColumn,
                                        IsCustomerColumn,
                                        IsSupplierColumn);
        }
        private async Task LoadGridAsync()
        {
            var response = await HttpUtilities.GetAsync(EndPoints.PEOPLE);
            var json = response.Content.ReadAsStringAsync().Result;
            people = JsonConvert.DeserializeObject<List<Person>>(json);
            SetDataSource();
        }

        private void SetDataSource(List<Person> people)
        {
            try
            {
                if (people.Count > 0)
                {
                    people.ForEach(x => x.IdNumber =
                Convert.ToUInt64(x.IdNumber.Replace(".", "").Replace("-", "").Replace("/", "")).ToString());
                    people.ForEach(x => x.IdNumber = x.IdNumber.Length == 14 ?
                Convert.ToUInt64(x.IdNumber).ToString(@"00\.000\.000\/0000\-00") :
                Convert.ToUInt64(x.IdNumber).ToString(@"000\.000\.000\-00"));

                    people = people.OrderBy(x => x.Id).ToList();
                }
                gridPeople.DataSource = people.ConvertToDatatable<Person>(c => c.Id);
            }
            finally
            {
                buildingDataSource = false;
            }
        }
        private void SetDataSource()
        {
            buildingDataSource = true;
            SetDataSource(people);
        }
        private async Task AddOnGrid(Person Person)
        {
            people.Add(Person);
            SetDataSource();
            await SetToRowAsync(gridPeople.Rows.Count);
        }
        private async Task UpdateOnGridAsync(Person Person)
        {
            var PersonToUpdate = people.Where(x => x.Id == Person.Id).FirstOrDefault();
            Person.CopyAllTo(PersonToUpdate);

            var rowIndex = gridPeople.Rows.IndexOf(gridPeople.GetSelectedRow());
            SetDataSource();
            await SetToRowAsync(rowIndex);
        }
        private async Task RemoveOnGridAsync(Person Person)
        {
            var PersonToDelete = people.Where(x => x.Id == Person.Id).FirstOrDefault();
            people.Remove(PersonToDelete);
            SetDataSource();
            await SetToRowAsync(gridPeople.Rows.Count);
        }
        private async Task SetToRowAsync(int indexRow)
        {
            gridPeople.EnsureVisibleRow(indexRow);
            if (gridPeople.Rows.Count == 1)
            {
                var person = await GetPersonSelectedOnGridAsync();
                LoadFields(person);
            }
        }




        #endregion

        #region Public Methods

        #endregion
    }

}
