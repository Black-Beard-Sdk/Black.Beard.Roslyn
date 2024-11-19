<a name='assembly'></a>
# Black.Beard.Projects.Models

## Contents

- [Group](#T-Bb-Projects-Group 'Bb.Projects.Group')
  - [#ctor(key,duplicateMode)](#M-Bb-Projects-Group-#ctor-System-String,System-Boolean- 'Bb.Projects.Group.#ctor(System.String,System.Boolean)')
  - [Add(key,value)](#M-Bb-Projects-Group-Add-System-String,System-Uri- 'Bb.Projects.Group.Add(System.String,System.Uri)')
  - [Add(key,value)](#M-Bb-Projects-Group-Add-System-String,System-Guid- 'Bb.Projects.Group.Add(System.String,System.Guid)')
  - [Add(key,value)](#M-Bb-Projects-Group-Add-System-String,System-String- 'Bb.Projects.Group.Add(System.String,System.String)')
  - [Add(key,value)](#M-Bb-Projects-Group-Add-System-String,System-Boolean- 'Bb.Projects.Group.Add(System.String,System.Boolean)')
  - [Add(key,value)](#M-Bb-Projects-Group-Add-System-String,System-Version- 'Bb.Projects.Group.Add(System.String,System.Version)')
  - [Add(value)](#M-Bb-Projects-Group-Add-Bb-Projects-Group- 'Bb.Projects.Group.Add(Bb.Projects.Group)')
  - [Add(value)](#M-Bb-Projects-Group-Add-Bb-Projects-PropertyKey- 'Bb.Projects.Group.Add(Bb.Projects.PropertyKey)')
  - [Add(value)](#M-Bb-Projects-Group-Add-System-Xml-Linq-XAttribute- 'Bb.Projects.Group.Add(System.Xml.Linq.XAttribute)')
  - [AddAttribute(key,value)](#M-Bb-Projects-Group-AddAttribute-System-String,System-String- 'Bb.Projects.Group.AddAttribute(System.String,System.String)')
- [MsProject](#T-Bb-Projects-MsProject 'Bb.Projects.MsProject')
  - [AppendDocument(path,filename,content)](#M-Bb-Projects-MsProject-AppendDocument-System-String,System-String,System-Text-StringBuilder- 'Bb.Projects.MsProject.AppendDocument(System.String,System.String,System.Text.StringBuilder)')
  - [AppendDocument(filename,content)](#M-Bb-Projects-MsProject-AppendDocument-System-String,System-Text-StringBuilder- 'Bb.Projects.MsProject.AppendDocument(System.String,System.Text.StringBuilder)')
  - [AppendDocument(filename,content)](#M-Bb-Projects-MsProject-AppendDocument-System-String,System-String- 'Bb.Projects.MsProject.AppendDocument(System.String,System.String)')
  - [AppendDocument(path,filename,content)](#M-Bb-Projects-MsProject-AppendDocument-System-String,System-String,System-String- 'Bb.Projects.MsProject.AppendDocument(System.String,System.String,System.String)')
  - [ComputeFullPath(path,filename)](#M-Bb-Projects-MsProject-ComputeFullPath-System-String,System-String- 'Bb.Projects.MsProject.ComputeFullPath(System.String,System.String)')
  - [ComputeFullPath(path)](#M-Bb-Projects-MsProject-ComputeFullPath-System-String- 'Bb.Projects.MsProject.ComputeFullPath(System.String)')
- [SqlServerVersion](#T-Bb-Projects-SqlServerVersion 'Bb.Projects.SqlServerVersion')
  - [Sql150](#P-Bb-Projects-SqlServerVersion-Sql150 'Bb.Projects.SqlServerVersion.Sql150')

<a name='T-Bb-Projects-Group'></a>
## Group `type`

##### Namespace

Bb.Projects

<a name='M-Bb-Projects-Group-#ctor-System-String,System-Boolean-'></a>
### #ctor(key,duplicateMode) `constructor`

##### Summary

Initializes a new instance of the [Group](#T-Bb-Projects-Group 'Bb.Projects.Group') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |
| duplicateMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if set to `true` [duplicate mode]. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | name |

<a name='M-Bb-Projects-Group-Add-System-String,System-Uri-'></a>
### Add(key,value) `method`

##### Summary

Adds a new property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.Uri](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Uri 'System.Uri') | The uri value. |

<a name='M-Bb-Projects-Group-Add-System-String,System-Guid-'></a>
### Add(key,value) `method`

##### Summary

Adds a new property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The value. |

<a name='M-Bb-Projects-Group-Add-System-String,System-String-'></a>
### Add(key,value) `method`

##### Summary

Adds a new property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value. |

<a name='M-Bb-Projects-Group-Add-System-String,System-Boolean-'></a>
### Add(key,value) `method`

##### Summary

Adds a new property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if set to `true` [value]. |

<a name='M-Bb-Projects-Group-Add-System-String,System-Version-'></a>
### Add(key,value) `method`

##### Summary

Adds a new property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.Version](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Version 'System.Version') | The value version. |

<a name='M-Bb-Projects-Group-Add-Bb-Projects-Group-'></a>
### Add(value) `method`

##### Summary

Adds the specified group.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Bb.Projects.Group](#T-Bb-Projects-Group 'Bb.Projects.Group') | The value. |

<a name='M-Bb-Projects-Group-Add-Bb-Projects-PropertyKey-'></a>
### Add(value) `method`

##### Summary

Adds the specified property key.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [Bb.Projects.PropertyKey](#T-Bb-Projects-PropertyKey 'Bb.Projects.PropertyKey') | The value. |

<a name='M-Bb-Projects-Group-Add-System-Xml-Linq-XAttribute-'></a>
### Add(value) `method`

##### Summary

Adds the specified attribute.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Xml.Linq.XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute') | The value is [XAttribute](#T-XAttribute 'XAttribute'). |

<a name='M-Bb-Projects-Group-AddAttribute-System-String,System-String-'></a>
### AddAttribute(key,value) `method`

##### Summary

Adds a new attribute.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The key. |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value. |

<a name='T-Bb-Projects-MsProject'></a>
## MsProject `type`

##### Namespace

Bb.Projects

<a name='M-Bb-Projects-MsProject-AppendDocument-System-String,System-String,System-Text-StringBuilder-'></a>
### AppendDocument(path,filename,content) `method`

##### Summary

Appends a new document in the project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path. |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |
| content | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The content. |

<a name='M-Bb-Projects-MsProject-AppendDocument-System-String,System-Text-StringBuilder-'></a>
### AppendDocument(filename,content) `method`

##### Summary

Appends a new document in the project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |
| content | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The content. |

<a name='M-Bb-Projects-MsProject-AppendDocument-System-String,System-String-'></a>
### AppendDocument(filename,content) `method`

##### Summary

Appends a new document in the project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content. |

<a name='M-Bb-Projects-MsProject-AppendDocument-System-String,System-String,System-String-'></a>
### AppendDocument(path,filename,content) `method`

##### Summary

Appends a new document in the project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path. |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content. |

<a name='M-Bb-Projects-MsProject-ComputeFullPath-System-String,System-String-'></a>
### ComputeFullPath(path,filename) `method`

##### Summary

Computes the full path for the file you want to append to project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path. |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |

<a name='M-Bb-Projects-MsProject-ComputeFullPath-System-String-'></a>
### ComputeFullPath(path) `method`

##### Summary

Computes the full path for the file you want to append to project.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path. |

<a name='T-Bb-Projects-SqlServerVersion'></a>
## SqlServerVersion `type`

##### Namespace

Bb.Projects

<a name='P-Bb-Projects-SqlServerVersion-Sql150'></a>
### Sql150 `property`

##### Summary

By default
