using System;
using Todox.Store.Drivers;

namespace Todox.Store
{
    public class Storage
    {
        public static IStoreInterface Init(string driver = "file")
        {
            if (driver == "file")
            {
                return new FileStore();
            }

            throw new ArgumentException("The given driver, {0}, is not supported.", driver);
        }
    }
}
