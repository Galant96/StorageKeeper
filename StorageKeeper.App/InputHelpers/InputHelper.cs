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
            Console.WriteLine("Provide id: ");
            var id = Console.ReadKey();
            int intId;
            Int32.TryParse(id.KeyChar.ToString(), out intId);
            return intId;
        }

        public static int GetQuantityFromUser()
        {
            Console.WriteLine("Provide quantity: ");
            var id = Console.ReadKey();
            int intId;
            Int32.TryParse(id.KeyChar.ToString(), out intId);
            return intId;
        }
    }
}
