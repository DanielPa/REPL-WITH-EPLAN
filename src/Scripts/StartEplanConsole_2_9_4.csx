#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.Systemu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.Starteru.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.AFu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.Baseu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.Guiu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.DataModelu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.MasterDatau.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.EServicesu.dll"
#r "C:\Program Files\EPLAN\Platform\2.9.4\Bin\Eplan.EplApi.HEServicesu.dll"

using System;
using System.IO;
using System.Linq;
using Eplan.EplApi.System;
using Eplan.EplApi.Starter;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;

var eplanFinder = new EplanFinder();

string binPath = @"C:\Program Files\EPLAN\Platform\2.9.4\Bin\";
EplApplication eplan;

if(!string.IsNullOrWhiteSpace(binPath))
{
  binPath = Path.GetDirectoryName(binPath);
  AssemblyResolver resolver = new AssemblyResolver();
  resolver.SetEplanBinPath(binPath);
  resolver.PinToEplan();

  eplan = new EplApplication();
  eplan.EplanBinFolder = @"C:\Program Files\EPLAN\Electric P8\2.9.4\Bin";
  eplan.SystemConfiguration = "API";
  eplan.QuietMode = EplApplication.QuietModes.ShowAllDialogs;
  eplan.Init("", true, true);
  eplan.QuietMode = EplApplication.QuietModes.ShowNoDialogs;
}
Project GetProject(string linkFile)
{
  var prjManager = new ProjectManager();
  prjManager.LockProjectByDefault = false;
  var substitutedLinkFile = PathMap.SubstitutePath(linkFile);
  return prjManager.OpenProject(substitutedLinkFile, ProjectManager.OpenMode.Standard, true);
}