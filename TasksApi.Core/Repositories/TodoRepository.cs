using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Core.Models;

namespace TodoApi.Core.Repositories
{
    public class TodoRepository
        : ITodoRepository
    {
        private List<Todo> cache = new List<Todo>();

        public TodoRepository()
        {
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
            cache.Add(GenerateFakeTask());
        }

        public Todo GetTodoById(Guid id)
        {
            return cache.FirstOrDefault(
                x => x.Id.Equals(id));
        }

        public IEnumerable<Todo> GetTodos()
        {
            return cache;
        }

        public IEnumerable<Todo> GetCompleteTodos()
        {
            return cache.Where(x => x.IsComplete);
        }

        public IEnumerable<Todo> GetTodosByName(string name)
        {
            return cache.Where(x => x.Name.Equals(name));
        }

        private Todo GenerateFakeTask()
        {
            var isComplete = DateTime.Now.Millisecond % 2 == 0;
            return new Todo
            {
                Name = $"name{DateTime.Now.Millisecond}",
                Id = Guid.NewGuid(),
                IsComplete = isComplete,
                ParentTodo = isComplete && cache.Any() ? cache.First() : null
            };
        }
    }
}