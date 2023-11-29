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
            if (add_student.SelectedTab == coursetab)
            {

            }
            if (add_student.SelectedTab == feetab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Students where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                studentIdbox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["student_id"].ToString()); // The corresponding value
                    studentIdbox.Items.Add(value);
                }

                feestudentGV.DataSource = dataTable;
                feestudentGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                feestudentGV.ColumnHeadersVisible = true;
                feestudentGV.RowHeadersVisible = true;
                feestudentGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

                cmd = new SqlCommand("SELECT  * from register_courses where active  = 1", con);
                dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);

                }
                courseIdbox.Items.Clear();


                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["course_id"].ToString());
                    courseIdbox.Items.Add(value);
                }


                feeCourseGV.DataSource = dataTable;
                feeCourseGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                feeCourseGV.ColumnHeadersVisible = true;
                feeCourseGV.RowHeadersVisible = true;
                feeCourseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);


            }
            if (add_student.SelectedTab == salarytab)
            {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Teachers where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                teacherIdbox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["teacher_id"].ToString()); // The corresponding value
                    teacherIdbox.Items.Add(value);
                }

                teachersalaryGV.DataSource = dataTable;
                teachersalaryGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                teachersalaryGV.ColumnHeadersVisible = true;
                teachersalaryGV.RowHeadersVisible = true;
                teachersalaryGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if (add_student.SelectedTab == chattab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Students where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                studentmsgId.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["student_id"].ToString()); // The corresponding value
                    studentmsgId.Items.Add(value);
                }

                studentmessageGV.DataSource = dataTable;
                studentmessageGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                studentmessageGV.ColumnHeadersVisible = true;
                studentmessageGV.RowHeadersVisible = true;
                studentmessageGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if(add_student.SelectedTab == tabPage6)
            {
                SIGNIN signin = new SIGNIN();
                this.Controls.Clear();
                this.Controls.Add(signin);
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
            teacherGV.ReadOnly = false; // Allow editing
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
            if (nametext.Text != "")
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
                MessageBox.Show("course add successfully");
            }
            else
            {

                MessageBox.Show("Please add the course Name");
            }
        }

        private void viewbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from courses where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            courseGV.DataSource = dataTable;
            courseGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            courseGV.ColumnHeadersVisible = true;
            courseGV.RowHeadersVisible = true;
            courseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            courseGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (courseGV.SelectedRows.Count > 0)
            {
                courseGV.AllowUserToAddRows = false;

                int studentId = Convert.ToInt32(courseGV.SelectedRows[0].Cells[5].Value);
                DeleteCourse(studentId);
                courseGV.Rows.RemoveAt(courseGV.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
            updateCourseDataGridView();
        }

        private void DeleteCourse(int studentId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Courses SET active = @active WHERE course_id = @course_id", con);
            cmd.Parameters.AddWithValue("@course_id", studentId);
            cmd.Parameters.AddWithValue("@active", 0);
            cmd.ExecuteNonQuery();
        }

        private void updateCourseDataGridView()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from courses where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            courseGV.DataSource = dataTable;
            courseGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            courseGV.ColumnHeadersVisible = true;
            courseGV.RowHeadersVisible = true;
            courseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

        }

        private void updatecoursebutton_Click(object sender, EventArgs e)
        {
            courseGV.ReadOnly = false; // Allow editing
            if (courseGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = courseGV.SelectedRows[0];

                int courseId = Convert.ToInt32(selectedRow.Cells["course_id"].Value); // Replace "StudentId" with the name of your ID column
                string updatedCourseName = selectedRow.Cells["course_name"].Value.ToString(); // Replace "Name" with the name of your column
                bool updatedCourseStatus = bool.Parse(selectedRow.Cells["active"].Value.ToString()); // Replace "Name" with the name of your column// Replace "Name" with the name of your column

                UpdateCourse(courseId, updatedCourseName, updatedCourseStatus);
            }
            else
            {
                MessageBox.Show("Please select a course to update.");
            }
        }


        private void UpdateCourse(int studentId, string updatedUserName, bool updatedCourseStatus)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Courses SET course_name = @course_name ,active = @active WHERE course_id = @course_id", con);

            cmd.Parameters.AddWithValue("@course_id", studentId);
            cmd.Parameters.AddWithValue("@course_name", updatedUserName);
            cmd.Parameters.AddWithValue("@active", updatedCourseStatus);

            cmd.ExecuteNonQuery();

        }

        private void vew_inbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from courses where active  = @active", con);
            cmd.Parameters.AddWithValue("@active", activeStatus.Text);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
                reader.Close();
            }
            courseGV.DataSource = dataTable;
            courseGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            courseGV.ColumnHeadersVisible = true;
            courseGV.RowHeadersVisible = true;
            courseGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void feebutton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(courseIdbox.Text) && !string.IsNullOrEmpty(studentIdbox.Text) != null && amountbox.Text != "")
            {
                int courseId = int.Parse(courseIdbox.Text);
                int studentId = int.Parse(studentIdbox.Text);
                int fee = int.Parse(amountbox.Text);
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
                SqlCommand cmd1 = new SqlCommand("Insert into Fees values ( @student_id,@course_id,@amount,@paid_date,@created_at,@updated_at,@active,@admin_id)", con);

                cmd1.Parameters.AddWithValue("@student_id", studentId);
                cmd1.Parameters.AddWithValue("@course_id", courseId);
                cmd1.Parameters.AddWithValue("@amount", fee);
                cmd1.Parameters.AddWithValue("@paid_date", DateTime.Parse(DateTimePicker1.Text));
                cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@active", 1);
                cmd1.Parameters.AddWithValue("@admin_id", adminId);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("course add successfully");
            }
        }

        private void view_feebutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from Fees where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
                reader.Close();
            }

            feeGV.DataSource = dataTable;
            feeGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            feeGV.ColumnHeadersVisible = true;
            feeGV.RowHeadersVisible = true;
            feeGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void updatefeebutton_Click(object sender, EventArgs e)
        {
            feeGV.ReadOnly = false; // Allow editing
            if (feeGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = feeGV.SelectedRows[0];

                int courseId = Convert.ToInt32(selectedRow.Cells["course_id"].Value); // Replace "StudentId" with the name of your ID column
                int updatedCourseName = int.Parse(selectedRow.Cells["student_id"].Value.ToString()); // Replace "Name" with the name of your column
                float updatedCourseStatus = float.Parse(selectedRow.Cells["amount"].Value.ToString());
                DateTime date = DateTime.Parse(DateTimePicker1.Text);
                selectedRow.Cells["fee_id"].ReadOnly = true;
                int feeId = int.Parse(selectedRow.Cells["fee_id"].Value.ToString());


                UpdateFee(courseId, updatedCourseName, updatedCourseStatus, date, feeId);
            }
            else
            {
                MessageBox.Show("Please select a course to update.");
            }
        }


        private void UpdateFee(int studentId, int updatedUserName, float updatedCourseStatus, DateTime newDate, int feeId)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Fees SET student_id = @student_id,course_id=@course_id,amount=@amount,paid_date=@paid_date,updated_at=@updated_at  WHERE fee_id = @fee_id", con);
            cmd.Parameters.AddWithValue("@course_id", studentId);
            cmd.Parameters.AddWithValue("@fee_id", feeId);
            cmd.Parameters.AddWithValue("@student_id", updatedUserName);
            cmd.Parameters.AddWithValue("@amount", updatedCourseStatus);
            cmd.Parameters.AddWithValue("@paid_date", newDate);
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd.ExecuteNonQuery();

        }

        private void addsbutton_Click(object sender, EventArgs e)
        {
            if (teacherIdbox.Text != null && salarybox.Text != "")
            {
                int teacherId = int.Parse(teacherIdbox.Text);
                int fee = int.Parse(salarybox.Text);
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
                SqlCommand cmd1 = new SqlCommand("Insert into Salaries values ( @teacher_id,@amount,@payment_date,@created_at,@updated_at,@active,@admin_id)", con);

                cmd1.Parameters.AddWithValue("@teacher_id", teacherId);
                cmd1.Parameters.AddWithValue("@amount", fee);
                cmd1.Parameters.AddWithValue("@payment_date", DateTime.Parse(salarydate.Text));
                cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@active", 1);
                cmd1.Parameters.AddWithValue("@admin_id", adminId);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("course add successfully");
            }
        }

        private void viewsalarybutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from Salaries where active  = 1", con);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
                reader.Close();
            }

            addedSalaryGV.DataSource = dataTable;
            addedSalaryGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addedSalaryGV.ColumnHeadersVisible = true;
            addedSalaryGV.RowHeadersVisible = true;
            addedSalaryGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void salarybox_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(salarybox.Text, out int salary))
            {
                if (salary <= 0)
                {
                    MessageBox.Show("Please enter a positive value for the salary.");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
            }
        }

        private void amountbox_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(amountbox.Text, out int salary))
            {
                if (salary <= 0)
                {
                    MessageBox.Show("Please enter a positive value for the salary.");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
            }
        }

        private void updatesalarybutton_Click(object sender, EventArgs e)
        {
            addedSalaryGV.ReadOnly = false;
            if (addedSalaryGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = addedSalaryGV.SelectedRows[0];
                selectedRow.Cells["salary_id"].ReadOnly = true;
                int salaryId = Convert.ToInt32(selectedRow.Cells["salary_id"].Value); // Replace "StudentId" with the name of your ID column
                float updatedAmount = float.Parse(selectedRow.Cells["amount"].Value.ToString());
                DateTime date = DateTime.Parse(DateTimePicker1.Text);
                int feeId = int.Parse(selectedRow.Cells["salary_id"].Value.ToString());
                UpdateSalary(salaryId, updatedAmount, date, feeId);
            }
            else
            {
                MessageBox.Show("Please select a course to update.");
            }
        }

        private void UpdateSalary(int teacherId, float updatedCourseStatus, DateTime newDate, int feeId)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Salaries SET teacher_id = @teacher_id,amount=@amount,payment_date=@payment_date,updated_at=@updated_at  WHERE salary_id = @salary_id", con);
            cmd.Parameters.AddWithValue("@teacher_id", teacherId);
            cmd.Parameters.AddWithValue("@salary_id", feeId);
            cmd.Parameters.AddWithValue("@amount", updatedCourseStatus);
            cmd.Parameters.AddWithValue("@payment_date", newDate);
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd.ExecuteNonQuery();

        }

        private void chat_tab_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chat_tab.SelectedTab == tabPage4)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Students where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                    reader.Close();
                }

                studentmsgId.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["student_id"].ToString()); // The corresponding value
                    studentmsgId.Items.Add(value);
                }

                studentmessageGV.DataSource = dataTable;
                studentmessageGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                studentmessageGV.ColumnHeadersVisible = true;
                studentmessageGV.RowHeadersVisible = true;
                studentmessageGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if (chat_tab.SelectedTab == tabPage5)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Teachers where active  = 1", con);
                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                    reader.Close();
                }

                teacherboxId.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int value = int.Parse(row["teacher_id"].ToString()); // The corresponding value
                    teacherboxId.Items.Add(value);
                }

                teacherchatGV.DataSource = dataTable;
                teacherchatGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                teacherchatGV.ColumnHeadersVisible = true;
                teacherchatGV.RowHeadersVisible = true;
                teacherchatGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }

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
            int studentId = int.Parse(studentmsgId.Text);
            SqlCommand cmd1 = new SqlCommand("Insert into Alerts values (@message,@send_date,@created_at,@updated_at,@active,@admin_id,@student_id, @teacher_id)", con);

            cmd1.Parameters.AddWithValue("@message", sendmsgbox.Text);
            cmd1.Parameters.AddWithValue("@send_date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@active", 1);
            cmd1.Parameters.AddWithValue("@admin_id", adminId);
            cmd1.Parameters.AddWithValue("@student_id", studentId);
            cmd1.Parameters.AddWithValue("@teacher_id", DBNull.Value);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Message Send successfully");
        }

        private void viewmsgbutton_Click(object sender, EventArgs e)
        {
            if (studentmsgId.Text != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  message from Alerts where student_id = @student_id", con);
                cmd.Parameters.AddWithValue("@student_id", int.Parse(studentmsgId.Text));
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
        }

        private void sendtmsgbutton_Click(object sender, EventArgs e)
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
            int teacherId = int.Parse(teacherboxId.Text);
            SqlCommand cmd1 = new SqlCommand("Insert into Alerts values (@message,@send_date,@created_at,@updated_at,@active,@admin_id,@student_id, @teacher_id)", con);

            cmd1.Parameters.AddWithValue("@message", messageteacher.Text);
            cmd1.Parameters.AddWithValue("@send_date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd1.Parameters.AddWithValue("@active", 1);
            cmd1.Parameters.AddWithValue("@admin_id", adminId);
            cmd1.Parameters.AddWithValue("@student_id", DBNull.Value);
            cmd1.Parameters.AddWithValue("@teacher_id", teacherId);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Message Send successfully");
        }

        private void viewtbutton_Click(object sender, EventArgs e)
        {
            if (teacherboxId.Text != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  message from Alerts where teacher_id = @teacher_id", con);
                cmd.Parameters.AddWithValue("@teacher_id", int.Parse(teacherboxId.Text));
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


                teachermsgBox.Text = messages.ToString();

            }
        }
    }
}
