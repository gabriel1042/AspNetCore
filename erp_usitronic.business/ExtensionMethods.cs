using erp_usitronic.business.models;
using FastMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace erp_usitronic.business
{
    public static class ExtensionMethods
    {                

        #region Number to String
        public static string ToText(this int number, int padLeftNumber)
        {
            return number.ToString().PadLeft(padLeftNumber, '0');
        }
        public static string ToText(this int number)
        {
            return number.ToString();
        }
        public static string ToText(this decimal number)
        {
            return number.ToString();
        }

        #endregion

        #region Controls - Form
        public static void RodarEmThreadSeparada(this Form form, bool emBackground)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));
            if (form.IsHandleCreated)
#pragma warning disable CA1303 // Não passar literais como parâmetros localizados
                throw new InvalidOperationException("O Formulário já está sendo exibido.");
#pragma warning restore CA1303 // Não passar literais como parâmetros localizados
            var formThread = new Thread(ApplicationRunProc);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.IsBackground = emBackground;
            formThread.Start(form);
        }
        private static void ApplicationRunProc(object state)
        {
            if (state is Form form)
            {
                Application.Run(form);
            }
        }
        private static void ClearControl(Control control)
        {
            foreach (ListBox listBox in control.Controls.OfType<ListBox>())
            {
                listBox.Items.Clear();
            }
            foreach (CheckedListBox listBox in control.Controls.OfType<CheckedListBox>())
            {
                listBox.Items.Clear();
            }
            foreach (ListView listView in control.Controls.OfType<ListView>())
            {
                listView.Items.Clear();
            }
            foreach (CheckBox checkBox in control.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            foreach (TextBoxBase textBox in control.Controls.OfType<TextBoxBase>())
            {
                textBox.Text = string.Empty;
            }
            foreach (GroupBox groupBox in control.Controls.OfType<GroupBox>())
            {
                groupBox.ClearControls();
            }

            foreach (ComboBox comboBox in control.Controls.OfType<ComboBox>())
            {
                comboBox.Text = "";
                comboBox.SelectedIndex = -1;
            }

            foreach (Panel panel in control.Controls.OfType<Panel>())
            {
                panel.ClearControls();
            }
        }
        public static void ClearControls(this GroupBox control)
        {
            ClearControl(control);
        }
        public static void ClearControls(this Panel control)
        {
            ClearControl(control);
        }
        #region ComboBox
        public static int GetSelectedValue(this ComboBox combo)
        {
            if (combo.SelectedValue == null) return -1;
            return (int)combo.SelectedValue;
        }
        public static void SetSelectedValue(this ComboBox combo, int value)
        {
            combo.SelectedValue = value;
        }
        public static void Build(this ComboBox combo,
                                 string propertyNameIndexValue,
                                 string propertyNameToDisplay,
                                 object list)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            combo.DisplayMember = propertyNameToDisplay;
            combo.ValueMember = propertyNameIndexValue;
            combo.DataSource = list;
        }
        public static void SetFirstPosition(this ComboBox combo)
        {
            if(combo.Items.Count> 0)
                combo.SelectedIndex = 0;
        }
        public static void SetPositionByDisplayName(this ComboBox combo, string description)
        {
            combo.SelectedIndex = combo.FindStringExact(description);
        }
        #endregion
        #endregion

        #region String to Number
        public static int ToNumber(this TextBoxBase textBox)
        {
            if(int.TryParse(textBox.Text, out int number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this TextBoxBase textBox)
        {
            if (decimal.TryParse(textBox.Text, out decimal number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Util Classes
        public static void CopyAllTo<T>(this T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                if(targetProperty.SetMethod !=null)
                    targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);   
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }
        #endregion

        #region DataGridView
        public static DataTable ConvertToDatatable(this IList source, String nameColumnPK)
        {
            try
            {
                if (source == null) throw new ArgumentNullException();
                var table = new DataTable();
                if (source.Count == 0) return table;

                Type itemType = source[0].GetType();
                table.TableName = itemType.Name;
                List<string> names = new List<string>();
                foreach (var prop in itemType.GetProperties())
                {
                    if (prop.CanRead && prop.GetIndexParameters().Length == 0)
                    {
                        names.Add(prop.Name);
                        Type propType = prop.PropertyType;
                        if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            propType = propType.GetGenericArguments()[0];
                        }
                        DataColumn column = new DataColumn(prop.Name, propType);
                        table.Columns.Add(column);
                        if (nameColumnPK != null && nameColumnPK == prop.Name)
                            table.PrimaryKey = new DataColumn[] { column };
                    }
                }
                names.TrimExcess();

                var accessor = TypeAccessor.Create(itemType);
                object[] values = new object[names.Count];
                foreach (var row in source)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = accessor[row, names[i]];
                    }
                    table.Rows.Add(values);
                }

                return table;
            }
            catch
            {
                throw;
            }
        }
        public static DataTable ConvertToDatatable<T>(this IList source, Expression<Func<T, object>> columnPK)
        {
            String member = ((columnPK.Body as UnaryExpression).Operand as System.Linq.Expressions.MemberExpression).Member.Name;
            return ConvertToDatatable(source, member);
        }
        public static int? GetIdCurrentRow(this DataGridView grid)
        {
            var row = grid.GetSelectedRow();
            if (row?.Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                return (int)row.Cells[0].Value;
            }
        }
        public static void EnsureVisibleRow(this DataGridView grid, int rowToShow)
        {
            if (rowToShow == grid.RowCount) rowToShow--;
            if (rowToShow >= 0 && rowToShow < grid.RowCount)
            {
                var countVisible = grid.DisplayedRowCount(false);
                var firstVisible = grid.FirstDisplayedScrollingRowIndex;
                if (rowToShow < firstVisible)
                {
                    grid.FirstDisplayedScrollingRowIndex = rowToShow;
                }
                else if (rowToShow >= firstVisible + countVisible)
                {
                    if(countVisible>0)
                        grid.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
                }
                grid.Rows[rowToShow].Selected = true;
            }
        }
        public static DataGridViewRow GetSelectedRow(this DataGridView grid)
        {
            return grid.SelectedRows.OfType<DataGridViewRow>().FirstOrDefault();
        }
        #endregion

        #region Strings
        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }
        #endregion 
    }
}
