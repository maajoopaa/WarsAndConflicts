using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.Domain.Models
{
    public class War
    {
        public const int MAX_TITLE_LENGTH = 150;

        public War(Guid id, string title, string description, byte[] image, Period period, ICollection<Comment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Period = period;
            Comments = comments;
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public Period Period { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = [];

        public static (War War, string Error) Create(Guid id, string title, string description, byte[] image, Period period, ICollection<Comment> comments)
        {
            var error = string.Empty;

            if (title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Название не может быть больше {MAX_TITLE_LENGTH} символов!";
            }

            return (new War(id, title, description, image, period, comments), error);
        }

    }
}
