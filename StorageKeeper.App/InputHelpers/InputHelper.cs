using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageKeeper.InputHelpers
{
    public static class InputHelper
    {
        public static int GetIdFromUser()
        {
            Console.WriteLine("Provide item id: ");
            var id = Console.ReadKey();
            int intId;
            Int32.TryParse(id.KeyChar.ToString(), out intId);
            return intId;
        }
    }
}
