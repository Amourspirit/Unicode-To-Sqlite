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
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.CodePoints = (string)el.Attribute("cps") ?? string.Empty;
            this.Description = (string)el.Attribute("desc") ?? string.Empty;
            this.When = (string)el.Attribute("when") ?? string.Empty;
        }

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
