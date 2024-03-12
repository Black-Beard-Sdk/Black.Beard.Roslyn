using System.Text;

namespace Bb.Nugets.Versions
{
    /*
     *  Will resolve to the smallest acceptable stable version
     * 
     *  Accepts any version 6.1 and above. 
     *  Version="6.1"           -- >= 6.1
     *
     *  Accepts any 6.x.y version. Will resolve to the highest acceptable stable version.
     *  Version="6.*"           -- > 6.x
     *
     *  <!-- Accepts any version above, but not including 4.1.3. Could be used to guarantee a dependency with a specific bug fix.
     *  Version="(4.1.3,)"      -- > 4.1.3
     *
     *  Accepts any version up below 5.x, which might be used to prevent pulling in a later version of a dependency that changed its interface. 
     *  However, this form is not recommended because it can be difficult to determine the lowest version.
     *  Version="(,5.0)"        -- < 5.0
     *
     *  Accepts any 1.x or 2.x version, but not 0.x or 3.x and higher.
     *  Version="[1,3)"         -- >= 1 and < 3
     *
     *  Accepts 1.3.2 up to 1.4.x, but not 1.5 and higher.
     *  Version="[1.3.2,1.5)"   -- >= 1.3.2 and < 1.5
     */

    internal class VersionMotif
    {

        public VersionMotif(VersionToken token)
        {
            Token = token;
            _ints = new List<int>();
            _values = new StringBuilder();
            Failed = false;
        }

        internal ConstraintVersion BuildVersion()
        {

            if (_values.Length > 0)
                _ints.Add(int.Parse(_values.ToString()));

            switch (_ints.Count)
            {
                case 1:
                    return new ConstraintVersion(_ints.Count, new Version(_ints[0], 0), _leftConstraint, _rightConstraint);

                case 2:
                    return new ConstraintVersion(_ints.Count, new Version(_ints[0], _ints[1]), _leftConstraint, _rightConstraint);

                case 3:
                    return new ConstraintVersion(_ints.Count, new Version(_ints[0], _ints[1], _ints[2]), _leftConstraint, _rightConstraint);

                case 4:
                    return new ConstraintVersion(_ints.Count, new Version(_ints[0], _ints[1], _ints[2], _ints[3]), _leftConstraint, _rightConstraint);

                default:
                    break;
            }

            Failed = true;

            return null;

        }

        public void Append(char c, VersionToken token)
        {

            if (token == VersionToken.Digit)
                _values.Append(c);

            else if (token == VersionToken.Dot)
            {
                var i = int.Parse(_values.ToString());
                _ints.Add(i);
                _values.Clear();
            }

            else if (token == VersionToken.Wildcard)
                this._wildcard = true;

        }

        public void SetLeftConstraint(ContraintEnum constraint)
        {
            _leftConstraint = constraint;
        }


        public void SetRightConstraint(ContraintEnum constraint)
        {

            if (this._wildcard)
            {
                if ((constraint & ContraintEnum.Lower) == ContraintEnum.Lower)
                    constraint ^= ContraintEnum.Lower;
            }

            _rightConstraint = constraint;

        }

        public bool HasVersion()
        {
            if (_values.Length > 0)
            {
                _ints.Add(int.Parse(_values.ToString()));
                _values.Clear();
            }
            return _ints.Count > 0;

        }

        public VersionToken Token { get; }

        public bool Failed { get; private set; }

        private ContraintEnum _leftConstraint;
        private ContraintEnum _rightConstraint;

        private List<int> _ints;
        private StringBuilder _values;
        private bool _wildcard;

    }

}
