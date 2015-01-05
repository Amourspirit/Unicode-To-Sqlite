using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;
namespace UCD.StandardizedVariants
{
    public class SvTable : TableBase
    {
        internal static String TableName = "standardizedVariants";

        public SvTable(String dbFile) : base(dbFile) { }

        /// <summary>
        /// Creates Repertoire table in database with all the necessary columns.
        /// Table is only created if it does not exist.
        /// </summary>
        public void CreateTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    SQLiteTable tb = new SQLiteTable(TableName);

                    tb.Columns.Add(new SQLiteColumn("id", ColType.Integer, true, true, true, "0"));
                    tb.Columns.Add(new SQLiteColumn("cps", ColType.Text, false, false, true, ""));
                    tb.Columns.Add(new SQLiteColumn("desc", ColType.Text, false, false, true, ""));
                    tb.Columns.Add(new SQLiteColumn("'when'")); // single quotes as when is a reserved word

                    sh.CreateTable(tb);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating repertoire table!", e);
                throw ex;
            }


        }

        public void DropTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                    cmd.Connection = conn;
                    conn.Open();
                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    sh.DropTable(TableName);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating " + TableName, e);
                throw ex;
            }
        }

    }
}
