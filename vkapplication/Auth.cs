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
            string GroupToken = textBox2.Text;
            string UserToken = textBox1.Text;
            string GroupId = textBox3.Text;
            vkAPI f2 = new vkAPI(GroupToken, UserToken, GroupId);
            this.Hide();
            f2.Show();
        }
    }
}
