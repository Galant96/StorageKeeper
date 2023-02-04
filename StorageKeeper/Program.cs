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
       
            Console.WriteLine("Welcome to Storage Keeper!");
            MenuActionService actionService = new MenuActionService();
            CatalogueService catalogueService = new CatalogueService();
            CatalogueManager catalogueManager = new CatalogueManager(actionService, catalogueService);
            ItemService itemService = new ItemService();
            ItemManager itemManager = new ItemManager(actionService, itemService, catalogueManager);
          
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
               
                    // Show catalogues
                    case '1':
                        catalogueManager.ShowCatalogueMenu();
                        break;
                    // Manage items
                    case '2':
                        itemManager.ShowItemMenu();
                        break;
                    // Exit
                    case '3':
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