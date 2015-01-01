using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.CjkRadicals;

namespace UCD.Args
{
    public class CjkRadicalsArgs : EventArgs
    {
        public CjkRadicalsArgs() : base() { }
        public CjkRadicalsArgs(CjkRadicalsItem Item)
            : base()
        {
            this.Item = Item;

        }
        public CjkRadicalsItem Item { get; set; }
    }
}
