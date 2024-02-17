


using System.Diagnostics;

namespace Refs
{
    public class Accessibility : ILib
    {

        public static Accessibility Default { get; } = new Accessibility();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, };

        public string[] Namespaces { get; } = new string[] { "Accessibility", };

        public static string AssemblyName = "Accessibility";
        public static string AssemblyFile = "Accessibility.dll";


    }

    public class DirectWriteForwarder : ILib
    {

        public static DirectWriteForwarder Default { get; } = new DirectWriteForwarder();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { mscorlib.Default, System.Runtime.Default, System.Runtime.Extensions.Default, System.Runtime.InteropServices.Default, System.Runtime.CompilerServices.VisualC.Default, Microsoft.CSharp.Default, Microsoft.VisualBasic.Core.Default, Microsoft.VisualBasic.Default, Microsoft.Win32.Primitives.Default, netstandard.Default, System.AppContext.Default, System.Buffers.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Collections.Immutable.Default, System.Collections.NonGeneric.Default, System.Collections.Specialized.Default, System.ComponentModel.Annotations.Default, System.ComponentModel.DataAnnotations.Default, System.ComponentModel.Default, System.ComponentModel.EventBasedAsync.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.Configuration.Default, System.Console.Default, System.Core.Default, System.Data.Common.Default, System.Data.DataSetExtensions.Default, System.Data.Default, System.Diagnostics.Contracts.Default, System.Diagnostics.Debug.Default, System.Diagnostics.DiagnosticSource.Default, System.Diagnostics.FileVersionInfo.Default, System.Diagnostics.Process.Default, System.Diagnostics.StackTrace.Default, System.Diagnostics.TextWriterTraceListener.Default, System.Diagnostics.Tools.Default, System.Diagnostics.TraceSource.Default, System.Diagnostics.Tracing.Default, System.Default, System.Drawing.Default, System.Drawing.Primitives.Default, System.Dynamic.Runtime.Default, System.Globalization.Calendars.Default, System.Globalization.Default, System.Globalization.Extensions.Default, System.IO.Compression.Brotli.Default, System.IO.Compression.Default, System.IO.Compression.FileSystem.Default, System.IO.Compression.ZipFile.Default, System.IO.Default, System.IO.FileSystem.Default, System.IO.FileSystem.DriveInfo.Default, System.IO.FileSystem.Primitives.Default, System.IO.FileSystem.Watcher.Default, System.IO.IsolatedStorage.Default, System.IO.MemoryMappedFiles.Default, System.IO.Packaging.Default, System.IO.Pipes.Default, System.IO.UnmanagedMemoryStream.Default, System.Linq.Default, System.Linq.Expressions.Default, System.Linq.Parallel.Default, System.Linq.Queryable.Default, System.Memory.Default, System.Net.Default, System.Net.Http.Default, System.Net.HttpListener.Default, System.Net.Mail.Default, System.Net.NameResolution.Default, System.Net.NetworkInformation.Default, System.Net.Ping.Default, System.Net.Primitives.Default, System.Net.Requests.Default, System.Net.Security.Default, System.Net.ServicePoint.Default, System.Net.Sockets.Default, System.Net.WebClient.Default, System.Net.WebHeaderCollection.Default, System.Net.WebProxy.Default, System.Net.WebSockets.Client.Default, System.Net.WebSockets.Default, System.Numerics.Default, System.Numerics.Vectors.Default, System.ObjectModel.Default, System.Reflection.DispatchProxy.Default, System.Reflection.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Extensions.Default, System.Reflection.Metadata.Default, System.Reflection.Primitives.Default, System.Reflection.TypeExtensions.Default, System.Resources.Reader.Default, System.Resources.ResourceManager.Default, System.Resources.Writer.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Handles.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Runtime.InteropServices.WindowsRuntime.Default, System.Runtime.Intrinsics.Default, System.Runtime.Loader.Default, System.Runtime.Numerics.Default, System.Runtime.Serialization.Default, System.Runtime.Serialization.Formatters.Default, System.Runtime.Serialization.Json.Default, System.Runtime.Serialization.Primitives.Default, System.Runtime.Serialization.Xml.Default, System.Security.Claims.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Default, System.Security.Principal.Default, System.Security.SecureString.Default, System.ServiceModel.Web.Default, System.ServiceProcess.Default, System.Text.Encoding.CodePages.Default, System.Text.Encoding.Default, System.Text.Encoding.Extensions.Default, System.Text.Encodings.Web.Default, System.Text.Json.Default, System.Text.RegularExpressions.Default, System.Threading.Channels.Default, System.Threading.Default, System.Threading.Overlapped.Default, System.Threading.Tasks.Dataflow.Default, System.Threading.Tasks.Default, System.Threading.Tasks.Extensions.Default, System.Threading.Tasks.Parallel.Default, System.Threading.Thread.Default, System.Threading.ThreadPool.Default, System.Threading.Timer.Default, System.Transactions.Default, System.Transactions.Local.Default, System.ValueTuple.Default, System.Web.Default, System.Web.HttpUtility.Default, System.Windows.Default, System.Xml.Default, System.Xml.Linq.Default, System.Xml.ReaderWriter.Default, System.Xml.Serialization.Default, System.Xml.XDocument.Default, System.Xml.XmlDocument.Default, System.Xml.XmlSerializer.Default, System.Xml.XPath.Default, System.Xml.XPath.XDocument.Default, WindowsBase.Default, netstandard.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal.TtfDelta", "MS.Internal", "MS.Internal.Text.TextInterface", "MS.Internal.Text.TextInterface.Native", "MS.Internal.Text.TextInterface.Interfaces", "MS.Internal.Text.TextInterface.Generics", "<CppImplementationDetails>", "vc_attributes", "<CrtImplementationDetails>", };

        public static string AssemblyName = "DirectWriteForwarder";
        public static string AssemblyFile = "DirectWriteForwarder.dll";


    }

    public class Microsoft
    {

        public class AspNetCore : ILib
        {

            public static AspNetCore Default { get; } = new AspNetCore();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.AspNetCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Hosting.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.DependencyInjection.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.AspNetCore.Server.Kestrel.Core.Default, Microsoft.AspNetCore.HttpOverrides.Default, Microsoft.AspNetCore.HostFiltering.Default, System.IO.FileSystem.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.Configuration.CommandLine.Default, Microsoft.AspNetCore.Server.Kestrel.Default, Microsoft.AspNetCore.Server.IIS.Default, Microsoft.AspNetCore.Server.IISIntegration.Default, Microsoft.Extensions.Logging.Configuration.Default, Microsoft.Extensions.Logging.Console.Default, Microsoft.Extensions.Logging.Debug.Default, Microsoft.Extensions.Logging.EventSource.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Options.ConfigurationExtensions.Default, System.Net.Primitives.Default, Microsoft.Extensions.Configuration.Json.Default, Microsoft.Extensions.Configuration.UserSecrets.Default, Microsoft.Extensions.Configuration.EnvironmentVariables.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Hosting", "Microsoft.AspNetCore", };

            public static string AssemblyName = "Microsoft.AspNetCore";
            public static string AssemblyFile = "Microsoft.AspNetCore.dll";


            public class Antiforgery : ILib
            {

                public static Antiforgery Default { get; } = new Antiforgery();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.ObjectPool.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.DataProtection.Default, System.Security.Cryptography.Algorithms.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Threading.Tasks.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, System.Security.Claims.Default, System.Collections.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Cryptography.Primitives.Default, System.Linq.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Security.Cryptography.Csp.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Antiforgery", };

                public static string AssemblyName = "Microsoft.AspNetCore.Antiforgery";
                public static string AssemblyFile = "Microsoft.AspNetCore.Antiforgery.dll";


            }

            public class Authentication : ILib
            {

                public static Authentication Default { get; } = new Authentication();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Claims.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Text.Encodings.Web.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Text.Json.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, System.Runtime.Extensions.Default, System.Collections.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.AspNetCore.Http.Features.Default, System.Net.Http.Default, System.Linq.Default, Microsoft.AspNetCore.Authentication.Core.Default, Microsoft.AspNetCore.DataProtection.Default, Microsoft.Extensions.WebEncoders.Default, Microsoft.AspNetCore.WebUtilities.Default, System.ComponentModel.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Authentication", "Microsoft.AspNetCore.Builder", };

                public static string AssemblyName = "Microsoft.AspNetCore.Authentication";
                public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.ComponentModel.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Authentication", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authentication.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.Abstractions.dll";


                }

                public class BearerToken : ILib
                {

                    public static BearerToken Default { get; } = new BearerToken();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Authentication.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Text.Encodings.Web.Default, System.Security.Claims.Default, System.Text.Json.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Net.Http.Headers.Default, System.ComponentModel.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Authentication.BearerToken", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authentication.BearerToken";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.BearerToken.dll";


                }

                public class Cookies : ILib
                {

                    public static Cookies Default { get; } = new Cookies();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Authentication.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Text.Encodings.Web.Default, System.Security.Claims.Default, System.Threading.Tasks.Default, Microsoft.AspNetCore.Http.Features.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Extensions.Default, Microsoft.Net.Http.Headers.Default, System.Linq.Default, System.Security.Principal.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Authentication.Cookies", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authentication.Cookies";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.Cookies.dll";


                }

                public class Core : ILib
                {

                    public static Core Default { get; } = new Core();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Options.Default, System.Security.Claims.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Linq.Default, System.ComponentModel.Default, System.Security.Principal.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Authentication", "Microsoft.Extensions.DependencyInjection", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authentication.Core";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.Core.dll";


                }

                public class OAuth : ILib
                {

                    public static OAuth Default { get; } = new OAuth();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Authentication.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Text.Json.Default, System.Net.Http.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Security.Cryptography.Algorithms.Default, System.Text.Encodings.Web.Default, System.Threading.Tasks.Default, System.Collections.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, System.Diagnostics.Debug.Default, System.Net.Primitives.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Security.Principal.Default, System.Security.Cryptography.Primitives.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Linq.Default, Microsoft.Net.Http.Headers.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Logging", "Microsoft.AspNetCore.Authentication", "Microsoft.AspNetCore.Authentication.OAuth", "Microsoft.AspNetCore.Authentication.OAuth.Claims", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authentication.OAuth";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authentication.OAuth.dll";


                }

            }

            public class Authorization : ILib
            {

                public static Authorization Default { get; } = new Authorization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Metadata.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Security.Claims.Default, Microsoft.Extensions.Options.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Security.Principal.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Authorization", "Microsoft.AspNetCore.Authorization.Infrastructure", };

                public static string AssemblyName = "Microsoft.AspNetCore.Authorization";
                public static string AssemblyFile = "Microsoft.AspNetCore.Authorization.dll";


                public class Policy : ILib
                {

                    public static Policy Default { get; } = new Policy();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Claims.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Authorization.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Threading.Tasks.Default, Microsoft.AspNetCore.Metadata.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Diagnostics.Debug.Default, System.Linq.Default, System.ComponentModel.Default, System.Security.Principal.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Authorization", "Microsoft.AspNetCore.Authorization.Policy", "Microsoft.AspNetCore.Builder", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Authorization.Policy";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Authorization.Policy.dll";


                }

            }

            public class Components : ILib
            {

                public static Components Default { get; } = new Components();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.ComponentModel.TypeConverter.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.ComponentModel.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ObjectModel.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Buffers.Default, System.Threading.Default, System.Linq.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Components", "Microsoft.AspNetCore.Components.Routing", "Microsoft.AspNetCore.Components.RenderTree", "Microsoft.AspNetCore.Components.Rendering", "Microsoft.AspNetCore.Components.Reflection", "Microsoft.AspNetCore.Components.CompilerServices", "Microsoft.Extensions.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.Components";
                public static string AssemblyFile = "Microsoft.AspNetCore.Components.dll";


                public class Authorization : ILib
                {

                    public static Authorization Default { get; } = new Authorization();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Metadata.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Components.Default, Microsoft.AspNetCore.Authorization.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Linq.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Components.Authorization", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Components.Authorization";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Components.Authorization.dll";


                }

                public class Endpoints : ILib
                {

                    public static Endpoints Default { get; } = new Endpoints();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Loader.Default, System.Collections.Concurrent.Default, System.Collections.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Components.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.StaticFiles.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.Routing.Default, System.Text.Json.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.Components.Web.Default, Microsoft.AspNetCore.DataProtection.Extensions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Html.Abstractions.Default, Microsoft.JSInterop.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Antiforgery.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Text.Encodings.Web.Default, Microsoft.AspNetCore.Components.Authorization.Default, System.Collections.Immutable.Default, System.Linq.Expressions.Default, System.Runtime.Serialization.Primitives.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.Extensions.Logging.Default, Microsoft.Net.Http.Headers.Default, System.Threading.Default, Microsoft.Extensions.FileProviders.Embedded.Default, System.Linq.Default, System.Security.Cryptography.Default, Microsoft.AspNetCore.Http.Default, System.Memory.Default, System.Runtime.InteropServices.Default, Microsoft.Extensions.Features.Default, Microsoft.AspNetCore.Diagnostics.Abstractions.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.StaticFiles", "Microsoft.AspNetCore.Http.HttpResults", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Components", "Microsoft.AspNetCore.Components.Forms", "Microsoft.AspNetCore.Components.Discovery", "Microsoft.AspNetCore.Components.Infrastructure", "Microsoft.AspNetCore.Components.Endpoints", "Microsoft.AspNetCore.Components.Endpoints.Rendering", "Microsoft.AspNetCore.Components.Endpoints.Forms", "Microsoft.AspNetCore.Components.Endpoints.FormMapping", "Microsoft.AspNetCore.Components.Endpoints.FormMapping.Metadata", "Microsoft.AspNetCore.Components.Endpoints.DependencyInjection", "Microsoft.AspNetCore.Components.Endpoints.Infrastructure", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Components.Endpoints";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Components.Endpoints.dll";


                }

                public class Forms : ILib
                {

                    public static Forms Default { get; } = new Forms();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Components.Default, System.Collections.Default, System.Linq.Expressions.Default, System.Diagnostics.Debug.Default, System.Collections.Concurrent.Default, System.ComponentModel.Annotations.Default, System.Threading.Default, System.Linq.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Components.Forms", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Components.Forms";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Components.Forms.dll";


                }

                public class Server : ILib
                {

                    public static Server Default { get; } = new Server();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Runtime.InteropServices.Default, System.Memory.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Buffers.Default, System.Threading.Tasks.Default, Microsoft.AspNetCore.StaticFiles.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.SignalR.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.AspNetCore.Http.Connections.Default, System.Collections.Concurrent.Default, System.Text.Json.Default, Microsoft.AspNetCore.Components.Default, Microsoft.AspNetCore.Components.Web.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.AspNetCore.Components.Authorization.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.SignalR.Core.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.FileProviders.Embedded.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Security.Claims.Default, System.ComponentModel.Default, Microsoft.JSInterop.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.Extensions.Caching.Abstractions.Default, Microsoft.Extensions.Caching.Memory.Default, Microsoft.AspNetCore.SignalR.Common.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Text.Encoding.Extensions.Default, System.Threading.Default, Microsoft.Net.Http.Headers.Default, System.Linq.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.Configuration.Binder.Default, System.Security.Principal.Default, Microsoft.AspNetCore.DataProtection.Extensions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.FileProviders.Composite.Default, System.Security.Cryptography.Primitives.Default, Microsoft.AspNetCore.WebUtilities.Default, Microsoft.AspNetCore.DataProtection.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Buffers", "MessagePack", "MessagePack.Internal", "Nerdbank.Streams", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.StaticFiles", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.SignalR.Internal", "Microsoft.AspNetCore.Components", "Microsoft.AspNetCore.Components.Web", "Microsoft.AspNetCore.Components.Server", "Microsoft.AspNetCore.Components.Server.Circuits", "Microsoft.AspNetCore.Components.Server.BlazorPack", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Components.Server";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Components.Server.dll";


                }

                public class Web : ILib
                {

                    public static Web Default { get; } = new Web();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Components.Default, Microsoft.AspNetCore.Components.Forms.Default, System.Linq.Expressions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Runtime.Extensions.Default, System.Linq.Default, System.Collections.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Components", "Microsoft.AspNetCore.Components.Web", "Microsoft.AspNetCore.Components.RenderTree", "Microsoft.AspNetCore.Components.Routing", "Microsoft.AspNetCore.Components.Forms", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Components.Web";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Components.Web.dll";


                }

            }

            public class Connections
            {

                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Default, System.Net.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, System.IO.Pipelines.Default, System.Threading.Tasks.Default, System.Security.Claims.Default, System.Threading.ThreadPool.Default, System.Memory.Default, System.Linq.Expressions.Default, System.Collections.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Connections", "Microsoft.AspNetCore.Connections.Features", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Connections.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Connections.Abstractions.dll";


                }

            }

            public class CookiePolicy : ILib
            {

                public static CookiePolicy Default { get; } = new CookiePolicy();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.CookiePolicy", };

                public static string AssemblyName = "Microsoft.AspNetCore.CookiePolicy";
                public static string AssemblyFile = "Microsoft.AspNetCore.CookiePolicy.dll";


            }

            public class Cors : ILib
            {

                public static Cors Default { get; } = new Cors();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, System.Collections.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Cors", "Microsoft.AspNetCore.Cors.Infrastructure", };

                public static string AssemblyName = "Microsoft.AspNetCore.Cors";
                public static string AssemblyFile = "Microsoft.AspNetCore.Cors.dll";


            }

            public class Cryptography
            {

                public class Internal : ILib
                {

                    public static Internal Default { get; } = new Internal();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Cryptography", "Microsoft.AspNetCore.Cryptography.Internal", "Microsoft.AspNetCore.Cryptography.SafeHandles", "Microsoft.AspNetCore.Cryptography.Cng", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Cryptography.Internal";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Cryptography.Internal.dll";


                }

                public class KeyDerivation : ILib
                {

                    public static KeyDerivation Default { get; } = new KeyDerivation();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.AspNetCore.Cryptography.Internal.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Cryptography.KeyDerivation", "Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Cryptography.KeyDerivation";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Cryptography.KeyDerivation.dll";


                }

            }

            public class DataProtection : ILib
            {

                public static DataProtection Default { get; } = new DataProtection();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.ComponentModel.Default, System.Xml.XDocument.Default, Microsoft.Win32.Registry.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.Extensions.Options.Default, System.IO.FileSystem.Default, System.Security.Cryptography.X509Certificates.Default, System.Collections.Default, Microsoft.AspNetCore.Cryptography.Internal.Default, System.Text.RegularExpressions.Default, System.Text.Encoding.Extensions.Default, System.Security.Cryptography.Xml.Default, System.Xml.ReaderWriter.Default, System.Security.Principal.Windows.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Primitives.Default, System.Diagnostics.Debug.Default, System.Threading.Tasks.Default, Microsoft.Extensions.Hosting.Abstractions.Default, System.Linq.Default, System.Collections.NonGeneric.Default, System.Security.Claims.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Threading.Default, System.Runtime.InteropServices.Default, System.Security.Cryptography.Csp.Default, };

                public string[] Namespaces { get; } = new string[] { "System", "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.DataProtection", "Microsoft.AspNetCore.DataProtection.XmlEncryption", "Microsoft.AspNetCore.DataProtection.SP800_108", "Microsoft.AspNetCore.DataProtection.Repositories", "Microsoft.AspNetCore.DataProtection.Managed", "Microsoft.AspNetCore.DataProtection.KeyManagement", "Microsoft.AspNetCore.DataProtection.KeyManagement.Internal", "Microsoft.AspNetCore.DataProtection.Internal", "Microsoft.AspNetCore.DataProtection.Cng", "Microsoft.AspNetCore.DataProtection.Cng.Internal", "Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption", "Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel", };

                public static string AssemblyName = "Microsoft.AspNetCore.DataProtection";
                public static string AssemblyFile = "Microsoft.AspNetCore.DataProtection.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Default, System.Text.Encoding.Extensions.Default, System.Runtime.Extensions.Default, System.Memory.Default, System.Buffers.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.WebEncoders.Sources", "Microsoft.AspNetCore.DataProtection", "Microsoft.AspNetCore.DataProtection.Abstractions", "Microsoft.AspNetCore.DataProtection.Infrastructure", };

                    public static string AssemblyName = "Microsoft.AspNetCore.DataProtection.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.DataProtection.Abstractions.dll";


                }

                public class Extensions : ILib
                {

                    public static Extensions Default { get; } = new Extensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, System.IO.FileSystem.Default, Microsoft.AspNetCore.DataProtection.Default, System.Security.Cryptography.X509Certificates.Default, System.Text.Encoding.Extensions.Default, Microsoft.Extensions.DependencyInjection.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.DataProtection", "Microsoft.AspNetCore.DataProtection.Extensions", };

                    public static string AssemblyName = "Microsoft.AspNetCore.DataProtection.Extensions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.DataProtection.Extensions.dll";


                }

            }

            public class Diagnostics : ILib
            {

                public static Diagnostics Default { get; } = new Diagnostics();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, System.Collections.Default, System.Threading.Tasks.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.AspNetCore.Diagnostics.Abstractions.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.AspNetCore.Http.Features.Default, System.Reflection.Metadata.Default, System.Collections.Immutable.Default, System.Diagnostics.StackTrace.Default, System.Linq.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.WebUtilities.Default, System.IO.FileSystem.Default, System.Text.Encoding.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.DiagnosticsViewPage.Views", "Microsoft.AspNetCore.Diagnostics", "Microsoft.AspNetCore.Diagnostics.Views", "Microsoft.AspNetCore.Diagnostics.RazorViews", "Microsoft.AspNetCore.Builder", "Microsoft.Extensions.StackTrace.Sources", "Microsoft.Extensions.RazorViews", "Microsoft.Extensions.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.Diagnostics";
                public static string AssemblyFile = "Microsoft.AspNetCore.Diagnostics.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Diagnostics", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Diagnostics.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Diagnostics.Abstractions.dll";


                }

                public class HealthChecks : ILib
                {

                    public static HealthChecks Default { get; } = new HealthChecks();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Diagnostics.HealthChecks.Default, Microsoft.Extensions.Options.Default, System.Threading.Tasks.Default, Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.Default, System.Collections.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Routing.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Diagnostics.HealthChecks", "Microsoft.AspNetCore.Builder", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Diagnostics.HealthChecks";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Diagnostics.HealthChecks.dll";


                }

            }

            public class HostFiltering : ILib
            {

                public static HostFiltering Default { get; } = new HostFiltering();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Net.Http.Headers.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.HostFiltering", "Microsoft.AspNetCore.Builder", };

                public static string AssemblyName = "Microsoft.AspNetCore.HostFiltering";
                public static string AssemblyFile = "Microsoft.AspNetCore.HostFiltering.dll";


            }

            public class Hosting : ILib
            {

                public static Hosting Default { get; } = new Hosting();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Threading.Tasks.Default, System.Runtime.InteropServices.RuntimeInformation.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Diagnostics.Tracing.Default, System.Threading.Default, System.Console.Default, System.Linq.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.FileProviders.Physical.Default, System.Xml.XDocument.Default, System.Runtime.Extensions.Default, System.Reflection.Metadata.Default, System.Collections.Immutable.Default, System.Diagnostics.StackTrace.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.Configuration.EnvironmentVariables.Default, System.Web.HttpUtility.Default, System.IO.FileSystem.Default, Microsoft.Extensions.Configuration.FileExtensions.Default, Microsoft.Extensions.FileProviders.Composite.Default, Microsoft.Extensions.Configuration.Binder.Default, System.Text.Encoding.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Hosting.Views", "Microsoft.AspNetCore.Hosting.StaticWebAssets", "Microsoft.AspNetCore.Hosting.Server.Features", "Microsoft.AspNetCore.Hosting.Builder", "Microsoft.Extensions.StackTrace.Sources", "Microsoft.Extensions.RazorViews", "Microsoft.Extensions.Hosting", "Microsoft.Extensions.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.Hosting";
                public static string AssemblyFile = "Microsoft.AspNetCore.Hosting.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Hosting.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Hosting", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Hosting.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Hosting.Abstractions.dll";


                }

                public class Server
                {

                    public class Abstractions : ILib
                    {

                        public static Abstractions Default { get; } = new Abstractions();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Features.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Hosting.Server", "Microsoft.AspNetCore.Hosting.Server.Abstractions", "Microsoft.AspNetCore.Hosting.Server.Features", };

                        public static string AssemblyName = "Microsoft.AspNetCore.Hosting.Server.Abstractions";
                        public static string AssemblyFile = "Microsoft.AspNetCore.Hosting.Server.Abstractions.dll";


                    }

                }

            }

            public class Html
            {

                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, System.Diagnostics.Debug.Default, System.Collections.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Html", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Html.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Html.Abstractions.dll";


                }

            }

            public class Http : ILib
            {

                public static Http Default { get; } = new Http();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.IO.Pipelines.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Claims.Default, Microsoft.Extensions.Primitives.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Threading.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Net.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, System.Net.WebSockets.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.ObjectPool.Default, System.IO.FileSystem.Default, System.Linq.Default, System.Security.Principal.Default, System.Memory.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Http.Features", "Microsoft.AspNetCore.Http.Features.Authentication", };

                public static string AssemblyName = "Microsoft.AspNetCore.Http";
                public static string AssemblyFile = "Microsoft.AspNetCore.Http.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.ComponentModel.Default, System.Linq.Expressions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Http.Features.Default, System.Net.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, Microsoft.Extensions.Primitives.Default, System.IO.Pipelines.Default, System.Security.Claims.Default, System.ObjectModel.Default, System.ComponentModel.TypeConverter.Default, System.Net.WebSockets.Default, System.Runtime.Extensions.Default, System.Memory.Default, Microsoft.Net.Http.Headers.Default, System.Linq.Default, System.Text.Encodings.Web.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Routing", "Microsoft.AspNetCore.Cors.Infrastructure", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Builder.Extensions", "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Http.Abstractions", "Microsoft.AspNetCore.Http.Features", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Http.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Http.Abstractions.dll";


                }

                public class Connections : ILib
                {

                    public static Connections Default { get; } = new Connections();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Net.WebSockets.Default, System.Memory.Default, System.Diagnostics.Debug.Default, System.IO.Pipelines.Default, System.Threading.Tasks.Default, System.Collections.Default, System.Threading.Timer.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.AspNetCore.Metadata.Default, Microsoft.AspNetCore.Http.Connections.Common.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.Primitives.Default, System.ComponentModel.Default, System.Security.Cryptography.Csp.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.Hosting.Abstractions.Default, System.Diagnostics.Tracing.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Buffers.Default, System.Security.Principal.Default, System.Security.Principal.Windows.Default, System.Net.Primitives.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.AspNetCore.WebSockets.Default, Microsoft.AspNetCore.Authorization.Policy.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.Net.Http.Headers.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Net.WebSockets", "System.IO", "System.IO.Pipelines", "System.Threading.Tasks", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Http.Connections", "Microsoft.AspNetCore.Http.Connections.Internal", "Microsoft.AspNetCore.Http.Connections.Internal.Transports", "Microsoft.AspNetCore.Http.Connections.Features", "Microsoft.AspNetCore.Builder", "Microsoft.Extensions.WebEncoders.Sources", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Http.Connections";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Http.Connections.dll";


                    public class Common : ILib
                    {

                        public static Common Default { get; } = new Common();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Text.Encoding.Extensions.Default, System.Memory.Default, System.Text.Json.Default, System.Collections.Default, System.Text.Encodings.Web.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Http.Connections", };

                        public static string AssemblyName = "Microsoft.AspNetCore.Http.Connections.Common";
                        public static string AssemblyFile = "Microsoft.AspNetCore.Http.Connections.Common.dll";


                    }

                }

                public class Extensions : ILib
                {

                    public static Extensions Default { get; } = new Extensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Linq.Default, System.Collections.Default, System.Text.Encodings.Web.Default, System.Buffers.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Http.Headers", "Microsoft.AspNetCore.Http.Extensions", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Http.Extensions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Http.Extensions.dll";


                }

                public class Features : ILib
                {

                    public static Features Default { get; } = new Features();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Primitives.Default, System.Diagnostics.Debug.Default, System.Net.Primitives.Default, System.IO.Pipelines.Default, System.Net.WebSockets.Default, System.ComponentModel.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Claims.Default, System.Collections.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Http.Features", "Microsoft.AspNetCore.Http.Features.Authentication", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Http.Features";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Http.Features.dll";


                }

                public class Results : ILib
                {

                    public static Results Default { get; } = new Results();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.Net.Http.Headers.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Security.Claims.Default, System.Text.Json.Default, System.Collections.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Memory.Default, System.Linq.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Http", "Microsoft.AspNetCore.Http.Extensions", "Microsoft.AspNetCore.Http.Result", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Http.Results";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Http.Results.dll";


                }

            }

            public class HttpLogging : ILib
            {

                public static HttpLogging Default { get; } = new HttpLogging();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Memory.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Collections.Concurrent.Default, System.Collections.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, System.IO.Pipelines.Default, System.Threading.Default, System.Linq.Default, Microsoft.Extensions.Features.Default, System.Net.Primitives.Default, System.Security.Claims.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Text", "System.IO.Pipelines", "System.Threading.Tasks", "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.HttpLogging", };

                public static string AssemblyName = "Microsoft.AspNetCore.HttpLogging";
                public static string AssemblyFile = "Microsoft.AspNetCore.HttpLogging.dll";


            }

            public class HttpOverrides : ILib
            {

                public static HttpOverrides Default { get; } = new HttpOverrides();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Collections.Default, System.Net.Primitives.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Linq.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.HttpOverrides", "Microsoft.AspNetCore.Builder", };

                public static string AssemblyName = "Microsoft.AspNetCore.HttpOverrides";
                public static string AssemblyFile = "Microsoft.AspNetCore.HttpOverrides.dll";


            }

            public class HttpsPolicy : ILib
            {

                public static HttpsPolicy Default { get; } = new HttpsPolicy();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Extensions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Net.Http.Headers.Default, System.Collections.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.Extensions.Configuration.Binder.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.HttpsPolicy", "Microsoft.AspNetCore.Builder", };

                public static string AssemblyName = "Microsoft.AspNetCore.HttpsPolicy";
                public static string AssemblyFile = "Microsoft.AspNetCore.HttpsPolicy.dll";


            }

            public class Identity : ILib
            {

                public static Identity Default { get; } = new Identity();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Identity.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Authentication.Cookies.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Options.Default, System.ComponentModel.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, System.Threading.Tasks.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Authentication.Default, System.Collections.Default, Microsoft.AspNetCore.Http.Default, System.Text.Encoding.Extensions.Default, System.Linq.Default, System.Security.Principal.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Identity", };

                public static string AssemblyName = "Microsoft.AspNetCore.Identity";
                public static string AssemblyFile = "Microsoft.AspNetCore.Identity.dll";


            }

            public class Localization : ILib
            {

                public static Localization Default { get; } = new Localization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Http.Extensions.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Features.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Localization", };

                public static string AssemblyName = "Microsoft.AspNetCore.Localization";
                public static string AssemblyFile = "Microsoft.AspNetCore.Localization.dll";


                public class Routing : ILib
                {

                    public static Routing Default { get; } = new Routing();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Localization.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, Microsoft.Extensions.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Localization.Routing", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Localization.Routing";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Localization.Routing.dll";


                }

            }

            public class Metadata : ILib
            {

                public static Metadata Default { get; } = new Metadata();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Authorization", };

                public static string AssemblyName = "Microsoft.AspNetCore.Metadata";
                public static string AssemblyFile = "Microsoft.AspNetCore.Metadata.dll";


            }

            public class Mvc : ILib
            {

                public static Mvc Default { get; } = new Mvc();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Mvc.RazorPages.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Mvc.ApiExplorer.Default, Microsoft.AspNetCore.Mvc.Cors.Default, Microsoft.AspNetCore.Mvc.DataAnnotations.Default, Microsoft.AspNetCore.Mvc.ViewFeatures.Default, Microsoft.AspNetCore.Mvc.Razor.Default, Microsoft.AspNetCore.Mvc.TagHelpers.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc", };

                public static string AssemblyName = "Microsoft.AspNetCore.Mvc";
                public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, System.Diagnostics.Debug.Default, System.ComponentModel.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, System.Runtime.Extensions.Default, System.Linq.Default, System.ComponentModel.TypeConverter.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Mvc", "Microsoft.AspNetCore.Mvc.Routing", "Microsoft.AspNetCore.Mvc.ModelBinding", "Microsoft.AspNetCore.Mvc.ModelBinding.Validation", "Microsoft.AspNetCore.Mvc.ModelBinding.Metadata", "Microsoft.AspNetCore.Mvc.Formatters", "Microsoft.AspNetCore.Mvc.Filters", "Microsoft.AspNetCore.Mvc.Authorization", "Microsoft.AspNetCore.Mvc.ApiExplorer", "Microsoft.AspNetCore.Mvc.ActionConstraints", "Microsoft.AspNetCore.Mvc.Abstractions", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Abstractions.dll";


                }

                public class ApiExplorer : ILib
                {

                    public static ApiExplorer Default { get; } = new ApiExplorer();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, System.Linq.Default, Microsoft.AspNetCore.Routing.Default, System.Collections.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc.ApiExplorer", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.ApiExplorer";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.ApiExplorer.dll";


                }

                public class Core : ILib
                {

                    public static Core Default { get; } = new Core();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Text.Json.Default, System.Text.Encodings.Web.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Collections.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Threading.Tasks.Default, System.Security.Claims.Default, System.Linq.Expressions.Default, Microsoft.Extensions.Options.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Collections.Concurrent.Default, System.ComponentModel.TypeConverter.Default, System.ObjectModel.Default, System.Threading.Default, System.Buffers.Default, System.IO.FileSystem.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.AspNetCore.Authorization.Default, Microsoft.AspNetCore.Metadata.Default, Microsoft.AspNetCore.Authorization.Policy.Default, Microsoft.Extensions.DependencyInjection.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Text.Encoding.Extensions.Default, Microsoft.AspNetCore.ResponseCaching.Abstractions.Default, Microsoft.AspNetCore.Authentication.Core.Default, Microsoft.Extensions.Hosting.Abstractions.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Text.Json", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Routing", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Mvc", "Microsoft.AspNetCore.Mvc.ViewFeatures", "Microsoft.AspNetCore.Mvc.Routing", "Microsoft.AspNetCore.Mvc.ModelBinding", "Microsoft.AspNetCore.Mvc.ModelBinding.Validation", "Microsoft.AspNetCore.Mvc.ModelBinding.Metadata", "Microsoft.AspNetCore.Mvc.ModelBinding.Binders", "Microsoft.AspNetCore.Mvc.Core", "Microsoft.AspNetCore.Mvc.Core.Infrastructure", "Microsoft.AspNetCore.Mvc.Infrastructure", "Microsoft.AspNetCore.Mvc.Formatters", "Microsoft.AspNetCore.Mvc.Formatters.Json", "Microsoft.AspNetCore.Mvc.Filters", "Microsoft.AspNetCore.Mvc.Diagnostics", "Microsoft.AspNetCore.Mvc.Controllers", "Microsoft.AspNetCore.Mvc.Authorization", "Microsoft.AspNetCore.Mvc.ApplicationParts", "Microsoft.AspNetCore.Mvc.ApplicationModels", "Microsoft.AspNetCore.Mvc.ApiExplorer", "Microsoft.AspNetCore.Mvc.ActionConstraints", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Core";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Core.dll";


                }

                public class Cors : ILib
                {

                    public static Cors Default { get; } = new Cors();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.AspNetCore.Cors.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Tasks.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Diagnostics.Debug.Default, System.ComponentModel.Default, System.Linq.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc.Cors", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Cors";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Cors.dll";


                }

                public class DataAnnotations : ILib
                {

                    public static DataAnnotations Default { get; } = new DataAnnotations();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Localization.Abstractions.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, System.ComponentModel.Annotations.Default, System.Collections.Default, System.ComponentModel.Primitives.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Localization.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.ComponentModel.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc", "Microsoft.AspNetCore.Mvc.DataAnnotations", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.DataAnnotations";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.DataAnnotations.dll";


                }

                public class Formatters
                {

                    public class Json : ILib
                    {

                        public static Json Default { get; } = new Json();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, };

                        public string[] Namespaces { get; } = new string[] { };

                        public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Formatters.Json";
                        public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Formatters.Json.dll";


                    }

                    public class Xml : ILib
                    {

                        public static Xml Default { get; } = new Xml();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Runtime.Serialization.Primitives.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, System.Collections.Concurrent.Default, System.Runtime.Serialization.Xml.Default, System.Threading.Tasks.Default, System.Xml.ReaderWriter.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Diagnostics.Debug.Default, System.Runtime.Extensions.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Xml.XmlSerializer.Default, System.Collections.Default, Microsoft.Net.Http.Headers.Default, System.Linq.Default, System.ComponentModel.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc.ModelBinding.Metadata", "Microsoft.AspNetCore.Mvc.Formatters", "Microsoft.AspNetCore.Mvc.Formatters.Xml", };

                        public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Formatters.Xml";
                        public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Formatters.Xml.dll";


                    }

                }

                public class Localization : ILib
                {

                    public static Localization Default { get; } = new Localization();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Localization.Abstractions.Default, Microsoft.AspNetCore.Html.Abstractions.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Mvc.Razor.Default, Microsoft.Extensions.Localization.Default, Microsoft.AspNetCore.Mvc.ViewFeatures.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.AspNetCore.Mvc.DataAnnotations.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Hosting.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Mvc.Localization", "Microsoft.Extensions.DependencyInjection", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Localization";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Localization.dll";


                }

                public class Razor : ILib
                {

                    public static Razor Default { get; } = new Razor();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.AspNetCore.Razor.Default, Microsoft.AspNetCore.Mvc.ViewFeatures.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Html.Abstractions.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, System.Diagnostics.Debug.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Linq.Expressions.Default, System.Security.Claims.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Razor.Runtime.Default, Microsoft.Extensions.Caching.Abstractions.Default, Microsoft.Extensions.Primitives.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, System.Linq.Default, Microsoft.Extensions.Caching.Memory.Default, Microsoft.AspNetCore.Antiforgery.Default, System.Security.Cryptography.Csp.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Security.Cryptography.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc.Diagnostics", "Microsoft.AspNetCore.Mvc.Razor", "Microsoft.AspNetCore.Mvc.Razor.TagHelpers", "Microsoft.AspNetCore.Mvc.Razor.Internal", "Microsoft.AspNetCore.Mvc.Razor.Infrastructure", "Microsoft.AspNetCore.Mvc.Razor.Compilation", "Microsoft.AspNetCore.Mvc.ApplicationParts", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.Razor";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.Razor.dll";


                }

                public class RazorPages : ILib
                {

                    public static RazorPages Default { get; } = new RazorPages();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Mvc.Razor.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Default, Microsoft.AspNetCore.Routing.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Mvc.ViewFeatures.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.Net.Http.Headers.Default, System.Security.Claims.Default, System.Linq.Expressions.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Html.Abstractions.Default, Microsoft.AspNetCore.Authorization.Default, Microsoft.AspNetCore.Metadata.Default, Microsoft.AspNetCore.Razor.Runtime.Default, System.Threading.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Features.Default, System.Runtime.Extensions.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Mvc.Filters", "Microsoft.AspNetCore.Mvc.Diagnostics", "Microsoft.AspNetCore.Mvc.RazorPages", "Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure", "Microsoft.AspNetCore.Mvc.ApplicationModels", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.RazorPages";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.RazorPages.dll";


                }

                public class TagHelpers : ILib
                {

                    public static TagHelpers Default { get; } = new TagHelpers();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Razor.Default, Microsoft.AspNetCore.Mvc.ViewFeatures.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Caching.Abstractions.Default, System.Text.Encodings.Web.Default, System.Threading.Tasks.Default, Microsoft.AspNetCore.Html.Abstractions.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.FileSystemGlobbing.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, System.Collections.Default, Microsoft.AspNetCore.Mvc.Razor.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.Extensions.Caching.Memory.Default, Microsoft.Extensions.Hosting.Abstractions.Default, System.ComponentModel.Default, System.Linq.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, System.Security.Claims.Default, System.Security.Principal.Default, System.Security.Cryptography.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Mvc.Rendering", "Microsoft.AspNetCore.Mvc.TagHelpers", "Microsoft.AspNetCore.Mvc.TagHelpers.Cache", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.TagHelpers";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.TagHelpers.dll";


                }

                public class ViewFeatures : ILib
                {

                    public static ViewFeatures Default { get; } = new ViewFeatures();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.AspNetCore.Mvc.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Mvc.DataAnnotations.Default, Microsoft.Extensions.Localization.Abstractions.Default, System.Text.Json.Default, Microsoft.AspNetCore.Components.Default, System.Collections.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Mvc.Abstractions.Default, System.Linq.Expressions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Html.Abstractions.Default, System.ComponentModel.Annotations.Default, Microsoft.AspNetCore.Diagnostics.Abstractions.Default, System.Security.Principal.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, System.Collections.Concurrent.Default, System.Text.Encodings.Web.Default, System.Diagnostics.DiagnosticSource.Default, System.Linq.Default, Microsoft.AspNetCore.Antiforgery.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Components.Authorization.Default, Microsoft.JSInterop.Default, Microsoft.AspNetCore.DataProtection.Extensions.Default, System.Threading.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Memory.Default, System.Buffers.Default, Microsoft.AspNetCore.DataProtection.Default, Microsoft.Extensions.WebEncoders.Default, Microsoft.CSharp.Default, System.Threading.Thread.Default, Microsoft.AspNetCore.Http.Extensions.Default, System.Security.Cryptography.Algorithms.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Components", "Microsoft.AspNetCore.Components.Rendering", "Microsoft.AspNetCore.Mvc", "Microsoft.AspNetCore.Mvc.ViewEngines", "Microsoft.AspNetCore.Mvc.ViewComponents", "Microsoft.AspNetCore.Mvc.Rendering", "Microsoft.AspNetCore.Mvc.ModelBinding", "Microsoft.AspNetCore.Mvc.Diagnostics", "Microsoft.AspNetCore.Mvc.ViewFeatures", "Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure", "Microsoft.AspNetCore.Mvc.ViewFeatures.Filters", "Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Mvc.ViewFeatures";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Mvc.ViewFeatures.dll";


                }

            }

            public class OutputCaching : ILib
            {

                public static OutputCaching Default { get; } = new OutputCaching();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Collections.Default, System.IO.Pipelines.Default, Microsoft.AspNetCore.Http.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.ObjectPool.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Caching.Memory.Default, Microsoft.Extensions.Caching.Abstractions.Default, System.Linq.Default, Microsoft.Extensions.Features.Default, System.Security.Claims.Default, System.Threading.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Threading.Tasks", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.OutputCaching", "Microsoft.AspNetCore.OutputCaching.Serialization", "Microsoft.AspNetCore.OutputCaching.Policies", "Microsoft.AspNetCore.OutputCaching.Memory", };

                public static string AssemblyName = "Microsoft.AspNetCore.OutputCaching";
                public static string AssemblyFile = "Microsoft.AspNetCore.OutputCaching.dll";


            }

            public class RateLimiting : ILib
            {

                public static RateLimiting Default { get; } = new RateLimiting();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Threading.RateLimiting.Default, System.Collections.Default, System.ComponentModel.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Extensions.Internal", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.RateLimiting", };

                public static string AssemblyName = "Microsoft.AspNetCore.RateLimiting";
                public static string AssemblyFile = "Microsoft.AspNetCore.RateLimiting.dll";


            }

            public class Razor : ILib
            {

                public static Razor Default { get; } = new Razor();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Collections.Default, Microsoft.AspNetCore.Html.Abstractions.Default, System.Text.Encodings.Web.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Razor.TagHelpers", "Microsoft.Extensions.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.Razor";
                public static string AssemblyFile = "Microsoft.AspNetCore.Razor.dll";


                public class Runtime : ILib
                {

                    public static Runtime Default { get; } = new Runtime();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Default, Microsoft.AspNetCore.Razor.Default, System.Text.Encodings.Web.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Linq.Default, Microsoft.AspNetCore.Html.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.AspNetCore.Razor.Runtime", "Microsoft.AspNetCore.Razor.Runtime.TagHelpers", "Microsoft.AspNetCore.Razor.Hosting", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Razor.Runtime";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Razor.Runtime.dll";


                }

            }

            public class RequestDecompression : ILib
            {

                public static RequestDecompression Default { get; } = new RequestDecompression();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, System.IO.Compression.Brotli.Default, System.IO.Compression.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Features.Default, System.Collections.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.RequestDecompression", };

                public static string AssemblyName = "Microsoft.AspNetCore.RequestDecompression";
                public static string AssemblyFile = "Microsoft.AspNetCore.RequestDecompression.dll";


            }

            public class ResponseCaching : ILib
            {

                public static ResponseCaching Default { get; } = new ResponseCaching();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Net.Http.Headers.Default, System.Collections.Default, Microsoft.Extensions.Caching.Abstractions.Default, Microsoft.AspNetCore.ResponseCaching.Abstractions.Default, Microsoft.Extensions.ObjectPool.Default, Microsoft.Extensions.Options.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Threading.Default, Microsoft.AspNetCore.Http.Default, System.Linq.Default, Microsoft.Extensions.Caching.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.ResponseCaching", };

                public static string AssemblyName = "Microsoft.AspNetCore.ResponseCaching";
                public static string AssemblyFile = "Microsoft.AspNetCore.ResponseCaching.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.ResponseCaching", };

                    public static string AssemblyName = "Microsoft.AspNetCore.ResponseCaching.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.ResponseCaching.Abstractions.dll";


                }

            }

            public class ResponseCompression : ILib
            {

                public static ResponseCompression Default { get; } = new ResponseCompression();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, System.IO.Compression.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Features.Default, System.IO.Pipelines.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Net.Http.Headers.Default, System.IO.Compression.Brotli.Default, System.Memory.Default, Microsoft.AspNetCore.Http.Default, System.Linq.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.ResponseCompression", };

                public static string AssemblyName = "Microsoft.AspNetCore.ResponseCompression";
                public static string AssemblyFile = "Microsoft.AspNetCore.ResponseCompression.dll";


            }

            public class Rewrite : ILib
            {

                public static Rewrite Default { get; } = new Rewrite();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Runtime.Extensions.Default, System.Collections.Default, System.Text.RegularExpressions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Http.Features.Default, System.Xml.XDocument.Default, System.Xml.ReaderWriter.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Extensions.Default, System.Net.Primitives.Default, System.Text.Encodings.Web.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Rewrite", "Microsoft.AspNetCore.Rewrite.UrlMatches", "Microsoft.AspNetCore.Rewrite.UrlActions", "Microsoft.AspNetCore.Rewrite.PatternSegments", "Microsoft.AspNetCore.Rewrite.IISUrlRewrite", "Microsoft.AspNetCore.Rewrite.Logging", "Microsoft.AspNetCore.Rewrite.ApacheModRewrite", };

                public static string AssemblyName = "Microsoft.AspNetCore.Rewrite";
                public static string AssemblyFile = "Microsoft.AspNetCore.Rewrite.dll";


            }

            public class Routing : ILib
            {

                public static Routing Default { get; } = new Routing();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Routing.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Tasks.Default, Microsoft.Extensions.Primitives.Default, System.ObjectModel.Default, System.Collections.Default, System.Collections.Concurrent.Default, System.Linq.Default, System.Diagnostics.DiagnosticSource.Default, System.Threading.Default, Microsoft.Extensions.ObjectPool.Default, System.Text.Encodings.Web.Default, Microsoft.AspNetCore.Http.Features.Default, System.Reflection.Emit.ILGeneration.Default, System.Text.RegularExpressions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.Metadata.Default, System.Memory.Default, System.Runtime.CompilerServices.Unsafe.Default, Microsoft.Net.Http.Headers.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Routing", "Microsoft.AspNetCore.Routing.Tree", "Microsoft.AspNetCore.Routing.Template", "Microsoft.AspNetCore.Routing.Patterns", "Microsoft.AspNetCore.Routing.Matching", "Microsoft.AspNetCore.Routing.Logging", "Microsoft.AspNetCore.Routing.Internal", "Microsoft.AspNetCore.Routing.DecisionTree", "Microsoft.AspNetCore.Routing.Constraints", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.Routing";
                public static string AssemblyFile = "Microsoft.AspNetCore.Routing.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.Collections.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Runtime.Extensions.Default, System.Linq.Default, Microsoft.AspNetCore.Http.Features.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.AspNetCore.Routing", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Routing.Abstractions";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Routing.Abstractions.dll";


                }

            }

            public class Server
            {

                public class HttpSys : ILib
                {

                    public static HttpSys Default { get; } = new HttpSys();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Collections.Default, System.Threading.Overlapped.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, System.Diagnostics.Debug.Default, System.Security.Principal.Windows.Default, System.Security.Cryptography.X509Certificates.Default, System.Diagnostics.Tools.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Numerics.Vectors.Default, System.Threading.Tasks.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Security.Principal.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.IO.Pipelines.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Win32.Primitives.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Hosting.Default, Microsoft.Extensions.Options.Default, System.Collections.Concurrent.Default, Microsoft.Win32.Registry.Default, System.Runtime.InteropServices.Default, System.Threading.Default, System.Text.Encoding.Extensions.Default, System.Collections.Immutable.Default, System.ObjectModel.Default, System.Memory.Default, System.Linq.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Intrinsics.Default, Microsoft.AspNetCore.Authentication.Core.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.HttpSys.Internal", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure", "Microsoft.AspNetCore.Server.HttpSys", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Server.HttpSys";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Server.HttpSys.dll";


                }

                public class IIS : ILib
                {

                    public static IIS Default { get; } = new IIS();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Memory.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Diagnostics.StackTrace.Default, System.Collections.Concurrent.Default, System.Net.Primitives.Default, System.Threading.Overlapped.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Principal.Windows.Default, System.Security.Cryptography.X509Certificates.Default, System.Diagnostics.Tools.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Numerics.Vectors.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, System.IO.Pipelines.Default, System.Security.Claims.Default, System.Threading.ThreadPool.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Reflection.Metadata.Default, System.Collections.Immutable.Default, System.Threading.Default, System.Linq.Default, System.Runtime.InteropServices.Default, Microsoft.Net.Http.Headers.Default, System.Text.Encoding.Extensions.Default, System.ObjectModel.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Intrinsics.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.AspNetCore.WebUtilities.Default, System.Security.Principal.Default, Microsoft.AspNetCore.Http.Default, System.IO.FileSystem.Default, Microsoft.Extensions.FileProviders.Physical.Default, Microsoft.AspNetCore.Authentication.Core.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Buffers", "Microsoft.AspNetCore.HttpSys.Internal", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Hosting.Views", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure", "Microsoft.AspNetCore.Server.IIS", "Microsoft.AspNetCore.Server.IIS.Core", "Microsoft.AspNetCore.Server.IIS.Core.IO", "Microsoft.Extensions.RazorViews", "Microsoft.Extensions.StackTrace.Sources", "Microsoft.Extensions.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Server.IIS";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Server.IIS.dll";


                }

                public class IISIntegration : ILib
                {

                    public static IISIntegration Default { get; } = new IISIntegration();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.HttpOverrides.Default, Microsoft.AspNetCore.Authentication.Abstractions.Default, System.Security.Principal.Windows.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Authentication.Core.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Server.IISIntegration", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Server.IISIntegration";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Server.IISIntegration.dll";


                }

                public class Kestrel : ILib
                {

                    public static Kestrel Default { get; } = new Kestrel();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.AspNetCore.Server.Kestrel.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Hosting", };

                    public static string AssemblyName = "Microsoft.AspNetCore.Server.Kestrel";
                    public static string AssemblyFile = "Microsoft.AspNetCore.Server.Kestrel.dll";


                    public class Core : ILib
                    {

                        public static Core Default { get; } = new Core();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Memory.Default, System.IO.Pipelines.Default, System.Security.Cryptography.X509Certificates.Default, System.Collections.Default, System.Security.Cryptography.Algorithms.Default, System.Diagnostics.Process.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.Cng.Default, System.Text.RegularExpressions.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, System.Net.Primitives.Default, System.Security.Cryptography.Encoding.Default, System.Net.Security.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Hosting.Server.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.Extensions.Options.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Http.Default, System.Collections.Concurrent.Default, System.Threading.Timer.Default, System.Text.Encoding.Extensions.Default, System.Threading.ThreadPool.Default, System.Diagnostics.Tracing.Default, System.Numerics.Vectors.Default, Microsoft.AspNetCore.Http.Abstractions.Default, System.Buffers.Default, System.Linq.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Security.Cryptography.Primitives.Default, System.IO.FileSystem.Default, System.Collections.NonGeneric.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Configuration.Default, System.Net.Sockets.Default, Microsoft.Extensions.Configuration.Binder.Default, System.Threading.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Intrinsics.Default, Microsoft.Net.Http.Headers.Default, Microsoft.AspNetCore.WebUtilities.Default, };

                        public string[] Namespaces { get; } = new string[] { "System.Diagnostics", "System.IO.Pipelines", "System.Buffers", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Certificates.Generation", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel", "Microsoft.AspNetCore.Server.Kestrel.Https", "Microsoft.AspNetCore.Server.Kestrel.Https.Internal", "Microsoft.AspNetCore.Server.Kestrel.Core", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure.PipeWriterHelpers", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.FlowControl", "Microsoft.AspNetCore.Server.Kestrel.Core.Features", };

                        public static string AssemblyName = "Microsoft.AspNetCore.Server.Kestrel.Core";
                        public static string AssemblyFile = "Microsoft.AspNetCore.Server.Kestrel.Core.dll";


                    }

                    public class Transport
                    {

                        public class NamedPipes : ILib
                        {

                            public static NamedPipes Default { get; } = new NamedPipes();
                            public string Name => AssemblyName;
                            public string File => AssemblyFile;
                            public string Sdk { get; } = "Microsoft.AspNetCore.App";

                            public Version[] Versions { get; } = new Version[] { Libs.Version80, };

                            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.Pipelines.Default, System.Memory.Default, System.Collections.Default, System.Diagnostics.StackTrace.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.Extensions.Features.Default, System.Net.Primitives.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.IO.Pipes.AccessControl.Default, System.IO.Pipes.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.ObjectPool.Default, System.Threading.Channels.Default, Microsoft.Extensions.Options.Default, System.Runtime.InteropServices.Default, System.Threading.Default, System.Linq.Default, };

                            public string[] Namespaces { get; } = new string[] { "System.IO.Pipelines", "System.Buffers", "Microsoft.AspNetCore.Connections", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes", "Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.Internal", };

                            public static string AssemblyName = "Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes";
                            public static string AssemblyFile = "Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes.dll";


                        }

                        public class Quic : ILib
                        {

                            public static Quic Default { get; } = new Quic();
                            public string Name => AssemblyName;
                            public string File => AssemblyFile;
                            public string Sdk { get; } = "Microsoft.AspNetCore.App";

                            public Version[] Versions { get; } = new Version[] { Libs.Version60, Libs.Version70, Libs.Version80, };

                            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.Pipelines.Default, System.Memory.Default, System.Collections.Default, System.Diagnostics.StackTrace.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.Extensions.Features.Default, System.Net.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Intrinsics.Default, System.Numerics.Vectors.Default, Microsoft.Extensions.Options.Default, System.Net.Security.Default, System.Net.Quic.Default, System.Security.Cryptography.X509Certificates.Default, System.Threading.Default, System.Linq.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Text.Encoding.Extensions.Default, System.Threading.ThreadPool.Default, };

                            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Threading.Tasks", "System.IO.Pipelines", "System.Buffers", "Microsoft.AspNetCore.Connections", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel", "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure", "Microsoft.AspNetCore.Server.Kestrel.Transport.Quic", "Microsoft.AspNetCore.Server.Kestrel.Transport.Quic.Internal", };

                            public static string AssemblyName = "Microsoft.AspNetCore.Server.Kestrel.Transport.Quic";
                            public static string AssemblyFile = "Microsoft.AspNetCore.Server.Kestrel.Transport.Quic.dll";


                        }

                        public class Sockets : ILib
                        {

                            public static Sockets Default { get; } = new Sockets();
                            public string Name => AssemblyName;
                            public string File => AssemblyFile;
                            public string Sdk { get; } = "Microsoft.AspNetCore.App";

                            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.IO.Pipelines.Default, System.Memory.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Diagnostics.StackTrace.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Net.Primitives.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Net.Sockets.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.ThreadPool.Default, System.Threading.Default, System.Linq.Default, System.Threading.Thread.Default, System.Runtime.InteropServices.RuntimeInformation.Default, };

                            public string[] Namespaces { get; } = new string[] { "System.IO.Pipelines", "System.Buffers", "Microsoft.AspNetCore.Connections", "Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets", "Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Internal", };

                            public static string AssemblyName = "Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets";
                            public static string AssemblyFile = "Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.dll";


                        }

                    }

                }

            }

            public class Session : ILib
            {

                public static Session Default { get; } = new Session();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.DataProtection.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.Extensions.Caching.Abstractions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.DataProtection.Default, System.Collections.Default, System.Linq.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Logging", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.Session", };

                public static string AssemblyName = "Microsoft.AspNetCore.Session";
                public static string AssemblyFile = "Microsoft.AspNetCore.Session.dll";


            }

            public class SignalR : ILib
            {

                public static SignalR Default { get; } = new SignalR();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.AspNetCore.SignalR.Core.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.AspNetCore.WebSockets.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.AspNetCore.Http.Connections.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, Microsoft.AspNetCore.Authorization.Default, Microsoft.AspNetCore.SignalR.Common.Default, Microsoft.Extensions.Options.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Authorization.Policy.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Metadata.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.SignalR", };

                public static string AssemblyName = "Microsoft.AspNetCore.SignalR";
                public static string AssemblyFile = "Microsoft.AspNetCore.SignalR.dll";


                public class Common : ILib
                {

                    public static Common Default { get; } = new Common();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Text.Json.Default, System.Memory.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Text.Encoding.Extensions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, System.Buffers.Default, System.Text.Encodings.Web.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.SignalR", "Microsoft.AspNetCore.SignalR.Internal", "Microsoft.AspNetCore.SignalR.Protocol", };

                    public static string AssemblyName = "Microsoft.AspNetCore.SignalR.Common";
                    public static string AssemblyFile = "Microsoft.AspNetCore.SignalR.Common.dll";


                }

                public class Core : ILib
                {

                    public static Core Default { get; } = new Core();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Linq.Expressions.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Concurrent.Default, Microsoft.AspNetCore.SignalR.Common.Default, System.Security.Claims.Default, Microsoft.AspNetCore.Http.Features.Default, System.Threading.ThreadPool.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, System.Threading.Tasks.Default, System.Threading.Default, System.IO.Pipelines.Default, System.Diagnostics.Debug.Default, System.Memory.Default, Microsoft.Extensions.Options.Default, System.Threading.Channels.Default, System.ComponentModel.Default, Microsoft.AspNetCore.Metadata.Default, Microsoft.AspNetCore.Authorization.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.Runtime.Extensions.Default, System.Linq.Default, Microsoft.AspNetCore.Authorization.Policy.Default, Microsoft.AspNetCore.SignalR.Protocols.Json.Default, System.Reflection.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.SignalR", "Microsoft.AspNetCore.SignalR.Internal", };

                    public static string AssemblyName = "Microsoft.AspNetCore.SignalR.Core";
                    public static string AssemblyFile = "Microsoft.AspNetCore.SignalR.Core.dll";


                }

                public class Protocols
                {

                    public class Json : ILib
                    {

                        public static Json Default { get; } = new Json();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.AspNetCore.SignalR.Common.Default, System.Text.Json.Default, System.Memory.Default, System.Text.Encoding.Extensions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Connections.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Text.Encodings.Web.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.SignalR", "Microsoft.AspNetCore.SignalR.Internal", "Microsoft.AspNetCore.SignalR.Protocol", };

                        public static string AssemblyName = "Microsoft.AspNetCore.SignalR.Protocols.Json";
                        public static string AssemblyFile = "Microsoft.AspNetCore.SignalR.Protocols.Json.dll";


                    }

                }

            }

            public class StaticFiles : ILib
            {

                public static StaticFiles Default { get; } = new StaticFiles();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Net.Http.Headers.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Extensions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Primitives.Default, Microsoft.AspNetCore.Http.Features.Default, Microsoft.AspNetCore.Routing.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.AspNetCore.Hosting.Abstractions.Default, Microsoft.Extensions.Options.Default, System.Text.Encodings.Web.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.WebEncoders.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Collections.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Internal", "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.StaticFiles", "Microsoft.AspNetCore.StaticFiles.Infrastructure", };

                public static string AssemblyName = "Microsoft.AspNetCore.StaticFiles";
                public static string AssemblyFile = "Microsoft.AspNetCore.StaticFiles.dll";


            }

            public class WebSockets : ILib
            {

                public static WebSockets Default { get; } = new WebSockets();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.AspNetCore.Http.Abstractions.Default, Microsoft.AspNetCore.Http.Features.Default, System.Security.Cryptography.Algorithms.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Primitives.Default, System.Net.WebSockets.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Net.Http.Headers.Default, System.Security.Cryptography.Primitives.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Builder", "Microsoft.AspNetCore.WebSockets", };

                public static string AssemblyName = "Microsoft.AspNetCore.WebSockets";
                public static string AssemblyFile = "Microsoft.AspNetCore.WebSockets.dll";


            }

            public class WebUtilities : ILib
            {

                public static WebUtilities Default { get; } = new WebUtilities();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Buffers.Default, System.Threading.Tasks.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, Microsoft.Net.Http.Headers.Default, Microsoft.Extensions.Primitives.Default, System.IO.Pipelines.Default, System.Collections.Default, System.Memory.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.IO.FileSystem.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Text.Encodings.Web.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.WebEncoders.Sources", "Microsoft.AspNetCore.WebUtilities", "Microsoft.AspNetCore.Internal", };

                public static string AssemblyName = "Microsoft.AspNetCore.WebUtilities";
                public static string AssemblyFile = "Microsoft.AspNetCore.WebUtilities.dll";


            }

        }

        public class CSharp : ILib
        {

            public static CSharp Default { get; } = new CSharp();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { netstandard.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.Microsoft.CSharp", "System", "System.Numerics.Hashing", "Microsoft.CSharp.RuntimeBinder", "Microsoft.CSharp.RuntimeBinder.Syntax", "Microsoft.CSharp.RuntimeBinder.Semantics", "Microsoft.CSharp.RuntimeBinder.Errors", };

            public static string AssemblyName = "Microsoft.CSharp";
            public static string AssemblyFile = "Microsoft.CSharp.dll";


        }

        public class Extensions
        {

            public class Caching
            {

                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.Caching.Distributed", "Microsoft.Extensions.Caching.Memory", };

                    public static string AssemblyName = "Microsoft.Extensions.Caching.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Caching.Abstractions.dll";


                }

                public class Memory : ILib
                {

                    public static Memory Default { get; } = new Memory();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Caching.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Primitives.Default, System.Threading.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Threading.ThreadPool.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Caching.Distributed", "Microsoft.Extensions.Caching.Memory", };

                    public static string AssemblyName = "Microsoft.Extensions.Caching.Memory";
                    public static string AssemblyFile = "Microsoft.Extensions.Caching.Memory.dll";


                }

            }

            public class Configuration : ILib
            {

                public static Configuration Default { get; } = new Configuration();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.Memory", };

                public static string AssemblyName = "Microsoft.Extensions.Configuration";
                public static string AssemblyFile = "Microsoft.Extensions.Configuration.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Primitives.Default, System.Linq.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.Abstractions.dll";


                }

                public class Binder : ILib
                {

                    public static Binder Default { get; } = new Binder();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, System.ComponentModel.TypeConverter.Default, System.Collections.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.Binder", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.Binder";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.Binder.dll";


                }

                public class CommandLine : ILib
                {

                    public static CommandLine Default { get; } = new CommandLine();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Configuration.Default, System.Collections.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.CommandLine", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.CommandLine";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.CommandLine.dll";


                }

                public class EnvironmentVariables : ILib
                {

                    public static EnvironmentVariables Default { get; } = new EnvironmentVariables();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Configuration.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Runtime.Extensions.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.EnvironmentVariables", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.EnvironmentVariables";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.EnvironmentVariables.dll";


                }

                public class FileExtensions : ILib
                {

                    public static FileExtensions Default { get; } = new FileExtensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.FileProviders.Physical.Default, System.Runtime.Extensions.Default, System.Collections.Default, System.Threading.Thread.Default, System.IO.FileSystem.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.FileExtensions", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.FileExtensions";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.FileExtensions.dll";


                }

                public class Ini : ILib
                {

                    public static Ini Default { get; } = new Ini();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.Configuration.FileExtensions.Default, Microsoft.Extensions.Configuration.Default, System.Collections.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.Ini", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.Ini";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.Ini.dll";


                }

                public class Json : ILib
                {

                    public static Json Default { get; } = new Json();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Collections.Default, System.Text.Json.Default, Microsoft.Extensions.Configuration.FileExtensions.Default, Microsoft.Extensions.Configuration.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.Json", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.Json";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.Json.dll";


                }

                public class KeyPerFile : ILib
                {

                    public static KeyPerFile Default { get; } = new KeyPerFile();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Configuration.Default, System.Collections.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Runtime.Extensions.Default, System.IO.FileSystem.Default, Microsoft.Extensions.FileProviders.Physical.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.KeyPerFile", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.KeyPerFile";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.KeyPerFile.dll";


                }

                public class UserSecrets : ILib
                {

                    public static UserSecrets Default { get; } = new UserSecrets();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Physical.Default, System.Runtime.Extensions.Default, System.IO.FileSystem.Default, Microsoft.Extensions.Configuration.Json.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.UserSecrets", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.UserSecrets";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.UserSecrets.dll";


                }

                public class Xml : ILib
                {

                    public static Xml Default { get; } = new Xml();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.Configuration.FileExtensions.Default, System.Xml.ReaderWriter.Default, System.Security.Cryptography.Xml.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Configuration.Default, System.Collections.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Configuration", "Microsoft.Extensions.Configuration.Xml", };

                    public static string AssemblyName = "Microsoft.Extensions.Configuration.Xml";
                    public static string AssemblyFile = "Microsoft.Extensions.Configuration.Xml.dll";


                }

            }

            public class DependencyInjection : ILib
            {

                public static DependencyInjection Default { get; } = new DependencyInjection();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, System.Diagnostics.Tracing.Default, System.Linq.Expressions.Default, System.Collections.Concurrent.Default, System.Diagnostics.Debug.Default, System.Threading.ThreadPool.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Emit.ILGeneration.Default, System.Runtime.Extensions.Default, System.Linq.Default, System.Threading.Default, System.Reflection.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.DependencyInjection.ServiceLookup", };

                public static string AssemblyName = "Microsoft.Extensions.DependencyInjection";
                public static string AssemblyFile = "Microsoft.Extensions.DependencyInjection.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.DependencyInjection.Abstractions", "Microsoft.Extensions.DependencyInjection.Extensions", };

                    public static string AssemblyName = "Microsoft.Extensions.DependencyInjection.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.DependencyInjection.Abstractions.dll";


                }

            }

            public class Diagnostics : ILib
            {

                public static Diagnostics Default { get; } = new Diagnostics();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Diagnostics.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Configuration.Abstractions.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.Options.ConfigurationExtensions.Default, System.Threading.Default, System.Console.Default, System.Memory.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.Microsoft.Extensions.Diagnostics", "System", "System.Diagnostics", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Diagnostics.Metrics", "Microsoft.Extensions.Diagnostics.Metrics.Configuration", };

                public static string AssemblyName = "Microsoft.Extensions.Diagnostics";
                public static string AssemblyFile = "Microsoft.Extensions.Diagnostics.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Diagnostics.DiagnosticSource.Default, Microsoft.Extensions.Options.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.Microsoft.Extensions.Diagnostics.Abstractions", "System", "Microsoft.Extensions.Internal", "Microsoft.Extensions.Diagnostics.Metrics", };

                    public static string AssemblyName = "Microsoft.Extensions.Diagnostics.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Diagnostics.Abstractions.dll";


                }

                public class HealthChecks : ILib
                {

                    public static HealthChecks Default { get; } = new HealthChecks();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Threading.Timer.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Threading.Tasks.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Linq.Default, Microsoft.Extensions.Hosting.Abstractions.Default, System.Threading.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Diagnostics.HealthChecks", };

                    public static string AssemblyName = "Microsoft.Extensions.Diagnostics.HealthChecks";
                    public static string AssemblyFile = "Microsoft.Extensions.Diagnostics.HealthChecks.dll";


                    public class Abstractions : ILib
                    {

                        public static Abstractions Default { get; } = new Abstractions();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.AspNetCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Default, System.Runtime.Extensions.Default, System.Collections.Default, System.Linq.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Diagnostics.HealthChecks", };

                        public static string AssemblyName = "Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions";
                        public static string AssemblyFile = "Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.dll";


                    }

                }

            }

            public class Features : ILib
            {

                public static Features Default { get; } = new Features();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Collections.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.AspNetCore.Http.Features", };

                public static string AssemblyName = "Microsoft.Extensions.Features";
                public static string AssemblyFile = "Microsoft.Extensions.Features.dll";


            }

            public class FileProviders
            {

                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Primitives.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.FileProviders", };

                    public static string AssemblyName = "Microsoft.Extensions.FileProviders.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.FileProviders.Abstractions.dll";


                }

                public class Composite : ILib
                {

                    public static Composite Default { get; } = new Composite();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.FileProviders", "Microsoft.Extensions.FileProviders.Composite", };

                    public static string AssemblyName = "Microsoft.Extensions.FileProviders.Composite";
                    public static string AssemblyFile = "Microsoft.Extensions.FileProviders.Composite.dll";


                }

                public class Embedded : ILib
                {

                    public static Embedded Default { get; } = new Embedded();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.Primitives.Default, System.Diagnostics.Debug.Default, System.Xml.XDocument.Default, System.IO.FileSystem.Default, System.Runtime.Extensions.Default, System.Linq.Default, System.Xml.ReaderWriter.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.FileProviders", "Microsoft.Extensions.FileProviders.Embedded", "Microsoft.Extensions.FileProviders.Embedded.Manifest", };

                    public static string AssemblyName = "Microsoft.Extensions.FileProviders.Embedded";
                    public static string AssemblyFile = "Microsoft.Extensions.FileProviders.Embedded.dll";


                }

                public class Physical : ILib
                {

                    public static Physical Default { get; } = new Physical();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Threading.Timer.Default, Microsoft.Extensions.Primitives.Default, System.Threading.Tasks.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.IO.FileSystem.Default, System.Collections.Concurrent.Default, System.IO.FileSystem.Watcher.Default, Microsoft.Extensions.FileSystemGlobbing.Default, System.Linq.Default, System.Security.Cryptography.Algorithms.Default, System.Threading.Default, System.ComponentModel.Primitives.Default, System.Security.Cryptography.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.FileProviders", "Microsoft.Extensions.FileProviders.Internal", "Microsoft.Extensions.FileProviders.Physical", "Microsoft.Extensions.FileProviders.Physical.Internal", };

                    public static string AssemblyName = "Microsoft.Extensions.FileProviders.Physical";
                    public static string AssemblyFile = "Microsoft.Extensions.FileProviders.Physical.dll";


                }

            }

            public class FileSystemGlobbing : ILib
            {

                public static FileSystemGlobbing Default { get; } = new FileSystemGlobbing();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Extensions.Internal", "Microsoft.Extensions.FileSystemGlobbing", "Microsoft.Extensions.FileSystemGlobbing.Util", "Microsoft.Extensions.FileSystemGlobbing.Internal", "Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns", "Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts", "Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments", "Microsoft.Extensions.FileSystemGlobbing.Abstractions", };

                public static string AssemblyName = "Microsoft.Extensions.FileSystemGlobbing";
                public static string AssemblyFile = "Microsoft.Extensions.FileSystemGlobbing.dll";


            }

            public class Hosting : ILib
            {

                public static Hosting Default { get; } = new Hosting();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Hosting.Abstractions.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.DependencyInjection.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, System.Threading.Tasks.Default, System.Threading.Default, Microsoft.Extensions.Options.Default, System.Console.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, System.IO.FileSystem.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.FileProviders.Physical.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Configuration.FileExtensions.Default, Microsoft.Extensions.Configuration.EnvironmentVariables.Default, Microsoft.Extensions.Configuration.CommandLine.Default, Microsoft.Extensions.Configuration.Json.Default, Microsoft.Extensions.Configuration.UserSecrets.Default, System.Runtime.InteropServices.RuntimeInformation.Default, Microsoft.Extensions.Logging.EventLog.Default, Microsoft.Extensions.Logging.Configuration.Default, Microsoft.Extensions.Logging.Console.Default, Microsoft.Extensions.Logging.Debug.Default, Microsoft.Extensions.Logging.EventSource.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Hosting", "Microsoft.Extensions.Hosting.Internal", };

                public static string AssemblyName = "Microsoft.Extensions.Hosting";
                public static string AssemblyFile = "Microsoft.Extensions.Hosting.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.FileProviders.Abstractions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Hosting", };

                    public static string AssemblyName = "Microsoft.Extensions.Hosting.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Hosting.Abstractions.dll";


                }

            }

            public class Http : ILib
            {

                public static Http Default { get; } = new Http();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Net.Http.Default, System.Threading.Timer.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Concurrent.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Net.Primitives.Default, System.Threading.Default, System.Runtime.Extensions.Default, System.Linq.Default, Microsoft.Extensions.Logging.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Net.Http", "Microsoft.Extensions.Internal", "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Http", "Microsoft.Extensions.Http.Logging", };

                public static string AssemblyName = "Microsoft.Extensions.Http";
                public static string AssemblyFile = "Microsoft.Extensions.Http.dll";


            }

            public class Identity
            {

                public class Core : ILib
                {

                    public static Core Default { get; } = new Core();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Claims.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Security.Cryptography.Algorithms.Default, System.ComponentModel.Default, System.Collections.Default, System.Linq.Expressions.Default, Microsoft.Extensions.Options.Default, Microsoft.AspNetCore.Cryptography.KeyDerivation.Default, System.Security.Cryptography.Primitives.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.Logging.Default, System.Runtime.Extensions.Default, System.Linq.Default, System.Net.Primitives.Default, System.Text.Encoding.Extensions.Default, System.Security.Principal.Default, System.ComponentModel.Annotations.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Security.Claims", "Microsoft.Extensions.Identity.Core", "Microsoft.Extensions.DependencyInjection", "Microsoft.AspNetCore.Identity", };

                    public static string AssemblyName = "Microsoft.Extensions.Identity.Core";
                    public static string AssemblyFile = "Microsoft.Extensions.Identity.Core.dll";


                }

                public class Stores : ILib
                {

                    public static Stores Default { get; } = new Stores();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Claims.Default, Microsoft.Extensions.Identity.Core.Default, System.Linq.Expressions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, System.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.AspNetCore.Identity", };

                    public static string AssemblyName = "Microsoft.Extensions.Identity.Stores";
                    public static string AssemblyFile = "Microsoft.Extensions.Identity.Stores.dll";


                }

            }

            public class Localization : ILib
            {

                public static Localization Default { get; } = new Localization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Localization.Abstractions.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Default, System.Diagnostics.Debug.Default, Microsoft.Extensions.Options.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Localization", "Microsoft.Extensions.Localization.Internal", };

                public static string AssemblyName = "Microsoft.Extensions.Localization";
                public static string AssemblyFile = "Microsoft.Extensions.Localization.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Localization", };

                    public static string AssemblyName = "Microsoft.Extensions.Localization.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Localization.Abstractions.dll";


                }

            }

            public class Logging : ILib
            {

                public static Logging Default { get; } = new Logging();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.ComponentModel.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Logging", };

                public static string AssemblyName = "Microsoft.Extensions.Logging";
                public static string AssemblyFile = "Microsoft.Extensions.Logging.dll";


                public class Abstractions : ILib
                {

                    public static Abstractions Default { get; } = new Abstractions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Extensions.Internal", "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.Abstractions", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.Abstractions";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.Abstractions.dll";


                }

                public class Configuration : ILib
                {

                    public static Configuration Default { get; } = new Configuration();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Configuration.Default, Microsoft.Extensions.Options.ConfigurationExtensions.Default, Microsoft.Extensions.Configuration.Binder.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.Configuration", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.Configuration";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.Configuration.dll";


                }

                public class Console : ILib
                {

                    public static Console Default { get; } = new Console();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Console.Default, System.Runtime.Extensions.Default, System.Collections.Concurrent.Default, System.Threading.Thread.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Configuration.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.InteropServices.RuntimeInformation.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.Console", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.Console";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.Console.dll";


                }

                public class Debug : ILib
                {

                    public static Debug Default { get; } = new Debug();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.Logging.Abstractions.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Diagnostics.Debug.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.Debug", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.Debug";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.Debug.dll";


                }

                public class EventLog : ILib
                {

                    public static EventLog Default { get; } = new EventLog();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Diagnostics.EventLog.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.EventLog", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.EventLog";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.EventLog.dll";


                }

                public class EventSource : ILib
                {

                    public static EventSource Default { get; } = new EventSource();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Logging.Default, Microsoft.Extensions.Primitives.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.Text.Json.Default, System.Diagnostics.Tracing.Default, System.Threading.Tasks.Default, System.Collections.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Threading.Default, System.Runtime.CompilerServices.Unsafe.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.EventSource", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.EventSource";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.EventSource.dll";


                }

                public class TraceSource : ILib
                {

                    public static TraceSource Default { get; } = new TraceSource();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Logging.Default, System.Diagnostics.TraceSource.Default, Microsoft.Extensions.Logging.Abstractions.Default, System.ComponentModel.Default, System.Collections.Concurrent.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Logging", "Microsoft.Extensions.Logging.TraceSource", };

                    public static string AssemblyName = "Microsoft.Extensions.Logging.TraceSource";
                    public static string AssemblyFile = "Microsoft.Extensions.Logging.TraceSource.dll";


                }

            }

            public class ObjectPool : ILib
            {

                public static ObjectPool Default { get; } = new ObjectPool();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.ObjectPool", };

                public static string AssemblyName = "Microsoft.Extensions.ObjectPool";
                public static string AssemblyFile = "Microsoft.Extensions.ObjectPool.dll";


            }

            public class Options : ILib
            {

                public static Options Default { get; } = new Options();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Primitives.Default, System.ComponentModel.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Options", };

                public static string AssemblyName = "Microsoft.Extensions.Options";
                public static string AssemblyFile = "Microsoft.Extensions.Options.dll";


                public class ConfigurationExtensions : ILib
                {

                    public static ConfigurationExtensions Default { get; } = new ConfigurationExtensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Options.Default, Microsoft.Extensions.Configuration.Abstractions.Default, Microsoft.Extensions.Configuration.Binder.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, Microsoft.Extensions.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Options", };

                    public static string AssemblyName = "Microsoft.Extensions.Options.ConfigurationExtensions";
                    public static string AssemblyFile = "Microsoft.Extensions.Options.ConfigurationExtensions.dll";


                }

                public class DataAnnotations : ILib
                {

                    public static DataAnnotations Default { get; } = new DataAnnotations();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, Microsoft.Extensions.Options.Default, System.Collections.Default, System.ComponentModel.Annotations.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.DependencyInjection", "Microsoft.Extensions.Options", };

                    public static string AssemblyName = "Microsoft.Extensions.Options.DataAnnotations";
                    public static string AssemblyFile = "Microsoft.Extensions.Options.DataAnnotations.dll";


                }

            }

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Threading.Tasks.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Threading.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.Internal", "Microsoft.Extensions.Primitives", };

                public static string AssemblyName = "Microsoft.Extensions.Primitives";
                public static string AssemblyFile = "Microsoft.Extensions.Primitives.dll";


            }

            public class WebEncoders : ILib
            {

                public static WebEncoders Default { get; } = new WebEncoders();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, Microsoft.Extensions.DependencyInjection.Abstractions.Default, System.ComponentModel.Default, Microsoft.Extensions.Options.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.Extensions.WebEncoders", "Microsoft.Extensions.WebEncoders.Testing", "Microsoft.Extensions.DependencyInjection", };

                public static string AssemblyName = "Microsoft.Extensions.WebEncoders";
                public static string AssemblyFile = "Microsoft.Extensions.WebEncoders.dll";


            }

        }

        public class JSInterop : ILib
        {

            public static JSInterop Default { get; } = new JSInterop();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.AspNetCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.Text.Json.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Threading.Default, System.Linq.Default, System.Runtime.Extensions.Default, System.Text.Encodings.Web.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.JSInterop", "Microsoft.JSInterop.Infrastructure", };

            public static string AssemblyName = "Microsoft.JSInterop";
            public static string AssemblyFile = "Microsoft.JSInterop.dll";


        }

        public class Net
        {

            public class Http
            {

                public class Headers : ILib
                {

                    public static Headers Default { get; } = new Headers();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Microsoft.Extensions.Primitives.Default, System.Collections.Default, System.Linq.Default, System.Buffers.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.Net.Http.Headers", };

                    public static string AssemblyName = "Microsoft.Net.Http.Headers";
                    public static string AssemblyFile = "Microsoft.Net.Http.Headers.dll";


                }

            }

        }

        public class VisualBasic : ILib
        {

            public static VisualBasic Default { get; } = new VisualBasic();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.VisualBasic.Core.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "Microsoft.VisualBasic";
            public static string AssemblyFile = "Microsoft.VisualBasic.dll";


            public class Core : ILib
            {

                public static Core Default { get; } = new Core();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.IO.FileSystem.DriveInfo.Default, System.IO.FileSystem.Default, System.Runtime.Extensions.Default, System.Collections.Specialized.Default, System.Text.RegularExpressions.Default, System.Collections.Default, System.Threading.Thread.Default, System.Linq.Expressions.Default, System.Diagnostics.Debug.Default, Microsoft.Win32.Primitives.Default, System.Resources.ResourceManager.Default, System.Threading.Tasks.Default, System.Diagnostics.Process.Default, System.ComponentModel.Primitives.Default, System.Threading.Default, System.ObjectModel.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.VisualBasic.FileIO", "Microsoft.VisualBasic.CompilerServices", "Microsoft.VisualBasic", "System", "FxResources.Microsoft.VisualBasic.Core", };

                public static string AssemblyName = "Microsoft.VisualBasic.Core";
                public static string AssemblyFile = "Microsoft.VisualBasic.Core.dll";


            }

            public class Forms : ILib
            {

                public static Forms Default { get; } = new Forms();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, Microsoft.VisualBasic.Core.Default, System.IO.Pipes.Default, System.Runtime.Serialization.Xml.Default, System.Threading.Thread.Default, System.ComponentModel.Default, System.Windows.Forms.Default, System.ComponentModel.TypeConverter.Default, System.Threading.Default, System.Runtime.InteropServices.Default, Microsoft.Win32.Primitives.Default, System.IO.FileSystem.Default, System.Drawing.Primitives.Default, System.Windows.Extensions.Default, System.Net.NetworkInformation.Default, System.Net.Primitives.Default, System.Net.WebClient.Default, System.Net.Requests.Default, System.Diagnostics.TraceSource.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Collections.Specialized.Default, System.Security.Permissions.Default, System.Drawing.Common.Default, System.IO.FileSystem.DriveInfo.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.EventBasedAsync.Default, Microsoft.Win32.Registry.Default, System.Security.Principal.Windows.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Net.Ping.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.VisualBasic.ApplicationServices", "Microsoft.VisualBasic.CompilerServices", "Microsoft.VisualBasic", "Microsoft.VisualBasic.Devices", "Microsoft.VisualBasic.Logging", "Microsoft.VisualBasic.MyServices", "Microsoft.VisualBasic.MyServices.Internal", "System", };

                public static string AssemblyName = "Microsoft.VisualBasic.Forms";
                public static string AssemblyFile = "Microsoft.VisualBasic.Forms.dll";


            }

        }

        public class Win32
        {

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, };

                public string[] Namespaces { get; } = new string[] { "System.ComponentModel", };

                public static string AssemblyName = "Microsoft.Win32.Primitives";
                public static string AssemblyFile = "Microsoft.Win32.Primitives.dll";


            }

            public class Registry : ILib
            {

                public static Registry Default { get; } = new Registry();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Security.AccessControl.Default, System.Security.Principal.Windows.Default, System.Collections.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.Microsoft.Win32.Registry", "System", "System.Security.AccessControl", "Microsoft.Win32", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "Microsoft.Win32.Registry";
                public static string AssemblyFile = "Microsoft.Win32.Registry.dll";


                public class AccessControl : ILib
                {

                    public static AccessControl Default { get; } = new AccessControl();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, Microsoft.Win32.Registry.Default, System.Security.AccessControl.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.Microsoft.Win32.Registry.AccessControl", "System", "Microsoft.Win32", };

                    public static string AssemblyName = "Microsoft.Win32.Registry.AccessControl";
                    public static string AssemblyFile = "Microsoft.Win32.Registry.AccessControl.dll";


                }

            }

            public class SystemEvents : ILib
            {

                public static SystemEvents Default { get; } = new SystemEvents();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.Threading.Thread.Default, System.Threading.Default, System.Collections.Default, System.ComponentModel.EventBasedAsync.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.Microsoft.Win32.SystemEvents", "System", "Microsoft.Win32", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "Microsoft.Win32.SystemEvents";
                public static string AssemblyFile = "Microsoft.Win32.SystemEvents.dll";


            }

        }

    }

    public class mscorlib : ILib
    {

        public static mscorlib Default { get; } = new mscorlib();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.NETCore.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, Microsoft.Win32.Registry.Default, System.Security.Principal.Windows.Default, System.Runtime.Extensions.Default, System.Security.Permissions.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Collections.Concurrent.Default, System.ObjectModel.Default, System.Console.Default, System.Diagnostics.StackTrace.Default, System.IO.FileSystem.Default, System.IO.FileSystem.DriveInfo.Default, System.Runtime.Default, System.IO.IsolatedStorage.Default, System.ComponentModel.Default, System.Resources.Writer.Default, System.Runtime.CompilerServices.VisualC.Default, System.Runtime.InteropServices.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Runtime.Serialization.Formatters.Default, System.Security.AccessControl.Default, System.IO.FileSystem.AccessControl.Default, System.Threading.AccessControl.Default, System.Security.Claims.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Principal.Default, System.Threading.Default, System.Threading.Tasks.Parallel.Default, };

        public string[] Namespaces { get; } = new string[] { };

        public static string AssemblyName = "mscorlib";
        public static string AssemblyFile = "mscorlib.dll";


    }

    public class netstandard : ILib
    {

        public static netstandard Default { get; } = new netstandard();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.NETCore.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.MemoryMappedFiles.Default, System.IO.Pipes.Default, System.Diagnostics.Process.Default, System.Security.Cryptography.X509Certificates.Default, System.Runtime.Extensions.Default, System.Memory.Default, System.Buffers.Default, System.Diagnostics.Tools.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Collections.Concurrent.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.EventBasedAsync.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.Default, Microsoft.Win32.Primitives.Default, System.Console.Default, System.Data.Common.Default, System.Runtime.InteropServices.Default, System.Diagnostics.TraceSource.Default, System.Diagnostics.Contracts.Default, System.Diagnostics.Debug.Default, System.Diagnostics.TextWriterTraceListener.Default, System.Diagnostics.FileVersionInfo.Default, System.Diagnostics.StackTrace.Default, System.Diagnostics.Tracing.Default, System.Drawing.Primitives.Default, System.Linq.Expressions.Default, System.IO.Compression.Brotli.Default, System.IO.Compression.Default, System.IO.Compression.ZipFile.Default, System.IO.FileSystem.Default, System.IO.FileSystem.DriveInfo.Default, System.IO.FileSystem.Watcher.Default, System.IO.IsolatedStorage.Default, System.Linq.Default, System.Linq.Queryable.Default, System.Linq.Parallel.Default, System.Threading.Thread.Default, System.Net.Requests.Default, System.Net.Primitives.Default, System.Net.HttpListener.Default, System.Net.ServicePoint.Default, System.Net.NameResolution.Default, System.Net.WebClient.Default, System.Net.Http.Default, System.Net.WebHeaderCollection.Default, System.Net.WebProxy.Default, System.Net.Mail.Default, System.Net.NetworkInformation.Default, System.Net.Ping.Default, System.Net.Security.Default, System.Net.Sockets.Default, System.Net.WebSockets.Client.Default, System.Net.WebSockets.Default, System.Runtime.Numerics.Default, System.Numerics.Vectors.Default, System.Threading.Tasks.Default, System.Reflection.DispatchProxy.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Primitives.Default, System.Resources.ResourceManager.Default, System.Resources.Writer.Default, System.Runtime.CompilerServices.VisualC.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Runtime.Serialization.Primitives.Default, System.Runtime.Serialization.Xml.Default, System.Runtime.Serialization.Json.Default, System.Runtime.Serialization.Formatters.Default, System.Security.Claims.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Security.Principal.Default, System.Text.Encoding.Extensions.Default, System.Text.RegularExpressions.Default, System.Threading.Default, System.Threading.Overlapped.Default, System.Threading.ThreadPool.Default, System.Threading.Tasks.Parallel.Default, System.Threading.Timer.Default, System.Transactions.Local.Default, System.Web.HttpUtility.Default, System.Xml.ReaderWriter.Default, System.Xml.XDocument.Default, System.Xml.XmlSerializer.Default, System.Xml.XPath.XDocument.Default, System.Xml.XPath.Default, };

        public string[] Namespaces { get; } = new string[] { };

        public static string AssemblyName = "netstandard";
        public static string AssemblyFile = "netstandard.dll";


    }

    public class PresentationCore : ILib
    {

        public static PresentationCore Default { get; } = new PresentationCore();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { mscorlib.Default, System.Runtime.Default, System.Xaml.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, WindowsBase.Default, System.Collections.Default, System.Diagnostics.Debug.Default, DirectWriteForwarder.Default, System.ComponentModel.Primitives.Default, System.Diagnostics.Process.Default, UIAutomationTypes.Default, System.Net.Requests.Default, System.Diagnostics.TraceSource.Default, System.ComponentModel.TypeConverter.Default, System.Runtime.InteropServices.WindowsRuntime.Default, System.IO.Packaging.Default, System.Xml.ReaderWriter.Default, Microsoft.Win32.Registry.Default, UIAutomationProvider.Default, Microsoft.Win32.Primitives.Default, System.Net.WebHeaderCollection.Default, System.Net.Primitives.Default, System.Diagnostics.Tracing.Default, System.Diagnostics.Contracts.Default, System.Threading.Default, System.Collections.Specialized.Default, System.Threading.ThreadPool.Default, System.Threading.Timer.Default, System.ObjectModel.Default, System.Configuration.ConfigurationManager.Default, System.Runtime.Serialization.Formatters.Default, System.Threading.Thread.Default, System.Windows.Input.Manipulations.Default, System.Collections.NonGeneric.Default, System.ComponentModel.Default, System.ComponentModel.EventBasedAsync.Default, System.IO.FileSystem.Default, System.Text.Encoding.Extensions.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.PresentationCore", "MS.Utility", "MS.Internal.PresentationCore", "MS.Win32.PresentationCore", "MS.Win32", "System.Windows.Media", "System.Windows.Media.Composition", "System.Windows.Media.Imaging", "MS.Internal", "MS.Win32.Recognizer", "System.Windows.Ink", "MS.Win32.Pointer", "MS.Win32.Penimc", "System.Windows.Interop", "MS.Win32.Compile", "System.Windows", "System.Windows.Input", "MS.Internal.FontCache", "System.Windows.Media.TextFormatting", "System", "System.Windows.Media.Media3D", "System.Windows.Automation.Peers", "System.IO.Packaging", "System.Windows.Navigation", "MS.Internal.AppModel", "MS.Internal.Media", "System.Windows.Media.Animation", "MS.Internal.WindowsRuntime.Windows.UI.ViewManagement", "MS.Internal.Shaping", "MS.Internal.FontFace", "System.Windows.Markup", "MS.Internal.TextFormatting", "MS.Internal.Generic", "MS.Internal.Resources", "System.Windows.Resources", "MS.Internal.Media3D", "MS.Internal.Interop", "MS.Internal.IO.Packaging", "MS.Internal.Collections", "MS.Internal.Automation", "MS.Internal.KnownBoxes", "MS.Internal.Telemetry.PresentationCore", "MS.Internal.Ink", "MS.Internal.Ink.InkSerializedFormat", "MS.Internal.Ink.GestureRecognition", "MS.Internal.Hashing.PresentationCore", "MS.Internal.Composition", "MS.Internal.PresentationCore.WindowsRuntime", "System.IO", "System.Windows.Input.StylusPlugIns", "System.Windows.Media.Effects", "System.Windows.Input.StylusPointer", "System.Windows.Input.Tracing", "System.Windows.Input.StylusWisp", "System.Windows.Documents", "System.Windows.Diagnostics", "System.Windows.Automation", "System.Windows.Media.Media3D.Converters", "System.Windows.Media.Converters", };

        public static string AssemblyName = "PresentationCore";
        public static string AssemblyFile = "PresentationCore.dll";


    }

    public class PresentationFramework : ILib
    {

        public static PresentationFramework Default { get; } = new PresentationFramework();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Xaml.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Threading.Thread.Default, WindowsBase.Default, System.Collections.Default, PresentationCore.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Default, System.Diagnostics.FileVersionInfo.Default, Microsoft.Win32.Registry.Default, System.Diagnostics.TraceSource.Default, System.Xml.ReaderWriter.Default, UIAutomationProvider.Default, UIAutomationTypes.Default, ReachFramework.Default, System.Printing.Default, System.IO.Packaging.Default, System.Collections.NonGeneric.Default, System.Text.RegularExpressions.Default, PresentationUI.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.ComponentModel.Primitives.Default, System.Xml.XPath.Default, System.Text.Encoding.Extensions.Default, System.ComponentModel.EventBasedAsync.Default, System.Runtime.Serialization.Formatters.Default, System.Diagnostics.Tracing.Default, System.Diagnostics.Contracts.Default, System.Net.Requests.Default, System.Threading.Default, System.Configuration.ConfigurationManager.Default, System.Collections.Concurrent.Default, System.Linq.Expressions.Default, System.Windows.Extensions.Default, Microsoft.Win32.Primitives.Default, Accessibility.Default, System.IO.FileSystem.Default, System.Threading.ThreadPool.Default, System.Console.Default, System.Text.Encoding.CodePages.Default, System.Linq.Default, System.Diagnostics.StackTrace.Default, System.Net.Primitives.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.PresentationFramework", "Standard", "Microsoft.Win32", "MS.Win32", "MS.Utility", "MS.Internal", "MS.Internal.Automation", "MS.Internal.PtsTable", "MS.Internal.PtsHost", "MS.Internal.PtsHost.UnsafeNativeMethods", "MS.Internal.Progressivity", "MS.Internal.Printing", "MS.Internal.Navigation", "MS.Internal.Markup", "MS.Internal.KnownBoxes", "MS.Internal.IO.Packaging", "MS.Internal.Interop", "MS.Internal.Ink", "MS.Internal.Globalization", "MS.Internal.Documents", "MS.Internal.Documents.Application", "MS.Internal.Data", "MS.Internal.Controls", "MS.Internal.Controls.StickyNote", "MS.Internal.Commands", "MS.Internal.AppModel", "MS.Internal.Annotations", "MS.Internal.Annotations.Storage", "MS.Internal.Annotations.Component", "MS.Internal.Annotations.Anchoring", "MS.Internal.Telemetry.PresentationFramework", "MS.Internal.Utility", "MS.Internal.WindowsRuntime", "MS.Internal.WindowsRuntime.Windows.Globalization", "MS.Internal.WindowsRuntime.Windows.Data.Text", "MS.Internal.Text", "MS.Internal.Hashing.PresentationFramework", "MS.Internal.PresentationFramework", "MS.Internal.PresentationFramework.Markup", "MS.Internal.PresentationFramework.Interop", "MS.Internal.Xaml.Context", "MS.Internal.Xaml.Parser", "System", "System.ComponentModel", "System.Runtime.InteropServices", "System.Windows", "System.Windows.Shell", "System.Windows.Shapes", "System.Windows.Resources", "System.Windows.Baml2006", "System.Windows.Interop", "System.Windows.Input", "System.Windows.Media", "System.Windows.Media.Animation", "System.Windows.Diagnostics", "System.Windows.Data", "System.Windows.Markup", "System.Windows.Markup.Primitives", "System.Windows.Markup.Localizer", "System.Windows.Automation.Peers", "System.Windows.Navigation", "System.Windows.Documents", "System.Windows.Documents.Tracing", "System.Windows.Documents.Serialization", "System.Windows.Documents.MsSpellCheckLib", "System.Windows.Documents.DocumentStructures", "System.Windows.Documents.Internal", "System.Windows.Controls", "System.Windows.Controls.Primitives", "System.Windows.Annotations", "System.Windows.Annotations.Storage", };

        public static string AssemblyName = "PresentationFramework";
        public static string AssemblyFile = "PresentationFramework.dll";


        public class Aero : ILib
        {

            public static Aero Default { get; } = new Aero();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.Aero";
            public static string AssemblyFile = "PresentationFramework.Aero.dll";


        }

        public class Aero2 : ILib
        {

            public static Aero2 Default { get; } = new Aero2();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.Aero2";
            public static string AssemblyFile = "PresentationFramework.Aero2.dll";


        }

        public class AeroLite : ILib
        {

            public static AeroLite Default { get; } = new AeroLite();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.AeroLite";
            public static string AssemblyFile = "PresentationFramework.AeroLite.dll";


        }

        public class Classic : ILib
        {

            public static Classic Default { get; } = new Classic();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.Classic";
            public static string AssemblyFile = "PresentationFramework.Classic.dll";


        }

        public class Luna : ILib
        {

            public static Luna Default { get; } = new Luna();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.Luna";
            public static string AssemblyFile = "PresentationFramework.Luna.dll";


        }

        public class Royale : ILib
        {

            public static Royale Default { get; } = new Royale();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, PresentationCore.Default, System.Xaml.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Collections.Concurrent.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.Windows.Themes", "Microsoft.Internal", };

            public static string AssemblyName = "PresentationFramework.Royale";
            public static string AssemblyFile = "PresentationFramework.Royale.dll";


        }

    }

    public class PresentationFramework_SystemCore : ILib
    {

        public static PresentationFramework_SystemCore Default { get; } = new PresentationFramework_SystemCore();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, PresentationFramework.Default, System.Linq.Expressions.Default, System.Threading.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal", };

        public static string AssemblyName = "PresentationFramework-SystemCore";
        public static string AssemblyFile = "PresentationFramework-SystemCore.dll";


    }

    public class PresentationFramework_SystemData : ILib
    {

        public static PresentationFramework_SystemData Default { get; } = new PresentationFramework_SystemData();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, System.ComponentModel.TypeConverter.Default, System.Data.Common.Default, System.ObjectModel.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal", };

        public static string AssemblyName = "PresentationFramework-SystemData";
        public static string AssemblyFile = "PresentationFramework-SystemData.dll";


    }

    public class PresentationFramework_SystemDrawing : ILib
    {

        public static PresentationFramework_SystemDrawing Default { get; } = new PresentationFramework_SystemDrawing();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, System.Drawing.Common.Default, System.Drawing.Primitives.Default, System.Runtime.Extensions.Default, PresentationCore.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal", };

        public static string AssemblyName = "PresentationFramework-SystemDrawing";
        public static string AssemblyFile = "PresentationFramework-SystemDrawing.dll";


    }

    public class PresentationFramework_SystemXml : ILib
    {

        public static PresentationFramework_SystemXml Default { get; } = new PresentationFramework_SystemXml();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, System.Xml.ReaderWriter.Default, PresentationFramework.Default, System.ComponentModel.TypeConverter.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal", "MS.Internal.Data", };

        public static string AssemblyName = "PresentationFramework-SystemXml";
        public static string AssemblyFile = "PresentationFramework-SystemXml.dll";


    }

    public class PresentationFramework_SystemXmlLinq : ILib
    {

        public static PresentationFramework_SystemXmlLinq Default { get; } = new PresentationFramework_SystemXmlLinq();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, System.Xml.XDocument.Default, System.ComponentModel.TypeConverter.Default, };

        public string[] Namespaces { get; } = new string[] { "MS.Internal", };

        public static string AssemblyName = "PresentationFramework-SystemXmlLinq";
        public static string AssemblyFile = "PresentationFramework-SystemXmlLinq.dll";


    }

    public class PresentationUI : ILib
    {

        public static PresentationUI Default { get; } = new PresentationUI();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, PresentationFramework.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.Windows.Forms.Default, PresentationCore.Default, WindowsBase.Default, System.Collections.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Cryptography.Algorithms.Default, ReachFramework.Default, System.IO.Packaging.Default, System.Drawing.Primitives.Default, System.Xaml.Default, System.Diagnostics.Debug.Default, System.Diagnostics.Tools.Default, System.Runtime.Extensions.Default, System.DirectoryServices.Default, Microsoft.Win32.Registry.Default, System.IO.FileSystem.Default, System.Drawing.Common.Default, System.Threading.Default, System.Printing.Default, UIAutomationProvider.Default, System.IO.FileSystem.AccessControl.Default, System.Diagnostics.TraceSource.Default, System.Security.Cryptography.Primitives.Default, System.Windows.Extensions.Default, System.Collections.NonGeneric.Default, System.Threading.ThreadPool.Default, System.Threading.Thread.Default, System.Diagnostics.Process.Default, System.ObjectModel.Default, System.Security.AccessControl.Default, System.ComponentModel.Default, UIAutomationTypes.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.PresentationUI", "MS.Internal.Documents", "MS.Internal.Documents.Application", "MS.Internal.PresentationUI", "Microsoft.Internal", "Microsoft.Internal.DeploymentUI", "System.Windows.Documents", "System.Windows.TrustUI", };

        public static string AssemblyName = "PresentationUI";
        public static string AssemblyFile = "PresentationUI.dll";


    }

    public class ReachFramework : ILib
    {

        public static ReachFramework Default { get; } = new ReachFramework();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, PresentationCore.Default, WindowsBase.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Printing.Default, Microsoft.Win32.Primitives.Default, System.Xml.ReaderWriter.Default, System.Threading.Thread.Default, System.ComponentModel.TypeConverter.Default, PresentationFramework.Default, System.ObjectModel.Default, System.IO.Packaging.Default, System.Security.Cryptography.Xml.Default, System.Security.Cryptography.X509Certificates.Default, System.ComponentModel.Default, System.ComponentModel.EventBasedAsync.Default, System.ComponentModel.Primitives.Default, System.Net.Requests.Default, System.Threading.Default, System.IO.FileSystem.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.ReachFramework", "Microsoft.Internal.AlphaFlattener", "MS.Internal", "MS.Internal.Printing", "MS.Internal.Printing.Configuration", "MS.Internal.PrintWin32Thunk.Win32ApiThunk", "MS.Internal.Utility", "MS.Internal.ReachFramework", "MS.Internal.ReachFramework.Markup", "System.Printing", "System.Printing.Interop", "System.Windows.Xps", "System.Windows.Xps.Packaging", "System.Windows.Xps.Serialization", "System.Windows.Xps.Serialization.RCW", };

        public static string AssemblyName = "ReachFramework";
        public static string AssemblyFile = "ReachFramework.dll";


    }

    public class System : ILib
    {

        public static System Default { get; } = new System();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.NETCore.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.CodeDom.Default, Microsoft.Win32.SystemEvents.Default,
            System.Diagnostics.Process.Default, System.Security.Cryptography.X509Certificates.Default,
            System.Diagnostics.Tools.Default, System.Runtime.Extensions.Default, System.Collections.Concurrent.Default, System.Runtime.Default,
            System.Collections.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.Collections.NonGeneric.Default,
            System.ComponentModel.TypeConverter.Default, System.ComponentModel.EventBasedAsync.Default, System.ComponentModel.Primitives.Default,
            System.ComponentModel.Default, Microsoft.Win32.Primitives.Default, System.Configuration.ConfigurationManager.Default, System.Diagnostics.TraceSource.Default,
            System.Diagnostics.TextWriterTraceListener.Default, System.Diagnostics.PerformanceCounter.Default, System.Diagnostics.EventLog.Default,
            System.Security.Permissions.Default, System.Diagnostics.FileVersionInfo.Default, System.Diagnostics.StackTrace.Default,
            System.Private.Uri.Default, System.IO.Compression.Default, System.IO.FileSystem.Watcher.Default,
            new ExternalAssembly("System.IO.Ports"),
            System.Windows.Extensions.Default, System.Net.Requests.Default, System.Net.Primitives.Default, System.Net.HttpListener.Default,
            System.Net.ServicePoint.Default, System.Net.NameResolution.Default, System.Net.WebClient.Default, System.Net.WebHeaderCollection.Default,
            System.Net.WebProxy.Default, System.Net.Mail.Default, System.Net.NetworkInformation.Default, System.Net.Ping.Default, System.Net.Security.Default,
            System.Net.Sockets.Default, System.Net.WebSockets.Client.Default, System.Net.WebSockets.Default, System.Runtime.InteropServices.Default,
            System.Threading.AccessControl.Default, System.Security.Cryptography.Encoding.Default, System.Text.RegularExpressions.Default, System.Threading.Default,
            System.Threading.Thread.Default, };

        public string[] Namespaces { get; } = new string[] { };

        public static string AssemblyName = "System";
        public static string AssemblyFile = "System.dll";


        public class AppContext : ILib
        {

            public static AppContext Default { get; } = new AppContext();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.AppContext";
            public static string AssemblyFile = "System.AppContext.dll";


        }

        public class Buffers : ILib
        {

            public static Buffers Default { get; } = new Buffers();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Buffers";
            public static string AssemblyFile = "System.Buffers.dll";


        }

        public class CodeDom : ILib
        {

            public static CodeDom Default { get; } = new CodeDom();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { netstandard.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.CodeDom", "System", "System.Collections.Specialized", "System.CodeDom", "System.CodeDom.Compiler", "Microsoft.VisualBasic", "Microsoft.CSharp", };

            public static string AssemblyName = "System.CodeDom";
            public static string AssemblyFile = "System.CodeDom.dll";


        }

        public class Collections : ILib
        {

            public static Collections Default { get; } = new Collections();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Runtime.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Collections", "System", "System.Collections", "System.Collections.Generic", };

            public static string AssemblyName = "System.Collections";
            public static string AssemblyFile = "System.Collections.dll";


            public class Concurrent : ILib
            {

                public static Concurrent Default { get; } = new Concurrent();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Collections.Concurrent", "System", "System.Threading", "System.Collections.Concurrent", };

                public static string AssemblyName = "System.Collections.Concurrent";
                public static string AssemblyFile = "System.Collections.Concurrent.dll";


            }

            public class Immutable : ILib
            {

                public static Immutable Default { get; } = new Immutable();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Diagnostics.Tools.Default, System.Linq.Default, System.Threading.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Collections.Immutable", "System", "System.Runtime.Versioning", "System.Linq", "System.Collections.Immutable", "System.Collections.Generic", };

                public static string AssemblyName = "System.Collections.Immutable";
                public static string AssemblyFile = "System.Collections.Immutable.dll";


            }

            public class NonGeneric : ILib
            {

                public static NonGeneric Default { get; } = new NonGeneric();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Collections.NonGeneric", "System", "System.Collections", "System.Collections.Specialized", };

                public static string AssemblyName = "System.Collections.NonGeneric";
                public static string AssemblyFile = "System.Collections.NonGeneric.dll";


            }

            public class Specialized : ILib
            {

                public static Specialized Default { get; } = new Specialized();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Collections.Specialized", "System", "System.Collections", "System.Collections.Specialized", };

                public static string AssemblyName = "System.Collections.Specialized";
                public static string AssemblyFile = "System.Collections.Specialized.dll";


            }

        }

        public class ComponentModel : ILib
        {

            public static ComponentModel Default { get; } = new ComponentModel();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

            public string[] Namespaces { get; } = new string[] { "System", "System.ComponentModel", };

            public static string AssemblyName = "System.ComponentModel";
            public static string AssemblyFile = "System.ComponentModel.dll";


            public class Annotations : ILib
            {

                public static Annotations Default { get; } = new Annotations();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.ComponentModel.Annotations", "System", "System.ComponentModel.DataAnnotations", "System.ComponentModel.DataAnnotations.Schema", };

                public static string AssemblyName = "System.ComponentModel.Annotations";
                public static string AssemblyFile = "System.ComponentModel.Annotations.dll";


            }

            public class DataAnnotations : ILib
            {

                public static DataAnnotations Default { get; } = new DataAnnotations();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.ComponentModel.Annotations.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.ComponentModel.DataAnnotations";
                public static string AssemblyFile = "System.ComponentModel.DataAnnotations.dll";


            }

            public class EventBasedAsync : ILib
            {

                public static EventBasedAsync Default { get; } = new EventBasedAsync();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.ComponentModel.EventBasedAsync", "System", "System.ComponentModel", };

                public static string AssemblyName = "System.ComponentModel.EventBasedAsync";
                public static string AssemblyFile = "System.ComponentModel.EventBasedAsync.dll";


            }

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.NonGeneric.Default, System.ComponentModel.Default, System.Threading.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.ComponentModel.Primitives", "System", "System.ComponentModel", };

                public static string AssemblyName = "System.ComponentModel.Primitives";
                public static string AssemblyFile = "System.ComponentModel.Primitives.dll";


            }

            public class TypeConverter : ILib
            {

                public static TypeConverter Default { get; } = new TypeConverter();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Net.Security.Default, System.Drawing.Primitives.Default, System.Collections.Default, System.ComponentModel.Primitives.Default, System.Threading.Timer.Default, System.Diagnostics.TraceSource.Default, System.ComponentModel.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.Collections.NonGeneric.Default, System.Runtime.Serialization.Formatters.Default, System.Resources.Writer.Default, System.Xml.XDocument.Default, System.Threading.Default, System.Linq.Default, System.IO.FileSystem.Default, System.Text.RegularExpressions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.ComponentModel.TypeConverter", "System", "System.Security.Authentication.ExtendedProtection", "System.Drawing", "System.Timers", "System.ComponentModel", "System.ComponentModel.Design", "System.ComponentModel.Design.Serialization", "MS.Internal.Xml.Linq.ComponentModel", };

                public static string AssemblyName = "System.ComponentModel.TypeConverter";
                public static string AssemblyFile = "System.ComponentModel.TypeConverter.dll";


            }

        }

        public class Configuration : ILib
        {

            public static Configuration Default { get; } = new Configuration();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Configuration.ConfigurationManager.Default, System.Security.Permissions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Configuration";
            public static string AssemblyFile = "System.Configuration.dll";


            public class ConfigurationManager : ILib
            {

                public static ConfigurationManager Default { get; } = new ConfigurationManager();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, System.Security.Permissions.Default, System.Security.Cryptography.ProtectedData.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Configuration.ConfigurationManager", "System", "System.IO.Internal", "System.Security", "System.Drawing.Configuration", "System.Configuration", "System.Configuration.Provider", "System.Configuration.Internal", };

                public static string AssemblyName = "System.Configuration.ConfigurationManager";
                public static string AssemblyFile = "System.Configuration.ConfigurationManager.dll";


            }

        }

        public class Console : ILib
        {

            public static Console Default { get; } = new Console();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.Text.Encoding.Extensions.Default, System.Buffers.Default, System.Memory.Default, System.Threading.Tasks.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.Console", "System", "System.Text", "System.IO", };

            public static string AssemblyName = "System.Console";
            public static string AssemblyFile = "System.Console.dll";


        }

        public class Core : ILib
        {

            public static Core Default { get; } = new Core();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.MemoryMappedFiles.Default, System.Security.Cryptography.Cng.Default, System.IO.Pipes.Default, System.Collections.Default, System.Diagnostics.EventLog.Default, System.Diagnostics.PerformanceCounter.Default, System.Linq.Expressions.Default, System.IO.Pipes.AccessControl.Default, System.Linq.Default, System.Linq.Queryable.Default, System.Linq.Parallel.Default, System.Runtime.InteropServices.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.X509Certificates.Default, System.Threading.Default, System.Threading.Tasks.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Core";
            public static string AssemblyFile = "System.Core.dll";


        }

        public class Data : ILib
        {

            public static Data Default { get; } = new Data();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[]
            {
                System.Private.CoreLib.Default,
                new ExternalAssembly("System.Data.SqlClient"),
                System.Data.Common.Default, System.Security.Permissions.Default,
                new ExternalAssembly("System.Data.Odbc"),
                new ExternalAssembly("System.Data.OleDb"),
            };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Data";
            public static string AssemblyFile = "System.Data.dll";


            public class Common : ILib
            {

                public static Common Default { get; } = new Common();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Runtime.Extensions.Default, System.Xml.ReaderWriter.Default,
                    System.ObjectModel.Default, System.ComponentModel.TypeConverter.Default, System.Collections.NonGeneric.Default,
                    System.ComponentModel.Primitives.Default, System.Collections.Default, System.Runtime.Numerics.Default, System.ComponentModel.Default,
                    System.Xml.XmlSerializer.Default, System.Runtime.Serialization.Formatters.Default, System.Transactions.Local.Default,
                    System.Collections.Concurrent.Default, System.Text.RegularExpressions.Default, System.Private.Uri.Default, System.Linq.Default,
                    System.Linq.Expressions.Default, System.Drawing.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Data.Common", "System", "System.Xml", "System.Data", "System.Data.SqlTypes", "System.Data.ProviderBase", "System.Data.Common", };

                public static string AssemblyName = "System.Data.Common";
                public static string AssemblyFile = "System.Data.Common.dll";


            }

            public class DataSetExtensions : ILib
            {

                public static DataSetExtensions Default { get; } = new DataSetExtensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Data.Common.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Data.DataSetExtensions";
                public static string AssemblyFile = "System.Data.DataSetExtensions.dll";


            }

        }

        public class Design : ILib
        {

            public static Design Default { get; } = new Design();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Windows.Forms.Design.Default, System.Windows.Forms.Design.Editors.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Design";
            public static string AssemblyFile = "System.Design.dll";


        }

        public class Diagnostics
        {

            public class Contracts : ILib
            {

                public static Contracts Default { get; } = new Contracts();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Diagnostics.Contracts";
                public static string AssemblyFile = "System.Diagnostics.Contracts.dll";


            }

            public class Debug : ILib
            {

                public static Debug Default { get; } = new Debug();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Diagnostics.Debug";
                public static string AssemblyFile = "System.Diagnostics.Debug.dll";


            }

            public class DiagnosticSource : ILib
            {

                public static DiagnosticSource Default { get; } = new DiagnosticSource();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Threading.Default, System.Diagnostics.Debug.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.DiagnosticSource", "System", "System.Diagnostics", };

                public static string AssemblyName = "System.Diagnostics.DiagnosticSource";
                public static string AssemblyFile = "System.Diagnostics.DiagnosticSource.dll";


            }

            public class EventLog : ILib
            {

                public static EventLog Default { get; } = new EventLog();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Primitives.Default, System.Threading.Default, Microsoft.Win32.Registry.Default, System.Collections.Default, System.Collections.Specialized.Default, Microsoft.Win32.Primitives.Default, System.Threading.ThreadPool.Default, System.Diagnostics.TraceSource.Default, System.Security.Principal.Windows.Default, System.IO.FileSystem.Default, System.Threading.Thread.Default, System.Threading.Tasks.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.EventLog", "Microsoft.Win32", "Microsoft.Win32.SafeHandles", "System", "System.Diagnostics", "System.Diagnostics.Eventing.Reader", "System.ComponentModel", };

                public static string AssemblyName = "System.Diagnostics.EventLog";
                public static string AssemblyFile = "System.Diagnostics.EventLog.dll";


                public class Messages : ILib
                {

                    public static Messages Default { get; } = new Messages();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Diagnostics.EventLog.Messages";
                    public static string AssemblyFile = "System.Diagnostics.EventLog.Messages.dll";


                }

            }

            public class FileVersionInfo : ILib
            {

                public static FileVersionInfo Default { get; } = new FileVersionInfo();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.IO.FileSystem.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Diagnostics", };

                public static string AssemblyName = "System.Diagnostics.FileVersionInfo";
                public static string AssemblyFile = "System.Diagnostics.FileVersionInfo.dll";


            }

            public class PerformanceCounter : ILib
            {

                public static PerformanceCounter Default { get; } = new PerformanceCounter();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Memory.Default, System.IO.MemoryMappedFiles.Default, System.Diagnostics.Process.Default, System.Security.Principal.Windows.Default, System.Resources.ResourceManager.Default, System.Collections.NonGeneric.Default, System.Configuration.ConfigurationManager.Default, System.ComponentModel.Primitives.Default, System.Threading.Default, Microsoft.Win32.Registry.Default, System.Collections.Default, Microsoft.Win32.Primitives.Default, System.Threading.Thread.Default, System.ComponentModel.TypeConverter.Default, System.IO.FileSystem.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.PerformanceCounter", "Microsoft.Win32.SafeHandles", "Internal.Win32.SafeHandles", "System", "System.Diagnostics", "System.Diagnostics.PerformanceData", };

                public static string AssemblyName = "System.Diagnostics.PerformanceCounter";
                public static string AssemblyFile = "System.Diagnostics.PerformanceCounter.dll";


            }

            public class Process : ILib
            {

                public static Process Default { get; } = new Process();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Threading.Tasks.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Threading.ThreadPool.Default, System.ComponentModel.Primitives.Default, Microsoft.Win32.Primitives.Default, System.Threading.Thread.Default, System.Diagnostics.FileVersionInfo.Default, System.Collections.NonGeneric.Default, System.Collections.Specialized.Default, Microsoft.Win32.Registry.Default, System.Collections.Concurrent.Default, System.Text.Encoding.Extensions.Default, System.Threading.Default, System.IO.FileSystem.Default, System.Linq.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.Process", "System", "System.Text", "System.Runtime.Serialization", "System.Diagnostics", "System.Collections.Specialized", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "System.Diagnostics.Process";
                public static string AssemblyFile = "System.Diagnostics.Process.dll";


            }

            public class StackTrace : ILib
            {

                public static StackTrace Default { get; } = new StackTrace();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Runtime.Extensions.Default, System.Reflection.Metadata.Default, System.IO.FileSystem.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Diagnostics", "System.Diagnostics.SymbolStore", };

                public static string AssemblyName = "System.Diagnostics.StackTrace";
                public static string AssemblyFile = "System.Diagnostics.StackTrace.dll";


            }

            public class TextWriterTraceListener : ILib
            {

                public static TextWriterTraceListener Default { get; } = new TextWriterTraceListener();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Diagnostics.TraceSource.Default, System.Collections.NonGeneric.Default, System.Xml.ReaderWriter.Default, System.Diagnostics.Process.Default, System.Console.Default, System.Threading.Default, System.Text.Encoding.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.TextWriterTraceListener", "System", "System.Diagnostics", };

                public static string AssemblyName = "System.Diagnostics.TextWriterTraceListener";
                public static string AssemblyFile = "System.Diagnostics.TextWriterTraceListener.dll";


            }

            public class Tools : ILib
            {

                public static Tools Default { get; } = new Tools();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Diagnostics.CodeAnalysis", "System.CodeDom.Compiler", };

                public static string AssemblyName = "System.Diagnostics.Tools";
                public static string AssemblyFile = "System.Diagnostics.Tools.dll";


            }

            public class TraceSource : ILib
            {

                public static TraceSource Default { get; } = new TraceSource();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Collections.NonGeneric.Default, System.Collections.Specialized.Default, System.Diagnostics.Process.Default, System.IO.FileSystem.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Diagnostics.TraceSource", "System", "System.Diagnostics", };

                public static string AssemblyName = "System.Diagnostics.TraceSource";
                public static string AssemblyFile = "System.Diagnostics.TraceSource.dll";


            }

            public class Tracing : ILib
            {

                public static Tracing Default { get; } = new Tracing();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Diagnostics.Tracing";
                public static string AssemblyFile = "System.Diagnostics.Tracing.dll";


            }

        }

        public class DirectoryServices : ILib
        {

            public static DirectoryServices Default { get; } = new DirectoryServices();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.IO.FileSystem.AccessControl.Default, System.Security.Principal.Windows.Default, System.Security.AccessControl.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Primitives.Default, System.Net.Primitives.Default, System.Collections.Specialized.Default, System.Collections.NonGeneric.Default, System.Security.Permissions.Default, System.Net.NameResolution.Default, System.IO.FileSystem.Default, System.Security.Cryptography.Algorithms.Default, System.Threading.Thread.Default, Microsoft.Win32.Primitives.Default, System.Threading.Default, System.Security.Claims.Default, System.Net.Security.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.DirectoryServices", "System", "System.DirectoryServices", "System.DirectoryServices.Interop", "System.DirectoryServices.ActiveDirectory", "System.DirectoryServices.Design", };

            public static string AssemblyName = "System.DirectoryServices";
            public static string AssemblyFile = "System.DirectoryServices.dll";


        }

        public class Drawing : ILib
        {

            public static Drawing Default { get; } = new Drawing();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Drawing.Common.Default, System.Drawing.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.Configuration.ConfigurationManager.Default, System.Windows.Extensions.Default, System.Security.Permissions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Drawing";
            public static string AssemblyFile = "System.Drawing.dll";


            public class Common : ILib
            {

                public static Common Default { get; } = new Common();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Drawing.Primitives.Default, System.Diagnostics.TraceSource.Default, Microsoft.Win32.Primitives.Default, System.Threading.Thread.Default, System.ComponentModel.Primitives.Default, System.ObjectModel.Default, System.Collections.Default, System.Threading.Default, Microsoft.Win32.SystemEvents.Default, System.Collections.NonGeneric.Default, System.ComponentModel.Default, System.Memory.Default, System.IO.FileSystem.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Drawing.Common", "Microsoft.Win32.SafeHandles", "System", "System.Windows.Forms", "System.ComponentModel", "System.Drawing", "System.Drawing.Internal", "System.Drawing.Text", "System.Drawing.Imaging", "System.Drawing.Drawing2D", "System.Drawing.Design", "System.Drawing.Printing", };

                public static string AssemblyName = "System.Drawing.Common";
                public static string AssemblyFile = "System.Drawing.Common.dll";


            }

            public class Design : ILib
            {

                public static Design Default { get; } = new Design();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Windows.Forms.Design.Editors.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Drawing.Design";
                public static string AssemblyFile = "System.Drawing.Design.dll";


            }

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Drawing.Primitives", "System", "System.Numerics.Hashing", "System.Drawing", };

                public static string AssemblyName = "System.Drawing.Primitives";
                public static string AssemblyFile = "System.Drawing.Primitives.dll";


            }

        }

        public class Dynamic
        {

            public class Runtime : ILib
            {

                public static Runtime Default { get; } = new Runtime();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Linq.Expressions.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Dynamic.Runtime";
                public static string AssemblyFile = "System.Dynamic.Runtime.dll";


            }

        }

        public class Formats
        {

            public class Asn1 : ILib
            {

                public static Asn1 Default { get; } = new Asn1();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Collections.Default, System.Runtime.Numerics.Default, System.Memory.Default, System.Text.Encoding.Extensions.Default, System.Runtime.InteropServices.Default, System.Security.Cryptography.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Formats.Asn1", "System", "System.Formats.Asn1", "System.Security.Cryptography", };

                public static string AssemblyName = "System.Formats.Asn1";
                public static string AssemblyFile = "System.Formats.Asn1.dll";


            }

            public class Tar : ILib
            {

                public static Tar Default { get; } = new Tar();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Memory.Default, System.Collections.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Formats.Tar", "System", "System.IO", "System.Formats.Tar", };

                public static string AssemblyName = "System.Formats.Tar";
                public static string AssemblyFile = "System.Formats.Tar.dll";


            }

        }

        public class Globalization : ILib
        {

            public static Globalization Default { get; } = new Globalization();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Globalization";
            public static string AssemblyFile = "System.Globalization.dll";


            public class Calendars : ILib
            {

                public static Calendars Default { get; } = new Calendars();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Globalization.Calendars";
                public static string AssemblyFile = "System.Globalization.Calendars.dll";


            }

            public class Extensions : ILib
            {

                public static Extensions Default { get; } = new Extensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Globalization.Extensions";
                public static string AssemblyFile = "System.Globalization.Extensions.dll";


            }

        }

        public class IO : ILib
        {

            public static IO Default { get; } = new IO();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.IO";
            public static string AssemblyFile = "System.IO.dll";


            public class Compression : ILib
            {

                public static Compression Default { get; } = new Compression();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Threading.Default, System.Buffers.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.Compression", "System", "System.Threading.Tasks", "System.IO", "System.IO.Compression", };

                public static string AssemblyName = "System.IO.Compression";
                public static string AssemblyFile = "System.IO.Compression.dll";


                public class Brotli : ILib
                {

                    public static Brotli Default { get; } = new Brotli();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.IO.Compression.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Memory.Default, System.Buffers.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.Compression.Brotli", "Microsoft.Win32.SafeHandles", "System", "System.Threading.Tasks", "System.IO.Compression", };

                    public static string AssemblyName = "System.IO.Compression.Brotli";
                    public static string AssemblyFile = "System.IO.Compression.Brotli.dll";


                }

                public class FileSystem : ILib
                {

                    public static FileSystem Default { get; } = new FileSystem();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.Compression.ZipFile.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.IO.Compression.FileSystem";
                    public static string AssemblyFile = "System.IO.Compression.FileSystem.dll";


                }

                public class ZipFile : ILib
                {

                    public static ZipFile Default { get; } = new ZipFile();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.IO.Compression.Default, System.IO.FileSystem.Default, System.Buffers.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.Compression.ZipFile", "System", "System.IO", "System.IO.Compression", };

                    public static string AssemblyName = "System.IO.Compression.ZipFile";
                    public static string AssemblyFile = "System.IO.Compression.ZipFile.dll";


                }

            }

            public class FileSystem : ILib
            {

                public static FileSystem Default { get; } = new FileSystem();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Memory.Default, System.Buffers.Default, System.Linq.Default, System.Text.Encoding.Extensions.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.FileSystem", "Microsoft.Win32.SafeHandles", "System", "System.Text", "System.IO", "System.IO.Enumeration", };

                public static string AssemblyName = "System.IO.FileSystem";
                public static string AssemblyFile = "System.IO.FileSystem.dll";


                public class AccessControl : ILib
                {

                    public static AccessControl Default { get; } = new AccessControl();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Security.AccessControl.Default, System.Security.Principal.Windows.Default, System.IO.FileSystem.Default, System.Collections.Default, System.Buffers.Default, System.Memory.Default, System.Collections.NonGeneric.Default, System.Threading.Tasks.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.FileSystem.AccessControl", "Microsoft.Win32.SafeHandles", "System", "System.Security.AccessControl", "System.IO", };

                    public static string AssemblyName = "System.IO.FileSystem.AccessControl";
                    public static string AssemblyFile = "System.IO.FileSystem.AccessControl.dll";


                }

                public class DriveInfo : ILib
                {

                    public static DriveInfo Default { get; } = new DriveInfo();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.IO.FileSystem.Default, System.Threading.Tasks.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.FileSystem.DriveInfo", "System", "System.IO", };

                    public static string AssemblyName = "System.IO.FileSystem.DriveInfo";
                    public static string AssemblyFile = "System.IO.FileSystem.DriveInfo.dll";


                }

                public class Primitives : ILib
                {

                    public static Primitives Default { get; } = new Primitives();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.IO.FileSystem.Primitives";
                    public static string AssemblyFile = "System.IO.FileSystem.Primitives.dll";


                }

                public class Watcher : ILib
                {

                    public static Watcher Default { get; } = new Watcher();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Threading.Overlapped.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.Threading.Tasks.Default, System.IO.FileSystem.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.FileSystem.Watcher", "System", "System.IO", };

                    public static string AssemblyName = "System.IO.FileSystem.Watcher";
                    public static string AssemblyFile = "System.IO.FileSystem.Watcher.dll";


                }

            }

            public class IsolatedStorage : ILib
            {

                public static IsolatedStorage Default { get; } = new IsolatedStorage();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Algorithms.Default, System.Threading.Default, System.IO.FileSystem.Default, System.IO.FileSystem.AccessControl.Default, System.Security.Cryptography.Primitives.Default, System.Linq.Default, System.Security.AccessControl.Default, System.Security.Principal.Windows.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.IsolatedStorage", "System", "System.Security", "System.IO.IsolatedStorage", };

                public static string AssemblyName = "System.IO.IsolatedStorage";
                public static string AssemblyFile = "System.IO.IsolatedStorage.dll";


            }

            public class MemoryMappedFiles : ILib
            {

                public static MemoryMappedFiles Default { get; } = new MemoryMappedFiles();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.Threading.Tasks.Default, System.IO.FileSystem.Default, System.Threading.Thread.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.MemoryMappedFiles", "System", "System.IO", "System.IO.MemoryMappedFiles", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "System.IO.MemoryMappedFiles";
                public static string AssemblyFile = "System.IO.MemoryMappedFiles.dll";


            }

            public class Packaging : ILib
            {

                public static Packaging Default { get; } = new Packaging();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.Packaging", "System", "System.IO", "System.IO.Packaging", };

                public static string AssemblyName = "System.IO.Packaging";
                public static string AssemblyFile = "System.IO.Packaging.dll";


            }

            public class Pipelines : ILib
            {

                public static Pipelines Default { get; } = new Pipelines();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Memory.Default, System.Threading.Default, System.Diagnostics.Debug.Default, System.Buffers.Default, System.Collections.Default, System.Threading.Tasks.Default, System.Runtime.Extensions.Default, System.Threading.ThreadPool.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.IO.Pipelines", "System", "System.IO.Pipelines", "System.Threading.Tasks", };

                public static string AssemblyName = "System.IO.Pipelines";
                public static string AssemblyFile = "System.IO.Pipelines.dll";


            }

            public class Pipes : ILib
            {

                public static Pipes Default { get; } = new Pipes();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Threading.Overlapped.Default, System.Resources.ResourceManager.Default, System.Security.Principal.Default, System.Threading.Default, System.Security.Principal.Windows.Default, System.Security.AccessControl.Default, System.Threading.Tasks.Default, System.Memory.Default, System.Collections.NonGeneric.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.IO.Pipes", "System", "System.Threading.Tasks", "System.IO", "System.IO.Pipes", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "System.IO.Pipes";
                public static string AssemblyFile = "System.IO.Pipes.dll";


                public class AccessControl : ILib
                {

                    public static AccessControl Default { get; } = new AccessControl();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.IO.Pipes.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.IO.Pipes.AccessControl";
                    public static string AssemblyFile = "System.IO.Pipes.AccessControl.dll";


                }

            }

            public class UnmanagedMemoryStream : ILib
            {

                public static UnmanagedMemoryStream Default { get; } = new UnmanagedMemoryStream();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.IO.UnmanagedMemoryStream";
                public static string AssemblyFile = "System.IO.UnmanagedMemoryStream.dll";


            }

        }

        public class Linq : ILib
        {

            public static Linq Default { get; } = new Linq();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Diagnostics.Tools.Default, System.Runtime.Extensions.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.Linq", "System", "System.Collections.Generic", "System.Linq", };

            public static string AssemblyName = "System.Linq";
            public static string AssemblyFile = "System.Linq.dll";


            public class Expressions : ILib
            {

                public static Expressions Default { get; } = new Expressions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Reflection.Emit.ILGeneration.Default, System.Runtime.Extensions.Default, System.Diagnostics.Tools.Default, System.Reflection.Emit.Default, System.ObjectModel.Default, System.Reflection.Primitives.Default, System.Reflection.Emit.Lightweight.Default, System.Threading.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Linq.Expressions", "System", "System.Runtime.CompilerServices", "System.Linq", "System.Linq.Expressions", "System.Linq.Expressions.Interpreter", "System.Linq.Expressions.Compiler", "System.Dynamic", "System.Dynamic.Utils", "System.Collections.Generic", };

                public static string AssemblyName = "System.Linq.Expressions";
                public static string AssemblyFile = "System.Linq.Expressions.dll";


            }

            public class Parallel : ILib
            {

                public static Parallel Default { get; } = new Parallel();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Linq.Default, System.Diagnostics.Tools.Default, System.Collections.Concurrent.Default, System.Threading.Default, System.Diagnostics.Debug.Default, System.Threading.Tasks.Default, System.Diagnostics.Tracing.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Linq.Parallel", "System", "System.Linq", "System.Linq.Parallel", };

                public static string AssemblyName = "System.Linq.Parallel";
                public static string AssemblyFile = "System.Linq.Parallel.dll";


            }

            public class Queryable : ILib
            {

                public static Queryable Default { get; } = new Queryable();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Diagnostics.Debug.Default, System.Resources.ResourceManager.Default, System.Linq.Expressions.Default, System.Collections.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Linq.Queryable", "System", "System.Linq", };

                public static string AssemblyName = "System.Linq.Queryable";
                public static string AssemblyFile = "System.Linq.Queryable.dll";


            }

        }

        public class Memory : ILib
        {

            public static Memory Default { get; } = new Memory();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Memory", "System", "System.Numerics.Hashing", "System.Runtime.InteropServices", "System.Buffers", "System.Buffers.Text", };

            public static string AssemblyName = "System.Memory";
            public static string AssemblyFile = "System.Memory.dll";


        }

        public class Net : ILib
        {

            public static Net Default { get; } = new Net();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Net.Primitives.Default, System.Net.WebClient.Default, System.Net.WebHeaderCollection.Default, System.Net.Requests.Default, System.Net.NetworkInformation.Default, System.Security.Permissions.Default, System.Net.Sockets.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Net";
            public static string AssemblyFile = "System.Net.dll";


            public class Http : ILib
            {

                public static Http Default { get; } = new Http();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Diagnostics.Debug.Default, System.Security.Cryptography.X509Certificates.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Threading.Default, System.Diagnostics.Tracing.Default, System.Net.Primitives.Default, System.Security.Principal.Windows.Default, System.Net.Sockets.Default, System.Net.Security.Default, Microsoft.Win32.Primitives.Default, System.Security.Cryptography.Encoding.Default, System.Threading.Tasks.Default, System.Security.Cryptography.Primitives.Default, System.Net.NameResolution.Default, System.Memory.Default, System.Threading.Timer.Default, System.Collections.Concurrent.Default, System.Text.RegularExpressions.Default, System.Net.NetworkInformation.Default, System.Diagnostics.DiagnosticSource.Default, System.Collections.NonGeneric.Default, System.Buffers.Default, System.Security.Cryptography.Algorithms.Default, System.IO.Compression.Default, System.IO.Compression.Brotli.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.Http", "System", "System.Threading.Tasks", "System.Collections.Generic", "System.Text", "System.IO", "System.Net", "System.Net.Mime", "System.Net.Mail", "System.Net.Sockets", "System.Net.Security", "System.Net.Http", "System.Net.Http.HPack", "System.Net.Http.Headers", };

                public static string AssemblyName = "System.Net.Http";
                public static string AssemblyFile = "System.Net.Http.dll";


                public class Json : ILib
                {

                    public static Json Default { get; } = new Json();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Net.Http.Default, System.Text.Json.Default, System.Net.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Net.Http.Json", "System", "System.Net.Http.Json", };

                    public static string AssemblyName = "System.Net.Http.Json";
                    public static string AssemblyFile = "System.Net.Http.Json.dll";


                }

            }

            public class HttpListener : ILib
            {

                public static HttpListener Default { get; } = new HttpListener();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Threading.Overlapped.Default, System.Net.WebHeaderCollection.Default, System.Collections.Default, System.Security.Cryptography.X509Certificates.Default, System.Resources.ResourceManager.Default, System.Net.Security.Default, System.Collections.Specialized.Default, System.Security.Principal.Default, System.Security.Principal.Windows.Default, Microsoft.Win32.Primitives.Default, System.Threading.Default, System.Security.Claims.Default, System.Diagnostics.Tracing.Default, System.Net.WebSockets.Default, System.Security.Cryptography.Algorithms.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Threading.Timer.Default, System.Net.Requests.Default, System.Net.NameResolution.Default, System.Text.Encoding.Extensions.Default, System.Collections.NonGeneric.Default, System.Memory.Default, System.Security.Cryptography.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Net.HttpListener", "Microsoft.Win32.SafeHandles", "System", "System.Collections.Generic", "System.Net", "System.Net.Security", "System.Net.WebSockets", };

                public static string AssemblyName = "System.Net.HttpListener";
                public static string AssemblyFile = "System.Net.HttpListener.dll";


            }

            public class Mail : ILib
            {

                public static Mail Default { get; } = new Mail();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.X509Certificates.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Collections.Specialized.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Diagnostics.Tracing.Default, System.Net.Sockets.Default, System.Net.Security.Default, System.Threading.Default, System.Security.Principal.Windows.Default, System.Net.Primitives.Default, Microsoft.Win32.Primitives.Default, System.Net.Requests.Default, System.ComponentModel.EventBasedAsync.Default, System.Threading.Timer.Default, System.Net.ServicePoint.Default, System.Memory.Default, System.Net.NetworkInformation.Default, System.IO.FileSystem.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Net.Mail", "System", "System.Collections.Generic", "System.Net", "System.Net.Security", "System.Net.Mail", "System.Net.Mime", };

                public static string AssemblyName = "System.Net.Mail";
                public static string AssemblyFile = "System.Net.Mail.dll";


            }

            public class NameResolution : ILib
            {

                public static NameResolution Default { get; } = new NameResolution();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Threading.Overlapped.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.Collections.Default, System.Threading.Default, System.Security.Principal.Windows.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.NameResolution", "Microsoft.Win32.SafeHandles", "System", "System.Net", "System.Net.Sockets", "System.Net.Internals", };

                public static string AssemblyName = "System.Net.NameResolution";
                public static string AssemblyFile = "System.Net.NameResolution.dll";


            }

            public class NetworkInformation : ILib
            {

                public static NetworkInformation Default { get; } = new NetworkInformation();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Net.Sockets.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.Threading.Default, System.Security.Principal.Windows.Default, System.Collections.Default, Microsoft.Win32.Primitives.Default, System.Memory.Default, System.Threading.ThreadPool.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.NetworkInformation", "Microsoft.Win32.SafeHandles", "System", "System.Net", "System.Net.Internals", "System.Net.NetworkInformation", };

                public static string AssemblyName = "System.Net.NetworkInformation";
                public static string AssemblyFile = "System.Net.NetworkInformation.dll";


            }

            public class Ping : ILib
            {

                public static Ping Default { get; } = new Ping();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.ComponentModel.Primitives.Default, System.Threading.Default, System.Threading.ThreadPool.Default, System.Threading.Tasks.Default, System.ComponentModel.EventBasedAsync.Default, System.Diagnostics.Debug.Default, System.Memory.Default, System.Net.NameResolution.Default, Microsoft.Win32.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.Ping", "Microsoft.Win32.SafeHandles", "System", "System.Net", "System.Net.Sockets", "System.Net.Internals", "System.Net.NetworkInformation", };

                public static string AssemblyName = "System.Net.Ping";
                public static string AssemblyFile = "System.Net.Ping.dll";


            }

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Algorithms.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Diagnostics.Debug.Default, System.Diagnostics.Tracing.Default, Microsoft.Win32.Primitives.Default, System.Memory.Default, System.Threading.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.Primitives", "Microsoft.Win32.SafeHandles", "System", "System.Text", "System.Security.Authentication", "System.Security.Authentication.ExtendedProtection", "System.Net", "System.Net.Cache", "System.Net.NetworkInformation", "System.Net.Security", "System.Net.Sockets", };

                public static string AssemblyName = "System.Net.Primitives";
                public static string AssemblyFile = "System.Net.Primitives.dll";


            }

            public class Quic : ILib
            {

                public static Quic Default { get; } = new Quic();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Security.Cryptography.X509Certificates.Default, System.Threading.Default, System.Diagnostics.Tracing.Default, System.Memory.Default, System.Net.Primitives.Default, System.Net.Security.Default, System.Security.Cryptography.Encoding.Default, System.Collections.Concurrent.Default, System.Threading.Channels.Default, System.Collections.NonGeneric.Default, System.Collections.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Net.Quic", "System", "System.IO", "System.Threading.Tasks", "System.Net", "System.Net.Quic", "System.Net.Quic.Implementations", "System.Net.Quic.Implementations.MsQuic", "System.Net.Quic.Implementations.MsQuic.Internal", "System.Net.Quic.Implementations.Mock", };

                public static string AssemblyName = "System.Net.Quic";
                public static string AssemblyFile = "System.Net.Quic.dll";


            }

            public class Requests : ILib
            {

                public static Requests Default { get; } = new Requests();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Specialized.Default, System.Net.Primitives.Default, System.Net.WebHeaderCollection.Default, System.Threading.Default, System.Net.Http.Default, System.Net.ServicePoint.Default, System.Threading.Tasks.Default, System.Security.Cryptography.X509Certificates.Default, System.Net.Security.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Security.Principal.Default, System.Net.Sockets.Default, System.Diagnostics.Tracing.Default, System.Security.Principal.Windows.Default, System.Memory.Default, System.Threading.Thread.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.Requests", "System", "System.Threading.Tasks", "System.Net", "System.Net.Cache", };

                public static string AssemblyName = "System.Net.Requests";
                public static string AssemblyFile = "System.Net.Requests.dll";


            }

            public class Security : ILib
            {

                public static Security Default { get; } = new Security();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.X509Certificates.Default, System.Collections.Default, System.Resources.ResourceManager.Default, System.Net.Primitives.Default, System.Collections.NonGeneric.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Diagnostics.Tracing.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, System.Security.Cryptography.Encoding.Default, System.Collections.Concurrent.Default, System.Security.Principal.Default, System.Security.Principal.Windows.Default, System.Memory.Default, System.Buffers.Default, System.Threading.ThreadPool.Default, System.Security.Claims.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Net.Security", "System", "System.Collections.Generic", "System.Threading.Tasks", "System.Security.Authentication", "System.Security.Authentication.ExtendedProtection", "System.Net", "System.Net.Security", };

                public static string AssemblyName = "System.Net.Security";
                public static string AssemblyFile = "System.Net.Security.dll";


            }

            public class ServicePoint : ILib
            {

                public static ServicePoint Default { get; } = new ServicePoint();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Net.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, System.Collections.Concurrent.Default, System.Net.Security.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.ServicePoint", "System", "System.Net", };

                public static string AssemblyName = "System.Net.ServicePoint";
                public static string AssemblyFile = "System.Net.ServicePoint.dll";


            }

            public class Sockets : ILib
            {

                public static Sockets Default { get; } = new Sockets();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Threading.Overlapped.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.Collections.Default, System.Threading.Default, System.Security.Principal.Windows.Default, System.Threading.Tasks.Default, System.Memory.Default, System.Net.NameResolution.Default, System.IO.FileSystem.Default, System.Buffers.Default, System.Threading.ThreadPool.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.Sockets", "System", "System.Net", "System.Net.Internals", "System.Net.Sockets", };

                public static string AssemblyName = "System.Net.Sockets";
                public static string AssemblyFile = "System.Net.Sockets.dll";


            }

            public class WebClient : ILib
            {

                public static WebClient Default { get; } = new WebClient();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.EventBasedAsync.Default, System.Net.Primitives.Default, System.Net.WebHeaderCollection.Default, System.Collections.Specialized.Default, System.Net.Requests.Default, System.Threading.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.IO.FileSystem.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.WebClient", "System", "System.Threading.Tasks", "System.IO", "System.Net", "System.Net.Http", };

                public static string AssemblyName = "System.Net.WebClient";
                public static string AssemblyFile = "System.Net.WebClient.dll";


            }

            public class WebHeaderCollection : ILib
            {

                public static WebHeaderCollection Default { get; } = new WebHeaderCollection();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Specialized.Default, System.Collections.Default, System.Diagnostics.Tracing.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.WebHeaderCollection", "System", "System.Net", };

                public static string AssemblyName = "System.Net.WebHeaderCollection";
                public static string AssemblyFile = "System.Net.WebHeaderCollection.dll";


            }

            public class WebProxy : ILib
            {

                public static WebProxy Default { get; } = new WebProxy();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Net.Primitives.Default, System.Text.RegularExpressions.Default, System.Net.NetworkInformation.Default, System.Net.NameResolution.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Net", };

                public static string AssemblyName = "System.Net.WebProxy";
                public static string AssemblyFile = "System.Net.WebProxy.dll";


            }

            public class WebSockets : ILib
            {

                public static WebSockets Default { get; } = new WebSockets();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Security.Cryptography.Algorithms.Default, System.Text.Encoding.Extensions.Default, System.Threading.Timer.Default, System.Threading.Tasks.Default, System.Threading.Default, System.Numerics.Vectors.Default, System.Diagnostics.Debug.Default, System.Collections.Specialized.Default, System.Net.Primitives.Default, System.Security.Principal.Default, Microsoft.Win32.Primitives.Default, System.Buffers.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.WebSockets", "System", "System.Net.WebSockets", };

                public static string AssemblyName = "System.Net.WebSockets";
                public static string AssemblyFile = "System.Net.WebSockets.dll";


                public class Client : ILib
                {

                    public static Client Default { get; } = new Client();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Tracing.Default, System.Net.Primitives.Default, System.Net.WebSockets.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Net.Security.Default, System.Security.Cryptography.X509Certificates.Default, System.Net.WebHeaderCollection.Default, System.Collections.Default, System.Net.Http.Default, System.Security.Cryptography.Algorithms.Default, System.Threading.Default, System.Collections.Specialized.Default, System.Security.Cryptography.Primitives.Default, System.Collections.NonGeneric.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Net.WebSockets.Client", "System", "System.Net", "System.Net.WebSockets", };

                    public static string AssemblyName = "System.Net.WebSockets.Client";
                    public static string AssemblyFile = "System.Net.WebSockets.Client.dll";


                }

            }

        }

        public class Numerics : ILib
        {

            public static Numerics Default { get; } = new Numerics();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Numerics.Default, System.Numerics.Vectors.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Numerics";
            public static string AssemblyFile = "System.Numerics.dll";


            public class Vectors : ILib
            {

                public static Vectors Default { get; } = new Vectors();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Numerics.Vectors", "System", "System.Numerics", "System.Numerics.Hashing", };

                public static string AssemblyName = "System.Numerics.Vectors";
                public static string AssemblyFile = "System.Numerics.Vectors.dll";


            }

        }

        public class ObjectModel : ILib
        {

            public static ObjectModel Default { get; } = new ObjectModel();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Threading.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.ObjectModel", "System", "System.Windows.Input", "System.Windows.Markup", "System.Reflection", "System.ComponentModel", "System.Collections.ObjectModel", "System.Collections.Specialized", "System.Collections.Generic", };

            public static string AssemblyName = "System.ObjectModel";
            public static string AssemblyFile = "System.ObjectModel.dll";


        }

        public class Printing : ILib
        {

            public static Printing Default { get; } = new Printing();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { mscorlib.Default, System.Runtime.Default, System.Runtime.Extensions.Default, System.Runtime.InteropServices.Default, System.Runtime.CompilerServices.VisualC.Default, Microsoft.CSharp.Default, Microsoft.VisualBasic.Core.Default, Microsoft.VisualBasic.Default, Microsoft.Win32.Primitives.Default, Microsoft.Win32.Registry.Default, netstandard.Default, System.AppContext.Default, System.Buffers.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Collections.Immutable.Default, System.Collections.NonGeneric.Default, System.Collections.Specialized.Default, System.ComponentModel.Annotations.Default, System.ComponentModel.DataAnnotations.Default, System.ComponentModel.Default, System.ComponentModel.EventBasedAsync.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.Configuration.Default, System.Console.Default, System.Core.Default, System.Data.Common.Default, System.Data.DataSetExtensions.Default, System.Data.Default, System.Diagnostics.Contracts.Default, System.Diagnostics.Debug.Default, System.Diagnostics.DiagnosticSource.Default, System.Diagnostics.FileVersionInfo.Default, System.Diagnostics.Process.Default, System.Diagnostics.StackTrace.Default, System.Diagnostics.TextWriterTraceListener.Default, System.Diagnostics.Tools.Default, System.Diagnostics.TraceSource.Default, System.Diagnostics.Tracing.Default, System.Default, System.Drawing.Default, System.Drawing.Primitives.Default, System.Dynamic.Runtime.Default, System.Globalization.Calendars.Default, System.Globalization.Default, System.Globalization.Extensions.Default, System.IO.Compression.Brotli.Default, System.IO.Compression.Default, System.IO.Compression.FileSystem.Default, System.IO.Compression.ZipFile.Default, System.IO.Default, System.IO.FileSystem.Default, System.IO.FileSystem.DriveInfo.Default, System.IO.FileSystem.Primitives.Default, System.IO.FileSystem.Watcher.Default, System.IO.IsolatedStorage.Default, System.IO.MemoryMappedFiles.Default, System.IO.Packaging.Default, System.IO.Pipes.Default, System.IO.UnmanagedMemoryStream.Default, System.Linq.Default, System.Linq.Expressions.Default, System.Linq.Parallel.Default, System.Linq.Queryable.Default, System.Memory.Default, System.Net.Default, System.Net.Http.Default, System.Net.HttpListener.Default, System.Net.Mail.Default, System.Net.NameResolution.Default, System.Net.NetworkInformation.Default, System.Net.Ping.Default, System.Net.Primitives.Default, System.Net.Requests.Default, System.Net.Security.Default, System.Net.ServicePoint.Default, System.Net.Sockets.Default, System.Net.WebClient.Default, System.Net.WebHeaderCollection.Default, System.Net.WebProxy.Default, System.Net.WebSockets.Client.Default, System.Net.WebSockets.Default, System.Numerics.Default, System.Numerics.Vectors.Default, System.ObjectModel.Default, System.Reflection.DispatchProxy.Default, System.Reflection.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Extensions.Default, System.Reflection.Metadata.Default, System.Reflection.Primitives.Default, System.Reflection.TypeExtensions.Default, System.Resources.Reader.Default, System.Resources.ResourceManager.Default, System.Resources.Writer.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Handles.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Runtime.InteropServices.WindowsRuntime.Default, System.Runtime.Intrinsics.Default, System.Runtime.Loader.Default, System.Runtime.Numerics.Default, System.Runtime.Serialization.Default, System.Runtime.Serialization.Formatters.Default, System.Runtime.Serialization.Json.Default, System.Runtime.Serialization.Primitives.Default, System.Runtime.Serialization.Xml.Default, System.Security.AccessControl.Default, System.Security.Claims.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Csp.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Default, System.Security.Principal.Default, System.Security.Principal.Windows.Default, System.Security.SecureString.Default, System.ServiceModel.Web.Default, System.ServiceProcess.Default, System.Text.Encoding.CodePages.Default, System.Text.Encoding.Default, System.Text.Encoding.Extensions.Default, System.Text.Encodings.Web.Default, System.Text.Json.Default, System.Text.RegularExpressions.Default, System.Threading.Channels.Default, System.Threading.Default, System.Threading.Overlapped.Default, System.Threading.Tasks.Dataflow.Default, System.Threading.Tasks.Default, System.Threading.Tasks.Extensions.Default, System.Threading.Tasks.Parallel.Default, System.Threading.Thread.Default, System.Threading.ThreadPool.Default, System.Threading.Timer.Default, System.Transactions.Default, System.Transactions.Local.Default, System.ValueTuple.Default, System.Web.Default, System.Web.HttpUtility.Default, System.Windows.Default, System.Xml.Default, System.Xml.Linq.Default, System.Xml.ReaderWriter.Default, System.Xml.Serialization.Default, System.Xml.XDocument.Default, System.Xml.XmlDocument.Default, System.Xml.XmlSerializer.Default, System.Xml.XPath.Default, System.Xml.XPath.XDocument.Default, WindowsBase.Default, System.Xaml.Default, PresentationFramework.Default, ReachFramework.Default, PresentationCore.Default, System.Printing.Default, netstandard.Default, };

            public string[] Namespaces { get; } = new string[] { "vc_attributes", "MS.Internal.PrintWin32Thunk", "MS.Internal.PrintWin32Thunk.DirectInteropForPrintQueue", "MS.Internal.PrintWin32Thunk.DirectInteropForJob", "MS.Internal.PrintWin32Thunk.Win32ApiThunk", "MS.Internal.PrintWin32Thunk.AttributeNameToInfoLevelMapping", "MS.Internal.PrintWin32Thunk.AttributeNameToInfoLevelMapping.PrintQueueThunk", "MS.Internal.PrintWin32Thunk.AttributeNameToInfoLevelMapping.DriverThunk", "MS.Internal.PrintWin32Thunk.AttributeNameToInfoLevelMapping.JobThunk", "System.Printing", "System.Windows.Xps", "System.Printing.IndexedProperties", "System.Printing.Activation", "Microsoft.Internal.GDIExporter", "<CppImplementationDetails>", "<CrtImplementationDetails>", };

            public static string AssemblyName = "System.Printing";
            public static string AssemblyFile = "System.Printing.dll";


        }

        public class Private
        {

            public class CoreLib : ILib
            {

                public static CoreLib Default { get; } = new CoreLib();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Windows.Foundation.Diagnostics", "System", "System.Private.CoreLib.Resources", "System.Numerics", "System.Numerics.Hashing", "System.Configuration.Assemblies", "System.ComponentModel", "System.Buffers", "System.Buffers.Text", "System.Buffers.Binary", "System.Threading", "System.Threading.Tasks", "System.Threading.Tasks.Sources", "System.Text", "System.Text.Unicode", "System.StubHelpers", "System.Security", "System.Security.Principal", "System.Security.Permissions", "System.Security.Cryptography", "System.Runtime", "System.Runtime.Serialization", "System.Runtime.Remoting", "System.Runtime.Intrinsics", "System.Runtime.Intrinsics.Arm.Arm64", "System.Runtime.Intrinsics.X86", "System.Runtime.ExceptionServices", "System.Runtime.ConstrainedExecution", "System.Runtime.Versioning", "System.Runtime.Loader", "System.Runtime.InteropServices", "System.Runtime.InteropServices.WindowsRuntime", "System.Runtime.InteropServices.CustomMarshalers", "System.Runtime.InteropServices.Expando", "System.Runtime.InteropServices.ComTypes", "System.Resources", "System.Reflection", "System.Reflection.Metadata", "System.Reflection.Emit", "System.IO", "System.Globalization", "System.Diagnostics", "System.Diagnostics.Contracts", "System.Diagnostics.CodeAnalysis", "System.Diagnostics.SymbolStore", "System.Diagnostics.Tracing", "System.Collections", "System.Collections.Concurrent", "System.Collections.ObjectModel", "System.Collections.Generic", "Microsoft.Reflection", "Microsoft.Win32", "Microsoft.Win32.SafeHandles", "Internal", "Internal.Resources", "Internal.Win32", "Internal.Win32.SafeHandles", "Internal.Threading.Tasks", "Internal.IO", "Internal.Runtime.CompilerServices", "Internal.Runtime.InteropServices", "Internal.Runtime.InteropServices.WindowsRuntime", };

                public static string AssemblyName = "System.Private.CoreLib";
                public static string AssemblyFile = "System.Private.CoreLib.dll";


            }

            public class DataContractSerialization : ILib
            {

                public static DataContractSerialization Default { get; } = new DataContractSerialization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Xml.ReaderWriter.Default, System.Text.Encoding.Extensions.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Primitives.Default, System.Runtime.Serialization.Primitives.Default, System.Xml.XmlSerializer.Default, System.Collections.NonGeneric.Default, System.Runtime.Serialization.Formatters.Default, System.Threading.Default, System.Linq.Default, System.Text.RegularExpressions.Default, System.Xml.XDocument.Default, System.Collections.Specialized.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Private.DataContractSerialization", "System", "System.Text", "System.Xml", "System.ServiceModel", "System.Runtime.Serialization", "System.Runtime.Serialization.Json", };

                public static string AssemblyName = "System.Private.DataContractSerialization";
                public static string AssemblyFile = "System.Private.DataContractSerialization.dll";


            }

            public class Uri : ILib
            {

                public static Uri Default { get; } = new Uri();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Private.Uri", "System", "System.Collections.Generic", };

                public static string AssemblyName = "System.Private.Uri";
                public static string AssemblyFile = "System.Private.Uri.dll";


            }

            public class Xml : ILib
            {

                public static Xml Default { get; } = new Xml();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Collections.Default, System.Diagnostics.Debug.Default, System.Security.Cryptography.Algorithms.Default, System.Resources.ResourceManager.Default, System.Threading.Tasks.Default, System.Diagnostics.TraceSource.Default, System.Text.RegularExpressions.Default, System.Net.Primitives.Default, System.Net.Requests.Default, System.Text.Encoding.Extensions.Default, System.Collections.NonGeneric.Default, System.Threading.Default, System.Diagnostics.Tools.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.Reflection.Primitives.Default, System.Diagnostics.Tracing.Default, System.Collections.Concurrent.Default, System.Linq.Expressions.Default, System.Memory.Default, System.Threading.Thread.Default, System.IO.FileSystem.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Private.Xml", "MS.Internal.Xml.XPath", "MS.Internal.Xml.Cache", "System", "System.Xml", "System.Xml.Extensions", "System.Xml.Schema", "System.Xml.Xsl", "System.Xml.Xsl.Xslt", "System.Xml.Xsl.XsltOld", "System.Xml.Xsl.XsltOld.Debugger", "System.Xml.Xsl.XPath", "System.Xml.Xsl.Runtime", "System.Xml.Xsl.Qil", "System.Xml.Xsl.IlGen", "System.Xml.XPath", "System.Xml.Resolvers", "System.Xml.Serialization", "System.Xml.Serialization.Configuration", "System.Text", };

                public static string AssemblyName = "System.Private.Xml";
                public static string AssemblyFile = "System.Private.Xml.dll";


                public class Linq : ILib
                {

                    public static Linq Default { get; } = new Linq();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Private.Xml.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Runtime.Extensions.Default, System.ObjectModel.Default, System.Diagnostics.Tools.Default, System.Threading.Default, System.Threading.Tasks.Default, System.Linq.Default, System.Threading.Thread.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Private.Xml.Linq", "System", "System.Xml.XPath", "System.Xml.Schema", "System.Xml.Linq", "System.Text", "System.Collections.Generic", };

                    public static string AssemblyName = "System.Private.Xml.Linq";
                    public static string AssemblyFile = "System.Private.Xml.Linq.dll";


                }

            }

        }

        public class Reflection : ILib
        {

            public static Reflection Default { get; } = new Reflection();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Reflection";
            public static string AssemblyFile = "System.Reflection.dll";


            public class DispatchProxy : ILib
            {

                public static DispatchProxy Default { get; } = new DispatchProxy();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Reflection.Emit.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Primitives.Default, System.Threading.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Reflection.DispatchProxy", "System", "System.Reflection", "System.Reflection.Emit", };

                public static string AssemblyName = "System.Reflection.DispatchProxy";
                public static string AssemblyFile = "System.Reflection.DispatchProxy.dll";


            }

            public class Emit : ILib
            {

                public static Emit Default { get; } = new Emit();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Reflection.Emit";
                public static string AssemblyFile = "System.Reflection.Emit.dll";


                public class ILGeneration : ILib
                {

                    public static ILGeneration Default { get; } = new ILGeneration();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Reflection.Emit.ILGeneration";
                    public static string AssemblyFile = "System.Reflection.Emit.ILGeneration.dll";


                }

                public class Lightweight : ILib
                {

                    public static Lightweight Default { get; } = new Lightweight();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Reflection.Emit.Lightweight";
                    public static string AssemblyFile = "System.Reflection.Emit.Lightweight.dll";


                }

            }

            public class Extensions : ILib
            {

                public static Extensions Default { get; } = new Extensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Reflection.Extensions";
                public static string AssemblyFile = "System.Reflection.Extensions.dll";


            }

            public class Metadata : ILib
            {

                public static Metadata Default { get; } = new Metadata();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Immutable.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.IO.Compression.Default, System.IO.MemoryMappedFiles.Default, System.Threading.Default, System.Text.Encoding.Extensions.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Reflection.Metadata", "System", "System.Reflection", "System.Reflection.PortableExecutable", "System.Reflection.Metadata", "System.Reflection.Metadata.Ecma335", "System.Reflection.Internal", };

                public static string AssemblyName = "System.Reflection.Metadata";
                public static string AssemblyFile = "System.Reflection.Metadata.dll";


            }

            public class Primitives : ILib
            {

                public static Primitives Default { get; } = new Primitives();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Reflection.Primitives";
                public static string AssemblyFile = "System.Reflection.Primitives.dll";


            }

            public class TypeExtensions : ILib
            {

                public static TypeExtensions Default { get; } = new TypeExtensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Reflection.TypeExtensions", "System", "System.Reflection", };

                public static string AssemblyName = "System.Reflection.TypeExtensions";
                public static string AssemblyFile = "System.Reflection.TypeExtensions.dll";


            }

        }

        public class Resources
        {

            public class Extensions : ILib
            {

                public static Extensions Default { get; } = new Extensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Resources.Extensions", "System", "System.Numerics.Hashing", "System.Diagnostics.CodeAnalysis", "System.IO", "System.Resources", "System.Resources.Extensions", };

                public static string AssemblyName = "System.Resources.Extensions";
                public static string AssemblyFile = "System.Resources.Extensions.dll";


            }

            public class Reader : ILib
            {

                public static Reader Default { get; } = new Reader();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Resources.Reader";
                public static string AssemblyFile = "System.Resources.Reader.dll";


            }

            public class ResourceManager : ILib
            {

                public static ResourceManager Default { get; } = new ResourceManager();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Resources.ResourceManager";
                public static string AssemblyFile = "System.Resources.ResourceManager.dll";


            }

            public class Writer : ILib
            {

                public static Writer Default { get; } = new Writer();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Resources.Writer", "System", "System.Resources", };

                public static string AssemblyName = "System.Resources.Writer";
                public static string AssemblyFile = "System.Resources.Writer.dll";


            }

        }

        public class Runtime : ILib
        {

            public static Runtime Default { get; } = new Runtime();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Private.Uri.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System", "System.Threading", "System.Runtime", "System.Runtime.ConstrainedExecution", "System.Reflection", "System.IO", "System.Collections.Generic", };

            public static string AssemblyName = "System.Runtime";
            public static string AssemblyFile = "System.Runtime.dll";


            public class CompilerServices
            {

                public class Unsafe : ILib
                {

                    public static Unsafe Default { get; } = new Unsafe();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Runtime.CompilerServices", "System.Runtime.Versioning", };

                    public static string AssemblyName = "System.Runtime.CompilerServices.Unsafe";
                    public static string AssemblyFile = "System.Runtime.CompilerServices.Unsafe.dll";


                }

                public class VisualC : ILib
                {

                    public static VisualC Default { get; } = new VisualC();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Runtime.CompilerServices", };

                    public static string AssemblyName = "System.Runtime.CompilerServices.VisualC";
                    public static string AssemblyFile = "System.Runtime.CompilerServices.VisualC.dll";


                }

            }

            public class Extensions : ILib
            {

                public static Extensions Default { get; } = new Extensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Private.Uri.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Runtime.Extensions", "System", "System.Text", "System.Threading.Tasks", "System.Security.Permissions", "System.Runtime", "System.Runtime.Versioning", "System.Reflection", "System.Net", "System.IO", "System.Diagnostics", "System.CodeDom.Compiler", };

                public static string AssemblyName = "System.Runtime.Extensions";
                public static string AssemblyFile = "System.Runtime.Extensions.dll";


            }

            public class Handles : ILib
            {

                public static Handles Default { get; } = new Handles();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Runtime.Handles";
                public static string AssemblyFile = "System.Runtime.Handles.dll";


            }

            public class InteropServices : ILib
            {

                public static InteropServices Default { get; } = new InteropServices();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Runtime.InteropServices", "System", "System.Security", "System.Runtime.InteropServices", "System.Runtime.InteropServices.ComTypes", };

                public static string AssemblyName = "System.Runtime.InteropServices";
                public static string AssemblyFile = "System.Runtime.InteropServices.dll";


                public class JavaScript : ILib
                {

                    public static JavaScript Default { get; } = new JavaScript();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Runtime.InteropServices.JavaScript", "System", "System.Runtime.InteropServices.JavaScript", };

                    public static string AssemblyName = "System.Runtime.InteropServices.JavaScript";
                    public static string AssemblyFile = "System.Runtime.InteropServices.JavaScript.dll";


                }

                public class RuntimeInformation : ILib
                {

                    public static RuntimeInformation Default { get; } = new RuntimeInformation();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.InteropServices.RuntimeInformation", "System", "System.Runtime.InteropServices", };

                    public static string AssemblyName = "System.Runtime.InteropServices.RuntimeInformation";
                    public static string AssemblyFile = "System.Runtime.InteropServices.RuntimeInformation.dll";


                }

                public class WindowsRuntime : ILib
                {

                    public static WindowsRuntime Default { get; } = new WindowsRuntime();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Runtime.InteropServices.WindowsRuntime";
                    public static string AssemblyFile = "System.Runtime.InteropServices.WindowsRuntime.dll";


                }

            }

            public class Intrinsics : ILib
            {

                public static Intrinsics Default { get; } = new Intrinsics();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Runtime.Intrinsics";
                public static string AssemblyFile = "System.Runtime.Intrinsics.dll";


            }

            public class Loader : ILib
            {

                public static Loader Default { get; } = new Loader();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Runtime.Loader";
                public static string AssemblyFile = "System.Runtime.Loader.dll";


            }

            public class Numerics : ILib
            {

                public static Numerics Default { get; } = new Numerics();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Buffers.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.Numerics", "System", "System.Text", "System.Globalization", "System.Numerics", };

                public static string AssemblyName = "System.Runtime.Numerics";
                public static string AssemblyFile = "System.Runtime.Numerics.dll";


            }

            public class Serialization : ILib
            {

                public static Serialization Default { get; } = new Serialization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Serialization.Primitives.Default, System.Runtime.Serialization.Xml.Default, System.Runtime.Serialization.Json.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Runtime.Serialization";
                public static string AssemblyFile = "System.Runtime.Serialization.dll";


                public class Formatters : ILib
                {

                    public static Formatters Default { get; } = new Formatters();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Collections.NonGeneric.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Runtime.CompilerServices.Unsafe.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.Serialization.Formatters", "System", "System.Collections", "System.Runtime.Serialization", "System.Runtime.Serialization.Formatters", "System.Runtime.Serialization.Formatters.Binary", };

                    public static string AssemblyName = "System.Runtime.Serialization.Formatters";
                    public static string AssemblyFile = "System.Runtime.Serialization.Formatters.dll";


                }

                public class Json : ILib
                {

                    public static Json Default { get; } = new Json();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.DataContractSerialization.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Runtime.Serialization.Json";
                    public static string AssemblyFile = "System.Runtime.Serialization.Json.dll";


                }

                public class Primitives : ILib
                {

                    public static Primitives Default { get; } = new Primitives();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.Serialization.Primitives", "System", "System.Runtime.Serialization", };

                    public static string AssemblyName = "System.Runtime.Serialization.Primitives";
                    public static string AssemblyFile = "System.Runtime.Serialization.Primitives.dll";


                }

                public class Xml : ILib
                {

                    public static Xml Default { get; } = new Xml();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.DataContractSerialization.Default, System.Runtime.Serialization.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Runtime.Serialization.Xml";
                    public static string AssemblyFile = "System.Runtime.Serialization.Xml.dll";


                }

            }

            public class WindowsRuntime : ILib
            {

                public static WindowsRuntime Default { get; } = new WindowsRuntime();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, Windows.Default, System.ObjectModel.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.WindowsRuntime", "Windows.UI", "Windows.Foundation", "System", "System.Resources", "System.Threading", "System.Threading.Tasks", "System.Runtime.InteropServices", "System.Runtime.InteropServices.WindowsRuntime", "System.IO", };

                public static string AssemblyName = "System.Runtime.WindowsRuntime";
                public static string AssemblyFile = "System.Runtime.WindowsRuntime.dll";


                public class UI
                {

                    public class Xaml : ILib
                    {

                        public static Xaml Default { get; } = new Xaml();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.NETCore.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.WindowsRuntime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, };

                        public string[] Namespaces { get; } = new string[] { "FxResources.System.Runtime.WindowsRuntime.UI.Xaml", "Windows.UI.Xaml", "Windows.UI.Xaml.Media", "Windows.UI.Xaml.Media.Media3D", "Windows.UI.Xaml.Media.Animation", "Windows.UI.Xaml.Markup", "Windows.UI.Xaml.Controls.Primitives", "Windows.UI.Xaml.Automation", "System", };

                        public static string AssemblyName = "System.Runtime.WindowsRuntime.UI.Xaml";
                        public static string AssemblyFile = "System.Runtime.WindowsRuntime.UI.Xaml.dll";


                    }

                }

            }

        }

        public class Security : ILib
        {

            public static Security Default { get; } = new Security();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Security.Cryptography.Pkcs.Default, System.Security.Cryptography.ProtectedData.Default, System.Windows.Extensions.Default, System.Security.Cryptography.Xml.Default, System.Security.Permissions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Security";
            public static string AssemblyFile = "System.Security.dll";


            public class AccessControl : ILib
            {

                public static AccessControl Default { get; } = new AccessControl();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Principal.Windows.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Threading.Default, System.Threading.Thread.Default, System.Collections.NonGeneric.Default, Microsoft.Win32.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.AccessControl", "Microsoft.Win32.SafeHandles", "System", "System.Security.Principal", "System.Security.AccessControl", };

                public static string AssemblyName = "System.Security.AccessControl";
                public static string AssemblyFile = "System.Security.AccessControl.dll";


            }

            public class Claims : ILib
            {

                public static Claims Default { get; } = new Claims();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Security.Principal.Default, System.Collections.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Claims", "System", "System.Security.Principal", "System.Security.Claims", };

                public static string AssemblyName = "System.Security.Claims";
                public static string AssemblyFile = "System.Security.Claims.dll";


            }

            public class Cryptography : ILib
            {

                public static Cryptography Default { get; } = new Cryptography();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Memory.Default, System.Collections.Concurrent.Default, System.Formats.Asn1.Default, System.Threading.Default, System.Runtime.Numerics.Default, System.Collections.Default, System.Text.Encoding.Extensions.Default, System.Threading.Thread.Default, System.Collections.NonGeneric.Default, System.Net.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Security.Cryptography", "Internal.NativeCrypto", "Internal.Cryptography", "Microsoft.Win32.SafeHandles", "System", "System.Threading.Tasks", "System.Security.Cryptography", "System.Security.Cryptography.X509Certificates", "System.Security.Cryptography.X509Certificates.Asn1", "System.Security.Cryptography.Pkcs", "System.Security.Cryptography.Asn1", "System.Security.Cryptography.Asn1.Pkcs7", "System.Security.Cryptography.Asn1.Pkcs12", "System.Buffers", "System.Formats.Asn1", };

                public static string AssemblyName = "System.Security.Cryptography";
                public static string AssemblyFile = "System.Security.Cryptography.dll";


                public class Algorithms : ILib
                {

                    public static Algorithms Default { get; } = new Algorithms();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Collections.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Runtime.Numerics.Default, System.Collections.Concurrent.Default, System.Memory.Default, System.Runtime.InteropServices.RuntimeInformation.Default, System.Threading.Default, System.Buffers.Default, System.Text.Encoding.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Algorithms", "Microsoft.Win32.SafeHandles", "Internal.NativeCrypto", "Internal.Cryptography", "System", "System.Buffers", "System.Security.Cryptography", "System.Security.Cryptography.Pkcs", "System.Security.Cryptography.Asn1", };

                    public static string AssemblyName = "System.Security.Cryptography.Algorithms";
                    public static string AssemblyFile = "System.Security.Cryptography.Algorithms.dll";


                }

                public class Cng : ILib
                {

                    public static Cng Default { get; } = new Cng();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.Algorithms.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.Collections.Default, System.Runtime.Numerics.Default, System.Memory.Default, System.Buffers.Default, System.Text.Encoding.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Cng", "Internal.NativeCrypto", "Internal.Cryptography", "Microsoft.Win32.SafeHandles", "System", "System.Buffers", "System.Security.Cryptography", "System.Security.Cryptography.Pkcs", "System.Security.Cryptography.Asn1", };

                    public static string AssemblyName = "System.Security.Cryptography.Cng";
                    public static string AssemblyFile = "System.Security.Cryptography.Cng.dll";


                }

                public class Csp : ILib
                {

                    public static Csp Default { get; } = new Csp();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.Algorithms.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.Memory.Default, System.Text.Encoding.Extensions.Default, System.Threading.Thread.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Csp", "Microsoft.Win32.SafeHandles", "Internal.Cryptography", "Internal.NativeCrypto", "System", "System.Security.Cryptography", };

                    public static string AssemblyName = "System.Security.Cryptography.Csp";
                    public static string AssemblyFile = "System.Security.Cryptography.Csp.dll";


                }

                public class Encoding : ILib
                {

                    public static Encoding Default { get; } = new Encoding();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Security.Cryptography.Primitives.Default, System.Collections.Concurrent.Default, System.Memory.Default, System.Linq.Default, System.Buffers.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Encoding", "System", "System.Security.Cryptography", "Internal.Cryptography", };

                    public static string AssemblyName = "System.Security.Cryptography.Encoding";
                    public static string AssemblyFile = "System.Security.Cryptography.Encoding.dll";


                }

                public class OpenSsl : ILib
                {

                    public static OpenSsl Default { get; } = new OpenSsl();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.OpenSsl", "System", "System.Security.Cryptography", };

                    public static string AssemblyName = "System.Security.Cryptography.OpenSsl";
                    public static string AssemblyFile = "System.Security.Cryptography.OpenSsl.dll";


                }

                public class Pkcs : ILib
                {

                    public static Pkcs Default { get; } = new Pkcs();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Cng.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.Algorithms.Default, System.Collections.Default, System.Security.Cryptography.Csp.Default, System.Resources.ResourceManager.Default, System.Runtime.Numerics.Default, System.Memory.Default, System.Threading.Default, System.Collections.NonGeneric.Default, System.Buffers.Default, System.Linq.Default, System.Text.Encoding.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Security.Cryptography.Pkcs", "Microsoft.Win32.SafeHandles", "Internal.Cryptography", "Internal.Cryptography.Pal.Windows", "Internal.Cryptography.Pal.AnyOS", "System", "System.Buffers", "System.Security.Cryptography", "System.Security.Cryptography.Xml", "System.Security.Cryptography.Pkcs", "System.Security.Cryptography.Pkcs.Asn1", "System.Security.Cryptography.Asn1", };

                    public static string AssemblyName = "System.Security.Cryptography.Pkcs";
                    public static string AssemblyFile = "System.Security.Cryptography.Pkcs.dll";


                }

                public class Primitives : ILib
                {

                    public static Primitives Default { get; } = new Primitives();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Buffers.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Primitives", "Internal.Cryptography", "System", "System.Threading.Tasks", "System.Security.Cryptography", };

                    public static string AssemblyName = "System.Security.Cryptography.Primitives";
                    public static string AssemblyFile = "System.Security.Cryptography.Primitives.dll";


                }

                public class ProtectedData : ILib
                {

                    public static ProtectedData Default { get; } = new ProtectedData();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, System.Memory.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.ProtectedData", "Internal.Cryptography", "System", "System.Security.Cryptography", };

                    public static string AssemblyName = "System.Security.Cryptography.ProtectedData";
                    public static string AssemblyFile = "System.Security.Cryptography.ProtectedData.dll";


                }

                public class X509Certificates : ILib
                {

                    public static X509Certificates Default { get; } = new X509Certificates();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Security.Cryptography.Cng.Default, System.Security.Cryptography.Encoding.Default, System.Security.Cryptography.Algorithms.Default, System.Security.Cryptography.Primitives.Default, System.Collections.Default, System.Runtime.Numerics.Default, System.Security.Cryptography.Csp.Default, System.Resources.ResourceManager.Default, System.Net.Primitives.Default, System.Collections.NonGeneric.Default, System.Memory.Default, System.Threading.Default, System.IO.FileSystem.Default, System.Buffers.Default, System.Linq.Default, System.Text.Encoding.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.X509Certificates", "Microsoft.Win32.SafeHandles", "Internal.Cryptography", "Internal.Cryptography.Pal", "Internal.Cryptography.Pal.Native", "System", "System.Buffers", "System.Security.Cryptography", "System.Security.Cryptography.X509Certificates", "System.Security.Cryptography.X509Certificates.Asn1", "System.Security.Cryptography.Asn1", };

                    public static string AssemblyName = "System.Security.Cryptography.X509Certificates";
                    public static string AssemblyFile = "System.Security.Cryptography.X509Certificates.dll";


                }

                public class Xml : ILib
                {

                    public static Xml Default { get; } = new Xml();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.AspNetCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, System.Security.Permissions.Default, System.Security.Cryptography.Pkcs.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Cryptography.Xml", "System", "System.Security.Cryptography.Xml", };

                    public static string AssemblyName = "System.Security.Cryptography.Xml";
                    public static string AssemblyFile = "System.Security.Cryptography.Xml.dll";


                }

            }

            public class Permissions : ILib
            {

                public static Permissions Default { get; } = new Permissions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Windows.Extensions.Default, System.Runtime.Extensions.Default, System.Collections.NonGeneric.Default, System.Threading.Default, System.Security.Cryptography.Primitives.Default, System.Security.Cryptography.X509Certificates.Default, System.Security.AccessControl.Default, System.Security.Cryptography.Csp.Default, System.Collections.Default, System.Security.Principal.Default, System.Text.RegularExpressions.Default, System.Data.Common.Default, System.ComponentModel.Primitives.Default, System.Threading.Thread.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Permissions", "System", "System.Xaml.Permissions", "System.Web", "System.Transactions", "System.ServiceProcess", "System.Security", "System.Security.Policy", "System.Security.Permissions", "System.Net", "System.Net.PeerToPeer", "System.Net.PeerToPeer.Collaboration", "System.Net.NetworkInformation", "System.Net.Mail", "System.Drawing.Printing", "System.Diagnostics", "System.Data.SqlClient", "System.Data.OracleClient", "System.Data.OleDb", "System.Data.Odbc", "System.Data.Common", "System.Configuration", };

                public static string AssemblyName = "System.Security.Permissions";
                public static string AssemblyFile = "System.Security.Permissions.dll";


            }

            public class Principal : ILib
            {

                public static Principal Default { get; } = new Principal();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Security.Principal", };

                public static string AssemblyName = "System.Security.Principal";
                public static string AssemblyFile = "System.Security.Principal.dll";


                public class Windows : ILib
                {

                    public static Windows Default { get; } = new Windows();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Security.Claims.Default, System.Security.Principal.Default, System.Threading.Default, System.Diagnostics.Debug.Default, Microsoft.Win32.Primitives.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Security.Principal.Windows", "System", "System.Security.Principal", "Microsoft.Win32.SafeHandles", };

                    public static string AssemblyName = "System.Security.Principal.Windows";
                    public static string AssemblyFile = "System.Security.Principal.Windows.dll";


                }

            }

            public class SecureString : ILib
            {

                public static SecureString Default { get; } = new SecureString();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Security.SecureString";
                public static string AssemblyFile = "System.Security.SecureString.dll";


            }

        }

        public class ServiceModel
        {

            public class Web : ILib
            {

                public static Web Default { get; } = new Web();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Serialization.Json.Default, new ExternalAssembly("System.ServiceModel.Syndication"), };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.ServiceModel.Web";
                public static string AssemblyFile = "System.ServiceModel.Web.dll";


            }

        }

        public class ServiceProcess : ILib
        {

            public static ServiceProcess Default { get; } = new ServiceProcess();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, new ExternalAssembly("System.ServiceProcess.ServiceController"),
                System.Security.Permissions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.ServiceProcess";
            public static string AssemblyFile = "System.ServiceProcess.dll";


        }

        public class Text
        {

            public class Encoding : ILib
            {

                public static Encoding Default { get; } = new Encoding();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Text.Encoding";
                public static string AssemblyFile = "System.Text.Encoding.dll";


                public class CodePages : ILib
                {

                    public static CodePages Default { get; } = new CodePages();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Threading.Default, System.Runtime.CompilerServices.Unsafe.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Text.Encoding.CodePages", "System", "System.Text", "Microsoft.Win32.SafeHandles", };

                    public static string AssemblyName = "System.Text.Encoding.CodePages";
                    public static string AssemblyFile = "System.Text.Encoding.CodePages.dll";


                }

                public class Extensions : ILib
                {

                    public static Extensions Default { get; } = new Extensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Text.Encoding.Extensions";
                    public static string AssemblyFile = "System.Text.Encoding.Extensions.dll";


                }

            }

            public class Encodings
            {

                public class Web : ILib
                {

                    public static Web Default { get; } = new Web();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Text", "System.Text.Unicode", "System.Text.Internal", "System.Text.Encodings.Web", "System.IO", };

                    public static string AssemblyName = "System.Text.Encodings.Web";
                    public static string AssemblyFile = "System.Text.Encodings.Web.dll";


                }

            }

            public class Json : ILib
            {

                public static Json Default { get; } = new Json();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Text.Encodings.Web.Default, System.Collections.Default, System.Memory.Default, System.Threading.Tasks.Default, System.Diagnostics.Debug.Default, System.Text.Encoding.Extensions.Default, System.Numerics.Vectors.Default, System.Collections.Concurrent.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Emit.ILGeneration.Default, System.Buffers.Default, System.Threading.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Reflection.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Text.Json", "System", "System.Text.Json", "System.Text.Json.Serialization", "System.Text.Json.Serialization.Converters", };

                public static string AssemblyName = "System.Text.Json";
                public static string AssemblyFile = "System.Text.Json.dll";


            }

            public class RegularExpressions : ILib
            {

                public static RegularExpressions Default { get; } = new RegularExpressions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Diagnostics.Debug.Default, System.Collections.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Emit.Lightweight.Default, System.Buffers.Default, System.Memory.Default, System.Threading.Default, System.Reflection.Primitives.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Text.RegularExpressions", "System", "System.Text", "System.Text.RegularExpressions", "System.Collections", "System.Collections.Generic", };

                public static string AssemblyName = "System.Text.RegularExpressions";
                public static string AssemblyFile = "System.Text.RegularExpressions.dll";


            }

        }

        public class Threading : ILib
        {

            public static Threading Default { get; } = new Threading();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Runtime.Extensions.Default, };

            public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Threading", "System", "System.Threading", };

            public static string AssemblyName = "System.Threading";
            public static string AssemblyFile = "System.Threading.dll";


            public class AccessControl : ILib
            {

                public static AccessControl Default { get; } = new AccessControl();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { netstandard.Default, System.Security.AccessControl.Default, System.Security.Principal.Windows.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Threading.AccessControl", "System", "System.Threading", "System.Security.AccessControl", };

                public static string AssemblyName = "System.Threading.AccessControl";
                public static string AssemblyFile = "System.Threading.AccessControl.dll";


            }

            public class Channels : ILib
            {

                public static Channels Default { get; } = new Channels();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Threading.ThreadPool.Default, System.Threading.Default, System.Diagnostics.Debug.Default, System.Threading.Tasks.Default, System.Collections.Default, System.Collections.Concurrent.Default, System.Runtime.Extensions.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Threading.Channels", "Internal", "System", "System.Threading.Channels", "System.Collections.Concurrent", "System.Collections.Generic", };

                public static string AssemblyName = "System.Threading.Channels";
                public static string AssemblyFile = "System.Threading.Channels.dll";


            }

            public class Overlapped : ILib
            {

                public static Overlapped Default { get; } = new Overlapped();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Threading.Overlapped";
                public static string AssemblyFile = "System.Threading.Overlapped.dll";


            }

            public class RateLimiting : ILib
            {

                public static RateLimiting Default { get; } = new RateLimiting();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Collections.Default, System.Threading.Default, System.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Threading.RateLimiting", "System", "System.Collections.Generic", "System.Threading.RateLimiting", };

                public static string AssemblyName = "System.Threading.RateLimiting";
                public static string AssemblyFile = "System.Threading.RateLimiting.dll";


            }

            public class Tasks : ILib
            {

                public static Tasks Default { get; } = new Tasks();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Threading.Tasks";
                public static string AssemblyFile = "System.Threading.Tasks.dll";


                public class Dataflow : ILib
                {

                    public static Dataflow Default { get; } = new Dataflow();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { netstandard.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "FxResources.System.Threading.Tasks.Dataflow", "Internal", "System", "System.Threading.Tasks", "System.Threading.Tasks.Dataflow", "System.Threading.Tasks.Dataflow.Internal", };

                    public static string AssemblyName = "System.Threading.Tasks.Dataflow";
                    public static string AssemblyFile = "System.Threading.Tasks.Dataflow.dll";


                }

                public class Extensions : ILib
                {

                    public static Extensions Default { get; } = new Extensions();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                    public string[] Namespaces { get; } = new string[] { };

                    public static string AssemblyName = "System.Threading.Tasks.Extensions";
                    public static string AssemblyFile = "System.Threading.Tasks.Extensions.dll";


                }

                public class Parallel : ILib
                {

                    public static Parallel Default { get; } = new Parallel();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Collections.Concurrent.Default, System.Threading.Tasks.Default, System.Diagnostics.Tracing.Default, System.Diagnostics.Debug.Default, System.Threading.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Threading.Tasks.Parallel", "System", "System.Threading", "System.Threading.Tasks", };

                    public static string AssemblyName = "System.Threading.Tasks.Parallel";
                    public static string AssemblyFile = "System.Threading.Tasks.Parallel.dll";


                }

            }

            public class Thread : ILib
            {

                public static Thread Default { get; } = new Thread();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System.Threading", };

                public static string AssemblyName = "System.Threading.Thread";
                public static string AssemblyFile = "System.Threading.Thread.dll";


            }

            public class ThreadPool : ILib
            {

                public static ThreadPool Default { get; } = new ThreadPool();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Threading.ThreadPool";
                public static string AssemblyFile = "System.Threading.ThreadPool.dll";


            }

            public class Timer : ILib
            {

                public static Timer Default { get; } = new Timer();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Threading.Timer";
                public static string AssemblyFile = "System.Threading.Timer.dll";


            }

        }

        public class Transactions : ILib
        {

            public static Transactions Default { get; } = new Transactions();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Transactions.Local.Default, System.Security.Permissions.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Transactions";
            public static string AssemblyFile = "System.Transactions.dll";


            public class Local : ILib
            {

                public static Local Default { get; } = new Local();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.Threading.Default, System.Runtime.Serialization.Formatters.Default, System.Threading.Timer.Default, System.Threading.Thread.Default, System.Threading.ThreadPool.Default, System.Diagnostics.Tracing.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Transactions.Local", "System", "System.Transactions", "System.Transactions.Configuration", "System.Transactions.Distributed", };

                public static string AssemblyName = "System.Transactions.Local";
                public static string AssemblyFile = "System.Transactions.Local.dll";


            }

        }

        public class ValueTuple : ILib
        {

            public static ValueTuple Default { get; } = new ValueTuple();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.ValueTuple";
            public static string AssemblyFile = "System.ValueTuple.dll";


        }

        public class Web : ILib
        {

            public static Web Default { get; } = new Web();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Web.HttpUtility.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Web";
            public static string AssemblyFile = "System.Web.dll";


            public class HttpUtility : ILib
            {

                public static HttpUtility Default { get; } = new HttpUtility();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Collections.Specialized.Default, System.Memory.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Web", "System.Web.Util", };

                public static string AssemblyName = "System.Web.HttpUtility";
                public static string AssemblyFile = "System.Web.HttpUtility.dll";


            }

        }

        public class Windows : ILib
        {

            public static Windows Default { get; } = new Windows();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.ObjectModel.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Windows";
            public static string AssemblyFile = "System.Windows.dll";


            public class Controls
            {

                public class Ribbon : ILib
                {

                    public static Ribbon Default { get; } = new Ribbon();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, PresentationFramework.Default, System.Xaml.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, WindowsBase.Default, PresentationCore.Default, System.Collections.Default, System.Runtime.Extensions.Default, System.ObjectModel.Default, System.Diagnostics.Debug.Default, System.ComponentModel.TypeConverter.Default, System.Collections.Specialized.Default, System.Xml.ReaderWriter.Default, System.ComponentModel.Primitives.Default, UIAutomationProvider.Default, UIAutomationTypes.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, System.ComponentModel.Default, System.Threading.Thread.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Windows.Controls.Ribbon", "MS.Internal", "System.Windows.Controls", "System.Windows.Controls.Ribbon", "System.Windows.Controls.Ribbon.Primitives", "System.Windows.Automation.Peers", "Microsoft.Windows.Input", "Microsoft.Windows.Controls", };

                    public static string AssemblyName = "System.Windows.Controls.Ribbon";
                    public static string AssemblyFile = "System.Windows.Controls.Ribbon.dll";


                }

            }

            public class Extensions : ILib
            {

                public static Extensions Default { get; } = new Extensions();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.AspNetCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Runtime.Extensions.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.EventBasedAsync.Default, System.Threading.Default, System.Threading.Tasks.Default, System.IO.FileSystem.Default, System.Net.Requests.Default, System.Diagnostics.Debug.Default, System.ComponentModel.TypeConverter.Default, System.Drawing.Common.Default, System.Security.Cryptography.X509Certificates.Default, System.Memory.Default, System.Buffers.Default, };

                public string[] Namespaces { get; } = new string[] { "FxResources.System.Windows.Extensions", "System", "System.Xaml.Permissions", "System.Media", "System.Drawing", "System.Drawing.Printing", "System.Text", "System.Security.Cryptography.X509Certificates", "Microsoft.Win32.SafeHandles", };

                public static string AssemblyName = "System.Windows.Extensions";
                public static string AssemblyFile = "System.Windows.Extensions.dll";


            }

            public class Forms : ILib
            {

                public static Forms Default { get; } = new Forms();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Drawing.Common.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Drawing.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Default, System.Runtime.Serialization.Formatters.Default, System.Xml.ReaderWriter.Default, System.Collections.Default, System.ObjectModel.Default, System.Collections.Specialized.Default, System.Resources.Writer.Default, System.Diagnostics.TraceSource.Default, System.ComponentModel.Primitives.Default, Accessibility.Default, System.Threading.Thread.Default, System.IO.FileSystem.Default, Microsoft.Win32.Registry.Default, System.Diagnostics.FileVersionInfo.Default, System.Diagnostics.Process.Default, System.Threading.Default, System.Collections.NonGeneric.Default, Microsoft.Win32.SystemEvents.Default, System.Diagnostics.Tools.Default, System.ComponentModel.EventBasedAsync.Default, System.Net.WebClient.Default, System.Net.Requests.Default, System.Collections.Concurrent.Default, System.Configuration.ConfigurationManager.Default, System.Text.RegularExpressions.Default, System.Reflection.Emit.Default, System.Diagnostics.StackTrace.Default, System.Linq.Default, Microsoft.Win32.Primitives.Default, System.Threading.ThreadPool.Default, System.Diagnostics.Debug.Default, System.Text.Encoding.Extensions.Default, System.Buffers.Default, System.Windows.Extensions.Default, System.Text.Encoding.CodePages.Default, System.Memory.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Console.Default, };

                public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Win32.SafeHandles", "System", "System.Drawing.Design", "System.Resources", "System.Windows.Forms", "System.Windows.Forms.VisualStyles", "System.Windows.Forms.PropertyGridInternal", "System.Windows.Forms.Layout", "System.Windows.Forms.Design", "System.Windows.Forms.ComponentModel.Com2Interop", "System.Windows.Forms.ButtonInternal", "System.Windows.Forms.Automation", "System.Windows.Forms.Internal", "System.ComponentModel", "System.Collections.Specialized", };

                public static string AssemblyName = "System.Windows.Forms";
                public static string AssemblyFile = "System.Windows.Forms.dll";


                public class Design : ILib
                {

                    public static Design Default { get; } = new Design();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Drawing.Primitives.Default, System.Runtime.InteropServices.Default, System.Drawing.Common.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Primitives.Default, System.Diagnostics.TraceSource.Default, System.Collections.Default, System.Collections.NonGeneric.Default, System.Windows.Forms.Default, System.ComponentModel.Default, Microsoft.Win32.Registry.Default, System.Configuration.ConfigurationManager.Default, System.Collections.Specialized.Default, System.CodeDom.Default, System.Resources.Writer.Default, System.ObjectModel.Default, Accessibility.Default, System.Windows.Forms.Design.Editors.Default, Microsoft.Win32.SystemEvents.Default, System.Diagnostics.Tools.Default, System.Diagnostics.Debug.Default, System.Linq.Default, System.Text.RegularExpressions.Default, System.Threading.Default, System.Threading.Thread.Default, Microsoft.Win32.Primitives.Default, System.Memory.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Runtime.Serialization.Formatters.Default, System.Buffers.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "System", "System.Runtime.InteropServices", "System.Drawing.Design", "System.ComponentModel", "System.ComponentModel.Design", "System.ComponentModel.Design.Serialization", "System.Windows.Forms", "System.Windows.Forms.Design", "System.Windows.Forms.Design.Behavior", "System.Windows.Forms.Design.Resources", };

                    public static string AssemblyName = "System.Windows.Forms.Design";
                    public static string AssemblyFile = "System.Windows.Forms.Design.dll";


                    public class Editors : ILib
                    {

                        public static Editors Default { get; } = new Editors();
                        public string Name => AssemblyName;
                        public string File => AssemblyFile;
                        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, System.Drawing.Primitives.Default, System.Runtime.InteropServices.Default, System.Collections.Default, System.Drawing.Common.Default, System.Windows.Forms.Default, System.ComponentModel.TypeConverter.Default, System.ComponentModel.Default, System.ComponentModel.Primitives.Default, Microsoft.Win32.Registry.Default, System.Diagnostics.TraceSource.Default, System.Collections.Specialized.Default, System.Configuration.ConfigurationManager.Default, System.Threading.Thread.Default, System.Buffers.Default, };

                        public string[] Namespaces { get; } = new string[] { "Microsoft.Win32.SafeHandles", "System", "System.Drawing.Design", "System.ComponentModel.Design", "System.Configuration", "System.Windows.Forms", "System.Windows.Forms.Design", "System.Windows.Forms.Design.Editors", };

                        public static string AssemblyName = "System.Windows.Forms.Design.Editors";
                        public static string AssemblyFile = "System.Windows.Forms.Design.Editors.dll";


                    }

                }

                public class Primitives : ILib
                {

                    public static Primitives Default { get; } = new Primitives();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Drawing.Primitives.Default, System.Numerics.Vectors.Default, System.Drawing.Common.Default, Accessibility.Default, System.Diagnostics.TraceSource.Default, System.ObjectModel.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.Collections.Default, System.Runtime.CompilerServices.Unsafe.Default, System.Memory.Default, Microsoft.Win32.Primitives.Default, System.Threading.Thread.Default, System.Threading.Default, System.IO.FileSystem.Default, System.Diagnostics.StackTrace.Default, };

                    public string[] Namespaces { get; } = new string[] { "Microsoft.CodeAnalysis", "System.Runtime.CompilerServices", "Microsoft.Win32.SafeHandles", "System", "System.ComponentModel", "System.Windows.Forms", "System.Windows.Forms.Primitives.Resources", "System.Windows.Forms.VisualStyles", "System.Windows.Forms.Automation", };

                    public static string AssemblyName = "System.Windows.Forms.Primitives";
                    public static string AssemblyFile = "System.Windows.Forms.Primitives.dll";


                }

            }

            public class Input
            {

                public class Manipulations : ILib
                {

                    public static Manipulations Default { get; } = new Manipulations();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Collections.Default, System.Runtime.Extensions.Default, };

                    public string[] Namespaces { get; } = new string[] { "FxResources.System.Windows.Input.Manipulations", "System", "System.Windows.Input.Manipulations", };

                    public static string AssemblyName = "System.Windows.Input.Manipulations";
                    public static string AssemblyFile = "System.Windows.Input.Manipulations.dll";


                }

            }

            public class Presentation : ILib
            {

                public static Presentation Default { get; } = new Presentation();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.ComponentModel.Primitives.Default, WindowsBase.Default, };

                public string[] Namespaces { get; } = new string[] { "System.Windows.Threading", };

                public static string AssemblyName = "System.Windows.Presentation";
                public static string AssemblyFile = "System.Windows.Presentation.dll";


            }

        }

        public class Xaml : ILib
        {

            public static Xaml Default { get; } = new Xaml();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Collections.Specialized.Default, System.Collections.Default, System.ComponentModel.TypeConverter.Default, System.Diagnostics.Debug.Default, System.Windows.Extensions.Default, System.Xml.ReaderWriter.Default, System.Runtime.Extensions.Default, System.Threading.Default, System.Threading.Thread.Default, System.ComponentModel.Default, System.ComponentModel.Primitives.Default, System.Collections.Concurrent.Default, System.Threading.ThreadPool.Default, System.ObjectModel.Default, System.Reflection.Emit.Lightweight.Default, System.Reflection.Emit.ILGeneration.Default, System.Reflection.Primitives.Default, System.Security.Permissions.Default, System.Text.Encoding.Extensions.Default, System.Runtime.Serialization.Formatters.Default, };

            public string[] Namespaces { get; } = new string[] { "FxResources.System.Xaml", "System", "System.Xaml", "System.Xaml.Replacements", "System.Xaml.MS.Impl", "System.Xaml.Schema", "System.Windows.Markup", "MS.Internal.WindowsBase", "MS.Internal.Xaml", "MS.Internal.Xaml.Runtime", "MS.Internal.Xaml.Parser", "MS.Internal.Xaml.Context", "MS.Internal.Serialization", };

            public static string AssemblyName = "System.Xaml";
            public static string AssemblyFile = "System.Xaml.dll";


        }

        public class Xml : ILib
        {

            public static Xml Default { get; } = new Xml();
            public string Name => AssemblyName;
            public string File => AssemblyFile;
            public string Sdk { get; } = "Microsoft.NETCore.App";

            public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

            public ILib[] References { get; } = new ILib[] { System.Private.CoreLib.Default, System.Private.Xml.Default, };

            public string[] Namespaces { get; } = new string[] { };

            public static string AssemblyName = "System.Xml";
            public static string AssemblyFile = "System.Xml.dll";


            public class Linq : ILib
            {

                public static Linq Default { get; } = new Linq();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Xml.XDocument.Default, System.Xml.XPath.XDocument.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.Linq";
                public static string AssemblyFile = "System.Xml.Linq.dll";


            }

            public class ReaderWriter : ILib
            {

                public static ReaderWriter Default { get; } = new ReaderWriter();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.Xml.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.ReaderWriter";
                public static string AssemblyFile = "System.Xml.ReaderWriter.dll";


            }

            public class Serialization : ILib
            {

                public static Serialization Default { get; } = new Serialization();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Xml.ReaderWriter.Default, System.Xml.XmlSerializer.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.Serialization";
                public static string AssemblyFile = "System.Xml.Serialization.dll";


            }

            public class XDocument : ILib
            {

                public static XDocument Default { get; } = new XDocument();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.Xml.Linq.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.XDocument";
                public static string AssemblyFile = "System.Xml.XDocument.dll";


            }

            public class XmlDocument : ILib
            {

                public static XmlDocument Default { get; } = new XmlDocument();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.Xml.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.XmlDocument";
                public static string AssemblyFile = "System.Xml.XmlDocument.dll";


            }

            public class XmlSerializer : ILib
            {

                public static XmlSerializer Default { get; } = new XmlSerializer();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.Xml.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.XmlSerializer";
                public static string AssemblyFile = "System.Xml.XmlSerializer.dll";


            }

            public class XPath : ILib
            {

                public static XPath Default { get; } = new XPath();
                public string Name => AssemblyName;
                public string File => AssemblyFile;
                public string Sdk { get; } = "Microsoft.NETCore.App";

                public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Private.Xml.Default, };

                public string[] Namespaces { get; } = new string[] { };

                public static string AssemblyName = "System.Xml.XPath";
                public static string AssemblyFile = "System.Xml.XPath.dll";


                public class XDocument : ILib
                {

                    public static XDocument Default { get; } = new XDocument();
                    public string Name => AssemblyName;
                    public string File => AssemblyFile;
                    public string Sdk { get; } = "Microsoft.NETCore.App";

                    public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

                    public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.Extensions.Default, System.Private.Xml.Default, System.Private.Xml.Linq.Default, };

                    public string[] Namespaces { get; } = new string[] { "System.Xml.XPath", };

                    public static string AssemblyName = "System.Xml.XPath.XDocument";
                    public static string AssemblyFile = "System.Xml.XPath.XDocument.dll";


                }

            }

        }

    }

    public class UIAutomationClient : ILib
    {

        public static UIAutomationClient Default { get; } = new UIAutomationClient();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, WindowsBase.Default, UIAutomationTypes.Default, UIAutomationProvider.Default, System.ComponentModel.EventBasedAsync.Default, System.Collections.NonGeneric.Default, Accessibility.Default, System.Diagnostics.Process.Default, System.Diagnostics.StackTrace.Default, System.Threading.Thread.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.UIAutomationClient", "System", "System.Windows.Automation", "System.Windows.Automation.Text", "MS.Win32", "MS.Internal.Automation", "MS.Internal.UIAutomationClient", "Microsoft.Internal", };

        public static string AssemblyName = "UIAutomationClient";
        public static string AssemblyFile = "UIAutomationClient.dll";


    }

    public class UIAutomationClientSideProviders : ILib
    {

        public static UIAutomationClientSideProviders Default { get; } = new UIAutomationClientSideProviders();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, UIAutomationClient.Default, WindowsBase.Default, Accessibility.Default, Microsoft.Win32.Primitives.Default, UIAutomationProvider.Default, UIAutomationTypes.Default, System.Collections.NonGeneric.Default, System.Threading.Default, System.Net.Primitives.Default, System.Diagnostics.Process.Default, System.Threading.Thread.Default, System.ComponentModel.Primitives.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.UIAutomationClientSideProviders", "UIAutomationClientsideProviders", "System", "MS.Win32", "MS.Internal.AutomationProxies", "MS.Internal.UIAutomationClientSideProviders", "Microsoft.Internal", };

        public static string AssemblyName = "UIAutomationClientSideProviders";
        public static string AssemblyFile = "UIAutomationClientSideProviders.dll";


    }

    public class UIAutomationProvider : ILib
    {

        public static UIAutomationProvider Default { get; } = new UIAutomationProvider();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, UIAutomationTypes.Default, WindowsBase.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.UIAutomationProvider", "System.Windows.Automation.Provider", "Microsoft.Internal", "MS.Internal.Automation", };

        public static string AssemblyName = "UIAutomationProvider";
        public static string AssemblyFile = "UIAutomationProvider.dll";


    }

    public class UIAutomationTypes : ILib
    {

        public static UIAutomationTypes Default { get; } = new UIAutomationTypes();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, System.Runtime.Extensions.Default, Accessibility.Default, WindowsBase.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, System.Threading.Thread.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.UIAutomationTypes", "System", "System.Windows.Automation", "System.Windows.Automation.Text", "MS.Win32", "MS.Internal", "MS.Internal.Automation", "MS.Internal.UIAutomationTypes", "MS.Internal.UIAutomationTypes.Interop", };

        public static string AssemblyName = "UIAutomationTypes";
        public static string AssemblyFile = "UIAutomationTypes.dll";


    }

    public class WindowsBase : ILib
    {

        public static WindowsBase Default { get; } = new WindowsBase();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.NETCore.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.ObjectModel.Default, System.IO.Packaging.Default, System.Security.Permissions.Default, };

        public string[] Namespaces { get; } = new string[] { };

        public static string AssemblyName = "WindowsBase";
        public static string AssemblyFile = "WindowsBase.dll";


    }

    public class WindowsFormsIntegration : ILib
    {

        public static WindowsFormsIntegration Default { get; } = new WindowsFormsIntegration();
        public string Name => AssemblyName;
        public string File => AssemblyFile;
        public string Sdk { get; } = "Microsoft.WindowsDesktop.App";

        public Version[] Versions { get; } = new Version[] { Libs.Version31, Libs.Version50, Libs.Version60, Libs.Version70, Libs.Version80, };

        public ILib[] References { get; } = new ILib[] { System.Runtime.Default, System.Xaml.Default, System.Runtime.InteropServices.Default, System.Resources.ResourceManager.Default, PresentationFramework.Default, WindowsBase.Default, System.Windows.Forms.Default, System.Collections.Default, PresentationCore.Default, System.Diagnostics.Debug.Default, System.Drawing.Common.Default, System.Runtime.Extensions.Default, System.Drawing.Primitives.Default, System.ComponentModel.Primitives.Default, System.ComponentModel.TypeConverter.Default, System.Diagnostics.TraceSource.Default, UIAutomationProvider.Default, System.Threading.Default, Microsoft.Win32.Primitives.Default, };

        public string[] Namespaces { get; } = new string[] { "FxResources.WindowsFormsIntegration", "System.Windows", "System.Windows.Forms.Integration", "System.Windows.Automation.Peers", "MS.Win32", "MS.Internal.WinFormsIntegration", "Microsoft.Internal", };

        public static string AssemblyName = "WindowsFormsIntegration";
        public static string AssemblyFile = "WindowsFormsIntegration.dll";


    }


}
