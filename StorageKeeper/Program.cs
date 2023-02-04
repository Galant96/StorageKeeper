using StorageKeeper.App.Concrete;
using StorageKeeper.App.Managers;
using StorageKeeper.Domain.Entities;
using System;

namespace StorageKeeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Say hello to user
            // 2. Print menu
                // 2.1 Create a storage catalogue
                    // Provide name
                        // Save
                // 2.2 Show catalogue
                // 2.3 Add item
                    // Create id
                    // Provide name
                    // Provide quantity
                // 2.4 Remove item
                    // Provide name or id
                        // Provide quantity
                            // Remove
                // 2.5 Exit App


            Console.WriteLine("Welcome to Storage Keeper!");
            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            ItemManager itemManager = new ItemManager(actionService, itemService);
            CatalogueService catalogueService = new CatalogueService();
            CatalogueManager catalogueManager = new CatalogueManager(actionService, catalogueService);
            bool isApplicationRunning = true;

            while (isApplicationRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Please chose an option:");
                List<MenuAction> menuActions = actionService.GetMenuActionsByName("MainMenu");

                actionService.DisplayMenuActions(menuActions);

                var option = Console.ReadKey();

                switch(option.KeyChar)
                {
                    // Create a new catalogue
                    case '1':
                        catalogueManager.AddNewCatalogue();
                        break;
                    // Show catalogues
                    case '2':
                        catalogueManager.ShowCatalogueMenu();
                        break;
                    // Manage items
                    case '3':
                        itemManager.ShowItemMenu();
                        break;
                    // Exit
                    case '4':
                        Console.WriteLine("\nExit...");
                        isApplicationRunning = false;
                        break;
                    default:
                        Console.WriteLine(" - Invalid input");
                        break;
                }
            }
        }

    }
}