using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Models
{

    //public enum UserRole
    //{
    //    Regular,
    //    UserManager,
    //    Admin
    //}
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DataRegistered { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Movie> Movies { get; set; }

        //pentru clasa de legatura
        public IEnumerable<UserUserRole> UserUserRoles { get; set; }

    }
}
