using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCD.Repertoire
{
    [Serializable()]
    public class NameAlias
    {
        public int ID { get; set; }
        public int RepertoireID { get; set; }
        public int cp { get; set; }
        public string alias { get; set; }
        public string type { get; set; }
        public NameAlias() { 
        }

        public Dictionary<string, object> ToObjectDictinary()
        {
            Dictionary<string, object> ciDic = new Dictionary<string, object>();
            if (RepertoireTable.MakeCpPrimaryKey == true)
            {
                ciDic["cp"] = this.cp;
            }
            else
            {
                ciDic["repertoireID"] = this.RepertoireID;
            }
            
            ciDic["alias"] = this.alias;
            ciDic["type"] = this.type;
            return ciDic;
        }
    }

        
}
