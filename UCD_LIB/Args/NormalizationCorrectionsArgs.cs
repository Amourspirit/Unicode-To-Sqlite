using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.NormalizationCorrections;
namespace UCD.Args
{
    public class NormalizationCorrectionsArgs : EventArgs
    {
        public NormalizationCorrectionsArgs() : base() { }
        public NormalizationCorrectionsArgs(NcItem Item)
            : base()
        {
            this.Item = Item;

        }
        public NcItem Item { get; set; }
    }
}
