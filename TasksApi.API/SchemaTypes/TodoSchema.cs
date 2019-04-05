using GraphQL.Types;

namespace TodoApi.API.SchemaTypes
{
    public class TodoSchema : Schema
    {
        public TodoSchema(TodoQuery query)
        {
            Query = query;
        }
    }
}