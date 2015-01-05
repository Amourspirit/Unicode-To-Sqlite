using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UCD.Repertoire;
using UCD.Block;
using UCD.Args;
using System.Data.SQLite;
using UCD.DataCommon;

namespace UCD
{
    #region Delegate Methods
    public delegate void ReadElementHandler(object sender, RepertoireArgs args);
    public delegate void ReadElementNullHandler(object sender, NamedArgs args);
    public delegate void FinishedHandler(object sender, FinishedArgs args);
    public delegate void ReadBlockElementHandler(object sender, BlockItemArgs args);
    public delegate void ReadNamedSequenceElementHandler(object sender, NamedSequenceArgs args);
    public delegate void NormalizationCorrectionsElementHandler(object sender, NormalizationCorrectionsArgs args);
    public delegate void StandardizedVariantsElementHandler(object sender, StandardizedVariantsArgs args);
    public delegate void CjkRadicalsElementHandler(object sender, CjkRadicalsArgs args);
    public delegate void EmojiSourceElementHandler(object sender, EmojiSourceArgs args);
    #endregion

    public class XmlToDb
    {
        //internal static int MaxCharValue = 50; // 65535; // 0xFFFF The maximum char value to parse and enter into the database.
        #region Constructors
        /// <summary>
        /// Constructs a new instance of the class
        /// </summary>
        /// <param name="dbFile">The full path to the SqLite Database file to write xml values into</param>
        public XmlToDb(string dbFile) : this(dbFile, 65535)  { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbFile"></param>
        /// <param name="dbFile">The full path to the SqLite Database file to write xml values into</param>
        /// <param name="Maxchars">
        /// The max number of repertoire values to read and write into the database.
        /// A common number is 65535 and is the default
        /// </param>
        public XmlToDb(string dbFile, int Maxchars)
        {
            this.DatabaseFile = dbFile;
            this.MaxCharValue = Maxchars;
            this.ProcessRepertoireXml = true;
            this.ProcessBlocksXml = true;
            this.ProcessNamedSequences = true;
            this.ProcessNormalizationCorrections = true;
            this.ProcesStandardizedVariants = true;
            this.ProcessCjkRadicals = true;
            this.ProcessEmojiSource = true;
        }
        #endregion
        #region Properties
        /// <summary>
        /// The maximum number of element to read from xml and write to database.
        /// Default value is 65535
        /// </summary>
        public int MaxCharValue { get; set; }
        /// <summary>
        /// If true then Repertoire items will be processed and written into Database.
        /// Default is true.
        /// </summary>
        /// <remarks>
        /// <typeparamref name="ProcessRepertoireXml"/> is affected by <typeparamref name="MaxCharValue"/>
        /// </remarks>
        public bool ProcessRepertoireXml { get; set; }
        /// <summary>
        /// If true then Block items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcessBlocksXml { get; set; }
        /// <summary>
        /// If true then Named Sequences items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcessNamedSequences { get; set; }

        /// <summary>
        /// If true then Normalization Corrections items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcessNormalizationCorrections { get; set; }

        /// <summary>
        /// If true then Standardized Variants items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcesStandardizedVariants { get; set; }

        /// <summary>
        /// If true then Cjk Radicals items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcessCjkRadicals { get; set; }
        /// <summary>
        /// If true then Emoji Source items will be processed and written into the database.
        /// Default is true.
        /// </summary>
        public bool ProcessEmojiSource { get; set; }
        #endregion
        #region Data Connection
        private string DatabaseFile = "";
        private string DataSource
        {
            get
            {
                return string.Format("data source={0}", DatabaseFile);
            }
        }

        private SQLiteConnection _conn;

        private SQLiteConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                   _conn = new SQLiteConnection(this.DataSource); 
                }
                return _conn; 
            }
        }

        private SQLiteCommand _command;

        private SQLiteCommand Command
        {
            get 
            {
                if (this._command == null)
                {
                    this._command = new SQLiteCommand(this.Conn);
                }
                return this._command; 
            }

        }

        #endregion

        #region Event Handlers
        public event ReadElementHandler ReadElement;
        public event ReadElementNullHandler ReadElementNull;
        public event EventHandler XmlRead;
        public event FinishedHandler Finished;
        public event ReadBlockElementHandler ReadBlockElement;
        public event ReadNamedSequenceElementHandler ReadNamedSequenceElement;
        public event StandardizedVariantsElementHandler ReadStandardizedVariantsElement;
        public event NormalizationCorrectionsElementHandler ReadNormalizationCorrectionsElement;
        public event CjkRadicalsElementHandler ReadCjkRadicalsElement;
        public event EmojiSourceElementHandler ReadEmojiSourceElement;
        #endregion
        #region OnMethods
        protected void OnReadElementNull(string ElementName)
        {
            ReadElementNullHandler handler = ReadElementNull;
            
            if (null != handler)
            {
                NamedArgs Args = new NamedArgs(ElementName);
                handler(this, Args);
            }
            
        }
        protected void OnReadElement(CharItem itm)
        {
            if (ReadElement != null)
            {
                 RepertoireArgs Args = new RepertoireArgs(itm);
                 ReadElement(this, Args);
            }
           
        }
        protected void OnFinished(int FinishedCount)
        {
            if (Finished != null)
            {
                FinishedArgs Args = new FinishedArgs(FinishedCount);
                Finished(this, Args);
            }

        }
        protected void OnXmlRead()
        {
            EventHandler handler = XmlRead;
            if (null != handler) handler(this, EventArgs.Empty);
        }
        #region On BLOCK
        protected void OnReadBlockElement(BlockItem itm)
        {
            
            if (ReadBlockElement != null)
	        {
		        BlockItemArgs args = new BlockItemArgs(itm);
                ReadBlockElement(this, args);
	        }
        }
        #endregion
        #region On Named Sequence
        protected void OnReadNamedSequence(UCD.NamedSequence.NsItem itm)
        {
            if (ReadNamedSequenceElement != null)
            {
                NamedSequenceArgs args = new NamedSequenceArgs(itm);
                ReadNamedSequenceElement(this, args);
            }
        }
        #endregion
        #region On Standardized Variants
        protected void OnReadStandardizedVariantsElement(UCD.StandardizedVariants.SvItem itm)
        {
            if (ReadStandardizedVariantsElement != null)
            {
                StandardizedVariantsArgs args = new StandardizedVariantsArgs(itm);
                ReadStandardizedVariantsElement(this, args);
            }
        }
        #endregion
        #region On Normalization Corrections
        protected void OnReadNormalizationCorrectionsElement(UCD.NormalizationCorrections.NcItem itm)
        {
            if (ReadNormalizationCorrectionsElement != null)
            {
                NormalizationCorrectionsArgs args = new NormalizationCorrectionsArgs(itm);
                ReadNormalizationCorrectionsElement(this, args);
            }

        }
        #endregion
        #region On Cjk Radicals
        protected void OnCjkRadicalsElement(UCD.CjkRadicals.CjkRadicalsItem itm)
        {
            if (ReadCjkRadicalsElement != null)
            {
                CjkRadicalsArgs args = new CjkRadicalsArgs(itm);
                ReadCjkRadicalsElement(this, args);
            }

        }
        #endregion
        #region On EmojiSource
        protected void OnEmojiSourceElement(UCD.EmojiSource.EmojiSourceItem itm)
        {
            if (ReadEmojiSourceElement != null)
            {
                EmojiSourceArgs args = new EmojiSourceArgs(itm);
                ReadEmojiSourceElement(this, args);
            }
        }
        #endregion
        #endregion
        public void ProcessXml(string docPath)
        {
           
            XDocument doc = XDocument.Load(docPath);
            XNamespace UcdNS = "http://www.unicode.org/ns/2003/ucd/1.0";
            this.Conn.Open();
            int iCount = 0;
            #region Process Repertoir
            if (this.ProcessRepertoireXml == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "repertoire").Elements())
                {

                    int iCurrentChar = 0;
                    int iRangeEnd = 0;
                    var att = element.Attribute("cp");
                    bool RangeStarted = false;
                    if (att == null)
                    {
                        var attf = element.Attribute("first-cp");
                        if (attf != null)
                        {
                            iCurrentChar = DataHelper.HexStringToInt32(attf.Value);
                            RangeStarted = true;
                        }
                    }
                    else
                    {
                        iCurrentChar = DataHelper.HexStringToInt32(att.Value);
                    }
                    if (iCurrentChar >= this.MaxCharValue)
                    {
                        // we have hit the max value set so we will not parse any more values
                        break;
                    }
                    CharItem itm;

                    itm = new CharItem();
                    itm.PopulateFromElement(element);


                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadElement(itm);
                    this.RepertoireToDB(itm);
                    if (RangeStarted == true)
                    {
                        var attl = element.Attribute("last-cp");
                        iRangeEnd = DataHelper.HexStringToInt32(attl.Value);
                        int iRangeCount = iRangeEnd - iCurrentChar;
                        List<CharItem> lst = this.CreateRange(itm, iRangeCount);
                        for (int i = 0; i < lst.Count; i++)
                        {
                            CharItem lstItm = lst[i];
                            this.OnReadElement(lstItm);
                            this.RepertoireToDB(lstItm);
                            iCount++;
                        }
                    }
                    else
                    {
                        iCount++;
                    }

                }
            }
           
            #endregion
            #region Process Blocks
            if (this.ProcessBlocksXml == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "blocks").Elements())
                {

                    BlockItem itm = new BlockItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadBlockElement(itm);
                    this.DataItemToDB(itm, UCD.Block.BlockTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Process Named Sequence
            if (this.ProcessNamedSequences == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "named-sequences").Elements())
                {

                    UCD.NamedSequence.NsItem itm = new UCD.NamedSequence.NsItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadNamedSequence(itm);
                    this.DataItemToDB(itm, UCD.NamedSequence.NsTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Process Provisional Named Sequence
            // UCD documentation states that there can be elements named-sequences and
            // provisional-named-sequences Children of UCD element. It appears there are no
            // provisional-named-sequences in ucd.all.flat.xml. NsItem class serves for both
            // cases. The provisional-named-sequences will be processed as named-sequences for
            // future proofing.
            if (this.ProcessNamedSequences == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "provisional-named-sequences").Elements())
                {

                    UCD.NamedSequence.NsItem itm = new UCD.NamedSequence.NsItem();
                    
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadNamedSequence(itm);
                    this.DataItemToDB(itm, UCD.NamedSequence.NsTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Normalization Corrections
            if (this.ProcessNormalizationCorrections == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "normalization-corrections").Elements())
                {

                    UCD.NormalizationCorrections.NcItem itm = new UCD.NormalizationCorrections.NcItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadNormalizationCorrectionsElement(itm);
                    this.DataItemToDB(itm, UCD.NormalizationCorrections.NcTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Standardized Variants
            if (this.ProcesStandardizedVariants == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "standardized-variants").Elements())
                {

                    UCD.StandardizedVariants.SvItem itm = new UCD.StandardizedVariants.SvItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnReadStandardizedVariantsElement(itm);
                    this.DataItemToDB(itm, UCD.StandardizedVariants.SvTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Cjk Radicals
            if (this.ProcessCjkRadicals == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "cjk-radicals").Elements())
                {

                    UCD.CjkRadicals.CjkRadicalsItem  itm = new UCD.CjkRadicals.CjkRadicalsItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnCjkRadicalsElement(itm);
                    this.DataItemToDB(itm, UCD.CjkRadicals.CjkRadicalsTable.TableName);
                    iCount++;
                }
            }
            #endregion
            #region Emoji Source
            if (this.ProcessEmojiSource == true)
            {
                foreach (XElement element in doc.Root.Elements(UcdNS + "emoji-sources").Elements())
                {

                    UCD.EmojiSource.EmojiSourceItem itm = new UCD.EmojiSource.EmojiSourceItem();
                    itm.PopulateFromElement(element);

                    if (itm == null)
                    {
                        OnReadElementNull(element.Name.LocalName);
                        continue;
                    }

                    this.OnEmojiSourceElement(itm);
                    this.DataItemToDB(itm, UCD.EmojiSource.EmojiSourceTable.TableName);
                    iCount++;
                }
            }
            #endregion
            this.OnFinished(iCount);
            this.Conn.Close();
            this._command = null;
        }


        #region ToDb
        private void RepertoireToDB(RepertoireBase itm)
        {
                SQLiteHelper sh = new SQLiteHelper(this.Command);
                sh.Insert(RepertoireTable.RepertoireTableName, itm.ToObjectDictinary());
                if ((itm.NameAliasList != null) && (itm.NameAliasList.Count > 0))
                {
                    if (RepertoireTable.MakeCpPrimaryKey == true)
                    {
                        for (int i = 0; i < itm.NameAliasList.Count; i++)
                        {
                            NameAlias NameA = itm.NameAliasList[i];
                            sh.Insert(RepertoireTable.NameAliasTableName, NameA.ToObjectDictinary());
                        }
                        
                    }
                    else
                    {
                        long id = sh.LastInsertRowId();
                        for (int i = 0; i < itm.NameAliasList.Count; i++)
			            {
                            NameAlias NameA = itm.NameAliasList[i];
                            NameA.RepertoireID = (int)id;
                            sh.Insert(RepertoireTable.NameAliasTableName, NameA.ToObjectDictinary());
			            }
                        
                    }
                }
    
        }
       
        private void DataItemToDB(UCD.DataCommon.DataItemBase itm, String TableName)
        {

            SQLiteHelper sh = new SQLiteHelper(this.Command);
            sh.Insert(TableName, itm.ToObjectDictinary());

        }
        #endregion
        #region Range
        private List<CharItem> CreateRange(CharItem FirstItem, int Count)
        {
            List<CharItem> lst = new List<CharItem>();
            for (int i = 0; i < Count; i++)
            {
                CharItem NewItm = UCD.Utility.ObjectCopier.Clone<CharItem>(FirstItem);
                NewItm.CodePoint = (FirstItem.CodePoint + i + 1);
                lst.Add(NewItm);
            }
            return lst;
        }
        #endregion

        #region TestConnection
        /// <summary>
        /// Test the current database connection to the database file passed into the constructor.
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            try
            {
                this.Conn.Open();
                this.Conn.Clone();
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
