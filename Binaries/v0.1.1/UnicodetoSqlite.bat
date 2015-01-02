@echo off
rem -d "Path to SqLite database to create or write to."
rem -x "Path to ucd.all.flat.xml"
rem -v=2 - Verbose level. Range: from 0 to 2. Higher is more Verbose
rem -m=65535 - Max Char Value. Range: from 0 to infinity. Default is 65535
rem --pr - Repertoire items will be processed and written into Database.
rem --pb - Block items will be processed and written into the database
rem --ps - Named Sequences items will be processed and written into the database.
rem --pn - Normalization Corrections items will be processed and written into the database.
rem --pv - Standardized Variants items will be processed and written into the database
rem --pc - Cjk Radicals items will be processed and written into the database.
rem --pe - Emoji Source items will be processed and written into the database.

UnicodeToSqLite.exe -d "d:\ucd.sqlite" -x "...yourpath\ucd.all.flat.xml" --pr --pb --ps --pn --pv --pc --pe