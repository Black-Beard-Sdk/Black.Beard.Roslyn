<a name='assembly'></a>
# Black.Beard.Process

## Contents

- [ArgumentHelper](#T-Bb-Process-ArgumentHelper 'Bb.Process.ArgumentHelper')
  - [Quoted(value,quote)](#M-Bb-Process-ArgumentHelper-Quoted-System-String,System-String- 'Bb.Process.ArgumentHelper.Quoted(System.String,System.String)')
  - [Quoted(file,quote)](#M-Bb-Process-ArgumentHelper-Quoted-System-IO-FileInfo,System-String- 'Bb.Process.ArgumentHelper.Quoted(System.IO.FileInfo,System.String)')
- [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand')
  - [#ctor(id)](#M-Bb-Process-ProcessCommand-#ctor-System-Guid- 'Bb.Process.ProcessCommand.#ctor(System.Guid)')
  - [#ctor(id,tag)](#M-Bb-Process-ProcessCommand-#ctor-System-Guid,System-Object- 'Bb.Process.ProcessCommand.#ctor(System.Guid,System.Object)')
  - [#ctor()](#M-Bb-Process-ProcessCommand-#ctor 'Bb.Process.ProcessCommand.#ctor')
  - [ArgumentText](#P-Bb-Process-ProcessCommand-ArgumentText 'Bb.Process.ProcessCommand.ArgumentText')
  - [CreateNoWindow](#P-Bb-Process-ProcessCommand-CreateNoWindow 'Bb.Process.ProcessCommand.CreateNoWindow')
  - [FileNameText](#P-Bb-Process-ProcessCommand-FileNameText 'Bb.Process.ProcessCommand.FileNameText')
  - [LoadUserProfile](#P-Bb-Process-ProcessCommand-LoadUserProfile 'Bb.Process.ProcessCommand.LoadUserProfile')
  - [ShellExecute](#P-Bb-Process-ProcessCommand-ShellExecute 'Bb.Process.ProcessCommand.ShellExecute')
  - [WindowStyle](#P-Bb-Process-ProcessCommand-WindowStyle 'Bb.Process.ProcessCommand.WindowStyle')
  - [#cctor()](#M-Bb-Process-ProcessCommand-#cctor 'Bb.Process.ProcessCommand.#cctor')
  - [AddVariable(variableName,variableValue)](#M-Bb-Process-ProcessCommand-AddVariable-System-String,System-String- 'Bb.Process.ProcessCommand.AddVariable(System.String,System.String)')
  - [ArgumentList(args)](#M-Bb-Process-ProcessCommand-ArgumentList-System-String[]- 'Bb.Process.ProcessCommand.ArgumentList(System.String[])')
  - [Arguments(arguments)](#M-Bb-Process-ProcessCommand-Arguments-System-String- 'Bb.Process.ProcessCommand.Arguments(System.String)')
  - [Cancel(wait)](#M-Bb-Process-ProcessCommand-Cancel-System-Int32- 'Bb.Process.ProcessCommand.Cancel(System.Int32)')
  - [Command(command,arguments)](#M-Bb-Process-ProcessCommand-Command-System-String,System-String- 'Bb.Process.ProcessCommand.Command(System.String,System.String)')
  - [CommandWindowsBatch()](#M-Bb-Process-ProcessCommand-CommandWindowsBatch 'Bb.Process.ProcessCommand.CommandWindowsBatch')
  - [CommandWithArgumentList(command,arguments)](#M-Bb-Process-ProcessCommand-CommandWithArgumentList-System-String,System-String[]- 'Bb.Process.ProcessCommand.CommandWithArgumentList(System.String,System.String[])')
  - [CreateWindow(use)](#M-Bb-Process-ProcessCommand-CreateWindow-System-Boolean- 'Bb.Process.ProcessCommand.CreateWindow(System.Boolean)')
  - [Credentials(userName,password)](#M-Bb-Process-ProcessCommand-Credentials-System-String,System-Security-SecureString- 'Bb.Process.ProcessCommand.Credentials(System.String,System.Security.SecureString)')
  - [Credentials(userName,password)](#M-Bb-Process-ProcessCommand-Credentials-System-String,System-String- 'Bb.Process.ProcessCommand.Credentials(System.String,System.String)')
  - [Dispose()](#M-Bb-Process-ProcessCommand-Dispose 'Bb.Process.ProcessCommand.Dispose')
  - [Intercept(interceptor)](#M-Bb-Process-ProcessCommand-Intercept-Bb-Process-TaskEventHandler- 'Bb.Process.ProcessCommand.Intercept(Bb.Process.TaskEventHandler)')
  - [PushTaskEvent(task,status)](#M-Bb-Process-ProcessCommand-PushTaskEvent-System-Object,Bb-Process-TaskEventEnum- 'Bb.Process.ProcessCommand.PushTaskEvent(System.Object,Bb.Process.TaskEventEnum)')
  - [RemoveIntercept(interceptor)](#M-Bb-Process-ProcessCommand-RemoveIntercept-Bb-Process-TaskEventHandler- 'Bb.Process.ProcessCommand.RemoveIntercept(Bb.Process.TaskEventHandler)')
  - [Run(wait)](#M-Bb-Process-ProcessCommand-Run-System-Boolean- 'Bb.Process.ProcessCommand.Run(System.Boolean)')
  - [Run(millisecondsTimeout)](#M-Bb-Process-ProcessCommand-Run-System-Int32- 'Bb.Process.ProcessCommand.Run(System.Int32)')
  - [Run(timeout)](#M-Bb-Process-ProcessCommand-Run-System-TimeSpan- 'Bb.Process.ProcessCommand.Run(System.TimeSpan)')
  - [SetWindowStyle(use)](#M-Bb-Process-ProcessCommand-SetWindowStyle-System-Diagnostics-ProcessWindowStyle- 'Bb.Process.ProcessCommand.SetWindowStyle(System.Diagnostics.ProcessWindowStyle)')
  - [SetWorkingDirectory(WorkingDirectory)](#M-Bb-Process-ProcessCommand-SetWorkingDirectory-System-String- 'Bb.Process.ProcessCommand.SetWorkingDirectory(System.String)')
  - [SetWorkingDirectory(WorkingDirectory)](#M-Bb-Process-ProcessCommand-SetWorkingDirectory-System-IO-DirectoryInfo- 'Bb.Process.ProcessCommand.SetWorkingDirectory(System.IO.DirectoryInfo)')
  - [UseShellExecute(use)](#M-Bb-Process-ProcessCommand-UseShellExecute-System-Boolean- 'Bb.Process.ProcessCommand.UseShellExecute(System.Boolean)')
  - [Wait(millisecondsTimeout)](#M-Bb-Process-ProcessCommand-Wait-System-Int32- 'Bb.Process.ProcessCommand.Wait(System.Int32)')
  - [Wait()](#M-Bb-Process-ProcessCommand-Wait 'Bb.Process.ProcessCommand.Wait')
  - [Wait(timeout)](#M-Bb-Process-ProcessCommand-Wait-System-TimeSpan- 'Bb.Process.ProcessCommand.Wait(System.TimeSpan)')
  - [WriteInput(command)](#M-Bb-Process-ProcessCommand-WriteInput-System-String- 'Bb.Process.ProcessCommand.WriteInput(System.String)')
- [ProcessCommandExtension](#T-Bb-Process-ProcessCommandExtension 'Bb.Process.ProcessCommandExtension')
  - [Configure\`\`1(self,actionToConfigure)](#M-Bb-Process-ProcessCommandExtension-Configure``1-``0,System-Action{``0}- 'Bb.Process.ProcessCommandExtension.Configure``1(``0,System.Action{``0})')
- [ProcessCommandService](#T-Bb-Process-ProcessCommandService 'Bb.Process.ProcessCommandService')
  - [#ctor()](#M-Bb-Process-ProcessCommandService-#ctor 'Bb.Process.ProcessCommandService.#ctor')
  - [Count](#P-Bb-Process-ProcessCommandService-Count 'Bb.Process.ProcessCommandService.Count')
  - [Add\`\`1(cmd)](#M-Bb-Process-ProcessCommandService-Add``1-``0,System-Action{``0}- 'Bb.Process.ProcessCommandService.Add``1(``0,System.Action{``0})')
  - [Cancel(wait)](#M-Bb-Process-ProcessCommandService-Cancel-System-Int32- 'Bb.Process.ProcessCommandService.Cancel(System.Int32)')
  - [Cancel(id,wait)](#M-Bb-Process-ProcessCommandService-Cancel-System-Guid,System-Int32- 'Bb.Process.ProcessCommandService.Cancel(System.Guid,System.Int32)')
  - [CancelByTag(tag,wait)](#M-Bb-Process-ProcessCommandService-CancelByTag-System-Object,System-Int32- 'Bb.Process.ProcessCommandService.CancelByTag(System.Object,System.Int32)')
  - [Dispose()](#M-Bb-Process-ProcessCommandService-Dispose 'Bb.Process.ProcessCommandService.Dispose')
  - [GetTask(id)](#M-Bb-Process-ProcessCommandService-GetTask-System-Guid- 'Bb.Process.ProcessCommandService.GetTask(System.Guid)')
  - [GetTaskByTag(tag)](#M-Bb-Process-ProcessCommandService-GetTaskByTag-System-Object- 'Bb.Process.ProcessCommandService.GetTaskByTag(System.Object)')
  - [Intercept(id,action)](#M-Bb-Process-ProcessCommandService-Intercept-System-Guid,Bb-Process-TaskEventHandler- 'Bb.Process.ProcessCommandService.Intercept(System.Guid,Bb.Process.TaskEventHandler)')
  - [Intercept(action)](#M-Bb-Process-ProcessCommandService-Intercept-Bb-Process-TaskEventHandler- 'Bb.Process.ProcessCommandService.Intercept(Bb.Process.TaskEventHandler)')
  - [Run(actionToConfigure)](#M-Bb-Process-ProcessCommandService-Run-System-Action{Bb-Process-ProcessCommand}- 'Bb.Process.ProcessCommandService.Run(System.Action{Bb.Process.ProcessCommand})')
  - [Run(actionToConfigure,tag)](#M-Bb-Process-ProcessCommandService-Run-System-Guid,System-Action{Bb-Process-ProcessCommand},System-Object- 'Bb.Process.ProcessCommandService.Run(System.Guid,System.Action{Bb.Process.ProcessCommand},System.Object)')
  - [RunAndGet(actionToConfigure,wait)](#M-Bb-Process-ProcessCommandService-RunAndGet-System-Action{Bb-Process-ProcessCommand},System-Boolean- 'Bb.Process.ProcessCommandService.RunAndGet(System.Action{Bb.Process.ProcessCommand},System.Boolean)')
  - [RunAndGet(tag,actionToConfigure)](#M-Bb-Process-ProcessCommandService-RunAndGet-System-Guid,System-Action{Bb-Process-ProcessCommand},System-Object- 'Bb.Process.ProcessCommandService.RunAndGet(System.Guid,System.Action{Bb.Process.ProcessCommand},System.Object)')
  - [RunAndGet\`\`1(command,tag,actionToConfigure)](#M-Bb-Process-ProcessCommandService-RunAndGet``1-``0,System-Action{``0}- 'Bb.Process.ProcessCommandService.RunAndGet``1(``0,System.Action{``0})')
  - [Wait(test)](#M-Bb-Process-ProcessCommandService-Wait-System-Action{Bb-Process-ProcessCommandService}- 'Bb.Process.ProcessCommandService.Wait(System.Action{Bb.Process.ProcessCommandService})')
  - [Wait(test)](#M-Bb-Process-ProcessCommandService-Wait-System-Int32- 'Bb.Process.ProcessCommandService.Wait(System.Int32)')
  - [Wait(id,wait)](#M-Bb-Process-ProcessCommandService-Wait-System-Guid,System-Int32- 'Bb.Process.ProcessCommandService.Wait(System.Guid,System.Int32)')
- [TaskEventArgs](#T-Bb-Process-TaskEventArgs 'Bb.Process.TaskEventArgs')
  - [#ctor(process,status)](#M-Bb-Process-TaskEventArgs-#ctor-Bb-Process-ProcessCommand,Bb-Process-TaskEventEnum,System-Diagnostics-DataReceivedEventArgs- 'Bb.Process.TaskEventArgs.#ctor(Bb.Process.ProcessCommand,Bb.Process.TaskEventEnum,System.Diagnostics.DataReceivedEventArgs)')
  - [Closed](#P-Bb-Process-TaskEventArgs-Closed 'Bb.Process.TaskEventArgs.Closed')
  - [DateReceived](#P-Bb-Process-TaskEventArgs-DateReceived 'Bb.Process.TaskEventArgs.DateReceived')
  - [Process](#P-Bb-Process-TaskEventArgs-Process 'Bb.Process.TaskEventArgs.Process')
  - [ReceivedDtm](#P-Bb-Process-TaskEventArgs-ReceivedDtm 'Bb.Process.TaskEventArgs.ReceivedDtm')
  - [Status](#P-Bb-Process-TaskEventArgs-Status 'Bb.Process.TaskEventArgs.Status')
- [TaskEventEnum](#T-Bb-Process-TaskEventEnum 'Bb.Process.TaskEventEnum')
- [TaskEventHandler](#T-Bb-Process-TaskEventHandler 'Bb.Process.TaskEventHandler')

<a name='T-Bb-Process-ArgumentHelper'></a>
## ArgumentHelper `type`

##### Namespace

Bb.Process

<a name='M-Bb-Process-ArgumentHelper-Quoted-System-String,System-String-'></a>
### Quoted(value,quote) `method`

##### Summary

adds quotes on beginning and ending to the string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| quote | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Bb-Process-ArgumentHelper-Quoted-System-IO-FileInfo,System-String-'></a>
### Quoted(file,quote) `method`

##### Summary

adds quotes on beginning and ending to the file path

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| file | [System.IO.FileInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileInfo 'System.IO.FileInfo') |  |
| quote | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Bb-Process-ProcessCommand'></a>
## ProcessCommand `type`

##### Namespace

Bb.Process

##### Summary

class for manage lifecycle of the [Task](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task 'System.Threading.Tasks.Task') what wraps external process

##### See Also

- [System.IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable')

<a name='M-Bb-Process-ProcessCommand-#ctor-System-Guid-'></a>
### #ctor(id) `constructor`

##### Summary

Initializes a new instance of the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | Set the id process |

<a name='M-Bb-Process-ProcessCommand-#ctor-System-Guid,System-Object-'></a>
### #ctor(id,tag) `constructor`

##### Summary

Initializes a new instance of the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | Set the id process. |
| tag | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Set the tag. |

<a name='M-Bb-Process-ProcessCommand-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Process-ProcessCommand-ArgumentText'></a>
### ArgumentText `property`

##### Summary

Gets the argument text line.

<a name='P-Bb-Process-ProcessCommand-CreateNoWindow'></a>
### CreateNoWindow `property`

##### Summary

Gets or sets a value indicating whether to start the process in a new window..

##### Returns

true if the process should be started without creating a new window to contain it; otherwise, false. The default is false.

<a name='P-Bb-Process-ProcessCommand-FileNameText'></a>
### FileNameText `property`

##### Summary

Gets the filename to execute.

<a name='P-Bb-Process-ProcessCommand-LoadUserProfile'></a>
### LoadUserProfile `property`

##### Summary

Gets or sets a value that indicates whether the Windows user profile is to be loaded from the registry.

##### Returns

true if the Windows user profile should be loaded; otherwise, false. The default is false.

##### Remarks

This property is referenced if the process is being started by using the user name, password, and domain.
If the value is true, the user's profile in the HKEY_USERS registry key is loaded. Loading the profile can be time-consuming. Therefore, it is best to use this value only if you must access the information in the HKEY_CURRENT_USER registry key.
In Windows Server 2003 and Windows 2000, the profile is unloaded after the new process has been terminated, regardless of whether the process has created child processes.
In Windows XP, the profile is unloaded after the new process and all child processes it has created have been terminated.

<a name='P-Bb-Process-ProcessCommand-ShellExecute'></a>
### ShellExecute `property`

##### Summary

Gets or sets a value indicating whether to use the operating system shell to start the process.

##### Returns

true if the shell should be used when starting the process; false if the process should be created directly from the executable file. The default is true on .NET Framework apps and false on .NET Core apps.

<a name='P-Bb-Process-ProcessCommand-WindowStyle'></a>
### WindowStyle `property`

##### Summary

Gets or sets the window state to use when the process is started.

##### Returns

One of the enumeration values that indicates whether the process is started in a window that is maximized, minimized, normal (neither maximized nor minimized), or not visible. The default is Normal.

<a name='M-Bb-Process-ProcessCommand-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') class.

##### Parameters

This method has no parameters.

<a name='M-Bb-Process-ProcessCommand-AddVariable-System-String,System-String-'></a>
### AddVariable(variableName,variableValue) `method`

##### Summary

Adds the specified variable in the environment.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| variableName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the variable. |
| variableValue | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The variable value. |

<a name='M-Bb-Process-ProcessCommand-ArgumentList-System-String[]-'></a>
### ArgumentList(args) `method`

##### Summary

add the argument's list.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The arguments. |

<a name='M-Bb-Process-ProcessCommand-Arguments-System-String-'></a>
### Arguments(arguments) `method`

##### Summary

specify the argument's line.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| arguments | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The arguments. |

<a name='M-Bb-Process-ProcessCommand-Cancel-System-Int32-'></a>
### Cancel(wait) `method`

##### Summary

Cancels the current running task and wait specified time.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wait | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | if set to `true` [wait]. |

<a name='M-Bb-Process-ProcessCommand-Command-System-String,System-String-'></a>
### Command(command,arguments) `method`

##### Summary

set the Commands to run with the argument's line.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| command | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The command. |
| arguments | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The arguments. |

<a name='M-Bb-Process-ProcessCommand-CommandWindowsBatch'></a>
### CommandWindowsBatch() `method`

##### Summary

the batch on 'cmd.exe'.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Process-ProcessCommand-CommandWithArgumentList-System-String,System-String[]-'></a>
### CommandWithArgumentList(command,arguments) `method`

##### Summary

set the Commands to run with the list of argument

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| command | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The command. |
| arguments | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The arguments. |

<a name='M-Bb-Process-ProcessCommand-CreateWindow-System-Boolean-'></a>
### CreateWindow(use) `method`

##### Summary

sets a value indicating whether to use the operating system shell to start the process.

##### Returns

[ProcessCommand](#T-ProcessCommand 'ProcessCommand')fluent command method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| use | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | false if the process should be started without creating a new window to contain it; otherwise, true. The default is false.. |

<a name='M-Bb-Process-ProcessCommand-Credentials-System-String,System-Security-SecureString-'></a>
### Credentials(userName,password) `method`

##### Summary

Sets the credentials for specified user name.
note : Setting the Domain, UserName, and the Password properties in a ProcessStartInfo object is the recommended practice for starting a process with user credentials.

##### Returns

[ProcessCommand](#T-ProcessCommand 'ProcessCommand')fluent command method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Sets the user name to use when starting the process. If you use the UPN format, user@DNS_domain_name, the Domain property must be null.. |
| password | [System.Security.SecureString](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.SecureString 'System.Security.SecureString') | Sets a secure string that contains the user password to use when starting the process. |

##### Remarks

The WorkingDirectory property must be set if UserName and Password are provided. If the property is not set, the default working directory is %SYSTEMROOT%\system32.

<a name='M-Bb-Process-ProcessCommand-Credentials-System-String,System-String-'></a>
### Credentials(userName,password) `method`

##### Summary

Sets the credentials for specified user name.
note : Setting the Domain, UserName, and the Password properties in a ProcessStartInfo object is the recommended practice for starting a process with user credentials.

##### Returns

[ProcessCommand](#T-ProcessCommand 'ProcessCommand')fluent command method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Sets the user name to use when starting the process. If you use the UPN format, user@DNS_domain_name, the Domain property must be null.. |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Sets a string that contains the user password to use when starting the process. |

<a name='M-Bb-Process-ProcessCommand-Dispose'></a>
### Dispose() `method`

##### Summary

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

##### Parameters

This method has no parameters.

<a name='M-Bb-Process-ProcessCommand-Intercept-Bb-Process-TaskEventHandler-'></a>
### Intercept(interceptor) `method`

##### Summary

add a new subscription

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interceptor | [Bb.Process.TaskEventHandler](#T-Bb-Process-TaskEventHandler 'Bb.Process.TaskEventHandler') | The interceptor. |

<a name='M-Bb-Process-ProcessCommand-PushTaskEvent-System-Object,Bb-Process-TaskEventEnum-'></a>
### PushTaskEvent(task,status) `method`

##### Summary

Raise the task event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| task | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The task. |
| status | [Bb.Process.TaskEventEnum](#T-Bb-Process-TaskEventEnum 'Bb.Process.TaskEventEnum') | The status. |

<a name='M-Bb-Process-ProcessCommand-RemoveIntercept-Bb-Process-TaskEventHandler-'></a>
### RemoveIntercept(interceptor) `method`

##### Summary

Removes the subscription

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interceptor | [Bb.Process.TaskEventHandler](#T-Bb-Process-TaskEventHandler 'Bb.Process.TaskEventHandler') | The interceptor. |

<a name='M-Bb-Process-ProcessCommand-Run-System-Boolean-'></a>
### Run(wait) `method`

##### Summary

Runs the task and wait the process is done.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wait | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if set to `true` [wait]. |

<a name='M-Bb-Process-ProcessCommand-Run-System-Int32-'></a>
### Run(millisecondsTimeout) `method`

##### Summary

Runs the task and wait the specified milliseconds timeout.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| millisecondsTimeout | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The milliseconds timeout. |

<a name='M-Bb-Process-ProcessCommand-Run-System-TimeSpan-'></a>
### Run(timeout) `method`

##### Summary

Runs the task and wait the specified timeout.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| timeout | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | The timeout. |

<a name='M-Bb-Process-ProcessCommand-SetWindowStyle-System-Diagnostics-ProcessWindowStyle-'></a>
### SetWindowStyle(use) `method`

##### Summary

Sets the window state to use when the process is started.

##### Returns

[ProcessCommand](#T-ProcessCommand 'ProcessCommand')fluent command method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| use | [System.Diagnostics.ProcessWindowStyle](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.ProcessWindowStyle 'System.Diagnostics.ProcessWindowStyle') | One of the enumeration values that indicates whether the process is started in a window that is maximized, minimized, normal (neither maximized nor minimized), or not visible. The default is Normal. |

<a name='M-Bb-Process-ProcessCommand-SetWorkingDirectory-System-String-'></a>
### SetWorkingDirectory(WorkingDirectory) `method`

##### Summary

Sets the working directory.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| WorkingDirectory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The working directory. |

<a name='M-Bb-Process-ProcessCommand-SetWorkingDirectory-System-IO-DirectoryInfo-'></a>
### SetWorkingDirectory(WorkingDirectory) `method`

##### Summary

Sets the working directory.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| WorkingDirectory | [System.IO.DirectoryInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryInfo 'System.IO.DirectoryInfo') | The working directory. |

<a name='M-Bb-Process-ProcessCommand-UseShellExecute-System-Boolean-'></a>
### UseShellExecute(use) `method`

##### Summary

Sets a value that indicates whether the Windows user profile is to be loaded from the registry.

##### Returns

[ProcessCommand](#T-ProcessCommand 'ProcessCommand')fluent command method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| use | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if the Windows user profile should be loaded; otherwise, false. The default is false. |

##### Remarks

This property is referenced if the process is being started by using the user name, password, and domain.
If the value is true, the user's profile in the HKEY_USERS registry key is loaded. Loading the profile can be time-consuming. Therefore, it is best to use this value only if you must access the information in the HKEY_CURRENT_USER registry key.
In Windows Server 2003 and Windows 2000, the profile is unloaded after the new process has been terminated, regardless of whether the process has created child processes.
In Windows XP, the profile is unloaded after the new process and all child processes it has created have been terminated.

<a name='M-Bb-Process-ProcessCommand-Wait-System-Int32-'></a>
### Wait(millisecondsTimeout) `method`

##### Summary

Waits the specified milliseconds timeout.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| millisecondsTimeout | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The milliseconds timeout. |

<a name='M-Bb-Process-ProcessCommand-Wait'></a>
### Wait() `method`

##### Summary

Waits the task finish

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-Process-ProcessCommand-Wait-System-TimeSpan-'></a>
### Wait(timeout) `method`

##### Summary

Waits the specified timeout.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| timeout | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | The timeout. |

<a name='M-Bb-Process-ProcessCommand-WriteInput-System-String-'></a>
### WriteInput(command) `method`

##### Summary

Writes the command in the input stream.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| command | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The command. |

<a name='T-Bb-Process-ProcessCommandExtension'></a>
## ProcessCommandExtension `type`

##### Namespace

Bb.Process

##### Summary

ProcessCommand extension

<a name='M-Bb-Process-ProcessCommandExtension-Configure``1-``0,System-Action{``0}-'></a>
### Configure\`\`1(self,actionToConfigure) `method`

##### Summary

Configures self with specified action.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [\`\`0](#T-``0 '``0') | The self. |
| actionToConfigure | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to configure. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Bb-Process-ProcessCommandService'></a>
## ProcessCommandService `type`

##### Namespace

Bb.Process

##### Summary

class for manage life cycle of the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand')

##### See Also

- [System.IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable')

<a name='M-Bb-Process-ProcessCommandService-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ProcessCommandService](#T-Bb-Process-ProcessCommandService 'Bb.Process.ProcessCommandService') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Process-ProcessCommandService-Count'></a>
### Count `property`

##### Summary

Gets the count of command process.

<a name='M-Bb-Process-ProcessCommandService-Add``1-``0,System-Action{``0}-'></a>
### Add\`\`1(cmd) `method`

##### Summary

Adds the specified command.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cmd | [\`\`0](#T-``0 '``0') | The command. |

<a name='M-Bb-Process-ProcessCommandService-Cancel-System-Int32-'></a>
### Cancel(wait) `method`

##### Summary

Cancel all commands process.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wait | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | if set to `true` [wait]. |

<a name='M-Bb-Process-ProcessCommandService-Cancel-System-Guid,System-Int32-'></a>
### Cancel(id,wait) `method`

##### Summary

Cancels the command process specified by id.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The identifier. |
| wait | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | if set to `true` [wait]. |

<a name='M-Bb-Process-ProcessCommandService-CancelByTag-System-Object,System-Int32-'></a>
### CancelByTag(tag,wait) `method`

##### Summary

Cancels the commands process specified by tag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tag | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The tag. |
| wait | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | if set to `true` [wait]. |

<a name='M-Bb-Process-ProcessCommandService-Dispose'></a>
### Dispose() `method`

##### Summary

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

##### Parameters

This method has no parameters.

<a name='M-Bb-Process-ProcessCommandService-GetTask-System-Guid-'></a>
### GetTask(id) `method`

##### Summary

Gets the task identified by id.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The identifier. |

<a name='M-Bb-Process-ProcessCommandService-GetTaskByTag-System-Object-'></a>
### GetTaskByTag(tag) `method`

##### Summary

Gets the task identified by tag.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tag | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The tag. |

<a name='M-Bb-Process-ProcessCommandService-Intercept-System-Guid,Bb-Process-TaskEventHandler-'></a>
### Intercept(id,action) `method`

##### Summary

append a new subscription on the output.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The identifier. |
| action | [Bb.Process.TaskEventHandler](#T-Bb-Process-TaskEventHandler 'Bb.Process.TaskEventHandler') | The action. |

<a name='M-Bb-Process-ProcessCommandService-Intercept-Bb-Process-TaskEventHandler-'></a>
### Intercept(action) `method`

##### Summary

append a new subscription on the output

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Bb.Process.TaskEventHandler](#T-Bb-Process-TaskEventHandler 'Bb.Process.TaskEventHandler') | The action. |

<a name='M-Bb-Process-ProcessCommandService-Run-System-Action{Bb-Process-ProcessCommand}-'></a>
### Run(actionToConfigure) `method`

##### Summary

Create and Runs a command. Method fluent

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| actionToConfigure | [System.Action{Bb.Process.ProcessCommand}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Process.ProcessCommand}') | The action to configure. |

<a name='M-Bb-Process-ProcessCommandService-Run-System-Guid,System-Action{Bb-Process-ProcessCommand},System-Object-'></a>
### Run(actionToConfigure,tag) `method`

##### Summary

Create and Runs a command. Method fluent

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| actionToConfigure | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The action to configure. |
| tag | [System.Action{Bb.Process.ProcessCommand}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Process.ProcessCommand}') | The tag. |

<a name='M-Bb-Process-ProcessCommandService-RunAndGet-System-Action{Bb-Process-ProcessCommand},System-Boolean-'></a>
### RunAndGet(actionToConfigure,wait) `method`

##### Summary

Create and Runs a command

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| actionToConfigure | [System.Action{Bb.Process.ProcessCommand}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Process.ProcessCommand}') | The action to configure. |
| wait | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | specify if the return wait the process is closing. |

<a name='M-Bb-Process-ProcessCommandService-RunAndGet-System-Guid,System-Action{Bb-Process-ProcessCommand},System-Object-'></a>
### RunAndGet(tag,actionToConfigure) `method`

##### Summary

Create and Runs a command.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tag | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The tag. for identified the process. |
| actionToConfigure | [System.Action{Bb.Process.ProcessCommand}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Process.ProcessCommand}') | The action to configure the command process. |

<a name='M-Bb-Process-ProcessCommandService-RunAndGet``1-``0,System-Action{``0}-'></a>
### RunAndGet\`\`1(command,tag,actionToConfigure) `method`

##### Summary

Create and Runs a command.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| command | [\`\`0](#T-``0 '``0') |  |
| tag | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The tag. for identified the process. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Bb-Process-ProcessCommandService-Wait-System-Action{Bb-Process-ProcessCommandService}-'></a>
### Wait(test) `method`

##### Summary

Waits the specified test return [ProcessCommandService](#T-Bb-Process-ProcessCommandService 'Bb.Process.ProcessCommandService')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| test | [System.Action{Bb.Process.ProcessCommandService}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{Bb.Process.ProcessCommandService}') | The test. |

<a name='M-Bb-Process-ProcessCommandService-Wait-System-Int32-'></a>
### Wait(test) `method`

##### Summary

Waits the specified time return [ProcessCommandService](#T-Bb-Process-ProcessCommandService 'Bb.Process.ProcessCommandService').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| test | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The test. |

<a name='M-Bb-Process-ProcessCommandService-Wait-System-Guid,System-Int32-'></a>
### Wait(id,wait) `method`

##### Summary

Waits the specified identifier.

##### Returns

return the [ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') specified by id

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The identifier of the process command. |
| wait | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The time to wait. |

<a name='T-Bb-Process-TaskEventArgs'></a>
## TaskEventArgs `type`

##### Namespace

Bb.Process

##### Summary



##### See Also

- [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs')

<a name='M-Bb-Process-TaskEventArgs-#ctor-Bb-Process-ProcessCommand,Bb-Process-TaskEventEnum,System-Diagnostics-DataReceivedEventArgs-'></a>
### #ctor(process,status) `constructor`

##### Summary

Initializes a new instance of the [TaskEventArgs](#T-Bb-Process-TaskEventArgs 'Bb.Process.TaskEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| process | [Bb.Process.ProcessCommand](#T-Bb-Process-ProcessCommand 'Bb.Process.ProcessCommand') | The process. |
| status | [Bb.Process.TaskEventEnum](#T-Bb-Process-TaskEventEnum 'Bb.Process.TaskEventEnum') | The status. |

<a name='P-Bb-Process-TaskEventArgs-Closed'></a>
### Closed `property`

##### Summary

Gets a value indicating whether this [TaskEventArgs](#T-Bb-Process-TaskEventArgs 'Bb.Process.TaskEventArgs') is closing.

<a name='P-Bb-Process-TaskEventArgs-DateReceived'></a>
### DateReceived `property`

##### Summary

Gets the date received.

<a name='P-Bb-Process-TaskEventArgs-Process'></a>
### Process `property`

##### Summary

Gets the process.

<a name='P-Bb-Process-TaskEventArgs-ReceivedDtm'></a>
### ReceivedDtm `property`

##### Summary

Gets the received DTM.

<a name='P-Bb-Process-TaskEventArgs-Status'></a>
### Status `property`

##### Summary

Gets the status.

<a name='T-Bb-Process-TaskEventEnum'></a>
## TaskEventEnum `type`

##### Namespace

Bb.Process

##### Summary

Task event status

<a name='T-Bb-Process-TaskEventHandler'></a>
## TaskEventHandler `type`

##### Namespace

Bb.Process

##### Summary

Task event handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:Bb.Process.TaskEventHandler](#T-T-Bb-Process-TaskEventHandler 'T:Bb.Process.TaskEventHandler') | The sender. |
