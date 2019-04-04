using System;
using System.Collections.Generic;
using GraphQL.Types;

namespace TasksApi.API.Models
{
    public class TasksQuery: ObjectGraphType
    {
        public TasksQuery(ITaskRepository taskRepository)
        {
            Field<ListGraphType<TaskType>>(
                "tasks",
                arguments: new QueryArguments(
                    new List<QueryArgument>
                    {
                        new QueryArgument<IdGraphType>
                        {
                            Name = "Id"
                        },
                        new QueryArgument<StringGraphType>
                        {
                            Name = "name"
                        },
                        new QueryArgument<BooleanGraphType>
                        {
                            Name = "isComplete"
                        }
                    }), resolve: ctx =>
                {
                    var id = ctx.GetArgument<string>("id");
                    var name = ctx.GetArgument<string>("name");
                    var isComplete = ctx.GetArgument<bool?>("isComplete");

                    if (!string.IsNullOrWhiteSpace(id) 
                        && Guid.TryParse(id, out var typedId))
                    {
                        return new List<Task>
                        {
                            taskRepository.GetTaskById(typedId)
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        return taskRepository.GetTasksByName(name);
                    }

                    if (isComplete.HasValue && isComplete.Value)
                    {
                        return taskRepository.GetCompleteTasks();
                    }

                    return taskRepository.GetTasks();
                });
        }
    }
}