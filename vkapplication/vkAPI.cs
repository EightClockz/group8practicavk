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

        string Usertoken1;
        string Grouptoken1;
        string GroupId1;
        public vkAPI(string GroupToken, string UserToken, String GroupId)
        {
            InitializeComponent();
            Usertoken1 = UserToken;
            Grouptoken1 = GroupToken;
            GroupId1 = GroupId;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            var api_user = new VkApi(); 
            try
            {
                api_user.Authorize(new ApiAuthParams
                {
                    AccessToken = Usertoken1
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
                    AccessToken = Grouptoken1
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }       
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
                GroupId = GroupId1,
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
                    AccessToken = Usertoken1
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
                s += user.Status + "   ";
                s += user.BirthDate +"    ";
                listBox1.Items.Add(s);
                s = "";
            }
        }

        private void vkAPI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
        
}


