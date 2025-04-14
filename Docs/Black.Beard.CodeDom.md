<a name='assembly'></a>
# Black.Beard.CodeDom

## Contents

- [CSharpHelpers](#T-Bb-Generators-Csharp-CSharpHelpers 'Bb.Generators.Csharp.CSharpHelpers')
  - [IsValidLanguageIndependentIdentifier()](#M-Bb-Generators-Csharp-CSharpHelpers-IsValidLanguageIndependentIdentifier-System-String- 'Bb.Generators.Csharp.CSharpHelpers.IsValidLanguageIndependentIdentifier(System.String)')
- [MethodCompiler](#T-Bb-Expressions-MethodCompiler 'Bb.Expressions.MethodCompiler')
  - [#ctor()](#M-Bb-Expressions-MethodCompiler-#ctor 'Bb.Expressions.MethodCompiler.#ctor')
  - [LastParameter](#P-Bb-Expressions-MethodCompiler-LastParameter 'Bb.Expressions.MethodCompiler.LastParameter')
  - [OutputPath](#P-Bb-Expressions-MethodCompiler-OutputPath 'Bb.Expressions.MethodCompiler.OutputPath')
  - [Parameters](#P-Bb-Expressions-MethodCompiler-Parameters 'Bb.Expressions.MethodCompiler.Parameters')
  - [AddParameter(type,name)](#M-Bb-Expressions-MethodCompiler-AddParameter-System-Type,System-String- 'Bb.Expressions.MethodCompiler.AddParameter(System.Type,System.String)')
  - [Compile\`\`1(filepathCode)](#M-Bb-Expressions-MethodCompiler-Compile``1-System-String- 'Bb.Expressions.MethodCompiler.Compile``1(System.String)')
  - [GenerateLambda(delegateType)](#M-Bb-Expressions-MethodCompiler-GenerateLambda-System-Type- 'Bb.Expressions.MethodCompiler.GenerateLambda(System.Type)')
  - [GenerateLambda\`\`1(filepathCode)](#M-Bb-Expressions-MethodCompiler-GenerateLambda``1-System-String- 'Bb.Expressions.MethodCompiler.GenerateLambda``1(System.String)')
  - [GetParameter(name)](#M-Bb-Expressions-MethodCompiler-GetParameter-System-String- 'Bb.Expressions.MethodCompiler.GetParameter(System.String)')
  - [GetVar(name)](#M-Bb-Expressions-MethodCompiler-GetVar-System-String- 'Bb.Expressions.MethodCompiler.GetVar(System.String)')
- [ResourceString](#T-Bb-Generators-Csharp-ResourceString 'Bb.Generators.Csharp.ResourceString')
  - [Argument_NullComment](#P-Bb-Generators-Csharp-ResourceString-Argument_NullComment 'Bb.Generators.Csharp.ResourceString.Argument_NullComment')
  - [ArityDoesntMatch](#P-Bb-Generators-Csharp-ResourceString-ArityDoesntMatch 'Bb.Generators.Csharp.ResourceString.ArityDoesntMatch')
  - [AutoGen_Comment_Line1](#P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line1 'Bb.Generators.Csharp.ResourceString.AutoGen_Comment_Line1')
  - [AutoGen_Comment_Line2](#P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line2 'Bb.Generators.Csharp.ResourceString.AutoGen_Comment_Line2')
  - [AutoGen_Comment_Line4](#P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line4 'Bb.Generators.Csharp.ResourceString.AutoGen_Comment_Line4')
  - [AutoGen_Comment_Line5](#P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line5 'Bb.Generators.Csharp.ResourceString.AutoGen_Comment_Line5')
  - [CodeDomProvider_NotDefined](#P-Bb-Generators-Csharp-ResourceString-CodeDomProvider_NotDefined 'Bb.Generators.Csharp.ResourceString.CodeDomProvider_NotDefined')
  - [CodeGenOutputWriter](#P-Bb-Generators-Csharp-ResourceString-CodeGenOutputWriter 'Bb.Generators.Csharp.ResourceString.CodeGenOutputWriter')
  - [CodeGenReentrance](#P-Bb-Generators-Csharp-ResourceString-CodeGenReentrance 'Bb.Generators.Csharp.ResourceString.CodeGenReentrance')
  - [Culture](#P-Bb-Generators-Csharp-ResourceString-Culture 'Bb.Generators.Csharp.ResourceString.Culture')
  - [DuplicateFileName](#P-Bb-Generators-Csharp-ResourceString-DuplicateFileName 'Bb.Generators.Csharp.ResourceString.DuplicateFileName')
  - [ExecTimeout](#P-Bb-Generators-Csharp-ResourceString-ExecTimeout 'Bb.Generators.Csharp.ResourceString.ExecTimeout')
  - [InvalidElementType](#P-Bb-Generators-Csharp-ResourceString-InvalidElementType 'Bb.Generators.Csharp.ResourceString.InvalidElementType')
  - [InvalidIdentifier](#P-Bb-Generators-Csharp-ResourceString-InvalidIdentifier 'Bb.Generators.Csharp.ResourceString.InvalidIdentifier')
  - [InvalidLanguageIdentifier](#P-Bb-Generators-Csharp-ResourceString-InvalidLanguageIdentifier 'Bb.Generators.Csharp.ResourceString.InvalidLanguageIdentifier')
  - [InvalidNullEmptyArgument](#P-Bb-Generators-Csharp-ResourceString-InvalidNullEmptyArgument 'Bb.Generators.Csharp.ResourceString.InvalidNullEmptyArgument')
  - [InvalidPathCharsInChecksum](#P-Bb-Generators-Csharp-ResourceString-InvalidPathCharsInChecksum 'Bb.Generators.Csharp.ResourceString.InvalidPathCharsInChecksum')
  - [InvalidPrimitiveType](#P-Bb-Generators-Csharp-ResourceString-InvalidPrimitiveType 'Bb.Generators.Csharp.ResourceString.InvalidPrimitiveType')
  - [InvalidRegion](#P-Bb-Generators-Csharp-ResourceString-InvalidRegion 'Bb.Generators.Csharp.ResourceString.InvalidRegion')
  - [InvalidTypeName](#P-Bb-Generators-Csharp-ResourceString-InvalidTypeName 'Bb.Generators.Csharp.ResourceString.InvalidTypeName')
  - [NotSupported_CodeDomAPI](#P-Bb-Generators-Csharp-ResourceString-NotSupported_CodeDomAPI 'Bb.Generators.Csharp.ResourceString.NotSupported_CodeDomAPI')
  - [Provider_does_not_support_options](#P-Bb-Generators-Csharp-ResourceString-Provider_does_not_support_options 'Bb.Generators.Csharp.ResourceString.Provider_does_not_support_options')
  - [ResourceManager](#P-Bb-Generators-Csharp-ResourceString-ResourceManager 'Bb.Generators.Csharp.ResourceString.ResourceManager')
  - [toStringUnknown](#P-Bb-Generators-Csharp-ResourceString-toStringUnknown 'Bb.Generators.Csharp.ResourceString.toStringUnknown')
- [SourceCodeDomGenerator](#T-Bb-Generators-Csharp-SourceCodeDomGenerator 'Bb.Generators.Csharp.SourceCodeDomGenerator')
  - [#ctor(namespace,classname,methodname,usings,withDebug)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-#ctor-System-String,System-String,System-String,System-String[],System-Boolean- 'Bb.Generators.Csharp.SourceCodeDomGenerator.#ctor(System.String,System.String,System.String,System.String[],System.Boolean)')
  - [CreatePrivateMethod()](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-CreatePrivateMethod 'Bb.Generators.Csharp.SourceCodeDomGenerator.CreatePrivateMethod')
  - [GetCode(e,namespace,classname,methodname,withDebug,usings)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-GetCode-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Boolean,System-String[]- 'Bb.Generators.Csharp.SourceCodeDomGenerator.GetCode(System.Linq.Expressions.Expression,System.String,System.String,System.String,System.Boolean,System.String[])')
  - [Parse(e)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-Parse-System-Linq-Expressions-Expression- 'Bb.Generators.Csharp.SourceCodeDomGenerator.Parse(System.Linq.Expressions.Expression)')
  - [Visit(e)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-Visit-System-Linq-Expressions-Expression- 'Bb.Generators.Csharp.SourceCodeDomGenerator.Visit(System.Linq.Expressions.Expression)')
  - [VisitBinaryOperation(e,ope)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitBinaryOperation-System-Linq-Expressions-BinaryExpression,System-CodeDom-CodeBinaryOperatorType- 'Bb.Generators.Csharp.SourceCodeDomGenerator.VisitBinaryOperation(System.Linq.Expressions.BinaryExpression,System.CodeDom.CodeBinaryOperatorType)')
  - [VisitConstant(node)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitConstant-System-Linq-Expressions-ConstantExpression- 'Bb.Generators.Csharp.SourceCodeDomGenerator.VisitConstant(System.Linq.Expressions.ConstantExpression)')
  - [VisitLambda(node)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitLambda-System-Linq-Expressions-LambdaExpression- 'Bb.Generators.Csharp.SourceCodeDomGenerator.VisitLambda(System.Linq.Expressions.LambdaExpression)')
  - [VisitMethodCall(node)](#M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitMethodCall-System-Linq-Expressions-MethodCallExpression- 'Bb.Generators.Csharp.SourceCodeDomGenerator.VisitMethodCall(System.Linq.Expressions.MethodCallExpression)')

<a name='T-Bb-Generators-Csharp-CSharpHelpers'></a>
## CSharpHelpers `type`

##### Namespace

Bb.Generators.Csharp

<a name='M-Bb-Generators-Csharp-CSharpHelpers-IsValidLanguageIndependentIdentifier-System-String-'></a>
### IsValidLanguageIndependentIdentifier() `method`

##### Parameters

This method has no parameters.

<a name='T-Bb-Expressions-MethodCompiler'></a>
## MethodCompiler `type`

##### Namespace

Bb.Expressions

##### Summary

Provides functionality to compile methods from expression trees and generate source code.

##### Remarks

This class allows adding parameters, generating lambda expressions, and compiling them into delegates.
It also supports generating C# source code for debugging purposes.

<a name='M-Bb-Expressions-MethodCompiler-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [MethodCompiler](#T-Bb-Expressions-MethodCompiler 'Bb.Expressions.MethodCompiler') class.

##### Parameters

This constructor has no parameters.

<a name='P-Bb-Expressions-MethodCompiler-LastParameter'></a>
### LastParameter `property`

##### Summary

Gets the last parameter added to the method.

##### Remarks

This property is useful for accessing the most recently added parameter.

<a name='P-Bb-Expressions-MethodCompiler-OutputPath'></a>
### OutputPath `property`

##### Summary

Gets or sets the output path for generated files.

##### Remarks

This property is used to specify the directory where generated files will be saved.

<a name='P-Bb-Expressions-MethodCompiler-Parameters'></a>
### Parameters `property`

##### Summary

Gets the list of all parameters added to the method.

##### Remarks

This property provides access to all parameters currently defined in the method.

<a name='M-Bb-Expressions-MethodCompiler-AddParameter-System-Type,System-String-'></a>
### AddParameter(type,name) `method`

##### Summary

Adds a new parameter to the method being compiled.

##### Returns

A [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') representing the added parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type of the parameter. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the parameter. If null, a unique name will be generated. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Bb.Exceptions.DuplicatedArgumentNameException](#T-Bb-Exceptions-DuplicatedArgumentNameException 'Bb.Exceptions.DuplicatedArgumentNameException') | Thrown if a parameter with the same name already exists. |

##### Example

```C#
var compiler = new MethodCompiler();
var parameter = compiler.AddParameter(typeof(int), "myParam");
```

##### Remarks

This method creates a new parameter and adds it to the internal parameter list.

<a name='M-Bb-Expressions-MethodCompiler-Compile``1-System-String-'></a>
### Compile\`\`1(filepathCode) `method`

##### Summary

Compiles the method into a delegate of the specified type and generates source code for debugging.

##### Returns

A delegate of type `TDelegate` representing the compiled method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filepathCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file path for the generated source code. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TDelegate | The type of the delegate to compile. |

##### Example

```C#
var compiler = new MethodCompiler();
var result = compiler.Compile&lt;Func&lt;int, int&gt;&gt;("MyCode.cs");
```

##### Remarks

This method generates a lambda expression, compiles it into a delegate, and optionally generates C# source code for debugging.

<a name='M-Bb-Expressions-MethodCompiler-GenerateLambda-System-Type-'></a>
### GenerateLambda(delegateType) `method`

##### Summary

Generates a lambda expression of the specified delegate type.

##### Returns

A [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') representing the generated lambda.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| delegateType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type of the delegate to generate. |

##### Remarks

This method creates a lambda expression using the defined parameters and the main expression body.

<a name='M-Bb-Expressions-MethodCompiler-GenerateLambda``1-System-String-'></a>
### GenerateLambda\`\`1(filepathCode) `method`

##### Summary

Generates a lambda expression of the specified delegate type and saves the source code to a file.

##### Returns

An [Expression\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression`1 'System.Linq.Expressions.Expression`1') representing the generated lambda.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filepathCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file path for the generated source code. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TDelegate | The type of the delegate to generate. |

##### Example

```C#
var compiler = new MethodCompiler();
var lambda = compiler.GenerateLambda&lt;Func&lt;int, int&gt;&gt;("MyCode.cs");
```

##### Remarks

This method creates a lambda expression using the defined parameters and the main expression body.

<a name='M-Bb-Expressions-MethodCompiler-GetParameter-System-String-'></a>
### GetParameter(name) `method`

##### Summary

Retrieves a parameter by its name.

##### Returns

A [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') representing the parameter, or null if no parameter with the specified name exists.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the parameter to retrieve. |

##### Example

```C#
var compiler = new MethodCompiler();
var parameter = compiler.GetParameter("myParam");
```

##### Remarks

This method searches the internal parameter list for a parameter with the specified name.

<a name='M-Bb-Expressions-MethodCompiler-GetVar-System-String-'></a>
### GetVar(name) `method`

##### Summary

Retrieves a variable or parameter by its name.

##### Returns

A [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') representing the variable or parameter, or null if no match is found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the variable or parameter to retrieve. |

##### Remarks

This method first searches for variables in the base class, then checks the parameters defined in this class.

<a name='T-Bb-Generators-Csharp-ResourceString'></a>
## ResourceString `type`

##### Namespace

Bb.Generators.Csharp

##### Summary

Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.

<a name='P-Bb-Generators-Csharp-ResourceString-Argument_NullComment'></a>
### Argument_NullComment `property`

##### Summary

Recherche une chaîne localisée semblable à The 'Comment' property of the CodeCommentStatement '{0}' cannot be null..

<a name='P-Bb-Generators-Csharp-ResourceString-ArityDoesntMatch'></a>
### ArityDoesntMatch `property`

##### Summary

Recherche une chaîne localisée semblable à The total arity specified in '{0}' does not match the number of TypeArguments supplied.  There were '{1}' TypeArguments supplied..

<a name='P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line1'></a>
### AutoGen_Comment_Line1 `property`

##### Summary

Recherche une chaîne localisée semblable à auto-generated>.

<a name='P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line2'></a>
### AutoGen_Comment_Line2 `property`

##### Summary

Recherche une chaîne localisée semblable à This code was generated by a tool..

<a name='P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line4'></a>
### AutoGen_Comment_Line4 `property`

##### Summary

Recherche une chaîne localisée semblable à Changes to this file may cause incorrect behavior and will be lost if.

<a name='P-Bb-Generators-Csharp-ResourceString-AutoGen_Comment_Line5'></a>
### AutoGen_Comment_Line5 `property`

##### Summary

Recherche une chaîne localisée semblable à the code is regenerated..

<a name='P-Bb-Generators-Csharp-ResourceString-CodeDomProvider_NotDefined'></a>
### CodeDomProvider_NotDefined `property`

##### Summary

Recherche une chaîne localisée semblable à There is no CodeDom provider defined for the language..

<a name='P-Bb-Generators-Csharp-ResourceString-CodeGenOutputWriter'></a>
### CodeGenOutputWriter `property`

##### Summary

Recherche une chaîne localisée semblable à The output writer for code generation and the writer supplied don't match and cannot be used. This is generally caused by a bad implementation of a CodeGenerator derived class..

<a name='P-Bb-Generators-Csharp-ResourceString-CodeGenReentrance'></a>
### CodeGenReentrance `property`

##### Summary

Recherche une chaîne localisée semblable à This code generation API cannot be called while the generator is being used to generate something else..

<a name='P-Bb-Generators-Csharp-ResourceString-Culture'></a>
### Culture `property`

##### Summary

Remplace la propriété CurrentUICulture du thread actuel pour toutes
  les recherches de ressources à l'aide de cette classe de ressource fortement typée.

<a name='P-Bb-Generators-Csharp-ResourceString-DuplicateFileName'></a>
### DuplicateFileName `property`

##### Summary

Recherche une chaîne localisée semblable à The file name '{0}' was already in the collection..

<a name='P-Bb-Generators-Csharp-ResourceString-ExecTimeout'></a>
### ExecTimeout `property`

##### Summary

Recherche une chaîne localisée semblable à Timed out waiting for a program to execute. The command being executed was {0}..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidElementType'></a>
### InvalidElementType `property`

##### Summary

Recherche une chaîne localisée semblable à Element type {0} is not supported..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidIdentifier'></a>
### InvalidIdentifier `property`

##### Summary

Recherche une chaîne localisée semblable à Identifier '{0}' is not valid..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidLanguageIdentifier'></a>
### InvalidLanguageIdentifier `property`

##### Summary

Recherche une chaîne localisée semblable à The identifier:"{0}" on the property:"{1}" of type:"{2}" is not a valid language-independent identifier name. Check to see if CodeGenerator.IsValidLanguageIndependentIdentifier allows the identifier name..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidNullEmptyArgument'></a>
### InvalidNullEmptyArgument `property`

##### Summary

Recherche une chaîne localisée semblable à Argument {0} cannot be null or zero-length..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidPathCharsInChecksum'></a>
### InvalidPathCharsInChecksum `property`

##### Summary

Recherche une chaîne localisée semblable à The CodeChecksumPragma file name '{0}' contains invalid path characters..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidPrimitiveType'></a>
### InvalidPrimitiveType `property`

##### Summary

Recherche une chaîne localisée semblable à Invalid Primitive Type: {0}. Consider using CodeObjectCreateExpression..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidRegion'></a>
### InvalidRegion `property`

##### Summary

Recherche une chaîne localisée semblable à The region directive '{0}' contains invalid characters.  RegionText cannot contain any new line characters..

<a name='P-Bb-Generators-Csharp-ResourceString-InvalidTypeName'></a>
### InvalidTypeName `property`

##### Summary

Recherche une chaîne localisée semblable à The type name:"{0}" on the property:"{1}" of type:"{2}" is not a valid language-independent type name..

<a name='P-Bb-Generators-Csharp-ResourceString-NotSupported_CodeDomAPI'></a>
### NotSupported_CodeDomAPI `property`

##### Summary

Recherche une chaîne localisée semblable à This CodeDomProvider does not support this method..

<a name='P-Bb-Generators-Csharp-ResourceString-Provider_does_not_support_options'></a>
### Provider_does_not_support_options `property`

##### Summary

Recherche une chaîne localisée semblable à This CodeDomProvider type does not have a constructor that takes providerOptions - "{0}"..

<a name='P-Bb-Generators-Csharp-ResourceString-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Retourne l'instance ResourceManager mise en cache utilisée par cette classe.

<a name='P-Bb-Generators-Csharp-ResourceString-toStringUnknown'></a>
### toStringUnknown `property`

##### Summary

Recherche une chaîne localisée semblable à {unknown}.

<a name='T-Bb-Generators-Csharp-SourceCodeDomGenerator'></a>
## SourceCodeDomGenerator `type`

##### Namespace

Bb.Generators.Csharp

##### Summary

Generates C# source code from expression trees using CodeDOM.

##### Remarks

This class provides functionality to parse expression trees and generate corresponding C# code.
It supports various expression types and handles complex scenarios like method calls, binary operations, and more.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-#ctor-System-String,System-String,System-String,System-String[],System-Boolean-'></a>
### #ctor(namespace,classname,methodname,usings,withDebug) `constructor`

##### Summary

Initializes a new instance of the [SourceCodeDomGenerator](#T-Bb-Generators-Csharp-SourceCodeDomGenerator 'Bb.Generators.Csharp.SourceCodeDomGenerator') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| namespace | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The namespace for the generated code. |
| classname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the class to generate. |
| methodname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the method to generate. |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | A list of namespaces to include in the generated code. |
| withDebug | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to include debugging information in the generated code. |

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-CreatePrivateMethod'></a>
### CreatePrivateMethod() `method`

##### Summary

Creates private helper methods for operations not directly supported by CodeDOM.

##### Parameters

This method has no parameters.

##### Remarks

This method generates methods like "Not", "Increment", and "Decrement" to handle unary operations.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-GetCode-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Boolean,System-String[]-'></a>
### GetCode(e,namespace,classname,methodname,withDebug,usings) `method`

##### Summary

Generates a [CodeNamespace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeNamespace 'System.CodeDom.CodeNamespace') from the given expression tree.

##### Returns

A [CodeNamespace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeNamespace 'System.CodeDom.CodeNamespace') containing the generated code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The expression tree to parse. |
| namespace | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The namespace for the generated code. |
| classname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the class to generate. |
| methodname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the method to generate. |
| withDebug | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to include debugging information in the generated code. |
| usings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | A list of namespaces to include in the generated code. |

##### Example

```C#
var expression = Expression.Constant(42);
var codeNamespace = SourceCodeDomGenerator.GetCode(expression, "MyNamespace", "MyClass", "MyMethod", false, "System");
```

##### Remarks

This method creates an instance of [SourceCodeDomGenerator](#T-Bb-Generators-Csharp-SourceCodeDomGenerator 'Bb.Generators.Csharp.SourceCodeDomGenerator'), parses the expression tree, and returns the generated namespace.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-Parse-System-Linq-Expressions-Expression-'></a>
### Parse(e) `method`

##### Summary

Parses the given expression tree and generates the corresponding code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The expression tree to parse. |

##### Remarks

This method collects required namespaces, visits the expression tree, and creates private helper methods as needed.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-Visit-System-Linq-Expressions-Expression-'></a>
### Visit(e) `method`

##### Summary

Visits the given expression and generates the corresponding CodeDOM representation.

##### Returns

An object representing the CodeDOM equivalent of the expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The expression to visit. |

##### Remarks

This method handles various expression types and delegates to specific visit methods for each type.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitBinaryOperation-System-Linq-Expressions-BinaryExpression,System-CodeDom-CodeBinaryOperatorType-'></a>
### VisitBinaryOperation(e,ope) `method`

##### Summary

Visits a binary operation expression and generates the corresponding CodeDOM representation.

##### Returns

A [CodeBinaryOperatorExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeBinaryOperatorExpression 'System.CodeDom.CodeBinaryOperatorExpression') representing the binary operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The binary expression to visit. |
| ope | [System.CodeDom.CodeBinaryOperatorType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeBinaryOperatorType 'System.CodeDom.CodeBinaryOperatorType') | The operator type for the binary operation. |

##### Remarks

This method generates a binary operation using the left and right operands of the expression.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitConstant-System-Linq-Expressions-ConstantExpression-'></a>
### VisitConstant(node) `method`

##### Summary

Visits a constant expression and generates the corresponding CodeDOM representation.

##### Returns

A [CodeExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeExpression 'System.CodeDom.CodeExpression') representing the constant value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The constant expression to visit. |

##### Remarks

This method handles various constant types, including strings, enums, and value types.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitLambda-System-Linq-Expressions-LambdaExpression-'></a>
### VisitLambda(node) `method`

##### Summary

Visits a lambda expression and generates the corresponding method in the generated class.

##### Returns

A [CodeMemberMethod](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeMemberMethod 'System.CodeDom.CodeMemberMethod') representing the generated method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The lambda expression to visit. |

##### Remarks

This method creates a method in the generated class, adds parameters, and processes the body of the lambda expression.

<a name='M-Bb-Generators-Csharp-SourceCodeDomGenerator-VisitMethodCall-System-Linq-Expressions-MethodCallExpression-'></a>
### VisitMethodCall(node) `method`

##### Summary

Visits a method call expression and generates the corresponding CodeDOM representation.

##### Returns

A [CodeMethodInvokeExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.CodeDom.CodeMethodInvokeExpression 'System.CodeDom.CodeMethodInvokeExpression') representing the method call.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The method call expression to visit. |

##### Remarks

This method handles static and instance method calls, as well as implicit and explicit conversions.
