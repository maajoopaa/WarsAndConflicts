using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsAndConflicts.DataAccess.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }

        public string Body { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public Guid CreatedById { get; set; }

        public UserEntity CreatedBy { get; set; } = null!;

        public Guid WarId { get; set; }

        public WarEntity War { get; set; } = null!;
    }
}
