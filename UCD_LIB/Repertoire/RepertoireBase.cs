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
        }
        #region Properties
        public List<NameAlias> NameAliasList { get; set; }
        public Int32 ID { get; set; }

        public Int32 CodePoint { get; set; }
        public Int32? FirstCodePoint { get; set; }
        public Int32? LastCodePoint { get; set; }
        public Decimal? Age { get; set; }
        public String Name { get; set; }
        public String NameOne { get; set; }
        public String Block { get; set; }
        public String GeneralCategory { get; set; }
        public Int32? Combining { get; set; }
        public String Bidirectionality { get; set; }
        public Boolean BidiM { get; set; }
        public Int32? Bmg { get; set; }
        public Boolean BidiControl { get; set; }
        public String BidiParedBracketType { get; set; }
        public String BidiParedBracket { get; set; }
        public String DecompDt { get; set; }
        public String DecompDm { get; set; }
        public Boolean CompositionExclusion { get; set; }
        public Boolean FullCompositionExclusion { get; set; }
        public Int32? NfcQuickCheck { get; set; }
        public Boolean NfdQuickCheck { get; set; }
        public Int32? NfkcQuickCheck { get; set; }
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
        public Int32? SimplCaseMapUpperCase { get; set; }
        public Int32? SimplCaseMapLowerCase { get; set; }
        public Int32? SimplCaseMapTitleCase { get; set; }
        public String ComplexCaseMapUpperCase { get; set; }
        public String ComplexCaseMapLowerCase { get; set; }
        public String ComplexCaseMapTitleCase { get; set; }
        public Int32? SimpleCaseFolding { get; set; }
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
        public Int32? kAccountingNumeric { get; set; }
        public String kAlternateHanYu { get; set; }
        public String kAlternateJEF { get; set; }
        public String kAlternateKangXi { get; set; }
        public String kAlternateMorohashi { get; set; }
        public Int32? kBigFive { get; set; }
        public Int32? kCCCII { get; set; }
        public String kCNS1986 { get; set; }
        public String kCNS1992 { get; set; }
        public String kCangjie { get; set; }
        public String kCantonese { get; set; }
        public String kCheungBauer { get; set; }
        public String kCheungBauerIndex { get; set; }
        public String kCihaiT { get; set; }
        public String kCompatibilityVariant { get; set; }
        public String kCowles { get; set; }
        public String kDaeJaweon { get; set; }
        public String kDefinition { get; set; }
        public Int32? kEACC { get; set; }
        public String kFenn { get; set; }
        public Decimal? kFennIndex { get; set; }
        public Decimal? kFourCornerCode { get; set; }
        public Int32? kFrequency { get; set; }
        public Int32? kGB0 { get; set; }
        public Int32? kGB1 { get; set; }
        public Int32? kGB3 { get; set; }
        public Int32? kGB5 { get; set; }
        public Int32? kGB7 { get; set; }
        public Int32? kGB8 { get; set; }
        public Int32? kGradeLevel { get; set; }
        public String kGSR { get; set; }
        public String kHangul { get; set; }
        public Decimal? kHanYu { get; set; }
        public String kHanyuPinlu { get; set; }
        public String kHanyuPinyin { get; set; }
        public String kHDZRadBreak { get; set; }
        public Int32? kHKGlyph { get; set; }
        public Int32? kHKSCS { get; set; }
        public String kIBMJapan { get; set; }
        public String kIICore { get; set; }
        public String kIRGDaeJaweon { get; set; }
        public String kIRGDaiKanwaZiten { get; set; }
        public String kIRGHanyuDaZidian { get; set; }
        public String kIRGKangXi { get; set; }
        public String kirgGSource { get; set; }
        public String KirgHSource { get; set; }
        public String KirgJSource { get; set; }
        public String KirgKPSource { get; set; }
        public String KirgKSource { get; set; }
        public String KirgMSource { get; set; }
        public String KirgTSource { get; set; }
        public String KirgUSource { get; set; }
        public String KirgVSource { get; set; }
        public String kJHJ { get; set; }
        public String kJIS0213 { get; set; }
        public String kJapaneseKun { get; set; }
        public String kJapaneseOn { get; set; }
        public Int32? kJis0 { get; set; }
        public Int32? kJis1 { get; set; }
        public Int32? kKPS0 { get; set; }
        public Int32? kKPS1 { get; set; }
        public Int32? kKSC0 { get; set; }
        public Int32? kKSC1 { get; set; }
        public String kKangXi { get; set; }
        public String kKarlgren { get; set; }
        public String kKorean { get; set; }
        public String kLau { get; set; }
        public Int32? kMainlandTelegraph { get; set; }
        public String kMandarin { get; set; }
        public String kMatthews { get; set; }
        public String kMeyerWempe { get; set; }
        public String kMorohashi { get; set; }
        public String kNelson { get; set; }
        public String kOtherNumeric { get; set; }
        public String kPhonetic { get; set; }
        public Int32? kPrimaryNumeric { get; set; }
        public Int32? kPseudoGB1 { get; set; }
        public String kRSAdobeJapan1_6 { get; set; }
        public Decimal? kRSJapanese { get; set; }
        public Decimal? kRSKanWa { get; set; }
        public Decimal? kRSKangXi { get; set; }
        public Decimal? kRSKorean { get; set; }
        public String kRSMerged { get; set; }
        public String kRSUnicode { get; set; }
        public String kSBGY { get; set; }
        public String kSemanticVariant { get; set; }
        public String kSimplifiedVariant { get; set; }
        public String kSpecializedSemanticVariant { get; set; }
        public Int32? kTaiwanTelegraph { get; set; }
        public String kTang { get; set; }
        public String kTotalStrokes { get; set; }
        public String kTraditionalVariant { get; set; }
        public String kVietnamese { get; set; }
        public String kXHC1983 { get; set; }
        public String kWubi { get; set; }
        public String kXerox { get; set; }
        public String kZVariant { get; set; }

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
           
            
            #region Populate from Element
            ElementName = el.Name.LocalName;
            //this.CodePoint = DataHelper.HexStringToInt32((String)el.Attribute("cp"), -1);
            //this.FirstCodePoint = DataHelper.HexCodePointToInt32Null((String)el.Attribute("first-cp"));
            //this.LastCodePoint = DataHelper.HexCodePointToInt32Null((String)el.Attribute("last-cp"));
            this.Age = DataHelper.StringtoDecimalNull((String)el.Attribute("age"));
            this.Name = DataHelper.StringToStringNull((String)el.Attribute("na"));
            this.NameOne = DataHelper.StringToStringNull((String)el.Attribute("na1"));
            this.Block = DataHelper.StringToStringNull((String)el.Attribute("blk"));
            this.GeneralCategory = DataHelper.StringToStringNull((String)el.Attribute("gc"));
            this.Combining = DataHelper.StringToInt32Null((String)el.Attribute("ccc"));
            this.Bidirectionality = DataHelper.StringToStringNull((String)el.Attribute("bc"));
            this.BidiM = DataHelper.StringToBool((String)el.Attribute("Bidi_M"));
            this.Bmg = DataHelper.HexCodePointToInt32Null((String)el.Attribute("bmg"));
            this.BidiControl = DataHelper.StringToBool((String)el.Attribute("Bidi_C"));
            this.BidiParedBracketType = DataHelper.StringToStringNull((String)el.Attribute("bpt"));
            this.BidiParedBracket = DataHelper.StringToStringNull((String)el.Attribute("bpb"));
            this.DecompDt = DataHelper.StringToStringNull((String)el.Attribute("dt"));
            this.DecompDm = DataHelper.StringToStringNull((String)el.Attribute("dm"));
            this.CompositionExclusion = DataHelper.StringToBool((String)el.Attribute("CE"));
            this.FullCompositionExclusion = DataHelper.StringToBool((String)el.Attribute("Comp_Ex"));
            this.NfcQuickCheck = DataHelper.YesNoMabeyToInt32((String)el.Attribute("NFC_QC"));
            this.NfdQuickCheck = DataHelper.StringToBool((String)el.Attribute("NFD_QC"));
            this.NfkcQuickCheck = DataHelper.YesNoMabeyToInt32((String)el.Attribute("NFKC_QC"));
            this.NfkdQuickCheck = DataHelper.StringToBool((String)el.Attribute("NFKD_QC"));
            this.ExpandsOnNFC = DataHelper.StringToBool((String)el.Attribute("XO_NFC"));
            this.ExpandsOnNFD = DataHelper.StringToBool((String)el.Attribute("XO_NFD"));
            this.ExpandsOnNFKC = DataHelper.StringToBool((String)el.Attribute("XO_NFKC"));
            this.ExpandsOnNKFD = DataHelper.StringToBool((String)el.Attribute("XO_NFKD"));
            this.FcNfkcClosure = DataHelper.StringToStringNull((String)el.Attribute("FC_NFKC"));
            this.NumericType = DataHelper.StringToStringNull((String)el.Attribute("nt"));
            this.NumericValue = el.Attribute("nv").Value;
            this.JoiningClass = el.Attribute("jt").Value;
            this.JoiningGroup = el.Attribute("jg").Value;
            this.JoiningControl = DataHelper.StringToBool((String)el.Attribute("Join_C"));
            this.LineBreak = el.Attribute("lb").Value;
            this.EastAsianWidth = el.Attribute("ea").Value;
            this.Upper = DataHelper.StringToBool((String)el.Attribute("Upper"));
            this.Lower = DataHelper.StringToBool((String)el.Attribute("Lower"));
            this.OtherUpper = DataHelper.StringToBool((String)el.Attribute("OUpper"));
            this.OtherLower = DataHelper.StringToBool((String)el.Attribute("OLower"));
            this.SimplCaseMapUpperCase = DataHelper.HexCodePointToInt32Null((String)el.Attribute("suc"));
            this.SimplCaseMapLowerCase = DataHelper.HexCodePointToInt32Null((String)el.Attribute("slc"));
            this.SimplCaseMapTitleCase = DataHelper.HexCodePointToInt32Null((String)el.Attribute("stc"));
            this.ComplexCaseMapUpperCase = DataHelper.StringToStringNull((String)el.Attribute("uc"));
            this.ComplexCaseMapLowerCase = DataHelper.StringToStringNull((String)el.Attribute("lc"));
            this.ComplexCaseMapTitleCase = DataHelper.StringToStringNull((String)el.Attribute("tc"));
            this.SimpleCaseFolding = DataHelper.HexCodePointToInt32Null((String)el.Attribute("scf"));
            this.CaseFolding = DataHelper.StringToStringNull((String)el.Attribute("cf"));
            this.CaseIgnorable = DataHelper.StringToBool((String)el.Attribute("CI"));
            this.Cased = DataHelper.StringToBool((String)el.Attribute("Cased"));
            this.ChangesWhenCasefolded = DataHelper.StringToBool((String)el.Attribute("CWCF"));
            this.ChangesWhenCasemapped = DataHelper.StringToBool((String)el.Attribute("CWCM"));
            this.ChangesWhenLowercased = DataHelper.StringToBool((String)el.Attribute("CWL"));
            this.ChangesWhenNfkcCasefolded = DataHelper.StringToBool((String)el.Attribute("CWKCF"));
            this.ChangesWhenTitlecased = DataHelper.StringToBool((String)el.Attribute("CWT"));
            this.ChangesWhenUppercased = DataHelper.StringToBool((String)el.Attribute("CWU"));
            this.NfkcCasefold = DataHelper.StringToStringNull((String)el.Attribute("NFKC_CF"));
            this.Script = el.Attribute("sc").Value;
            this.ScriptExtension = el.Attribute("scx").Value;
            this.Iso10646comment = DataHelper.StringToStringNull((String)el.Attribute("isc"));
            this.HangulSyllableType = el.Attribute("hst").Value;
            this.JamoShortName = DataHelper.StringToStringNull((String)el.Attribute("JSN"));
            this.IndicSyllabicCategory = el.Attribute("InSC").Value;
            this.IndicMatraCategory = el.Attribute("InMC").Value;
            this.IdStart = DataHelper.StringToBool((String)el.Attribute("IDS"));
            this.OtherIdStart = DataHelper.StringToBool((String)el.Attribute("OIDS"));
            this.XidStart = DataHelper.StringToBool((String)el.Attribute("XIDS"));
            this.IdContinue = DataHelper.StringToBool((String)el.Attribute("IDC"));
            this.OtherIdContinue = DataHelper.StringToBool((String)el.Attribute("OIDC"));
            this.XidContinue = DataHelper.StringToBool((String)el.Attribute("XIDC"));
            this.PatternSyntax = DataHelper.StringToBool((String)el.Attribute("Pat_Syn"));
            this.PatternWhiteSpace = DataHelper.StringToBool((String)el.Attribute("Pat_WS"));
            this.Dash = DataHelper.StringToBool((String)el.Attribute("Dash"));
            this.Hyphen = DataHelper.StringToBool((String)el.Attribute("Hyphen"));
            this.QuotationMark = DataHelper.StringToBool((String)el.Attribute("QMark"));
            this.TerminalPunctuation = DataHelper.StringToBool((String)el.Attribute("Term"));
            this.STerm = DataHelper.StringToBool((String)el.Attribute("STerm"));
            this.Diacritic = DataHelper.StringToBool((String)el.Attribute("Dia"));
            this.Extender = DataHelper.StringToBool((String)el.Attribute("Ext"));
            this.SoftDotted = DataHelper.StringToBool((String)el.Attribute("SD"));
            this.Alphabetic = DataHelper.StringToBool((String)el.Attribute("Alpha"));
            this.OtherAlphabetic = DataHelper.StringToBool((String)el.Attribute("OAlpha"));
            this.Math = DataHelper.StringToBool((String)el.Attribute("Math"));
            this.OtherMath = DataHelper.StringToBool((String)el.Attribute("OMath"));
            this.HexDigit = DataHelper.StringToBool((String)el.Attribute("Hex"));
            this.ASCIIHexDigit = DataHelper.StringToBool((String)el.Attribute("AHex"));
            this.DefaultIgnorableCodePoint = DataHelper.StringToBool((String)el.Attribute("DI"));
            this.OtherDefaultIgnorableCodePoint = DataHelper.StringToBool((String)el.Attribute("ODI"));
            this.LogicalOrderException = DataHelper.StringToBool((String)el.Attribute("LOE"));
            this.WhiteSpace = DataHelper.StringToBool((String)el.Attribute("WSpace"));
            this.GraphemeBase = DataHelper.StringToBool((String)el.Attribute("Gr_Base"));
            this.GraphemeExtend = DataHelper.StringToBool((String)el.Attribute("Gr_Ext"));
            this.OtherGraphemeExtend = DataHelper.StringToBool((String)el.Attribute("OGr_Ext"));
            this.GraphemeLink = DataHelper.StringToBool((String)el.Attribute("Gr_Link"));
            this.GraphemeClusterBreak = el.Attribute("GCB").Value;
            this.WordBreak = el.Attribute("WB").Value;
            this.SentenceBreak = el.Attribute("SB").Value;
            this.Ideographic = DataHelper.StringToBool((String)el.Attribute("Ideo"));
            this.UnifiedIdeograph = DataHelper.StringToBool((String)el.Attribute("UIdeo"));
            this.IDSBinaryOperator = DataHelper.StringToBool((String)el.Attribute("IDSB"));
            this.IDSTrinaryOperator = DataHelper.StringToBool((String)el.Attribute("IDST"));
            this.Radical = DataHelper.StringToBool((String)el.Attribute("Radical"));
            this.Deprecated = DataHelper.StringToBool((String)el.Attribute("Dep"));
            this.VariationSelector = DataHelper.StringToBool((String)el.Attribute("VS"));
            this.NoncharacterCodePoint = DataHelper.StringToBool((String)el.Attribute("NChar"));
            this.kAccountingNumeric = DataHelper.StringToInt32Null((String)el.Attribute("kAccountingNumeric"));
            this.kAlternateHanYu = DataHelper.StringToStringNull((String)el.Attribute("kAlternateHanYu"));
            this.kAlternateJEF = DataHelper.StringToStringNull((String)el.Attribute("kAlternateJEF"));
            this.kAlternateKangXi = DataHelper.StringToStringNull((String)el.Attribute("kAlternateKangXi"));
            this.kAlternateMorohashi = DataHelper.StringToStringNull((String)el.Attribute("kAlternateMorohashi"));
            this.kBigFive = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kBigFive"));
            this.kCCCII = DataHelper.HexStringToInt32Null((String)el.Attribute("kCCCII"), 6);
            this.kCNS1986 = DataHelper.StringToStringNull((String)el.Attribute("kCNS1986"));
            this.kCNS1992 = DataHelper.StringToStringNull((String)el.Attribute("kCNS1992"));
            this.kCangjie = DataHelper.StringToStringNull((String)el.Attribute("kCangjie"));
            this.kCantonese = DataHelper.StringToStringNull((String)el.Attribute("kCantonese"));
            this.kCheungBauer = DataHelper.StringToStringNull((String)el.Attribute("kCheungBauer"));
            this.kCheungBauerIndex = DataHelper.StringToStringNull((String)el.Attribute("kCheungBauerIndex"));
            this.kCihaiT = DataHelper.StringToStringNull((String)el.Attribute("kCihaiT"));
            this.kCompatibilityVariant = DataHelper.StringToStringNull((String)el.Attribute("kCompatibilityVariant"));
            this.kCowles = DataHelper.StringToStringNull((String)el.Attribute("kCowles"));
            this.kDaeJaweon = DataHelper.StringToStringNull((String)el.Attribute("kDaeJaweon"));
            this.kDefinition = DataHelper.StringToStringNull((String)el.Attribute("kDefinition"));
            this.kEACC = DataHelper.HexStringToInt32Null((String)el.Attribute("kEACC"), 6);
            this.kFenn = DataHelper.StringToStringNull((String)el.Attribute("kFenn"));
            this.kFennIndex = DataHelper.StringtoDecimalNull((String)el.Attribute("kFennIndex"));
            this.kFourCornerCode = DataHelper.StringtoDecimalNull((String)el.Attribute("kFourCornerCode"));
            this.kFrequency = DataHelper.StringToInt32Null((String)el.Attribute("kFrequency"));
            this.kGB0 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB0"));
            this.kGB1 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB1"));
            this.kGB3 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB3"));
            this.kGB5 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB5"));
            this.kGB7 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB7"));
            this.kGB8 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kGB8"));
            this.kGradeLevel = DataHelper.StringToInt32Null((String)el.Attribute("kGradeLevel"));
            this.kGSR = DataHelper.StringToStringNull((String)el.Attribute("kGSR"));
            this.kHangul = DataHelper.StringToStringNull((String)el.Attribute("kHangul"));
            this.kHanYu = DataHelper.StringtoDecimalNull((String)el.Attribute("kHanYu"));
            this.kHanyuPinlu = DataHelper.StringToStringNull((String)el.Attribute("kHanyuPinlu"));
            this.kHanyuPinyin = DataHelper.StringToStringNull((String)el.Attribute("kHanyuPinyin"));
            this.kHDZRadBreak = DataHelper.StringToStringNull((String)el.Attribute("kHDZRadBreak"));
            this.kHKGlyph = DataHelper.StringToInt32Null((String)el.Attribute("kHKGlyph"));
            this.kHKSCS = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kHKSCS"));
            this.kIBMJapan = DataHelper.StringToStringNull((String)el.Attribute("kIBMJapan"));
            this.kIICore = DataHelper.StringToStringNull((String)el.Attribute("kIICore"));
            this.kIRGDaeJaweon = DataHelper.StringToStringNull((String)el.Attribute("kIRGDaeJaweon"));
            this.kIRGDaiKanwaZiten = DataHelper.StringToStringNull((String)el.Attribute("kIRGDaiKanwaZiten"));
            this.kIRGHanyuDaZidian = DataHelper.StringToStringNull((String)el.Attribute("kIRGHanyuDaZidian"));
            this.kIRGKangXi = DataHelper.StringToStringNull((String)el.Attribute("kIRGKangXi"));
            this.kirgGSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_GSource"));
            this.KirgHSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_HSource"));
            this.KirgJSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_JSource"));
            this.KirgKPSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_KPSource"));
            this.KirgKSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_KSource"));
            this.KirgMSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_MSource"));
            this.KirgTSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_TSource"));
            this.KirgUSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_USource"));
            this.KirgVSource = DataHelper.StringToStringNull((String)el.Attribute("kIRG_VSource"));
            this.kJHJ = DataHelper.StringToStringNull((String)el.Attribute("kJHJ"));
            this.kJIS0213 = DataHelper.StringToStringNull((String)el.Attribute("kJIS0213"));
            this.kJapaneseKun = DataHelper.StringToStringNull((String)el.Attribute("kJapaneseKun"));
            this.kJapaneseOn = DataHelper.StringToStringNull((String)el.Attribute("kJapaneseOn"));
            this.kJis0 = DataHelper.StringToInt32Null((String)el.Attribute("kJis0"));
            this.kJis1 = DataHelper.StringToInt32Null((String)el.Attribute("kJis1"));
            this.kKPS0 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kKPS0"));
            this.kKPS1 = DataHelper.HexCodePointToInt32Null((String)el.Attribute("kKPS1"));
            this.kKSC0 = DataHelper.StringToInt32Null((String)el.Attribute("kKSC0"));
            this.kKSC1 = DataHelper.StringToInt32Null((String)el.Attribute("kKSC1"));
            this.kKangXi = DataHelper.StringToStringNull((String)el.Attribute("kKangXi"));
            this.kKarlgren = DataHelper.StringToStringNull((String)el.Attribute("kKarlgren"));
            this.kKorean = DataHelper.StringToStringNull((String)el.Attribute("kKorean"));
            this.kLau = DataHelper.StringToStringNull((String)el.Attribute("kLau"));
            this.kMainlandTelegraph = DataHelper.StringToInt32Null((String)el.Attribute("kMainlandTelegraph"));
            this.kMandarin = DataHelper.StringToStringNull((String)el.Attribute("kMandarin"));
            this.kMatthews = DataHelper.StringToStringNull((String)el.Attribute("kMatthews"));
            this.kMeyerWempe = DataHelper.StringToStringNull((String)el.Attribute("kMeyerWempe"));
            this.kMorohashi = DataHelper.StringToStringNull((String)el.Attribute("kMorohashi"));
            this.kNelson = DataHelper.StringToStringNull((String)el.Attribute("kNelson"));
            this.kOtherNumeric = DataHelper.StringToStringNull((String)el.Attribute("kOtherNumeric"));
            this.kPhonetic = DataHelper.StringToStringNull((String)el.Attribute("kPhonetic"));
            this.kPrimaryNumeric = DataHelper.StringToInt32Null((String)el.Attribute("kPrimaryNumeric"));
            this.kPseudoGB1 = DataHelper.StringToInt32Null((String)el.Attribute("kPseudoGB1"));
            this.kRSAdobeJapan1_6 = DataHelper.StringToStringNull((String)el.Attribute("kRSAdobe_Japan1_6"));
            this.kRSJapanese = DataHelper.StringtoDecimalNull((String)el.Attribute("kRSJapanese"));
            this.kRSKanWa = DataHelper.StringtoDecimalNull((String)el.Attribute("kRSKanWa"));
            this.kRSKangXi = DataHelper.StringtoDecimalNull((String)el.Attribute("kRSKangXi"));
            this.kRSKorean = DataHelper.StringtoDecimalNull((String)el.Attribute("kRSKorean"));
            this.kRSMerged = DataHelper.StringToStringNull((String)el.Attribute("kRSMerged"));
            this.kRSUnicode = DataHelper.StringToStringNull((String)el.Attribute("kRSUnicode"));
            this.kSBGY = DataHelper.StringToStringNull((String)el.Attribute("kSBGY"));
            this.kSemanticVariant = DataHelper.StringToStringNull((String)el.Attribute("kSemanticVariant"));
            this.kSimplifiedVariant = DataHelper.StringToStringNull((String)el.Attribute("kSimplifiedVariant"));
            this.kSpecializedSemanticVariant = DataHelper.StringToStringNull((String)el.Attribute("kSpecializedSemanticVariant"));
            this.kTaiwanTelegraph = DataHelper.StringToInt32Null((String)el.Attribute("kTaiwanTelegraph"));
            this.kTang = DataHelper.StringToStringNull((String)el.Attribute("kTang"));
            this.kTotalStrokes = DataHelper.StringToStringNull((String)el.Attribute("kTotalStrokes"));
            this.kTraditionalVariant = DataHelper.StringToStringNull((String)el.Attribute("kTraditionalVariant"));
            this.kVietnamese = DataHelper.StringToStringNull((String)el.Attribute("kVietnamese"));
            this.kXHC1983 = DataHelper.StringToStringNull((String)el.Attribute("kXHC1983"));
            this.kWubi = DataHelper.StringToStringNull((String)el.Attribute("kWubi"));
            this.kXerox = DataHelper.StringToStringNull((String)el.Attribute("kXerox"));
            this.kZVariant = DataHelper.StringToStringNull((String)el.Attribute("kZVariant"));
            #endregion
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
            ciDic["kAccountingNumeric"] = this.kAccountingNumeric;
            ciDic["kAlternateHanYu"] = this.kAlternateHanYu;
            ciDic["kAlternateJEF"] = this.kAlternateJEF;
            ciDic["kAlternateKangXi"] = this.kAlternateKangXi;
            ciDic["kAlternateMorohashi"] = this.kAlternateMorohashi;
            ciDic["kBigFive"] = this.kBigFive;
            ciDic["kCCCII"] = this.kCCCII;
            ciDic["kCNS1986"] = this.kCNS1986;
            ciDic["kCNS1992"] = this.kCNS1992;
            ciDic["kCangjie"] = this.kCangjie;
            ciDic["kCantonese"] = this.kCantonese;
            ciDic["kCheungBauer"] = this.kCheungBauer;
            ciDic["kCheungBauerIndex"] = this.kCheungBauerIndex;
            ciDic["kCihaiT"] = this.kCihaiT;
            ciDic["kCompatibilityVariant"] = this.kCompatibilityVariant;
            ciDic["kCowles"] = this.kCowles;
            ciDic["kDaeJaweon"] = this.kDaeJaweon;
            ciDic["kDefinition"] = this.kDefinition;
            ciDic["kEACC"] = this.kEACC;
            ciDic["kFenn"] = this.kFenn;
            ciDic["kFennIndex"] = this.kFennIndex;
            ciDic["kFourCornerCode"] = this.kFourCornerCode;
            ciDic["kFrequency"] = this.kFrequency;
            ciDic["kGB0"] = this.kGB0;
            ciDic["kGB1"] = this.kGB1;
            ciDic["kGB3"] = this.kGB3;
            ciDic["kGB5"] = this.kGB5;
            ciDic["kGB7"] = this.kGB7;
            ciDic["kGB8"] = this.kGB8;
            ciDic["kGradeLevel"] = this.kGradeLevel;
            ciDic["kGSR"] = this.kGSR;
            ciDic["kHangul"] = this.kHangul;
            ciDic["kHanYu"] = this.kHanYu;
            ciDic["kHanyuPinlu"] = this.kHanyuPinlu;
            ciDic["kHanyuPinyin"] = this.kHanyuPinyin;
            ciDic["kHDZRadBreak"] = this.kHDZRadBreak;
            ciDic["kHKGlyph"] = this.kHKGlyph;
            ciDic["kHKSCS"] = this.kHKSCS;
            ciDic["kIBMJapan"] = this.kIBMJapan;
            ciDic["kIICore"] = this.kIICore;
            ciDic["kIRGDaeJaweon"] = this.kIRGDaeJaweon;
            ciDic["kIRGDaiKanwaZiten"] = this.kIRGDaiKanwaZiten;
            ciDic["kIRGHanyuDaZidian"] = this.kIRGHanyuDaZidian;
            ciDic["kIRGKangXi"] = this.kIRGKangXi;
            ciDic["kIRG_GSource"] = this.kirgGSource;
            ciDic["kIRG_HSource"] = this.KirgHSource;
            ciDic["kIRG_JSource"] = this.KirgJSource;
            ciDic["kIRG_KPSource"] = this.KirgKPSource;
            ciDic["kIRG_KSource"] = this.KirgKSource;
            ciDic["kIRG_MSource"] = this.KirgMSource;
            ciDic["kIRG_TSource"] = this.KirgTSource;
            ciDic["kIRG_USource"] = this.KirgUSource;
            ciDic["kIRG_VSource"] = this.KirgVSource;
            ciDic["kJHJ"] = this.kJHJ;
            ciDic["kJIS0213"] = this.kJIS0213;
            ciDic["kJapaneseKun"] = this.kJapaneseKun;
            ciDic["kJapaneseOn"] = this.kJapaneseOn;
            ciDic["kJis0"] = this.kJis0;
            ciDic["kJis1"] = this.kJis1;
            ciDic["kKPS0"] = this.kKPS0;
            ciDic["kKPS1"] = this.kKPS1;
            ciDic["kKSC0"] = this.kKSC0;
            ciDic["kKSC1"] = this.kKSC1;
            ciDic["kKangXi"] = this.kKangXi;
            ciDic["kKarlgren"] = this.kKarlgren;
            ciDic["kKorean"] = this.kKorean;
            ciDic["kLau"] = this.kLau;
            ciDic["kMainlandTelegraph"] = this.kMainlandTelegraph;
            ciDic["kMandarin"] = this.kMandarin;
            ciDic["kMatthews"] = this.kMatthews;
            ciDic["kMeyerWempe"] = this.kMeyerWempe;
            ciDic["kMorohashi"] = this.kMorohashi;
            ciDic["kNelson"] = this.kNelson;
            ciDic["kOtherNumeric"] = this.kOtherNumeric;
            ciDic["kPhonetic"] = this.kPhonetic;
            ciDic["kPrimaryNumeric"] = this.kPrimaryNumeric;
            ciDic["kPseudoGB1"] = this.kPseudoGB1;
            ciDic["kRSAdobe_Japan1_6"] = this.kRSAdobeJapan1_6;
            ciDic["kRSJapanese"] = this.kRSJapanese;
            ciDic["kRSKanWa"] = this.kRSKanWa;
            ciDic["kRSKangXi"] = this.kRSKangXi;
            ciDic["kRSKorean"] = this.kRSKorean;
            ciDic["kRSMerged"] = this.kRSMerged;
            ciDic["kRSUnicode"] = this.kRSUnicode;
            ciDic["kSBGY"] = this.kSBGY;
            ciDic["kSemanticVariant"] = this.kSemanticVariant;
            ciDic["kSimplifiedVariant"] = this.kSimplifiedVariant;
            ciDic["kSpecializedSemanticVariant"] = this.kSpecializedSemanticVariant;
            ciDic["kTaiwanTelegraph"] = this.kTaiwanTelegraph;
            ciDic["kTang"] = this.kTang;
            ciDic["kTotalStrokes"] = this.kTotalStrokes;
            ciDic["kTraditionalVariant"] = this.kTraditionalVariant;
            ciDic["kVietnamese"] = this.kVietnamese;
            ciDic["kXHC1983"] = this.kXHC1983;
            ciDic["kWubi"] = this.kWubi;
            ciDic["kXerox"] = this.kXerox;
            ciDic["kZVariant"] = this.kZVariant;


            ciDic["elementName"] = this.ElementName;
            return ciDic;
        }
        #endregion
        #endregion

    }
}
