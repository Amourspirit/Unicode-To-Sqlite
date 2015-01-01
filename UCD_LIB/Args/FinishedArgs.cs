using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCD.Args
{
    public class FinishedArgs : EventArgs
    {
        public FinishedArgs() : base() { }

        public FinishedArgs(int count) : base()
        {
            this.EntryCount = count;
        }

        public int EntryCount { get; set; }
    }
}
