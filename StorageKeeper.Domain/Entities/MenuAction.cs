using StorageKeeper.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.Domain.Entities
{
    public class MenuAction : BaseEntity
    {
        public string OptionName { get; set; }
        public string MenuId { get; set; }

        #region Constructors
        public MenuAction(int id, string name, string menuId)
        {
            Id = id;
            OptionName = name;
            MenuId = menuId;
        }
        #endregion

    }
}
