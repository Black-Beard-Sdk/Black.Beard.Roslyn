namespace Bb.Nugets.Versions
{

    public enum ContraintEnum
    {

        None = 0,

        /// <summary>
        /// The version must be strictly ...
        /// </summary>
        Equal = 1,

        Lower = 2,

        Upper = 4,

        LowerOrEqual = 3, // Lower | Equal,

        UpperOrEqual = 5, // Upper | Equal,


    }

}
