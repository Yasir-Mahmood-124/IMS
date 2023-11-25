using IME.Classes.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IME
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }


        private void add_student_Click(object sender, EventArgs e)
        {




        }

        private void Profile_View_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  admin_id,full_name, email,phone_number FROM Admins WHERE username = @username AND password = @password and active = 1", con);
            cmd.Parameters.AddWithValue("@username", UserDL.SignINAdminName.Trim());
            cmd.Parameters.AddWithValue("@password", UserDL.SignInAdminPassword.Trim());
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string fullName = reader["full_name"].ToString();
                    string email = reader["email"].ToString();
                    string phoneNumber = reader["phone_number"].ToString();
                    UserDL.adminID = int.Parse(reader["admin_id"].ToString());

                    name.Text = fullName;
                    password.Text = UserDL.SignInAdminPassword;
                    username.Text = UserDL.SignINAdminName;
                    emailBox.Text = email;
                    phonenumberbox.Text = phoneNumber;
                }
                else
                {
                    MessageBox.Show("No user found with the provided credentials.");
                }
            }

        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            string updatedFullName = name.Text.Trim();
            string updatedEmail = emailBox.Text.Trim();
            string updatedPhoneNumber = phonenumberbox.Text.Trim();
            string updatedUsername = username.Text.Trim();
            string updatedPassword = password.Text.Trim();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("UPDATE Admins SET full_name = @fullName, email = @email, phone_number = @phoneNumber, username = @username, password = @password WHERE admin_id = @adminId", con);

            cmd1.Parameters.AddWithValue("@adminId", UserDL.adminID);
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

        private void add_student_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from students where active  = 0", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            studentGV.DataSource = dataTable;
            studentGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            studentGV.ColumnHeadersVisible = true;
            studentGV.RowHeadersVisible = true;
            studentGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);


        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            studentGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (studentGV.SelectedRows.Count > 0)
            {

                int studentId = Convert.ToInt32(studentGV.SelectedRows[0].Cells[8].Value);
                UpdateStudentStatus(studentId, true);
            }

        }


        private void UpdateStudentStatus(int studentId, bool newStatus)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Students SET active = @active WHERE student_id = @student_id", con);
            cmd.Parameters.AddWithValue("@active", 1);
            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.ExecuteNonQuery();
            updateDataGridView();
        }

        private void updateDataGridView()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from students where active  = 0", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            studentGV.DataSource = dataTable;
            studentGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            studentGV.ColumnHeadersVisible = true;
            studentGV.RowHeadersVisible = true;
            studentGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            studentGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (studentGV.SelectedRows.Count > 0)
            {
                studentGV.AllowUserToAddRows = false;

                int studentId = Convert.ToInt32(studentGV.SelectedRows[0].Cells[8].Value);
                DeleteStudent(studentId);
                studentGV.Rows.RemoveAt(studentGV.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
            updateDataGridView();
        }

        private void DeleteStudent(int studentId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Students SET active = @active WHERE student_id = @student_id", con);
            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.Parameters.AddWithValue("@active", 0);
            cmd.ExecuteNonQuery();
        }

        private void allstudentbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from students where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            studentGV.DataSource = dataTable;
            studentGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            studentGV.ColumnHeadersVisible = true;
            studentGV.RowHeadersVisible = true;
            studentGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void update_Button_Click(object sender, EventArgs e)
        {
            studentGV.ReadOnly = false; // Allow editing
            if (studentGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = studentGV.SelectedRows[0];

                int studentId = Convert.ToInt32(selectedRow.Cells["student_id"].Value); // Replace "StudentId" with the name of your ID column
                string updatedUserName = selectedRow.Cells["username"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedFullName = selectedRow.Cells["full_name"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedEmail = selectedRow.Cells["email"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedPhoneNumber = selectedRow.Cells["phone_number"].Value.ToString(); // Replace "Name" with the name of your column

                UpdateStudent(studentId, updatedUserName, updatedFullName, updatedEmail, updatedPhoneNumber);
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void UpdateStudent(int studentId, string updatedUserName, string updatedFullName, string updatedEmail, string updatedPhoneNumber)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Students SET username = @username ,full_name = @full_name,email=@email,phone_number = @phone_number WHERE student_id = @student_id", con);


            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.Parameters.AddWithValue("@username", updatedUserName);
            cmd.Parameters.AddWithValue("@full_name", updatedFullName);
            cmd.Parameters.AddWithValue("@email", updatedEmail);
            cmd.Parameters.AddWithValue("@phone_number", updatedPhoneNumber);

            cmd.ExecuteNonQuery();

        }


        private void add_student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add_student.SelectedTab == Profile_View)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  admin_id,full_name, email,phone_number FROM Admins WHERE username = @username AND password = @password and active = 1", con);
                cmd.Parameters.AddWithValue("@username", UserDL.SignINAdminName.Trim());
                cmd.Parameters.AddWithValue("@password", UserDL.SignInAdminPassword.Trim());
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = reader["full_name"].ToString();
                        string email = reader["email"].ToString();
                        string phoneNumber = reader["phone_number"].ToString();
                        UserDL.adminID = int.Parse(reader["admin_id"].ToString());

                        name.Text = fullName;
                        password.Text = UserDL.SignInAdminPassword;
                        username.Text = UserDL.SignINAdminName;
                        emailBox.Text = email;
                        phonenumberbox.Text = phoneNumber;
                    }
                    else
                    {
                        MessageBox.Show("No user found with the provided credentials.");
                    }
                }
            }
            if (add_student.SelectedTab == tabPage2)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Teachers where active  = 0", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                teacherGV.DataSource = dataTable;
                teacherGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                teacherGV.ColumnHeadersVisible = true;
                teacherGV.RowHeadersVisible = true;
                teacherGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if(add_student.SelectedTab == coursetab)
            {
               
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            teacherGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (teacherGV.SelectedRows.Count > 0)
            {

                int teacherId = Convert.ToInt32(teacherGV.SelectedRows[0].Cells[8].Value);
                UpdateTeacherStatus(teacherId, true);
            }
        }

        private void UpdateTeacherStatus(int teacherId, bool newStatus)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Teachers SET active = @active WHERE teacher_id = @teacher_id", con);
            cmd.Parameters.AddWithValue("@active", 1);
            cmd.Parameters.AddWithValue("@teacher_id", teacherId);
            cmd.ExecuteNonQuery();
            updateTeacherDataGridView();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            teacherGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (teacherGV.SelectedRows.Count > 0)
            {
                teacherGV.AllowUserToAddRows = false;

                int studentId = Convert.ToInt32(teacherGV.SelectedRows[0].Cells[8].Value);
                DeleteTeacher(studentId);
                teacherGV.Rows.RemoveAt(teacherGV.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
            updateTeacherDataGridView();
        }

        private void updateTeacherDataGridView()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from Teachers where active  = 0", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            teacherGV.DataSource = dataTable;
            teacherGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            teacherGV.ColumnHeadersVisible = true;
            teacherGV.RowHeadersVisible = true;
            teacherGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void DeleteTeacher(int studentId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Teachers SET active = @active WHERE teacher_id = @teacher_id", con);
            cmd.Parameters.AddWithValue("@teacher_id", studentId);
            cmd.Parameters.AddWithValue("@active", 0);
            cmd.ExecuteNonQuery();
        }

        private void view_button_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from Teachers where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            teacherGV.DataSource = dataTable;
            teacherGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            teacherGV.ColumnHeadersVisible = true;
            teacherGV.RowHeadersVisible = true;
            teacherGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void update_button1_Click(object sender, EventArgs e)
        {
            studentGV.ReadOnly = false; // Allow editing
            if (teacherGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = teacherGV.SelectedRows[0];

                int teacherId = Convert.ToInt32(selectedRow.Cells["teacher_id"].Value); // Replace "StudentId" with the name of your ID column
                string updatedUserName = selectedRow.Cells["username"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedFullName = selectedRow.Cells["full_name"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedEmail = selectedRow.Cells["email"].Value.ToString(); // Replace "Name" with the name of your column
                string updatedPhoneNumber = selectedRow.Cells["phone_number"].Value.ToString(); // Replace "Name" with the name of your column

                UpdateTeacher(teacherId, updatedUserName, updatedFullName, updatedEmail, updatedPhoneNumber);
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void UpdateTeacher(int studentId, string updatedUserName, string updatedFullName, string updatedEmail, string updatedPhoneNumber)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Teachers SET username = @username ,full_name = @full_name,email=@email,phone_number = @phone_number WHERE teacher_id = @teacher_id", con);


            cmd.Parameters.AddWithValue("@teacher_id", studentId);
            cmd.Parameters.AddWithValue("@username", updatedUserName);
            cmd.Parameters.AddWithValue("@full_name", updatedFullName);
            cmd.Parameters.AddWithValue("@email", updatedEmail);
            cmd.Parameters.AddWithValue("@phone_number", updatedPhoneNumber);

            cmd.ExecuteNonQuery();

        }

        private void add_course_Click(object sender, EventArgs e)
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
            SqlCommand cmd1 = new SqlCommand("Insert into Courses values ( @course_name,@created_at,@updated_at,@active,@admin_id)", con);
            cmd1.Parameters.AddWithValue("@course_name", nametext.Text);
            cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@active", 1);
            cmd1.Parameters.AddWithValue("@admin_id", adminId);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("user add successfully");
        }
    }
}
