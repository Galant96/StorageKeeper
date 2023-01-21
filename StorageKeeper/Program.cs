using StorageKeeper.App.Concrete;
using StorageKeeper.Domain.Entities;
using System;

namespace StorageKeeper
{
    internal class Program
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
            MenuActionService menuActionService = new MenuActionService();

            while (true)
            {
                Console.WriteLine("Please chose an option:");
                List<MenuAction> menuActions = menuActionService.GetMenuActionsByName("MainMenu");

                for (int i = 0; i < menuActions.Count; i++)
                {
                    Console.WriteLine($"{menuActions[i].Id}. {menuActions[i].OptionName}");
                }

                var option = Console.ReadLine();
            }
        }
    }
}