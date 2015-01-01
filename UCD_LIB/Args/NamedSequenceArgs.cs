using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.NamedSequence;

namespace UCD.Args
{
    public class NamedSequenceArgs : EventArgs
    {
        public NamedSequenceArgs() : base() { }
        public NamedSequenceArgs(NsItem Item)
            : base()
        {
            this.Item = Item;

        }
        public NsItem Item { get; set; }
    }
}
