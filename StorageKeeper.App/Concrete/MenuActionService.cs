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

        public List<MenuAction> GetMenuActionsByName(string menuName)
        {
            List<MenuAction> menuActions = new List<MenuAction>();

            foreach(MenuAction menuAction in Items)
            {
               if(menuAction.MenuName == menuName)
                {
                    menuActions.Add(menuAction);
                }
            }

            return menuActions;
        }

        private void Initialize()
        {
            // Main Menu
            AddItem(new MenuAction(1, "Create a storage catalogue", "MainMenu"));
            AddItem(new MenuAction(2, "Show catalogue", "MainMenu"));
            AddItem(new MenuAction(3, "Find item", "MainMenu"));
            AddItem(new MenuAction(4, "Exit", "MainMenu"));

            // Create a storage catalogue menu
            AddItem(new MenuAction(1, "Provide catalogue name", "CreateCatalogueMenu"));
            AddItem(new MenuAction(2, "Add item", "CreateCatalogueMenu"));
            AddItem(new MenuAction(3, "Remove item", "CreateCatalogueMenu"));
            AddItem(new MenuAction(4, "Save catalogue", "CreateCatalogueMenu"));
            AddItem(new MenuAction(5, "Back to Main Menu", "CreateCatalogueMenu"));

            // Manage catalogue menu
            AddItem(new MenuAction(1, "Chose catalogue", "ShowCatalogueMenu"));
            AddItem(new MenuAction(2, "Back to Main Menu", "ShowCatalogueMenu"));

            // Manage items menu
            AddItem(new MenuAction(1, "Add item", "ManageItemMenu"));
            AddItem(new MenuAction(2, "Remove item", "ManageItemMenu"));
            AddItem(new MenuAction(3, "Back to Main Menu", "ManageItemMenu"));

            // Find item menu
            AddItem(new MenuAction(1, "Find item by id", "FindItemMenu"));
            AddItem(new MenuAction(2, "Find item by name", "FindItemMenu"));

            // Remove item menu
            AddItem(new MenuAction(1, "Remove item by id", "RemoveItemMenu"));
            AddItem(new MenuAction(2, "Remove item by name", "RemoveItemMenu"));

        }
        #endregion
    }
}
