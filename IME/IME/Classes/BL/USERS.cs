using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IME.Classes.BL
{
    public class USERS
    {
        private string name;
        private string password;
        private string email;
        private string phone;
        private string userName;
        private string phoneNumber;
        private string userType;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string UserType { get => userType; set => userType = value; }

        public USERS() { }

        public USERS (string name, string password, string email, string phone, string userName, string phoneNumber,string userType)
        {
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            UserName = userName;
            PhoneNumber = phoneNumber;
            UserType = userType;
        }
    }
}
