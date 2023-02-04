using StorageKeeper.Domain.Common;

namespace StorageKeeper.Domain.Entities
{
    public class Item : BaseEntity
    {
        #region Properties

        public int Quantity { get; set; }

        public int CatalogueId { get; set; }
        #endregion

        #region Fields
        protected bool isLowInStorage;
        #endregion

        #region Constructors
        public Item() 
        {

        }

        public Item(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Item(int id, string name, int quantity, int catalogueId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            CatalogueId = catalogueId;
        }

        #endregion
    }
}
