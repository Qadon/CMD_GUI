using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AsciiMenu1
{

    internal class Option
    {
        public string name;
        public Action selected;
        public Option(string Name, Action Selected)
        {
            name = Name;
            selected = Selected;
        }
    }
}


