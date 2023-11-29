using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IME.Classes.DL;
using IME.Classes.BL;

namespace IME
{
    public partial class SignUp : UserControl
    {

        public SignUp()
        {
            InitializeComponent();
        }

        private void emailBox_Validating(object sender, CancelEventArgs e)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+com$";
            if (!Regex.IsMatch(emailBox.Text, emailPattern))
            {
                e.Cancel = true;
                emailBox.Focus();
                MessageBox.Show("Invalid Email");
            }
            else
            {
                e.Cancel = false;
            }
        }


        private void passwordbox_Validating(object sender, CancelEventArgs e)
        {
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$";
            if (!Regex.IsMatch(passwordbox.Text, passwordPattern))
            {
                e.Cancel = true;
                passwordbox.Focus();
                MessageBox.Show(passwordbox, "Password must be at least 6 characters and include uppercase, lowercase, number, and special character.");
            }
            else
            {
                e.Cancel = false;

            }
        }

        private void phonebox_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumberPattern = @"^03\d{2}\d{7}$";
            if (!Regex.IsMatch(phonebox.Text, phoneNumberPattern))
            {
                e.Cancel = true;
                phonebox.Focus();
                MessageBox.Show(phonebox, "Invalid phone number. Format: 03XXYYYYYYY");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void signUPbutton_Click(object sender, EventArgs e)
        {
            if (emailBox.Text != "" && nameBox.Text != "" && passwordbox.Text != "" && userbox.Text != "" && phonebox.Text != "" )
            {
                var con = Configuration.getInstance().getConnection();
                string email = "";
                string phone = "";
                string password = "";
                string userName = "";
                string fullName = "";
                string userType = "";
                email = emailBox.Text;
                phone = phonebox.Text;
                MessageBox.Show(phone);
                userName = userbox.Text;
                password = passwordbox.Text;
                fullName = nameBox.Text;
                userType = usertype.Text;
                USERS tempUser = new USERS();
                tempUser.UserName = userName;
                tempUser.Name = fullName;
                tempUser.Email = email;
                tempUser.Phone = phone;
                tempUser.Password = password;
                tempUser.UserType = usertype.Text;

                UserDL.users.Add(tempUser);
                if (usertype.Text.ToLower() == "teacher")
                {
                    SqlCommand cmd = new SqlCommand("Insert into Teachers values ( @username,@password,@fullname,@email,@phone_number,@created_at,@updated_at,@active)", con);
                    cmd.Parameters.AddWithValue("@username", userbox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordbox.Text);
                    cmd.Parameters.AddWithValue("@fullname", nameBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@phone_number", phonebox.Text);
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@active", 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user add successfully");
                    SIGNIN admin = new SIGNIN();
                    this.Controls.Clear();
                    this.Controls.Add(admin);
                }
                if (usertype.Text.ToLower() == "student")
                {
                    SqlCommand cmd = new SqlCommand("Insert into Students values (@username,@password,@fullname,@email,@phone_number,@created_at,@updated_at,@active)", con);
                    cmd.Parameters.AddWithValue("@username", userbox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordbox.Text);
                    cmd.Parameters.AddWithValue("@fullname", nameBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@phone_number", phonebox.Text); 
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@active", 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user add successfully");
                    SIGNIN admin = new SIGNIN();
                    this.Controls.Clear();
                    this.Controls.Add(admin);
                }
            }
        }
    }
}
