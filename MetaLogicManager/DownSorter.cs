using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaLogicManager
{
    public class DownSorter : ISortStrategy
    {
        public bool NeedSwap(string i_FirstElement, string i_SecondElemet)
        {
            bool needToSwap = false;

            if (i_FirstElement[0] < i_SecondElemet[0])
            {
                needToSwap = true;
            }

            return needToSwap;
        }
    }
}
