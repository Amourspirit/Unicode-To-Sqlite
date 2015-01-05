using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCD.DataCommon;
using System.Data.SQLite;

namespace UCD.Planes
{
    public class PlanesTable : TableBase
    {
        internal static String TableName = "planes";
        public PlanesTable(string dbFile) : base (dbFile)
        {

        }

         /// <summary>
        /// Creates Blocks table in database with all the necessary columns.
        /// Table is droped if it exist and then planes tables create containing planes data.
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
                    
                    String sql = this.PlanesSQL();
                    sh.Execute(sql);

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
        /// Drops Blocks table from database
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

        private String PlanesSQL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DROP INDEX IF EXISTS planes_cps;");
            sb.AppendLine(String.Format("Drop Table IF EXISTS {0};", TableName));

            sb.AppendLine(String.Format("CREATE TABLE {0} (", TableName));
            sb.AppendLine("name   TEXT(255) PRIMARY KEY,");
            sb.AppendLine("first  INTEGER(7),");
            sb.AppendLine("last   INTEGER(7)");
            sb.AppendLine(");");
            sb.AppendLine(String.Format("CREATE INDEX planes_cps ON {0} ( first, last );", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Basic Multilingual Plane', 0, 65535);",TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Supplementary Multilingual Plane', 65536, 131071);", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Supplementary Ideographic Plane', 131072, 196607);", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Tertiary Ideographic Plane', 196608, 262143);", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Supplementary Special-purpose Plane', 917504, 983039);", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Supplementary Private Use Area - A', 983040, 1048575);", TableName));
            sb.AppendLine(String.Format("INSERT INTO {0} (name, first, last) VALUES ('Supplementary Private Use Area - B', 1048576, 1114111);", TableName));
            return sb.ToString();

        }
    }

    
}
