using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD.StandardizedVariants
{
    public class SvItem : DataItemBase
    {
        public SvItem() : base() { }
        #region Properties
        public Int64 ID { get; set; }
        public String CodePoints { get; set; }
        public String When { get; set; }
        public String Description { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/blocks elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.CodePoints = (string)el.Attribute("cps") ?? string.Empty;
            this.Description = (string)el.Attribute("desc") ?? string.Empty;
            this.When = (string)el.Attribute("when") ?? string.Empty;
        }

        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public override Dictionary<string, object> ToObjectDictinary()
        {
            var ciDic = new Dictionary<string, object>();

            ciDic["cps"] = this.CodePoints;
            ciDic["desc"] = this.Description;
            ciDic["when"] = this.When;

            return ciDic;
        }
        #endregion
    }
}
