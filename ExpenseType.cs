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
    public partial class ExpenseType : Form
    {
        public ExpenseType()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод закрытия формы. При закрытии открывает предыдущую форму
        /// </summary>
        /// <param name="sender">Dходящий объект</param>
        /// <param name="e">Входящее событие</param>
        private void ExpenseType_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.main.Show();
        }
      /// <summary>
        /// Метод загрузки формы. Инициализирует поля значениями с базы данных
        /// </summary>
        /// <param name="sender">Входящий объект</param>
        /// <param name="e">Входящее событие</param>
        private void ExpenseType_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "businesstripcounterDataSet.expensetype". При необходимости она может быть перемещена или удалена.
            fillGrid();
        }
        /// <summary>
        /// Метод заполнение таблицы данными из бд
        /// </summary>

        private void fillGrid()
        {
            this.expensetypeTableAdapter.Fill(this.businesstripcounterDataSet.expensetype);
        }
        private bool isFill()
        {
            if (textBox1.Text.Length < 1)
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
                    DataRowView row = (DataRowView)expensetypeBindingSource.AddNew();

                    row[0] = textBox1.Text;

                    expensetypeBindingSource.EndEdit();
                    this.expensetypeTableAdapter.Update(businesstripcounterDataSet);
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
                    dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
                    expensetypeBindingSource.EndEdit();
                    this.expensetypeTableAdapter.Update(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);

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
                    expensetypeBindingSource.RemoveAt(dataGridView1.CurrentRow.Index);
                    expensetypeBindingSource.EndEdit();
                    expensetypeTableAdapter.Update(businesstripcounterDataSet.expensetype);
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
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Saver.Save(dataGridView1);
        }
    }
}
