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

        public User(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public static (User User, string Error) Create(Guid id, string username, string password)
        {
            var error = string.Empty;

            if(username.Length > MAX_USERNAME_LENGTH)
            {
                error = $"Имя пользователя не может быть больше {MAX_USERNAME_LENGTH} символов!";
            }

            return (new User(id, username, password), error);
        }
    }
}
