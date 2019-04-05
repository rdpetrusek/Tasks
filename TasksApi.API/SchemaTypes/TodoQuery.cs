using System;
using System.Collections.Generic;
using GraphQL.Types;
using Humanizer;
using TodoApi.Core.Models;
using TodoApi.Core.Repositories;

namespace TodoApi.API.SchemaTypes
{
    public class TodoQuery: ObjectGraphType
    {
        public TodoQuery(ITodoRepository todoRepository)
        {
            Field<ListGraphType<TodoType>>(
                nameof(Todo).ToLowerInvariant().Pluralize(),
                arguments: new QueryArguments(
                    new List<QueryArgument>
                    {
                        new QueryArgument<IdGraphType>
                        {
                            Name = nameof(Todo.Id).Camelize()
                        },
                        new QueryArgument<StringGraphType>
                        {
                            Name = nameof(Todo.Name).Camelize()
                        },
                        new QueryArgument<BooleanGraphType>
                        {
                            Name = nameof(Todo.IsComplete).Camelize()
                        }
                    }), resolve: ctx =>
                {
                    var id = ctx.GetArgument<string>(nameof(Todo.Id).Camelize());
                    var name = ctx.GetArgument<string>(nameof(Todo.Name).Camelize());
                    var isComplete = ctx.GetArgument<bool?>(nameof(Todo.IsComplete).Camelize());

                    if (!string.IsNullOrWhiteSpace(id) 
                        && Guid.TryParse(id, out var typedId))
                    {
                        return new List<Todo>
                        {
                            todoRepository.GetTodoById(typedId)
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        return todoRepository.GetTodosByName(name);
                    }

                    if (isComplete.HasValue && isComplete.Value)
                    {
                        return todoRepository.GetCompleteTodos();
                    }

                    return todoRepository.GetTodos();
                });
        }
    }
}