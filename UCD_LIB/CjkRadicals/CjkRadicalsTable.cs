using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD.CjkRadicals
{
    /// <summary>
    /// Drops and/or Creates table for UCD entries CjkRadicals
    /// </summary>
    public class CjkRadicalsTable : TableBase
    {
        internal static String TableName = "cjkRadicals";
        public CjkRadicalsTable(String dbFile) : base(dbFile) { }

        /// <summary>
        /// Creates CjkRadicals table in database with all the necessary columns.
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
                    tb.Columns.Add(new SQLiteColumn("number", ColType.Integer, false, false, true, ""));
                    tb.Columns.Add(new SQLiteColumn("radical", ColType.Integer, false, false, true, ""));
                    tb.Columns.Add(new SQLiteColumn("ideograph", ColType.Integer));
                    sh.CreateTable(tb);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Exception ex = new Exception("An error occured attempting to creating table: " + TableName, e);
                throw ex;
            }


        }
        /// <summary>
        /// Drops CjkRadicals table from database
        /// </summary>
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
                Exception ex = new Exception("An error occured attempting to drop table: " + TableName, e);
                throw ex;
            }
        }
    }
}
