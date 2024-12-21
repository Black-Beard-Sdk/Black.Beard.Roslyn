using System.Diagnostics;
using System.Text;

namespace Bb.Builds
{

    [DebuggerDisplay("{File.FullName}")]
    public class SourceCode
    {

        #region creators

        private SourceCode(FileInfo? file, string datas, string name)
        {

            if (file != null)
            {

                file.Refresh();

                if (!file.Exists)
                    throw new FileNotFoundException(nameof(file));

                this.File = file;

            }

            this.ReadedAt = DateTime.Now;
            this.Name = name;
            this.Source = datas;
        }

        /// <summary>
        /// Create a new instance of <see cref="SourceCode"/>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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

        /// <summary>
        /// Create a new instance of <see cref="SourceCode"/>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static SourceCode GetFromFile(FileInfo file, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = Path.GetFileNameWithoutExtension(file.Name);

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            var getDatas = file.LoadFromFile();

            return new SourceCode(file, getDatas, name);

        }

        /// <summary>
        /// Create a new instance of <see cref="SourceCode"/>
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SourceCode GetFromText(StringBuilder payload, string name = null)
        {
            return new SourceCode(null, payload.ToString(), name);
        }

        /// <summary>
        /// create a new instance of <see cref="SourceCode"/>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="payload"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SourceCode GetFromText(FileInfo file, string payload, string name = null)
        {
            return new SourceCode(file, payload, name);
        }

        /// <summary>
        /// create a new instance of <see cref="SourceCode"/>
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SourceCode GetFromText(string payload, string name = null)
        {
            return new SourceCode(null, payload, name);
        }

        #endregion creators


        #region properties

        /// <summary>
        /// return true if the source is in memory
        /// </summary>
        public bool IsMemorySource => this.File == null;

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
        /// The date time
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
        public string Source { get; set; }

        /// <summary>
        /// Gets the empty source code.
        /// </summary>
        public static SourceCode Empty { get; private set; }

        /// <summary>
        /// Gets the filename of the file.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Return true if the file was been deleted
        /// </summary>
        public bool IsDeleted => !File?.Exists ?? false;

        /// <summary>
        /// Return true if the file is a generated source
        /// </summary>
        public bool IsGeneratedSource
        {
            get
            {
                return this.File.Name.ToLower().EndsWith(".g.cs");
            }
        }

        #endregion properties


        /// <summary>
        /// Determines whether this file has been updated.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has updated; otherwise, <c>false</c>.
        /// </returns>
        public bool HasUpdated()
        {

            if (File != null && File.Exists)
            {
                File.Refresh();
                return File.LastWriteTime > this.ReadedAt;
            }

            return true;

        }

        /// <summary>
        /// Reloads the code source from the file.
        /// </summary>
        public void Reload()
        {
            if (File != null && File.Exists)
            {
                this.ReadedAt = DateTime.Now;
                this.Source = this.Filename.LoadFromFile();
            }
        }

        /// <summary>
        /// A hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            uint key = Name.CalculateCrc32();
            key ^= Source.CalculateCrc32();
            return (int)key;
        }


        #region implicit conversion

        /// <summary>
        /// implicit conversion from StringBuilder to SourceCode
        /// </summary>
        /// <param name="sb"></param>
        public static implicit operator SourceCode(StringBuilder sb)
        {
            return SourceCode.GetFromText(sb);
        }


        /// <summary>
        /// implicit conversion from string to SourceCode
        /// </summary>
        /// <param name="sb"></param>
        public static implicit operator SourceCode(string sb)
        {
            return SourceCode.GetFromText(sb);
        }

        /// <summary>
        /// implicit conversion from FileInfo to SourceCode
        /// </summary>
        /// <param name="file"></param>
        public static implicit operator SourceCode(FileInfo file)
        {
            return SourceCode.GetFromFile(file);
        }

        #endregion implicit conversion


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
