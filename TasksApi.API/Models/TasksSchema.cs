using GraphQL.Types;

namespace TasksApi.API.Models
{
    public class TasksSchema : Schema
    {
        public TasksSchema(TasksQuery query)
        {
            Query = query;
        }
    }
}