using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounts;

namespace LaboratoryPatternsGOFBehavior
{
    public partial class Form1 : Form,IObserverAccount
    {
        int _counterOperation = 0;

        AccountsHelper _accountsHelper;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            _accountsHelper = new AccountsHelper(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counterOperation++;

            label2.Text = _counterOperation.ToString();

            dataGridView2.DataSource = null;

            dataGridView2.DataSource = _accountsHelper.SimulatingOperation();
        }

        public void UpdateAccount()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = _accountsHelper.Accounts;
        }
    }
}
