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
    public partial class Main : Form
    {
        public static Main main;
        public Main()
        {
            InitializeComponent();
            main = this;
        }
        /// <summary>
        /// Кнопка командировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            new BusinessTrip().Show();
            this.Hide();
        }
        /// <summary>
        /// кропка сотрудники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Hide();
        }
        /// <summary>
        ///  Кнопка должности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            new Position().Show();
            this.Hide();
        }
        /// <summary>
        /// Кнопка тип расходов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            new ExpenseType().Show();
            this.Hide();
        }
    }
}
