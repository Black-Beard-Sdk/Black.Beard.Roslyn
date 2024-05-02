namespace Black.Beard.Roslyn.Documentation
{


    public class Solution
    {


        public Solution(FileInfo file)
        {
            this._file = file;
        }

        /// <summary>
        /// Return the list of solutions
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IEnumerable<Solution> GetSolutions(DirectoryInfo directory)
        {

            var files = directory.GetFiles("*.sln", SearchOption.AllDirectories);
            foreach (var file in files)
                yield return new Solution(file);

        }


        public IEnumerable<Project> GetProjects()
        {


            var root = this._file.Directory.FullName;

            List<string> projects = new List<string>();

            var content = File.ReadAllText(_file.FullName);
            var lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.StartsWith("Project"))
                {
                    var parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var f = parts[1].Trim('"', '\\', ' ');
                    var file = new FileInfo(Path.Combine(root, f));
                    if (file.Exists)
                        yield return new Project(file);
                }
            }
        }


        private readonly FileInfo _file;


    }


    public class Project
    {

        public Project(FileInfo file)
        {
            this._file = file;
        }

        private readonly FileInfo _file;

    }


}
