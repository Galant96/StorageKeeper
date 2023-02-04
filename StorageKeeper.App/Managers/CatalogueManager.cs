using StorageKeeper.App.Concrete;
using StorageKeeper.Domain.Entities;
using StorageKeeper.Domain.Interfaces;
using StorageKeeper.InputHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.App.Managers
{
    public class CatalogueManager
    {
        private readonly MenuActionService _actionService;
        private IService<Catalogue> _catalogueService;
     
        #region Constructors
        public CatalogueManager(MenuActionService actionService, IService<Catalogue> catalogueService)
        {
            _actionService = actionService;
            _catalogueService = catalogueService;

            Catalogue catalogueTestA = new Catalogue(_catalogueService.GetLastId()+1, "TestA");
            _catalogueService.AddItem(catalogueTestA);
            Catalogue catalogueTestB = new Catalogue(_catalogueService.GetLastId()+1, "TestB");
            _catalogueService.AddItem(catalogueTestB);
        }
        #endregion

        #region Methods
        public void ShowCatalogueMenu()
        {
            // Get the menu
            List<MenuAction> catalogueMenu = _actionService.GetMenuActionsByName("CatalogueMenu");

            bool isActive = true;

            // TEST
           

            while (isActive)
            {
                Console.WriteLine();
                Console.WriteLine("Please select operation:");
                _actionService.DisplayMenuActions(catalogueMenu);
                var operation = Console.ReadKey();
                int operationId;
                Int32.TryParse(operation.KeyChar.ToString(), out operationId);

                switch (operationId)
                {
                    // Add new catalogue
                    case 1:
                        int newCatalogueId = AddNewCatalogue();
                        break;
                    // Display catalogue
                    case 2:
                        DisplayCatalogueList();
                        DisplayCatalogueItems();
                        break;
                    // Remove catalogue
                    case 3:
                        int catalogueId = InputHelper.GetIdFromUser();
                        RemoveCatalogueById(catalogueId);
                        break;
                    // Go back
                    case 4:
                        isActive = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public int AddNewCatalogue()
        {
            Console.WriteLine();
            Console.WriteLine("Add a new catalogue.");
            Console.WriteLine("Provide a name for the catalogue:");
            var name = Console.ReadLine();
            int lastId = _catalogueService.GetLastId();
            Catalogue catalogue = new Catalogue(lastId + 1, name);
            _catalogueService.AddItem(catalogue);

            return catalogue.Id;
        }

        public Catalogue GetCatalogueById(int id)
        {
            Catalogue catalogue = _catalogueService.GetItemById(id);
            return catalogue;
        }

        public Catalogue GetCatalogueByName(string name)
        {
            Catalogue catalogue = _catalogueService.GetItemByName(name);
            return catalogue;
        }

        public void RemoveCatalogueById(int id)
        {
            Catalogue catalogue = _catalogueService.GetItemById(id);
            Console.WriteLine($"{catalogue.Name} has been removed");
            _catalogueService.RemoveItem(catalogue);
        }

        public void RemoveCatalogueByName(string name)
        {
            Catalogue catalogue = _catalogueService.GetItemByName(name);
            _catalogueService.RemoveItem(catalogue);
        }

        public void DisplayCatalogueList()
        {
            List<Catalogue> list = _catalogueService.GetAllItems();

            Console.WriteLine();
            foreach (Catalogue catalogue in list)
            {
                Console.WriteLine($"{catalogue.Id}. {catalogue.Name}");
            }
        }

        public void DisplayCatalogueItems()
        {
            Console.WriteLine("Provide catalogue id:");
            int catalogueId = InputHelper.GetIdFromUser();
            Catalogue catalogue = _catalogueService.GetItemById(catalogueId);
            Console.WriteLine(catalogue.CatalogueItems.Count);
            List<Item> itemList = GetCatalogueItems(catalogue);

            Console.WriteLine(catalogue.Name);

            foreach (Item item in itemList)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Quantity}");
            }
        }

        private List<Item> GetCatalogueItems(Catalogue catalogue)
        {
            Console.WriteLine(catalogue.Id);
            Console.WriteLine(catalogue.Name);
            Console.WriteLine(catalogue.CatalogueItems.Count);
            return catalogue.CatalogueItems;
        }
        #endregion
    }
}
