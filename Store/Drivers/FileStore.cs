using System;
using System.Reflection;
using System.Text.Json;

namespace Todox.Store.Drivers
{
    public class FileStore: IStoreInterface
    {
        readonly string filePath = "todos.json";

        public bool Add(Todo todo)
        {
            var todos = Load();
            todos.Add(todo);
            Save(todos);
            return true;
        }

        protected void Save(List<Todo> todos)
        {
            var data = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, data);
        }

        protected List<Todo> Load()
        {
            if (!File.Exists(filePath))
            {
                return [];
            }

            var data = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Todo>>(data) ?? [];
        }

    }
}
