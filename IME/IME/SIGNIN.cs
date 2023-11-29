using IME.Classes.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IME
{
    public partial class SIGNIN : UserControl
    {
        public SIGNIN()
        {
            InitializeComponent();
        }

        private void signUPbutton_Click(object sender, EventArgs e)
        {
            if (userBox.Text != "" && passwordbox.Text != "" )
            {
                string userName = userBox.Text;
                string password = passwordbox.Text;
                if(usertype.Text.ToLower() == "student")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students WHERE username = @username AND password = @password", con);

                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    
                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        UserDL.SignINAdminName = userName;
                        UserDL.SignInAdminPassword = password;
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM Students WHERE username = @username", con);

                        cmd1.Parameters.AddWithValue("@username", UserDL.SignINAdminName);
                        int student_id;
                        try
                        {
                            using (SqlDataReader reader = cmd1.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader["username"].ToString() == UserDL.SignINAdminName)
                                    {
                                        //studentIds.Add(reader.GetInt32(0)); // Assuming student_id is the first column
                                        UserDL.adminID = int.Parse(reader["student_id"].ToString());
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                        cmd.ExecuteNonQuery();
                        StudentPanel student = new StudentPanel();
                        this.Controls.Clear();
                        this.Controls.Add(student);
                        MessageBox.Show("You're logged in!");
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                    }
                }
                else if (usertype.Text.ToLower() == "teacher")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Teachers WHERE username = @username AND password = @password", con);

                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("You're logged in!");
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                    }
                }
                else if(usertype.Text.ToLower() == "admin")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM admins WHERE username = @username AND password = @password", con);

                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        UserDL.SignINAdminName = userName;
                        UserDL.SignInAdminPassword = password;
                        MessageBox.Show("You're logged in!");
                        Admin admin = new Admin();
                        this.Controls.Clear();
                        this.Controls.Add(admin);

                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                    }
                }
                else
                {
                    MessageBox.Show("please select correct type");
                }
            }
        }
    }
}
