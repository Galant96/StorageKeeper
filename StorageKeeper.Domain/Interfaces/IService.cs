using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.Domain.Interfaces
{
    // Interface for a generic class
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems();

        int GetLastId();

        T GetItemById(int id);

        void AddItem(T item);

        int UpdateItem(T item);

        void RemoveItem(T item);
    }
}
