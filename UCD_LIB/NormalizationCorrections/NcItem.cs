using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.DataCommon;

namespace UCD.NormalizationCorrections
{
    public class NcItem : DataItemBase
    {
        public NcItem() : base(){}
        #region Properties
        public Int64 ID { get; set; }
        public Int32 CodePoint { get; set; }
        public Int32 CodePointOld { get; set; }
        public Int32 CodePointNew { get; set; }
        public String Version { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/normalization-corrections elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName  = el.Name.LocalName;
   
            this.CodePoint = DataHelper.HexStringToInt32(el.Attribute("cp").Value);
            this.CodePointOld = DataHelper.HexStringToInt32(el.Attribute("old").Value);
            this.CodePointNew = DataHelper.HexStringToInt32(el.Attribute("new").Value);
            this.Version = (string)el.Attribute("version") ?? string.Empty;
        }

        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public override Dictionary<string, object> ToObjectDictinary()
        {
            var ciDic = new Dictionary<string, object>();

            ciDic["cp"] = this.CodePoint;
            ciDic["old"] = this.CodePointOld;
            ciDic["new"] = this.CodePointNew;
            ciDic["version"] = this.Version;

            return ciDic;
        }
        #endregion

    }
}
