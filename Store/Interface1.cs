using System;

namespace Todox.Store
{
    public interface IStoreInterface
    {
        List<Todo> All();
        bool Add(Todo todo);
    }
}
