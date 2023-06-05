using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Projects.Properties
{

    public class LaunchSettingsBuilder : BuilderBase
    {

        public LaunchSettingsBuilder()
        {

        }

        public static LaunchSettingsBuilder New(Action<LaunchSettingsBuilder> action)
        {
            var builder = new LaunchSettingsBuilder();
            action(builder);
            return builder;
        }


        public LaunchSettingsBuilder Profiles(string name, Action<ProfilesBuilder> action)
        {
            var builder = new ProfilesBuilder(name);
            action(builder);
            Add("profiles", builder);
            return this;
        }
        
        internal override JToken GetModel()
        {

            var result = new JObject();

            foreach (var item in base.GetItems())
            {
                var value = new JObject( item.Value.GetModel());
                result.Add(new JProperty(item.Key, value));
            }

            return result;

        }

    }


}
