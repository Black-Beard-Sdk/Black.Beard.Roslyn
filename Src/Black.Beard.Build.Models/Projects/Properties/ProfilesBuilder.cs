using Newtonsoft.Json.Linq;

namespace Bb.Projects.Properties
{
    public class ProfilesBuilder : BuilderBase
    {

        public ProfilesBuilder(string name)
        {
            this._name = name;
        }

        public ProfilesBuilder CommandName(string value)
        {
            Add("commandName", value);
            return this;
        }

        public ProfilesBuilder AuthenticationModeNone()
        {
            Add("authenticationMode", "None");
            return this;
        }

        public ProfilesBuilder AuthenticationModeWindows()
        {
            Add("authenticationMode", "Windows");
            return this;
        }

        public ProfilesBuilder AncmHostingModelInProcess()
        {
            Add("ancmHostingModel", "InProcess");
            return this;
        }

        public ProfilesBuilder AncmHostingModelOutOfProcess()
        {
            Add("ancmHostingModel", "OutOfProcess");
            return this;
        }

        public ProfilesBuilder CommandLineArgs(string value)
        {
            Add("commandLineArgs", value);
            return this;
        }

        public ProfilesBuilder ExecutablePath(string value)
        {
            Add("executablePath", value);
            return this;
        }
        public ProfilesBuilder InspectUri(Uri value)
        {
            Add("inspectUri", value);
            return this;
        }

        public ProfilesBuilder RemoteDebugMachine(string value)
        {
            Add("remoteDebugMachine", value);
            return this;
        }

        public ProfilesBuilder WorkingDirectory(string value)
        {
            Add("workingDirectory", value);
            return this;
        }

        public ProfilesBuilder TargetProject(string value)
        {
            Add("targetProject", value);
            return this;
        }

        public ProfilesBuilder LaunchBrowser(bool value)
        {
            Add("launchBrowser", value);
            return this;
        }

        public ProfilesBuilder DotnetRunMessages(bool value)
        {
            Add("dotnetRunMessages", value);
            return this;
        }

        public ProfilesBuilder PublishAllPorts(bool value)
        {
            Add("publishAllPorts", value);
            return this;
        }

        public ProfilesBuilder UseSSL(bool value)
        {
            Add("useSSL", value);
            return this;
        }

        public ProfilesBuilder Use64Bit(bool value)
        {
            Add("use64Bit", value);
            return this;
        }

        public ProfilesBuilder SqlDebugging(bool value)
        {
            Add("sqlDebugging", value);
            return this;
        }

        public ProfilesBuilder RemoteDebugEnabled(bool value)
        {
            Add("remoteDebugEnabled", value);
            return this;
        }

        public ProfilesBuilder NativeDebugging(bool value)
        {
            Add("nativeDebugging", value);
            return this;
        }

        public ProfilesBuilder LeaveRunningOnClose(bool value)
        {
            Add("leaveRunningOnClose", value);
            return this;
        }

        public ProfilesBuilder JsWebView2Debugging(bool value)
        {
            Add("jsWebView2Debugging", value);
            return this;
        }

        public ProfilesBuilder HotReloadEnabled(bool value)
        {
            Add("hotReloadEnabled", value);
            return this;
        }

        public ProfilesBuilder ExternalUrlConfiguration(bool value)
        {
            Add("externalUrlConfiguration", value);
            return this;
        }

        public ProfilesBuilder WindowsAuthentication(bool value)
        {
            Add("windowsAuthentication", value);
            return this;
        }

        public ProfilesBuilder AnonymousAuthentication(bool value)
        {
            Add("anonymousAuthentication", value);
            return this;
        }

        public ProfilesBuilder LaunchUrl(string value)
        {
            Add("launchUrl", value);
            return this;
        }

        public ProfilesBuilder SslPort(int value)
        {
            Add("sslPort", value);
            return this;
        }

        public ProfilesBuilder HttpPort(int value)
        {
            Add("httpPort", value);
            return this;
        }

        public ProfilesBuilder ApplicationUrl(params Uri[] values)
        {
            Add("applicationUrl", values);
            return this;
        }

        public ProfilesBuilder EnvironmentVariables(Action<EnironmentVariablesBuilder> action)
        {

            var builder = new EnironmentVariablesBuilder();
            action(builder);
            Add("environmentVariables", builder);
            return this;
        }

        internal override JToken GetModel()
        {

            List<JToken> list = new List<JToken>();

            foreach (var item in base.GetItems())
                list.Add(new JProperty(item.Key, item.Value.GetModel()));

            return new JProperty(_name,  new JObject(list));

        }

        private readonly string _name;


    }


}
