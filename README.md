# Black.Beard.Roslyn

[![Build status](https://ci.appveyor.com/api/projects/status/2r6ucvo29ywpvdc8?svg=true)](https://ci.appveyor.com/project/gaelgael5/black-beard-roslyn)

Helpers for compile Csharp with Roslyn.
The way use the tool installed on your machine. It does'nt work in dotnet is not installed.


Sample the use Black.Beard.Build for create a csproj
```CSHARP

    //Usings
    using Bb.Build;
    using System;
    using System.IO;

    // create a folder for store the generated project file
    var name = "Black.Beard.tests";
    var dir = new DirectoryInfo(Path.Combine(this._baseDirectory.FullName, name));


    var project = new MsProject(name, dir)
        
        .Sdk(ProjectSdk.MicrosoftNETSdk)    // Specify the target build

        .SetPropertyGroup(c =>              // set the properies of the build
        {
            c.TargetFramework(TargetFramework.Net6)
            .RootNamespace("Bb")
            .Description("My description")
            .RepositoryUrl(new System.Uri("http://github.com"))
            ;
        })

        .Packages(p =>                      // Reference packages
        {
            p.PackageReference("Black.Beard.ComponentModel", new Version("1.0.36"))
             .PackageReference("Black.Beard.Helpers.ContentLoaders", new Version("1.0.8"))
            ;

        });

    // Build
    var result = project.Build(inMemory: true, load: true);

    // fetch the new assembly
    var assembly = project.Assembly;

```

or the helper
``` CSHARP

    var project = MsProjects.CreateCsProject(dir.FullName, name, 
    TargetFramework.Net6, 
    "Bb"                
    )
    .SetPropertyGroup(a =>
    {
        a.Description("MyDescription");
    })
    .Packages(p =>
    {
        p.PackageReference("Black.Beard.ComponentModel", new Version("1.0.36"))
         .PackageReference("Black.Beard.Helpers.ContentLoaders", new Version("1.0.8"))
        ;
    
    });
```


This way use Roslyn for generate the assembly

``` CSHARP

    // Use NJsonSchema for generate json schema
    JsonSchema schema = JsonSchema.FromType(typeof(Sample1));

    // Helper for manipulate codeDom object
    var samples = "CodeDOMSample".ToNamespace()
        .Import("System")       // append usings

        .AppendPoco(schema)     // add a poco class from schema

        .ToCSharp(Path.Combine(_dir.FullName, "class1.cs")) // Generate csharp code
        ;

    // compile
    AssemblyResult assembly = GetCsharpBuilder(samples.FullName);

    // consumme the result assembly
    if (assembly.Success)
    {
        var ass = assembly.LoadAssembly();
        var type = ass.GetTypes().First(c => c.Name == "Sample1");
        Assert.NotNull(type);
    
        var property = type.GetProperties().FirstOrDefault(c => nameof(Sample1.Name) == c.Name);
        Assert.NotNull(property);
    
    }
    else
    {
        var payload = File.ReadAllText(samples.FullName);
        throw new Exception();
    }

```

``` CSHARP

    private static Bb.Compilers.AssemblyResult GetCsharpBuilder(string filepathCode)
    {

        var fileInfo = new FileInfo(filepathCode);

        // Build assembly

        Action<CSharpCompilationOptions> action = (r) =>
        {

        };

        BuildCSharp builder = new BuildCSharp()
        {
            ResolveAssembliesInCode = true,
            Debug = true,
            LanguageVersion = LanguageVersion.CSharp7,
        }
        .AddSource(fileInfo)
        .Suppress("CS1702", "CS1998")
        ;

        // System.Collections
        builder.References.AddRange(
            typeof(object),
            typeof(RequiredAttribute)
        );

        var assembly = builder.Build();
        return assembly;

    }        

```
