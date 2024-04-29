using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string role;
        private string email;
        private string password;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Role { get => role; set => role = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public User()
        {
        }
        public User(int id, string firstName, string lastName, string role, string email, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.Email = email;
            this.Password = password;
        }
    }
}
