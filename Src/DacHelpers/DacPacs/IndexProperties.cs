namespace Bb.DacPacs
{
    public class IndexProperties
    {

        public bool PadIndex { get; set; } = false;

        public bool StatisticsNorecompute { get; set; } = false;

        public bool AllowRowLocks { get; set; } = true;

        public bool AllowPageLocks { get; set; } = true;

        public bool OptimizeForSequentialKey { get; set; } = false;


        // public bool DropExisting { get; set; } = false;
        // public bool Online { get; set; } = false;
        // public bool SortInTempdb { get; set; } = false;

    }

}
