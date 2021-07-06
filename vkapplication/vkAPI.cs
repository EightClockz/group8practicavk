using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vkapplication
{
    public partial class vkAPI : Form
    {
        public vkAPI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private string getAuthForGroup()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Error!");
            }
            return textBox1.Text;          
        }
        private string getAuthForUser()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Error!");
            }
            return textBox2.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            var api_user = new VkApi(); 
            try
            {
                api_user.Authorize(new ApiAuthParams
                {
                    AccessToken = getAuthForUser()
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            var getFriends = api_user.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = VkNet.Enums.Filters.ProfileFields.All
            });
            foreach (User user in getFriends)
                listBox1.Items.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)));


            var get = api_user.Wall.Get(new WallGetParams());
            foreach (var wallPosts in get.WallPosts)
             listBox2.Items.Add(Encoding.Default.GetString(Encoding.UTF8.GetBytes(wallPosts.Text)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var api_group = new VkApi();
            try
            {
                api_group.Authorize(new ApiAuthParams
                {
                    AccessToken = getAuthForGroup()
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }       
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
                GroupId = textBox3.Text,
                Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl
            });
            foreach (User user in getFollowers)
                listBox1.Items.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)));  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var api_user = new VkApi();
            try
            {
                api_user.Authorize(new ApiAuthParams
                {
                    AccessToken = getAuthForUser()
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }

            var getFriends = api_user.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                Fields = VkNet.Enums.Filters.ProfileFields.All
            });
            string s = "";
            foreach (User user in getFriends)
            {
                s += (Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + "   " + user.LastName + "   ")));
                s += user.Sex + "   ";
                s += user.Relation + "    ";
                s += user.HasMobile + "   ";
                s += user.BirthDate +"    ";
                listBox1.Items.Add(s);
                s = "";
            }
        }
    }
        
}


