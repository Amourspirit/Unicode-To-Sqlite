using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UCD.DataCommon;

namespace UCD.Repertoire
{
    [Serializable()]
    public abstract class RepertoireBase : UCD.DataCommon.DataItemBase
    {
        public RepertoireBase() 
        {
            this.NameAliasList = new List<NameAlias>();
            this.CodePoint = -1;
            this.FirstCodePoint = -1;
            this.LastCodePoint = -1;
        }
        #region Properties
        public List<NameAlias> NameAliasList { get; set; }
        public Int32 ID { get; set; }

        public Int32 CodePoint { get; set; }
        public Int32? FirstCodePoint { get; set; }
        public Int32? LastCodePoint { get; set; }
        public Decimal Age { get; set; }
        public String Name { get; set; }
        public String NameOne { get; set; }
        public String Block { get; set; }
        public String GeneralCategory { get; set; }
        public Int32 Combining { get; set; }
        public String Bidirectionality { get; set; }
        public Boolean BidiM { get; set; }
        public String Bmg { get; set; }
        public Boolean BidiControl { get; set; }
        public String BidiParedBracketType { get; set; }
        public String BidiParedBracket { get; set; }
        public String DecompDt { get; set; }
        public String DecompDm { get; set; }
        public Boolean CompositionExclusion { get; set; }
        public Boolean FullCompositionExclusion { get; set; }
        public Int32 NfcQuickCheck { get; set; }
        public Boolean NfdQuickCheck { get; set; }
        public Int32 NfkcQuickCheck { get; set; }
        public Boolean NfkdQuickCheck { get; set; }
        public Boolean ExpandsOnNFC { get; set; }
        public Boolean ExpandsOnNFD { get; set; }
        public Boolean ExpandsOnNFKC { get; set; }
        public Boolean ExpandsOnNKFD { get; set; }
        public String FcNfkcClosure { get; set; }
        public String NumericType { get; set; }
        public String NumericValue { get; set; }
        public String JoiningClass { get; set; }
        public String JoiningGroup { get; set; }
        public Boolean JoiningControl { get; set; }
        public String LineBreak { get; set; }
        public String EastAsianWidth { get; set; }
        public Boolean Upper { get; set; }
        public Boolean Lower { get; set; }
        public Boolean OtherUpper { get; set; }
        public Boolean OtherLower { get; set; }
        public String SimplCaseMapUpperCase { get; set; }
        public String SimplCaseMapLowerCase { get; set; }
        public String SimplCaseMapTitleCase { get; set; }
        public String ComplexCaseMapUpperCase { get; set; }
        public String ComplexCaseMapLowerCase { get; set; }
        public String ComplexCaseMapTitleCase { get; set; }
        public String SimpleCaseFolding { get; set; }
        public String CaseFolding { get; set; }
        public Boolean CaseIgnorable { get; set; }
        public Boolean Cased { get; set; }
        public Boolean ChangesWhenCasefolded { get; set; }
        public Boolean ChangesWhenCasemapped { get; set; }
        public Boolean ChangesWhenLowercased { get; set; }
        public Boolean ChangesWhenNfkcCasefolded { get; set; }
        public Boolean ChangesWhenTitlecased { get; set; }
        public Boolean ChangesWhenUppercased { get; set; }
        public String NfkcCasefold { get; set; }
        public String Script { get; set; }
        public String ScriptExtension { get; set; }
        public String Iso10646comment { get; set; }
        public String HangulSyllableType { get; set; }
        public String JamoShortName { get; set; }
        public String IndicSyllabicCategory { get; set; }
        public String IndicMatraCategory { get; set; }
        public Boolean IdStart { get; set; }
        public Boolean OtherIdStart { get; set; }
        public Boolean XidStart { get; set; }
        public Boolean IdContinue { get; set; }
        public Boolean OtherIdContinue { get; set; }
        public Boolean XidContinue { get; set; }
        public Boolean PatternSyntax { get; set; }
        public Boolean PatternWhiteSpace { get; set; }
        public Boolean Dash { get; set; }
        public Boolean Hyphen { get; set; }
        public Boolean QuotationMark { get; set; }
        public Boolean TerminalPunctuation { get; set; }
        public Boolean STerm { get; set; }
        public Boolean Diacritic { get; set; }
        public Boolean Extender { get; set; }
        public Boolean SoftDotted { get; set; }
        public Boolean Alphabetic { get; set; }
        public Boolean OtherAlphabetic { get; set; }
        public Boolean Math { get; set; }
        public Boolean OtherMath { get; set; }
        public Boolean HexDigit { get; set; }
        public Boolean ASCIIHexDigit { get; set; }
        public Boolean DefaultIgnorableCodePoint { get; set; }
        public Boolean OtherDefaultIgnorableCodePoint { get; set; }
        public Boolean LogicalOrderException { get; set; }
        public Boolean WhiteSpace { get; set; }
        public Boolean GraphemeBase { get; set; }
        public Boolean GraphemeExtend { get; set; }
        public Boolean OtherGraphemeExtend { get; set; }
        public Boolean GraphemeLink { get; set; }
        public String GraphemeClusterBreak { get; set; }
        public String WordBreak { get; set; }
        public String SentenceBreak { get; set; }
        public Boolean Ideographic { get; set; }
        public Boolean UnifiedIdeograph { get; set; }
        public Boolean IDSBinaryOperator { get; set; }
        public Boolean IDSTrinaryOperator { get; set; }
        public Boolean Radical { get; set; }
        public Boolean Deprecated { get; set; }
        public Boolean VariationSelector { get; set; }
        public Boolean NoncharacterCodePoint { get; set; }



#endregion

