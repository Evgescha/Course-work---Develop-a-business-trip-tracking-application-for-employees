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
        //поездки
        private void button1_Click(object sender, EventArgs e)
        {
            new BusinessTrip().Show();
            this.Hide();
        }
        //Сотрудники
        private void button4_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Hide();
        }
        //должности
        private void button3_Click(object sender, EventArgs e)
        {
            new Position().Show();
            this.Hide();
        }
        //типы расходов
        private void button2_Click(object sender, EventArgs e)
        {
            new ExpenseType().Show();
            this.Hide();
        }
    }
}
