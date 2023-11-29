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
            MessageBox.Show("Message Send successfully");
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

        }
    }
}
