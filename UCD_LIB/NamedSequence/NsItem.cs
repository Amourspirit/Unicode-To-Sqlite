using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.DataCommon;

namespace UCD.NamedSequence
{
    /// <summary>
    /// Class that represents Named Sequences of the UCD.
    /// </summary>
    /// <remarks>
    /// UCD documentation states that there can be elements named-sequences and
    /// provisional-named-sequences Children of UCD element. It appears there are no
    /// provisional-named-sequences in ucd.all.flat.xml. This class will serve as both
    /// cases. The <see cref="NsItem.ParentElementName"/> will be used to store the element
    /// name on the database.
    /// </remarks>
    public class NsItem : DataItemBase
    {
        public NsItem() { }
        #region Properties
        /// <summary>
        /// The id of the entry. Primary key
        /// </summary>
        public Int64 ID { get; set; }
        /// <summary>
        /// One or more code points of the Named Sequence
        /// </summary>
        public string CodePoints { get; set; }
        /// <summary>
        /// The name of the Named Sequence
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// The name of named-sequence element parent.
        /// Expected to be named-sequences or provisional-named-sequences
        /// </summary>
        public String ParentElementName { get; set; }
        #endregion
        #region Methods
        #region PopulateFromElement
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/named-sequences elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            this.ElementName = el.Name.LocalName;
            this.ParentElementName = el.Parent.Name.LocalName;
            this.CodePoints = (String)el.Attribute("cps");
            this.Name = (String)el.Attribute("name");
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
            ciDic["cps"] = this.CodePoints;
            ciDic["name"] = this.Name;

            ciDic["parentElementName"] = this.ElementName;
            return ciDic;
        }
        #endregion
        #endregion
    }
}
