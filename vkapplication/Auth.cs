using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vkapplication
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string GroupToken ="";
            string UserToken ="" ;
            string GroupId ="";
            if (textBox2.Text != "")
            {
                GroupToken = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                Environment.Exit(1);
            }
            if (textBox1.Text != "")
            {
                 UserToken = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                Environment.Exit(1);
            }
            if (textBox1.Text != "")
            {
                GroupId = textBox3.Text;

            }
            else
            {
                MessageBox.Show("Заполните все поля");
                Environment.Exit(1);
            }
            vkAPI f2 = new vkAPI(GroupToken, UserToken, GroupId);
            this.Hide();
            f2.Show();
        }
    }
}
