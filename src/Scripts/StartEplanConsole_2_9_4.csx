#r "X:\Suplanus.Sepla\Suplanus.Sepla\bin\Release\Suplanus.Sepla.dll"
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
using Suplanus.Sepla.Application;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;

string binPath = Starter.GetEplanInstallations().LastOrDefault(obj => obj.EplanVersion.Equals("2.9.4")).EplanPath;
EplanOffline eplan;

if(!string.IsNullOrWhiteSpace(binPath))
{
  binPath = Path.GetDirectoryName(binPath);
  Starter.PinToEplan(binPath);
  eplan = new EplanOffline(binPath, "API");
  eplan.StartWithoutGui();
  return eplan.IsRunning;
}
Project GetProject(string linkFile)
{
  var prjManager = new ProjectManager();
  prjManager.LockProjectByDefault = false;
  var substitutedLinkFile = PathMap.SubstitutePath(linkFile);
  return prjManager.OpenProject(substitutedLinkFile, ProjectManager.OpenMode.Standard, true);
}