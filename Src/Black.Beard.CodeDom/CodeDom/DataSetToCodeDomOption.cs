namespace Bb.Schemas.Database
{

    public class DataSetToCodeDomOption
    {

        public DataSetToCodeDomOption(TargetServer targetServer = null)
        {
            this.TargetServer = targetServer ?? new Database.TargetServer();
            this.TargetServer.Options = this;

        }

        public bool PrimaryKeyInline { get; set; } = true;

        public TargetServer TargetServer { get; }


    }

}
