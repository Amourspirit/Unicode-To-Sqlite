using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.EmojiSource;

namespace UCD.Args
{
    public class EmojiSourceArgs: EventArgs
    {
        public EmojiSourceArgs() : base() { }
        public EmojiSourceArgs(EmojiSourceItem Item)
            : base()
        {
            this.Item = Item;

        }
        public EmojiSourceItem Item { get; set; }
    }
}