using System.Text;

namespace Bb.StarteKit.Components.Sql
{
    public class Writer
    {

        public Writer(StringBuilder sb)
        {
            this._sb = sb;
            _index = 0;
        }

        public Writer Append(string value)
        {

            return this;

        }

        public Writer Append(int value)
        {

            return this;

        }

        public Writer AppendLabel(params string[] values)
        {

            bool dot = false;
            foreach (var item in values)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (dot)
                        _sb.Append('.');
                    _sb.Append($"[{item}]");
                    dot = true;
                }
            }

            return this;

        }

        internal void DelIndent()
        {
            _index++;
        }

        internal void AddIndent()
        {
            _index--;
        }

        internal void AppendEndLine()
        {

            _sb.AppendLine();
            for (int i = 0; i < _index; i++)
                _sb.Append('\t');

        }

        private readonly StringBuilder _sb;
        private int _index;

    }


}