using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaLogicManager
{
    public class RiddleSet
    {
        public RiddleSet(string i_Riddle, string i_Answer)
        {
            Riddle = i_Riddle;
            Answer = i_Answer;
        }

        public string Riddle { get; private set; }

        public string Answer { get; set; }
    }
}
