using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.Block;

namespace UCD.Args
{
    public class BlockItemArgs : EventArgs
    {
        public BlockItemArgs() : base() { }
        public BlockItemArgs(BlockItem Item)
            : base()
        {
            this.Item = Item;

        }
        public BlockItem Item { get; set; }
    }
}