        #region Methods
        #region     PopulateFromElement
        /// <summary>
        /// Populates the class with data from XElement
        /// </summary>
        /// <param name="el">
        /// The XElement containing the data to populate the class with.
        /// This is expected to ba an element from a UCD XML file - ucd/repertoire elements.
        /// </param>
        override public void  PopulateFromElement(XElement el)
        {
           
            // Regex Replacements
            // Integer Find:        i:([0-9A-Za-z_]*)
            // Integer Replace:     $1 = (int?)c.Attribute("$1") ?? 0;
            // String Find:         s:([0-9A-Za-z_]*)
            // String Replace:      $1 = (string)c.Attribute("$1") ?? string.Empty;
            // Decimal Find:        d:([0-9A-Za-z_]*)
            // Decimal Replace:     $1 = DataHelper.StringToDecimal((string)c.Attribute("$1"));
            // Boolean Find:        b:([0-9A-Za-z_]*)
            // Boolean Replace:     $1 = DataHelper.StringToBool((string)c.Attribute("$1"));
            
            ElementName = el.Name.LocalName;
            //this.CodePoint = (int?)el.Attribute("cp") ?? 0;
            //this.FirstCodePoint = (int?)el.Attribute("first-cp") ?? 0;
            //this.LastCodePoint = (int?)el.Attribute("last-cp") ?? 0;
            this.Age = DataHelper.StringToDecimal((string)el.Attribute("age"));
            this.Name = (string)el.Attribute("na") ?? string.Empty;
            this.NameOne = (string)el.Attribute("na1") ?? string.Empty;
            this.Block = (string)el.Attribute("blk") ?? string.Empty;
            this.GeneralCategory = (string)el.Attribute("gc") ?? string.Empty;
            this.Combining = (int?)el.Attribute("ccc") ?? 0;
            this.Bidirectionality = (string)el.Attribute("bc") ?? string.Empty;
            this.BidiM = DataHelper.StringToBool((string)el.Attribute("Bidi_M"));
            this.Bmg = (string)el.Attribute("bmg") ?? string.Empty;
            this.BidiControl = DataHelper.StringToBool((string)el.Attribute("Bidi_C"));
            this.BidiParedBracketType = (string)el.Attribute("bpt") ?? string.Empty;
            this.BidiParedBracket = (string)el.Attribute("bpb") ?? string.Empty;
            this.DecompDt = (string)el.Attribute("dt") ?? string.Empty;
            this.DecompDm = (string)el.Attribute("dm") ?? string.Empty;
            this.CompositionExclusion = DataHelper.StringToBool((string)el.Attribute("CE"));
            this.FullCompositionExclusion = DataHelper.StringToBool((string)el.Attribute("Comp_Ex"));
            this.NfcQuickCheck = DataHelper.YesNoMabeyToInt32((string)el.Attribute("NFC_QC"));
            this.NfdQuickCheck = DataHelper.StringToBool((string)el.Attribute("NFD_QC"));
            this.NfkcQuickCheck = DataHelper.YesNoMabeyToInt32((string)el.Attribute("NFKC_QC"));
            this.NfkdQuickCheck = DataHelper.StringToBool((string)el.Attribute("NFKD_QC"));
            this.ExpandsOnNFC = DataHelper.StringToBool((string)el.Attribute("XO_NFC"));
            this.ExpandsOnNFD = DataHelper.StringToBool((string)el.Attribute("XO_NFD"));
            this.ExpandsOnNFKC = DataHelper.StringToBool((string)el.Attribute("XO_NFKC"));
            this.ExpandsOnNKFD = DataHelper.StringToBool((string)el.Attribute("XO_NFKD"));
            this.FcNfkcClosure = (string)el.Attribute("FC_NFKC") ?? string.Empty;
            this.NumericType = (string)el.Attribute("nt") ?? string.Empty;
            this.NumericValue = (string)el.Attribute("nv") ?? string.Empty;
            this.JoiningClass = (string)el.Attribute("jt") ?? string.Empty;
            this.JoiningGroup = (string)el.Attribute("jg") ?? string.Empty;
            this.JoiningControl = DataHelper.StringToBool((string)el.Attribute("Join_C"));
            this.LineBreak = (string)el.Attribute("lb") ?? string.Empty;
            this.EastAsianWidth = (string)el.Attribute("ea") ?? string.Empty;
            this.Upper = DataHelper.StringToBool((string)el.Attribute("Upper"));
            this.Lower = DataHelper.StringToBool((string)el.Attribute("Lower"));
            this.OtherUpper = DataHelper.StringToBool((string)el.Attribute("OUpper"));
            this.OtherLower = DataHelper.StringToBool((string)el.Attribute("OLower"));
            this.SimplCaseMapUpperCase = (string)el.Attribute("suc") ?? string.Empty;
            this.SimplCaseMapLowerCase = (string)el.Attribute("slc") ?? string.Empty;
            this.SimplCaseMapTitleCase = (string)el.Attribute("stc") ?? string.Empty;
            this.ComplexCaseMapUpperCase = (string)el.Attribute("uc") ?? string.Empty;
            this.ComplexCaseMapLowerCase = (string)el.Attribute("lc") ?? string.Empty;
            this.ComplexCaseMapTitleCase = (string)el.Attribute("tc") ?? string.Empty;
            this.SimpleCaseFolding = (string)el.Attribute("scf") ?? string.Empty;
            this.CaseFolding = (string)el.Attribute("cf") ?? string.Empty;
            this.CaseIgnorable = DataHelper.StringToBool((string)el.Attribute("CI"));
            this.Cased = DataHelper.StringToBool((string)el.Attribute("Cased"));
            this.ChangesWhenCasefolded = DataHelper.StringToBool((string)el.Attribute("CWCF"));
            this.ChangesWhenCasemapped = DataHelper.StringToBool((string)el.Attribute("CWCM"));
            this.ChangesWhenLowercased = DataHelper.StringToBool((string)el.Attribute("CWL"));
            this.ChangesWhenNfkcCasefolded = DataHelper.StringToBool((string)el.Attribute("CWKCF"));
            this.ChangesWhenTitlecased = DataHelper.StringToBool((string)el.Attribute("CWT"));
            this.ChangesWhenUppercased = DataHelper.StringToBool((string)el.Attribute("CWU"));
            this.NfkcCasefold = (string)el.Attribute("NFKC_CF") ?? string.Empty;
            this.Script = (string)el.Attribute("sc") ?? string.Empty;
            this.ScriptExtension = (string)el.Attribute("scx") ?? string.Empty;
            this.Iso10646comment = (string)el.Attribute("isc") ?? string.Empty;
            this.HangulSyllableType = (string)el.Attribute("hst") ?? string.Empty;
            this.JamoShortName = (string)el.Attribute("JSN") ?? string.Empty;
            this.IndicSyllabicCategory = (string)el.Attribute("InSC") ?? string.Empty;
            this.IndicMatraCategory = (string)el.Attribute("InMC") ?? string.Empty;
            this.IdStart = DataHelper.StringToBool((string)el.Attribute("IDS"));
            this.OtherIdStart = DataHelper.StringToBool((string)el.Attribute("OIDS"));
            this.XidStart = DataHelper.StringToBool((string)el.Attribute("XIDS"));
            this.IdContinue = DataHelper.StringToBool((string)el.Attribute("IDC"));
            this.OtherIdContinue = DataHelper.StringToBool((string)el.Attribute("OIDC"));
            this.XidContinue = DataHelper.StringToBool((string)el.Attribute("XIDC"));
            this.PatternSyntax = DataHelper.StringToBool((string)el.Attribute("Pat_Syn"));
            this.PatternWhiteSpace = DataHelper.StringToBool((string)el.Attribute("Pat_WS"));
            this.Dash = DataHelper.StringToBool((string)el.Attribute("Dash"));
            this.Hyphen = DataHelper.StringToBool((string)el.Attribute("Hyphen"));
            this.QuotationMark = DataHelper.StringToBool((string)el.Attribute("QMark"));
            this.TerminalPunctuation = DataHelper.StringToBool((string)el.Attribute("Term"));
            this.STerm = DataHelper.StringToBool((string)el.Attribute("STerm"));
            this.Diacritic = DataHelper.StringToBool((string)el.Attribute("Dia"));
            this.Extender = DataHelper.StringToBool((string)el.Attribute("Ext"));
            this.SoftDotted = DataHelper.StringToBool((string)el.Attribute("SD"));
            this.Alphabetic = DataHelper.StringToBool((string)el.Attribute("Alpha"));
            this.OtherAlphabetic = DataHelper.StringToBool((string)el.Attribute("OAlpha"));
            this.Math = DataHelper.StringToBool((string)el.Attribute("Math"));
            this.OtherMath = DataHelper.StringToBool((string)el.Attribute("OMath"));
            this.HexDigit = DataHelper.StringToBool((string)el.Attribute("Hex"));
            this.ASCIIHexDigit = DataHelper.StringToBool((string)el.Attribute("AHex"));
            this.DefaultIgnorableCodePoint = DataHelper.StringToBool((string)el.Attribute("DI"));
            this.OtherDefaultIgnorableCodePoint = DataHelper.StringToBool((string)el.Attribute("ODI"));
            this.LogicalOrderException = DataHelper.StringToBool((string)el.Attribute("LOE"));
            this.WhiteSpace = DataHelper.StringToBool((string)el.Attribute("WSpace"));
            this.GraphemeBase = DataHelper.StringToBool((string)el.Attribute("Gr_Base"));
            this.GraphemeExtend = DataHelper.StringToBool((string)el.Attribute("Gr_Ext"));
            this.OtherGraphemeExtend = DataHelper.StringToBool((string)el.Attribute("OGr_Ext"));
            this.GraphemeLink = DataHelper.StringToBool((string)el.Attribute("Gr_Link"));
            this.GraphemeClusterBreak = (string)el.Attribute("GCB") ?? string.Empty;
            this.WordBreak = (string)el.Attribute("WB") ?? string.Empty;
            this.SentenceBreak = (string)el.Attribute("SB") ?? string.Empty;
            this.Ideographic = DataHelper.StringToBool((string)el.Attribute("Ideo"));
            this.UnifiedIdeograph = DataHelper.StringToBool((string)el.Attribute("UIdeo"));
            this.IDSBinaryOperator = DataHelper.StringToBool((string)el.Attribute("IDSB"));
            this.IDSTrinaryOperator = DataHelper.StringToBool((string)el.Attribute("IDST"));
            this.Radical = DataHelper.StringToBool((string)el.Attribute("Radical"));
            this.Deprecated = DataHelper.StringToBool((string)el.Attribute("Dep"));
            this.VariationSelector = DataHelper.StringToBool((string)el.Attribute("VS"));
            this.NoncharacterCodePoint = DataHelper.StringToBool((string)el.Attribute("NChar"));


            var children = el.Descendants(el.GetDefaultNamespace() + "name-alias");
            //var children = el.Descendants();
            if (children != null)
            {
                foreach (XElement child in children)
                {
                    NameAlias _alias = new NameAlias();
                    _alias.alias = (string)child.Attribute("alias") ?? string.Empty;
                    _alias.type = (string)child.Attribute("type") ?? string.Empty;
                    _alias.cp = this.CodePoint;
                    this.NameAliasList.Add(_alias);
                }
                
            }
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
            ciDic["cp"] = this.CodePoint;
            ciDic["first_cp"] = this.FirstCodePoint;
            ciDic["last_cp"] = this.LastCodePoint;
            ciDic["age"] = this.Age;
            ciDic["na"] = this.Name;
            ciDic["na1"] = this.NameOne;
            ciDic["blk"] = this.Block;
            ciDic["gc"] = this.GeneralCategory;
            ciDic["ccc"] = this.Combining;
            ciDic["bc"] = this.Bidirectionality;
            ciDic["Bidi_M"] = Convert.ToInt32(this.BidiM);
            ciDic["bmg"] = this.Bmg;
            ciDic["Bidi_C"] = Convert.ToInt32(this.BidiControl);
            ciDic["bpt"] = this.BidiParedBracketType;
            ciDic["bpb"] = this.BidiParedBracket;
            ciDic["dt"] = this.DecompDt;
            ciDic["dm"] = this.DecompDm;
            ciDic["CE"] = Convert.ToInt32(this.CompositionExclusion);
            ciDic["Comp_Ex"] = Convert.ToInt32(this.FullCompositionExclusion);
            ciDic["NFC_QC"] = this.NfcQuickCheck;
            ciDic["NFD_QC"] = Convert.ToInt32(this.NfdQuickCheck);
            ciDic["NFKC_QC"] = this.NfkcQuickCheck;
            ciDic["NFKD_QC"] = Convert.ToInt32(this.NfkdQuickCheck);
            ciDic["XO_NFC"] = Convert.ToInt32(this.ExpandsOnNFC);
            ciDic["XO_NFD"] = Convert.ToInt32(this.ExpandsOnNFD);
            ciDic["XO_NFKC"] = Convert.ToInt32(this.ExpandsOnNFKC);
            ciDic["XO_NFKD"] = Convert.ToInt32(this.ExpandsOnNKFD);
            ciDic["FC_NFKC"] = this.FcNfkcClosure;
            ciDic["nt"] = this.NumericType;
            ciDic["nv"] = this.NumericValue;
            ciDic["jt"] = this.JoiningClass;
            ciDic["jg"] = this.JoiningGroup;
            ciDic["Join_C"] = Convert.ToInt32(this.JoiningControl);
            ciDic["lb"] = this.LineBreak;
            ciDic["ea"] = this.EastAsianWidth;
            ciDic["Upper"] = Convert.ToInt32(this.Upper);
            ciDic["Lower"] = Convert.ToInt32(this.Lower);
            ciDic["OUpper"] = Convert.ToInt32(this.OtherUpper);
            ciDic["OLower"] = Convert.ToInt32(this.OtherLower);
            ciDic["suc"] = this.SimplCaseMapUpperCase;
            ciDic["slc"] = this.SimplCaseMapLowerCase;
            ciDic["stc"] = this.SimplCaseMapTitleCase;
            ciDic["uc"] = this.ComplexCaseMapUpperCase;
            ciDic["lc"] = this.ComplexCaseMapLowerCase;
            ciDic["tc"] = this.ComplexCaseMapTitleCase;
            ciDic["scf"] = this.SimpleCaseFolding;
            ciDic["cf"] = this.CaseFolding;
            ciDic["CI"] = Convert.ToInt32(this.CaseIgnorable);
            ciDic["Cased"] = Convert.ToInt32(this.Cased);
            ciDic["CWCF"] = Convert.ToInt32(this.ChangesWhenCasefolded);
            ciDic["CWCM"] = Convert.ToInt32(this.ChangesWhenCasemapped);
            ciDic["CWL"] = Convert.ToInt32(this.ChangesWhenLowercased);
            ciDic["CWKCF"] = Convert.ToInt32(this.ChangesWhenNfkcCasefolded);
            ciDic["CWT"] = Convert.ToInt32(this.ChangesWhenTitlecased);
            ciDic["CWU"] = Convert.ToInt32(this.ChangesWhenUppercased);
            ciDic["NFKC_CF"] = this.NfkcCasefold;
            ciDic["sc"] = this.Script;
            ciDic["scx"] = this.ScriptExtension;
            ciDic["isc"] = this.Iso10646comment;
            ciDic["hst"] = this.HangulSyllableType;
            ciDic["JSN"] = this.JamoShortName;
            ciDic["InSC"] = this.IndicSyllabicCategory;
            ciDic["InMC"] = this.IndicMatraCategory;
            ciDic["IDS"] = Convert.ToInt32(this.IdStart);
            ciDic["OIDS"] = Convert.ToInt32(this.OtherIdStart);
            ciDic["XIDS"] = Convert.ToInt32(this.XidStart);
            ciDic["IDC"] = Convert.ToInt32(this.IdContinue);
            ciDic["OIDC"] = Convert.ToInt32(this.OtherIdContinue);
            ciDic["XIDC"] = Convert.ToInt32(this.XidContinue);
            ciDic["Pat_Syn"] = Convert.ToInt32(this.PatternSyntax);
            ciDic["Pat_WS"] = Convert.ToInt32(this.PatternWhiteSpace);
            ciDic["Dash"] = Convert.ToInt32(this.Dash);
            ciDic["Hyphen"] = Convert.ToInt32(this.Hyphen);
            ciDic["QMark"] = Convert.ToInt32(this.QuotationMark);
            ciDic["Term"] = Convert.ToInt32(this.TerminalPunctuation);
            ciDic["STerm"] = Convert.ToInt32(this.STerm);
            ciDic["Dia"] = Convert.ToInt32(this.Diacritic);
            ciDic["Ext"] = Convert.ToInt32(this.Extender);
            ciDic["SD"] = Convert.ToInt32(this.SoftDotted);
            ciDic["Alpha"] = Convert.ToInt32(this.Alphabetic);
            ciDic["OAlpha"] = Convert.ToInt32(this.OtherAlphabetic);
            ciDic["Math"] = Convert.ToInt32(this.Math);
            ciDic["OMath"] = Convert.ToInt32(this.OtherMath);
            ciDic["Hex"] = Convert.ToInt32(this.HexDigit);
            ciDic["AHex"] = Convert.ToInt32(this.ASCIIHexDigit);
            ciDic["DI"] = Convert.ToInt32(this.DefaultIgnorableCodePoint);
            ciDic["ODI"] = Convert.ToInt32(this.OtherDefaultIgnorableCodePoint);
            ciDic["LOE"] = Convert.ToInt32(this.LogicalOrderException);
            ciDic["WSpace"] = Convert.ToInt32(this.WhiteSpace);
            ciDic["Gr_Base"] = Convert.ToInt32(this.GraphemeBase);
            ciDic["Gr_Ext"] = Convert.ToInt32(this.GraphemeExtend);
            ciDic["OGr_Ext"] = Convert.ToInt32(this.OtherGraphemeExtend);
            ciDic["Gr_Link"] = Convert.ToInt32(this.GraphemeLink);
            ciDic["GCB"] = this.GraphemeClusterBreak;
            ciDic["WB"] = this.WordBreak;
            ciDic["SB"] = this.SentenceBreak;
            ciDic["Ideo"] = Convert.ToInt32(this.Ideographic);
            ciDic["UIdeo"] = Convert.ToInt32(this.UnifiedIdeograph);
            ciDic["IDSB"] = Convert.ToInt32(this.IDSBinaryOperator);
            ciDic["IDST"] = Convert.ToInt32(this.IDSTrinaryOperator);
            ciDic["Radical"] = Convert.ToInt32(this.Radical);
            ciDic["Dep"] = Convert.ToInt32(this.Deprecated);
            ciDic["VS"] = Convert.ToInt32(this.VariationSelector);
            ciDic["NChar"] = Convert.ToInt32(this.NoncharacterCodePoint);

            ciDic["elementName"] = this.ElementName;
            return ciDic;
        }
        #endregion
        #endregion

    }
}
