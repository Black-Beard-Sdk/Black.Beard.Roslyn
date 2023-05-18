using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Bb.Codings
{


    public class StatementList : List<StatementSyntax>
    {

        public StatementList()
            : base()
        {

        }

        public StatementList(int capacity) 
            : base(capacity)
        {
            
        }

        public StatementList(IEnumerable<StatementSyntax> collection) 
            : base(collection)
        {

        }

        public void Add(ExpressionSyntax expression)
        {
            Add(expression.ToStatement());
        }


    }



    public class CodeLevelBlock : IDisposable
    {

        internal CodeLevelBlock(CodeBlock root, CodeLevelBlock parent, StatementList collection)
        {
            Code = collection ?? new StatementList();
            _root = root;
            _parent = parent;
        }

        public CodeLevelBlock CurrentBlock
        {
            get
            {
                if (_root._stack.Count > 0)
                    return _root._stack.Peek();
                return this;
            }
        }

        public CodeLevelBlock Stack(StatementList collection = null)
        {

            CodeLevelBlock current = CurrentBlock;

            if (collection == null)
                collection = current.Code;

            var result = new CodeLevelBlock(_root, current, collection);

            _root._stack.Push(result);

            return result;

        }


        public void Dispose()
        {
            //foreach (var item in _variables)
            //    _root.RemoveVariable(item);
            var last = _root._stack.Pop();
            if (last != this)
                throw new InvalidOperationException();
        }

        //#region datas

        //public T GetRecursiveData<T>(string key)
        //{
        //    var result = GetRecursiveData(key);
        //    if (result == null)
        //        return default;

        //    return (T)result;
        //}

        //public T GetData<T>(string key)
        //{
        //    var result = GetData(key);
        //    if (result == null)
        //        return default;

        //    return (T)result;
        //}

        //public object GetRecursiveData(string key)
        //{

        //    if (_root._datas.TryGetValue(_source, out Data data))
        //    {

        //        var result = data.GetData(key);

        //        if (result != null)
        //            return result;

        //    }

        //    if (_parent != null)
        //        return _parent.GetRecursiveData(key);

        //    return null;

        //}

        //public object GetData(string key)
        //{

        //    if (_root._datas.TryGetValue(_source, out Data data))
        //    {

        //        var result = data.GetData(key);

        //        if (result != null)
        //            return result;

        //    }

        //    return null;

        //}

        //public LevelBloc GetLevelFromData(string key)
        //{

        //    if (_root._datas.TryGetValue(_source, out var data))
        //        if (data.DataExist(key))
        //            return this;

        //    if (_parent != null)
        //        return _parent.GetLevelFromData(key);

        //    return null;

        //}

        //public bool DataExists(string key)
        //{

        //    if (_root._datas.TryGetValue(_source, out var data))
        //        if (data.DataExist(key))
        //            return true;

        //    if (_parent != null)
        //        return _parent.DataExists(key);

        //    return false;

        //}

        //public void SetData(string key, object value)
        //{

        //    if (!_root._datas.TryGetValue(_source, out Data data))
        //        _root._datas.Add(_source, data = new Data());

        //    data.SetData(key, value);

        //}

        //#endregion datas

        public virtual Variable GetVariable(string name) => _root.GetVariable(name);

        public virtual bool VariableExists(string name) => _root.VariableExists(name);

        public virtual void RemoveVariable(string name) => _root.RemoveVariable(name);

        public virtual void RemoveVariable(Variable variable) => _root.RemoveVariable(variable);

        public virtual Variable CreateVariable(string name, Type type)
        {
            var result = _root.CreateVariable(name, type);
            _variables.Add(name);
            return result;
        }

        public virtual Variable CreateVariable(string name, string type)
        {
            var result = _root.CreateVariable(name, type);
            _variables.Add(name);
            return result;
        }

        public virtual Variable CreateOrGetVariable(string name, string type)
        {
            var variable = _root.CreateOrGetVariable(name, type);
            _variables.Add(name);
            return variable;
        }

        public virtual Variable CreateOrGetVariable(string name, Type type)
        {
            var variable = _root.CreateOrGetVariable(name, type);
            _variables.Add(name);
            return variable;
        }


        //public CodeMarker GetMarker()
        //{
        //    return new CodeMarker(this);
        //}


        public virtual BlockSyntax Build()
        {
            return new SyntaxList<StatementSyntax>(Code).ToBlock();
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public void Stop()
        {
            System.Diagnostics.Debugger.Break();
        }
        public StatementList Code { get; }

        public CodeLevelBlock Add(StatementSyntax statementSyntax)
        {
            Code.Add(statementSyntax);
            return this;
        }

        public CodeLevelBlock Add(ExpressionSyntax statementSyntax)
        {
            Code.Add(statementSyntax.ToStatement());
            return this;
        }

        protected CodeBlock _root;
        protected CodeLevelBlock _parent;
        private HashSet<string> _variables = new HashSet<string>();

    }


}
