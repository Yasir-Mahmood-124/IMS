using IME.Classes.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IME.Classes.DL
{
    public class UserDL
    {

        public static List<USERS> users = new List<USERS>();
        public static bool emailChecker(string Email)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM Users WHERE Email = @email", con);
            cmd.Parameters.AddWithValue("@email", Email);
            try
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Email already exit try another type unique email");
                return false;
            }

        }
    }
}
