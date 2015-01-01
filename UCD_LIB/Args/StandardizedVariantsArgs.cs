using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.StandardizedVariants;
namespace UCD.Args
{
    public class StandardizedVariantsArgs : EventArgs
    {
        public StandardizedVariantsArgs() : base(){}
        public StandardizedVariantsArgs(SvItem Item)
            : base()
        {
            this.Item = Item;

        }
        public SvItem Item { get; set; }

    }
}
