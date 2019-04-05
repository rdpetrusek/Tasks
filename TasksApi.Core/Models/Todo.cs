using System;

namespace TodoApi.Core.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public Todo ParentTodo { get; set; }
    }
}