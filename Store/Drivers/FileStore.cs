using System;
using System.Reflection;
using System.Text.Json;

namespace Todox.Store.Drivers
{
    public class FileStore: IStoreInterface
    {
        readonly string filePath = "todos.json";

        public List<Todo> All()
        {
            return Load();
        }

        public Todo? GetById(int id) {
            var todos = Load();

            if (todos.Count == 0)
            {
                return null;
            }

            var todo = todos.Find(todo => todo.Id == id);

            if (todo == null)
            {
                return null;
            }

            return todo;

        }

        public bool Add(Todo todo)
        {
            var todos = Load();
            todos.Add(todo);
            Save(todos);
            return true;
        }

        public bool Update(Todo todo)
        {
            var todos = Load();
            if (todos.Count == 0)
            {
                return false;
            }

            int index = todos.FindIndex(todo => todo.Id == todo.Id);

            if (index == -1)
            {
                return false;
            }

            todos[index] = todo;
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
