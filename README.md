# Black.Beard.Roslyn

[![Build status](https://ci.appveyor.com/api/projects/status/2r6ucvo29ywpvdc8?svg=true)](https://ci.appveyor.com/project/gaelgael5/black-beard-roslyn)

Helpers for compile Csharp with Roslyn.
The way use the tool installed on your machine. It does'nt work if dotnet is not installed.



## How to install
Use project model for create a project file

```powershell
NuGet\Install-Package Black.Beard.Projects.Models
``` 

Use build for build project
```powershell
NuGet\Install-Package Black.Beard.Build
``` 

Use roslyn for compile without project
```powershell
NuGet\Install-Package Black.Beard.Roslyn
``` 

## How to use Roslyn

```csharp

// Use existing project
var projects = _directoryProject.GetFiles("*.csproj", SearchOption.AllDirectories);

foreach (var item in projects)
{
    var builder = ProjectRoslynBuilderHelper.CreateCsharpBuild(item.FullName, true);
    var result = builder.Build();
    var assembly = result.LoadAssembly();
    var types = assembly.GetExportedTypes();
    var instance = Activator.CreateInstance(types[0]);
}
```

```csharp

// Use Roslyn for generate #Csharp
var artifact = new CSharpArtifact("test1")
    .Namespace("namespace1", ns =>
    {
        ns.Class("class1", cls =>
        {
            cls.Property("get1", nameof(String), property =>
            {
                property.AutoGet().AutoSet();
            });
        });
    });

var code = artifact.ToString();

```