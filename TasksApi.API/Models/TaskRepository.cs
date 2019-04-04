using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksApi.API.Models
{
    public class TaskRepository
        : ITaskRepository
    {
        private List<Task> cache = new List<Task>();

        public TaskRepository()
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

        public Task GetTaskById(Guid id)
        {
            return cache.FirstOrDefault(
                x => x.Id.Equals(id));
        }

        public IEnumerable<Task> GetTasks()
        {
            return cache;
        }

        public IEnumerable<Task> GetCompleteTasks()
        {
            return cache.Where(x => x.IsComplete);
        }

        public IEnumerable<Task> GetTasksByName(string name)
        {
            return cache.Where(x => x.Name.Equals(name));
        }

        private Task GenerateFakeTask()
        {
            return new Task
            {
                Name = $"name{DateTime.Now.Millisecond}",
                Id = Guid.NewGuid(),
                IsComplete = DateTime.Now.Millisecond % 2 == 0
            };
        }
    }
}