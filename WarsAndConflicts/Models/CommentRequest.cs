using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Models
{
    public class CommentRequest
    {
        public string Body { get; set; } = null!;

        public string WarId { get; set; } = null!;
    }
}
