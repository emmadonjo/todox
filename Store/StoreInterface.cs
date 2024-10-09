using System;

namespace Todox.Store
{
    public interface IStoreInterface
    {
        List<Todo> All();
        Todo? GetById(int id);
        bool Add(Todo todo);
        bool Update(Todo todo);
        bool Delete(Todo todo);
    }
}
