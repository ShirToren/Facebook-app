using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaLogicManager
{
    public interface ISortStrategy
    {
        bool NeedSwap(string i_FirstElement , string i_SecondElemet);
    }
}
