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
                    tb.Columns.Add(new SQLiteColumn("Bidi_M", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("bmg"));
                    tb.Columns.Add(new SQLiteColumn("Bidi_C", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("bpt"));
                    tb.Columns.Add(new SQLiteColumn("bpb"));
                    tb.Columns.Add(new SQLiteColumn("dt"));
                    tb.Columns.Add(new SQLiteColumn("dm"));
                    tb.Columns.Add(new SQLiteColumn("CE", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Comp_Ex", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFC_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFD_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFKC_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFKD_QC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XO_NFC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XO_NFD", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XO_NFKC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XO_NFKD", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("FC_NFKC"));
                    tb.Columns.Add(new SQLiteColumn("nt"));
                    tb.Columns.Add(new SQLiteColumn("nv"));
                    tb.Columns.Add(new SQLiteColumn("jt"));
                    tb.Columns.Add(new SQLiteColumn("jg"));
                    tb.Columns.Add(new SQLiteColumn("Join_C", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("lb"));
                    tb.Columns.Add(new SQLiteColumn("ea"));
                    tb.Columns.Add(new SQLiteColumn("Upper", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Lower", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OUpper", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OLower", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("suc"));
                    tb.Columns.Add(new SQLiteColumn("slc"));
                    tb.Columns.Add(new SQLiteColumn("stc"));
                    tb.Columns.Add(new SQLiteColumn("uc"));
                    tb.Columns.Add(new SQLiteColumn("lc"));
                    tb.Columns.Add(new SQLiteColumn("tc"));
                    tb.Columns.Add(new SQLiteColumn("scf"));
                    tb.Columns.Add(new SQLiteColumn("cf"));
                    tb.Columns.Add(new SQLiteColumn("CI", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Cased", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWCF", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWCM", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWL", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWKCF", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWT", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("CWU", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NFKC_CF"));
                    tb.Columns.Add(new SQLiteColumn("sc"));
                    tb.Columns.Add(new SQLiteColumn("scx"));
                    tb.Columns.Add(new SQLiteColumn("isc"));
                    tb.Columns.Add(new SQLiteColumn("hst"));
                    tb.Columns.Add(new SQLiteColumn("JSN"));
                    tb.Columns.Add(new SQLiteColumn("InSC"));
                    tb.Columns.Add(new SQLiteColumn("InMC"));
                    tb.Columns.Add(new SQLiteColumn("IDS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OIDS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XIDS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("IDC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OIDC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("XIDC", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Pat_Syn", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Pat_WS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Dash", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Hyphen", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("QMark", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Term", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("STerm", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Dia", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Ext", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("SD", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Alpha", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OAlpha", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Math", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OMath", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Hex", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("AHex", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("DI", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("ODI", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("LOE", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("WSpace", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Gr_Base", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Gr_Ext", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("OGr_Ext", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Gr_Link", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("GCB"));
                    tb.Columns.Add(new SQLiteColumn("WB"));
                    tb.Columns.Add(new SQLiteColumn("SB"));
                    tb.Columns.Add(new SQLiteColumn("Ideo", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("UIdeo", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("IDSB", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("IDST", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Radical", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("Dep", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("VS", ColType.Integer));
                    tb.Columns.Add(new SQLiteColumn("NChar", ColType.Integer));
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
