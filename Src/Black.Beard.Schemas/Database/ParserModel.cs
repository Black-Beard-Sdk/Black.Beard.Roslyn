using System.Data;

namespace Bb.Schemas.Database
{
    public class ParserModel : List<ParserModel>
    {

        public ParserModel()
        {

        }

        public ParserModelEnum Kind { get; internal set; }

        public string SourcePath { get; internal set; }

        public DataColumn TargetPath { get; internal set; }

    }


}
