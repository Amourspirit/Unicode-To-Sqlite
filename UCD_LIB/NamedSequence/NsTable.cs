using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace UCD.NamedSequence
{
    /// <summary>
    /// Drops and/or Creates table for UCD entries NamedSequences
    /// </summary>
    /// <remarks>
    /// UCD documentation states that there can be elements named-sequences and
    /// provisional-named-sequences Children of UCD element. It appears there are no
    /// provisional-named-sequences in ucd.all.flat.xml. This class will serve as both
    /// cases. The <see cref="NsItem.ParentElementName"/> will be used to store the element
    /// name on the database.
    /// </remarks>
    public class NsTable : UCD.DataCommon.TableBase
    {
        internal static String TableName = "namedSequences";

        public NsTable(string dbFile) : base(dbFile) { }

        /// <summary>
        /// Creates NamedSequences table in database with all the necessary columns.
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
                    tb.Columns.Add(new SQLiteColumn("cps"));
                    tb.Columns.Add(new SQLiteColumn("name"));
                    tb.Columns.Add(new SQLiteColumn("parentElementName", ColType.Text, false, false, true, ""));


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
        /// Drops NamedSequences table from database
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
