# REPL with EPLAN

Usage of C# Interactive Window with EPLAN API

## Description

REPL is for [Read Evaluate Print Loop](https://en.wikipedia.org/wiki/Read–eval–print_loop). Just imagine you could execute code while you're writing it line by line. The Roslyn compiler makes this possible. The Visual Studio Build Tools include an executable named `csi.exe` (C# Interactive) that starts as a simple console window. Here you can start to enter and execute C# code instantly. 
Default path for the executable is:
`C:\Program Files (x86)\Microsoft Visual Studio\2019\[VARIANT]\MSBuild\Current\Bin\Roslyn\csi.exe`

You can also start C# Interactive within Visual Studio 2015 and newer (View > Other Windows > C# Interactive). This adds Intellisense (code completion) to the terminal, what makes it even easier to learn a framework or analyze method behavior and properties of a class.
With the `#r` directive you can simply add .Net library references to your C# Interactive instance. With a little trick this works for the EPLAN API assemblies as well. Of course you still need the developer license (EPLAN API Extension).

## Prepare EPLAN

To use the EPLAN API assemblies in C# Interactive you need to proceed like you would use [EPLAN offline in other applications](https://www.eplan.help/help/platformapi/2.7/en-us/help/UsingEplanAssemblies.html). The easiest way to do so is by using the [Suplanus.Seplan](https://github.com/Suplanus/Suplanus.Sepla) library.  
But you don't need to type in or copy paste the code each time. With the `#load` directive you can include and execute a C# Script (*.csx) to your execution engine. I prepared a script here [StartEplanConsole_2_9_4](./src/Scripts/StartEplanConsole_2_9_4.csx) that does the job if paths for `#r` directive are setup correctly.

So all you need to do is:
1. Download the script [StartEplanConsole_2_9_4](./src/Scripts/StartEplanConsole_2_9_4.csx)
2. Fix the path to your Sepl build 
3. Fix the path and version to your EPLAN assemblies you like to adress
4. Fix the system configuration you like to start with (mine is `API`)
5. `#load ./src/Scripts/StartEplanConsole_2_9_4.csx`
6. Select license with API Extension 
7. have fun

The Script also brings an example method to open a EPLAN project. 
Just `var myProject = GetProject("$(MD_PROJECTS)\MyProject.elk")`

[![Video](https://img.youtube.com/vi/h3kXCovQbEg/hqdefault.jpg)](https://youtu.be/h3kXCovQbEg)

| :warning: Make sure you close all project before you reset or close the C# Interactive Window |
| --- |

Also it's nicer to shut down the EPLAN offline application with `eplan.Close();`
