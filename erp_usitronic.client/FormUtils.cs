using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.client.HttpResources;
using Newtonsoft.Json;
using erp_usitronic.business;

namespace erp_usitronic.client
{
    public static class FormUtils
    {
        public static async Task<DefaultResponse> ProcessHttpReturnAsync(HttpResponseMessage response)
        {
            var jsonBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DefaultResponse>(jsonBody);            
            if(!result.Success)
            {
                var errorMsg = new StringBuilder();
                errorMsg.Append("Ocorreram os seguintes erros ao gravar:\n\n");
                foreach (var error in result.Errors)
                {
                    errorMsg.AppendLine(error);
                }
                MessageBoxWrapper.ShowError(errorMsg.ToString());
            }
            return result;
        }

        public static void BuildGrid(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.MultiSelect = false;
        }
        
    }
}
