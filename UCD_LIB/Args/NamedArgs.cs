using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCD.Args
{
    public class NamedArgs : EventArgs
    {
        public NamedArgs() : base() { }

        public  NamedArgs(string name) : base()
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
