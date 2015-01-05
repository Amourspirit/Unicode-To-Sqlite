using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UCD.Repertoire
{
    /// <summary>
    /// Drops and/or Creates Tables in a database for UCD entries Repertoire and NameAlias
    /// </summary>
    public class RepertoireTable : UCD.DataCommon.TableBase
    {
        internal static bool MakeCpPrimaryKey = true;
        public const string RepertoireTableName = "repertoire";
        public const string NameAliasTableName = "namealias";
        /// <summary>
        /// constructor for class
        /// </summary>
        /// <param name="dbFile">The full path to the sqlite database to use of operations.</param>
        public RepertoireTable(string dbFile) : base(dbFile) { }
        

        /// <summary>
        /// Drops all Repertoire related tables from the database.
        /// </summary>
        public void DropTables() 
        {
            this.DropNameAliasTable();
            this.DropRepertoireTable();

        }

        /// <summary>
        /// Drops Repertoire table from the database.
        /// </summary>
        public void DropRepertoireTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    sh.DropTable(RepertoireTable.RepertoireTableName);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating table: " + RepertoireTableName, e);
                throw ex;
            }
        }

        /// <summary>
        /// Drops namealias table from the database.
        /// </summary>
        public void DropNameAliasTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    sh.DropTable(RepertoireTable.NameAliasTableName);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating table: " + NameAliasTableName , e);
                throw ex;
            }
        }

        /// <summary>
        /// Creates tables in database for Repertoire and NameAlias with all the necessary columns.
        /// Tables are only created if they do not exist.
        /// </summary>
        public void CreateTables() 
        {
            this.CreateRepertoireTable();
            this.CreateNameAliasTable();
        }

        /// <summary>
        /// Creates Repertoire table in database with all the necessary columns.
        /// Table is only created if it does not exist.
        /// </summary>
        public void CreateRepertoireTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    SQLiteTable tb = new SQLiteTable(RepertoireTable.RepertoireTableName);
                    #region Table columns
                    if (RepertoireTable.MakeCpPrimaryKey == true)
                    {
                        tb.Columns.Add(new SQLiteColumn("cp", ColType.Integer, true, false, true, "0"));
                    }
                    else
                    {
                        tb.Columns.Add(new SQLiteColumn("id", ColType.Integer, true, true, true, "0"));
                        tb.Columns.Add(new SQLiteColumn("cp",ColType.Integer));
                    }

                    tb.Columns.Add(new SQLiteColumn("first_cp", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("last_cp", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("age", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("na"));
                    tb.Columns.Add(new SQLiteColumn("na1"));
                    tb.Columns.Add(new SQLiteColumn("blk"));
                    tb.Columns.Add(new SQLiteColumn("gc"));
                    tb.Columns.Add(new SQLiteColumn("ccc", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("bc"));
                    tb.Columns.Add(new SQLiteColumn("Bidi_M", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("bmg", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Bidi_C", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("bpt"));
                    tb.Columns.Add(new SQLiteColumn("bpb"));
                    tb.Columns.Add(new SQLiteColumn("dt"));
                    tb.Columns.Add(new SQLiteColumn("dm"));
                    tb.Columns.Add(new SQLiteColumn("CE", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Comp_Ex", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("NFC_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFD_QC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("NFKC_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFKD_QC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XO_NFC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XO_NFD", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XO_NFKC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XO_NFKD", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("FC_NFKC"));
                    tb.Columns.Add(new SQLiteColumn("nt"));
                    tb.Columns.Add(new SQLiteColumn("nv"));
                    tb.Columns.Add(new SQLiteColumn("jt"));
                    tb.Columns.Add(new SQLiteColumn("jg"));
                    tb.Columns.Add(new SQLiteColumn("Join_C", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("lb"));
                    tb.Columns.Add(new SQLiteColumn("ea"));
                    tb.Columns.Add(new SQLiteColumn("Upper", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Lower", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OUpper", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OLower", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("suc", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("slc", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("stc", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("uc"));
                    tb.Columns.Add(new SQLiteColumn("lc"));
                    tb.Columns.Add(new SQLiteColumn("tc"));
                    tb.Columns.Add(new SQLiteColumn("scf", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("cf"));
                    tb.Columns.Add(new SQLiteColumn("CI", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Cased", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWCF", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWCM", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWL", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWKCF", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWT", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("CWU", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("NFKC_CF"));
                    tb.Columns.Add(new SQLiteColumn("sc"));
                    tb.Columns.Add(new SQLiteColumn("scx"));
                    tb.Columns.Add(new SQLiteColumn("isc"));
                    tb.Columns.Add(new SQLiteColumn("hst"));
                    tb.Columns.Add(new SQLiteColumn("JSN"));
                    tb.Columns.Add(new SQLiteColumn("InSC"));
                    tb.Columns.Add(new SQLiteColumn("InMC"));
                    tb.Columns.Add(new SQLiteColumn("IDS", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OIDS", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XIDS", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("IDC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OIDC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("XIDC", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Pat_Syn", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Pat_WS", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Dash", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Hyphen", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("QMark", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Term", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("STerm", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Dia", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Ext", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("SD", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Alpha", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OAlpha", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Math", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OMath", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Hex", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("AHex", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("DI", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("ODI", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("LOE", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("WSpace", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Gr_Base", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Gr_Ext", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("OGr_Ext", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Gr_Link", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("GCB"));
                    tb.Columns.Add(new SQLiteColumn("WB"));
                    tb.Columns.Add(new SQLiteColumn("SB"));
                    tb.Columns.Add(new SQLiteColumn("Ideo", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("UIdeo", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("IDSB", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("IDST", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Radical", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("Dep", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("VS", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("NChar", ColType.Integer, false, false, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("kAccountingNumeric", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kAlternateHanYu"));
                    tb.Columns.Add(new SQLiteColumn("kAlternateJEF"));
                    tb.Columns.Add(new SQLiteColumn("kAlternateKangXi"));
                    tb.Columns.Add(new SQLiteColumn("kAlternateMorohashi"));
                    tb.Columns.Add(new SQLiteColumn("kBigFive", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kCCCII", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kCNS1986"));
                    tb.Columns.Add(new SQLiteColumn("kCNS1992"));
                    tb.Columns.Add(new SQLiteColumn("kCangjie"));
                    tb.Columns.Add(new SQLiteColumn("kCantonese"));
                    tb.Columns.Add(new SQLiteColumn("kCheungBauer"));
                    tb.Columns.Add(new SQLiteColumn("kCheungBauerIndex"));
                    tb.Columns.Add(new SQLiteColumn("kCihaiT"));
                    tb.Columns.Add(new SQLiteColumn("kCompatibilityVariant"));
                    tb.Columns.Add(new SQLiteColumn("kCowles"));
                    tb.Columns.Add(new SQLiteColumn("kDaeJaweon"));
                    tb.Columns.Add(new SQLiteColumn("kDefinition"));
                    tb.Columns.Add(new SQLiteColumn("kEACC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kFenn"));
                    tb.Columns.Add(new SQLiteColumn("kFennIndex", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kFourCornerCode", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kFrequency", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB0", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB1", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB3", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB5", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB7", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGB8", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGradeLevel", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kGSR"));
                    tb.Columns.Add(new SQLiteColumn("kHangul"));
                    tb.Columns.Add(new SQLiteColumn("kHanYu", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kHanyuPinlu"));
                    tb.Columns.Add(new SQLiteColumn("kHanyuPinyin"));
                    tb.Columns.Add(new SQLiteColumn("kHDZRadBreak"));
                    tb.Columns.Add(new SQLiteColumn("kHKGlyph", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kHKSCS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kIBMJapan"));
                    tb.Columns.Add(new SQLiteColumn("kIICore"));
                    tb.Columns.Add(new SQLiteColumn("kIRGDaeJaweon"));
                    tb.Columns.Add(new SQLiteColumn("kIRGDaiKanwaZiten"));
                    tb.Columns.Add(new SQLiteColumn("kIRGHanyuDaZidian"));
                    tb.Columns.Add(new SQLiteColumn("kIRGKangXi"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_GSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_HSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_JSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_KPSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_KSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_MSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_TSource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_USource"));
                    tb.Columns.Add(new SQLiteColumn("kIRG_VSource"));
                    tb.Columns.Add(new SQLiteColumn("kJHJ"));
                    tb.Columns.Add(new SQLiteColumn("kJIS0213"));
                    tb.Columns.Add(new SQLiteColumn("kJapaneseKun"));
                    tb.Columns.Add(new SQLiteColumn("kJapaneseOn"));
                    tb.Columns.Add(new SQLiteColumn("kJis0", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kJis1", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kKPS0", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kKPS1", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kKSC0", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kKSC1", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kKangXi"));
                    tb.Columns.Add(new SQLiteColumn("kKarlgren"));
                    tb.Columns.Add(new SQLiteColumn("kKorean"));
                    tb.Columns.Add(new SQLiteColumn("kLau"));
                    tb.Columns.Add(new SQLiteColumn("kMainlandTelegraph", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kMandarin"));
                    tb.Columns.Add(new SQLiteColumn("kMatthews"));
                    tb.Columns.Add(new SQLiteColumn("kMeyerWempe"));
                    tb.Columns.Add(new SQLiteColumn("kMorohashi"));
                    tb.Columns.Add(new SQLiteColumn("kNelson"));
                    tb.Columns.Add(new SQLiteColumn("kOtherNumeric"));
                    tb.Columns.Add(new SQLiteColumn("kPhonetic"));
                    tb.Columns.Add(new SQLiteColumn("kPrimaryNumeric", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kPseudoGB1", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kRSAdobe_Japan1_6"));
                    tb.Columns.Add(new SQLiteColumn("kRSJapanese", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kRSKanWa", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kRSKangXi", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kRSKorean", ColType.Decimal));
                    tb.Columns.Add(new SQLiteColumn("kRSMerged"));
                    tb.Columns.Add(new SQLiteColumn("kRSUnicode"));
                    tb.Columns.Add(new SQLiteColumn("kSBGY"));
                    tb.Columns.Add(new SQLiteColumn("kSemanticVariant"));
                    tb.Columns.Add(new SQLiteColumn("kSimplifiedVariant"));
                    tb.Columns.Add(new SQLiteColumn("kSpecializedSemanticVariant"));
                    tb.Columns.Add(new SQLiteColumn("kTaiwanTelegraph", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("kTang"));
                    tb.Columns.Add(new SQLiteColumn("kTotalStrokes"));
                    tb.Columns.Add(new SQLiteColumn("kTraditionalVariant"));
                    tb.Columns.Add(new SQLiteColumn("kVietnamese"));
                    tb.Columns.Add(new SQLiteColumn("kXHC1983"));
                    tb.Columns.Add(new SQLiteColumn("kWubi"));
                    tb.Columns.Add(new SQLiteColumn("kXerox"));
                    tb.Columns.Add(new SQLiteColumn("kZVariant"));

                   
                    tb.Columns.Add(new SQLiteColumn("elementName"));
                    #endregion
                    sh.CreateTable(tb);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating table: " + RepertoireTableName, e);
                throw ex;
            }
           
            
         }
        
        /// <summary>
        ///  Creates NameAlias table in database with all the necessary columns.
        ///  Table is only created if it does not exist.
        /// </summary>
        public void CreateNameAliasTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    SQLiteTable tb = new SQLiteTable(RepertoireTable.NameAliasTableName);
                    #region Table columns
                    tb.Columns.Add(new SQLiteColumn("id", ColType.Integer, true, true, true, "0"));
                    if (RepertoireTable.MakeCpPrimaryKey == true)
                    {
                        tb.Columns.Add(new SQLiteColumn("cp", ColType.Integer));
                    }
                    else
                    {
                        tb.Columns.Add(new SQLiteColumn("repertoireId", ColType.Integer, false, false, true, ""));
                    }
                    
                    tb.Columns.Add(new SQLiteColumn("alias"));
                    tb.Columns.Add(new SQLiteColumn("type"));
                    #endregion
                    sh.CreateTable(tb);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating table: " + NameAliasTableName, e);
                throw ex;
            }


        }
    }
}
