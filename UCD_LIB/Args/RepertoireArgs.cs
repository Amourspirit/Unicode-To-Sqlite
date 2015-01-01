using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.Repertoire;

namespace UCD.Args
{
    public class RepertoireArgs : EventArgs
    {
        public RepertoireArgs() : base() { }

        public RepertoireArgs(CharItem Item)
            : base()
        {
           this.Item = Item;

        }
        public CharItem Item { get; set; }
    }
}
