#Unicode-To-Sqlite


Reads Unicode Xml file, parses all the values and writes them into a sqlite database

**This is a comand line project developed in c#**

The purpose of this project to convert unicode xml ][/ucd.all.flat.xml](https://github.com/behnam/unicode-ucdxml/blob/master/ucd.all.flat.xml)
into a sqlite database.

The binaries can be found in the binaries folder. Of the commpiled project.

**Usage**
Command Line options.
**-d** "Path to SqLite database to create or write to."  
**-x** "Path to ucd.all.flat.xml"  
**-v=2** - Verbose level. Range: from 0 to 2. Higher is more Verbose  
**-m=65535** - Max Char Value. Range: from 0 to infinity. Default is 65535  
**--pr** - Repertoire items will be processed and written into Database.  
**--pb** - Block items will be processed and written into the database  
**--ps** - Named Sequences items will be processed and written into the database.  
**--pn** - Normalization Corrections items will be processed and written into the database.  
**--pv** - Standardized Variants items will be processed and written into the database  
**--pc** - Cjk Radicals items will be processed and written into the database.  
**--pe** - Emoji Source items will be processed and written into the database.  

**Example:** UnicodeToSqLite.exe -d "d:\ucd.sqlite" -x "d:\xml\ucd\ucd.all.flat.xml" --pr --pb --ps --pn --pv --pc --pe
