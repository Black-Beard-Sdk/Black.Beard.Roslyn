using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bb.Codings
{
    public class CodeMarker
    {

        public CodeMarker(LevelBloc bloc)
        {
            _bloc = bloc;

            _position = _bloc.Code.Count;

        }


        //public void Append(CodeExpression e)
        //{
        //    this._bloc.Code.Insert(this._position++, e.AsStatement());
        //}

        public void Append(StatementSyntax s)
        {
            _bloc.Code.Insert(_position++, s);
        }


        private readonly LevelBloc _bloc;
        private int _position;

    }


}
