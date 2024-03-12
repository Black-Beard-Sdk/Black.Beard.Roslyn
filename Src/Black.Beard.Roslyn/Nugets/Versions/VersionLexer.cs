using System.ComponentModel;

namespace Bb.Nugets.Versions
{
    internal class VersionLexer
    {


        public VersionLexer(string version)
        {
            _version = version.Trim();
            _index = 0;
            _length = version.Length;
            _constraint = null;
        }


        public ConstraintVersion Parse()
        {

            ContraintEnum left = ContraintEnum.None;
            bool closed = false;
            bool leftWrited = false;
            while (Read() != VersionToken.Eof)
            {

                switch (CurrentToken)
                {

                    case VersionToken.Comma:
                        if (_current != null)
                        {
                            _current.SetLeftConstraint(left);
                            left = ContraintEnum.None;
                            leftWrited = false;
                            Create();
                        }
                        else
                        {
                            Create();
                        }
                        left = ContraintEnum.None;
                        break;

                    case VersionToken.BracketLeft:
                        left = ContraintEnum.UpperOrEqual;
                        break;

                    case VersionToken.ParentLeft:
                        left = ContraintEnum.Upper;
                        break;

                    case VersionToken.BracketRight:
                        if (!_current.HasVersion())
                        {
                            if (Revert())
                            {

                            }
                            else
                            {

                            }
                        }

                        _current.SetLeftConstraint(left);
                        _current.SetRightConstraint(ContraintEnum.LowerOrEqual);
                        leftWrited = true;
                        closed = true;
                        break;

                    case VersionToken.ParentRight:
                        if (!_current.HasVersion())
                        {
                            if (Revert())
                            {
                                leftWrited = true;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            _current.SetLeftConstraint(left);
                            leftWrited = true;
                        }
                        _current.SetRightConstraint(ContraintEnum.Lower);
                        closed = true;
                        break;

                    case VersionToken.Wildcard:
                    case VersionToken.Dot:
                        if (_current == null)
                            return null;
                        _current.Append(CurrentChar, CurrentToken);
                        break;

                    case VersionToken.Digit:
                        if (_current == null)
                            Create();
                        _current.Append(CurrentChar, CurrentToken);
                        break;

                    default:
                        break;

                }

            }

            if (_current != null)
            {
                if (!closed)
                {
                    if (!leftWrited && left == ContraintEnum.None)
                        _current.SetLeftConstraint(ContraintEnum.UpperOrEqual);
                    else
                        _current.SetLeftConstraint(left);
                }
                Create();
            }
            return _constraint;

        }

        private bool Revert()
        {
            if (_motifs.Count > 0)
            {
                var index = _motifs.Count - 1;
                _current = _motifs[index];
                _motifs.RemoveAt(index);

                return true;

            }

            return false;

        }

        private void Create()
        {

            if (_current != null)
            {
                var v = _current.BuildVersion();
                if (v != null)
                {
                    if (_constraint == null)
                        _constraint = v;
                    else
                        _constraint.Append(v);
                }
            }

            var c = new VersionMotif(CurrentToken);
            _motifs.Add(c);

            _current = c;

        }

        private VersionToken Read()
        {
            if (_index >= _length)
                return VersionToken.Eof;

            CurrentChar = '\0';
            VersionToken result = VersionToken.Undefined;

            var _currentChar = _version[_index];

            switch (_currentChar)
            {

                case '.':
                    result = VersionToken.Dot;
                    break;

                case ',':
                    result = VersionToken.Comma;
                    break;

                case '*':
                    result = VersionToken.Wildcard;
                    break;

                case '(':
                    result = VersionToken.ParentLeft;
                    break;

                case ')':
                    result = VersionToken.ParentRight;
                    break;

                case '[':
                    result = VersionToken.BracketLeft;
                    break;

                case ']':
                    result = VersionToken.BracketRight;
                    break;

                default:
                    if (char.IsDigit(_currentChar))
                    {
                        result = VersionToken.Digit;
                        CurrentChar = _currentChar;
                    }
                    break;
            }

            if (result == VersionToken.Undefined)
            {

            }

            PreviousToken = CurrentToken;
            CurrentToken = result;
            _index++;
            return result;

        }

        public VersionToken PreviousToken { get; private set; }

        public VersionToken CurrentToken { get; private set; }

        public char CurrentChar { get; private set; }

        private ConstraintVersion _constraint;
        private List<VersionMotif> _motifs = new List<VersionMotif>();
        private VersionMotif _current;
        private string _version;
        private int _index;
        private readonly int _length;

    }

}
