using System.Text.Json;


namespace Bb.Analysis
{
    public static class FrameworkHelper
    {

        public static JsonElement? TryGetDeps(DirectoryInfo dir, string pattern)
        {

            var file = dir.GetFiles(pattern + ".deps.json", SearchOption.AllDirectories).FirstOrDefault();
            if (file != null)
            {
                var json = file.FullName.LoadJsonFromFile();   // JsonDocument.Parse(File.ReadAllText(file.FullName));
                var nam = json.RootElement.GetProperty("runtimeTarget").GetProperty("name");
                return nam;
            }

            return default;

        }

        public static JsonElement? TryGetRuntimeConfig(DirectoryInfo dir, string pattern)
        {
          
            var file = dir.GetFiles(pattern + ".runtimeconfig.json", SearchOption.AllDirectories).FirstOrDefault();
            if (file != null)
            {
                var json = file.FullName.LoadJsonFromFile();   // JsonDocument.Parse(File.ReadAllText(file.FullName));
                var nam = json.RootElement.GetProperty("runtimeOptions");
                return nam;
            }

            return default;

        }

    }

}
