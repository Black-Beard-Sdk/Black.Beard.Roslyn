
namespace Bb.Codings
{

    public class DeclarationBloc : DeclarationLevelBloc
    {

        public DeclarationBloc()
            : base(null, null, null)
        {

        }


        public override CSMemberDeclaration Current { get => _current ?? CurrentBlock?.Current; set { _current = value; } }

        public DeclarationLevelBloc CurrentBlock
        {
            get
            {
                if (_stack.Count > 0)
                    return _stack.Peek();
                return null;
            }
        }

        public DeclarationLevelBloc Stack(CSMemberDeclaration currentMember)
        {

            DeclarationLevelBloc last = this;
            if (_stack.Count > 0)
                last = _stack.Peek();

            if (currentMember == null)
            {
                var current = CurrentBlock;
                currentMember = current != null
                    ? current.Current
                    : Current;
            }

            var result = new DeclarationLevelBloc(this, last, currentMember);

            _stack.Push(result);

            return result;

        }


        public void Remove(DeclarationLevelBloc levelBloc)
        {

            var t = _stack.Pop();

            if (t != levelBloc)
                throw new InvalidOperationException();

        }

        private Stack<DeclarationLevelBloc> _stack = new Stack<DeclarationLevelBloc>();
        private CSMemberDeclaration _current = null;

    }


    public class DeclarationLevelBloc : IDisposable
    {

        internal DeclarationLevelBloc(DeclarationBloc root, DeclarationLevelBloc parent, CSMemberDeclaration current)
        {
            Current = current;
            _root = root;
            _parent = parent;
        }

        public void Dispose()
        {
            _root.Remove(this);
        }

        public virtual CSMemberDeclaration Current { get; set; }
        private readonly DeclarationBloc _root;
        private readonly DeclarationLevelBloc _parent;

    }


}
