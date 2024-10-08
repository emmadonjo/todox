using System;

namespace Todox.Store
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Priority { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
