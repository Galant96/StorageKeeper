using StorageKeeper.App.Concrete;
using StorageKeeper.Domain.Interfaces;
using StorageKeeper.Domain.Entities;
using StorageKeeper.InputHelpers;

namespace StorageKeeper.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private IService<Item> _itemService;
        private readonly CatalogueManager _catalogueManager;

        #region Constructors
        public ItemManager(MenuActionService actionService, IService<Item> itemService, CatalogueManager catalogueManager)
        {
            _actionService = actionService;
            _itemService = itemService; // Get access to ItemService/BaseService methods
            _catalogueManager = catalogueManager;
        }
        #endregion

        #region Methods
        public void ShowItemMenu()
        {
            // Get the menu
            List<MenuAction> manageItemMenu = _actionService.GetMenuActionsByName("ManageItemMenu");

            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine();
                Console.WriteLine("Please select operation:");
                _actionService.DisplayMenuActions(manageItemMenu);
                var operation = Console.ReadKey();
                int operationId;
                Int32.TryParse(operation.KeyChar.ToString(), out operationId);

                switch (operationId)
                {
                    // Add new item
                    case 1:
                        int itemId = AddNewItem();
                        break;
                    // Find item by id
                    case 2:
                        {
                            int id = InputHelper.GetIdFromUser();
                            Item result = GetItemById(id);
                            if(result != null)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Id:{result.Id} Name:{result.Name} Qunatity:{result.Quantity}");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Item does not exist!");
                            }
                            break;
                        }
                    // Remove item by id
                    case 3:
                        {
                            int id = InputHelper.GetIdFromUser();
                            RemoveItemById(id);
                            break;
                        }
                    // Update item by id
                    case 4:
                        int updatedItemId = UpdateItem();
                        break;
                    // exit
                    case 5:
                        isActive = false;
                        break;
                    default:
                        break;
                }
            }
            
        }

        public Item GetItemById(int id)
        {
            return _itemService.GetItemById(id);
        }

        public int UpdateItem()
        {
            // Get item you want to update
            int id = InputHelper.GetIdFromUser();
            Item item = GetItemById(id);

            // Print update item menu
            List<MenuAction> updateItemMenu = _actionService.GetMenuActionsByName("UpdateItemMenu");
            Console.WriteLine();

            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine("Please select operation:");
                _actionService.DisplayMenuActions(updateItemMenu);
                var operation = Console.ReadKey();
                int operationId;
                Int32.TryParse(operation.KeyChar.ToString(), out operationId);
                switch (operationId)
                {
                    // Change name
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Provide a name for the item:");
                        var name = Console.ReadLine();
                        item.Name = name;
                        break;
                    // Change quantity
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Provide a quantity for the item:");
                        var quantity = Console.ReadLine();
                        int intQunatity;
                        Int32.TryParse(quantity.ToString(), out intQunatity);
                        item.Quantity = intQunatity;
                        break;
                    // Exit
                    case 3:
                        isActive = false;
                        break;
                    default:
                        break;
                }
            }

            int updatedItemId = _itemService.UpdateItem(item);
            return updatedItemId;
        }

        private int AddNewItem()
        {
            Console.WriteLine();
            Console.WriteLine("Add a new item.");
            Console.WriteLine("Provide a name for the item:");
            var name = Console.ReadLine();
            int quantity = InputHelper.GetQuantityFromUser();
            int lastId = _itemService.GetLastId();
            Console.WriteLine();

            Console.WriteLine("Catalogues List:");

            _catalogueManager.DisplayCatalogueList();
            Console.WriteLine("Assign item to the catalogue. Please, chose your option: ");
            int catalogueId = InputHelper.GetIdFromUser();

            Item item = new Item(lastId + 1, name, quantity, catalogueId);
            _itemService.AddItem(item);
            _catalogueManager.AddItemToCatalogue(item);
            return item.Id;
        }
        private void RemoveItemById(int id)
        {
            Console.WriteLine();
            Item item = _itemService.GetItemById(id);
            Console.WriteLine($"{item.Name} has been removed");
            _itemService.RemoveItem(item);
        }

        #endregion
    }
}
