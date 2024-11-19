<a name='assembly'></a>
# Black.Beard.Build

## Contents

- [DacpacArguments](#T-Bb-DacpacArguments 'Bb.DacpacArguments')
  - [AdditionalDeploymentContributorArguments](#P-Bb-DacpacArguments-AdditionalDeploymentContributorArguments 'Bb.DacpacArguments.AdditionalDeploymentContributorArguments')
  - [AdditionalDeploymentContributorPaths](#P-Bb-DacpacArguments-AdditionalDeploymentContributorPaths 'Bb.DacpacArguments.AdditionalDeploymentContributorPaths')
  - [AdditionalDeploymentContributors](#P-Bb-DacpacArguments-AdditionalDeploymentContributors 'Bb.DacpacArguments.AdditionalDeploymentContributors')
  - [AllowDropBlockingAssemblies](#P-Bb-DacpacArguments-AllowDropBlockingAssemblies 'Bb.DacpacArguments.AllowDropBlockingAssemblies')
  - [AllowExternalLanguagePaths](#P-Bb-DacpacArguments-AllowExternalLanguagePaths 'Bb.DacpacArguments.AllowExternalLanguagePaths')
  - [AllowExternalLibraryPaths](#P-Bb-DacpacArguments-AllowExternalLibraryPaths 'Bb.DacpacArguments.AllowExternalLibraryPaths')
  - [AllowIncompatiblePlatform](#P-Bb-DacpacArguments-AllowIncompatiblePlatform 'Bb.DacpacArguments.AllowIncompatiblePlatform')
  - [AllowUnsafeRowLevelSecurityDataMovement](#P-Bb-DacpacArguments-AllowUnsafeRowLevelSecurityDataMovement 'Bb.DacpacArguments.AllowUnsafeRowLevelSecurityDataMovement')
  - [AzureSharedAccessSignatureToken](#P-Bb-DacpacArguments-AzureSharedAccessSignatureToken 'Bb.DacpacArguments.AzureSharedAccessSignatureToken')
  - [AzureStorageBlobEndpoint](#P-Bb-DacpacArguments-AzureStorageBlobEndpoint 'Bb.DacpacArguments.AzureStorageBlobEndpoint')
  - [AzureStorageContainer](#P-Bb-DacpacArguments-AzureStorageContainer 'Bb.DacpacArguments.AzureStorageContainer')
  - [AzureStorageKey](#P-Bb-DacpacArguments-AzureStorageKey 'Bb.DacpacArguments.AzureStorageKey')
  - [AzureStorageRootPath](#P-Bb-DacpacArguments-AzureStorageRootPath 'Bb.DacpacArguments.AzureStorageRootPath')
  - [BackupDatabaseBeforeChanges](#P-Bb-DacpacArguments-BackupDatabaseBeforeChanges 'Bb.DacpacArguments.BackupDatabaseBeforeChanges')
  - [BlockOnPossibleDataLoss](#P-Bb-DacpacArguments-BlockOnPossibleDataLoss 'Bb.DacpacArguments.BlockOnPossibleDataLoss')
  - [BlockWhenDriftDetected](#P-Bb-DacpacArguments-BlockWhenDriftDetected 'Bb.DacpacArguments.BlockWhenDriftDetected')
  - [CommandTimeout](#P-Bb-DacpacArguments-CommandTimeout 'Bb.DacpacArguments.CommandTimeout')
  - [CommentOutSetVarDeclarations](#P-Bb-DacpacArguments-CommentOutSetVarDeclarations 'Bb.DacpacArguments.CommentOutSetVarDeclarations')
  - [CompareUsingTargetCollation](#P-Bb-DacpacArguments-CompareUsingTargetCollation 'Bb.DacpacArguments.CompareUsingTargetCollation')
  - [CreateNewDatabase](#P-Bb-DacpacArguments-CreateNewDatabase 'Bb.DacpacArguments.CreateNewDatabase')
  - [DataOperationStateProvider](#P-Bb-DacpacArguments-DataOperationStateProvider 'Bb.DacpacArguments.DataOperationStateProvider')
  - [DatabaseLockTimeout](#P-Bb-DacpacArguments-DatabaseLockTimeout 'Bb.DacpacArguments.DatabaseLockTimeout')
  - [DatabaseSpecification](#P-Bb-DacpacArguments-DatabaseSpecification 'Bb.DacpacArguments.DatabaseSpecification')
  - [DeployDatabaseInSingleUserMode](#P-Bb-DacpacArguments-DeployDatabaseInSingleUserMode 'Bb.DacpacArguments.DeployDatabaseInSingleUserMode')
  - [DisableAndReenableDdlTriggers](#P-Bb-DacpacArguments-DisableAndReenableDdlTriggers 'Bb.DacpacArguments.DisableAndReenableDdlTriggers')
  - [DisableIndexesForDataPhase](#P-Bb-DacpacArguments-DisableIndexesForDataPhase 'Bb.DacpacArguments.DisableIndexesForDataPhase')
  - [DisableParallelismForEnablingIndexes](#P-Bb-DacpacArguments-DisableParallelismForEnablingIndexes 'Bb.DacpacArguments.DisableParallelismForEnablingIndexes')
  - [DoNotAlterChangeDataCaptureObjects](#P-Bb-DacpacArguments-DoNotAlterChangeDataCaptureObjects 'Bb.DacpacArguments.DoNotAlterChangeDataCaptureObjects')
  - [DoNotAlterReplicatedObjects](#P-Bb-DacpacArguments-DoNotAlterReplicatedObjects 'Bb.DacpacArguments.DoNotAlterReplicatedObjects')
  - [DoNotDropDatabaseWorkloadGroups](#P-Bb-DacpacArguments-DoNotDropDatabaseWorkloadGroups 'Bb.DacpacArguments.DoNotDropDatabaseWorkloadGroups')
  - [DoNotDropObjectTypes](#P-Bb-DacpacArguments-DoNotDropObjectTypes 'Bb.DacpacArguments.DoNotDropObjectTypes')
  - [DoNotDropWorkloadClassifiers](#P-Bb-DacpacArguments-DoNotDropWorkloadClassifiers 'Bb.DacpacArguments.DoNotDropWorkloadClassifiers')
  - [DoNotEvaluateSqlCmdVariables](#P-Bb-DacpacArguments-DoNotEvaluateSqlCmdVariables 'Bb.DacpacArguments.DoNotEvaluateSqlCmdVariables')
  - [DropConstraintsNotInSource](#P-Bb-DacpacArguments-DropConstraintsNotInSource 'Bb.DacpacArguments.DropConstraintsNotInSource')
  - [DropDmlTriggersNotInSource](#P-Bb-DacpacArguments-DropDmlTriggersNotInSource 'Bb.DacpacArguments.DropDmlTriggersNotInSource')
  - [DropExtendedPropertiesNotInSource](#P-Bb-DacpacArguments-DropExtendedPropertiesNotInSource 'Bb.DacpacArguments.DropExtendedPropertiesNotInSource')
  - [DropIndexesNotInSource](#P-Bb-DacpacArguments-DropIndexesNotInSource 'Bb.DacpacArguments.DropIndexesNotInSource')
  - [DropObjectsNotInSource](#P-Bb-DacpacArguments-DropObjectsNotInSource 'Bb.DacpacArguments.DropObjectsNotInSource')
  - [DropPermissionsNotInSource](#P-Bb-DacpacArguments-DropPermissionsNotInSource 'Bb.DacpacArguments.DropPermissionsNotInSource')
  - [DropRoleMembersNotInSource](#P-Bb-DacpacArguments-DropRoleMembersNotInSource 'Bb.DacpacArguments.DropRoleMembersNotInSource')
  - [DropStatisticsNotInSource](#P-Bb-DacpacArguments-DropStatisticsNotInSource 'Bb.DacpacArguments.DropStatisticsNotInSource')
  - [EnclaveAttestationProtocol](#P-Bb-DacpacArguments-EnclaveAttestationProtocol 'Bb.DacpacArguments.EnclaveAttestationProtocol')
  - [EnclaveAttestationUrl](#P-Bb-DacpacArguments-EnclaveAttestationUrl 'Bb.DacpacArguments.EnclaveAttestationUrl')
  - [ExcludeObjectTypes](#P-Bb-DacpacArguments-ExcludeObjectTypes 'Bb.DacpacArguments.ExcludeObjectTypes')
  - [GenerateSmartDefaults](#P-Bb-DacpacArguments-GenerateSmartDefaults 'Bb.DacpacArguments.GenerateSmartDefaults')
  - [HashObjectNamesInLogs](#P-Bb-DacpacArguments-HashObjectNamesInLogs 'Bb.DacpacArguments.HashObjectNamesInLogs')
  - [IgnoreAnsiNulls](#P-Bb-DacpacArguments-IgnoreAnsiNulls 'Bb.DacpacArguments.IgnoreAnsiNulls')
  - [IgnoreAuthorizer](#P-Bb-DacpacArguments-IgnoreAuthorizer 'Bb.DacpacArguments.IgnoreAuthorizer')
  - [IgnoreColumnCollation](#P-Bb-DacpacArguments-IgnoreColumnCollation 'Bb.DacpacArguments.IgnoreColumnCollation')
  - [IgnoreColumnOrder](#P-Bb-DacpacArguments-IgnoreColumnOrder 'Bb.DacpacArguments.IgnoreColumnOrder')
  - [IgnoreComments](#P-Bb-DacpacArguments-IgnoreComments 'Bb.DacpacArguments.IgnoreComments')
  - [IgnoreCryptographicProviderFilePath](#P-Bb-DacpacArguments-IgnoreCryptographicProviderFilePath 'Bb.DacpacArguments.IgnoreCryptographicProviderFilePath')
  - [IgnoreDatabaseWorkloadGroups](#P-Bb-DacpacArguments-IgnoreDatabaseWorkloadGroups 'Bb.DacpacArguments.IgnoreDatabaseWorkloadGroups')
  - [IgnoreDdlTriggerOrder](#P-Bb-DacpacArguments-IgnoreDdlTriggerOrder 'Bb.DacpacArguments.IgnoreDdlTriggerOrder')
  - [IgnoreDdlTriggerState](#P-Bb-DacpacArguments-IgnoreDdlTriggerState 'Bb.DacpacArguments.IgnoreDdlTriggerState')
  - [IgnoreDefaultSchema](#P-Bb-DacpacArguments-IgnoreDefaultSchema 'Bb.DacpacArguments.IgnoreDefaultSchema')
  - [IgnoreDmlTriggerOrder](#P-Bb-DacpacArguments-IgnoreDmlTriggerOrder 'Bb.DacpacArguments.IgnoreDmlTriggerOrder')
  - [IgnoreDmlTriggerState](#P-Bb-DacpacArguments-IgnoreDmlTriggerState 'Bb.DacpacArguments.IgnoreDmlTriggerState')
  - [IgnoreExtendedProperties](#P-Bb-DacpacArguments-IgnoreExtendedProperties 'Bb.DacpacArguments.IgnoreExtendedProperties')
  - [IgnoreFileAndLogFilePath](#P-Bb-DacpacArguments-IgnoreFileAndLogFilePath 'Bb.DacpacArguments.IgnoreFileAndLogFilePath')
  - [IgnoreFileSize](#P-Bb-DacpacArguments-IgnoreFileSize 'Bb.DacpacArguments.IgnoreFileSize')
  - [IgnoreFilegroupPlacement](#P-Bb-DacpacArguments-IgnoreFilegroupPlacement 'Bb.DacpacArguments.IgnoreFilegroupPlacement')
  - [IgnoreFillFactor](#P-Bb-DacpacArguments-IgnoreFillFactor 'Bb.DacpacArguments.IgnoreFillFactor')
  - [IgnoreFullTextCatalogFilePath](#P-Bb-DacpacArguments-IgnoreFullTextCatalogFilePath 'Bb.DacpacArguments.IgnoreFullTextCatalogFilePath')
  - [IgnoreIdentitySeed](#P-Bb-DacpacArguments-IgnoreIdentitySeed 'Bb.DacpacArguments.IgnoreIdentitySeed')
  - [IgnoreIncrement](#P-Bb-DacpacArguments-IgnoreIncrement 'Bb.DacpacArguments.IgnoreIncrement')
  - [IgnoreIndexOptions](#P-Bb-DacpacArguments-IgnoreIndexOptions 'Bb.DacpacArguments.IgnoreIndexOptions')
  - [IgnoreIndexPadding](#P-Bb-DacpacArguments-IgnoreIndexPadding 'Bb.DacpacArguments.IgnoreIndexPadding')
  - [IgnoreKeywordCasing](#P-Bb-DacpacArguments-IgnoreKeywordCasing 'Bb.DacpacArguments.IgnoreKeywordCasing')
  - [IgnoreLockHintsOnIndexes](#P-Bb-DacpacArguments-IgnoreLockHintsOnIndexes 'Bb.DacpacArguments.IgnoreLockHintsOnIndexes')
  - [IgnoreLoginSids](#P-Bb-DacpacArguments-IgnoreLoginSids 'Bb.DacpacArguments.IgnoreLoginSids')
  - [IgnoreNotForReplication](#P-Bb-DacpacArguments-IgnoreNotForReplication 'Bb.DacpacArguments.IgnoreNotForReplication')
  - [IgnoreObjectPlacementOnPartitionScheme](#P-Bb-DacpacArguments-IgnoreObjectPlacementOnPartitionScheme 'Bb.DacpacArguments.IgnoreObjectPlacementOnPartitionScheme')
  - [IgnorePartitionSchemes](#P-Bb-DacpacArguments-IgnorePartitionSchemes 'Bb.DacpacArguments.IgnorePartitionSchemes')
  - [IgnorePermissions](#P-Bb-DacpacArguments-IgnorePermissions 'Bb.DacpacArguments.IgnorePermissions')
  - [IgnoreQuotedIdentifiers](#P-Bb-DacpacArguments-IgnoreQuotedIdentifiers 'Bb.DacpacArguments.IgnoreQuotedIdentifiers')
  - [IgnoreRoleMembership](#P-Bb-DacpacArguments-IgnoreRoleMembership 'Bb.DacpacArguments.IgnoreRoleMembership')
  - [IgnoreRouteLifetime](#P-Bb-DacpacArguments-IgnoreRouteLifetime 'Bb.DacpacArguments.IgnoreRouteLifetime')
  - [IgnoreSemicolonBetweenStatements](#P-Bb-DacpacArguments-IgnoreSemicolonBetweenStatements 'Bb.DacpacArguments.IgnoreSemicolonBetweenStatements')
  - [IgnoreSensitivityClassifications](#P-Bb-DacpacArguments-IgnoreSensitivityClassifications 'Bb.DacpacArguments.IgnoreSensitivityClassifications')
  - [IgnoreTableOptions](#P-Bb-DacpacArguments-IgnoreTableOptions 'Bb.DacpacArguments.IgnoreTableOptions')
  - [IgnoreTablePartitionOptions](#P-Bb-DacpacArguments-IgnoreTablePartitionOptions 'Bb.DacpacArguments.IgnoreTablePartitionOptions')
  - [IgnoreUserSettingsObjects](#P-Bb-DacpacArguments-IgnoreUserSettingsObjects 'Bb.DacpacArguments.IgnoreUserSettingsObjects')
  - [IgnoreWhitespace](#P-Bb-DacpacArguments-IgnoreWhitespace 'Bb.DacpacArguments.IgnoreWhitespace')
  - [IgnoreWithNocheckOnCheckConstraints](#P-Bb-DacpacArguments-IgnoreWithNocheckOnCheckConstraints 'Bb.DacpacArguments.IgnoreWithNocheckOnCheckConstraints')
  - [IgnoreWithNocheckOnForeignKeys](#P-Bb-DacpacArguments-IgnoreWithNocheckOnForeignKeys 'Bb.DacpacArguments.IgnoreWithNocheckOnForeignKeys')
  - [IgnoreWorkloadClassifiers](#P-Bb-DacpacArguments-IgnoreWorkloadClassifiers 'Bb.DacpacArguments.IgnoreWorkloadClassifiers')
  - [IncludeCompositeObjects](#P-Bb-DacpacArguments-IncludeCompositeObjects 'Bb.DacpacArguments.IncludeCompositeObjects')
  - [IncludeTransactionalScripts](#P-Bb-DacpacArguments-IncludeTransactionalScripts 'Bb.DacpacArguments.IncludeTransactionalScripts')
  - [IsAlwaysEncryptedParameterizationEnabled](#P-Bb-DacpacArguments-IsAlwaysEncryptedParameterizationEnabled 'Bb.DacpacArguments.IsAlwaysEncryptedParameterizationEnabled')
  - [LongRunningCommandTimeout](#P-Bb-DacpacArguments-LongRunningCommandTimeout 'Bb.DacpacArguments.LongRunningCommandTimeout')
  - [NoAlterStatementsToChangeClrTypes](#P-Bb-DacpacArguments-NoAlterStatementsToChangeClrTypes 'Bb.DacpacArguments.NoAlterStatementsToChangeClrTypes')
  - [PopulateFilesOnFileGroups](#P-Bb-DacpacArguments-PopulateFilesOnFileGroups 'Bb.DacpacArguments.PopulateFilesOnFileGroups')
  - [PreserveIdentityLastValues](#P-Bb-DacpacArguments-PreserveIdentityLastValues 'Bb.DacpacArguments.PreserveIdentityLastValues')
  - [RebuildIndexesOfflineForDataPhase](#P-Bb-DacpacArguments-RebuildIndexesOfflineForDataPhase 'Bb.DacpacArguments.RebuildIndexesOfflineForDataPhase')
  - [RegisterDataTierApplication](#P-Bb-DacpacArguments-RegisterDataTierApplication 'Bb.DacpacArguments.RegisterDataTierApplication')
  - [RestoreSequenceCurrentValue](#P-Bb-DacpacArguments-RestoreSequenceCurrentValue 'Bb.DacpacArguments.RestoreSequenceCurrentValue')
  - [RunDeploymentPlanExecutors](#P-Bb-DacpacArguments-RunDeploymentPlanExecutors 'Bb.DacpacArguments.RunDeploymentPlanExecutors')
  - [ScriptDatabaseCollation](#P-Bb-DacpacArguments-ScriptDatabaseCollation 'Bb.DacpacArguments.ScriptDatabaseCollation')
  - [ScriptDatabaseCompatibility](#P-Bb-DacpacArguments-ScriptDatabaseCompatibility 'Bb.DacpacArguments.ScriptDatabaseCompatibility')
  - [ScriptDatabaseOptions](#P-Bb-DacpacArguments-ScriptDatabaseOptions 'Bb.DacpacArguments.ScriptDatabaseOptions')
  - [ScriptDeployStateChecks](#P-Bb-DacpacArguments-ScriptDeployStateChecks 'Bb.DacpacArguments.ScriptDeployStateChecks')
  - [ScriptFileSize](#P-Bb-DacpacArguments-ScriptFileSize 'Bb.DacpacArguments.ScriptFileSize')
  - [ScriptNewConstraintValidation](#P-Bb-DacpacArguments-ScriptNewConstraintValidation 'Bb.DacpacArguments.ScriptNewConstraintValidation')
  - [ScriptRefreshModule](#P-Bb-DacpacArguments-ScriptRefreshModule 'Bb.DacpacArguments.ScriptRefreshModule')
  - [SqlCommandVariableValues](#P-Bb-DacpacArguments-SqlCommandVariableValues 'Bb.DacpacArguments.SqlCommandVariableValues')
  - [TreatVerificationErrorsAsWarnings](#P-Bb-DacpacArguments-TreatVerificationErrorsAsWarnings 'Bb.DacpacArguments.TreatVerificationErrorsAsWarnings')
  - [UnmodifiableObjectWarnings](#P-Bb-DacpacArguments-UnmodifiableObjectWarnings 'Bb.DacpacArguments.UnmodifiableObjectWarnings')
  - [VerifyCollationCompatibility](#P-Bb-DacpacArguments-VerifyCollationCompatibility 'Bb.DacpacArguments.VerifyCollationCompatibility')
  - [VerifyDeployment](#P-Bb-DacpacArguments-VerifyDeployment 'Bb.DacpacArguments.VerifyDeployment')
- [DotnetCommand](#T-Bb-DotnetCommand 'Bb.DotnetCommand')
  - [DacpacPublishWithCreateDatabase($dacpacPath$dacpacPath)](#M-Bb-DotnetCommand-DacpacPublishWithCreateDatabase-System-String,System-String,System-String,System-String,System-String,System-String,Bb-DacpacArguments- 'Bb.DotnetCommand.DacpacPublishWithCreateDatabase(System.String,System.String,System.String,System.String,System.String,System.String,Bb.DacpacArguments)')
  - [DacpacPublishWithCreateDatabase($dacpacPath$dacpacPath)](#M-Bb-DotnetCommand-DacpacPublishWithCreateDatabase-System-String,System-String,System-String,System-String,Bb-DacpacArguments- 'Bb.DotnetCommand.DacpacPublishWithCreateDatabase(System.String,System.String,System.String,System.String,Bb.DacpacArguments)')
  - [InstallToolDacpac()](#M-Bb-DotnetCommand-InstallToolDacpac 'Bb.DotnetCommand.InstallToolDacpac')
  - [Tool(toolName)](#M-Bb-DotnetCommand-Tool-System-String- 'Bb.DotnetCommand.Tool(System.String)')

<a name='T-Bb-DacpacArguments'></a>
## DacpacArguments `type`

##### Namespace

Bb

<a name='P-Bb-DacpacArguments-AdditionalDeploymentContributorArguments'></a>
### AdditionalDeploymentContributorArguments `property`

##### Summary

Specifies additional deployment contributor arguments in addition to those already listed in the dacpac.

<a name='P-Bb-DacpacArguments-AdditionalDeploymentContributorPaths'></a>
### AdditionalDeploymentContributorPaths `property`

##### Summary

Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.

<a name='P-Bb-DacpacArguments-AdditionalDeploymentContributors'></a>
### AdditionalDeploymentContributors `property`

##### Summary

Specifies additional deployment contributors which should run - in addition to those specified in the dacpac.

<a name='P-Bb-DacpacArguments-AllowDropBlockingAssemblies'></a>
### AllowDropBlockingAssemblies `property`

##### Summary

Get or set boolean that specifies whether CLR deployment will cause blocking assemblies to be dropped.

<a name='P-Bb-DacpacArguments-AllowExternalLanguagePaths'></a>
### AllowExternalLanguagePaths `property`

##### Summary

Get or set boolean that specifies whether file paths should be used for external language deployment.

<a name='P-Bb-DacpacArguments-AllowExternalLibraryPaths'></a>
### AllowExternalLibraryPaths `property`

##### Summary

Get or set boolean that specifies whether file paths should be used for external library deployment.

<a name='P-Bb-DacpacArguments-AllowIncompatiblePlatform'></a>
### AllowIncompatiblePlatform `property`

##### Summary

Get or set boolean that specifies whether deployment will block due to platform compatibility.

<a name='P-Bb-DacpacArguments-AllowUnsafeRowLevelSecurityDataMovement'></a>
### AllowUnsafeRowLevelSecurityDataMovement `property`

##### Summary

Get or set boolean that specifies whether to ignore blocking data motion on RLS enabled tables

<a name='P-Bb-DacpacArguments-AzureSharedAccessSignatureToken'></a>
### AzureSharedAccessSignatureToken `property`

##### Summary

Azure Shared Access Signature token

<a name='P-Bb-DacpacArguments-AzureStorageBlobEndpoint'></a>
### AzureStorageBlobEndpoint `property`

##### Summary

Azure storage blob endpoint.

<a name='P-Bb-DacpacArguments-AzureStorageContainer'></a>
### AzureStorageContainer `property`

##### Summary

Azure storage container name.

<a name='P-Bb-DacpacArguments-AzureStorageKey'></a>
### AzureStorageKey `property`

##### Summary

Azure storage key

<a name='P-Bb-DacpacArguments-AzureStorageRootPath'></a>
### AzureStorageRootPath `property`

##### Summary

The storage root path under the container.

<a name='P-Bb-DacpacArguments-BackupDatabaseBeforeChanges'></a>
### BackupDatabaseBeforeChanges `property`

##### Summary

Get or set boolean that specifies whether a database backup will be performed before proceeding with the actual deployment actions.

<a name='P-Bb-DacpacArguments-BlockOnPossibleDataLoss'></a>
### BlockOnPossibleDataLoss `property`

##### Summary

Get or set boolean that specifies whether deployment should stop if the operation could cause data loss.

<a name='P-Bb-DacpacArguments-BlockWhenDriftDetected'></a>
### BlockWhenDriftDetected `property`

##### Summary

Get or set boolean that specifies whether the system will check for differences between the present state of the database and the registered state of the database and block deployment if changes are detected. Even if this option is set to true, drift detection will only occur on a database if it was previously deployed with the RegisterDataTierApplication option enabled.

<a name='P-Bb-DacpacArguments-CommandTimeout'></a>
### CommandTimeout `property`

##### Summary

Specifies the command timeout in seconds when executing queries against SQLServer. Default is 60

<a name='P-Bb-DacpacArguments-CommentOutSetVarDeclarations'></a>
### CommentOutSetVarDeclarations `property`

##### Summary

Get or set boolean that specifies whether the declaration of SQLCMD variables are commented out in the script header

<a name='P-Bb-DacpacArguments-CompareUsingTargetCollation'></a>
### CompareUsingTargetCollation `property`

##### Summary

Get or set boolean that specifies whether the target collation will be used for identifier comparison.

<a name='P-Bb-DacpacArguments-CreateNewDatabase'></a>
### CreateNewDatabase `property`

##### Summary

Get or set boolean that specifies whether the existing database will be dropped and a new database created before proceeding with the actual deployment actions. Acquires single-user mode before dropping the existing database.

<a name='P-Bb-DacpacArguments-DataOperationStateProvider'></a>
### DataOperationStateProvider `property`

##### Summary

Data operation state provider.

<a name='P-Bb-DacpacArguments-DatabaseLockTimeout'></a>
### DatabaseLockTimeout `property`

##### Summary

Specifies the database lock timeout in seconds when executing queries against SQLServer.

<a name='P-Bb-DacpacArguments-DatabaseSpecification'></a>
### DatabaseSpecification `property`

##### Summary

Defines optional parameters specific to a Microsoft Azure SQL Database.

<a name='P-Bb-DacpacArguments-DeployDatabaseInSingleUserMode'></a>
### DeployDatabaseInSingleUserMode `property`

##### Summary

Get or set boolean that specifies whether the system will acquire single-user mode on the target database during the duration of the deployment operation.

<a name='P-Bb-DacpacArguments-DisableAndReenableDdlTriggers'></a>
### DisableAndReenableDdlTriggers `property`

##### Summary

Get or set boolean that specifies if all DDL triggers will be disabled for the duration of the deployment operation and then re-enabled after all changes are applied.

<a name='P-Bb-DacpacArguments-DisableIndexesForDataPhase'></a>
### DisableIndexesForDataPhase `property`

##### Summary

Gets or set a boolean that specifies if indexes should be disabled before importing data into SQL Server.

<a name='P-Bb-DacpacArguments-DisableParallelismForEnablingIndexes'></a>
### DisableParallelismForEnablingIndexes `property`

##### Summary

Gets or set a boolean that specifies if rebuilding indexes should not use parallelism for importing data into SQL Server.

<a name='P-Bb-DacpacArguments-DoNotAlterChangeDataCaptureObjects'></a>
### DoNotAlterChangeDataCaptureObjects `property`

##### Summary

Get or set boolean that specifies whether items configured for Change Data Capture (CDC) should be altered during deployment.

<a name='P-Bb-DacpacArguments-DoNotAlterReplicatedObjects'></a>
### DoNotAlterReplicatedObjects `property`

##### Summary

Get or set boolean that specifies whether items configured for Replication should be altered during deployment.

<a name='P-Bb-DacpacArguments-DoNotDropDatabaseWorkloadGroups'></a>
### DoNotDropDatabaseWorkloadGroups `property`

##### Summary

Get or set boolean that specifies whether to drop all database workload groups that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DoNotDropObjectTypes'></a>
### DoNotDropObjectTypes `property`

##### Summary

Get or set a collection of object types that will not be dropped from the target when no corresponding object exists in the source. Note that dropping and recreating objects of the specified type may still be necessary due to dependencies from other objects.

<a name='P-Bb-DacpacArguments-DoNotDropWorkloadClassifiers'></a>
### DoNotDropWorkloadClassifiers `property`

##### Summary

Get or set boolean that specifies whether to drop all database workload groups that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DoNotEvaluateSqlCmdVariables'></a>
### DoNotEvaluateSqlCmdVariables `property`

##### Summary

Specified whether SQLCMD variable names should be used when comparing schema or their values

<a name='P-Bb-DacpacArguments-DropConstraintsNotInSource'></a>
### DropConstraintsNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all constraints that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropDmlTriggersNotInSource'></a>
### DropDmlTriggersNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all DML triggers that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropExtendedPropertiesNotInSource'></a>
### DropExtendedPropertiesNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all extended properties that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropIndexesNotInSource'></a>
### DropIndexesNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all indexes that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropObjectsNotInSource'></a>
### DropObjectsNotInSource `property`

##### Summary

Get or set boolean that specifies whether objects that exist in the target but not source should be dropped during deployment.

<a name='P-Bb-DacpacArguments-DropPermissionsNotInSource'></a>
### DropPermissionsNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all permissions that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropRoleMembersNotInSource'></a>
### DropRoleMembersNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all role memberships that do not exist in the source model.

<a name='P-Bb-DacpacArguments-DropStatisticsNotInSource'></a>
### DropStatisticsNotInSource `property`

##### Summary

Get or set boolean that specifies whether to drop all role memberships that do not exist in the source model.

<a name='P-Bb-DacpacArguments-EnclaveAttestationProtocol'></a>
### EnclaveAttestationProtocol `property`

##### Summary

Specifies an attestation protocol to be used with enclave based Always Encrypted.

<a name='P-Bb-DacpacArguments-EnclaveAttestationUrl'></a>
### EnclaveAttestationUrl `property`

##### Summary

Specifies the enclave attestation Url (an attestation service endpoint) to be used with enclave based Always Encrypted.

<a name='P-Bb-DacpacArguments-ExcludeObjectTypes'></a>
### ExcludeObjectTypes `property`

##### Summary

Get or set a collection of object types to exclude from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-GenerateSmartDefaults'></a>
### GenerateSmartDefaults `property`

##### Summary

Get or set boolean that specifies whether default values should be generated to populate NULL columns that are constrained to NOT NULL values.

<a name='P-Bb-DacpacArguments-HashObjectNamesInLogs'></a>
### HashObjectNamesInLogs `property`

##### Summary

Get or set boolean that specifies whether to hash object names in logs

<a name='P-Bb-DacpacArguments-IgnoreAnsiNulls'></a>
### IgnoreAnsiNulls `property`

##### Summary

Get or set boolean that specifies whether to exclude the ANSI_NULL option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreAuthorizer'></a>
### IgnoreAuthorizer `property`

##### Summary

Get or set boolean that specifies whether to exclude the AUTHORIZATION option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreColumnCollation'></a>
### IgnoreColumnCollation `property`

##### Summary

Get or set boolean that specifies whether to exclude the collation specifier from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreColumnOrder'></a>
### IgnoreColumnOrder `property`

##### Summary

Get or set boolean that specifies whether to exclude from consideration the order of columns in tables when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreComments'></a>
### IgnoreComments `property`

##### Summary

Get or set boolean that specifies whether to exclude comments from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreCryptographicProviderFilePath'></a>
### IgnoreCryptographicProviderFilePath `property`

##### Summary

Get or set boolean that specifies whether to exclude the file specification of a cryptographic provider from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreDatabaseWorkloadGroups'></a>
### IgnoreDatabaseWorkloadGroups `property`

##### Summary

Get or set boolean that specifies whether to exclude Database Workload Groups that do not exist in the source model.

<a name='P-Bb-DacpacArguments-IgnoreDdlTriggerOrder'></a>
### IgnoreDdlTriggerOrder `property`

##### Summary

Get or set boolean that specifies whether to exclude DDL trigger order from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreDdlTriggerState'></a>
### IgnoreDdlTriggerState `property`

##### Summary

Get or set boolean that specifies whether to exclude DDL trigger state from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreDefaultSchema'></a>
### IgnoreDefaultSchema `property`

##### Summary

Get or set boolean that specifies whether to exclude the DEFAULT_SCHEMA option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreDmlTriggerOrder'></a>
### IgnoreDmlTriggerOrder `property`

##### Summary

Get or set boolean that specifies whether to exclude DML trigger order from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreDmlTriggerState'></a>
### IgnoreDmlTriggerState `property`

##### Summary

Get or set boolean that specifies whether to exclude DML trigger state from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreExtendedProperties'></a>
### IgnoreExtendedProperties `property`

##### Summary

Get or set boolean that specifies whether to exclude all extended properties from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreFileAndLogFilePath'></a>
### IgnoreFileAndLogFilePath `property`

##### Summary

Get or set boolean that specifies whether to exclude the FILENAME option of FILE objects from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreFileSize'></a>
### IgnoreFileSize `property`

##### Summary

Get or set boolean that specifies whether to exclude the SIZE option of FILE objects from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreFilegroupPlacement'></a>
### IgnoreFilegroupPlacement `property`

##### Summary

Get or set boolean that specifies whether to exclude the filegroup specifier from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreFillFactor'></a>
### IgnoreFillFactor `property`

##### Summary

Get or set boolean that specifies whether to exclude the FILLFACTOR option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreFullTextCatalogFilePath'></a>
### IgnoreFullTextCatalogFilePath `property`

##### Summary

Get or set boolean that specifies whether to exclude the path specification of FULLTEXT CATALOG objects from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreIdentitySeed'></a>
### IgnoreIdentitySeed `property`

##### Summary

Get or set boolean that specifies whether to exclude the seed value of IDENTITY columns from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreIncrement'></a>
### IgnoreIncrement `property`

##### Summary

Get or set boolean that specifies whether to exclude the increment value of IDENTITY columns from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreIndexOptions'></a>
### IgnoreIndexOptions `property`

##### Summary

Get or set boolean that specifies whether to exclude differences in index options from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreIndexPadding'></a>
### IgnoreIndexPadding `property`

##### Summary

Get or set boolean that specifies whether to exclude the PAD_INDEX option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreKeywordCasing'></a>
### IgnoreKeywordCasing `property`

##### Summary

Get or set boolean that specifies whether to exclude difference in the casing of keywords from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreLockHintsOnIndexes'></a>
### IgnoreLockHintsOnIndexes `property`

##### Summary

Get or set boolean that specifies whether to exclude the ALLOW_ROW_LOCKS and ALLOW_PAGE_LOGKS options from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreLoginSids'></a>
### IgnoreLoginSids `property`

##### Summary

Get or set boolean that specifies whether to exclude the SID option of the LOGIN object from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreNotForReplication'></a>
### IgnoreNotForReplication `property`

##### Summary

Get or set boolean that specifies whether to exclude the NOT FOR REPLICATION option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreObjectPlacementOnPartitionScheme'></a>
### IgnoreObjectPlacementOnPartitionScheme `property`

##### Summary

Get or set boolean that specifies whether to exclude the partition scheme object from consideration when comparing the source and target model for the following objects: Table, Index, Unique Key, Primary Key, and Queue.

<a name='P-Bb-DacpacArguments-IgnorePartitionSchemes'></a>
### IgnorePartitionSchemes `property`

##### Summary

Get or set boolean that specifies whether to exclude the parameter type and boundary VALUES of a PARTITION FUNCTION from consideration when comparing the source and target model. Also excludes FILEGROUP and partition function of a PARTITION SCHEMA from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnorePermissions'></a>
### IgnorePermissions `property`

##### Summary

Get or set boolean that specifies whether to exclude all permission statements from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreQuotedIdentifiers'></a>
### IgnoreQuotedIdentifiers `property`

##### Summary

Get or set boolean that specifies whether to exclude the QUOTED_IDENTIFIER option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreRoleMembership'></a>
### IgnoreRoleMembership `property`

##### Summary

Get or set boolean that specifies whether to exclude all ROLE MEMBERSHIP objects from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreRouteLifetime'></a>
### IgnoreRouteLifetime `property`

##### Summary

Get or set boolean that specifies whether to exclude the LIFETIME option of ROUTE objects from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreSemicolonBetweenStatements'></a>
### IgnoreSemicolonBetweenStatements `property`

##### Summary

Get or set boolean that specifies whether to exclude the existence or absence of semi-colons from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreSensitivityClassifications'></a>
### IgnoreSensitivityClassifications `property`

##### Summary

Get or set boolean that specifies whether to exclude data sensitivity classifications on columns when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreTableOptions'></a>
### IgnoreTableOptions `property`

##### Summary

Get or set boolean that specifies whether the options on the target table are updated to match the source table.

<a name='P-Bb-DacpacArguments-IgnoreTablePartitionOptions'></a>
### IgnoreTablePartitionOptions `property`

##### Summary

Get or set boolean that specifies whether to exclude the RANGE and BOUNDARY VALUES of a table partition option from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreUserSettingsObjects'></a>
### IgnoreUserSettingsObjects `property`

##### Summary

Get or set boolean that specifies whether to exclude user settings from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreWhitespace'></a>
### IgnoreWhitespace `property`

##### Summary

Get or set boolean that specifies whether to exclude whitespace from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreWithNocheckOnCheckConstraints'></a>
### IgnoreWithNocheckOnCheckConstraints `property`

##### Summary

Get or set boolean that specifies whether to exclude the CHECK|NO CHECK option of a CHECK constraint object from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreWithNocheckOnForeignKeys'></a>
### IgnoreWithNocheckOnForeignKeys `property`

##### Summary

Get or set boolean that specifies whether to exclude the CHECK|NO CHECK option of a FOREIGN KEY constraint object from consideration when comparing the source and target model.

<a name='P-Bb-DacpacArguments-IgnoreWorkloadClassifiers'></a>
### IgnoreWorkloadClassifiers `property`

##### Summary

Get or set boolean that specifies whether to exclude WorkloadClassifiers that do not exist in the source model.

<a name='P-Bb-DacpacArguments-IncludeCompositeObjects'></a>
### IncludeCompositeObjects `property`

##### Summary

Get or set boolean that specifies whether to include referenced, external elements that also compose the source model and then update the target database in a single deployment operation.

<a name='P-Bb-DacpacArguments-IncludeTransactionalScripts'></a>
### IncludeTransactionalScripts `property`

##### Summary

Get or set boolean that specifies whether to use transations during the deployment operation and commit the transaction after all changes are successfully applied.

<a name='P-Bb-DacpacArguments-IsAlwaysEncryptedParameterizationEnabled'></a>
### IsAlwaysEncryptedParameterizationEnabled `property`

##### Summary

Set Always Encrypted Parameterization Mode

<a name='P-Bb-DacpacArguments-LongRunningCommandTimeout'></a>
### LongRunningCommandTimeout `property`

##### Summary

Specifies the long running command timeout in seconds when executing queries against SQLServer.

<a name='P-Bb-DacpacArguments-NoAlterStatementsToChangeClrTypes'></a>
### NoAlterStatementsToChangeClrTypes `property`

##### Summary

Get or set boolean that specifies whether to force a change to CLR assemblies by dropping and recreating them.

<a name='P-Bb-DacpacArguments-PopulateFilesOnFileGroups'></a>
### PopulateFilesOnFileGroups `property`

##### Summary

Get or set boolean that specifies whether files are supplied for filegroups defined in the deployment source.

<a name='P-Bb-DacpacArguments-PreserveIdentityLastValues'></a>
### PreserveIdentityLastValues `property`

##### Summary

Get or set boolean that specifies whether the last values used for identity columns should be preserved.

<a name='P-Bb-DacpacArguments-RebuildIndexesOfflineForDataPhase'></a>
### RebuildIndexesOfflineForDataPhase `property`

##### Summary

Gets or set a boolean that specifies if indexes should be rebuilt offline after importing data into SQL Server.

<a name='P-Bb-DacpacArguments-RegisterDataTierApplication'></a>
### RegisterDataTierApplication `property`

##### Summary

Get or set boolean that specifies whether the database will be registered as a Data-Tier Application. If the target database is already a registered Data-Tier Application, then the registration will be updated.

<a name='P-Bb-DacpacArguments-RestoreSequenceCurrentValue'></a>
### RestoreSequenceCurrentValue `property`

##### Summary

Gets or set a boolean that specifies if sequence value should be enabled or disabled before deploying the script into SQL Server.

<a name='P-Bb-DacpacArguments-RunDeploymentPlanExecutors'></a>
### RunDeploymentPlanExecutors `property`

##### Summary

Specifies whether DeploymentPlanExecutor contributors should be run when other operations are executed. Default is false.

<a name='P-Bb-DacpacArguments-ScriptDatabaseCollation'></a>
### ScriptDatabaseCollation `property`

##### Summary

Get or set boolean that specifies whether the target database should be altered to match the source model's collation.

<a name='P-Bb-DacpacArguments-ScriptDatabaseCompatibility'></a>
### ScriptDatabaseCompatibility `property`

##### Summary

Get or set boolean that specifies whether the target database should be altered to match the source model's compatibility level.

<a name='P-Bb-DacpacArguments-ScriptDatabaseOptions'></a>
### ScriptDatabaseOptions `property`

##### Summary

Get or set boolean that specifies whether the database options in the target database should be updated to match the source model.

<a name='P-Bb-DacpacArguments-ScriptDeployStateChecks'></a>
### ScriptDeployStateChecks `property`

##### Summary

Get or set boolean that specifies whether the target database should be checked to ensure that it exists, is online and can be updated.

<a name='P-Bb-DacpacArguments-ScriptFileSize'></a>
### ScriptFileSize `property`

##### Summary

Get or set boolean that specifies whether a file size is specified when adding files to file groups.

<a name='P-Bb-DacpacArguments-ScriptNewConstraintValidation'></a>
### ScriptNewConstraintValidation `property`

##### Summary

Get or set boolean that specifies whether constraints are validated after all changes are applied.

<a name='P-Bb-DacpacArguments-ScriptRefreshModule'></a>
### ScriptRefreshModule `property`

##### Summary

Get or set boolean that specifies whether referencing procedures are refreshed when referenced objects are updated.

<a name='P-Bb-DacpacArguments-SqlCommandVariableValues'></a>
### SqlCommandVariableValues `property`

##### Summary

Get dictionary of SQL command variable values, keyed by variable name.

<a name='P-Bb-DacpacArguments-TreatVerificationErrorsAsWarnings'></a>
### TreatVerificationErrorsAsWarnings `property`

##### Summary

Get or set boolean that specifies whether to treat errors that occur during publish verification as warnings. The check is performed against the generated deployment plan before the plan is executed against the target database. Plan verification detects problems, such as the loss of target-only objects (for example, indexes), that must be dropped to make a change. Verification also detects situations where dependencies (such as tables or views) exist because of a reference to a composite project, but do not exist in the target database. You might choose to treat verification errors as warnings to get a complete list of issues instead of allowing the publish action to stop when the first error occurs.

<a name='P-Bb-DacpacArguments-UnmodifiableObjectWarnings'></a>
### UnmodifiableObjectWarnings `property`

##### Summary

Get or set boolean that specifies whether warnings should be generated when differences are found in objects that cannot be modified, for example, if the file size or file paths were different for a file.

<a name='P-Bb-DacpacArguments-VerifyCollationCompatibility'></a>
### VerifyCollationCompatibility `property`

##### Summary

Get or set boolean that specifies whether deployment will verify that the collation specified in the source model is compatible with the collation specified in the target model.

<a name='P-Bb-DacpacArguments-VerifyDeployment'></a>
### VerifyDeployment `property`

##### Summary

Get or set boolean that specifies whether the plan verification phase is executed or not.

<a name='T-Bb-DotnetCommand'></a>
## DotnetCommand `type`

##### Namespace

Bb

<a name='M-Bb-DotnetCommand-DacpacPublishWithCreateDatabase-System-String,System-String,System-String,System-String,System-String,System-String,Bb-DacpacArguments-'></a>
### DacpacPublishWithCreateDatabase($dacpacPath$dacpacPath) `method`

##### Summary

Installez ou gérez les outils qui étendent l'expérience .NET.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| $dacpacPath$dacpacPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | folder that contains the dacpac |

<a name='M-Bb-DotnetCommand-DacpacPublishWithCreateDatabase-System-String,System-String,System-String,System-String,Bb-DacpacArguments-'></a>
### DacpacPublishWithCreateDatabase($dacpacPath$dacpacPath) `method`

##### Summary

Installez ou gérez les outils qui étendent l'expérience .NET.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| $dacpacPath$dacpacPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | folder that contains the dacpac |

<a name='M-Bb-DotnetCommand-InstallToolDacpac'></a>
### InstallToolDacpac() `method`

##### Summary

RUN dotnet tool install --global Dacpac.Tool

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Bb-DotnetCommand-Tool-System-String-'></a>
### Tool(toolName) `method`

##### Summary

Installez ou gérez les outils qui étendent l'expérience .NET.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| toolName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
