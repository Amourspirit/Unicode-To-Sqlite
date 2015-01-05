using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD.CjkRadicals
{
    public class CjkRadicalsItem : DataItemBase
    {
        public CjkRadicalsItem() : base() { }
        #region Properties
        public Int64 ID { get; set; }
        public String Number { get; set; }
        public Int32 Radical { get; set; }
        public Int32? Ideograph { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/cjk-radicals elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.Number = el.Attribute("number").Value;
            this.Radical = DataHelper.HexStringToInt32(el.Attribute("radical").Value);
            this.Ideograph = DataHelper.HexCodePointToInt32Null((String)el.Attribute("ideograph"));
        }

        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public override Dictionary<string, object> ToObjectDictinary()
        {
            var ciDic = new Dictionary<string, object>();

            ciDic["number"] = this.Number;
            ciDic["radical"] = this.Radical;
            ciDic["ideograph"] = this.Ideograph;

            return ciDic;
        }
        #endregion
    }
}
