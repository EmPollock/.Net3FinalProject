ECHO off

sqlcmd -S localhost -E -i critterpedia_plus_2.sql

rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE