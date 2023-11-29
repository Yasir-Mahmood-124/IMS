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
using System.Xml.Linq;

namespace IME
{
    public partial class StudentPanel : UserControl
    {
        public StudentPanel()
        {
            InitializeComponent();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == coursetab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Courses where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    dataTable.Load(reader1);
                }

                courseIdbox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["course_id"].ToString()); // The corresponding value
                    courseIdbox.Items.Add(value);
                }

                courseGV.DataSource = dataTable;
                courseGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                courseGV.ColumnHeadersVisible = true;
                courseGV.RowHeadersVisible = true;
                courseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if (guna2TabControl1.SelectedTab == resulttab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(@"
                                        select m.marks,c.course_name,s.full_name from Courses c inner join
                                        MarkSheets m on m.course_id = c.course_id
                                        inner join Students s on s.student_id = m.student_id where m.student_id=@student_id", con);
                cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    dataTable.Load(reader1);
                }
                resultGV.DataSource = dataTable;
                resultGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                resultGV.ColumnHeadersVisible = true;
                courseGV.RowHeadersVisible = true;
                courseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if (guna2TabControl1.SelectedTab == messagetab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  message from Alerts where student_id = @student_id", con);
                cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);
                StringBuilder messages = new StringBuilder();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string message = reader["message"].ToString();
                            messages.AppendLine(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }


                textBox1.Text = messages.ToString();
            }
            if (guna2TabControl1.SelectedTab == profiletab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  student_id,full_name, email,phone_number FROM Students WHERE username = @username AND password = @password and active = 1", con);
                cmd.Parameters.AddWithValue("@username", UserDL.SignINAdminName.Trim());
                cmd.Parameters.AddWithValue("@password", UserDL.SignInAdminPassword.Trim());
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = reader["full_name"].ToString();
                        string email = reader["email"].ToString();
                        string phoneNumber = reader["phone_number"].ToString();
                        UserDL.adminID = int.Parse(reader["student_id"].ToString());

                        fullnamebox.Text = fullName;
                        passwordbox.Text = UserDL.SignInAdminPassword;
                        usernamebox.Text = UserDL.SignINAdminName;
                        emailbox.Text = email;
                        phonebox.Text = phoneNumber;
                    }
                    else
                    {
                        MessageBox.Show("No user found with the provided credentials.");
                    }
                }
            }
            if (guna2TabControl1.SelectedTab == matrialtab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT cm.material_name,c.course_name,cm.created_at  FROM Students s 
                    INNER JOIN register_courses rc ON s.student_id = rc.student_id
                    INNER JOIN Courses c ON c.course_id = rc.course_id
                    INNER JOIN CourseMaterials cm ON cm.course_id = c.course_id 
                    WHERE rc.active = 1 AND s.active = 1 AND c.active = 1 AND cm.active = 1
                    AND s.student_id = @student_id", con);
                cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);

                DataTable dataTable = new DataTable();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                cmGV.DataSource = dataTable;
                cmGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                cmGV.ColumnHeadersVisible = true;
                cmGV.RowHeadersVisible = true;
                cmGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
        }

        private void addcourse_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("INSERT INTO register_courses values (@course_id, @student_id, @active, @created_at, @updated_at)", con);
            cmd.Parameters.AddWithValue("@course_id", int.Parse(courseIdbox.Text));
            cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);
            cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd.Parameters.AddWithValue("@active", 1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("course add successfully");
            showData();

        }

        private void showData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from register_courses where active  = 1 and student_id = @student_id", con);
            cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader1 = cmd.ExecuteReader())
            {
                dataTable.Load(reader1);
            }

            rcoursesGV.DataSource = dataTable;
            rcoursesGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            rcoursesGV.ColumnHeadersVisible = true;
            rcoursesGV.RowHeadersVisible = true;
            rcoursesGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void viewcbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from register_courses where active  = 1 and student_id = @student_id", con);
            cmd.Parameters.AddWithValue("@student_id", UserDL.adminID);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader1 = cmd.ExecuteReader())
            {
                dataTable.Load(reader1);
            }

            rcoursesGV.DataSource = dataTable;
            rcoursesGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            rcoursesGV.ColumnHeadersVisible = true;
            rcoursesGV.RowHeadersVisible = true;
            rcoursesGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            rcoursesGV.ReadOnly = false;
            if (rcoursesGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = rcoursesGV.SelectedRows[0];
                selectedRow.Cells[0].ReadOnly = true;
                int teacherId = Convert.ToInt32(selectedRow.Cells["register_id"].Value);
                bool updatedPhoneNumber = bool.Parse(selectedRow.Cells["active"].Value.ToString());
                UpdateCourse(teacherId, updatedPhoneNumber);
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
            showData();
        }

        private void UpdateCourse(int studentId, bool updatedFullName)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE register_courses SET active = @active WHERE register_id = @register_id", con);
            cmd.Parameters.AddWithValue("@active", updatedFullName);
            cmd.Parameters.AddWithValue("@register_id", studentId);
            cmd.ExecuteNonQuery();

        }

        private void sendmsgbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  admin_id from Admins where active  = 1", con);
            int adminId = 0;
            try
            {
                adminId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("Insert into Alerts values (@message,@send_date,@created_at,@updated_at,@active,@admin_id,@student_id, @teacher_id)", con);

            cmd1.Parameters.AddWithValue("@message", textBox1.Text);
            cmd1.Parameters.AddWithValue("@send_date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@active", 1);
            cmd1.Parameters.AddWithValue("@admin_id", adminId);
            cmd1.Parameters.AddWithValue("@student_id", UserDL.adminID);
            cmd1.Parameters.AddWithValue("@teacher_id", DBNull.Value);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Message Send successfully");
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            string updatedFullName = fullnamebox.Text.Trim();
            string updatedEmail = emailbox.Text.Trim();
            string updatedPhoneNumber = phonebox.Text.Trim();
            string updatedUsername = usernamebox.Text.Trim();
            string updatedPassword = passwordbox.Text.Trim();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("UPDATE Students SET full_name = @fullName, email = @email, phone_number = @phoneNumber, username = @username, password = @password WHERE student_id = @student_id", con);
            cmd1.Parameters.AddWithValue("@student_id", UserDL.adminID);
            cmd1.Parameters.AddWithValue("@fullName", updatedFullName);
            cmd1.Parameters.AddWithValue("@email", updatedEmail);
            cmd1.Parameters.AddWithValue("@phoneNumber", updatedPhoneNumber);
            cmd1.Parameters.AddWithValue("@username", updatedUsername);
            cmd1.Parameters.AddWithValue("@password", updatedPassword);
            try
            {
                int rowsAffected = cmd1.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User details updated successfully.");
                }
                else
                {
                    MessageBox.Show("No user details were updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
