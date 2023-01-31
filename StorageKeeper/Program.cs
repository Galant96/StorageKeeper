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

        #region Display Actions Functions
        private static void DisplayCreateMenuActions(MenuActionService menuActionService)
        {
            bool isExit = false;
            while(isExit == false)
            {
                List<MenuAction> createMenuActions = menuActionService.GetMenuActionsByName("CreateCatalogueMenu");
                menuActionService.DisplayMenuActions(createMenuActions);
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    case '1':
                        // CREATE CATALOGUE
                        // PROVIDE CATALOGUE'S NAME
                        break;
                    // Add Item
                    case '2':
                        // ADD ITEM
                        // ADD ID, NAME, QUANTITY, CATEGORY, CATALOGUE
                        break;
                    // Remove item
                    case '3':
                        DisplayRemoveItemMenuActions(menuActionService);
                        break;
                    // Save catalogue
                    case '4':
                    // SAVE CATALOGUE
                        break;
                    // Back to menu
                    case '5':
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                }
            }
        }

        private static void DisplayShowCatalogueMenuActions(MenuActionService menuActionService)
        {
            bool isExit = false;
            while (isExit == false)
            {
                List<MenuAction> showMenuActions = menuActionService.GetMenuActionsByName("ShowCatalogueMenu");
                menuActionService.DisplayMenuActions(showMenuActions);
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    // Display catalogue
                    case '1':
                        // PROVIDE CATALOGUE NAME TO DISPLAY IT
                        break;
                    // Exit
                    case '2':
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                }
            }
        }

        private static void DisplayFindItemMenuActions(MenuActionService menuActionService)
        {
            bool isExit = false;
            while (isExit == false)
            {
                List<MenuAction> findItemMenuActions = menuActionService.GetMenuActionsByName("ShowCatalogueMenu");
                menuActionService.DisplayMenuActions(findItemMenuActions);
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    // Find item by id
                    case '1':
                        // PROVIDE ITEM ID
                        break;
                    // Find item by name
                    case '2':
                        // PROVIDE ITEM NAME
                        break;
                    // Exit
                    case '3':
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                }
            }
        }

        private static void DisplayManageItemsMenuActions(MenuActionService menuActionService)
        {
            bool isExit = false;
            while (isExit == false)
            {
                List<MenuAction> manageItemsMenuActions = menuActionService.GetMenuActionsByName("ManageItemMenu");
                menuActionService.DisplayMenuActions(manageItemsMenuActions);
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    // Add item
                    case '1':
                        // ADD ITEM
                        // ADD ID, NAME, QUANTITY, CATEGORY, CATALOGUE
                        break;
                    // Remove item
                    case '2':
                        // REMOVE ITEM
                        break;
                    // Exit
                    case '3':
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                }
            }
        }

        private static void DisplayRemoveItemMenuActions(MenuActionService menuActionService)
        {
            bool isExit = false;
            while (isExit == false)
            {
                List<MenuAction> removeItemMenuActions = menuActionService.GetMenuActionsByName("RemoveItemMenu");
                menuActionService.DisplayMenuActions(removeItemMenuActions);
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    // Remove item by id
                    case '1':
                        break;
                    // Remove item by name
                    case '2':
                        break;
                    // Exit
                    case '3':
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                }
            }
        }



        #endregion
    }
}