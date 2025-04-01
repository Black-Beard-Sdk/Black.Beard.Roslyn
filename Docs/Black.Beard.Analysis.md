<a name='assembly'></a>
# Black.Beard.Analysis

## Contents

- [DisposingStorage](#T-Bb-Analysis-Tools-DisposingStorage 'Bb.Analysis.Tools.DisposingStorage')
  - [#ctor(document)](#M-Bb-Analysis-Tools-DisposingStorage-#ctor-Bb-Analysis-Tools-IStoreSource- 'Bb.Analysis.Tools.DisposingStorage.#ctor(Bb.Analysis.Tools.IStoreSource)')
- [FileReferences](#T-Bb-Builds-FileReferences 'Bb.Builds.FileReferences')
  - [Resolve(filename)](#M-Bb-Builds-FileReferences-Resolve-System-String- 'Bb.Builds.FileReferences.Resolve(System.String)')
- [FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey')
  - [#ctor(name,version,languageVersion)](#M-Bb-Analysis-FrameworkKey-#ctor-System-String,System-String,System-Version,System-Int32- 'Bb.Analysis.FrameworkKey.#ctor(System.String,System.String,System.Version,System.Int32)')
  - [All](#P-Bb-Analysis-FrameworkKey-All 'Bb.Analysis.FrameworkKey.All')
  - [Add(frameworkKey)](#M-Bb-Analysis-FrameworkKey-Add-System-String,Bb-Analysis-FrameworkKey- 'Bb.Analysis.FrameworkKey.Add(System.String,Bb.Analysis.FrameworkKey)')
  - [Add(frameworkKey)](#M-Bb-Analysis-FrameworkKey-Add-Bb-Analysis-FrameworkKey- 'Bb.Analysis.FrameworkKey.Add(Bb.Analysis.FrameworkKey)')
  - [GetHashCode()](#M-Bb-Analysis-FrameworkKey-GetHashCode 'Bb.Analysis.FrameworkKey.GetHashCode')
  - [Resolve(version)](#M-Bb-Analysis-FrameworkKey-Resolve-System-Version- 'Bb.Analysis.FrameworkKey.Resolve(System.Version)')
  - [Resolve(name)](#M-Bb-Analysis-FrameworkKey-Resolve-System-String- 'Bb.Analysis.FrameworkKey.Resolve(System.String)')
  - [op_Implicit(name)](#M-Bb-Analysis-FrameworkKey-op_Implicit-System-String-~Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey.op_Implicit(System.String)~Bb.Analysis.FrameworkKey')
  - [op_Implicit(name)](#M-Bb-Analysis-FrameworkKey-op_Implicit-System-Version-~Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey.op_Implicit(System.Version)~Bb.Analysis.FrameworkKey')
- [FrameworkType](#T-Bb-Analysis-FrameworkType 'Bb.Analysis.FrameworkType')
  - [ResolveSdkName(sdk)](#M-Bb-Analysis-FrameworkType-ResolveSdkName-System-String- 'Bb.Analysis.FrameworkType.ResolveSdkName(System.String)')
- [FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion')
  - [All](#P-Bb-Builds-FrameworkVersion-All 'Bb.Builds.FrameworkVersion.All')
  - [Base](#P-Bb-Builds-FrameworkVersion-Base 'Bb.Builds.FrameworkVersion.Base')
  - [CurrentVersion](#P-Bb-Builds-FrameworkVersion-CurrentVersion 'Bb.Builds.FrameworkVersion.CurrentVersion')
  - [Directory](#P-Bb-Builds-FrameworkVersion-Directory 'Bb.Builds.FrameworkVersion.Directory')
  - [Type](#P-Bb-Builds-FrameworkVersion-Type 'Bb.Builds.FrameworkVersion.Type')
  - [GetReferences()](#M-Bb-Builds-FrameworkVersion-GetReferences 'Bb.Builds.FrameworkVersion.GetReferences')
  - [Initialize(dir)](#M-Bb-Builds-FrameworkVersion-Initialize-System-IO-DirectoryInfo- 'Bb.Builds.FrameworkVersion.Initialize(System.IO.DirectoryInfo)')
  - [InitializeAllFrameworks()](#M-Bb-Builds-FrameworkVersion-InitializeAllFrameworks 'Bb.Builds.FrameworkVersion.InitializeAllFrameworks')
  - [InitializeAllFrameworks(dir)](#M-Bb-Builds-FrameworkVersion-InitializeAllFrameworks-System-String- 'Bb.Builds.FrameworkVersion.InitializeAllFrameworks(System.String)')
  - [Initialize_AllVersions_Impl(dir)](#M-Bb-Builds-FrameworkVersion-Initialize_AllVersions_Impl-System-IO-DirectoryInfo- 'Bb.Builds.FrameworkVersion.Initialize_AllVersions_Impl(System.IO.DirectoryInfo)')
  - [IsInSdk(file)](#M-Bb-Builds-FrameworkVersion-IsInSdk-System-IO-FileInfo- 'Bb.Builds.FrameworkVersion.IsInSdk(System.IO.FileInfo)')
  - [ResolveVersions(frameworkVersion,type)](#M-Bb-Builds-FrameworkVersion-ResolveVersions-System-Version,Bb-Analysis-FrameworkType- 'Bb.Builds.FrameworkVersion.ResolveVersions(System.Version,Bb.Analysis.FrameworkType)')
  - [ResolveVersions(frameworkVersion,type)](#M-Bb-Builds-FrameworkVersion-ResolveVersions-Bb-Analysis-FrameworkKey,Bb-Analysis-FrameworkType- 'Bb.Builds.FrameworkVersion.ResolveVersions(Bb.Analysis.FrameworkKey,Bb.Analysis.FrameworkType)')
  - [ToString()](#M-Bb-Builds-FrameworkVersion-ToString 'Bb.Builds.FrameworkVersion.ToString')
- [Frameworks](#T-Bb-Builds-Frameworks 'Bb.Builds.Frameworks')
  - [HasVersion](#P-Bb-Builds-Frameworks-HasVersion 'Bb.Builds.Frameworks.HasVersion')
  - [Sdk](#P-Bb-Builds-Frameworks-Sdk 'Bb.Builds.Frameworks.Sdk')
  - [Version](#P-Bb-Builds-Frameworks-Version 'Bb.Builds.Frameworks.Version')
  - [GetFrameworkVersion()](#M-Bb-Builds-Frameworks-GetFrameworkVersion 'Bb.Builds.Frameworks.GetFrameworkVersion')
  - [GetLanguageVersion()](#M-Bb-Builds-Frameworks-GetLanguageVersion 'Bb.Builds.Frameworks.GetLanguageVersion')
  - [Reset()](#M-Bb-Builds-Frameworks-Reset 'Bb.Builds.Frameworks.Reset')
- [ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-ILocation-IsEmpty 'Bb.Analysis.DiagTraces.ILocation.IsEmpty')
  - [CanBeCompare(location)](#M-Bb-Analysis-DiagTraces-ILocation-CanBeCompare-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.ILocation.CanBeCompare(Bb.Analysis.DiagTraces.ILocation)')
  - [EndAfter(location)](#M-Bb-Analysis-DiagTraces-ILocation-EndAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.ILocation.EndAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [EndBefore(location)](#M-Bb-Analysis-DiagTraces-ILocation-EndBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.ILocation.EndBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [StartAfter(location)](#M-Bb-Analysis-DiagTraces-ILocation-StartAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.ILocation.StartAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [StartBefore(location)](#M-Bb-Analysis-DiagTraces-ILocation-StartBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.ILocation.StartBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-ILocation-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.ILocation.WriteTo(System.Text.StringBuilder)')
- [ILocationIndex](#T-Bb-Analysis-DiagTraces-ILocationIndex 'Bb.Analysis.DiagTraces.ILocationIndex')
  - [Index](#P-Bb-Analysis-DiagTraces-ILocationIndex-Index 'Bb.Analysis.DiagTraces.ILocationIndex.Index')
- [ILocationPath](#T-Bb-Analysis-DiagTraces-ILocationPath 'Bb.Analysis.DiagTraces.ILocationPath')
  - [Path](#P-Bb-Analysis-DiagTraces-ILocationPath-Path 'Bb.Analysis.DiagTraces.ILocationPath.Path')
- [IStore](#T-Bb-Analysis-Tools-IStore 'Bb.Analysis.Tools.IStore')
  - [AddInStorage(key,value)](#M-Bb-Analysis-Tools-IStore-AddInStorage-System-String,System-Object- 'Bb.Analysis.Tools.IStore.AddInStorage(System.String,System.Object)')
  - [ContainsInStorage(key)](#M-Bb-Analysis-Tools-IStore-ContainsInStorage-System-String- 'Bb.Analysis.Tools.IStore.ContainsInStorage(System.String)')
  - [TryGetInStorage(key,value)](#M-Bb-Analysis-Tools-IStore-TryGetInStorage-System-String,System-Object@- 'Bb.Analysis.Tools.IStore.TryGetInStorage(System.String,System.Object@)')
- [Libs](#T-Refs-Libs 'Refs.Libs')
  - [Items](#P-Refs-Libs-Items 'Refs.Libs.Items')
- [LocationDefault](#T-Bb-Analysis-DiagTraces-LocationDefault 'Bb.Analysis.DiagTraces.LocationDefault')
  - [#ctor()](#M-Bb-Analysis-DiagTraces-LocationDefault-#ctor 'Bb.Analysis.DiagTraces.LocationDefault.#ctor')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-LocationDefault-IsEmpty 'Bb.Analysis.DiagTraces.LocationDefault.IsEmpty')
  - [CanBeCompare(location)](#M-Bb-Analysis-DiagTraces-LocationDefault-CanBeCompare-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationDefault.CanBeCompare(Bb.Analysis.DiagTraces.ILocation)')
  - [Clone()](#M-Bb-Analysis-DiagTraces-LocationDefault-Clone 'Bb.Analysis.DiagTraces.LocationDefault.Clone')
  - [EndAfter(location)](#M-Bb-Analysis-DiagTraces-LocationDefault-EndAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationDefault.EndAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [EndBefore(location)](#M-Bb-Analysis-DiagTraces-LocationDefault-EndBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationDefault.EndBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [GetHashCode()](#M-Bb-Analysis-DiagTraces-LocationDefault-GetHashCode 'Bb.Analysis.DiagTraces.LocationDefault.GetHashCode')
  - [StartAfter(location)](#M-Bb-Analysis-DiagTraces-LocationDefault-StartAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationDefault.StartAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [StartBefore(location)](#M-Bb-Analysis-DiagTraces-LocationDefault-StartBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationDefault.StartBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-LocationDefault-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.LocationDefault.WriteTo(System.Text.StringBuilder)')
- [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex')
  - [#ctor(index)](#M-Bb-Analysis-DiagTraces-LocationIndex-#ctor-System-Int32- 'Bb.Analysis.DiagTraces.LocationIndex.#ctor(System.Int32)')
  - [Index](#P-Bb-Analysis-DiagTraces-LocationIndex-Index 'Bb.Analysis.DiagTraces.LocationIndex.Index')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-LocationIndex-IsEmpty 'Bb.Analysis.DiagTraces.LocationIndex.IsEmpty')
  - [CanBeCompare(location)](#M-Bb-Analysis-DiagTraces-LocationIndex-CanBeCompare-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationIndex.CanBeCompare(Bb.Analysis.DiagTraces.ILocation)')
  - [Clone()](#M-Bb-Analysis-DiagTraces-LocationIndex-Clone 'Bb.Analysis.DiagTraces.LocationIndex.Clone')
  - [EndAfter(location)](#M-Bb-Analysis-DiagTraces-LocationIndex-EndAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationIndex.EndAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [EndBefore(location)](#M-Bb-Analysis-DiagTraces-LocationIndex-EndBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationIndex.EndBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [StartAfter(location)](#M-Bb-Analysis-DiagTraces-LocationIndex-StartAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationIndex.StartAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [StartBefore(location)](#M-Bb-Analysis-DiagTraces-LocationIndex-StartBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationIndex.StartBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [ToString()](#M-Bb-Analysis-DiagTraces-LocationIndex-ToString 'Bb.Analysis.DiagTraces.LocationIndex.ToString')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-LocationIndex-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.LocationIndex.WriteTo(System.Text.StringBuilder)')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationIndex-op_Implicit-System-Int32-~Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex.op_Implicit(System.Int32)~Bb.Analysis.DiagTraces.LocationIndex')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationIndex-op_Implicit-Bb-Analysis-DiagTraces-LocationIndex-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationIndex.op_Implicit(Bb.Analysis.DiagTraces.LocationIndex)~Bb.Analysis.DiagTraces.TextLocation')
- [LocationLine](#T-Bb-Analysis-DiagTraces-LocationLine 'Bb.Analysis.DiagTraces.LocationLine')
  - [#ctor(position)](#M-Bb-Analysis-DiagTraces-LocationLine-#ctor-System-ValueTuple{System-Int32,System-Int32}- 'Bb.Analysis.DiagTraces.LocationLine.#ctor(System.ValueTuple{System.Int32,System.Int32})')
  - [#ctor(line)](#M-Bb-Analysis-DiagTraces-LocationLine-#ctor-System-Int32,System-Int32- 'Bb.Analysis.DiagTraces.LocationLine.#ctor(System.Int32,System.Int32)')
  - [Column](#P-Bb-Analysis-DiagTraces-LocationLine-Column 'Bb.Analysis.DiagTraces.LocationLine.Column')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-LocationLine-IsEmpty 'Bb.Analysis.DiagTraces.LocationLine.IsEmpty')
  - [Line](#P-Bb-Analysis-DiagTraces-LocationLine-Line 'Bb.Analysis.DiagTraces.LocationLine.Line')
  - [CanBeCompare(location)](#M-Bb-Analysis-DiagTraces-LocationLine-CanBeCompare-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLine.CanBeCompare(Bb.Analysis.DiagTraces.ILocation)')
  - [Clone()](#M-Bb-Analysis-DiagTraces-LocationLine-Clone 'Bb.Analysis.DiagTraces.LocationLine.Clone')
  - [EndAfter(location)](#M-Bb-Analysis-DiagTraces-LocationLine-EndAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLine.EndAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [EndBefore(location)](#M-Bb-Analysis-DiagTraces-LocationLine-EndBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLine.EndBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [StartAfter(location)](#M-Bb-Analysis-DiagTraces-LocationLine-StartAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLine.StartAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [StartBefore(location)](#M-Bb-Analysis-DiagTraces-LocationLine-StartBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLine.StartBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [ToString()](#M-Bb-Analysis-DiagTraces-LocationLine-ToString 'Bb.Analysis.DiagTraces.LocationLine.ToString')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-LocationLine-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.LocationLine.WriteTo(System.Text.StringBuilder)')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationLine-op_Implicit-System-ValueTuple{System-Int32,System-Int32}-~Bb-Analysis-DiagTraces-LocationLine 'Bb.Analysis.DiagTraces.LocationLine.op_Implicit(System.ValueTuple{System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLine')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationLine-op_Implicit-Bb-Analysis-DiagTraces-LocationLine-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationLine.op_Implicit(Bb.Analysis.DiagTraces.LocationLine)~Bb.Analysis.DiagTraces.TextLocation')
- [LocationLineAndIndex](#T-Bb-Analysis-DiagTraces-LocationLineAndIndex 'Bb.Analysis.DiagTraces.LocationLineAndIndex')
  - [#ctor(position,index)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-ValueTuple{System-Int32,System-Int32},System-Int32- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.#ctor(System.ValueTuple{System.Int32,System.Int32},System.Int32)')
  - [#ctor(position)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-ValueTuple{System-Int32,System-Int32,System-Int32}- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.#ctor(System.ValueTuple{System.Int32,System.Int32,System.Int32})')
  - [#ctor(index)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-Int32,System-Int32,System-Int32- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.#ctor(System.Int32,System.Int32,System.Int32)')
  - [Column](#P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Column 'Bb.Analysis.DiagTraces.LocationLineAndIndex.Column')
  - [Index](#P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Index 'Bb.Analysis.DiagTraces.LocationLineAndIndex.Index')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-LocationLineAndIndex-IsEmpty 'Bb.Analysis.DiagTraces.LocationLineAndIndex.IsEmpty')
  - [Line](#P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Line 'Bb.Analysis.DiagTraces.LocationLineAndIndex.Line')
  - [Clone()](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-Clone 'Bb.Analysis.DiagTraces.LocationLineAndIndex.Clone')
  - [EndAfter(location)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-EndAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.EndAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [EndBefore(location)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-EndBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.EndBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [StartAfter(location)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-StartAfter-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.StartAfter(Bb.Analysis.DiagTraces.ILocation)')
  - [StartBefore(location)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-StartBefore-Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.StartBefore(Bb.Analysis.DiagTraces.ILocation)')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.LocationLineAndIndex.WriteTo(System.Text.StringBuilder)')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-op_Implicit-System-ValueTuple{System-Int32,System-Int32,System-Int32}-~Bb-Analysis-DiagTraces-LocationLineAndIndex 'Bb.Analysis.DiagTraces.LocationLineAndIndex.op_Implicit(System.ValueTuple{System.Int32,System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLineAndIndex')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationLineAndIndex-op_Implicit-Bb-Analysis-DiagTraces-LocationLineAndIndex-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationLineAndIndex.op_Implicit(Bb.Analysis.DiagTraces.LocationLineAndIndex)~Bb.Analysis.DiagTraces.TextLocation')
- [LocationPath](#T-Bb-Analysis-DiagTraces-LocationPath 'Bb.Analysis.DiagTraces.LocationPath')
  - [#ctor(index)](#M-Bb-Analysis-DiagTraces-LocationPath-#ctor-System-String- 'Bb.Analysis.DiagTraces.LocationPath.#ctor(System.String)')
  - [IsEmpty](#P-Bb-Analysis-DiagTraces-LocationPath-IsEmpty 'Bb.Analysis.DiagTraces.LocationPath.IsEmpty')
  - [Path](#P-Bb-Analysis-DiagTraces-LocationPath-Path 'Bb.Analysis.DiagTraces.LocationPath.Path')
  - [Clone()](#M-Bb-Analysis-DiagTraces-LocationPath-Clone 'Bb.Analysis.DiagTraces.LocationPath.Clone')
  - [WriteTo(sb)](#M-Bb-Analysis-DiagTraces-LocationPath-WriteTo-System-Text-StringBuilder- 'Bb.Analysis.DiagTraces.LocationPath.WriteTo(System.Text.StringBuilder)')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-LocationPath-op_Implicit-System-String-~Bb-Analysis-DiagTraces-LocationPath 'Bb.Analysis.DiagTraces.LocationPath.op_Implicit(System.String)~Bb.Analysis.DiagTraces.LocationPath')
  - [op_Implicit(path)](#M-Bb-Analysis-DiagTraces-LocationPath-op_Implicit-Bb-Analysis-DiagTraces-LocationPath-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationPath.op_Implicit(Bb.Analysis.DiagTraces.LocationPath)~Bb.Analysis.DiagTraces.TextLocation')
- [ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic')
  - [#ctor(locations)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostic-#ctor-Bb-Analysis-DiagTraces-TextLocation[]- 'Bb.Analysis.DiagTraces.ScriptDiagnostic.#ctor(Bb.Analysis.DiagTraces.TextLocation[])')
  - [#ctor()](#M-Bb-Analysis-DiagTraces-ScriptDiagnostic-#ctor 'Bb.Analysis.DiagTraces.ScriptDiagnostic.#ctor')
  - [Filename](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Filename 'Bb.Analysis.DiagTraces.ScriptDiagnostic.Filename')
  - [IsSeverityAsError](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-IsSeverityAsError 'Bb.Analysis.DiagTraces.ScriptDiagnostic.IsSeverityAsError')
  - [Message](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Message 'Bb.Analysis.DiagTraces.ScriptDiagnostic.Message')
  - [Severity](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Severity 'Bb.Analysis.DiagTraces.ScriptDiagnostic.Severity')
  - [SeverityLevel](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-SeverityLevel 'Bb.Analysis.DiagTraces.ScriptDiagnostic.SeverityLevel')
  - [Text](#P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Text 'Bb.Analysis.DiagTraces.ScriptDiagnostic.Text')
  - [GetSeverity()](#M-Bb-Analysis-DiagTraces-ScriptDiagnostic-GetSeverity 'Bb.Analysis.DiagTraces.ScriptDiagnostic.GetSeverity')
  - [SetSeverity(severity)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostic-SetSeverity-Bb-Analysis-DiagTraces-SeverityEnum- 'Bb.Analysis.DiagTraces.ScriptDiagnostic.SetSeverity(Bb.Analysis.DiagTraces.SeverityEnum)')
- [ScriptDiagnostics](#T-Bb-Analysis-DiagTraces-ScriptDiagnostics 'Bb.Analysis.DiagTraces.ScriptDiagnostics')
  - [Count](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Count 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Count')
  - [Errors](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Errors 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Errors')
  - [InError](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-InError 'Bb.Analysis.DiagTraces.ScriptDiagnostics.InError')
  - [IsReadOnly](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-IsReadOnly 'Bb.Analysis.DiagTraces.ScriptDiagnostics.IsReadOnly')
  - [Item](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Item-System-Int32- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Item(System.Int32)')
  - [Success](#P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Success 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Success')
  - [Add(item)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Add-Bb-Analysis-DiagTraces-ScriptDiagnostic- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Add(Bb.Analysis.DiagTraces.ScriptDiagnostic)')
  - [Clear()](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Clear 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Clear')
  - [Contains(item)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Contains-Bb-Analysis-DiagTraces-ScriptDiagnostic- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Contains(Bb.Analysis.DiagTraces.ScriptDiagnostic)')
  - [CopyTo(array,arrayIndex)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-CopyTo-Bb-Analysis-DiagTraces-ScriptDiagnostic[],System-Int32- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.CopyTo(Bb.Analysis.DiagTraces.ScriptDiagnostic[],System.Int32)')
  - [GetEnumerator()](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-GetEnumerator 'Bb.Analysis.DiagTraces.ScriptDiagnostics.GetEnumerator')
  - [IndexOf(item)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-IndexOf-Bb-Analysis-DiagTraces-ScriptDiagnostic- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.IndexOf(Bb.Analysis.DiagTraces.ScriptDiagnostic)')
  - [Insert(index,item)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Insert-System-Int32,Bb-Analysis-DiagTraces-ScriptDiagnostic- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Insert(System.Int32,Bb.Analysis.DiagTraces.ScriptDiagnostic)')
  - [Remove(item)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Remove-Bb-Analysis-DiagTraces-ScriptDiagnostic- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.Remove(Bb.Analysis.DiagTraces.ScriptDiagnostic)')
  - [RemoveAt(index)](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-RemoveAt-System-Int32- 'Bb.Analysis.DiagTraces.ScriptDiagnostics.RemoveAt(System.Int32)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-Bb-Analysis-DiagTraces-ScriptDiagnostics-System#Collections#IEnumerable#GetEnumerator 'Bb.Analysis.DiagTraces.ScriptDiagnostics.System#Collections#IEnumerable#GetEnumerator')
- [SpanLocation\`2](#T-Bb-Analysis-DiagTraces-SpanLocation`2 'Bb.Analysis.DiagTraces.SpanLocation`2')
  - [#ctor()](#M-Bb-Analysis-DiagTraces-SpanLocation`2-#ctor-`0,`1- 'Bb.Analysis.DiagTraces.SpanLocation`2.#ctor(`0,`1)')
  - [Stop](#P-Bb-Analysis-DiagTraces-SpanLocation`2-Stop 'Bb.Analysis.DiagTraces.SpanLocation`2.Stop')
  - [Clone()](#M-Bb-Analysis-DiagTraces-SpanLocation`2-Clone 'Bb.Analysis.DiagTraces.SpanLocation`2.Clone')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-SpanLocation`2-op_Implicit-System-ValueTuple{`0,`1}-~Bb-Analysis-DiagTraces-SpanLocation{`0,`1} 'Bb.Analysis.DiagTraces.SpanLocation`2.op_Implicit(System.ValueTuple{`0,`1})~Bb.Analysis.DiagTraces.SpanLocation{`0,`1}')
- [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation')
  - [#ctor(position)](#M-Bb-Analysis-DiagTraces-TextLocation-#ctor-Bb-Analysis-DiagTraces-ILocation,Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.TextLocation.#ctor(Bb.Analysis.DiagTraces.ILocation,Bb.Analysis.DiagTraces.ILocation)')
  - [Empty](#F-Bb-Analysis-DiagTraces-TextLocation-Empty 'Bb.Analysis.DiagTraces.TextLocation.Empty')
  - [Datas](#P-Bb-Analysis-DiagTraces-TextLocation-Datas 'Bb.Analysis.DiagTraces.TextLocation.Datas')
  - [Filename](#P-Bb-Analysis-DiagTraces-TextLocation-Filename 'Bb.Analysis.DiagTraces.TextLocation.Filename')
  - [Start](#P-Bb-Analysis-DiagTraces-TextLocation-Start 'Bb.Analysis.DiagTraces.TextLocation.Start')
  - [Stop](#P-Bb-Analysis-DiagTraces-TextLocation-Stop 'Bb.Analysis.DiagTraces.TextLocation.Stop')
  - [Add(datas)](#M-Bb-Analysis-DiagTraces-TextLocation-Add-System-Collections-Generic-Dictionary{System-String,System-Object}- 'Bb.Analysis.DiagTraces.TextLocation.Add(System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [Add(item)](#M-Bb-Analysis-DiagTraces-TextLocation-Add-System-Collections-Generic-KeyValuePair{System-String,System-Object}- 'Bb.Analysis.DiagTraces.TextLocation.Add(System.Collections.Generic.KeyValuePair{System.String,System.Object})')
  - [Clone()](#M-Bb-Analysis-DiagTraces-TextLocation-Clone 'Bb.Analysis.DiagTraces.TextLocation.Clone')
  - [Create(location,initializer)](#M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Action{Bb-Analysis-DiagTraces-TextLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex}}- 'Bb.Analysis.DiagTraces.TextLocation.Create(System.ValueTuple{System.Int32,System.Int32,System.Int32},System.Action{Bb.Analysis.DiagTraces.TextLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex}})')
  - [Create(location,right,initializer)](#M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Int32,System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,Bb-Analysis-DiagTraces-LocationIndex}}- 'Bb.Analysis.DiagTraces.TextLocation.Create(System.ValueTuple{System.Int32,System.Int32,System.Int32},System.Int32,System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationIndex}})')
  - [Create(location,right,initializer)](#M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,Bb-Analysis-DiagTraces-LocationLineAndIndex}}- 'Bb.Analysis.DiagTraces.TextLocation.Create(System.ValueTuple{System.Int32,System.Int32,System.Int32},System.ValueTuple{System.Int32,System.Int32,System.Int32},System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationLineAndIndex}})')
  - [Create\`\`1(location,right,initializer)](#M-Bb-Analysis-DiagTraces-TextLocation-Create``1-System-ValueTuple{System-Int32,System-Int32,System-Int32},``0,System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,``0}}- 'Bb.Analysis.DiagTraces.TextLocation.Create``1(System.ValueTuple{System.Int32,System.Int32,System.Int32},``0,System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,``0}})')
  - [Get(self,key)](#M-Bb-Analysis-DiagTraces-TextLocation-Get-System-String- 'Bb.Analysis.DiagTraces.TextLocation.Get(System.String)')
- [TextLocationExtension](#T-Bb-Analysis-DiagTraces-TextLocationExtension 'Bb.Analysis.DiagTraces.TextLocationExtension')
  - [Add\`\`1(self,key,value)](#M-Bb-Analysis-DiagTraces-TextLocationExtension-Add``1-``0,System-String,System-Object- 'Bb.Analysis.DiagTraces.TextLocationExtension.Add``1(``0,System.String,System.Object)')
  - [Copy\`\`1(self)](#M-Bb-Analysis-DiagTraces-TextLocationExtension-Copy``1-``0- 'Bb.Analysis.DiagTraces.TextLocationExtension.Copy``1(``0)')
  - [InDocument\`\`1(self,documentName)](#M-Bb-Analysis-DiagTraces-TextLocationExtension-InDocument``1-``0,System-String- 'Bb.Analysis.DiagTraces.TextLocationExtension.InDocument``1(``0,System.String)')
- [TextLocation\`1](#T-Bb-Analysis-DiagTraces-TextLocation`1 'Bb.Analysis.DiagTraces.TextLocation`1')
  - [#ctor(start)](#M-Bb-Analysis-DiagTraces-TextLocation`1-#ctor-`0,Bb-Analysis-DiagTraces-ILocation- 'Bb.Analysis.DiagTraces.TextLocation`1.#ctor(`0,Bb.Analysis.DiagTraces.ILocation)')
  - [#ctor(start)](#M-Bb-Analysis-DiagTraces-TextLocation`1-#ctor-`0- 'Bb.Analysis.DiagTraces.TextLocation`1.#ctor(`0)')
  - [Start](#P-Bb-Analysis-DiagTraces-TextLocation`1-Start 'Bb.Analysis.DiagTraces.TextLocation`1.Start')
  - [Clone()](#M-Bb-Analysis-DiagTraces-TextLocation`1-Clone 'Bb.Analysis.DiagTraces.TextLocation`1.Clone')
  - [ToString()](#M-Bb-Analysis-DiagTraces-TextLocation`1-ToString 'Bb.Analysis.DiagTraces.TextLocation`1.ToString')
  - [op_Implicit(position)](#M-Bb-Analysis-DiagTraces-TextLocation`1-op_Implicit-`0-~Bb-Analysis-DiagTraces-TextLocation{`0} 'Bb.Analysis.DiagTraces.TextLocation`1.op_Implicit(`0)~Bb.Analysis.DiagTraces.TextLocation{`0}')

<a name='T-Bb-Analysis-Tools-DisposingStorage'></a>
## DisposingStorage `type`

##### Namespace

Bb.Analysis.Tools

##### Summary

Object for storing data in processing visitor

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Analysis-Tools-DisposingStorage-#ctor-Bb-Analysis-Tools-IStoreSource-'></a>
### #ctor(document) `constructor`

##### Summary

Initializes a new instance of the [](#!-DisposingStorage<T> 'DisposingStorage<T>') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Bb.Analysis.Tools.IStoreSource](#T-Bb-Analysis-Tools-IStoreSource 'Bb.Analysis.Tools.IStoreSource') |  |

<a name='T-Bb-Builds-FileReferences'></a>
## FileReferences `type`

##### Namespace

Bb.Builds

<a name='M-Bb-Builds-FileReferences-Resolve-System-String-'></a>
### Resolve(filename) `method`

##### Summary

resolve the full path of the specified assembly

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Analysis-FrameworkKey'></a>
## FrameworkKey `type`

##### Namespace

Bb.Analysis

<a name='M-Bb-Analysis-FrameworkKey-#ctor-System-String,System-String,System-Version,System-Int32-'></a>
### #ctor(name,version,languageVersion) `constructor`

##### Summary

ctor with name and version

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| version | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| languageVersion | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |

<a name='P-Bb-Analysis-FrameworkKey-All'></a>
### All `property`

##### Summary

return all framework keys

<a name='M-Bb-Analysis-FrameworkKey-Add-System-String,Bb-Analysis-FrameworkKey-'></a>
### Add(frameworkKey) `method`

##### Summary

Add a new framework key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Analysis-FrameworkKey-Add-Bb-Analysis-FrameworkKey-'></a>
### Add(frameworkKey) `method`

##### Summary

Add a new framework key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkKey | [Bb.Analysis.FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey') |  |

<a name='M-Bb-Analysis-FrameworkKey-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Gets a hash code for this string.  If strings A and B are such that A.Equals(B), then they will return the same hash code.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-FrameworkKey-Resolve-System-Version-'></a>
### Resolve(version) `method`

##### Summary

resolve by version

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') |  |

<a name='M-Bb-Analysis-FrameworkKey-Resolve-System-String-'></a>
### Resolve(name) `method`

##### Summary

resolve by name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') |  |

<a name='M-Bb-Analysis-FrameworkKey-op_Implicit-System-String-~Bb-Analysis-FrameworkKey'></a>
### op_Implicit(name) `method`

##### Summary

convert a string to a framework key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String)~Bb.Analysis.FrameworkKey](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)~Bb.Analysis.FrameworkKey 'System.String)~Bb.Analysis.FrameworkKey') |  |

<a name='M-Bb-Analysis-FrameworkKey-op_Implicit-System-Version-~Bb-Analysis-FrameworkKey'></a>
### op_Implicit(name) `method`

##### Summary

convert a version to a framework key

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.Version)~Bb.Analysis.FrameworkKey](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version)~Bb.Analysis.FrameworkKey 'System.Version)~Bb.Analysis.FrameworkKey') |  |

<a name='T-Bb-Analysis-FrameworkType'></a>
## FrameworkType `type`

##### Namespace

Bb.Analysis

<a name='M-Bb-Analysis-FrameworkType-ResolveSdkName-System-String-'></a>
### ResolveSdkName(sdk) `method`

##### Summary

Resolve type from sdk name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sdk | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Builds-FrameworkVersion'></a>
## FrameworkVersion `type`

##### Namespace

Bb.Builds

##### Summary

Sdk installed on the system.

<a name='P-Bb-Builds-FrameworkVersion-All'></a>
### All `property`

##### Summary

Gets the framework versions installed on the system.

<a name='P-Bb-Builds-FrameworkVersion-Base'></a>
### Base `property`

##### Summary

Gets the base framework.

<a name='P-Bb-Builds-FrameworkVersion-CurrentVersion'></a>
### CurrentVersion `property`

##### Summary

return the current running framework

<a name='P-Bb-Builds-FrameworkVersion-Directory'></a>
### Directory `property`

##### Summary

Gets the directory where the libraries can be found.

<a name='P-Bb-Builds-FrameworkVersion-Type'></a>
### Type `property`

##### Summary

Gets the type of sdk.

<a name='M-Bb-Builds-FrameworkVersion-GetReferences'></a>
### GetReferences() `method`

##### Summary

Gets the references of the directory.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-FrameworkVersion-Initialize-System-IO-DirectoryInfo-'></a>
### Initialize(dir) `method`

##### Summary

Discover all available framework versions from directory.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dir | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') | The dir. |

<a name='M-Bb-Builds-FrameworkVersion-InitializeAllFrameworks'></a>
### InitializeAllFrameworks() `method`

##### Summary

Discover all available framework versions from system directory.

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-FrameworkVersion-InitializeAllFrameworks-System-String-'></a>
### InitializeAllFrameworks(dir) `method`

##### Summary

Discover all available framework versions from directory.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dir | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The dir. |

<a name='M-Bb-Builds-FrameworkVersion-Initialize_AllVersions_Impl-System-IO-DirectoryInfo-'></a>
### Initialize_AllVersions_Impl(dir) `method`

##### Summary

Discover all available framework versions in the directory.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dir | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') | The dir. |

<a name='M-Bb-Builds-FrameworkVersion-IsInSdk-System-IO-FileInfo-'></a>
### IsInSdk(file) `method`

##### Summary

return true if the file is located in the sdk directory.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |

<a name='M-Bb-Builds-FrameworkVersion-ResolveVersions-System-Version,Bb-Analysis-FrameworkType-'></a>
### ResolveVersions(frameworkVersion,type) `method`

##### Summary

Try to Resolve specified versions in the available version installed on system.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkVersion | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') | The framework version. |
| type | [Bb.Analysis.FrameworkType](#T-Bb-Analysis-FrameworkType 'Bb.Analysis.FrameworkType') | The type of sdk. |

<a name='M-Bb-Builds-FrameworkVersion-ResolveVersions-Bb-Analysis-FrameworkKey,Bb-Analysis-FrameworkType-'></a>
### ResolveVersions(frameworkVersion,type) `method`

##### Summary

Try to Resolve specified versions in the available version installed on system.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frameworkVersion | [Bb.Analysis.FrameworkKey](#T-Bb-Analysis-FrameworkKey 'Bb.Analysis.FrameworkKey') | The framework version. |
| type | [Bb.Analysis.FrameworkType](#T-Bb-Analysis-FrameworkType 'Bb.Analysis.FrameworkType') | The type of sdk. |

<a name='M-Bb-Builds-FrameworkVersion-ToString'></a>
### ToString() `method`

##### Summary

return the user friendly of the [FrameworkVersion](#T-Bb-Builds-FrameworkVersion 'Bb.Builds.FrameworkVersion')

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Bb-Builds-Frameworks'></a>
## Frameworks `type`

##### Namespace

Bb.Builds

<a name='P-Bb-Builds-Frameworks-HasVersion'></a>
### HasVersion `property`

##### Summary

return true whether has version.

<a name='P-Bb-Builds-Frameworks-Sdk'></a>
### Sdk `property`

##### Summary

Gets or sets the SDK.

<a name='P-Bb-Builds-Frameworks-Version'></a>
### Version `property`

##### Summary

Gets or sets the version.

<a name='M-Bb-Builds-Frameworks-GetFrameworkVersion'></a>
### GetFrameworkVersion() `method`

##### Summary

Resolve the framework to use for build.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-Frameworks-GetLanguageVersion'></a>
### GetLanguageVersion() `method`

##### Summary

Gets or sets the language version.

##### Parameters

This method has no parameters.

<a name='M-Bb-Builds-Frameworks-Reset'></a>
### Reset() `method`

##### Summary



##### Parameters

This method has no parameters.

<a name='T-Bb-Analysis-DiagTraces-ILocation'></a>
## ILocation `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='P-Bb-Analysis-DiagTraces-ILocation-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='M-Bb-Analysis-DiagTraces-ILocation-CanBeCompare-Bb-Analysis-DiagTraces-ILocation-'></a>
### CanBeCompare(location) `method`

##### Summary

return true if the current location can be compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-ILocation-EndAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndAfter(location) `method`

##### Summary

return true if the current location end after the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-ILocation-EndBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndBefore(location) `method`

##### Summary

return true if the current location end before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-ILocation-StartAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartAfter(location) `method`

##### Summary

return true if the current position start before the specified location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-ILocation-StartBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartBefore(location) `method`

##### Summary

return true if the current location start before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-ILocation-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='T-Bb-Analysis-DiagTraces-ILocationIndex'></a>
## ILocationIndex `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='P-Bb-Analysis-DiagTraces-ILocationIndex-Index'></a>
### Index `property`

##### Summary

index position

<a name='T-Bb-Analysis-DiagTraces-ILocationPath'></a>
## ILocationPath `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='P-Bb-Analysis-DiagTraces-ILocationPath-Path'></a>
### Path `property`

##### Summary

Path position

<a name='T-Bb-Analysis-Tools-IStore'></a>
## IStore `type`

##### Namespace

Bb.Analysis.Tools

<a name='M-Bb-Analysis-Tools-IStore-AddInStorage-System-String,System-Object-'></a>
### AddInStorage(key,value) `method`

##### Summary

Add or replace the value in the storage

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Bb-Analysis-Tools-IStore-ContainsInStorage-System-String-'></a>
### ContainsInStorage(key) `method`

##### Summary

Return true if the storage contains the specified key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Analysis-Tools-IStore-TryGetInStorage-System-String,System-Object@-'></a>
### TryGetInStorage(key,value) `method`

##### Summary

Return true if the storage contains the specified key. The value is returned in the out value way

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.Object@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object@ 'System.Object@') |  |

<a name='T-Refs-Libs'></a>
## Libs `type`

##### Namespace

Refs

<a name='P-Refs-Libs-Items'></a>
### Items `property`

##### Summary

REturn the list of assemblies

<a name='T-Bb-Analysis-DiagTraces-LocationDefault'></a>
## LocationDefault `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [LocationDefault](#T-Bb-Analysis-DiagTraces-LocationDefault 'Bb.Analysis.DiagTraces.LocationDefault') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Analysis-DiagTraces-LocationDefault-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-CanBeCompare-Bb-Analysis-DiagTraces-ILocation-'></a>
### CanBeCompare(location) `method`

##### Summary

return true if the current location can be compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-EndAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndAfter(location) `method`

##### Summary

return true if the current location end after the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-EndBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndBefore(location) `method`

##### Summary

return true if the current location end before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Gets a hash code for this string.  If strings A and B are such that A.Equals(B), then

##### Returns

they will return the same hash code.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-StartAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartAfter(location) `method`

##### Summary

return true if the current position start before the specified location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-StartBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartBefore(location) `method`

##### Summary

return true if the current location start before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationDefault-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='T-Bb-Analysis-DiagTraces-LocationIndex'></a>
## LocationIndex `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-#ctor-System-Int32-'></a>
### #ctor(index) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-Bb-Analysis-DiagTraces-LocationIndex-Index'></a>
### Index `property`

##### Summary

index position

<a name='P-Bb-Analysis-DiagTraces-LocationIndex-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-CanBeCompare-Bb-Analysis-DiagTraces-ILocation-'></a>
### CanBeCompare(location) `method`

##### Summary

return true if the current location can be compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-EndAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndAfter(location) `method`

##### Summary

return true if the current location end after the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-EndBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndBefore(location) `method`

##### Summary

return true if the current location end before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-StartAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartAfter(location) `method`

##### Summary

return true if the current position start before the specified location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-StartBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartBefore(location) `method`

##### Summary

return true if the current location start before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-op_Implicit-System-Int32-~Bb-Analysis-DiagTraces-LocationIndex'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') to [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Int32)~Bb.Analysis.DiagTraces.LocationIndex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32)~Bb.Analysis.DiagTraces.LocationIndex 'System.Int32)~Bb.Analysis.DiagTraces.LocationIndex') | The position. |

<a name='M-Bb-Analysis-DiagTraces-LocationIndex-op_Implicit-Bb-Analysis-DiagTraces-LocationIndex-~Bb-Analysis-DiagTraces-TextLocation'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Bb.Analysis.DiagTraces.LocationIndex)~Bb.Analysis.DiagTraces.TextLocation](#T-Bb-Analysis-DiagTraces-LocationIndex-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationIndex)~Bb.Analysis.DiagTraces.TextLocation') |  |

<a name='T-Bb-Analysis-DiagTraces-LocationLine'></a>
## LocationLine `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-LocationLine-#ctor-System-ValueTuple{System-Int32,System-Int32}-'></a>
### #ctor(position) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32}') | (line, column) |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-#ctor-System-Int32,System-Int32-'></a>
### #ctor(line) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-Bb-Analysis-DiagTraces-LocationLine-Column'></a>
### Column `property`

##### Summary

Line position

<a name='P-Bb-Analysis-DiagTraces-LocationLine-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='P-Bb-Analysis-DiagTraces-LocationLine-Line'></a>
### Line `property`

##### Summary

Line position

<a name='M-Bb-Analysis-DiagTraces-LocationLine-CanBeCompare-Bb-Analysis-DiagTraces-ILocation-'></a>
### CanBeCompare(location) `method`

##### Summary

return true if the current location can be compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationLine-EndAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndAfter(location) `method`

##### Summary

return true if the current location end after the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-EndBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndBefore(location) `method`

##### Summary

return true if the current location end before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-StartAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartAfter(location) `method`

##### Summary

return true if the current position start before the specified location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-StartBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartBefore(location) `method`

##### Summary

return true if the current location start before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationLine-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-op_Implicit-System-ValueTuple{System-Int32,System-Int32}-~Bb-Analysis-DiagTraces-LocationLine'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [](#!-ValueTuple<int, int> 'ValueTuple<int, int>') to [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLine](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLine') | The position. |

<a name='M-Bb-Analysis-DiagTraces-LocationLine-op_Implicit-Bb-Analysis-DiagTraces-LocationLine-~Bb-Analysis-DiagTraces-TextLocation'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [LocationLine](#T-Bb-Analysis-DiagTraces-LocationLine 'Bb.Analysis.DiagTraces.LocationLine') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Bb.Analysis.DiagTraces.LocationLine)~Bb.Analysis.DiagTraces.TextLocation](#T-Bb-Analysis-DiagTraces-LocationLine-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationLine)~Bb.Analysis.DiagTraces.TextLocation') |  |

<a name='T-Bb-Analysis-DiagTraces-LocationLineAndIndex'></a>
## LocationLineAndIndex `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-ValueTuple{System-Int32,System-Int32},System-Int32-'></a>
### #ctor(position,index) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32}') | (line, column) |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | index |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-ValueTuple{System-Int32,System-Int32,System-Int32}-'></a>
### #ctor(position) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') | (line, column, index) |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-#ctor-System-Int32,System-Int32,System-Int32-'></a>
### #ctor(index) `constructor`

##### Summary

Initializes a new instance of the [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Column'></a>
### Column `property`

##### Summary

Line position

<a name='P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Index'></a>
### Index `property`

##### Summary

Line position

<a name='P-Bb-Analysis-DiagTraces-LocationLineAndIndex-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='P-Bb-Analysis-DiagTraces-LocationLineAndIndex-Line'></a>
### Line `property`

##### Summary

Line position

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-EndAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndAfter(location) `method`

##### Summary

return true if the current location end after the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-EndBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### EndBefore(location) `method`

##### Summary

return true if the current location end before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-StartAfter-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartAfter(location) `method`

##### Summary

return true if the current position start before the specified location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-StartBefore-Bb-Analysis-DiagTraces-ILocation-'></a>
### StartBefore(location) `method`

##### Summary

return true if the current location start before the compared with another location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | the location to compare |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-op_Implicit-System-ValueTuple{System-Int32,System-Int32,System-Int32}-~Bb-Analysis-DiagTraces-LocationLineAndIndex'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [](#!-ValueTuple<int, int> 'ValueTuple<int, int>') to [LocationIndex](#T-Bb-Analysis-DiagTraces-LocationIndex 'Bb.Analysis.DiagTraces.LocationIndex').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{System.Int32,System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLineAndIndex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32})~Bb.Analysis.DiagTraces.LocationLineAndIndex') | The position. |

<a name='M-Bb-Analysis-DiagTraces-LocationLineAndIndex-op_Implicit-Bb-Analysis-DiagTraces-LocationLineAndIndex-~Bb-Analysis-DiagTraces-TextLocation'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [LocationLineAndIndex](#T-Bb-Analysis-DiagTraces-LocationLineAndIndex 'Bb.Analysis.DiagTraces.LocationLineAndIndex') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Bb.Analysis.DiagTraces.LocationLineAndIndex)~Bb.Analysis.DiagTraces.TextLocation](#T-Bb-Analysis-DiagTraces-LocationLineAndIndex-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationLineAndIndex)~Bb.Analysis.DiagTraces.TextLocation') |  |

<a name='T-Bb-Analysis-DiagTraces-LocationPath'></a>
## LocationPath `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-LocationPath-#ctor-System-String-'></a>
### #ctor(index) `constructor`

##### Summary

Initializes a new instance of the [LocationPath](#T-Bb-Analysis-DiagTraces-LocationPath 'Bb.Analysis.DiagTraces.LocationPath') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='P-Bb-Analysis-DiagTraces-LocationPath-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Gets a value indicating whether this instance is the empty instance.

<a name='P-Bb-Analysis-DiagTraces-LocationPath-Path'></a>
### Path `property`

##### Summary

index position

<a name='M-Bb-Analysis-DiagTraces-LocationPath-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-LocationPath-WriteTo-System-Text-StringBuilder-'></a>
### WriteTo(sb) `method`

##### Summary

Writes message to specified [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') |  |

<a name='M-Bb-Analysis-DiagTraces-LocationPath-op_Implicit-System-String-~Bb-Analysis-DiagTraces-LocationPath'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to [LocationPath](#T-Bb-Analysis-DiagTraces-LocationPath 'Bb.Analysis.DiagTraces.LocationPath').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.String)~Bb.Analysis.DiagTraces.LocationPath](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)~Bb.Analysis.DiagTraces.LocationPath 'System.String)~Bb.Analysis.DiagTraces.LocationPath') | The position. |

<a name='M-Bb-Analysis-DiagTraces-LocationPath-op_Implicit-Bb-Analysis-DiagTraces-LocationPath-~Bb-Analysis-DiagTraces-TextLocation'></a>
### op_Implicit(path) `method`

##### Summary

Performs an implicit conversion from [LocationPath](#T-Bb-Analysis-DiagTraces-LocationPath 'Bb.Analysis.DiagTraces.LocationPath') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [Bb.Analysis.DiagTraces.LocationPath)~Bb.Analysis.DiagTraces.TextLocation](#T-Bb-Analysis-DiagTraces-LocationPath-~Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.LocationPath)~Bb.Analysis.DiagTraces.TextLocation') |  |

<a name='T-Bb-Analysis-DiagTraces-ScriptDiagnostic'></a>
## ScriptDiagnostic `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostic-#ctor-Bb-Analysis-DiagTraces-TextLocation[]-'></a>
### #ctor(locations) `constructor`

##### Summary

Initializes a new instance of the [ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| locations | [Bb.Analysis.DiagTraces.TextLocation[]](#T-Bb-Analysis-DiagTraces-TextLocation[] 'Bb.Analysis.DiagTraces.TextLocation[]') | The list of locations. |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostic-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Filename'></a>
### Filename `property`

##### Summary

Gets the filename of the first Diagnostic location

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-IsSeverityAsError'></a>
### IsSeverityAsError `property`

##### Summary

Gets or sets a value indicating whether this instance is severity as error.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Message'></a>
### Message `property`

##### Summary

Gets or sets the message that explain the diagnostic

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Severity'></a>
### Severity `property`

##### Summary

Gets or sets the severity Name.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-SeverityLevel'></a>
### SeverityLevel `property`

##### Summary

Gets or sets the severity level.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostic-Text'></a>
### Text `property`

##### Summary

Gets or sets the text that causes the diagnostic item

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostic-GetSeverity'></a>
### GetSeverity() `method`

##### Summary

Gets the severity in [SeverityEnum](#T-SeverityEnum 'SeverityEnum').

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostic-SetSeverity-Bb-Analysis-DiagTraces-SeverityEnum-'></a>
### SetSeverity(severity) `method`

##### Summary

Sets the severity.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| severity | [Bb.Analysis.DiagTraces.SeverityEnum](#T-Bb-Analysis-DiagTraces-SeverityEnum 'Bb.Analysis.DiagTraces.SeverityEnum') | The severity. |

<a name='T-Bb-Analysis-DiagTraces-ScriptDiagnostics'></a>
## ScriptDiagnostics `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Count'></a>
### Count `property`

##### Summary

Gets the number of elements contained in the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Errors'></a>
### Errors `property`

##### Summary

Gets the errors diagnostic items.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-InError'></a>
### InError `property`

##### Summary

Gets a value indicating whether this [ScriptDiagnostics](#T-Bb-Analysis-DiagTraces-ScriptDiagnostics 'Bb.Analysis.DiagTraces.ScriptDiagnostics') is in error. then the list of diagnostic contains error.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

Gets a value indicating whether the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1') is read-only.

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Item-System-Int32-'></a>
### Item `property`

##### Summary

Gets or sets the [ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') at the specified index.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The index. |

<a name='P-Bb-Analysis-DiagTraces-ScriptDiagnostics-Success'></a>
### Success `property`

##### Summary

Gets a value indicating whether this [ScriptDiagnostics](#T-Bb-Analysis-DiagTraces-ScriptDiagnostics 'Bb.Analysis.DiagTraces.ScriptDiagnostics') is success. then the list of diagnostic don't contains error.

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Add-Bb-Analysis-DiagTraces-ScriptDiagnostic-'></a>
### Add(item) `method`

##### Summary

Adds an item to the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.Analysis.DiagTraces.ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') | The object to add to the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'). |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Clear'></a>
### Clear() `method`

##### Summary

Removes all items from the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Contains-Bb-Analysis-DiagTraces-ScriptDiagnostic-'></a>
### Contains(item) `method`

##### Summary

Determines whether this instance contains the object.

##### Returns

`true` if `item` is found in the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.Analysis.DiagTraces.ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') | The object to locate in the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'). |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-CopyTo-Bb-Analysis-DiagTraces-ScriptDiagnostic[],System-Int32-'></a>
### CopyTo(array,arrayIndex) `method`

##### Summary

Copies the elements of the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1') to an [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array'), starting at a particular [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array') index.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| array | [Bb.Analysis.DiagTraces.ScriptDiagnostic[]](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic[] 'Bb.Analysis.DiagTraces.ScriptDiagnostic[]') | The one-dimensional [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array') that is the destination of the elements copied from [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'). The [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array') must have zero-based indexing. |
| arrayIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index in `array` at which copying begins. |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through the collection.

##### Returns

An enumerator that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-IndexOf-Bb-Analysis-DiagTraces-ScriptDiagnostic-'></a>
### IndexOf(item) `method`

##### Summary

Determines the index of a specific item in the [IList\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList`1 'System.Collections.Generic.IList`1').

##### Returns

The index of `item` if found in the list; otherwise, -1.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.Analysis.DiagTraces.ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') | The object to locate in the [IList\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList`1 'System.Collections.Generic.IList`1'). |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Insert-System-Int32,Bb-Analysis-DiagTraces-ScriptDiagnostic-'></a>
### Insert(index,item) `method`

##### Summary

Inserts an item to the [IList\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList`1 'System.Collections.Generic.IList`1') at the specified index.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index at which `item` should be inserted. |
| item | [Bb.Analysis.DiagTraces.ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') | The object to insert into the [IList\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList`1 'System.Collections.Generic.IList`1'). |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-Remove-Bb-Analysis-DiagTraces-ScriptDiagnostic-'></a>
### Remove(item) `method`

##### Summary

Removes the first occurrence of a specific object from the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

##### Returns

`true` if `item` was successfully removed from the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'); otherwise, `false`. This method also returns `false` if `item` is not found in the original [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Bb.Analysis.DiagTraces.ScriptDiagnostic](#T-Bb-Analysis-DiagTraces-ScriptDiagnostic 'Bb.Analysis.DiagTraces.ScriptDiagnostic') | The object to remove from the [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1'). |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-RemoveAt-System-Int32-'></a>
### RemoveAt(index) `method`

##### Summary

Removes the [IList\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList`1 'System.Collections.Generic.IList`1') item at the specified index.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index of the item to remove. |

<a name='M-Bb-Analysis-DiagTraces-ScriptDiagnostics-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Returns an enumerator that iterates through a collection.

##### Returns

An [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator') object that can be used to iterate through the collection.

##### Parameters

This method has no parameters.

<a name='T-Bb-Analysis-DiagTraces-SpanLocation`2'></a>
## SpanLocation\`2 `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-SpanLocation`2-#ctor-`0,`1-'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [](#!-SpanLocation 'SpanLocation') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Analysis-DiagTraces-SpanLocation`2-Stop'></a>
### Stop `property`

##### Summary

Gets the right location

<a name='M-Bb-Analysis-DiagTraces-SpanLocation`2-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns

A new object that is a copy of this instance.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-SpanLocation`2-op_Implicit-System-ValueTuple{`0,`1}-~Bb-Analysis-DiagTraces-SpanLocation{`0,`1}'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [](#!-ValueTuple<int, int> 'ValueTuple<int, int>') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.ValueTuple{\`0,\`1})~Bb.Analysis.DiagTraces.SpanLocation{\`0,\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{`0,`1})~Bb.Analysis.DiagTraces.SpanLocation{`0,`1}') | The position. |

<a name='T-Bb-Analysis-DiagTraces-TextLocation'></a>
## TextLocation `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-TextLocation-#ctor-Bb-Analysis-DiagTraces-ILocation,Bb-Analysis-DiagTraces-ILocation-'></a>
### #ctor(position) `constructor`

##### Summary

Initializes a new instance of the [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [Bb.Analysis.DiagTraces.ILocation](#T-Bb-Analysis-DiagTraces-ILocation 'Bb.Analysis.DiagTraces.ILocation') | The position. |

<a name='F-Bb-Analysis-DiagTraces-TextLocation-Empty'></a>
### Empty `constants`

##### Summary

The empty value

<a name='P-Bb-Analysis-DiagTraces-TextLocation-Datas'></a>
### Datas `property`

##### Summary

Datas dictionary

<a name='P-Bb-Analysis-DiagTraces-TextLocation-Filename'></a>
### Filename `property`

##### Summary

Filename document

<a name='P-Bb-Analysis-DiagTraces-TextLocation-Start'></a>
### Start `property`

##### Summary

get the left location

<a name='P-Bb-Analysis-DiagTraces-TextLocation-Stop'></a>
### Stop `property`

##### Summary

Gets the right location

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Add-System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### Add(datas) `method`

##### Summary

Add dictionary items

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| datas | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Add-System-Collections-Generic-KeyValuePair{System-String,System-Object}-'></a>
### Add(item) `method`

##### Summary

Add item

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [System.Collections.Generic.KeyValuePair{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyValuePair 'System.Collections.Generic.KeyValuePair{System.String,System.Object}') |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns

A new object that is a copy of this instance.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Action{Bb-Analysis-DiagTraces-TextLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex}}-'></a>
### Create(location,initializer) `method`

##### Summary

convert location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') |  |
| initializer | [System.Action{Bb.Analysis.DiagTraces.TextLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Analysis.DiagTraces.TextLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex}}') |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Int32,System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,Bb-Analysis-DiagTraces-LocationIndex}}-'></a>
### Create(location,right,initializer) `method`

##### Summary

convert location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') |  |
| right | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| initializer | [System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationIndex}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationIndex}}') |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Create-System-ValueTuple{System-Int32,System-Int32,System-Int32},System-ValueTuple{System-Int32,System-Int32,System-Int32},System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,Bb-Analysis-DiagTraces-LocationLineAndIndex}}-'></a>
### Create(location,right,initializer) `method`

##### Summary

convert location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') |  |
| right | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') |  |
| initializer | [System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationLineAndIndex}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,Bb.Analysis.DiagTraces.LocationLineAndIndex}}') |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Create``1-System-ValueTuple{System-Int32,System-Int32,System-Int32},``0,System-Action{Bb-Analysis-DiagTraces-SpanLocation{Bb-Analysis-DiagTraces-LocationLineAndIndex,``0}}-'></a>
### Create\`\`1(location,right,initializer) `method`

##### Summary

convert location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.ValueTuple{System.Int32,System.Int32,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple 'System.ValueTuple{System.Int32,System.Int32,System.Int32}') |  |
| right | [\`\`0](#T-``0 '``0') |  |
| initializer | [System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Analysis.DiagTraces.SpanLocation{Bb.Analysis.DiagTraces.LocationLineAndIndex,``0}}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| U |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocation-Get-System-String-'></a>
### Get(self,key) `method`

##### Summary

get a value from the dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Analysis-DiagTraces-TextLocationExtension'></a>
## TextLocationExtension `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-TextLocationExtension-Add``1-``0,System-String,System-Object-'></a>
### Add\`\`1(self,key,value) `method`

##### Summary

Add a value to the dictionary

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocationExtension-Copy``1-``0-'></a>
### Copy\`\`1(self) `method`

##### Summary

Copy the location. helper for the clone method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Analysis-DiagTraces-TextLocationExtension-InDocument``1-``0,System-String-'></a>
### InDocument\`\`1(self,documentName) `method`

##### Summary

Copy the location and set the document name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') |  |
| documentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Bb-Analysis-DiagTraces-TextLocation`1'></a>
## TextLocation\`1 `type`

##### Namespace

Bb.Analysis.DiagTraces

<a name='M-Bb-Analysis-DiagTraces-TextLocation`1-#ctor-`0,Bb-Analysis-DiagTraces-ILocation-'></a>
### #ctor(start) `constructor`

##### Summary

Initializes a new instance of the [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [\`0](#T-`0 '`0') | The position. |

<a name='M-Bb-Analysis-DiagTraces-TextLocation`1-#ctor-`0-'></a>
### #ctor(start) `constructor`

##### Summary

Initializes a new instance of the [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [\`0](#T-`0 '`0') | The position. |

<a name='P-Bb-Analysis-DiagTraces-TextLocation`1-Start'></a>
### Start `property`

##### Summary

Gets the left location.

<a name='M-Bb-Analysis-DiagTraces-TextLocation`1-Clone'></a>
### Clone() `method`

##### Summary

Creates a new object that is a copy of the current instance.

##### Returns

A new object that is a copy of this instance.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-TextLocation`1-ToString'></a>
### ToString() `method`

##### Summary

Converts to string.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents this instance.

##### Parameters

This method has no parameters.

<a name='M-Bb-Analysis-DiagTraces-TextLocation`1-op_Implicit-`0-~Bb-Analysis-DiagTraces-TextLocation{`0}'></a>
### op_Implicit(position) `method`

##### Summary

Performs an implicit conversion from [](#!-ValueTuple<int, int> 'ValueTuple<int, int>') to [TextLocation](#T-Bb-Analysis-DiagTraces-TextLocation 'Bb.Analysis.DiagTraces.TextLocation').

##### Returns

The result of the conversion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [\`0)~Bb.Analysis.DiagTraces.TextLocation{\`0}](#T-`0-~Bb-Analysis-DiagTraces-TextLocation{`0} '`0)~Bb.Analysis.DiagTraces.TextLocation{`0}') | The position. |
