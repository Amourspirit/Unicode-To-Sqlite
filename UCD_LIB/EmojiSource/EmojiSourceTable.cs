using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD.EmojiSource
{
    /// <summary>
    /// Drops and/or Creates table for UCD entries EmojiSource
    /// </summary>
    public class EmojiSourceTable : TableBase
    {
         internal static String TableName = "emojiSource";

         public EmojiSourceTable(string dbFile) : base(dbFile) { }

       
        /// <summary>
         /// Creates EmojiSource table in database with all the necessary columns.
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
                    tb.Columns.Add(new SQLiteColumn("unicode"));
                    tb.Columns.Add(new SQLiteColumn("docomo", ColType.Integer,false, false, false,""));
                    tb.Columns.Add(new SQLiteColumn("kddi", ColType.Integer, false, false, false, ""));
                    tb.Columns.Add(new SQLiteColumn("softbank", ColType.Integer, false, false, false, ""));
      
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
        /// Drops EmojiSource table from database
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
