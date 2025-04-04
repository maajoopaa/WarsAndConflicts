using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.Domain.Models
{
    public class User
    {
        public const int MAX_USERNAME_LENGTH = 15;

        public User(Guid id, string username, string email, string password, ICollection<Comment> comments)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Comments = comments;
        }

        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = [];

        public static (User User, string Error) Create(Guid id, string username,string email, string password, ICollection<Comment> comments)
        {
            var error = string.Empty;

            if(username.Length > MAX_USERNAME_LENGTH)
            {
                error = $"Имя пользователя не может быть больше {MAX_USERNAME_LENGTH} символов!";
            }

            return (new User(id, username, email, password, comments), error);
        }
    }
}
