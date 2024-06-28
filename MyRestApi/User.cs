using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace MyRestApi
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public User(int id, string login, string email, string firstName, string lastName, int age, string city, string street)
        {
            Id = id;
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
            Street = street;
        }   
    }
}