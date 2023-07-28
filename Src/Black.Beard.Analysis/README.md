# Black.Beard.Roslyn

[![Build status](https://ci.appveyor.com/api/projects/status/2r6ucvo29ywpvdc8?svg=true)](https://ci.appveyor.com/project/gaelgael5/black-beard-roslyn)

Class for manage Compile / Analyse of code.

Sample the use Black.Beard.Build for create a csproj
```CSHARP

    int line = 0;
    int column = 0;
    
    var diag = new Diagnostics();
    
    diag.AddError("filename", line, 0, column, "text", "message");
    
    Assert.False(diag.Success);

```
