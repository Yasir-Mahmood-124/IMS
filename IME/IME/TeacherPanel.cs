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

namespace IME
{
    public partial class TeacherPanel : UserControl
    {
        public TeacherPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (studentidbox.SelectedItem != null && cmIdbox.SelectedItem != null && markbox.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd1 = new SqlCommand("Insert into MarkSheets values (@teacher_id,@student_id,@course_id,@marks,@created_at,@updated_at,@active)", con);
                cmd1.Parameters.AddWithValue("@teacher_id", UserDL.adminID);
                cmd1.Parameters.AddWithValue("@send_date", DateTime.Now);
                cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@active", 1);
                cmd1.Parameters.AddWithValue("@student_id", int.Parse(studentidbox.Text));
                cmd1.Parameters.AddWithValue("@course_id", int.Parse(cmIdbox.Text));
                cmd1.Parameters.AddWithValue("@marks", int.Parse(markbox.Text));
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Marks Added successfully");
            }
            else
            {
                MessageBox.Show("Please select all the statement first");
            }


        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == courseMTab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE active = 1", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    if (reader.Read())
                    {
                        dataTable.Load(reader);
                    }
                    else
                    {
                        MessageBox.Show("No user found with the provided credentials.");
                    }
                    studentidbox.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int value = int.Parse(row["student_id"].ToString());
                        studentidbox.Items.Add(value);
                    }
                }

                cmd = new SqlCommand("SELECT  * from Courses where active  = 1", con);
                DataTable dataTable1 = new DataTable();
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    dataTable1.Load(reader1);
                }

                cmIdbox.Items.Clear();
                foreach (DataRow row in dataTable1.Rows)
                {

                    int value = int.Parse(row["course_id"].ToString());
                    cmIdbox.Items.Add(value);

                }


                SqlCommand cmd1 = new SqlCommand("SELECT * FROM MarkSheets WHERE active = 1 and teacher_id = @teacher_id", con);
                cmd1.Parameters.AddWithValue("@teacher_id", UserDL.adminID);

                DataTable dataTable2 = new DataTable();

                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    dataTable2.Load(reader);
                }
                cmGV.DataSource = dataTable2;
                cmGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                cmGV.ColumnHeadersVisible = true;
                cmGV.RowHeadersVisible = true;
                cmGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            }
            if (guna2TabControl1.SelectedTab == courseTab)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT  * from Courses where active  = 1", con);
                DataTable dataTable1 = new DataTable();
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    dataTable1.Load(reader1);
                }

                courseId.Items.Clear();
                foreach (DataRow row in dataTable1.Rows)
                {

                    int value = int.Parse(row["course_id"].ToString());
                    courseId.Items.Add(value);

                }
            }
            if (guna2TabControl1.SelectedTab == logouttab)
            {
                SIGNIN signin = new SIGNIN();
                this.Controls.Clear();
                this.Controls.Add(signin);
            }
        }

        private void markbox_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(markbox.Text, out int salary))
            {
                if (salary <= -10)
                {
                    MessageBox.Show("Please enter a gretaer value than -10 for the marks.");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
            }
        }

        private void viewbutton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MarkSheets WHERE active = 1 and teacher_id = @teacher_id", con);
            cmd.Parameters.AddWithValue("@teacher_id", UserDL.adminID);
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

        private void button2_Click(object sender, EventArgs e)
        {

            cmGV.ReadOnly = false;
            if (cmGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = cmGV.SelectedRows[0];
                selectedRow.Cells[7].ReadOnly = true;
                int marksheetId = Convert.ToInt32(selectedRow.Cells["mark_sheet_id"].Value);
                int marks = Convert.ToInt32(selectedRow.Cells["marks"].Value);
                bool status = bool.Parse(selectedRow.Cells["active"].Value.ToString());

                UpdateCourse(marksheetId, marks, status);
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
            showData();
        }

        private void showData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from MarkSheets where active  = 1 and teacher_id = @teacher_id", con);
            cmd.Parameters.AddWithValue("@teacher_id", UserDL.adminID);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader1 = cmd.ExecuteReader())
            {
                dataTable.Load(reader1);
            }
            cmGV.DataSource = dataTable;
            cmGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            cmGV.ColumnHeadersVisible = true;
            cmGV.RowHeadersVisible = true;
            cmGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void UpdateCourse(int studentId, int updatedFullName, bool activestatus)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE MarkSheets SET active = @active,updated_at=@updated_at , marks = @marks  WHERE mark_sheet_id = @mark_sheet_id", con);
            cmd.Parameters.AddWithValue("@active", activestatus);
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd.Parameters.AddWithValue("@marks", updatedFullName);
            cmd.Parameters.AddWithValue("@mark_sheet_id", studentId);
            cmd.ExecuteNonQuery();

        }

        private void courseMTab_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cmIdbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void studentidbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void markbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }


        private void addbutton_Click(object sender, EventArgs e)
        {
            if (courseId.SelectedItem != null && matrialbox.Text != "")
            {
                MessageBox.Show("" + UserDL.adminID);
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd1 = new SqlCommand("Insert into CourseMaterials values (@course_id,@teacher_id,@material_name,@created_at,@updated_at,@active)", con);
                cmd1.Parameters.AddWithValue("@course_id", int.Parse(courseId.Text));
                cmd1.Parameters.AddWithValue("@teacher_id", UserDL.adminID);
                cmd1.Parameters.AddWithValue("@material_name", matrialbox.Text);
                cmd1.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@updated_at", DateTime.Now);
                cmd1.Parameters.AddWithValue("@active", 1);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Matrial Added successfully");
            }
            else
            {
                MessageBox.Show("Please select all the statement first");
            }
            //showMatrial();
        }

        private void showMatrial()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  * from CourseMaterials where active  = 1 and teacher_id = @teacher_id", con);
            cmd.Parameters.AddWithValue("@teacher_id", UserDL.adminID);
            DataTable dataTable = new DataTable();
            using (SqlDataReader reader1 = cmd.ExecuteReader())
            {
                dataTable.Load(reader1);
            }
            matrialGV.DataSource = dataTable;
            matrialGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            matrialGV.ColumnHeadersVisible = true;
            matrialGV.RowHeadersVisible = true;
            matrialGV.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showMatrial();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            matrialGV.ReadOnly = false;
            if (matrialGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = matrialGV.SelectedRows[0];
                selectedRow.Cells[6].ReadOnly = true;
                int marksheetId = Convert.ToInt32(selectedRow.Cells["material_id"].Value);
                string marks = selectedRow.Cells["material_name"].Value.ToString();
                bool status = bool.Parse(selectedRow.Cells["active"].Value.ToString());

                UpdateMatrial(marksheetId, marks, status);
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
            showMatrial();
        }


        private void UpdateMatrial(int studentId, string updatedFullName, bool activestatus)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE CourseMaterials SET active = @active,updated_at=@updated_at , material_name = @material_name  WHERE material_id = @material_id", con);
            cmd.Parameters.AddWithValue("@active", activestatus);
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
            cmd.Parameters.AddWithValue("@material_name", updatedFullName);
            cmd.Parameters.AddWithValue("@material_id", studentId);
            cmd.ExecuteNonQuery();

        }
    }
}
