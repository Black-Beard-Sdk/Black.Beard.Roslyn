using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb
{

    public class DotnetCommand
    {

        /// <summary>
        ///  RUN dotnet tool install --global Dacpac.Tool
        /// </summary>
        /// <returns></returns>
        public static string InstallToolDacpac()
        {
            return Tool("Dacpac.Tool");
        }

        /// <summary>
        /// Installez ou gérez les outils qui étendent l'expérience .NET.
        /// </summary>
        /// <param name="toolName"></param>
        /// <returns></returns>
        public static string Tool(string toolName)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"dotnet tool install --global {toolName}");

            return sb.ToString();

        }


        /// <summary>
        /// Installez ou gérez les outils qui étendent l'expérience .NET.
        /// </summary>
        /// <param name="$dacpacPath">folder that contains the dacpac</param>
        /// <returns></returns>
        public static (string, string) DacpacPublishWithCreateDatabase(string dacpacPath, string dacpacPattern, string server, string dbName, string userId, string password, DacpacArguments options = null)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"dacpac publish");
            sb.Append($" --dacpath={dacpacPath} --namePattern={dacpacPattern}");
            sb.Append($" --server={server}");
            sb.Append($" --databaseNames={dbName}");
            sb.Append($" --userId={userId} --password={password}");
            Generate(options, sb);

            return ("dotnet", sb.ToString());

        }

        /// <summary>
        /// Installez ou gérez les outils qui étendent l'expérience .NET.
        /// </summary>
        /// <param name="$dacpacPath">folder that contains the dacpac</param>
        /// <returns></returns>
        public static (string, string) DacpacPublishWithCreateDatabase(string dacpacPath, string dacpacPattern, string server, string dbName, DacpacArguments options = null)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"dacpac publish");
            sb.Append($" --dacpath={dacpacPath} --namePattern={dacpacPattern}");
            sb.Append($" --server={server} --databaseNames={dbName}");
            sb.Append($" --UseSspi=true");

            Generate(options, sb);

            return ("dotnet", sb.ToString());

        }


        private static void Generate(DacpacArguments options, StringBuilder sb)
        {
            if (options != null)
            {
                foreach (var property in typeof(DacpacArguments).GetProperties())
                {

                    var value = property.GetValue(options);
                    if (value != null)
                    {

                        var name = property.Name;
                        sb.Append(" --");
                        sb.Append(char.ToLower(name[0]));
                        sb.Append(name.Substring(1));
                        sb.Append('=');

                        if (property.PropertyType.GetGenericArguments()[0] == typeof(string))
                        {
                            var valueString = (string)value;
                            sb.Append(valueString);
                        }
                        else if (property.PropertyType.GetGenericArguments()[0] == typeof(bool))
                        {
                            var valueBoolean = (bool)value;
                            if (valueBoolean == true)
                                sb.Append("true");
                            else
                                sb.Append("false");
                        }

                    }
                }
            }
        }


    }

    public class DacpacArguments
    {

        /// <summary>
        /// Specifies additional deployment contributor arguments in addition to those already listed in the dacpac.
        /// </summary>
        public string? AdditionalDeploymentContributorArguments { get; set; }

        /// <summary>
        /// Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        public string? AdditionalDeploymentContributorPaths { get; set; }

        /// <summary>
        /// Specifies additional deployment contributors which should run - in addition to those specified in the dacpac.
        /// </summary>
        public string? AdditionalDeploymentContributors { get; set; }


        /// <summary>
        /// Get or set boolean that specifies whether CLR deployment will cause blocking assemblies to be dropped.
        /// </summary>
        public bool? AllowDropBlockingAssemblies { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether file paths should be used for external language deployment.
        /// </summary>
        public bool? AllowExternalLanguagePaths { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether file paths should be used for external library deployment.
        /// </summary>
        public bool? AllowExternalLibraryPaths { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether deployment will block due to platform compatibility.
        /// </summary>
        public bool? AllowIncompatiblePlatform { get; set; }


        /// <summary>
        /// Get or set boolean that specifies whether to ignore blocking data motion on RLS enabled tables
        /// </summary>
        public bool? AllowUnsafeRowLevelSecurityDataMovement { get; set; }

        /// <summary>
        /// Azure Shared Access Signature token
        /// </summary>
        public string? AzureSharedAccessSignatureToken { get; set; }

        /// <summary>
        /// Azure storage blob endpoint.
        /// </summary>
        public string? AzureStorageBlobEndpoint { get; set; }

        /// <summary>
        /// Azure storage container name.
        /// </summary>
        public string? AzureStorageContainer { get; set; }

        /// <summary>
        /// Azure storage key
        /// </summary>
        public string? AzureStorageKey { get; set; }

        /// <summary>
        /// The storage root path under the container.
        /// </summary>
        public string? AzureStorageRootPath { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether a database backup will be performed before proceeding with the actual deployment actions.
        /// </summary>
        public bool? BackupDatabaseBeforeChanges { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether deployment should stop if the operation could cause data loss.
        /// </summary>
        public bool? BlockOnPossibleDataLoss { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the system will check for differences between the present state of the database and the registered state of the database and block deployment if changes are detected. Even if this option is set to true, drift detection will only occur on a database if it was previously deployed with the RegisterDataTierApplication option enabled.
        /// </summary>
        public bool? BlockWhenDriftDetected { get; set; }

        /// <summary>
        /// Specifies the command timeout in seconds when executing queries against SQLServer. Default is 60
        /// </summary>
        public string? CommandTimeout { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the declaration of SQLCMD variables are commented out in the script header
        /// </summary>
        public bool? CommentOutSetVarDeclarations { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the target collation will be used for identifier comparison.
        /// </summary>
        public bool? CompareUsingTargetCollation { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the existing database will be dropped and a new database created before proceeding with the actual deployment actions. Acquires single-user mode before dropping the existing database.
        /// </summary>
        public bool? CreateNewDatabase { get; set; }

        /// <summary>
        /// Specifies the database lock timeout in seconds when executing queries against SQLServer.
        /// </summary>
        public string? DatabaseLockTimeout { get; set; }

        /// <summary>
        /// Defines optional parameters specific to a Microsoft Azure SQL Database.
        /// </summary>
        public string? DatabaseSpecification { get; set; }

        /// <summary>
        /// Data operation state provider.
        /// </summary>
        public string? DataOperationStateProvider { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the system will acquire single-user mode on the target database during the duration of the deployment operation.
        /// </summary>
        public bool? DeployDatabaseInSingleUserMode { get; set; }

        /// <summary>
        /// Get or set boolean that specifies if all DDL triggers will be disabled for the duration of the deployment operation and then re-enabled after all changes are applied.
        /// </summary>
        public bool? DisableAndReenableDdlTriggers { get; set; }

        /// <summary>
        /// Gets or set a boolean that specifies if indexes should be disabled before importing data into SQL Server.
        /// </summary>
        public string? DisableIndexesForDataPhase { get; set; }

        /// <summary>
        /// Gets or set a boolean that specifies if rebuilding indexes should not use parallelism for importing data into SQL Server.
        /// </summary>
        public string? DisableParallelismForEnablingIndexes { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether items configured for Change Data Capture (CDC) should be altered during deployment.
        /// </summary>
        public bool? DoNotAlterChangeDataCaptureObjects { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether items configured for Replication should be altered during deployment.
        /// </summary>
        public bool? DoNotAlterReplicatedObjects { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all database workload groups that do not exist in the source model.
        /// </summary>
        public bool? DoNotDropDatabaseWorkloadGroups { get; set; }

        /// <summary>
        /// Get or set a collection of object types that will not be dropped from the target when no corresponding object exists in the source. Note that dropping and recreating objects of the specified type may still be necessary due to dependencies from other objects.
        /// </summary>
        public string? DoNotDropObjectTypes { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all database workload groups that do not exist in the source model.
        /// </summary>
        public bool? DoNotDropWorkloadClassifiers { get; set; }

        /// <summary>
        /// Specified whether SQLCMD variable names should be used when comparing schema or their values
        /// </summary>
        public string? DoNotEvaluateSqlCmdVariables { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all constraints that do not exist in the source model.
        /// </summary>
        public bool? DropConstraintsNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all DML triggers that do not exist in the source model.
        /// </summary>
        public bool? DropDmlTriggersNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all extended properties that do not exist in the source model.
        /// </summary>
        public bool? DropExtendedPropertiesNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all indexes that do not exist in the source model.
        /// </summary>
        public bool? DropIndexesNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether objects that exist in the target but not source should be dropped during deployment.
        /// </summary>
        public bool? DropObjectsNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all permissions that do not exist in the source model.
        /// </summary>
        public bool? DropPermissionsNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all role memberships that do not exist in the source model.
        /// </summary>
        public bool? DropRoleMembersNotInSource { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to drop all role memberships that do not exist in the source model.
        /// </summary>
        public bool? DropStatisticsNotInSource { get; set; }

        /// <summary>
        /// Specifies an attestation protocol to be used with enclave based Always Encrypted.
        /// </summary>
        public string? EnclaveAttestationProtocol { get; set; }

        /// <summary>
        /// Specifies the enclave attestation Url (an attestation service endpoint) to be used with enclave based Always Encrypted.
        /// </summary>
        public string? EnclaveAttestationUrl { get; set; }

        /// <summary>
        /// Get or set a collection of object types to exclude from consideration when comparing the source and target model.
        /// </summary>
        public string? ExcludeObjectTypes { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether default values should be generated to populate NULL columns that are constrained to NOT NULL values.
        /// </summary>
        public bool? GenerateSmartDefaults { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to hash object names in logs
        /// </summary>
        public bool? HashObjectNamesInLogs { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the ANSI_NULL option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreAnsiNulls { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the AUTHORIZATION option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreAuthorizer { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the collation specifier from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreColumnCollation { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude from consideration the order of columns in tables when comparing the source and target model.
        /// </summary>
        public bool? IgnoreColumnOrder { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude comments from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreComments { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the file specification of a cryptographic provider from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreCryptographicProviderFilePath { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude Database Workload Groups that do not exist in the source model.
        /// </summary>
        public bool? IgnoreDatabaseWorkloadGroups { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude DDL trigger order from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreDdlTriggerOrder { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude DDL trigger state from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreDdlTriggerState { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the DEFAULT_SCHEMA option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreDefaultSchema { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude DML trigger order from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreDmlTriggerOrder { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude DML trigger state from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreDmlTriggerState { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude all extended properties from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreExtendedProperties { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the FILENAME option of FILE objects from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreFileAndLogFilePath { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the filegroup specifier from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreFilegroupPlacement { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the SIZE option of FILE objects from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreFileSize { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the FILLFACTOR option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreFillFactor { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the path specification of FULLTEXT CATALOG objects from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreFullTextCatalogFilePath { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the seed value of IDENTITY columns from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreIdentitySeed { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the increment value of IDENTITY columns from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreIncrement { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude differences in index options from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreIndexOptions { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the PAD_INDEX option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreIndexPadding { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude difference in the casing of keywords from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreKeywordCasing { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the ALLOW_ROW_LOCKS and ALLOW_PAGE_LOGKS options from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreLockHintsOnIndexes { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the SID option of the LOGIN object from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreLoginSids { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to exclude the NOT FOR REPLICATION option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreNotForReplication { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the partition scheme object from consideration when comparing the source and target model for the following objects: Table, Index, Unique Key, Primary Key, and Queue.
        /// </summary>
        public bool? IgnoreObjectPlacementOnPartitionScheme { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the parameter type and boundary VALUES of a PARTITION FUNCTION from consideration when comparing the source and target model. Also excludes FILEGROUP and partition function of a PARTITION SCHEMA from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnorePartitionSchemes { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude all permission statements from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnorePermissions { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the QUOTED_IDENTIFIER option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreQuotedIdentifiers { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude all ROLE MEMBERSHIP objects from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreRoleMembership { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the LIFETIME option of ROUTE objects from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreRouteLifetime { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the existence or absence of semi-colons from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreSemicolonBetweenStatements { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude data sensitivity classifications on columns when comparing the source and target model.
        /// </summary>
        public bool? IgnoreSensitivityClassifications { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether the options on the target table are updated to match the source table.
        /// </summary>
        public bool? IgnoreTableOptions { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the RANGE and BOUNDARY VALUES of a table partition option from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreTablePartitionOptions { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude user settings from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreUserSettingsObjects { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude whitespace from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreWhitespace { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the CHECK|NO CHECK option of a CHECK constraint object from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreWithNocheckOnCheckConstraints { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude the CHECK|NO CHECK option of a FOREIGN KEY constraint object from consideration when comparing the source and target model.
        /// </summary>
        public bool? IgnoreWithNocheckOnForeignKeys { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to exclude WorkloadClassifiers that do not exist in the source model.
        /// </summary>
        public bool? IgnoreWorkloadClassifiers { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to include referenced, external elements that also compose the source model and then update the target database in a single deployment operation.
        /// </summary>
        public bool? IncludeCompositeObjects { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to use transations during the deployment operation and commit the transaction after all changes are successfully applied.
        /// </summary>
        public bool? IncludeTransactionalScripts { get; set; }


        /// <summary>
        ///  Set Always Encrypted Parameterization Mode
        /// </summary>
        public string? IsAlwaysEncryptedParameterizationEnabled { get; set; }

        /// <summary>
        ///  Specifies the long running command timeout in seconds when executing queries against SQLServer.
        /// </summary>
        public string? LongRunningCommandTimeout { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether to force a change to CLR assemblies by dropping and recreating them.
        /// </summary>
        public bool? NoAlterStatementsToChangeClrTypes { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether files are supplied for filegroups defined in the deployment source.
        /// </summary>
        public bool? PopulateFilesOnFileGroups { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether the last values used for identity columns should be preserved.
        /// </summary>
        public bool? PreserveIdentityLastValues { get; set; }

        /// <summary>
        ///  Gets or set a boolean that specifies if indexes should be rebuilt offline after importing data into SQL Server.
        /// </summary>
        public string? RebuildIndexesOfflineForDataPhase { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether the database will be registered as a Data-Tier Application. If the target database is already a registered Data-Tier Application, then the registration will be updated.
        /// </summary>
        public bool? RegisterDataTierApplication { get; set; }

        /// <summary>
        ///  Gets or set a boolean that specifies if sequence value should be enabled or disabled before deploying the script into SQL Server.
        /// </summary>
        public string? RestoreSequenceCurrentValue { get; set; }

        /// <summary>
        ///  Specifies whether DeploymentPlanExecutor contributors should be run when other operations are executed. Default is false.
        /// </summary>
        public string? RunDeploymentPlanExecutors { get; set; }



        /// <summary>
        ///  Get or set boolean that specifies whether the target database should be altered to match the source model's collation.
        /// </summary>
        public bool? ScriptDatabaseCollation { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether the target database should be altered to match the source model's compatibility level.
        /// </summary>
        public bool? ScriptDatabaseCompatibility { get; set; }

        /// <summary>
        ///  Get or set boolean that specifies whether the database options in the target database should be updated to match the source model.
        /// </summary>
        public bool? ScriptDatabaseOptions { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the target database should be checked to ensure that it exists, is online and can be updated.
        /// </summary>
        public bool? ScriptDeployStateChecks { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether a file size is specified when adding files to file groups.
        /// </summary>
        public bool? ScriptFileSize { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether constraints are validated after all changes are applied.
        /// </summary>
        public bool? ScriptNewConstraintValidation { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether referencing procedures are refreshed when referenced objects are updated.
        /// </summary>
        public bool? ScriptRefreshModule { get; set; }

        /// <summary>
        /// Get dictionary of SQL command variable values, keyed by variable name.
        /// </summary>
        public string? SqlCommandVariableValues { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether to treat errors that occur during publish verification as warnings. The check is performed against the generated deployment plan before the plan is executed against the target database. Plan verification detects problems, such as the loss of target-only objects (for example, indexes), that must be dropped to make a change. Verification also detects situations where dependencies (such as tables or views) exist because of a reference to a composite project, but do not exist in the target database. You might choose to treat verification errors as warnings to get a complete list of issues instead of allowing the publish action to stop when the first error occurs.
        /// </summary>
        public bool? TreatVerificationErrorsAsWarnings { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether warnings should be generated when differences are found in objects that cannot be modified, for example, if the file size or file paths were different for a file.
        /// </summary>
        public bool? UnmodifiableObjectWarnings { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether deployment will verify that the collation specified in the source model is compatible with the collation specified in the target model.
        /// </summary>
        public bool? VerifyCollationCompatibility { get; set; }

        /// <summary>
        /// Get or set boolean that specifies whether the plan verification phase is executed or not.
        /// </summary>
        public bool? VerifyDeployment { get; set; }

    }

    /*
     
    add               Ajoutez un package ou une référence à un projet .NET.
    build             Générez un projet .NET.
    build-server      Interagissez avec les serveurs démarrés par une build.
    clean             Nettoyez les sorties de build d'un projet .NET.
    format            Appliquez les préférences de style à un projet ou une solution.
    help              Affichez l'aide de la ligne de commande.
    list              Listez les références de projet d'un projet .NET.
    msbuild           Exécutez des commandes MSBuild (Microsoft Build Engine).
    new               Créez un fichier ou projet .NET.
    nuget             Fournit des commandes NuGet supplémentaires.
    pack              Créez un package NuGet.
    publish           Publiez un projet .NET à des fins de déploiement.
    remove            Supprimez un package ou une référence d'un projet .NET.
    restore           Restaurez les dépendances spécifiées dans un projet .NET.
    run               Générez et exécutez une sortie de projet .NET.
    sdk               Gérer l'installation du kit SDK .NET.
    sln               Modifiez les fichiers solution Visual Studio.
    store             Stockez les assemblys spécifiés dans le magasin de packages de runtime.
    test              Exécutez des tests unitaires à l'aide du programme Test Runner spécifié dans un projet .NET.
    vstest            Exécutez des commandes VSTest (Microsoft Test Engine).
    workload          Gérez les charges de travail facultatives.

     
     */
}
