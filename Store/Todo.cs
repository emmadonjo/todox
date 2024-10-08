using System;

namespace Todox.Store
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
