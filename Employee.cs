using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessTripCounter
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "businesstripcounterDataSet.position". При необходимости она может быть перемещена или удалена.
            this.positionTableAdapter.Fill(this.businesstripcounterDataSet.position);
            fillGrid();
        }

        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.main.Show();
        }

        private void fixName()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                comboBox1.SelectedItem = comboBox1.Items[
                                                           positionBindingSource.Find(
                                                                       "id",
                                                                       int.Parse(dataGridView1[2, i].Value.ToString())
                                                                       )
                                                           ];
                dataGridView1[3, i].Value = comboBox1.Text;
            }
        }

        private void textBox_OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Char.IsDigit(number)) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void fillGrid()
        {
            this.employeeTableAdapter.Fill(this.businesstripcounterDataSet.employee);
            fixName();
        }
        private bool isFill()
        {
            if (textBox1.Text.Length < 1 || comboBox1.Items.Count<1)
            {
                MessageBox.Show("Не все поля заполнены!");
                return false;
            }
            return true;
        }
        private void clearFields()
        {
            textBox1.Text = "";
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)employeeBindingSource.AddNew();

                    row[1] = textBox1.Text;
                    row[2] = comboBox1.SelectedValue;

                    employeeBindingSource.EndEdit();
                    this.employeeTableAdapter.Update(businesstripcounterDataSet);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            fillGrid();
        }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[3].Value = comboBox1.Text;
                    employeeBindingSource.EndEdit();
                    this.employeeTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            fillGrid();
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                try
                {
                    businesstripcounterDataSet.AcceptChanges();
                    employeeBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    employeeBindingSource.EndEdit();
                    employeeTableAdapter.Update(businesstripcounterDataSet.employee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                fillGrid();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Saver.Save(dataGridView1);
        }
    }
}
