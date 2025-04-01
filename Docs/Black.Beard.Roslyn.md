<a name='assembly'></a>
# Black.Beard.Roslyn

## Contents

- [AssemblyReferences](#T-Bb-Builds-AssemblyReferences 'Bb.Builds.AssemblyReferences')
  - [#ctor()](#M-Bb-Builds-AssemblyReferences-#ctor 'Bb.Builds.AssemblyReferences.#ctor')
  - [AddAssemblyFiles(assemblies)](#M-Bb-Builds-AssemblyReferences-AddAssemblyFiles-System-String[]- 'Bb.Builds.AssemblyReferences.AddAssemblyFiles(System.String[])')
  - [AddAssemblyLocation(location,assemblyName,Version)](#M-Bb-Builds-AssemblyReferences-AddAssemblyLocation-System-String- 'Bb.Builds.AssemblyReferences.AddAssemblyLocation(System.String)')
  - [AddByAssemblies(assemblies)](#M-Bb-Builds-AssemblyReferences-AddByAssemblies-System-Reflection-Assembly[]- 'Bb.Builds.AssemblyReferences.AddByAssemblies(System.Reflection.Assembly[])')
  - [AddByAssembly(assembly)](#M-Bb-Builds-AssemblyReferences-AddByAssembly-System-Reflection-Assembly- 'Bb.Builds.AssemblyReferences.AddByAssembly(System.Reflection.Assembly)')
  - [AddByType(type)](#M-Bb-Builds-AssemblyReferences-AddByType-System-Type- 'Bb.Builds.AssemblyReferences.AddByType(System.Type)')
  - [AddByTypes(typeAssembly)](#M-Bb-Builds-AssemblyReferences-AddByTypes-System-Type[]- 'Bb.Builds.AssemblyReferences.AddByTypes(System.Type[])')
  - [AddResolveFilename(filename)](#M-Bb-Builds-AssemblyReferences-AddResolveFilename-System-String- 'Bb.Builds.AssemblyReferences.AddResolveFilename(System.String)')
  - [GetEnumerator()](#M-Bb-Builds-AssemblyReferences-GetEnumerator 'Bb.Builds.AssemblyReferences.GetEnumerator')
  - [IsInSdk(fullName)](#M-Bb-Builds-AssemblyReferences-IsInSdk-System-String- 'Bb.Builds.AssemblyReferences.IsInSdk(System.String)')
  - [IsInSdk(file)](#M-Bb-Builds-AssemblyReferences-IsInSdk-System-IO-FileInfo- 'Bb.Builds.AssemblyReferences.IsInSdk(System.IO.FileInfo)')
  - [ResolveAssemblyName(assemblyName,Version)](#M-Bb-Builds-AssemblyReferences-ResolveAssemblyName-System-String,System-Func{Bb-Builds-ReferenceType,System-Collections-Generic-List{Bb-Builds-Reference},Bb-Builds-Reference}- 'Bb.Builds.AssemblyReferences.ResolveAssemblyName(System.String,System.Func{Bb.Builds.ReferenceType,System.Collections.Generic.List{Bb.Builds.Reference},Bb.Builds.Reference})')
  - [SearchInRegistered(assemblyName,Version)](#M-Bb-Builds-AssemblyReferences-SearchInRegistered-System-String,System-Version- 'Bb.Builds.AssemblyReferences.SearchInRegistered(System.String,System.Version)')
  - [SearchInRegistered(assemblyName,Version)](#M-Bb-Builds-AssemblyReferences-SearchInRegistered-System-String- 'Bb.Builds.AssemblyReferences.SearchInRegistered(System.String)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-Bb-Builds-AssemblyReferences-System#Collections#IEnumerable#GetEnumerator 'Bb.Builds.AssemblyReferences.System#Collections#IEnumerable#GetEnumerator')
- [AssemblyResult](#T-Bb-Compilers-AssemblyResult 'Bb.Compilers.AssemblyResult')
  - [LoadAssembly()](#M-Bb-Compilers-AssemblyResult-LoadAssembly 'Bb.Compilers.AssemblyResult.LoadAssembly')
  - [PrepareFolderToExecute()](#M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute 'Bb.Compilers.AssemblyResult.PrepareFolderToExecute')
  - [PrepareFolderToExecute(directory)](#M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute-System-String- 'Bb.Compilers.AssemblyResult.PrepareFolderToExecute(System.String)')
  - [PrepareFolderToExecute(directory)](#M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute-System-IO-DirectoryInfo- 'Bb.Compilers.AssemblyResult.PrepareFolderToExecute(System.IO.DirectoryInfo)')
  - [ResolveDependencies()](#M-Bb-Compilers-AssemblyResult-ResolveDependencies 'Bb.Compilers.AssemblyResult.ResolveDependencies')
  - [ResolveDependencies(references)](#M-Bb-Compilers-AssemblyResult-ResolveDependencies-Bb-Builds-AssemblyReferences- 'Bb.Compilers.AssemblyResult.ResolveDependencies(Bb.Builds.AssemblyReferences)')
- [BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')
  - [#ctor(configureCompilation)](#M-Bb-Builds-BuildCSharp-#ctor-System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}- 'Bb.Builds.BuildCSharp.#ctor(System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions})')
  - [AssemblyName](#P-Bb-Builds-BuildCSharp-AssemblyName 'Bb.Builds.BuildCSharp.AssemblyName')
  - [Debug](#P-Bb-Builds-BuildCSharp-Debug 'Bb.Builds.BuildCSharp.Debug')
  - [DelaySign](#P-Bb-Builds-BuildCSharp-DelaySign 'Bb.Builds.BuildCSharp.DelaySign')
  - [DocumentationMode](#P-Bb-Builds-BuildCSharp-DocumentationMode 'Bb.Builds.BuildCSharp.DocumentationMode')
  - [Framework](#P-Bb-Builds-BuildCSharp-Framework 'Bb.Builds.BuildCSharp.Framework')
  - [KeyFile](#P-Bb-Builds-BuildCSharp-KeyFile 'Bb.Builds.BuildCSharp.KeyFile')
  - [LastBuild](#P-Bb-Builds-BuildCSharp-LastBuild 'Bb.Builds.BuildCSharp.LastBuild')
  - [MainTypeName](#P-Bb-Builds-BuildCSharp-MainTypeName 'Bb.Builds.BuildCSharp.MainTypeName')
  - [Nugets](#P-Bb-Builds-BuildCSharp-Nugets 'Bb.Builds.BuildCSharp.Nugets')
  - [OutputKind](#P-Bb-Builds-BuildCSharp-OutputKind 'Bb.Builds.BuildCSharp.OutputKind')
  - [OutputPath](#P-Bb-Builds-BuildCSharp-OutputPath 'Bb.Builds.BuildCSharp.OutputPath')
  - [Platform](#P-Bb-Builds-BuildCSharp-Platform 'Bb.Builds.BuildCSharp.Platform')
  - [References](#P-Bb-Builds-BuildCSharp-References 'Bb.Builds.BuildCSharp.References')
  - [ResolveObjects](#P-Bb-Builds-BuildCSharp-ResolveObjects 'Bb.Builds.BuildCSharp.ResolveObjects')
  - [RuntimeConfig](#P-Bb-Builds-BuildCSharp-RuntimeConfig 'Bb.Builds.BuildCSharp.RuntimeConfig')
  - [Sources](#P-Bb-Builds-BuildCSharp-Sources 'Bb.Builds.BuildCSharp.Sources')
  - [StrongNameKey](#P-Bb-Builds-BuildCSharp-StrongNameKey 'Bb.Builds.BuildCSharp.StrongNameKey')
  - [AddAssemblyAttribute(attributeName,arguments)](#M-Bb-Builds-BuildCSharp-AddAssemblyAttribute-System-String,System-Object[]- 'Bb.Builds.BuildCSharp.AddAssemblyAttribute(System.String,System.Object[])')
  - [AddAssemblyAttribute(attribute,arguments)](#M-Bb-Builds-BuildCSharp-AddAssemblyAttribute-System-Type,System-Object[]- 'Bb.Builds.BuildCSharp.AddAssemblyAttribute(System.Type,System.Object[])')
  - [AddAvailableSdk(frameworkVersions)](#M-Bb-Builds-BuildCSharp-AddAvailableSdk-System-String[]- 'Bb.Builds.BuildCSharp.AddAvailableSdk(System.String[])')
  - [AddPackage(packageName,version)](#M-Bb-Builds-BuildCSharp-AddPackage-System-String,System-Version- 'Bb.Builds.BuildCSharp.AddPackage(System.String,System.Version)')
  - [AddPackage(packageName,version)](#M-Bb-Builds-BuildCSharp-AddPackage-System-String,System-String- 'Bb.Builds.BuildCSharp.AddPackage(System.String,System.String)')
  - [AddPackage(packageName)](#M-Bb-Builds-BuildCSharp-AddPackage-System-String- 'Bb.Builds.BuildCSharp.AddPackage(System.String)')
  - [AddReferences(types)](#M-Bb-Builds-BuildCSharp-AddReferences-System-Type[]- 'Bb.Builds.BuildCSharp.AddReferences(System.Type[])')
  - [AddReferences(types)](#M-Bb-Builds-BuildCSharp-AddReferences-System-Reflection-Assembly[]- 'Bb.Builds.BuildCSharp.AddReferences(System.Reflection.Assembly[])')
  - [AddReferences(assemblyLocation,assemblyName)](#M-Bb-Builds-BuildCSharp-AddReferences-System-String- 'Bb.Builds.BuildCSharp.AddReferences(System.String)')
  - [AddSource(paths)](#M-Bb-Builds-BuildCSharp-AddSource-System-IO-FileInfo[]- 'Bb.Builds.BuildCSharp.AddSource(System.IO.FileInfo[])')
  - [AddSource(path)](#M-Bb-Builds-BuildCSharp-AddSource-System-String[]- 'Bb.Builds.BuildCSharp.AddSource(System.String[])')
  - [AddSource(path)](#M-Bb-Builds-BuildCSharp-AddSource-System-String,System-String- 'Bb.Builds.BuildCSharp.AddSource(System.String,System.String)')
  - [Build(assemblyName)](#M-Bb-Builds-BuildCSharp-Build-System-String- 'Bb.Builds.BuildCSharp.Build(System.String)')
  - [CanBeBuilt()](#M-Bb-Builds-BuildCSharp-CanBeBuilt 'Bb.Builds.BuildCSharp.CanBeBuilt')
  - [ConfigureCompilation()](#M-Bb-Builds-BuildCSharp-ConfigureCompilation-System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}- 'Bb.Builds.BuildCSharp.ConfigureCompilation(System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions})')
  - [EnableImplicitUsings(enable)](#M-Bb-Builds-BuildCSharp-EnableImplicitUsings-System-Boolean- 'Bb.Builds.BuildCSharp.EnableImplicitUsings(System.Boolean)')
  - [FilterSources(value)](#M-Bb-Builds-BuildCSharp-FilterSources-System-Func{Bb-Builds-SourceCode,System-Boolean}- 'Bb.Builds.BuildCSharp.FilterSources(System.Func{Bb.Builds.SourceCode,System.Boolean})')
  - [ResetSdk()](#M-Bb-Builds-BuildCSharp-ResetSdk 'Bb.Builds.BuildCSharp.ResetSdk')
  - [SetDiagnostics(diagnostics)](#M-Bb-Builds-BuildCSharp-SetDiagnostics-Bb-Analysis-DiagTraces-ScriptDiagnostics- 'Bb.Builds.BuildCSharp.SetDiagnostics(Bb.Analysis.DiagTraces.ScriptDiagnostics)')
  - [SetNugetController(controller)](#M-Bb-Builds-BuildCSharp-SetNugetController-Bb-Nugets-NugetController- 'Bb.Builds.BuildCSharp.SetNugetController(Bb.Nugets.NugetController)')
  - [SetOutputKind(kind,mainTypeName)](#M-Bb-Builds-BuildCSharp-SetOutputKind-Microsoft-CodeAnalysis-OutputKind,System-String- 'Bb.Builds.BuildCSharp.SetOutputKind(Microsoft.CodeAnalysis.OutputKind,System.String)')
  - [SetOutputKind(kind)](#M-Bb-Builds-BuildCSharp-SetOutputKind-Microsoft-CodeAnalysis-OutputKind- 'Bb.Builds.BuildCSharp.SetOutputKind(Microsoft.CodeAnalysis.OutputKind)')
  - [SetSdk(frameworkKey)](#M-Bb-Builds-BuildCSharp-SetSdk-System-String- 'Bb.Builds.BuildCSharp.SetSdk(System.String)')
  - [SetSdk(key,type)](#M-Bb-Builds-BuildCSharp-SetSdk-Bb-Analysis-FrameworkKey,Bb-Analysis-FrameworkType- 'Bb.Builds.BuildCSharp.SetSdk(Bb.Analysis.FrameworkKey,Bb.Analysis.FrameworkType)')
  - [SetSdk()](#M-Bb-Builds-BuildCSharp-SetSdk 'Bb.Builds.BuildCSharp.SetSdk')
  - [SetSdk(framework)](#M-Bb-Builds-BuildCSharp-SetSdk-Bb-Builds-FrameworkVersion- 'Bb.Builds.BuildCSharp.SetSdk(Bb.Builds.FrameworkVersion)')
  - [Suppress(ids)](#M-Bb-Builds-BuildCSharp-Suppress-System-String[]- 'Bb.Builds.BuildCSharp.Suppress(System.String[])')
  - [SuppressDiagnostic(reportMode,ids)](#M-Bb-Builds-BuildCSharp-SuppressDiagnostic-Microsoft-CodeAnalysis-ReportDiagnostic,System-String[]- 'Bb.Builds.BuildCSharp.SuppressDiagnostic(Microsoft.CodeAnalysis.ReportDiagnostic,System.String[])')
  - [Using(usings,action)](#M-Bb-Builds-BuildCSharp-Using-System-String,System-Action{Bb-Codings-CSUsing}- 'Bb.Builds.BuildCSharp.Using(System.String,System.Action{Bb.Codings.CSUsing})')
  - [Using(usings,action)](#M-Bb-Builds-BuildCSharp-Using-Bb-Codings-CSUsing- 'Bb.Builds.BuildCSharp.Using(Bb.Codings.CSUsing)')
  - [UsingStatics(usings)](#M-Bb-Builds-BuildCSharp-UsingStatics-System-String[]- 'Bb.Builds.BuildCSharp.UsingStatics(System.String[])')
  - [Usings(usings)](#M-Bb-Builds-BuildCSharp-Usings-System-Type[]- 'Bb.Builds.BuildCSharp.Usings(System.Type[])')
  - [Usings(usings,action)](#M-Bb-Builds-BuildCSharp-Usings-System-String[],System-Action{Bb-Codings-CSUsing}- 'Bb.Builds.BuildCSharp.Usings(System.String[],System.Action{Bb.Codings.CSUsing})')
- [CSMemberDeclaration](#T-Bb-Codings-CSMemberDeclaration 'Bb.Codings.CSMemberDeclaration')
  - [Add\`\`1(member)](#M-Bb-Codings-CSMemberDeclaration-Add``1-``0- 'Bb.Codings.CSMemberDeclaration.Add``1(``0)')
  - [Field(fieldName,type,action)](#M-Bb-Codings-CSMemberDeclaration-Field-System-String,System-String,System-Action{Bb-Codings-CsFieldDeclaration}- 'Bb.Codings.CSMemberDeclaration.Field(System.String,System.String,System.Action{Bb.Codings.CsFieldDeclaration})')
  - [Field(fieldName,type)](#M-Bb-Codings-CSMemberDeclaration-Field-System-String,System-String- 'Bb.Codings.CSMemberDeclaration.Field(System.String,System.String)')
  - [Items\`\`1()](#M-Bb-Codings-CSMemberDeclaration-Items``1 'Bb.Codings.CSMemberDeclaration.Items``1')
- [CSMemberDeclarationHelper](#T-Bb-Codings-CSMemberDeclarationHelper 'Bb.Codings.CSMemberDeclarationHelper')
  - [Attribute\`\`1(self,attribute,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Attribute``1-``0,System-Type,System-Action{Bb-Codings-CsAttributeDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Attribute``1(``0,System.Type,System.Action{Bb.Codings.CsAttributeDeclaration})')
  - [Attribute\`\`1(self,attributeName,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Attribute``1-``0,System-String,System-Action{Bb-Codings-CsAttributeDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Attribute``1(``0,System.String,System.Action{Bb.Codings.CsAttributeDeclaration})')
  - [DisableWarning\`\`1(self,codes)](#M-Bb-Codings-CSMemberDeclarationHelper-DisableWarning``1-``0,System-String[]- 'Bb.Codings.CSMemberDeclarationHelper.DisableWarning``1(``0,System.String[])')
  - [Method\`\`1(self,methodName,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-Action{Bb-Codings-CsMethodDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Method``1(``0,System.String,System.Action{Bb.Codings.CsMethodDeclaration})')
  - [Method\`\`1(self,methodName,type,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-String,System-Action{Bb-Codings-CsMethodDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Method``1(``0,System.String,System.String,System.Action{Bb.Codings.CsMethodDeclaration})')
  - [Method\`\`1(self,methodName,type,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-Type,System-Action{Bb-Codings-CsMethodDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Method``1(``0,System.String,System.Type,System.Action{Bb.Codings.CsMethodDeclaration})')
  - [Method\`\`1(self,methodName,type,action)](#M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax,System-Action{Bb-Codings-CsMethodDeclaration}- 'Bb.Codings.CSMemberDeclarationHelper.Method``1(``0,System.String,Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax,System.Action{Bb.Codings.CsMethodDeclaration})')
- [CSNamespace](#T-Bb-Codings-CSNamespace 'Bb.Codings.CSNamespace')
  - [#ctor(name)](#M-Bb-Codings-CSNamespace-#ctor-System-String- 'Bb.Codings.CSNamespace.#ctor(System.String)')
  - [Class(name)](#M-Bb-Codings-CSNamespace-Class-System-String,System-Action{Bb-Codings-CsClassDeclaration}- 'Bb.Codings.CSNamespace.Class(System.String,System.Action{Bb.Codings.CsClassDeclaration})')
  - [Class(name)](#M-Bb-Codings-CSNamespace-Class-System-String- 'Bb.Codings.CSNamespace.Class(System.String)')
- [CSUsing](#T-Bb-Codings-CSUsing 'Bb.Codings.CSUsing')
  - [#ctor(namespaceOrType)](#M-Bb-Codings-CSUsing-#ctor-System-String- 'Bb.Codings.CSUsing.#ctor(System.String)')
  - [Alias](#P-Bb-Codings-CSUsing-Alias 'Bb.Codings.CSUsing.Alias')
  - [IsGlobal](#P-Bb-Codings-CSUsing-IsGlobal 'Bb.Codings.CSUsing.IsGlobal')
  - [IsStatic](#P-Bb-Codings-CSUsing-IsStatic 'Bb.Codings.CSUsing.IsStatic')
  - [NamespaceOrType](#P-Bb-Codings-CSUsing-NamespaceOrType 'Bb.Codings.CSUsing.NamespaceOrType')
- [CSharpArtifact](#T-Bb-Codings-CSharpArtifact 'Bb.Codings.CSharpArtifact')
  - [#ctor()](#M-Bb-Codings-CSharpArtifact-#ctor 'Bb.Codings.CSharpArtifact.#ctor')
  - [#ctor(name,projectPath)](#M-Bb-Codings-CSharpArtifact-#ctor-System-String,System-String- 'Bb.Codings.CSharpArtifact.#ctor(System.String,System.String)')
  - [Tree](#P-Bb-Codings-CSharpArtifact-Tree 'Bb.Codings.CSharpArtifact.Tree')
  - [Build()](#M-Bb-Codings-CSharpArtifact-Build 'Bb.Codings.CSharpArtifact.Build')
  - [Code()](#M-Bb-Codings-CSharpArtifact-Code 'Bb.Codings.CSharpArtifact.Code')
  - [Namespace(namespace,action)](#M-Bb-Codings-CSharpArtifact-Namespace-System-String,System-Action{Bb-Codings-CSNamespace}- 'Bb.Codings.CSharpArtifact.Namespace(System.String,System.Action{Bb.Codings.CSNamespace})')
  - [Save()](#M-Bb-Codings-CSharpArtifact-Save 'Bb.Codings.CSharpArtifact.Save')
  - [Save(path)](#M-Bb-Codings-CSharpArtifact-Save-System-String- 'Bb.Codings.CSharpArtifact.Save(System.String)')
  - [ToString()](#M-Bb-Codings-CSharpArtifact-ToString 'Bb.Codings.CSharpArtifact.ToString')
  - [Using(usings,action)](#M-Bb-Codings-CSharpArtifact-Using-System-String,System-Action{Bb-Codings-CSUsing}- 'Bb.Codings.CSharpArtifact.Using(System.String,System.Action{Bb.Codings.CSUsing})')
  - [Using(usings,action)](#M-Bb-Codings-CSharpArtifact-Using-Bb-Codings-CSUsing- 'Bb.Codings.CSharpArtifact.Using(Bb.Codings.CSUsing)')
  - [UsingStatics(usings)](#M-Bb-Codings-CSharpArtifact-UsingStatics-System-String[]- 'Bb.Codings.CSharpArtifact.UsingStatics(System.String[])')
  - [Usings(usings)](#M-Bb-Codings-CSharpArtifact-Usings-System-Type[]- 'Bb.Codings.CSharpArtifact.Usings(System.Type[])')
  - [Usings(usings)](#M-Bb-Codings-CSharpArtifact-Usings-System-String[]- 'Bb.Codings.CSharpArtifact.Usings(System.String[])')
  - [Usings(usings,action)](#M-Bb-Codings-CSharpArtifact-Usings-System-String[],System-Action{Bb-Codings-CSUsing}- 'Bb.Codings.CSharpArtifact.Usings(System.String[],System.Action{Bb.Codings.CSUsing})')
- [CSharpNode](#T-Bb-Codings-CSharpNode 'Bb.Codings.CSharpNode')
  - [#ctor()](#M-Bb-Codings-CSharpNode-#ctor 'Bb.Codings.CSharpNode.#ctor')
  - [Name(name)](#M-Bb-Codings-CSharpNode-Name-System-String- 'Bb.Codings.CSharpNode.Name(System.String)')
  - [Token(kind)](#M-Bb-Codings-CSharpNode-Token-Microsoft-CodeAnalysis-CSharp-SyntaxKind- 'Bb.Codings.CSharpNode.Token(Microsoft.CodeAnalysis.CSharp.SyntaxKind)')
- [CodeHelper](#T-Bb-Codings-CodeHelper 'Bb.Codings.CodeHelper')
  - [ElementAccess(expression,arguments)](#M-Bb-Codings-CodeHelper-ElementAccess-Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax,Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax[]- 'Bb.Codings.CodeHelper.ElementAccess(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax,Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[])')
  - [Identifier(self)](#M-Bb-Codings-CodeHelper-Identifier-System-String- 'Bb.Codings.CodeHelper.Identifier(System.String)')
  - [Identifiers(self,self2,items)](#M-Bb-Codings-CodeHelper-Identifiers-System-String,System-String,System-String[]- 'Bb.Codings.CodeHelper.Identifiers(System.String,System.String,System.String[])')
  - [ToBlock(self)](#M-Bb-Codings-CodeHelper-ToBlock-Microsoft-CodeAnalysis-SyntaxList{Microsoft-CodeAnalysis-CSharp-Syntax-StatementSyntax}- 'Bb.Codings.CodeHelper.ToBlock(Microsoft.CodeAnalysis.SyntaxList{Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax})')
  - [ToToken(self)](#M-Bb-Codings-CodeHelper-ToToken-Microsoft-CodeAnalysis-CSharp-SyntaxKind- 'Bb.Codings.CodeHelper.ToToken(Microsoft.CodeAnalysis.CSharp.SyntaxKind)')
- [ConstraintVersion](#T-Bb-Nugets-Versions-ConstraintVersion 'Bb.Nugets.Versions.ConstraintVersion')
  - [#ctor()](#M-Bb-Nugets-Versions-ConstraintVersion-#ctor 'Bb.Nugets.Versions.ConstraintVersion.#ctor')
  - [#ctor(count,version,leftConstraint)](#M-Bb-Nugets-Versions-ConstraintVersion-#ctor-System-Int32,System-Version,Bb-Nugets-Versions-ContraintEnum,Bb-Nugets-Versions-ContraintEnum- 'Bb.Nugets.Versions.ConstraintVersion.#ctor(System.Int32,System.Version,Bb.Nugets.Versions.ContraintEnum,Bb.Nugets.Versions.ContraintEnum)')
  - [Version](#F-Bb-Nugets-Versions-ConstraintVersion-Version 'Bb.Nugets.Versions.ConstraintVersion.Version')
  - [Child](#P-Bb-Nugets-Versions-ConstraintVersion-Child 'Bb.Nugets.Versions.ConstraintVersion.Child')
  - [Description](#P-Bb-Nugets-Versions-ConstraintVersion-Description 'Bb.Nugets.Versions.ConstraintVersion.Description')
  - [Failed](#P-Bb-Nugets-Versions-ConstraintVersion-Failed 'Bb.Nugets.Versions.ConstraintVersion.Failed')
  - [Append(next)](#M-Bb-Nugets-Versions-ConstraintVersion-Append-Bb-Nugets-Versions-ConstraintVersion- 'Bb.Nugets.Versions.ConstraintVersion.Append(Bb.Nugets.Versions.ConstraintVersion)')
  - [Evaluate(versionToCompare)](#M-Bb-Nugets-Versions-ConstraintVersion-Evaluate-System-Version- 'Bb.Nugets.Versions.ConstraintVersion.Evaluate(System.Version)')
- [ContraintEnum](#T-Bb-Nugets-Versions-ContraintEnum 'Bb.Nugets.Versions.ContraintEnum')
  - [Equal](#F-Bb-Nugets-Versions-ContraintEnum-Equal 'Bb.Nugets.Versions.ContraintEnum.Equal')
- [CsClassDeclaration](#T-Bb-Codings-CsClassDeclaration 'Bb.Codings.CsClassDeclaration')
  - [Base(baseNames)](#M-Bb-Codings-CsClassDeclaration-Base-System-String[]- 'Bb.Codings.CsClassDeclaration.Base(System.String[])')
  - [Ctor()](#M-Bb-Codings-CsClassDeclaration-Ctor 'Bb.Codings.CsClassDeclaration.Ctor')
  - [Ctor(action)](#M-Bb-Codings-CsClassDeclaration-Ctor-System-Action{Bb-Codings-CsCtorDeclaration}- 'Bb.Codings.CsClassDeclaration.Ctor(System.Action{Bb.Codings.CsCtorDeclaration})')
  - [Field(fieldName,type,action)](#M-Bb-Codings-CsClassDeclaration-Field-System-String,System-String,System-Action{Bb-Codings-CsFieldDeclaration}- 'Bb.Codings.CsClassDeclaration.Field(System.String,System.String,System.Action{Bb.Codings.CsFieldDeclaration})')
  - [Property(propertyName,type,action)](#M-Bb-Codings-CsClassDeclaration-Property-System-String,System-String,System-Action{Bb-Codings-CsPropertyDeclaration}- 'Bb.Codings.CsClassDeclaration.Property(System.String,System.String,System.Action{Bb.Codings.CsPropertyDeclaration})')
  - [Property(propertyName,type)](#M-Bb-Codings-CsClassDeclaration-Property-System-String,System-String- 'Bb.Codings.CsClassDeclaration.Property(System.String,System.String)')
- [CsFieldDeclaration](#T-Bb-Codings-CsFieldDeclaration 'Bb.Codings.CsFieldDeclaration')
  - [#ctor(name,typeName)](#M-Bb-Codings-CsFieldDeclaration-#ctor-System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax- 'Bb.Codings.CsFieldDeclaration.#ctor(System.String,Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax)')
  - [#ctor(name,typeName)](#M-Bb-Codings-CsFieldDeclaration-#ctor-System-String,System-String- 'Bb.Codings.CsFieldDeclaration.#ctor(System.String,System.String)')
  - [ReturnType(type)](#M-Bb-Codings-CsFieldDeclaration-ReturnType-System-String- 'Bb.Codings.CsFieldDeclaration.ReturnType(System.String)')
  - [ReturnType(type)](#M-Bb-Codings-CsFieldDeclaration-ReturnType-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax- 'Bb.Codings.CsFieldDeclaration.ReturnType(Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax)')
  - [ReturnType(type)](#M-Bb-Codings-CsFieldDeclaration-ReturnType-System-Type- 'Bb.Codings.CsFieldDeclaration.ReturnType(System.Type)')
  - [SetInitialValue(value)](#M-Bb-Codings-CsFieldDeclaration-SetInitialValue-System-Object- 'Bb.Codings.CsFieldDeclaration.SetInitialValue(System.Object)')
- [CsParameterDeclaration](#T-Bb-Codings-CsParameterDeclaration 'Bb.Codings.CsParameterDeclaration')
  - [Way(way)](#M-Bb-Codings-CsParameterDeclaration-Way-Bb-Codings-ParameterWay- 'Bb.Codings.CsParameterDeclaration.Way(Bb.Codings.ParameterWay)')
- [CsPropertyDeclaration](#T-Bb-Codings-CsPropertyDeclaration 'Bb.Codings.CsPropertyDeclaration')
  - [#ctor(name,typeName)](#M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,System-String- 'Bb.Codings.CsPropertyDeclaration.#ctor(System.String,System.String)')
  - [#ctor(name,type)](#M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,System-Type- 'Bb.Codings.CsPropertyDeclaration.#ctor(System.String,System.Type)')
  - [#ctor(name,type)](#M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax- 'Bb.Codings.CsPropertyDeclaration.#ctor(System.String,Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax)')
  - [AutoGet()](#M-Bb-Codings-CsPropertyDeclaration-AutoGet 'Bb.Codings.CsPropertyDeclaration.AutoGet')
  - [AutoSet()](#M-Bb-Codings-CsPropertyDeclaration-AutoSet 'Bb.Codings.CsPropertyDeclaration.AutoSet')
  - [BodyGet(action)](#M-Bb-Codings-CsPropertyDeclaration-BodyGet-System-Action{Bb-Codings-CodeBlock}- 'Bb.Codings.CsPropertyDeclaration.BodyGet(System.Action{Bb.Codings.CodeBlock})')
  - [BodySet(action)](#M-Bb-Codings-CsPropertyDeclaration-BodySet-System-Action{Bb-Codings-CodeBlock}- 'Bb.Codings.CsPropertyDeclaration.BodySet(System.Action{Bb.Codings.CodeBlock})')
  - [ReturnType(type)](#M-Bb-Codings-CsPropertyDeclaration-ReturnType-System-String- 'Bb.Codings.CsPropertyDeclaration.ReturnType(System.String)')
  - [ReturnType(type)](#M-Bb-Codings-CsPropertyDeclaration-ReturnType-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax- 'Bb.Codings.CsPropertyDeclaration.ReturnType(Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax)')
  - [ReturnType(type)](#M-Bb-Codings-CsPropertyDeclaration-ReturnType-System-Type- 'Bb.Codings.CsPropertyDeclaration.ReturnType(System.Type)')
- [DependencyAssemblyNameResolver](#T-Bb-Builds-DependencyAssemblyNameResolver 'Bb.Builds.DependencyAssemblyNameResolver')
  - [Resolve(file,references,download)](#M-Bb-Builds-DependencyAssemblyNameResolver-Resolve-System-IO-FileInfo,Bb-Builds-AssemblyReferences- 'Bb.Builds.DependencyAssemblyNameResolver.Resolve(System.IO.FileInfo,Bb.Builds.AssemblyReferences)')
- [DocXml](#T-Bb-Codings-DocXml 'Bb.Codings.DocXml')
  - [EmptyLine](#P-Bb-Codings-DocXml-EmptyLine 'Bb.Codings.DocXml.EmptyLine')
- [FileCode](#T-Bb-Compilers-FileCode 'Bb.Compilers.FileCode')
- [FileNugetFolder](#T-Bb-Nugets-FileNugetFolder 'Bb.Nugets.FileNugetFolder')
  - [#ctor(dir)](#M-Bb-Nugets-FileNugetFolder-#ctor-System-IO-DirectoryInfo- 'Bb.Nugets.FileNugetFolder.#ctor(System.IO.DirectoryInfo)')
  - [Last(version)](#M-Bb-Nugets-FileNugetFolder-Last 'Bb.Nugets.FileNugetFolder.Last')
  - [Refresh()](#M-Bb-Nugets-FileNugetFolder-Refresh 'Bb.Nugets.FileNugetFolder.Refresh')
  - [Resolve(version)](#M-Bb-Nugets-FileNugetFolder-Resolve-System-Version,System-Boolean- 'Bb.Nugets.FileNugetFolder.Resolve(System.Version,System.Boolean)')
- [FileNugetFolders](#T-Bb-Nugets-FileNugetFolders 'Bb.Nugets.FileNugetFolders')
  - [#ctor(path,host)](#M-Bb-Nugets-FileNugetFolders-#ctor-System-String,System-String[]- 'Bb.Nugets.FileNugetFolders.#ctor(System.String,System.String[])')
  - [Hosts](#P-Bb-Nugets-FileNugetFolders-Hosts 'Bb.Nugets.FileNugetFolders.Hosts')
  - [Parent](#P-Bb-Nugets-FileNugetFolders-Parent 'Bb.Nugets.FileNugetFolders.Parent')
  - [Path](#P-Bb-Nugets-FileNugetFolders-Path 'Bb.Nugets.FileNugetFolders.Path')
  - [WithResolver](#P-Bb-Nugets-FileNugetFolders-WithResolver 'Bb.Nugets.FileNugetFolders.WithResolver')
  - [Refresh()](#M-Bb-Nugets-FileNugetFolders-Refresh 'Bb.Nugets.FileNugetFolders.Refresh')
  - [Resolve(name)](#M-Bb-Nugets-FileNugetFolders-Resolve-System-String- 'Bb.Nugets.FileNugetFolders.Resolve(System.String)')
  - [Resolve(name,version)](#M-Bb-Nugets-FileNugetFolders-Resolve-System-String,System-Version,System-Boolean- 'Bb.Nugets.FileNugetFolders.Resolve(System.String,System.Version,System.Boolean)')
  - [Resolve(item)](#M-Bb-Nugets-FileNugetFolders-Resolve-System-ValueTuple{System-String,System-Version},System-Boolean- 'Bb.Nugets.FileNugetFolders.Resolve(System.ValueTuple{System.String,System.Version},System.Boolean)')
  - [ResolveAll(item)](#M-Bb-Nugets-FileNugetFolders-ResolveAll-System-ValueTuple{System-String,System-Version}- 'Bb.Nugets.FileNugetFolders.ResolveAll(System.ValueTuple{System.String,System.Version})')
  - [ResolveAll(item)](#M-Bb-Nugets-FileNugetFolders-ResolveAll-System-String- 'Bb.Nugets.FileNugetFolders.ResolveAll(System.String)')
  - [TryToDownload(dependency)](#M-Bb-Nugets-FileNugetFolders-TryToDownload-Bb-Nugets-NugetDependency- 'Bb.Nugets.FileNugetFolders.TryToDownload(Bb.Nugets.NugetDependency)')
  - [TryToDownload(item)](#M-Bb-Nugets-FileNugetFolders-TryToDownload-System-String,System-Version- 'Bb.Nugets.FileNugetFolders.TryToDownload(System.String,System.Version)')
- [GeneratorExtension](#T-Bb-Compilers-GeneratorExtension 'Bb.Compilers.GeneratorExtension')
  - [EmitToArray(compilation)](#M-Bb-Compilers-GeneratorExtension-EmitToArray-Microsoft-CodeAnalysis-Compilation,Microsoft-CodeAnalysis-DiagnosticSeverity,Bb-Compilers-CompilerException@- 'Bb.Compilers.GeneratorExtension.EmitToArray(Microsoft.CodeAnalysis.Compilation,Microsoft.CodeAnalysis.DiagnosticSeverity,Bb.Compilers.CompilerException@)')
  - [Map(self)](#M-Bb-Compilers-GeneratorExtension-Map-Microsoft-CodeAnalysis-Diagnostic- 'Bb.Compilers.GeneratorExtension.Map(Microsoft.CodeAnalysis.Diagnostic)')
  - [Map(location)](#M-Bb-Compilers-GeneratorExtension-Map-Microsoft-CodeAnalysis-Location- 'Bb.Compilers.GeneratorExtension.Map(Microsoft.CodeAnalysis.Location)')
- [Helper](#T-Bb-Helper 'Bb.Helper')
  - [ResolveVersion(text)](#M-Bb-Helper-ResolveVersion-System-String- 'Bb.Helper.ResolveVersion(System.String)')
- [LocalFileNugetVersion](#T-Bb-Nugets-LocalFileNugetVersion 'Bb.Nugets.LocalFileNugetVersion')
  - [#ctor(dir)](#M-Bb-Nugets-LocalFileNugetVersion-#ctor-System-IO-DirectoryInfo- 'Bb.Nugets.LocalFileNugetVersion.#ctor(System.IO.DirectoryInfo)')
  - [Empty](#P-Bb-Nugets-LocalFileNugetVersion-Empty 'Bb.Nugets.LocalFileNugetVersion.Empty')
  - [Metadata](#P-Bb-Nugets-LocalFileNugetVersion-Metadata 'Bb.Nugets.LocalFileNugetVersion.Metadata')
  - [Name](#P-Bb-Nugets-LocalFileNugetVersion-Name 'Bb.Nugets.LocalFileNugetVersion.Name')
  - [Parent](#P-Bb-Nugets-LocalFileNugetVersion-Parent 'Bb.Nugets.LocalFileNugetVersion.Parent')
  - [References](#P-Bb-Nugets-LocalFileNugetVersion-References 'Bb.Nugets.LocalFileNugetVersion.References')
  - [Version](#P-Bb-Nugets-LocalFileNugetVersion-Version 'Bb.Nugets.LocalFileNugetVersion.Version')
- [NamedNode](#T-Bb-Codings-NamedNode 'Bb.Codings.NamedNode')
- [NugetCompressedDocument](#T-Bb-Nugets-NugetCompressedDocument 'Bb.Nugets.NugetCompressedDocument')
  - [Create(path,targetFolder)](#M-Bb-Nugets-NugetCompressedDocument-Create-System-String,System-String- 'Bb.Nugets.NugetCompressedDocument.Create(System.String,System.String)')
  - [Create(path,targetFolder)](#M-Bb-Nugets-NugetCompressedDocument-Create-System-IO-FileInfo,System-IO-DirectoryInfo- 'Bb.Nugets.NugetCompressedDocument.Create(System.IO.FileInfo,System.IO.DirectoryInfo)')
  - [Load()](#M-Bb-Nugets-NugetCompressedDocument-Load 'Bb.Nugets.NugetCompressedDocument.Load')
- [NugetController](#T-Bb-Nugets-NugetController 'Bb.Nugets.NugetController')
  - [#ctor()](#M-Bb-Nugets-NugetController-#ctor 'Bb.Nugets.NugetController.#ctor')
  - [IsFreeBSDPlatform](#F-Bb-Nugets-NugetController-IsFreeBSDPlatform 'Bb.Nugets.NugetController.IsFreeBSDPlatform')
  - [IsLinuxPlatform](#F-Bb-Nugets-NugetController-IsLinuxPlatform 'Bb.Nugets.NugetController.IsLinuxPlatform')
  - [IsOsxPlatform](#F-Bb-Nugets-NugetController-IsOsxPlatform 'Bb.Nugets.NugetController.IsOsxPlatform')
  - [IsWindowsPlatform](#F-Bb-Nugets-NugetController-IsWindowsPlatform 'Bb.Nugets.NugetController.IsWindowsPlatform')
  - [Intercept](#P-Bb-Nugets-NugetController-Intercept 'Bb.Nugets.NugetController.Intercept')
  - [AddDefaultLinuxFolderIf(nugetHosts)](#M-Bb-Nugets-NugetController-AddDefaultLinuxFolderIf-System-String[]- 'Bb.Nugets.NugetController.AddDefaultLinuxFolderIf(System.String[])')
  - [AddDefaultWindowsFolderIf(nugetHosts)](#M-Bb-Nugets-NugetController-AddDefaultWindowsFolderIf-System-String[]- 'Bb.Nugets.NugetController.AddDefaultWindowsFolderIf(System.String[])')
  - [AddFolder(path,nugetHosts)](#M-Bb-Nugets-NugetController-AddFolder-System-String,System-String[]- 'Bb.Nugets.NugetController.AddFolder(System.String,System.String[])')
  - [AddFolderIf(filter,path,nugetHosts)](#M-Bb-Nugets-NugetController-AddFolderIf-System-Boolean,System-String,System-String[]- 'Bb.Nugets.NugetController.AddFolderIf(System.Boolean,System.String,System.String[])')
  - [AddPackage(nugetName)](#M-Bb-Nugets-NugetController-AddPackage-System-String- 'Bb.Nugets.NugetController.AddPackage(System.String)')
  - [AddPackage(nugetName,versionMin)](#M-Bb-Nugets-NugetController-AddPackage-System-String,System-String- 'Bb.Nugets.NugetController.AddPackage(System.String,System.String)')
  - [AddPackage(nugetName,version)](#M-Bb-Nugets-NugetController-AddPackage-System-String,System-Version- 'Bb.Nugets.NugetController.AddPackage(System.String,System.Version)')
  - [CopyFolderFrom(source)](#M-Bb-Nugets-NugetController-CopyFolderFrom-Bb-Nugets-NugetController- 'Bb.Nugets.NugetController.CopyFolderFrom(Bb.Nugets.NugetController)')
  - [CopyPackagesFrom(source)](#M-Bb-Nugets-NugetController-CopyPackagesFrom-Bb-Nugets-NugetController- 'Bb.Nugets.NugetController.CopyPackagesFrom(Bb.Nugets.NugetController)')
  - [Resolve(name)](#M-Bb-Nugets-NugetController-Resolve-System-String- 'Bb.Nugets.NugetController.Resolve(System.String)')
  - [ResolveAssemblyName(assemblyName,framework)](#M-Bb-Nugets-NugetController-ResolveAssemblyName-System-String,Bb-Builds-FrameworkVersion,System-Func{Bb-Builds-ReferenceType,System-Collections-Generic-List{Bb-Builds-Reference},Bb-Builds-Reference}- 'Bb.Nugets.NugetController.ResolveAssemblyName(System.String,Bb.Builds.FrameworkVersion,System.Func{Bb.Builds.ReferenceType,System.Collections.Generic.List{Bb.Builds.Reference},Bb.Builds.Reference})')
  - [TryToDownload(item)](#M-Bb-Nugets-NugetController-TryToDownload-Bb-Builds-FrameworkVersion,System-String,System-Version- 'Bb.Nugets.NugetController.TryToDownload(Bb.Builds.FrameworkVersion,System.String,System.Version)')
- [NugetDependency](#T-Bb-Nugets-NugetDependency 'Bb.Nugets.NugetDependency')
  - [#ctor(id,versionMin,versionMax,parent,nuget)](#M-Bb-Nugets-NugetDependency-#ctor-System-String,System-Version,System-Version,Bb-Nugets-NugetGroupDependency,Bb-Nugets-NugetDocument- 'Bb.Nugets.NugetDependency.#ctor(System.String,System.Version,System.Version,Bb.Nugets.NugetGroupDependency,Bb.Nugets.NugetDocument)')
  - [#ctor(id,version,parent,nuget)](#M-Bb-Nugets-NugetDependency-#ctor-System-String,System-Version,Bb-Nugets-NugetGroupDependency,Bb-Nugets-NugetDocument- 'Bb.Nugets.NugetDependency.#ctor(System.String,System.Version,Bb.Nugets.NugetGroupDependency,Bb.Nugets.NugetDocument)')
  - [ConstraintVersion](#P-Bb-Nugets-NugetDependency-ConstraintVersion 'Bb.Nugets.NugetDependency.ConstraintVersion')
  - [Group](#P-Bb-Nugets-NugetDependency-Group 'Bb.Nugets.NugetDependency.Group')
  - [Id](#P-Bb-Nugets-NugetDependency-Id 'Bb.Nugets.NugetDependency.Id')
  - [Nuget](#P-Bb-Nugets-NugetDependency-Nuget 'Bb.Nugets.NugetDependency.Nuget')
- [NugetDocument](#T-Bb-Nugets-NugetDocument 'Bb.Nugets.NugetDocument')
  - [Description](#P-Bb-Nugets-NugetDocument-Description 'Bb.Nugets.NugetDocument.Description')
  - [Id](#P-Bb-Nugets-NugetDocument-Id 'Bb.Nugets.NugetDocument.Id')
  - [IsMultipleTarget](#P-Bb-Nugets-NugetDocument-IsMultipleTarget 'Bb.Nugets.NugetDocument.IsMultipleTarget')
  - [References](#P-Bb-Nugets-NugetDocument-References 'Bb.Nugets.NugetDocument.References')
  - [Repository](#P-Bb-Nugets-NugetDocument-Repository 'Bb.Nugets.NugetDocument.Repository')
  - [Version](#P-Bb-Nugets-NugetDocument-Version 'Bb.Nugets.NugetDocument.Version')
  - [GroupDependencies()](#M-Bb-Nugets-NugetDocument-GroupDependencies 'Bb.Nugets.NugetDocument.GroupDependencies')
  - [GroupDependencies(framework)](#M-Bb-Nugets-NugetDocument-GroupDependencies-Bb-Analysis-FrameworkKey,Bb-Builds-FrameworkVersion- 'Bb.Nugets.NugetDocument.GroupDependencies(Bb.Analysis.FrameworkKey,Bb.Builds.FrameworkVersion)')
  - [GroupDependencies(framework)](#M-Bb-Nugets-NugetDocument-GroupDependencies-Bb-Analysis-FrameworkKey- 'Bb.Nugets.NugetDocument.GroupDependencies(Bb.Analysis.FrameworkKey)')
  - [ResolveNugetDocument(path)](#M-Bb-Nugets-NugetDocument-ResolveNugetDocument-System-IO-DirectoryInfo- 'Bb.Nugets.NugetDocument.ResolveNugetDocument(System.IO.DirectoryInfo)')
  - [ResolveNugetDocument(path)](#M-Bb-Nugets-NugetDocument-ResolveNugetDocument-System-IO-FileInfo- 'Bb.Nugets.NugetDocument.ResolveNugetDocument(System.IO.FileInfo)')
- [NugetGroupDependency](#T-Bb-Nugets-NugetGroupDependency 'Bb.Nugets.NugetGroupDependency')
  - [Nuget](#P-Bb-Nugets-NugetGroupDependency-Nuget 'Bb.Nugets.NugetGroupDependency.Nuget')
  - [TargetFramework](#P-Bb-Nugets-NugetGroupDependency-TargetFramework 'Bb.Nugets.NugetGroupDependency.TargetFramework')
  - [Dependencies()](#M-Bb-Nugets-NugetGroupDependency-Dependencies 'Bb.Nugets.NugetGroupDependency.Dependencies')
- [NugetRepository](#T-Bb-Nugets-NugetRepository 'Bb.Nugets.NugetRepository')
  - [Branch](#P-Bb-Nugets-NugetRepository-Branch 'Bb.Nugets.NugetRepository.Branch')
  - [Commit](#P-Bb-Nugets-NugetRepository-Commit 'Bb.Nugets.NugetRepository.Commit')
  - [Type](#P-Bb-Nugets-NugetRepository-Type 'Bb.Nugets.NugetRepository.Type')
  - [Url](#P-Bb-Nugets-NugetRepository-Url 'Bb.Nugets.NugetRepository.Url')
- [ObjectResolverVisitor](#T-Bb-Compilers-ObjectResolverVisitor 'Bb.Compilers.ObjectResolverVisitor')
  - [GetObjects(tree)](#M-Bb-Compilers-ObjectResolverVisitor-GetObjects-Microsoft-CodeAnalysis-SyntaxTree- 'Bb.Compilers.ObjectResolverVisitor.GetObjects(Microsoft.CodeAnalysis.SyntaxTree)')
- [ProjectRoslynBuilderHelper](#T-Bb-Builds-ProjectRoslynBuilderHelper 'Bb.Builds.ProjectRoslynBuilderHelper')
  - [CreateCsharpBuild(path,debug,configureCompilation)](#M-Bb-Builds-ProjectRoslynBuilderHelper-CreateCsharpBuild-System-String,System-Boolean,System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}- 'Bb.Builds.ProjectRoslynBuilderHelper.CreateCsharpBuild(System.String,System.Boolean,System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions})')
  - [CreateCsharpBuild(path,debug,configureCompilation)](#M-Bb-Builds-ProjectRoslynBuilderHelper-CreateCsharpBuild-System-IO-FileInfo,System-Boolean,System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}- 'Bb.Builds.ProjectRoslynBuilderHelper.CreateCsharpBuild(System.IO.FileInfo,System.Boolean,System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions})')
- [ReferenceResolver](#T-Bb-Builds-ReferenceResolver 'Bb.Builds.ReferenceResolver')
  - [#ctor(assemblies)](#M-Bb-Builds-ReferenceResolver-#ctor-Bb-Builds-AssemblyReferences,Bb-Analysis-DiagTraces-ScriptDiagnostics- 'Bb.Builds.ReferenceResolver.#ctor(Bb.Builds.AssemblyReferences,Bb.Analysis.DiagTraces.ScriptDiagnostics)')
  - [ResolveMissingAssemblies](#P-Bb-Builds-ReferenceResolver-ResolveMissingAssemblies 'Bb.Builds.ReferenceResolver.ResolveMissingAssemblies')
  - [Equals(other)](#M-Bb-Builds-ReferenceResolver-Equals-System-Object- 'Bb.Builds.ReferenceResolver.Equals(System.Object)')
  - [GetHashCode()](#M-Bb-Builds-ReferenceResolver-GetHashCode 'Bb.Builds.ReferenceResolver.GetHashCode')
- [RoslynActivityProvider](#T-Bb-Metrology-RoslynActivityProvider 'Bb.Metrology.RoslynActivityProvider')
  - [#cctor()](#M-Bb-Metrology-RoslynActivityProvider-#cctor 'Bb.Metrology.RoslynActivityProvider.#cctor')
  - [AddBaggage(key,value)](#M-Bb-Metrology-RoslynActivityProvider-AddBaggage-System-String,System-String- 'Bb.Metrology.RoslynActivityProvider.AddBaggage(System.String,System.String)')
  - [AddEvent(eventName,tags)](#M-Bb-Metrology-RoslynActivityProvider-AddEvent-System-String,System-ValueTuple{System-String,System-String}[]- 'Bb.Metrology.RoslynActivityProvider.AddEvent(System.String,System.ValueTuple{System.String,System.String}[])')
  - [AddProperty(key,value)](#M-Bb-Metrology-RoslynActivityProvider-AddProperty-System-String,System-Object- 'Bb.Metrology.RoslynActivityProvider.AddProperty(System.String,System.Object)')
  - [AddTag(key,value)](#M-Bb-Metrology-RoslynActivityProvider-AddTag-System-String,System-Object- 'Bb.Metrology.RoslynActivityProvider.AddTag(System.String,System.Object)')
  - [CreateActivity(name,kind)](#M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind- 'Bb.Metrology.RoslynActivityProvider.CreateActivity(System.String,System.Diagnostics.ActivityKind)')
  - [CreateActivity(name,kind,parentContext,tags,links,idFormat)](#M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-Diagnostics-ActivityIdFormat- 'Bb.Metrology.RoslynActivityProvider.CreateActivity(System.String,System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.Diagnostics.ActivityIdFormat)')
  - [CreateActivity(name,kind,parentId,tags,links,idFormat)](#M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind,System-String,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-Diagnostics-ActivityIdFormat- 'Bb.Metrology.RoslynActivityProvider.CreateActivity(System.String,System.Diagnostics.ActivityKind,System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.Diagnostics.ActivityIdFormat)')
  - [Set(action)](#M-Bb-Metrology-RoslynActivityProvider-Set-System-Action{System-Diagnostics-Activity}- 'Bb.Metrology.RoslynActivityProvider.Set(System.Action{System.Diagnostics.Activity})')
  - [StartActivity(name,kind)](#M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind- 'Bb.Metrology.RoslynActivityProvider.StartActivity(System.String,System.Diagnostics.ActivityKind)')
  - [StartActivity(name,kind,parentContext,tags,links,startTime)](#M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset- 'Bb.Metrology.RoslynActivityProvider.StartActivity(System.String,System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.DateTimeOffset)')
  - [StartActivity(name,kind,parentId,tags,links,startTime)](#M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind,System-String,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset- 'Bb.Metrology.RoslynActivityProvider.StartActivity(System.String,System.Diagnostics.ActivityKind,System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.DateTimeOffset)')
  - [StartActivity(kind,parentContext,tags,links,startTime,name)](#M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset,System-String- 'Bb.Metrology.RoslynActivityProvider.StartActivity(System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.DateTimeOffset,System.String)')
- [RoslynCompiler](#T-Bb-Compilers-RoslynCompiler 'Bb.Compilers.RoslynCompiler')
  - [AssemblyAttributes](#P-Bb-Compilers-RoslynCompiler-AssemblyAttributes 'Bb.Compilers.RoslynCompiler.AssemblyAttributes')
  - [Usings](#P-Bb-Compilers-RoslynCompiler-Usings 'Bb.Compilers.RoslynCompiler.Usings')
  - [AddCodeSource(sources)](#M-Bb-Compilers-RoslynCompiler-AddCodeSource-Bb-Builds-SourceCodes- 'Bb.Compilers.RoslynCompiler.AddCodeSource(Bb.Builds.SourceCodes)')
  - [AddCodeSource(source,path)](#M-Bb-Compilers-RoslynCompiler-AddCodeSource-System-String,System-String- 'Bb.Compilers.RoslynCompiler.AddCodeSource(System.String,System.String)')
  - [SetOutput(outputPah)](#M-Bb-Compilers-RoslynCompiler-SetOutput-System-String- 'Bb.Compilers.RoslynCompiler.SetOutput(System.String)')
- [RoslynExtensions](#T-Bb-Codings-RoslynExtensions 'Bb.Codings.RoslynExtensions')
  - [AddAfterEach\`\`1()](#M-Bb-Codings-RoslynExtensions-AddAfterEach``1-System-Collections-Generic-IEnumerable{``0},``0- 'Bb.Codings.RoslynExtensions.AddAfterEach``1(System.Collections.Generic.IEnumerable{``0},``0)')
- [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')
  - [Empty](#P-Bb-Builds-SourceCode-Empty 'Bb.Builds.SourceCode.Empty')
  - [File](#P-Bb-Builds-SourceCode-File 'Bb.Builds.SourceCode.File')
  - [Filename](#P-Bb-Builds-SourceCode-Filename 'Bb.Builds.SourceCode.Filename')
  - [IsDeleted](#P-Bb-Builds-SourceCode-IsDeleted 'Bb.Builds.SourceCode.IsDeleted')
  - [IsGeneratedSource](#P-Bb-Builds-SourceCode-IsGeneratedSource 'Bb.Builds.SourceCode.IsGeneratedSource')
  - [IsMemorySource](#P-Bb-Builds-SourceCode-IsMemorySource 'Bb.Builds.SourceCode.IsMemorySource')
  - [Name](#P-Bb-Builds-SourceCode-Name 'Bb.Builds.SourceCode.Name')
  - [Source](#P-Bb-Builds-SourceCode-Source 'Bb.Builds.SourceCode.Source')
  - [GetFromFile(filename,name)](#M-Bb-Builds-SourceCode-GetFromFile-System-String,System-String- 'Bb.Builds.SourceCode.GetFromFile(System.String,System.String)')
  - [GetFromFile(file,name)](#M-Bb-Builds-SourceCode-GetFromFile-System-IO-FileInfo,System-String- 'Bb.Builds.SourceCode.GetFromFile(System.IO.FileInfo,System.String)')
  - [GetFromText(payload,name)](#M-Bb-Builds-SourceCode-GetFromText-System-Text-StringBuilder,System-String- 'Bb.Builds.SourceCode.GetFromText(System.Text.StringBuilder,System.String)')
  - [GetFromText(file,payload,name)](#M-Bb-Builds-SourceCode-GetFromText-System-IO-FileInfo,System-String,System-String- 'Bb.Builds.SourceCode.GetFromText(System.IO.FileInfo,System.String,System.String)')
  - [GetFromText(payload,name)](#M-Bb-Builds-SourceCode-GetFromText-System-String,System-String- 'Bb.Builds.SourceCode.GetFromText(System.String,System.String)')
  - [GetHashCode()](#M-Bb-Builds-SourceCode-GetHashCode 'Bb.Builds.SourceCode.GetHashCode')
  - [HasUpdated()](#M-Bb-Builds-SourceCode-HasUpdated 'Bb.Builds.SourceCode.HasUpdated')
  - [Reload()](#M-Bb-Builds-SourceCode-Reload 'Bb.Builds.SourceCode.Reload')
  - [op_Implicit(sb)](#M-Bb-Builds-SourceCode-op_Implicit-System-Text-StringBuilder-~Bb-Builds-SourceCode 'Bb.Builds.SourceCode.op_Implicit(System.Text.StringBuilder)~Bb.Builds.SourceCode')
  - [op_Implicit(sb)](#M-Bb-Builds-SourceCode-op_Implicit-System-String-~Bb-Builds-SourceCode 'Bb.Builds.SourceCode.op_Implicit(System.String)~Bb.Builds.SourceCode')
  - [op_Implicit(file)](#M-Bb-Builds-SourceCode-op_Implicit-System-IO-FileInfo-~Bb-Builds-SourceCode 'Bb.Builds.SourceCode.op_Implicit(System.IO.FileInfo)~Bb.Builds.SourceCode')
- [SourceCodes](#T-Bb-Builds-SourceCodes 'Bb.Builds.SourceCodes')
  - [EnsureUptodated()](#M-Bb-Builds-SourceCodes-EnsureUptodated 'Bb.Builds.SourceCodes.EnsureUptodated')
  - [GetHashCode()](#M-Bb-Builds-SourceCodes-GetHashCode 'Bb.Builds.SourceCodes.GetHashCode')
- [SyntaxEx](#T-Bb-Codings-SyntaxEx 'Bb.Codings.SyntaxEx')
- [VersionMatcher](#T-Bb-Nugets-VersionMatcher 'Bb.Nugets.VersionMatcher')
  - [Parse(version)](#M-Bb-Nugets-VersionMatcher-Parse-System-String- 'Bb.Nugets.VersionMatcher.Parse(System.String)')

<a name='T-Bb-Builds-AssemblyReferences'></a>
## AssemblyReferences `type`

##### Namespace

Bb.Builds

##### Summary

Assembly references

##### See Also

- [System.Collections.Generic.IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')

<a name='M-Bb-Builds-AssemblyReferences-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [AssemblyReferences](#T-Bb-Builds-AssemblyReferences 'Bb.Builds.AssemblyReferences') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Builds-AssemblyReferences-AddAssemblyFiles-System-String[]-'></a>
### AddAssemblyFiles(assemblies) `method`

##### Summary

Adds the range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblies | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The assemblies. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | assemblies |

<a name='M-Bb-Builds-AssemblyReferences-AddAssemblyLocation-System-String-'></a>
### AddAssemblyLocation(location,assemblyName,Version) `method`

##### Summary

Adds the specified references.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | reference |

<a name='M-Bb-Builds-AssemblyReferences-AddByAssemblies-System-Reflection-Assembly[]-'></a>
### AddByAssemblies(assemblies) `method`

##### Summary

Adds assembly list in references.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblies | [System.Reflection.Assembly[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly[] 'System.Reflection.Assembly[]') | The assemblies. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | assemblies |

<a name='M-Bb-Builds-AssemblyReferences-AddByAssembly-System-Reflection-Assembly-'></a>
### AddByAssembly(assembly) `method`

##### Summary

Adds the reference by specified assembly.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | The assembly. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | assembly |

<a name='M-Bb-Builds-AssemblyReferences-AddByType-System-Type-'></a>
### AddByType(type) `method`

##### Summary

Adds the reference by assembly from specified type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | type |

<a name='M-Bb-Builds-AssemblyReferences-AddByTypes-System-Type[]-'></a>
### AddByTypes(typeAssembly) `method`

##### Summary

Adds assemblies references from types.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| typeAssembly | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | The type assembly. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | typeAssembly |

<a name='M-Bb-Builds-AssemblyReferences-AddResolveFilename-System-String-'></a>
### AddResolveFilename(filename) `method`

##### Summary

search filename in the sdk folder and add the reference

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |

<a name='M-Bb-Builds-AssemblyReferences-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through the collection.

##### Returns

An enumerator that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-AssemblyReferences-IsInSdk-System-String-'></a>
### IsInSdk(fullName) `method`

##### Summary

return true if the file is in the sdk directory

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fullName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | file location |

<a name='M-Bb-Builds-AssemblyReferences-IsInSdk-System-IO-FileInfo-'></a>
### IsInSdk(file) `method`

##### Summary

return true if the file is in the sdk directory

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') | file location |

<a name='M-Bb-Builds-AssemblyReferences-ResolveAssemblyName-System-String,System-Func{Bb-Builds-ReferenceType,System-Collections-Generic-List{Bb-Builds-Reference},Bb-Builds-Reference}-'></a>
### ResolveAssemblyName(assemblyName,Version) `method`

##### Summary

Adds the assembly reference by assembly name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The assembly name |
| Version | [System.Func{Bb.Builds.ReferenceType,System.Collections.Generic.List{Bb.Builds.Reference},Bb.Builds.Reference}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{Bb.Builds.ReferenceType,System.Collections.Generic.List{Bb.Builds.Reference},Bb.Builds.Reference}') | The version to find. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | assemblyName |
| [System.IO.FileLoadException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileLoadException 'System.IO.FileLoadException') |  |

<a name='M-Bb-Builds-AssemblyReferences-SearchInRegistered-System-String,System-Version-'></a>
### SearchInRegistered(assemblyName,Version) `method`

##### Summary

Return the specified references.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The assembly name |
| Version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') | The version to find. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | reference |

<a name='M-Bb-Builds-AssemblyReferences-SearchInRegistered-System-String-'></a>
### SearchInRegistered(assemblyName,Version) `method`

##### Summary

Return the specified references.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The assembly name |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') | reference |

<a name='M-Bb-Builds-AssemblyReferences-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through a collection.

##### Returns

An [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator') object that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='T-Bb-Compilers-AssemblyResult'></a>
## AssemblyResult `type`

##### Namespace

Bb.Compilers

<a name='M-Bb-Compilers-AssemblyResult-LoadAssembly'></a>
### LoadAssembly() `method`

##### Summary

Load assembly in the current app domain

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute'></a>
### PrepareFolderToExecute() `method`

##### Summary

Prepare the folder to execute the assembly. copy all dependencies in the specified folder.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute-System-String-'></a>
### PrepareFolderToExecute(directory) `method`

##### Summary

Prepare the folder to execute the assembly. copy all dependencies in the specified folder.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |

<a name='M-Bb-Compilers-AssemblyResult-PrepareFolderToExecute-System-IO-DirectoryInfo-'></a>
### PrepareFolderToExecute(directory) `method`

##### Summary

Prepare the folder to execute the assembly. copy all dependencies in the specified folder.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directory | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') |  |

<a name='M-Bb-Compilers-AssemblyResult-ResolveDependencies'></a>
### ResolveDependencies() `method`

##### Summary

Return the list of dependencies

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Compilers-AssemblyResult-ResolveDependencies-Bb-Builds-AssemblyReferences-'></a>
### ResolveDependencies(references) `method`

##### Summary

Return the list of dependencies

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| references | [Bb.Builds.AssemblyReferences](#T-Bb-Builds-AssemblyReferences 'Bb.Builds.AssemblyReferences') |  |

<a name='T-Bb-Builds-BuildCSharp'></a>
## BuildCSharp `type`

##### Namespace

Bb.Builds

##### Summary

Build Csharp

<a name='M-Bb-Builds-BuildCSharp-#ctor-System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}-'></a>
### #ctor(configureCompilation) `constructor`

##### Summary

Initializes a new instance of the [BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configureCompilation | [System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}') | The configure compilation. |

<a name='P-Bb-Builds-BuildCSharp-AssemblyName'></a>
### AssemblyName `property`

##### Summary

Set the assembly name.

<a name='P-Bb-Builds-BuildCSharp-Debug'></a>
### Debug `property`

##### Summary

Gets or sets a value indicating whether this [BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp') is debug mode.

<a name='P-Bb-Builds-BuildCSharp-DelaySign'></a>
### DelaySign `property`

##### Summary

Gets or sets a value indicating whether [delay sign].

<a name='P-Bb-Builds-BuildCSharp-DocumentationMode'></a>
### DocumentationMode `property`

##### Summary

Gets or sets the documentation mode.

<a name='P-Bb-Builds-BuildCSharp-Framework'></a>
### Framework `property`

##### Summary

get the framework

<a name='P-Bb-Builds-BuildCSharp-KeyFile'></a>
### KeyFile `property`

##### Summary

Gets or sets the key file.

<a name='P-Bb-Builds-BuildCSharp-LastBuild'></a>
### LastBuild `property`

##### Summary

Gets the last build result.

<a name='P-Bb-Builds-BuildCSharp-MainTypeName'></a>
### MainTypeName `property`

##### Summary

main type name

<a name='P-Bb-Builds-BuildCSharp-Nugets'></a>
### Nugets `property`

##### Summary

referential nuget controller

<a name='P-Bb-Builds-BuildCSharp-OutputKind'></a>
### OutputKind `property`

##### Summary

Gets or sets the output kind. DynamicallyLinkedLibrary by default.

<a name='P-Bb-Builds-BuildCSharp-OutputPath'></a>
### OutputPath `property`

##### Summary

Gets or sets the output path of the build.

<a name='P-Bb-Builds-BuildCSharp-Platform'></a>
### Platform `property`

##### Summary

Gets or sets the platform. AnyCpu by default.

<a name='P-Bb-Builds-BuildCSharp-References'></a>
### References `property`

##### Summary

Gets the references assemblies.

<a name='P-Bb-Builds-BuildCSharp-ResolveObjects'></a>
### ResolveObjects `property`

##### Summary

Gets or sets a value indicating whether [resolve objects].

<a name='P-Bb-Builds-BuildCSharp-RuntimeConfig'></a>
### RuntimeConfig `property`

##### Summary

Gets or sets the runtime configuration.

<a name='P-Bb-Builds-BuildCSharp-Sources'></a>
### Sources `property`

##### Summary

Gets the file name's list of sources code.

<a name='P-Bb-Builds-BuildCSharp-StrongNameKey'></a>
### StrongNameKey `property`

##### Summary

Gets or sets the strong name key.

<a name='M-Bb-Builds-BuildCSharp-AddAssemblyAttribute-System-String,System-Object[]-'></a>
### AddAssemblyAttribute(attributeName,arguments) `method`

##### Summary

Add attribute on the assembly

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| attributeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the attribute |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | arguments of the attribute |

<a name='M-Bb-Builds-BuildCSharp-AddAssemblyAttribute-System-Type,System-Object[]-'></a>
### AddAssemblyAttribute(attribute,arguments) `method`

##### Summary

Add attribute on the assembly

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| attribute | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | attribute type |
| arguments | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | arguments of the attribute |

<a name='M-Bb-Builds-BuildCSharp-AddAvailableSdk-System-String[]-'></a>
### AddAvailableSdk(frameworkVersions) `method`

##### Summary

Add available sdk.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkVersions | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

<a name='M-Bb-Builds-BuildCSharp-AddPackage-System-String,System-Version-'></a>
### AddPackage(packageName,version) `method`

##### Summary

Add packages on the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| packageName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the package |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') | version of the package. If null the last version is used |

<a name='M-Bb-Builds-BuildCSharp-AddPackage-System-String,System-String-'></a>
### AddPackage(packageName,version) `method`

##### Summary

Add packages on the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| packageName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the package |
| version | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | version of the package. If null the last version is used |

<a name='M-Bb-Builds-BuildCSharp-AddPackage-System-String-'></a>
### AddPackage(packageName) `method`

##### Summary

Add packages on the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| packageName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the package |

<a name='M-Bb-Builds-BuildCSharp-AddReferences-System-Type[]-'></a>
### AddReferences(types) `method`

##### Summary

Add references to the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') |  |

<a name='M-Bb-Builds-BuildCSharp-AddReferences-System-Reflection-Assembly[]-'></a>
### AddReferences(types) `method`

##### Summary

Add references to the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| types | [System.Reflection.Assembly[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly[] 'System.Reflection.Assembly[]') |  |

<a name='M-Bb-Builds-BuildCSharp-AddReferences-System-String-'></a>
### AddReferences(assemblyLocation,assemblyName) `method`

##### Summary

Add references to the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyLocation | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Builds-BuildCSharp-AddSource-System-IO-FileInfo[]-'></a>
### AddSource(paths) `method`

##### Summary

Load the sources from the project file.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| paths | [System.IO.FileInfo[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo[] 'System.IO.FileInfo[]') |  |

<a name='M-Bb-Builds-BuildCSharp-AddSource-System-String[]-'></a>
### AddSource(path) `method`

##### Summary

Adds the source code by filename.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The path. |

<a name='M-Bb-Builds-BuildCSharp-AddSource-System-String,System-String-'></a>
### AddSource(path) `method`

##### Summary

Adds the source code by filename.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path. |

<a name='M-Bb-Builds-BuildCSharp-Build-System-String-'></a>
### Build(assemblyName) `method`

##### Summary

Builds the specified assembly name.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the assembly. |

<a name='M-Bb-Builds-BuildCSharp-CanBeBuilt'></a>
### CanBeBuilt() `method`

##### Summary

the current instance can be built

##### Returns

boolean

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-BuildCSharp-ConfigureCompilation-System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}-'></a>
### ConfigureCompilation() `method`

##### Summary

Add configuration options action.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-BuildCSharp-EnableImplicitUsings-System-Boolean-'></a>
### EnableImplicitUsings(enable) `method`

##### Summary

Active the implicit usings.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| enable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-Bb-Builds-BuildCSharp-FilterSources-System-Func{Bb-Builds-SourceCode,System-Boolean}-'></a>
### FilterSources(value) `method`

##### Summary

Apply a filter for manage the sources to integrate in the build.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Func{Bb.Builds.SourceCode,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{Bb.Builds.SourceCode,System.Boolean}') |  |

<a name='M-Bb-Builds-BuildCSharp-ResetSdk'></a>
### ResetSdk() `method`

##### Summary

Remove all available sdk.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-BuildCSharp-SetDiagnostics-Bb-Analysis-DiagTraces-ScriptDiagnostics-'></a>
### SetDiagnostics(diagnostics) `method`

##### Summary

Set diagnostics

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| diagnostics | [Bb.Analysis.DiagTraces.ScriptDiagnostics](#T-Bb-Analysis-DiagTraces-ScriptDiagnostics 'Bb.Analysis.DiagTraces.ScriptDiagnostics') |  |

<a name='M-Bb-Builds-BuildCSharp-SetNugetController-Bb-Nugets-NugetController-'></a>
### SetNugetController(controller) `method`

##### Summary

Replace the current nuget controller

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| controller | [Bb.Nugets.NugetController](#T-Bb-Nugets-NugetController 'Bb.Nugets.NugetController') |  |

<a name='M-Bb-Builds-BuildCSharp-SetOutputKind-Microsoft-CodeAnalysis-OutputKind,System-String-'></a>
### SetOutputKind(kind,mainTypeName) `method`

##### Summary

Set type of output library

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| kind | [Microsoft.CodeAnalysis.OutputKind](#T-Microsoft-CodeAnalysis-OutputKind 'Microsoft.CodeAnalysis.OutputKind') | kind of library |
| mainTypeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of main type name |

<a name='M-Bb-Builds-BuildCSharp-SetOutputKind-Microsoft-CodeAnalysis-OutputKind-'></a>
### SetOutputKind(kind) `method`

##### Summary

Set type of output library

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| kind | [Microsoft.CodeAnalysis.OutputKind](#T-Microsoft-CodeAnalysis-OutputKind 'Microsoft.CodeAnalysis.OutputKind') | kind of library |

<a name='M-Bb-Builds-BuildCSharp-SetSdk-System-String-'></a>
### SetSdk(frameworkKey) `method`

##### Summary

Set the sdk dotnet.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Builds-BuildCSharp-SetSdk-Bb-Analysis-FrameworkKey,Bb-Analysis-FrameworkType-'></a>
### SetSdk(key,type) `method`

##### Summary

Set the sdk dotnet.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [Bb.Analysis.FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey') |  |
| type | [Bb.Analysis.FrameworkType](#T-Bb-Analysis-FrameworkType 'Bb.Analysis.FrameworkType') |  |

<a name='M-Bb-Builds-BuildCSharp-SetSdk'></a>
### SetSdk() `method`

##### Summary

Set the current running sdk dotnet.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-BuildCSharp-SetSdk-Bb-Builds-FrameworkVersion-'></a>
### SetSdk(framework) `method`

##### Summary

Set the sdk dotnet.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| framework | [Bb.Builds.FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion') |  |

<a name='M-Bb-Builds-BuildCSharp-Suppress-System-String[]-'></a>
### Suppress(ids) `method`

##### Summary

Suppresses the specified ids.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ids | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The ids. |

<a name='M-Bb-Builds-BuildCSharp-SuppressDiagnostic-Microsoft-CodeAnalysis-ReportDiagnostic,System-String[]-'></a>
### SuppressDiagnostic(reportMode,ids) `method`

##### Summary

suppress diagnostic items.

##### Returns

[BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp')fluent notation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reportMode | [Microsoft.CodeAnalysis.ReportDiagnostic](#T-Microsoft-CodeAnalysis-ReportDiagnostic 'Microsoft.CodeAnalysis.ReportDiagnostic') | The report mode. |
| ids | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The ids. |

<a name='M-Bb-Builds-BuildCSharp-Using-System-String,System-Action{Bb-Codings-CSUsing}-'></a>
### Using(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The usings to append. |
| action | [System.Action{Bb.Codings.CSUsing}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CSUsing}') | action to execute for every namespace. |

<a name='M-Bb-Builds-BuildCSharp-Using-Bb-Codings-CSUsing-'></a>
### Using(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [Bb.Codings.CSUsing](#T-Bb-Codings-CSUsing 'Bb.Codings.CSUsing') | The usings to append. |

<a name='M-Bb-Builds-BuildCSharp-UsingStatics-System-String[]-'></a>
### UsingStatics(usings) `method`

##### Summary

append static using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The static usings to append. |

<a name='M-Bb-Builds-BuildCSharp-Usings-System-Type[]-'></a>
### Usings(usings) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | The usings. |

<a name='M-Bb-Builds-BuildCSharp-Usings-System-String[],System-Action{Bb-Codings-CSUsing}-'></a>
### Usings(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The usings to append. |
| action | [System.Action{Bb.Codings.CSUsing}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CSUsing}') | action to execute for every namespace. |

<a name='T-Bb-Codings-CSMemberDeclaration'></a>
## CSMemberDeclaration `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CSMemberDeclaration-Add``1-``0-'></a>
### Add\`\`1(member) `method`

##### Summary

Generic method for add member

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Codings-CSMemberDeclaration-Field-System-String,System-String,System-Action{Bb-Codings-CsFieldDeclaration}-'></a>
### Field(fieldName,type,action) `method`

##### Summary

Add a new field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fieldName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the field |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Type of the field |
| action | [System.Action{Bb.Codings.CsFieldDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsFieldDeclaration}') | Action for manipulate the field |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | fieldName can't be null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | the field can't named like the class |

<a name='M-Bb-Codings-CSMemberDeclaration-Field-System-String,System-String-'></a>
### Field(fieldName,type) `method`

##### Summary

Add a new field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fieldName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the field |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Type of the field |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | fieldName can't be null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | the field can't named like the class |

<a name='M-Bb-Codings-CSMemberDeclaration-Items``1'></a>
### Items\`\`1() `method`

##### Summary

Iterator on the members

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Bb-Codings-CSMemberDeclarationHelper'></a>
## CSMemberDeclarationHelper `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Attribute``1-``0,System-Type,System-Action{Bb-Codings-CsAttributeDeclaration}-'></a>
### Attribute\`\`1(self,attribute,action) `method`

##### Summary

Add custom Attribute with the specified attribute type.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| attribute | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The attribute. |
| action | [System.Action{Bb.Codings.CsAttributeDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsAttributeDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Attribute``1-``0,System-String,System-Action{Bb-Codings-CsAttributeDeclaration}-'></a>
### Attribute\`\`1(self,attributeName,action) `method`

##### Summary

Add custom Attribute with the specified attribute name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| attributeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the attribute. |
| action | [System.Action{Bb.Codings.CsAttributeDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsAttributeDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-DisableWarning``1-``0,System-String[]-'></a>
### DisableWarning\`\`1(self,codes) `method`

##### Summary

append pragma code for disable the warning.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| codes | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The codes. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-Action{Bb-Codings-CsMethodDeclaration}-'></a>
### Method\`\`1(self,methodName,action) `method`

##### Summary

Declare a new methods the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the method. |
| action | [System.Action{Bb.Codings.CsMethodDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsMethodDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-String,System-Action{Bb-Codings-CsMethodDeclaration}-'></a>
### Method\`\`1(self,methodName,type,action) `method`

##### Summary

Declare a new methods the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the method. |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type. |
| action | [System.Action{Bb.Codings.CsMethodDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsMethodDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,System-Type,System-Action{Bb-Codings-CsMethodDeclaration}-'></a>
### Method\`\`1(self,methodName,type,action) `method`

##### Summary

Declare a new methods the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the method. |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |
| action | [System.Action{Bb.Codings.CsMethodDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsMethodDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSMemberDeclarationHelper-Method``1-``0,System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax,System-Action{Bb-Codings-CsMethodDeclaration}-'></a>
### Method\`\`1(self,methodName,type,action) `method`

##### Summary

Declare a new methods the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| methodName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the method. |
| type | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax') | The type. |
| action | [System.Action{Bb.Codings.CsMethodDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsMethodDeclaration}') | The action. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='T-Bb-Codings-CSNamespace'></a>
## CSNamespace `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CSNamespace-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Initializes a new instance of the [CSNamespace](#T-Bb-Codings-CSNamespace 'Bb.Codings.CSNamespace') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='M-Bb-Codings-CSNamespace-Class-System-String,System-Action{Bb-Codings-CsClassDeclaration}-'></a>
### Class(name) `method`

##### Summary

create a class with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='M-Bb-Codings-CSNamespace-Class-System-String-'></a>
### Class(name) `method`

##### Summary

create a class with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='T-Bb-Codings-CSUsing'></a>
## CSUsing `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CSUsing-#ctor-System-String-'></a>
### #ctor(namespaceOrType) `constructor`

##### Summary

Initializes a new instance of the [CSUsing](#T-Bb-Codings-CSUsing 'Bb.Codings.CSUsing') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespaceOrType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-Bb-Codings-CSUsing-Alias'></a>
### Alias `property`

##### Summary

Using has alias

<a name='P-Bb-Codings-CSUsing-IsGlobal'></a>
### IsGlobal `property`

##### Summary

Using is global

<a name='P-Bb-Codings-CSUsing-IsStatic'></a>
### IsStatic `property`

##### Summary

Using is static

<a name='P-Bb-Codings-CSUsing-NamespaceOrType'></a>
### NamespaceOrType `property`

##### Summary

Namespace or type to use

<a name='T-Bb-Codings-CSharpArtifact'></a>
## CSharpArtifact `type`

##### Namespace

Bb.Codings

##### Summary

Manage csharp code artifact for generate the code.

##### See Also

- [Bb.Codings.CSMemberDeclaration](#T-Bb-Codings-CSMemberDeclaration 'Bb.Codings.CSMemberDeclaration')

<a name='M-Bb-Codings-CSharpArtifact-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [CSharpArtifact](#T-Bb-Codings-CSharpArtifact 'Bb.Codings.CSharpArtifact') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Codings-CSharpArtifact-#ctor-System-String,System-String-'></a>
### #ctor(name,projectPath) `constructor`

##### Summary

Initializes a new instance of the [CSharpArtifact](#T-Bb-Codings-CSharpArtifact 'Bb.Codings.CSharpArtifact') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| projectPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The project path. |

<a name='P-Bb-Codings-CSharpArtifact-Tree'></a>
### Tree `property`

##### Summary

Get the tree of the code generated

<a name='M-Bb-Codings-CSharpArtifact-Build'></a>
### Build() `method`

##### Summary

Builds this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CSharpArtifact-Code'></a>
### Code() `method`

##### Summary

return the code generated

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CSharpArtifact-Namespace-System-String,System-Action{Bb-Codings-CSNamespace}-'></a>
### Namespace(namespace,action) `method`

##### Summary

Add a new Namespace with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespace | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The namespace. |
| action | [System.Action{Bb.Codings.CSNamespace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CSNamespace}') | The action. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CSharpArtifact-Save'></a>
### Save() `method`

##### Summary

Save the document

##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CSharpArtifact-Save-System-String-'></a>
### Save(path) `method`

##### Summary

Save the document in the specified path.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | full path where the file must write |

<a name='M-Bb-Codings-CSharpArtifact-ToString'></a>
### ToString() `method`

##### Summary

return the source code generated.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents this instance.

##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CSharpArtifact-Using-System-String,System-Action{Bb-Codings-CSUsing}-'></a>
### Using(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The usings to append. |
| action | [System.Action{Bb.Codings.CSUsing}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CSUsing}') | action to execute for every namespace. |

<a name='M-Bb-Codings-CSharpArtifact-Using-Bb-Codings-CSUsing-'></a>
### Using(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [Bb.Codings.CSUsing](#T-Bb-Codings-CSUsing 'Bb.Codings.CSUsing') | The usings to append. |

<a name='M-Bb-Codings-CSharpArtifact-UsingStatics-System-String[]-'></a>
### UsingStatics(usings) `method`

##### Summary

append static using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The static usings to append. |

<a name='M-Bb-Codings-CSharpArtifact-Usings-System-Type[]-'></a>
### Usings(usings) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | The usings. |

<a name='M-Bb-Codings-CSharpArtifact-Usings-System-String[]-'></a>
### Usings(usings) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The usings to append. |

<a name='M-Bb-Codings-CSharpArtifact-Usings-System-String[],System-Action{Bb-Codings-CSUsing}-'></a>
### Usings(usings,action) `method`

##### Summary

append using directives in the source code with specified name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The usings to append. |
| action | [System.Action{Bb.Codings.CSUsing}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CSUsing}') | action to execute for every namespace. |

<a name='T-Bb-Codings-CSharpNode'></a>
## CSharpNode `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CSharpNode-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [CSharpNode](#T-Bb-Codings-CSharpNode 'Bb.Codings.CSharpNode') class.

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Codings-CSharpNode-Name-System-String-'></a>
### Name(name) `method`

##### Summary

Parse a NameSyntax node using the grammar rule for names.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Codings-CSharpNode-Token-Microsoft-CodeAnalysis-CSharp-SyntaxKind-'></a>
### Token(kind) `method`

##### Summary

Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
can be inferred by the kind alone.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| kind | [Microsoft.CodeAnalysis.CSharp.SyntaxKind](#T-Microsoft-CodeAnalysis-CSharp-SyntaxKind 'Microsoft.CodeAnalysis.CSharp.SyntaxKind') | A syntax kind value for a token. These have the suffix Token or Keyword. |

<a name='T-Bb-Codings-CodeHelper'></a>
## CodeHelper `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CodeHelper-ElementAccess-Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax,Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax[]-'></a>
### ElementAccess(expression,arguments) `method`

##### Summary

Create expression[argument1, argument2, ...]

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax') |  |
| arguments | [Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[]](#T-Microsoft-CodeAnalysis-CSharp-Syntax-ExpressionSyntax[] 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[]') |  |

<a name='M-Bb-Codings-CodeHelper-Identifier-System-String-'></a>
### Identifier(self) `method`

##### Summary

Convert string to IdentifierNameSyntax (Roslyn)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Codings-CodeHelper-Identifiers-System-String,System-String,System-String[]-'></a>
### Identifiers(self,self2,items) `method`

##### Summary

convert string to MemberAccessExpressionSyntax (Roslyn)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| self2 | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| items | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

<a name='M-Bb-Codings-CodeHelper-ToBlock-Microsoft-CodeAnalysis-SyntaxList{Microsoft-CodeAnalysis-CSharp-Syntax-StatementSyntax}-'></a>
### ToBlock(self) `method`

##### Summary

convert list of StantementSyntax to SyntaxList

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [Microsoft.CodeAnalysis.SyntaxList{Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax}](#T-Microsoft-CodeAnalysis-SyntaxList{Microsoft-CodeAnalysis-CSharp-Syntax-StatementSyntax} 'Microsoft.CodeAnalysis.SyntaxList{Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax}') |  |

<a name='M-Bb-Codings-CodeHelper-ToToken-Microsoft-CodeAnalysis-CSharp-SyntaxKind-'></a>
### ToToken(self) `method`

##### Summary

convert syntaxKind to token

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [Microsoft.CodeAnalysis.CSharp.SyntaxKind](#T-Microsoft-CodeAnalysis-CSharp-SyntaxKind 'Microsoft.CodeAnalysis.CSharp.SyntaxKind') |  |

<a name='T-Bb-Nugets-Versions-ConstraintVersion'></a>
## ConstraintVersion `type`

##### Namespace

Bb.Nugets.Versions

##### Summary

Constraint version

<a name='M-Bb-Nugets-Versions-ConstraintVersion-#ctor'></a>
### #ctor() `constructor`

##### Summary

Create a new instance of ConstraintVersion

##### Parameters

This constructor has no parameters.

<a name='M-Bb-Nugets-Versions-ConstraintVersion-#ctor-System-Int32,System-Version,Bb-Nugets-Versions-ContraintEnum,Bb-Nugets-Versions-ContraintEnum-'></a>
### #ctor(count,version,leftConstraint) `constructor`

##### Summary

Create a new instance of ConstraintVersion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |
| leftConstraint | [Bb.Nugets.Versions.ContraintEnum](#T-Bb-Nugets-Versions-ContraintEnum 'Bb.Nugets.Versions.ContraintEnum') |  |

<a name='F-Bb-Nugets-Versions-ConstraintVersion-Version'></a>
### Version `constants`

##### Summary

Version reference

<a name='P-Bb-Nugets-Versions-ConstraintVersion-Child'></a>
### Child `property`

##### Summary

Child of the responsibility chain

<a name='P-Bb-Nugets-Versions-ConstraintVersion-Description'></a>
### Description `property`

##### Summary

Description of the constraint

<a name='P-Bb-Nugets-Versions-ConstraintVersion-Failed'></a>
### Failed `property`

##### Summary

Indicate if the constraint is not valid

<a name='M-Bb-Nugets-Versions-ConstraintVersion-Append-Bb-Nugets-Versions-ConstraintVersion-'></a>
### Append(next) `method`

##### Summary

Append item to responsibility chain

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| next | [Bb.Nugets.Versions.ConstraintVersion](#T-Bb-Nugets-Versions-ConstraintVersion 'Bb.Nugets.Versions.ConstraintVersion') |  |

<a name='M-Bb-Nugets-Versions-ConstraintVersion-Evaluate-System-Version-'></a>
### Evaluate(versionToCompare) `method`

##### Summary

Evaluate if the version match with the constraint

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| versionToCompare | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |

<a name='T-Bb-Nugets-Versions-ContraintEnum'></a>
## ContraintEnum `type`

##### Namespace

Bb.Nugets.Versions

<a name='F-Bb-Nugets-Versions-ContraintEnum-Equal'></a>
### Equal `constants`

##### Summary

The version must be strictly ...

<a name='T-Bb-Codings-CsClassDeclaration'></a>
## CsClassDeclaration `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CsClassDeclaration-Base-System-String[]-'></a>
### Base(baseNames) `method`

##### Summary

add Bases types

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| baseNames | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The base type names. |

<a name='M-Bb-Codings-CsClassDeclaration-Ctor'></a>
### Ctor() `method`

##### Summary

add a new constructor

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CsClassDeclaration-Ctor-System-Action{Bb-Codings-CsCtorDeclaration}-'></a>
### Ctor(action) `method`

##### Summary

add a new constructor

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{Bb.Codings.CsCtorDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsCtorDeclaration}') | action for manipulate the constructor. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CsClassDeclaration-Field-System-String,System-String,System-Action{Bb-Codings-CsFieldDeclaration}-'></a>
### Field(fieldName,type,action) `method`

##### Summary

Add a new Field with specified field name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fieldName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the field. |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type of the field. |
| action | [System.Action{Bb.Codings.CsFieldDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsFieldDeclaration}') | action for manipulate the field. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CsClassDeclaration-Property-System-String,System-String,System-Action{Bb-Codings-CsPropertyDeclaration}-'></a>
### Property(propertyName,type,action) `method`

##### Summary

Add a new property the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the property. |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type of the property. |
| action | [System.Action{Bb.Codings.CsPropertyDeclaration}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CsPropertyDeclaration}') | The action for manipulate the property. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | propertyName |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | the property name can't named like the class |

<a name='M-Bb-Codings-CsClassDeclaration-Property-System-String,System-String-'></a>
### Property(propertyName,type) `method`

##### Summary

Add a new property the specified method name.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the property. |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type of the property. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | propertyName |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | the property name can't named like the class |

<a name='T-Bb-Codings-CsFieldDeclaration'></a>
## CsFieldDeclaration `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CsFieldDeclaration-#ctor-System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax-'></a>
### #ctor(name,typeName) `constructor`

##### Summary

Initializes a new instance of the [CsFieldDeclaration](#T-Bb-Codings-CsFieldDeclaration 'Bb.Codings.CsFieldDeclaration') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| typeName | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax') | Name of the type. |

<a name='M-Bb-Codings-CsFieldDeclaration-#ctor-System-String,System-String-'></a>
### #ctor(name,typeName) `constructor`

##### Summary

Initializes a new instance of the [CsFieldDeclaration](#T-Bb-Codings-CsFieldDeclaration 'Bb.Codings.CsFieldDeclaration') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| typeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the type. |

<a name='M-Bb-Codings-CsFieldDeclaration-ReturnType-System-String-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type. |

<a name='M-Bb-Codings-CsFieldDeclaration-ReturnType-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax') | The type. |

<a name='M-Bb-Codings-CsFieldDeclaration-ReturnType-System-Type-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the field

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |

<a name='M-Bb-Codings-CsFieldDeclaration-SetInitialValue-System-Object-'></a>
### SetInitialValue(value) `method`

##### Summary

Sets the initial value.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value. |

<a name='T-Bb-Codings-CsParameterDeclaration'></a>
## CsParameterDeclaration `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CsParameterDeclaration-Way-Bb-Codings-ParameterWay-'></a>
### Way(way) `method`

##### Summary

specify the way of the parameter

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| way | [Bb.Codings.ParameterWay](#T-Bb-Codings-ParameterWay 'Bb.Codings.ParameterWay') | The way. |

<a name='T-Bb-Codings-CsPropertyDeclaration'></a>
## CsPropertyDeclaration `type`

##### Namespace

Bb.Codings

<a name='M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,System-String-'></a>
### #ctor(name,typeName) `constructor`

##### Summary

Initializes a new instance of the [CsPropertyDeclaration](#T-Bb-Codings-CsPropertyDeclaration 'Bb.Codings.CsPropertyDeclaration') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| typeName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the type. |

<a name='M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,System-Type-'></a>
### #ctor(name,type) `constructor`

##### Summary

Initializes a new instance of the [CsPropertyDeclaration](#T-Bb-Codings-CsPropertyDeclaration 'Bb.Codings.CsPropertyDeclaration') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |

<a name='M-Bb-Codings-CsPropertyDeclaration-#ctor-System-String,Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax-'></a>
### #ctor(name,type) `constructor`

##### Summary

Initializes a new instance of the [CsPropertyDeclaration](#T-Bb-Codings-CsPropertyDeclaration 'Bb.Codings.CsPropertyDeclaration') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| type | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax') | The type. |

<a name='M-Bb-Codings-CsPropertyDeclaration-AutoGet'></a>
### AutoGet() `method`

##### Summary

generate empty get. { get; }

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CsPropertyDeclaration-AutoSet'></a>
### AutoSet() `method`

##### Summary

generate empty set. { set; }

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Codings-CsPropertyDeclaration-BodyGet-System-Action{Bb-Codings-CodeBlock}-'></a>
### BodyGet(action) `method`

##### Summary

Manipulate the get body.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{Bb.Codings.CodeBlock}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CodeBlock}') | The action. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CsPropertyDeclaration-BodySet-System-Action{Bb-Codings-CodeBlock}-'></a>
### BodySet(action) `method`

##### Summary

Manipulate the set body.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{Bb.Codings.CodeBlock}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Codings.CodeBlock}') | The action. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | action |

<a name='M-Bb-Codings-CsPropertyDeclaration-ReturnType-System-String-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the property.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The type. |

<a name='M-Bb-Codings-CsPropertyDeclaration-ReturnType-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax') | The type. |

<a name='M-Bb-Codings-CsPropertyDeclaration-ReturnType-System-Type-'></a>
### ReturnType(type) `method`

##### Summary

Specify the type of the property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type. |

<a name='T-Bb-Builds-DependencyAssemblyNameResolver'></a>
## DependencyAssemblyNameResolver `type`

##### Namespace

Bb.Builds

<a name='M-Bb-Builds-DependencyAssemblyNameResolver-Resolve-System-IO-FileInfo,Bb-Builds-AssemblyReferences-'></a>
### Resolve(file,references,download) `method`

##### Summary

Return the list of assemblies referenced by the file

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| references | [Bb.Builds.AssemblyReferences](#T-Bb-Builds-AssemblyReferences 'Bb.Builds.AssemblyReferences') |  |

<a name='T-Bb-Codings-DocXml'></a>
## DocXml `type`

##### Namespace

Bb.Codings

<a name='P-Bb-Codings-DocXml-EmptyLine'></a>
### EmptyLine `property`

##### Summary

create an empty line.

<a name='T-Bb-Compilers-FileCode'></a>
## FileCode `type`

##### Namespace

Bb.Compilers

##### Summary

Code source

<a name='T-Bb-Nugets-FileNugetFolder'></a>
## FileNugetFolder `type`

##### Namespace

Bb.Nugets

##### Summary

File nuget folder

<a name='M-Bb-Nugets-FileNugetFolder-#ctor-System-IO-DirectoryInfo-'></a>
### #ctor(dir) `constructor`

##### Summary

Create a new instance of [FileNugetFolder](#T-Bb-Nugets-FileNugetFolder 'Bb.Nugets.FileNugetFolder')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dir | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') |  |

<a name='M-Bb-Nugets-FileNugetFolder-Last'></a>
### Last(version) `method`

##### Summary

Resolve the version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [M:Bb.Nugets.FileNugetFolder.Last](#T-M-Bb-Nugets-FileNugetFolder-Last 'M:Bb.Nugets.FileNugetFolder.Last') |  |

<a name='M-Bb-Nugets-FileNugetFolder-Refresh'></a>
### Refresh() `method`

##### Summary

Initializes folder.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Nugets-FileNugetFolder-Resolve-System-Version,System-Boolean-'></a>
### Resolve(version) `method`

##### Summary

Resolve the version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |

<a name='T-Bb-Nugets-FileNugetFolders'></a>
## FileNugetFolders `type`

##### Namespace

Bb.Nugets

<a name='M-Bb-Nugets-FileNugetFolders-#ctor-System-String,System-String[]-'></a>
### #ctor(path,host) `constructor`

##### Summary

Create a new instance of [FileNugetFolders](#T-Bb-Nugets-FileNugetFolders 'Bb.Nugets.FileNugetFolders')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| host | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

<a name='P-Bb-Nugets-FileNugetFolders-Hosts'></a>
### Hosts `property`

##### Summary

Hosts for resolve missing packages

<a name='P-Bb-Nugets-FileNugetFolders-Parent'></a>
### Parent `property`

##### Summary

Parent nuget controller

<a name='P-Bb-Nugets-FileNugetFolders-Path'></a>
### Path `property`

##### Summary

Path of the folder

<a name='P-Bb-Nugets-FileNugetFolders-WithResolver'></a>
### WithResolver `property`

##### Summary

return true if the resolver can used for download nuget

<a name='M-Bb-Nugets-FileNugetFolders-Refresh'></a>
### Refresh() `method`

##### Summary

Refresh the folders

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Nugets-FileNugetFolders-Resolve-System-String-'></a>
### Resolve(name) `method`

##### Summary

Resolve by name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Nugets-FileNugetFolders-Resolve-System-String,System-Version,System-Boolean-'></a>
### Resolve(name,version) `method`

##### Summary

resolve by name and version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |

<a name='M-Bb-Nugets-FileNugetFolders-Resolve-System-ValueTuple{System-String,System-Version},System-Boolean-'></a>
### Resolve(item) `method`

##### Summary

resolve by name and version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [System.ValueTuple{System.String,System.Version}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.String,System.Version}') |  |

<a name='M-Bb-Nugets-FileNugetFolders-ResolveAll-System-ValueTuple{System-String,System-Version}-'></a>
### ResolveAll(item) `method`

##### Summary

resolve all version by name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [System.ValueTuple{System.String,System.Version}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.String,System.Version}') |  |

<a name='M-Bb-Nugets-FileNugetFolders-ResolveAll-System-String-'></a>
### ResolveAll(item) `method`

##### Summary

resolve all version by name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Nugets-FileNugetFolders-TryToDownload-Bb-Nugets-NugetDependency-'></a>
### TryToDownload(dependency) `method`

##### Summary

Try to download the package nuget

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dependency | [Bb.Nugets.NugetDependency](#T-Bb-Nugets-NugetDependency 'Bb.Nugets.NugetDependency') |  |

<a name='M-Bb-Nugets-FileNugetFolders-TryToDownload-System-String,System-Version-'></a>
### TryToDownload(item) `method`

##### Summary

Try to download the package nuget

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Compilers-GeneratorExtension'></a>
## GeneratorExtension `type`

##### Namespace

Bb.Compilers

<a name='M-Bb-Compilers-GeneratorExtension-EmitToArray-Microsoft-CodeAnalysis-Compilation,Microsoft-CodeAnalysis-DiagnosticSeverity,Bb-Compilers-CompilerException@-'></a>
### EmitToArray(compilation) `method`

##### Summary

emit the compilation result into a byte array

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| compilation | [Microsoft.CodeAnalysis.Compilation](#T-Microsoft-CodeAnalysis-Compilation 'Microsoft.CodeAnalysis.Compilation') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Bb.Compilers.CompilerException](#T-Bb-Compilers-CompilerException 'Bb.Compilers.CompilerException') | throw an exception with corresponding message if there are errors |

<a name='M-Bb-Compilers-GeneratorExtension-Map-Microsoft-CodeAnalysis-Diagnostic-'></a>
### Map(self) `method`

##### Summary

Maps the specified self.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [Microsoft.CodeAnalysis.Diagnostic](#T-Microsoft-CodeAnalysis-Diagnostic 'Microsoft.CodeAnalysis.Diagnostic') | The self. |

<a name='M-Bb-Compilers-GeneratorExtension-Map-Microsoft-CodeAnalysis-Location-'></a>
### Map(location) `method`

##### Summary

Maps the specified location.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Microsoft.CodeAnalysis.Location](#T-Microsoft-CodeAnalysis-Location 'Microsoft.CodeAnalysis.Location') | The location. |

<a name='T-Bb-Helper'></a>
## Helper `type`

##### Namespace

Bb

<a name='M-Bb-Helper-ResolveVersion-System-String-'></a>
### ResolveVersion(text) `method`

##### Summary

resolve version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Nugets-LocalFileNugetVersion'></a>
## LocalFileNugetVersion `type`

##### Namespace

Bb.Nugets

##### Summary

Nutget version

<a name='M-Bb-Nugets-LocalFileNugetVersion-#ctor-System-IO-DirectoryInfo-'></a>
### #ctor(dir) `constructor`

##### Summary

create a new instance of [LocalFileNugetVersion](#T-Bb-Nugets-LocalFileNugetVersion 'Bb.Nugets.LocalFileNugetVersion')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dir | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') |  |

<a name='P-Bb-Nugets-LocalFileNugetVersion-Empty'></a>
### Empty `property`

##### Summary

Return true if the folder has no library.

<a name='P-Bb-Nugets-LocalFileNugetVersion-Metadata'></a>
### Metadata `property`

##### Summary

Metadata of the nuget

<a name='P-Bb-Nugets-LocalFileNugetVersion-Name'></a>
### Name `property`

##### Summary

Name of the nuget

<a name='P-Bb-Nugets-LocalFileNugetVersion-Parent'></a>
### Parent `property`

##### Summary

Parent folder

<a name='P-Bb-Nugets-LocalFileNugetVersion-References'></a>
### References `property`

##### Summary

Return the references of the library

<a name='P-Bb-Nugets-LocalFileNugetVersion-Version'></a>
### Version `property`

##### Summary

Version of the nuget

<a name='T-Bb-Codings-NamedNode'></a>
## NamedNode `type`

##### Namespace

Bb.Codings

##### Summary

Class that represents reference to a named symbol, like a local variable or a field.
Can be used for referencing such node after its creation.

Is implicitly convertible from types declaring those symbols and to [IdentifierNameSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-IdentifierNameSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax'),
that's be used to reference them.

<a name='T-Bb-Nugets-NugetCompressedDocument'></a>
## NugetCompressedDocument `type`

##### Namespace

Bb.Nugets

##### Summary

Nuget compressed document

<a name='M-Bb-Nugets-NugetCompressedDocument-Create-System-String,System-String-'></a>
### Create(path,targetFolder) `method`

##### Summary

Create a NugetCompressedDocument from a file that contains a nupkg file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| targetFolder | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Nugets-NugetCompressedDocument-Create-System-IO-FileInfo,System-IO-DirectoryInfo-'></a>
### Create(path,targetFolder) `method`

##### Summary

Create a NugetCompressedDocument from a file that contains a nupkg file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| targetFolder | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |

<a name='M-Bb-Nugets-NugetCompressedDocument-Load'></a>
### Load() `method`

##### Summary

load the nuget document

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-Nugets-NugetController'></a>
## NugetController `type`

##### Namespace

Bb.Nugets

<a name='M-Bb-Nugets-NugetController-#ctor'></a>
### #ctor() `constructor`

##### Summary

Create a new instance of [NugetController](#T-Bb-Nugets-NugetController 'Bb.Nugets.NugetController')

##### Parameters

This constructor has no parameters.

<a name='F-Bb-Nugets-NugetController-IsFreeBSDPlatform'></a>
### IsFreeBSDPlatform `constants`

##### Summary

Is FreeBSD platform

<a name='F-Bb-Nugets-NugetController-IsLinuxPlatform'></a>
### IsLinuxPlatform `constants`

##### Summary

Is Linux platform

<a name='F-Bb-Nugets-NugetController-IsOsxPlatform'></a>
### IsOsxPlatform `constants`

##### Summary

Is OSX platform

<a name='F-Bb-Nugets-NugetController-IsWindowsPlatform'></a>
### IsWindowsPlatform `constants`

##### Summary

Is Windows platform

<a name='P-Bb-Nugets-NugetController-Intercept'></a>
### Intercept `property`

##### Summary

Intercept functions. return true to bypass the process

<a name='M-Bb-Nugets-NugetController-AddDefaultLinuxFolderIf-System-String[]-'></a>
### AddDefaultLinuxFolderIf(nugetHosts) `method`

##### Summary

Add the default repository to resolve nuget for Linux if the system is Linux

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nugetHosts | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | hosts where search package on line |

<a name='M-Bb-Nugets-NugetController-AddDefaultWindowsFolderIf-System-String[]-'></a>
### AddDefaultWindowsFolderIf(nugetHosts) `method`

##### Summary

Add the default repository to resolve nuget for windows if the system is windows

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nugetHosts | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | hosts where search package on line |

<a name='M-Bb-Nugets-NugetController-AddFolder-System-String,System-String[]-'></a>
### AddFolder(path,nugetHosts) `method`

##### Summary

Add the default repository to resolve nuget for windows

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | path to store the package downloaded |
| nugetHosts | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | host where search package on line |

<a name='M-Bb-Nugets-NugetController-AddFolderIf-System-Boolean,System-String,System-String[]-'></a>
### AddFolderIf(filter,path,nugetHosts) `method`

##### Summary

Add the default repository to resolve nuget if filter is true

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | condition for adding folder |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | path to store the package downloaded |
| nugetHosts | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | hosts where search package on line |

<a name='M-Bb-Nugets-NugetController-AddPackage-System-String-'></a>
### AddPackage(nugetName) `method`

##### Summary

Add a reference to resolve in the build

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nugetName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | nuget reference to add |

<a name='M-Bb-Nugets-NugetController-AddPackage-System-String,System-String-'></a>
### AddPackage(nugetName,versionMin) `method`

##### Summary

Add a reference to resolve in the build

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nugetName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | nuget reference to add |
| versionMin | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | minimum version to add |

<a name='M-Bb-Nugets-NugetController-AddPackage-System-String,System-Version-'></a>
### AddPackage(nugetName,version) `method`

##### Summary

Add a reference to resolve in the build

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nugetName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | nuget reference to add |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') | minimum version to add |

<a name='M-Bb-Nugets-NugetController-CopyFolderFrom-Bb-Nugets-NugetController-'></a>
### CopyFolderFrom(source) `method`

##### Summary

Copy the nuget folder from the source

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [Bb.Nugets.NugetController](#T-Bb-Nugets-NugetController 'Bb.Nugets.NugetController') |  |

<a name='M-Bb-Nugets-NugetController-CopyPackagesFrom-Bb-Nugets-NugetController-'></a>
### CopyPackagesFrom(source) `method`

##### Summary

Copy the nuget folder from the source

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [Bb.Nugets.NugetController](#T-Bb-Nugets-NugetController 'Bb.Nugets.NugetController') |  |

<a name='M-Bb-Nugets-NugetController-Resolve-System-String-'></a>
### Resolve(name) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Nugets-NugetController-ResolveAssemblyName-System-String,Bb-Builds-FrameworkVersion,System-Func{Bb-Builds-ReferenceType,System-Collections-Generic-List{Bb-Builds-Reference},Bb-Builds-Reference}-'></a>
### ResolveAssemblyName(assemblyName,framework) `method`

##### Summary

Resolve assembly name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name of the assembly |
| framework | [Bb.Builds.FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion') | [FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion') |

<a name='M-Bb-Nugets-NugetController-TryToDownload-Bb-Builds-FrameworkVersion,System-String,System-Version-'></a>
### TryToDownload(item) `method`

##### Summary

Try to download the package nuget

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.Builds.FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion') |  |

<a name='T-Bb-Nugets-NugetDependency'></a>
## NugetDependency `type`

##### Namespace

Bb.Nugets

##### Summary

Nuget dependency

<a name='M-Bb-Nugets-NugetDependency-#ctor-System-String,System-Version,System-Version,Bb-Nugets-NugetGroupDependency,Bb-Nugets-NugetDocument-'></a>
### #ctor(id,versionMin,versionMax,parent,nuget) `constructor`

##### Summary

create a new instance of [NugetDependency](#T-Bb-Nugets-NugetDependency 'Bb.Nugets.NugetDependency')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| versionMin | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |
| versionMax | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |
| parent | [Bb.Nugets.NugetGroupDependency](#T-Bb-Nugets-NugetGroupDependency 'Bb.Nugets.NugetGroupDependency') |  |
| nuget | [Bb.Nugets.NugetDocument](#T-Bb-Nugets-NugetDocument 'Bb.Nugets.NugetDocument') |  |

<a name='M-Bb-Nugets-NugetDependency-#ctor-System-String,System-Version,Bb-Nugets-NugetGroupDependency,Bb-Nugets-NugetDocument-'></a>
### #ctor(id,version,parent,nuget) `constructor`

##### Summary

create a new instance of [NugetDependency](#T-Bb-Nugets-NugetDependency 'Bb.Nugets.NugetDependency')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |
| parent | [Bb.Nugets.NugetGroupDependency](#T-Bb-Nugets-NugetGroupDependency 'Bb.Nugets.NugetGroupDependency') |  |
| nuget | [Bb.Nugets.NugetDocument](#T-Bb-Nugets-NugetDocument 'Bb.Nugets.NugetDocument') |  |

<a name='P-Bb-Nugets-NugetDependency-ConstraintVersion'></a>
### ConstraintVersion `property`

##### Summary

Constraint version

<a name='P-Bb-Nugets-NugetDependency-Group'></a>
### Group `property`

##### Summary

Parent framework group of dependency

<a name='P-Bb-Nugets-NugetDependency-Id'></a>
### Id `property`

##### Summary

Package nuget Id

<a name='P-Bb-Nugets-NugetDependency-Nuget'></a>
### Nuget `property`

##### Summary

Root parent nuget document

<a name='T-Bb-Nugets-NugetDocument'></a>
## NugetDocument `type`

##### Namespace

Bb.Nugets

##### Summary

Nuget document

<a name='P-Bb-Nugets-NugetDocument-Description'></a>
### Description `property`

##### Summary

Package nuget description

<a name='P-Bb-Nugets-NugetDocument-Id'></a>
### Id `property`

##### Summary

Package nuget Id

<a name='P-Bb-Nugets-NugetDocument-IsMultipleTarget'></a>
### IsMultipleTarget `property`

##### Summary

return true if the dependencies are for multiple target build

<a name='P-Bb-Nugets-NugetDocument-References'></a>
### References `property`

##### Summary

List libraries references found in the folder lib

<a name='P-Bb-Nugets-NugetDocument-Repository'></a>
### Repository `property`

##### Summary

Repository informations

<a name='P-Bb-Nugets-NugetDocument-Version'></a>
### Version `property`

##### Summary

Package nuget version

<a name='M-Bb-Nugets-NugetDocument-GroupDependencies'></a>
### GroupDependencies() `method`

##### Summary

return the dependencies

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Nugets-NugetDocument-GroupDependencies-Bb-Analysis-FrameworkKey,Bb-Builds-FrameworkVersion-'></a>
### GroupDependencies(framework) `method`

##### Summary

return the dependencies for a specific framework

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| framework | [Bb.Analysis.FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey') |  |

<a name='M-Bb-Nugets-NugetDocument-GroupDependencies-Bb-Analysis-FrameworkKey-'></a>
### GroupDependencies(framework) `method`

##### Summary

return the dependencies for a specific framework

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| framework | [Bb.Analysis.FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey') |  |

<a name='M-Bb-Nugets-NugetDocument-ResolveNugetDocument-System-IO-DirectoryInfo-'></a>
### ResolveNugetDocument(path) `method`

##### Summary

Create a NugetDocument from a directory that contains a nuspec file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') |  |

<a name='M-Bb-Nugets-NugetDocument-ResolveNugetDocument-System-IO-FileInfo-'></a>
### ResolveNugetDocument(path) `method`

##### Summary

Create a NugetDocument from a file that contains a nuspec file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |

<a name='T-Bb-Nugets-NugetGroupDependency'></a>
## NugetGroupDependency `type`

##### Namespace

Bb.Nugets

##### Summary

Nuget group dependency for specific framework

<a name='P-Bb-Nugets-NugetGroupDependency-Nuget'></a>
### Nuget `property`

##### Summary

Root parent nuget document

<a name='P-Bb-Nugets-NugetGroupDependency-TargetFramework'></a>
### TargetFramework `property`

##### Summary

target framework

<a name='M-Bb-Nugets-NugetGroupDependency-Dependencies'></a>
### Dependencies() `method`

##### Summary

List of package dependencies

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-Nugets-NugetRepository'></a>
## NugetRepository `type`

##### Namespace

Bb.Nugets

##### Summary

Nuget repository informations

<a name='P-Bb-Nugets-NugetRepository-Branch'></a>
### Branch `property`

##### Summary

Branch of the repository

<a name='P-Bb-Nugets-NugetRepository-Commit'></a>
### Commit `property`

##### Summary

Commit of the repository

<a name='P-Bb-Nugets-NugetRepository-Type'></a>
### Type `property`

##### Summary

Type of repository

<a name='P-Bb-Nugets-NugetRepository-Url'></a>
### Url `property`

##### Summary

Url of the repository

<a name='T-Bb-Compilers-ObjectResolverVisitor'></a>
## ObjectResolverVisitor `type`

##### Namespace

Bb.Compilers

<a name='M-Bb-Compilers-ObjectResolverVisitor-GetObjects-Microsoft-CodeAnalysis-SyntaxTree-'></a>
### GetObjects(tree) `method`

##### Summary

Return the list o objects that contains in source code

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tree | [Microsoft.CodeAnalysis.SyntaxTree](#T-Microsoft-CodeAnalysis-SyntaxTree 'Microsoft.CodeAnalysis.SyntaxTree') |  |

<a name='T-Bb-Builds-ProjectRoslynBuilderHelper'></a>
## ProjectRoslynBuilderHelper `type`

##### Namespace

Bb.Builds

<a name='M-Bb-Builds-ProjectRoslynBuilderHelper-CreateCsharpBuild-System-String,System-Boolean,System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}-'></a>
### CreateCsharpBuild(path,debug,configureCompilation) `method`

##### Summary

Create a new instance of [BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp') from project file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| debug | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |
| configureCompilation | [System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}') |  |

<a name='M-Bb-Builds-ProjectRoslynBuilderHelper-CreateCsharpBuild-System-IO-FileInfo,System-Boolean,System-Func{Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions,Microsoft-CodeAnalysis-CSharp-CSharpCompilationOptions}-'></a>
### CreateCsharpBuild(path,debug,configureCompilation) `method`

##### Summary

Create a new instance of [BuildCSharp](#T-Bb-Builds-BuildCSharp 'Bb.Builds.BuildCSharp') from project file

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| debug | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |
| configureCompilation | [System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions,Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions}') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |

<a name='T-Bb-Builds-ReferenceResolver'></a>
## ReferenceResolver `type`

##### Namespace

Bb.Builds

<a name='M-Bb-Builds-ReferenceResolver-#ctor-Bb-Builds-AssemblyReferences,Bb-Analysis-DiagTraces-ScriptDiagnostics-'></a>
### #ctor(assemblies) `constructor`

##### Summary

Create a new instance of [ReferenceResolver](#T-Bb-Builds-ReferenceResolver 'Bb.Builds.ReferenceResolver')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblies | [Bb.Builds.AssemblyReferences](#T-Bb-Builds-AssemblyReferences 'Bb.Builds.AssemblyReferences') |  |

<a name='P-Bb-Builds-ReferenceResolver-ResolveMissingAssemblies'></a>
### ResolveMissingAssemblies `property`

##### Summary

return state if the instance resolve missing assemblies

<a name='M-Bb-Builds-ReferenceResolver-Equals-System-Object-'></a>
### Equals(other) `method`

##### Summary

Determines whether the specified object instances are considered equal.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to compare |

<a name='M-Bb-Builds-ReferenceResolver-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as the default hash function.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-Metrology-RoslynActivityProvider'></a>
## RoslynActivityProvider `type`

##### Namespace

Bb.Metrology

##### Summary

Managing initialize activity source.

<a name='M-Bb-Metrology-RoslynActivityProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes the [ActivitySource](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivitySource 'System.Diagnostics.ActivitySource') object.

##### Parameters

This method has no parameters.

<a name='M-Bb-Metrology-RoslynActivityProvider-AddBaggage-System-String,System-String-'></a>
### AddBaggage(key,value) `method`

##### Summary

Add custom property to the current Activity object for the current execution context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Metrology-RoslynActivityProvider-AddEvent-System-String,System-ValueTuple{System-String,System-String}[]-'></a>
### AddEvent(eventName,tags) `method`

##### Summary

Add custom event to the current Activity object for the current execution context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| tags | [System.ValueTuple{System.String,System.String}[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.String,System.String}[]') |  |

<a name='M-Bb-Metrology-RoslynActivityProvider-AddProperty-System-String,System-Object-'></a>
### AddProperty(key,value) `method`

##### Summary

Add custom property to the current Activity object for the current execution context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-Metrology-RoslynActivityProvider-AddTag-System-String,System-Object-'></a>
### AddTag(key,value) `method`

##### Summary

Add custom property to the current Activity object for the current execution context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind-'></a>
### CreateActivity(name,kind) `method`

##### Summary

Creates a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any event listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

##### Remarks

If the Activity object is created, it will not start automatically. Callers need to call [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity.Start 'System.Diagnostics.Activity.Start') to start it.

<a name='M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-Diagnostics-ActivityIdFormat-'></a>
### CreateActivity(name,kind,parentContext,tags,links,idFormat) `method`

##### Summary

Creates a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity, returns null otherwise.
If the Activity object is created, it will not automatically start. Callers will need to call [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity.Start 'System.Diagnostics.Activity.Start') to start it.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity. |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |
| parentContext | [System.Diagnostics.ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') | The parent [ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') object to initialize the created Activity object with. |
| tags | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}') | The optional tags list to initialize the created Activity object with. |
| links | [System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}') | The optional [ActivityLink](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityLink 'System.Diagnostics.ActivityLink') list to initialize the created Activity object with. |
| idFormat | [System.Diagnostics.ActivityIdFormat](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityIdFormat 'System.Diagnostics.ActivityIdFormat') | The default Id format to use. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

##### Remarks

If the Activity object is created, it will not start automatically. Callers need to call [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity.Start 'System.Diagnostics.Activity.Start') to start it.

<a name='M-Bb-Metrology-RoslynActivityProvider-CreateActivity-System-String,System-Diagnostics-ActivityKind,System-String,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-Diagnostics-ActivityIdFormat-'></a>
### CreateActivity(name,kind,parentId,tags,links,idFormat) `method`

##### Summary

Creates a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity. |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |
| parentId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The parent Id to initialize the created Activity object with. |
| tags | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}') | The optional tags list to initialize the created Activity object with. |
| links | [System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}') | The optional [ActivityLink](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityLink 'System.Diagnostics.ActivityLink') list to initialize the created Activity object with. |
| idFormat | [System.Diagnostics.ActivityIdFormat](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityIdFormat 'System.Diagnostics.ActivityIdFormat') | The default Id format to use. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

##### Remarks

If the Activity object is created, it will not start automatically. Callers need to call [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity.Start 'System.Diagnostics.Activity.Start') to start it.

<a name='M-Bb-Metrology-RoslynActivityProvider-Set-System-Action{System-Diagnostics-Activity}-'></a>
### Set(action) `method`

##### Summary

Gets the current Activity object for the current execution context.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{System.Diagnostics.Activity}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Diagnostics.Activity}') | action to run with current activity |

<a name='M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind-'></a>
### StartActivity(name,kind) `method`

##### Summary

Creates and starts a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any event listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

<a name='M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset-'></a>
### StartActivity(name,kind,parentContext,tags,links,startTime) `method`

##### Summary

Creates and starts a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity events, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity. |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |
| parentContext | [System.Diagnostics.ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') | The parent [ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') object to initialize the created Activity object with. |
| tags | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}') | The optional tags list to initialize the created Activity object with. |
| links | [System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}') | The optional [ActivityLink](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityLink 'System.Diagnostics.ActivityLink') list to initialize the created Activity object with. |
| startTime | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The optional start timestamp to set on the created Activity object. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

<a name='M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-String,System-Diagnostics-ActivityKind,System-String,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset-'></a>
### StartActivity(name,kind,parentId,tags,links,startTime) `method`

##### Summary

Creates and starts a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity events, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity. |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |
| parentId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The parent Id to initialize the created Activity object with. |
| tags | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}') | The optional tags list to initialize the created Activity object with. |
| links | [System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}') | The optional [ActivityLink](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityLink 'System.Diagnostics.ActivityLink') list to initialize the created Activity object with. |
| startTime | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The optional start timestamp to set on the created Activity object. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

<a name='M-Bb-Metrology-RoslynActivityProvider-StartActivity-System-Diagnostics-ActivityKind,System-Diagnostics-ActivityContext,System-Collections-Generic-IEnumerable{System-Collections-Generic-KeyValuePair{System-String,System-Object}},System-Collections-Generic-IEnumerable{System-Diagnostics-ActivityLink},System-DateTimeOffset,System-String-'></a>
### StartActivity(kind,parentContext,tags,links,startTime,name) `method`

##### Summary

Creates and starts a new [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object if there is any listener to the Activity events, returns null otherwise.

##### Returns

The created [Activity](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Activity 'System.Diagnostics.Activity') object or null if there is no any listener.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| kind | [System.Diagnostics.ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') | The [ActivityKind](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityKind 'System.Diagnostics.ActivityKind') |
| parentContext | [System.Diagnostics.ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') | The parent [ActivityContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityContext 'System.Diagnostics.ActivityContext') object to initialize the created Activity object with. |
| tags | [System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}') | The optional tags list to initialize the created Activity object with. |
| links | [System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink}') | The optional [ActivityLink](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ActivityLink 'System.Diagnostics.ActivityLink') list to initialize the created Activity object with. |
| startTime | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The optional start timestamp to set on the created Activity object. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The operation name of the Activity. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | If the Activity already exists. |

<a name='T-Bb-Compilers-RoslynCompiler'></a>
## RoslynCompiler `type`

##### Namespace

Bb.Compilers

<a name='P-Bb-Compilers-RoslynCompiler-AssemblyAttributes'></a>
### AssemblyAttributes `property`

##### Summary

Add attributes in the assembly

<a name='P-Bb-Compilers-RoslynCompiler-Usings'></a>
### Usings `property`

##### Summary



<a name='M-Bb-Compilers-RoslynCompiler-AddCodeSource-Bb-Builds-SourceCodes-'></a>
### AddCodeSource(sources) `method`

##### Summary

Add sources to the compiler

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sources | [Bb.Builds.SourceCodes](#T-Bb-Builds-SourceCodes 'Bb.Builds.SourceCodes') |  |

<a name='M-Bb-Compilers-RoslynCompiler-AddCodeSource-System-String,System-String-'></a>
### AddCodeSource(source,path) `method`

##### Summary

Add source document to the compiler

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Compilers-RoslynCompiler-SetOutput-System-String-'></a>
### SetOutput(outputPah) `method`

##### Summary

Set the output path

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outputPah | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Codings-RoslynExtensions'></a>
## RoslynExtensions `type`

##### Namespace

Bb.Codings

##### Summary

Extension methods that help with creating of Roslyn syntax trees.

<a name='M-Bb-Codings-RoslynExtensions-AddAfterEach``1-System-Collections-Generic-IEnumerable{``0},``0-'></a>
### AddAfterEach\`\`1() `method`

##### Summary

Returns a collection that has
the given object added after each item in the original collection.

##### Parameters

This method has no parameters.

<a name='T-Bb-Builds-SourceCode'></a>
## SourceCode `type`

##### Namespace

Bb.Builds

<a name='P-Bb-Builds-SourceCode-Empty'></a>
### Empty `property`

##### Summary

Gets the empty source code.

<a name='P-Bb-Builds-SourceCode-File'></a>
### File `property`

##### Summary

Gets the file that contains the source code.

<a name='P-Bb-Builds-SourceCode-Filename'></a>
### Filename `property`

##### Summary

Gets the filename of the file.

<a name='P-Bb-Builds-SourceCode-IsDeleted'></a>
### IsDeleted `property`

##### Summary

Return true if the file was been deleted

<a name='P-Bb-Builds-SourceCode-IsGeneratedSource'></a>
### IsGeneratedSource `property`

##### Summary

Return true if the file is a generated source

<a name='P-Bb-Builds-SourceCode-IsMemorySource'></a>
### IsMemorySource `property`

##### Summary

return true if the source is in memory

<a name='P-Bb-Builds-SourceCode-Name'></a>
### Name `property`

##### Summary

Gets the name of the source.

<a name='P-Bb-Builds-SourceCode-Source'></a>
### Source `property`

##### Summary

Gets the source code.

<a name='M-Bb-Builds-SourceCode-GetFromFile-System-String,System-String-'></a>
### GetFromFile(filename,name) `method`

##### Summary

Create a new instance of [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |

<a name='M-Bb-Builds-SourceCode-GetFromFile-System-IO-FileInfo,System-String-'></a>
### GetFromFile(file,name) `method`

##### Summary

Create a new instance of [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |

<a name='M-Bb-Builds-SourceCode-GetFromText-System-Text-StringBuilder,System-String-'></a>
### GetFromText(payload,name) `method`

##### Summary

Create a new instance of [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| payload | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Builds-SourceCode-GetFromText-System-IO-FileInfo,System-String,System-String-'></a>
### GetFromText(file,payload,name) `method`

##### Summary

create a new instance of [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| payload | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Builds-SourceCode-GetFromText-System-String,System-String-'></a>
### GetFromText(payload,name) `method`

##### Summary

create a new instance of [SourceCode](#T-Bb-Builds-SourceCode 'Bb.Builds.SourceCode')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| payload | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Builds-SourceCode-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

A hash code for the current object.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-SourceCode-HasUpdated'></a>
### HasUpdated() `method`

##### Summary

Determines whether this file has been updated.

##### Returns

`true` if this instance has updated; otherwise, `false`.

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-SourceCode-Reload'></a>
### Reload() `method`

##### Summary

Reloads the code source from the file.

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-SourceCode-op_Implicit-System-Text-StringBuilder-~Bb-Builds-SourceCode'></a>
### op_Implicit(sb) `method`

##### Summary

implicit conversion from StringBuilder to SourceCode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder)~Bb.Builds.SourceCode](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder)~Bb.Builds.SourceCode 'System.Text.StringBuilder)~Bb.Builds.SourceCode') |  |

<a name='M-Bb-Builds-SourceCode-op_Implicit-System-String-~Bb-Builds-SourceCode'></a>
### op_Implicit(sb) `method`

##### Summary

implicit conversion from string to SourceCode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.String)~Bb.Builds.SourceCode](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)~Bb.Builds.SourceCode 'System.String)~Bb.Builds.SourceCode') |  |

<a name='M-Bb-Builds-SourceCode-op_Implicit-System-IO-FileInfo-~Bb-Builds-SourceCode'></a>
### op_Implicit(file) `method`

##### Summary

implicit conversion from FileInfo to SourceCode

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo)~Bb.Builds.SourceCode](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo)~Bb.Builds.SourceCode 'System.IO.FileInfo)~Bb.Builds.SourceCode') |  |

<a name='T-Bb-Builds-SourceCodes'></a>
## SourceCodes `type`

##### Namespace

Bb.Builds

<a name='M-Bb-Builds-SourceCodes-EnsureUptodated'></a>
### EnsureUptodated() `method`

##### Summary

Ensure all sources are uptodated

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-SourceCodes-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

A hash code for the current object.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-Codings-SyntaxEx'></a>
## SyntaxEx `type`

##### Namespace

Bb.Codings

##### Summary

Contains methods for easy creating of Roslyn syntax trees.

<a name='T-Bb-Nugets-VersionMatcher'></a>
## VersionMatcher `type`

##### Namespace

Bb.Nugets

<a name='M-Bb-Nugets-VersionMatcher-Parse-System-String-'></a>
### Parse(version) `method`

##### Summary

Parse the package nuget version constraint

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
