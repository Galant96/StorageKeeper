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
        public string MenuName { get; set; }

        #region Constructors
        public MenuAction(int id, string name, string menuName)
        {
            Id = id;
            OptionName = name;
            MenuName = menuName;
        }
        #endregion

    }
}
