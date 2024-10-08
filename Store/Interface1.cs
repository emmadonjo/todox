using System;

namespace Todox.Store
{
    public interface IStoreInterface
    {
        bool Add(Todo todo);
    }
}
