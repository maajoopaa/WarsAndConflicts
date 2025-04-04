using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.Domain.Models
{
    public class Period
    {
        public const int MAX_TITLE_LENGTH = 150;

        public Period(Guid id, string title, string description, byte[] image, ICollection<War> wars)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Wars = wars;
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public ICollection<War> Wars { get; set; } = [];

        public static (Period Period, string Error) Create(Guid id, string title, string description, byte[] image, ICollection<War> wars)
        {
            var error = string.Empty;

            if(title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Название не может быть больше {MAX_TITLE_LENGTH} символов!";
            }

            return (new Period(id, title, description, image, wars), error);
        }
    }
}
