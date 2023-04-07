using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Storage.AppData
{
    internal class AppConnect
    {
        public static DiplomNikiforovEntities modelOdb { get; } = new DiplomNikiforovEntities();
    }
}
