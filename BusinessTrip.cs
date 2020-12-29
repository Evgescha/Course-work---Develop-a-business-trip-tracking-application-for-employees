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
    public partial class BusinessTrip : Form
    {
        public BusinessTrip()
        {
            InitializeComponent();
        }

        private void BusinessTrip_Load(object sender, EventArgs e)
        {
            this.employeeTableAdapter.Fill(this.businesstripcounterDataSet.employee);
            this.expensetypeTableAdapter.Fill(this.businesstripcounterDataSet.expensetype);
            this.expenseTableAdapter.Fill(this.businesstripcounterDataSet.expense);
            this.businesstripTableAdapter.Fill(this.businesstripcounterDataSet.businesstrip);
        }

        private void BusinessTrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.main.Show();
        }

        private void fixName()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                comboBox1.SelectedItem = comboBox1.Items[
                                                           employeeBindingSource.Find(
                                                                       "id",
                                                                       int.Parse(dataGridView1[1, i].Value.ToString())
                                                                       )
                                                           ];
                dataGridView1[5, i].Value = comboBox1.Text;
            }
        }

        private void textBox_OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void fillGrid()
        {
            this.businesstripTableAdapter.Fill(this.businesstripcounterDataSet.businesstrip);
            fixName();
        }
        private bool isFill()
        {
            if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || comboBox1.Items.Count < 1)
            {
                MessageBox.Show("Не все поля заполнены!");
                return false;
            }
            return true;
        }
        private void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (isFill())
                try
                {
                    DataRowView row = (DataRowView)businesstripBindingSource.AddNew();

                    row[1] = comboBox1.SelectedValue;
                    row[2] = dateTimePicker1.Value;
                    row[3] = textBox1.Text;
                    row[4] = textBox2.Text;

                    businesstripBindingSource.EndEdit();
                    this.businesstripTableAdapter.Update(businesstripcounterDataSet);
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
                    dataGridView1.CurrentRow.Cells[1].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[2].Value = dateTimePicker1.Value;
                    dataGridView1.CurrentRow.Cells[3].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[4].Value = textBox2.Text;
                    businesstripBindingSource.EndEdit();
                    this.businesstripTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
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
                    businesstripBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    businesstripBindingSource.EndEdit();
                    businesstripTableAdapter.Update(businesstripcounterDataSet.businesstrip);
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }









        // расходы на командировку



        private void fillGrid2()
        {
            this.expenseTableAdapter.Fill(this.businesstripcounterDataSet.expense);
        }
        private bool isFill2()
        {
            if (textBox3.Text.Length < 1  || comboBox2.Items.Count < 1 || dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("Не все поля заполнены или не выбрана командировка!");
                return false;
            }
            return true;
        }
        private void clearFields2()
        {
            textBox3.Text = "";
        }
        //add
        private void button1_Click222(object sender, EventArgs e)
        {
            if (isFill2())
                try
                {
                    DataRowView row = (DataRowView)expenseibfk1BindingSource.AddNew();

                    row[1] = dataGridView1.CurrentRow.Cells[0].Value;
                    row[2] = comboBox2.SelectedValue;
                    row[3] = textBox3.Text;

                    expenseibfk1BindingSource.EndEdit();
                    this.expenseTableAdapter.Update(businesstripcounterDataSet);
                    clearFields2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            fillGrid2();
        }
        //edit
        private void button2_Click222(object sender, EventArgs e)
        {
            if (isFill2())
                try
                {
                    dataGridView2.CurrentRow.Cells[2].Value = comboBox2.SelectedValue;
                    dataGridView2.CurrentRow.Cells[3].Value = textBox3.Text;

                    expenseibfk1BindingSource.EndEdit();
                    this.expenseTableAdapter.Update(((DataRowView)dataGridView2.CurrentRow.DataBoundItem).Row);
                    clearFields2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            fillGrid2();
        }

        //delete
        private void button3_Click222(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0 && dataGridView2.CurrentRow != null)
            {
                try
                {
                    businesstripcounterDataSet.AcceptChanges();
                    expenseibfk1BindingSource.RemoveAt(dataGridView2.CurrentRow.Index);
                    expenseibfk1BindingSource.EndEdit();
                    expenseTableAdapter.Update(businesstripcounterDataSet.expense);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                fillGrid2();
            }
        }

        private void dataGridView1_Click222(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0 && dataGridView2.CurrentRow != null)
            {
                comboBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            }
        }



    }
}
