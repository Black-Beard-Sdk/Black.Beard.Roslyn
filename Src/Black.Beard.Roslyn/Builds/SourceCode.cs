using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Bb.Builds
{

    [DebuggerDisplay("{File.FullName}")]
    public class SourceCode
    {

        public static SourceCode GetFromFile(string filename, string name = null)
        {

            // Charge and evaluate source
            var filePathSource = new FileInfo(filename);
            filePathSource.Refresh();

            if (!filePathSource.Exists)
                throw new FileNotFoundException(filePathSource.FullName);

            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(filePathSource.Name);

            var getDatas = filePathSource.LoadFromFile();

            return new SourceCode(filePathSource, getDatas, name) { Filename = filename };

        }

        public static SourceCode GetFromFile(FileInfo file, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(file.Name);

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            var getDatas = file.LoadFromFile();

            return new SourceCode(file, getDatas, name);

        }

        public static SourceCode GetFromText(StringBuilder payload, string name = null)
        {
            return new SourceCode(null, payload.ToString(), name);
        }

        public static SourceCode GetFromText(FileInfo file, string payload, string name = null)
        {
            return new SourceCode(file, payload, name);
        }

        public static SourceCode GetFromText(string payload, string name = null)
        {
            return new SourceCode(null, payload, name);
        }

        private SourceCode(FileInfo? file, string datas, string name)
        {
            this.File = file;
            this.ReadedAt = DateTime.Now;
            this.Name = name;
            this.Datas = datas;
        }


        /// <summary>
        /// Gets the file that contains the source code.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        public FileInfo File { get; }

        /// <summary>
        /// Gets the data & time of the loaded source.
        /// </summary>
        /// <value>
        /// The datetime
        /// </value>
        public DateTime ReadedAt { get; private set; }

        /// <summary>
        /// Gets the name of the source.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the source code.
        /// </summary>
        /// <value>
        /// String text
        /// </value>
        public string Datas { get; private set; }

        /// <summary>
        /// Determines whether this file has updated.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has updated; otherwise, <c>false</c>.
        /// </returns>
        public bool HasUpdated()
        {

            if (File != null && File.Exists)
                return File.LastWriteTime > this.ReadedAt;

            return false;

        }

        /// <summary>
        /// Reloads the code source from the file.
        /// </summary>
        public void Reload()
        {
            if (File != null && File.Exists)
            {
                this.Datas = this.Name.LoadFromFile();
                this.ReadedAt = DateTime.Now;
            }

        }

        public static SourceCode Empty { get; private set; }

        public string Filename { get; private set; }


        public static implicit operator SourceCode(StringBuilder sb)
        {
            return SourceCode.GetFromText(sb);
        }

        public static implicit operator SourceCode(string sb)
        {
            return SourceCode.GetFromText(sb);
        }

        public static implicit operator SourceCode(FileInfo file)
        {
            return SourceCode.GetFromFile(file);
        }

        public bool IsGeneratedSource
        {
            get
            {
                if (this.File != null)
                    return this.File.Name.ToLower().EndsWith(".g.cs");
                return false;
            }
        }


        //private static string Normalize(string payload)
        //{

        //    var length = payload.Length;
        //    StringBuilder sb = new StringBuilder(length);

        //    for (int i = 0; i < length; i++)
        //    {

        //        char c = payload[i];

        //        if ((int)c != 65279)
        //            sb.Append(c);

        //    }

        //    return sb.ToString();

        //}


    }



}
