using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageKeeper.Domain.Common;
using StorageKeeper.Domain.Interfaces;

namespace StorageKeeper.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        #region Constructor
        public BaseService()
        {
            Items = new List<T>();
        }
        #endregion

        #region Methods
        public void AddItem(T item)
        {
            Items.Add(item);
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public T GetItemById(int id)
        {
            // Returns the first element of a sequence, or a specified default value if the sequence contains no elements.
            var entity = Items.FirstOrDefault(entityX => entityX.Id == id);
          
            return entity;
        }

        public T GetItemByName(string name)
        {
            // Returns the first element of a sequence, or a specified default value if the sequence contains no elements.
            var entity = Items.FirstOrDefault(entityX => entityX.Name == name);

            return entity;
        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {                                               // Returns the last element of a sequence, or a specified default value if the sequence contains no elements
                lastId = Items.OrderBy(entityX => entityX.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(entityX => entityX.Id == item.Id);

            if (entity != null)
            {
                entity = item;
            }

            return entity.Id;
        }
        #endregion
    }
}
