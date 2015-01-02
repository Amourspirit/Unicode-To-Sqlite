using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD.EmojiSource
{
    public class EmojiSourceItem : DataItemBase
    {
        public EmojiSourceItem() : base() { }
        #region Properties
        public Int64 ID { get; set; }
        public String Unicode { get; set; }
        public Int32? Docomo { get; set; }
        public Int32? Kddi { get; set; }
        public Int32? Softbank { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/emoji-sources elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.Unicode = el.Attribute("unicode").Value;
            this.Docomo = DataHelper.HexStringToInt32Null(el.Attribute("docomo").Value);
            this.Kddi = DataHelper.HexStringToInt32Null(el.Attribute("kddi").Value);
            this.Softbank = DataHelper.HexStringToInt32Null(el.Attribute("softbank").Value);
        }

        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public override Dictionary<string, object> ToObjectDictinary()
        {
            var ciDic = new Dictionary<string, object>();

            ciDic["unicode"] = this.Unicode;
            ciDic["docomo"] = this.Docomo;
            ciDic["kddi"] = this.Kddi;
            ciDic["softbank"] = this.Softbank;

            return ciDic;
        }
        #endregion
    }
}
