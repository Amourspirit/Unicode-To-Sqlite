using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UCD.DataCommon
{
    [Serializable()]
    public abstract class DataItemBase
    {
        /// <summary>
        /// The name of the Xml Element for this instance.
        /// </summary>
        public String ElementName { get; set; }
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/blocks elements.
        /// </param>
        public abstract void PopulateFromElement(XElement el);
        /// <summary>
        /// Creates a Dictionary of String Object representing the values of the class for use with sqllite
        /// </summary>
        /// <returns>Dictionary of String, Object representing the data of the class</returns>
        public abstract Dictionary<string, object> ToObjectDictinary();

    }
}
