using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UCD.DataCommon
{
    public abstract class TableBase
    {
        public TableBase(string dbFile)
        {
            if (String.IsNullOrWhiteSpace(dbFile))
            {
                throw new ArgumentNullException("dbFile");
            }
            this.DatabaseFile = dbFile;
        }

        private string DatabaseFile = "";
        protected string DataSource
        {
            get
            {
                return string.Format("data source={0}", DatabaseFile);
            }
        }

        #region TestConnection
        /// <summary>
        /// Test the current database connection to the database file passed into the constructor.
        /// </summary>
        /// <returns></returns>
        public virtual bool TestConnection()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(this.DataSource);
                conn.Open();
                conn.Clone();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
