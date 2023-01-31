using StorageKeeper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.Domain.Entities
{
    public class Catalogue:BaseEntity
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Item> CatalogueItems { get; set; }
        #endregion

        #region Constructor
        public Catalogue()
        {
            CatalogueItems = new List<Item>();
            AddItemTest();
        }

        public Catalogue(int id, string name)
        {
            Id = id;
            Name = name;
            CatalogueItems = new List<Item>();
        }
        #endregion

        #region Methods
        private void AddItemTest()
        {
            Item itemA = new Item(1, "ItemA", 2);
            Item itemB = new Item(1, "ItemB", 3);
            CatalogueItems.Add(itemA);
            CatalogueItems.Add(itemB);
        }
        #endregion
    }
}
