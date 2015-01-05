#region License
//
// Command Line Library: Program.cs
//
// Author:
//   Giacomo Stelluti Scala (gsscoder@gmail.com)
//
// Copyright (C) 2005 - 2013 Giacomo Stelluti Scala
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
#endregion
#region Using Directives
using System;
using System.ComponentModel;
using System.Text;
using CommandLine;
using CommandLine.Text;
#endregion

namespace UnicodeToSqLite
{

    partial class Program
    {
        private enum OptimizeFor
        {
            Unspecified,
            Speed,
            Accuracy
        }
        private sealed class Options
        {
            [Option('d', "database", Required = true, HelpText = "Path to SqLite database to create or write to.")]
            public String InputDatabase { get; set; }

            [Option('x', "xml", Required = true, HelpText = "Path to ucd.all.flat.xml")]
            public String UcdFlatXmlPath { get; set; }

            [Option('v', MetaValue = "INT", HelpText = "Verbose level. Range: from 0 to 2. Higher is more Verbose")]
            public int? VerboseLevel { get; set; }

            /// <summary>
            /// The maximum number of element to read from xml and write to database.
            /// Default value is 65535
            /// </summary>
            [Option('m', MetaValue = "INT", HelpText = "Max Char Value. Range: from 0 to infinity. Default is 65535")]
            public int MaxCharValue { get; set; }
            /// <summary>
            /// If true then Repertoire items will be processed and written into Database.
            /// Default is true.
            /// </summary>
            /// <remarks>
            /// <typeparamref name="ProcessRepertoireXml"/> is affected by <typeparamref name="MaxCharValue"/>
            /// </remarks>
            [Option("pr", HelpText = "Repertoire items will be processed and written into database.")]
            public bool ProcessRepertoireXml { get; set; }
            /// <summary>
            /// If true then Block items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("pb", HelpText = "Block items will be processed and written into the database.")]
            public bool ProcessBlocksXml { get; set; }
            /// <summary>
            /// If true then Named Sequences items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("ps", HelpText = "Named Sequences items will be processed and written into the database.")]
            public bool ProcessNamedSequences { get; set; }

            /// <summary>
            /// If true then Normalization Corrections items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("pn", HelpText = "Normalization Corrections items will be processed and written into the database.")]
            public bool ProcessNormalizationCorrections { get; set; }

            /// <summary>
            /// If true then Standardized Variants items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("pv", HelpText = "Standardized Variants items will be processed and written into the database")]
            public bool ProcesStandardizedVariants { get; set; }

            /// <summary>
            /// If true then Cjk Radicals items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("pc", HelpText = "Cjk Radicals items will be processed and written into the database.")]
            public bool ProcessCjkRadicals { get; set; }
            /// <summary>
            /// If true then Emoji Source items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("pe", HelpText = "Emoji Source items will be processed and written into the database.")]
            public bool ProcessEmojiSource { get; set; }

            /// <summary>
            /// If true then Emoji Source items will be processed and written into the database.
            /// Default is true.
            /// </summary>
            [Option("cp", HelpText = "Planes table will be created with planes data inserted into the database.")]
            public bool CreatePlanes { get; set; }

            //
            // Marking a property of type IParserState with ParserStateAttribute allows you to
            // receive an instance of ParserState (that contains a IList<ParsingError>).
            // This is equivalent from inheriting from CommandLineOptionsBase (of previous versions)
            // with the advantage to not propagating a type of the library.
            //
            [ParserState]
            public IParserState LastParserState { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }

        }
    }
}
