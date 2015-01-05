#Unicode-To-Sqlite


Reads Unicode Xml file, parses all the values and writes them into a sqlite database

**This is a comand line project developed in c#**

The purpose of this project to convert unicode xml [ucd.all.flat.xml](https://github.com/behnam/unicode-ucdxml/blob/master/ucd.all.flat.xml)
into a sqlite database.

There are two projects [UCD_LIB](https://github.com/Amourspirit/Unicode-To-Sqlite/tree/master/UCD_LIB) that contains all the code for 
database manipulation. [UnicodeToSqlLite](https://github.com/Amourspirit/Unicode-To-Sqlite/tree/master/UnicodeToSqlLite) that is a
command line program that references *UCD_LIB* to manipulate the database.


The binaries can be found in the binaries folder. Of the compiled project.

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
**--cp** - Planes table will be created with planes data inserted into the database.  

#+BEGIN_EXAMPLE
   UnicodeToSqLite.exe -d "d:\ucd.sqlite" -x "d:\xml\ucd\ucd.all.flat.xml" --pr --pb --ps --pn --pv --pc --pe --cp
#+END_EXAMPLE


## Database Specific
Repertoire child elements such as char, reserved that have a range are expanded into one entry for each element.  
For example: entry <reserved first-cp="05F5" last-cp="05FF"  would be expanded into 11 entries,  05F5, 05F6, 05F7, 05F8, 05F8, 05FA,05FB, 05FC, 05FD, 05FE, 05FF  
This allow for easier looking up of entries from the *repertoire* table.  

## References
Unicode-To-SqLite references [System.Data.SQLite](https://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki)   
Unicode-To-SqLite references [SQLite Helper](http://www.codeproject.com/Articles/746191/SQLite-Helper-Csharp)  
Unicode-To-SqLite references [Command Line Parser Library](https://commandline.codeplex.com/)  

