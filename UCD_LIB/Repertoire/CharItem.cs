using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using UCD.DataCommon;

namespace UCD.Repertoire
{
    /// <summary>
    /// Represents a char Element in UCD xml
    /// </summary>
    [Serializable()]
    public class CharItem
        : RepertoireBase
    {
        public CharItem() : base() { }

        //private Int32 _cp;

        //public Int32 cp
        //{
        //    get { return _cp; }
        //    set { _cp = value; }
        //}
        
        
       
        /// <summary>
        /// Checks to see if this CharItem is has a range or is a single code point.
        /// </summary>
        public bool IsRangeChar
        {
            get 
            {
                if ((this.FirstCodePoint > -1 ) && (this.LastCodePoint > -1) && (this.FirstCodePoint > this.LastCodePoint))
                {
                    return true;
                }
                return false;
            }
 
        }


        /// <summary>
        /// Gest if the <see cref="CharItem"/> <see cref="CharItem.cp"/> has a value.
        /// </summary>
        /// <returns>
        /// Returns true if <see cref="CharItem.cp"/> has a value otherwise false.
        /// </returns>
        /// <remarks>
        /// <see cref="CharItem"/> can have two states. <see cref="CharItem.cp"/> can have a value
        /// or <see cref="CharItem.first_cp"/> and <see cref="CharItem.last_cp"/> can have values.
        /// </remarks>
        public bool HasCp()
        {
            return this.CodePoint >= 0;
        }

        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/repertoire elements.
        /// </param>
        public override void PopulateFromElement(System.Xml.Linq.XElement el)
        {
            base.PopulateFromElement(el);

           
            var attCp = el.Attribute("cp");
            if (attCp != null)
            {
              this.CodePoint = DataHelper.HexStringToInt32((String)el.Attribute("cp"), -1);
            }

            var attFirstCp = el.Attribute("first-cp");
            if (attFirstCp != null)
            {
                string strVar = DataHelper.ThrowIfNull(attFirstCp.Value, el.Name.LocalName);
                this.FirstCodePoint = DataHelper.HexCodePointToInt32Null((String)el.Attribute("first-cp"));
                // if we are using cp as primary key then lets make it the value of first-cp
                // later we will create new copies of char item to span between  first_cp and last_cp
                // each char will a cp value of the next one in the range
                if (RepertoireTable.MakeCpPrimaryKey == true)
                {
                    if (this.HasCp() == false)
                    {
                        this.CodePoint = ((this.FirstCodePoint.HasValue == true) ? this.FirstCodePoint.Value : -1 );
                    }
                }
            }

            var attLastCp = el.Attribute("last-cp");
            if (attLastCp != null)
            {
                this.LastCodePoint = DataHelper.HexCodePointToInt32Null((String)el.Attribute("last-cp"));
            }
            
            if ((this.CodePoint == -1) &&  (this.FirstCodePoint.HasValue == false))
            {
                string msg = string.Format("Element '{0}' does  has null cp and null first_cp.", el.Name.LocalName);
                throw new Exception(msg);
            }
            
        }

        public override Dictionary<string, object> ToObjectDictinary()
        {
            Dictionary<string, object> ciDic = base.ToObjectDictinary();
            if (this.HasCp() == true)
            {
                ciDic["cp"] = this.CodePoint;
            }
            else
            {
                ciDic["cp"] = "";
                
            }
            return ciDic;
        }
       
    }

  
}