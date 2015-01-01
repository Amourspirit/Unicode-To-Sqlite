using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.DataCommon;

namespace UCD.NamedSequence
{
    public class NsItem : DataItemBase
    {
        public NsItem() { }
        #region Properties
        public Int64 ID { get; set; }
        //public Int32? FirstCodePoint { get; set; }
        //public Int32? LastCodePoint { get; set; }
        public string CodePoints { get; set; }
        public String Name { get; set; }
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
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            String _cps = el.Attribute("cps").Value;
            this.CodePoints = _cps;
            //List<Int32> FirstLast = DataHelper.SplitHexString(_cps);
            //if (FirstLast.Count == 2)
            //{
            //    this.FirstCodePoint = FirstLast[0];
            //    this.LastCodePoint = FirstLast[1];
            //}
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

            //ciDic["first_cp"] = this.FirstCodePoint;
            //ciDic["last_cp"] = this.LastCodePoint;
            ciDic["cps"] = this.CodePoints;
            ciDic["name"] = this.Name;

            return ciDic;
        }
        #endregion
        #endregion
    }
}
