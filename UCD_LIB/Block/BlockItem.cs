using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UCD.DataCommon;

namespace UCD.Block
{
    [Serializable()]
    public class BlockItem : UCD.DataCommon.DataItemBase
    {
        public BlockItem() { }
        #region Properties
        public Int64 ID { get; set; }
        public String Name { get; set; }
        public Int32? FirstCodePoint { get; set; }
        public Int32? LastCodePoint { get; set; }
        #endregion
        #region Methods
        #region PopulateFromElement
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/blocks elements.
        /// </param>
        override public void  PopulateFromElement(XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.FirstCodePoint = DataHelper.HexStringToInt32(el.Attribute("first-cp").Value);
            this.LastCodePoint = DataHelper.HexStringToInt32(el.Attribute("last-cp").Value);
            this.Name = (string)el.Attribute("name") ?? string.Empty;
        }
        #endregion
        #region ToObjectDictinary
        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public override Dictionary<string, object> ToObjectDictinary()
        {
            var ciDic = new Dictionary<string, object>();

            ciDic["first_cp"] = this.FirstCodePoint;
            ciDic["last_cp"] = this.LastCodePoint;
            ciDic["name"] = this.Name;

            return ciDic;
        }
        #endregion
        #endregion
    }
}
