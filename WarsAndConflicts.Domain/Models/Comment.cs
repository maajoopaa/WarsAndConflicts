using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.Domain.Models
{
    public class Comment
    {
        public const int MAX_BODY_LENGTH = 250;

        public Comment(Guid id, string body, DateTime createdAt, User createdBy)
        {
            Id = id;
            Body = body;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }

        Guid Id { get;set; }

        public string Body { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public User CreatedBy { get; set; } = null!;

        public static (Comment Comment, string Error) Create(Guid id, string body, DateTime createdAt, User createdBy)
        {
            var error = string.Empty;

            if (body.Length > MAX_BODY_LENGTH)
            {
                error = $"Тело комментария не может быть больше {MAX_BODY_LENGTH} символов!";
            }

            return (new Comment(id, body, createdAt, createdBy), error);
        }
    }
}
