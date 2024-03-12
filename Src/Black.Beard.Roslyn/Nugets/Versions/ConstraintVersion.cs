using System.Text;

namespace Bb.Nugets.Versions
{

    /// <summary>
    /// Constraint version
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Description}")]
    public class ConstraintVersion
    {

        /// <summary>
        /// Create a new instance of ConstraintVersion
        /// </summary>
        public ConstraintVersion()
        {
            Failed = true;
        }

        /// <summary>
        /// Create a new instance of ConstraintVersion
        /// </summary>
        /// <param name="count"></param>
        /// <param name="version"></param>
        /// <param name="leftConstraint"></param>
        public ConstraintVersion(int count, Version version, ContraintEnum leftConstraint, ContraintEnum rightConstraint)
        {

            if (count == -1)
            {
                count = 4;
                if (version.Revision == -1)
                {
                    count--;
                    if (version.Build == -1)
                    {
                        count--;
                        if (version.Minor == -1)
                            count--;
                    }
                }
            }

            this.count = count;
            Version = version;
            this._leftConstraint = leftConstraint;
            this._rightConstraint = rightConstraint;

            // Description = $"{leftConstraint} {version}";

            //switch (this._leftConstraint)
            //{
            //    case ContraintEnum.Equal:
            //        // Accepts any version 6.1 and above. 
            //        Description = $"Accepts strictly version {version}";
            //        break;

            //    case ContraintEnum.Lower:
            //        Description = $"Accepts any version up below, but not including version {version}";
            //        break;

            //    //case ContraintEnum.EqualOrLower:
            //    //    Description = $"Accepts any version up below version {version}";
            //    //    break;

            //    //case ContraintEnum.Upper:
            //    //    Description = $"Accepts any version above, but not including version {version}";
            //    //    break;

            //    //case ContraintEnum.EqualOrUpper:
            //    //    Description = $"Accepts any version above version {version}";
            //    //    break;

            //    default:
            //        break;
            //}

        }

        /// <summary>
        /// Append item to responsibility chain
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public ConstraintVersion Append(ConstraintVersion next)
        {

            if (_next == null)
                _next = next;
            else
                _next.Append(next);

            return this;

        }

        /// <summary>
        /// Evaluate if the version match with the constraint
        /// </summary>
        /// <param name="versionToCompare"></param>
        /// <returns></returns>
        public bool Evaluate(Version versionToCompare)
        {

            if (Failed)
                return false;

            if (Version != null)
            {

                if (_leftConstraint == ContraintEnum.Equal)
                {
                    if (versionToCompare != Version)
                        return false;
                }

                else if ((_leftConstraint & ContraintEnum.Upper) == ContraintEnum.Upper)
                {
                    if ((_leftConstraint & ContraintEnum.Equal) == ContraintEnum.Equal)
                    {
                        if (versionToCompare < Version)
                            return false;
                    }
                    else
                    {
                        if (versionToCompare <= Version)
                            return false;
                    }
                }

                if (_rightConstraint == ContraintEnum.Equal)
                {
                    if (versionToCompare != Version)
                        return false;
                }

                else if ((_rightConstraint & ContraintEnum.Lower) == ContraintEnum.Lower)
                {
                    if ((_rightConstraint & ContraintEnum.Equal) == ContraintEnum.Equal)
                    {
                        if (versionToCompare > Version)
                            return false;
                    }
                    else
                    {
                        if (versionToCompare >= Version)
                            return false;
                    }
                }                          

            }

            if (_next != null)
                return _next.Evaluate(versionToCompare);

            return true;

        }


        /// <summary>
        /// Version reference
        /// </summary>
        public readonly Version Version;

        /// <summary>
        /// Description of the constraint
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Indicate if the constraint is not valid
        /// </summary>
        public bool Failed { get; }

        /// <summary>
        /// Child of the responsibility chain
        /// </summary>
        public ConstraintVersion Child { get => _next; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            WriteTo(sb);
            return sb.ToString();
        }

        private void WriteTo(StringBuilder sb)
        {
            sb.Append(Description);
            if (_next != null)
            {
                sb.Append(" and ");
                _next.WriteTo(sb);
            }
        }

        private ConstraintVersion _next;
        private readonly int count;
        private ContraintEnum _leftConstraint;
        private ContraintEnum _rightConstraint;

    }

}
