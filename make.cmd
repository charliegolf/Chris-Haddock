@echo off

if "%1" == "" goto DefaultTarget

goto SpecificTarget

:DefaultTarget
%windir%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Haddock.proj 
rem /l:FileLogger,Microsoft.Build.Engine;logfile=DebugBuild.txt;append=true;verbosity=detailed;encoding=utf-8
goto End

:SpecificTarget
%windir%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe Haddock.proj /t:%* 
rem /l:FileLogger,Microsoft.Build.Engine;logfile=DebugBuild.txt;append=true;verbosity=detailed;encoding=utf-8

:End
