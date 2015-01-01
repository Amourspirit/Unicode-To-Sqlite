using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UCD.Repertoire;
using System.Diagnostics;
using CommandLine;
using CommandLine.Text;

namespace UnicodeToSqLite
{
    sealed partial class Program
    {
        
        static Stopwatch sw;
        static Int16 VerposeLevelOption = 2;
        static void Main(string[] args)
        {
            var options = new Options();
            options.VerboseLevel = 2;
            options.MaxCharValue = 65535;
            options.ProcessBlocksXml = false;
            options.ProcessCjkRadicals = false;
            options.ProcessEmojiSource = false;
            options.ProcessNamedSequences = false;
            options.ProcessNormalizationCorrections = false;
            options.ProcessRepertoireXml = false;
            options.ProcesStandardizedVariants = false;
     
            var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

            if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-2)))
            {
                Run(options);
            }
        }

        private static void Run(Options options)
        {
            Console.WriteLine();
            if ((options.VerboseLevel == null) || (options.VerboseLevel == 0))
            {
                Console.WriteLine("verbose [off]");
            }
            else
            {
                Console.WriteLine(
                    "verbose [on]: {0}",
                    options.VerboseLevel < 0 || options.VerboseLevel > 2 ? "#invalid value#" : options.VerboseLevel.ToString());
            }
            if (options.VerboseLevel >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("Path to ucd.all.flat.xml: {0}", options.UcdFlatXmlPath);

                Console.WriteLine();
                Console.WriteLine("input Database: {0}", options.InputDatabase);

            }
            if (options.VerboseLevel >= 2)
            {
                Console.WriteLine("Max Chars to Process for Repertoire Elements is: {0}", options.MaxCharValue);
                Console.WriteLine("Process Repertoire Elements: {0}", options.ProcessRepertoireXml.ToString());
                Console.WriteLine("Process Block Elements: {0}",options.ProcessBlocksXml.ToString());
                Console.WriteLine("Process Named Sequences Elements: {0}", options.ProcessNamedSequences.ToString());
                Console.WriteLine("Process Normalization Corrections Elements: {0}", options.ProcessNormalizationCorrections.ToString());
                Console.WriteLine("Process StandardizedV ariants Elements: {0}", options.ProcesStandardizedVariants.ToString());
                Console.WriteLine("Process Cjk Radicals Elements: {0}", options.ProcessCjkRadicals.ToString());
                Console.WriteLine("Process Emoji Source Elements: {0}", options.ProcessEmojiSource.ToString());
                Console.WriteLine();
                
            }
            if (options.VerboseLevel >= 1)
            {
                Console.WriteLine("This is a long running process.");
                Console.WriteLine("This process can take hours depending on configuration.");
            }
           
            Console.WriteLine("Do you want to continue? Y/N");
            String cContinue = Console.ReadLine();
            //Console.WriteLine(cContinue);
            String strC = cContinue.Trim().ToLower();
            if ((strC != "y") && (strC != "yes"))
            {
                return;
            }
            Program.sw = new Stopwatch();

          
            #region Try
            try
            {
                string xmlUcdFlatFile = options.UcdFlatXmlPath;
                if (!File.Exists(xmlUcdFlatFile))
                {
                    FileNotFoundException ex = new FileNotFoundException(String.Format("Unable to find file: '{0}'", xmlUcdFlatFile), xmlUcdFlatFile);
                    throw ex;
                }
               
                Program.sw.Start();
                // http://www.codeproject.com/Articles/169598/Parse-XML-Documents-by-XMLDocument-and-XDocument

                Config.DatabaseFile = options.InputDatabase;

                //Config.DatabaseFile = @"d:\\ucd.sq3";


                UCD.XmlToDb xDb = new UCD.XmlToDb(Config.DatabaseFile, options.MaxCharValue);

                #region Process Optons
                xDb.ProcessRepertoireXml = options.ProcessRepertoireXml;
                xDb.ProcessBlocksXml = options.ProcessBlocksXml;
                xDb.ProcessNamedSequences = options.ProcessNamedSequences;
                xDb.ProcessNormalizationCorrections = options.ProcessNormalizationCorrections;
                xDb.ProcesStandardizedVariants = options.ProcesStandardizedVariants;
                xDb.ProcessCjkRadicals = options.ProcessCjkRadicals;
                xDb.ProcessEmojiSource = options.ProcessEmojiSource;
                #endregion
                if (options.VerboseLevel >= 1)
                {
                     xDb.Finished += new UCD.FinishedHandler(OnFinished);
                }
               
                #region Process Elements

                #region If ProcessRepertoireXml
                if (xDb.ProcessRepertoireXml == true)
                {
                    // only add event handlers if we are processing Repertoire Xml
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                         xDb.ReadElement += new UCD.ReadElementHandler(OnReadElement);
                        
                    }
                   

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    RepertoireTable tbl = new RepertoireTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTables();
                    tbl.CreateTables();
                    if (options.VerboseLevel >= 1)
                    {
                        Console.WriteLine("Table for Repertoire Has been created.");
                    }
                    
                }
                #endregion
                #region if ProcessBlocksXml
                if (xDb.ProcessBlocksXml == true)
                {
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadBlockElement += new UCD.ReadBlockElementHandler(OnReadBlockElementHandler);
                    }
                   

                    // only create new Repertoire tables if we are processing Repertoire Xml
                   UCD.Block.BlockTable tbl = new UCD.Block.BlockTable(Config.DatabaseFile);
                   
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    if (options.VerboseLevel >= 1)
                    {
                        Console.WriteLine("Table for Blocks Has been created.");
                    }
                    
                }
                #endregion
                #region if ProcessNamedSequences
                if (xDb.ProcessNamedSequences == true)
                {

                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadNamedSequenceElement += new UCD.ReadNamedSequenceElementHandler(OnReadNamedSequenceElementHandler);
                    }

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    UCD.NamedSequence.NsTable tbl = new UCD.NamedSequence.NsTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    if (options.VerboseLevel >= 1)
                    {
                        Console.WriteLine("Table for Named Sequence Has been created.");
                    }
                    
                }
                #endregion
                #region if ProcessNormalizationCorrections
                if (xDb.ProcessNormalizationCorrections == true)
                {
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadNormalizationCorrectionsElement += new UCD.NormalizationCorrectionsElementHandler(OnNormalizationCorrectionsElementHandler);
                    }

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    UCD.NormalizationCorrections.NcTable tbl = new UCD.NormalizationCorrections.NcTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    if (options.VerboseLevel >= 1)
                    {
                         Console.WriteLine("Table for Normalizaton Corrections Has been created.");
                    }
                   
                }
                #endregion
                #region if ProcesStandardizedVariants
                if (xDb.ProcesStandardizedVariants == true)
                {
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadStandardizedVariantsElement += new UCD.StandardizedVariantsElementHandler(OnStandardizedVariantsElementHandler);
                    }

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    UCD.StandardizedVariants.SvTable tbl = new UCD.StandardizedVariants.SvTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    if (options.VerboseLevel >= 1)
                    {
                        Console.WriteLine("Table for Normalizaton Corrections Has been created.");
                    }
                    
                }
                #endregion
                #region if ProcessCjkRadicals
                if (xDb.ProcessCjkRadicals == true)
                {
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadCjkRadicalsElement += new UCD.CjkRadicalsElementHandler(OnCjkRadicalsElementHandler);
                    }

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    UCD.CjkRadicals.CjkRadicalsTable tbl = new UCD.CjkRadicals.CjkRadicalsTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    if (options.VerboseLevel >= 1)
                    {
                        Console.WriteLine("Table for Cjk Radicals Has been created.");
                    }
                    
                }
                #endregion
                #region if ProcessEmojiSource
                if (xDb.ProcessEmojiSource == true)
                {
                    if (options.VerboseLevel >= Program.VerposeLevelOption)
                    {
                        xDb.ReadEmojiSourceElement += new UCD.EmojiSourceElementHandler(OnEmojiSourceElementHandler);
                    }

                    // only create new Repertoire tables if we are processing Repertoire Xml
                    UCD.EmojiSource.EmojiSourceTable tbl = new UCD.EmojiSource.EmojiSourceTable(Config.DatabaseFile);
                    if (tbl.TestConnection() == false)
                    {
                        throw new Exception("Unable to connect to database");
                    }
                    tbl.DropTable();
                    tbl.CreateTable();
                    Console.WriteLine("Table for Emoji Source Has been created.");
                }
                #endregion

                #endregion
                if (options.VerboseLevel >= 1)
                {
                    Console.WriteLine("Reading values from XML");
                    if (xDb.ProcessRepertoireXml == true)
                    {
                        Console.WriteLine("This may take several hours");
                    }
                    else
                    {
                        Console.WriteLine("This may take some time");
                    }
                }
                
                Console.WriteLine("Please wait...");
                // List<CharItem> cList = UCD.XMLParsers.Repertoireto(xmlUcdFlatFile);

                xDb.ProcessXml(xmlUcdFlatFile);
                //Console.WriteLine("Found {0} char entries in XML",cList.Count);
                if (options.VerboseLevel >= 1)
                {
                    Console.WriteLine("Done reading XML");
                }

            }
            catch (Exception e)
            {
                string msg = string.Empty;
                if (e.InnerException == null)
                {
                    msg = e.Message;
                }
                else
                {
                    msg = string.Format("{0}{1}{2}", e.Message, Environment.NewLine, e.InnerException.Message);
                }

                Console.WriteLine(@"An error has occured");
                Console.WriteLine(msg);
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Program.sw.Stop();
                if (options.VerboseLevel >= 1)
                {
                    if (Program.sw.ElapsedMilliseconds > 0)
                    {
                        Console.WriteLine("Elapsed={0}", Program.sw.Elapsed);
                    }

                }
                
                Console.WriteLine("Press enter key to exit...");
                Console.Read();
            }
            #endregion
        }

        #region On Methods
        static void OnReadElement(object s, UCD.Args.RepertoireArgs e)
        {

            if (e.Item is UCD.Repertoire.CharItem)
            {
                UCD.Repertoire.CharItem ci = (UCD.Repertoire.CharItem)e.Item;
                if (ci.HasCp())
                {
                    if (ci.IsRangeChar == true)
                    {
                        Console.WriteLine("Processing {3} '{0:X}' for range '{1:X}' to '{2:X}'"
                            , ci.CodePoint, ci.FirstCodePoint, ci.LastCodePoint, ci.ElementName);
                    }
                    else
                    {
                        Console.WriteLine("Processing {1}: {0:X}", ci.CodePoint, ci.ElementName);
                    }
                    
                }
                else
                {
                    if (ci.CodePoint > -1)
                    {
                        Console.WriteLine("Processing {3} '{0:X}' for range '{1:X}' to '{2:X}'"
                            ,ci.CodePoint , ci.FirstCodePoint, ci.LastCodePoint, ci.ElementName);
                    }
                    else
                    {
                        Console.WriteLine("Processing {2} '{0:X}' to '{1:X}'"
                            , ci.FirstCodePoint, ci.LastCodePoint, ci.ElementName);
                    }
                    
                }
            }
        }

        static void OnXmlRead(object s, EventArgs e)
        {
            Console.WriteLine("Xml fie has been loaded: Elapsed={0}", Program.sw.Elapsed);
        }
        static void OnFinished(object s, UCD.Args.FinishedArgs f)
        {
            Console.WriteLine("Finished reading and writing. A total of {0} entries was processed.", f.EntryCount);
        }

        static void OnReadBlockElementHandler(object sender, UCD.Args.BlockItemArgs args)
        {
            
            Console.WriteLine("Processing {2} '{0:X}' to '{1:X}'"
                            , args.Item.FirstCodePoint, args.Item.LastCodePoint, args.Item.ElementName);

        }

        static void OnReadNamedSequenceElementHandler(object sender, UCD.Args.NamedSequenceArgs args)
        {
            Console.WriteLine("Processing {1} '{0}'"
                           , args.Item.CodePoints, args.Item.ElementName);
        }
        static void OnNormalizationCorrectionsElementHandler(object sender, UCD.Args.NormalizationCorrectionsArgs args)
        {
            Console.WriteLine("Processing {0} '{1:X}'"
                            , args.Item.ElementName, args.Item.CodePoint);
        }

        static void OnStandardizedVariantsElementHandler(object sender, UCD.Args.StandardizedVariantsArgs args)
        {
            Console.WriteLine("Processing {0} '{1}'"
                            , args.Item.ElementName, args.Item.CodePoints);
        }
        static void OnCjkRadicalsElementHandler(object sender,UCD.Args.CjkRadicalsArgs args)
        {
            Console.WriteLine("Processing {0} '{1}'"
                            , args.Item.ElementName, args.Item.Number);
        }
        static void OnEmojiSourceElementHandler(object sender, UCD.Args.EmojiSourceArgs args)
        {
            Console.WriteLine("Processing {0} '{1}'"
                            , args.Item.ElementName, args.Item.Unicode);
        }
        #endregion
    }
}
