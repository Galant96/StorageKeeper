using StorageKeeper.App.Common;
using StorageKeeper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {

        #region Constructors
        public MenuActionService()
        {
            Initialize();
        }

        #endregion

        #region Methods

        public List<MenuAction> GetMenuActionsByName(string menuId)
        {
            List<MenuAction> menuActions = new List<MenuAction>();

            foreach(MenuAction menuAction in Items)
            {
               if(menuAction.MenuId == menuId)
                {
                    menuActions.Add(menuAction);
                }
            }

            return menuActions;
        }

        private void Initialize()
        {
            // Main Menu
            AddItem(new MenuAction(1, "Create storage catalogue", "MainMenu"));
            AddItem(new MenuAction(2, "Show catalogue", "MainMenu"));
            AddItem(new MenuAction(3, "Manage items", "MainMenu"));
            AddItem(new MenuAction(4, "Exit", "MainMenu"));

            // Create a storage catalogue menu
            AddItem(new MenuAction(1, "Add catalogue", "CatalogueMenu"));
            AddItem(new MenuAction(2, "Display catalogue", "CatalogueMenu"));
            AddItem(new MenuAction(3, "Remove catalogue", "CatalogueMenu"));
            AddItem(new MenuAction(4, "Back to Main Menu", "CatalogueMenu"));

            // Manage items menu
            AddItem(new MenuAction(1, "Add item", "ManageItemMenu"));
            AddItem(new MenuAction(2, "Find item by id", "ManageItemMenu"));
            AddItem(new MenuAction(3, "Remove item by id", "ManageItemMenu"));
            AddItem(new MenuAction(4, "Update item", "ManageItemMenu"));
            AddItem(new MenuAction(5, "Back to Main Menu", "ManageItemMenu"));



            // Update item menu
            AddItem(new MenuAction(1, "Update name", "UpdateItemMenu"));
            AddItem(new MenuAction(2, "Update quantity", "UpdateItemMenu"));
            AddItem(new MenuAction(3, "Go back", "UpdateItemMenu"));

            // Find item menu
            AddItem(new MenuAction(1, "Find item by id", "FindItemMenu"));
            AddItem(new MenuAction(2, "Find item by name", "FindItemMenu"));
            AddItem(new MenuAction(3, "Go back", "FindItemMenu"));
            // Remove item menu
            AddItem(new MenuAction(1, "Remove item by id", "RemoveItemMenu"));
            AddItem(new MenuAction(2, "Remove item by name", "RemoveItemMenu"));
            AddItem(new MenuAction(3, "Go back", "RemoveItemMenu"));

        }

        public void DisplayMenuActions(string menuName)
        {
            Console.WriteLine();
            List<MenuAction> menuActions = GetMenuActionsByName(menuName);
            for (int i = 0; i < menuActions.Count; i++)
            {
                Console.WriteLine($"{menuActions[i].Id}. {menuActions[i].OptionName}");
            }
        }

        public void DisplayMenuActions(List<MenuAction> menuActions)
        {
            Console.WriteLine();

            for (int i = 0; i < menuActions.Count; i++)
            {
                Console.WriteLine($"{menuActions[i].Id}. {menuActions[i].OptionName}");
            }

        }
        #endregion
    }
}
