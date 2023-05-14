using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Bb.Codings
{

    public class CodeBlock
    {

        public CodeBlock()
        {
            _datas = new Dictionary<object, Data>();
            _code = new SyntaxList<StatementSyntax>();
            //_stack = new Stack<LevelBloc>();
            _variables = new Dictionary<string, Variable>();
        }


        public Data GetDataFor(object key)
        {

            if (!_datas.TryGetValue(key, out Data data))
                _datas.Add(key, data = new Data());

            return data;

        }


        //public LevelBloc CurrentBlock
        //{
        //    get
        //    {
        //        if (_stack.Count > 0)
        //            return _stack.Peek();
        //        return null;
        //    }
        //}

        //public LevelBloc Stack(object sourceItem, SyntaxList<StatementSyntax> collection)
        //{

        //    LevelBloc last = null;
        //    if (_stack.Count > 0)
        //        last = _stack.Peek();

        //    if (collection == null)
        //    {
        //        var current = CurrentBlock;
        //        collection = CurrentBlock != null
        //            ? current.Code
        //            : _code;
        //    }

        //    var result = new LevelBloc(this, last, collection, sourceItem);

        //    _stack.Push(result);

        //    return result;

        //}


        //public void Remove(LevelBloc levelBloc)
        //{

        //    var t = _stack.Pop();

        //    if (t != levelBloc)
        //        throw new InvalidOperationException();

        //    if (_datas.ContainsKey(t._source))
        //        _datas.Remove(t._source);

        //}


        public BlockSyntax Build()
        {
            return _code.ToBlock();
        }


        public SyntaxList<StatementSyntax> Code { get => _code; }



        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public void Stop()
        {
            System.Diagnostics.Debugger.Break();
        }

        #region variables

        public Variable CreateOrGetVariable(string name, string type)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            variable = new Variable(name, type, null);
            _variables.Add(name, variable);

            return variable;
        }

        public Variable CreateVariable(string name, string type)
        {

            if (_variables.TryGetValue(name, out var variable))
            {

                int index = 1;
                var name1 = name + index;
                while (_variables.ContainsKey(name1))
                {
                    index++;
                    name1 = name + index;
                }

                variable = new Variable(name1, type, null);
                _variables.Add(variable.Name, variable);


            }
            else
                _variables.Add(name, variable = new Variable(name, type, null));

            return variable;

        }

        public Variable CreateOrGetVariable(string name, Type type)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            variable = new Variable(name, null, type);
            _variables.Add(name, variable);

            return variable;
        }

        public Variable CreateVariable(string name, Type type)
        {

            if (_variables.TryGetValue(name, out var variable))
            {

                int index = 1;
                var name1 = name + index;
                while (_variables.ContainsKey(name1))
                {
                    index++;
                    name1 = name + index;
                }

                variable = new Variable(name1, null, type);
                _variables.Add(variable.Name, variable);

            }
            else
                _variables.Add(name, variable = new Variable(name, null, type));

            return variable;

        }

        public Variable GetVariable(string name)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            return null;

        }

        public void RemoveVariable(string name)
        {

            if (_variables.ContainsKey(name))
                _variables.Remove(name);

        }

        public void RemoveVariable(Variable variable)
        {

            if (_variables.ContainsValue(variable))
                _variables.Remove(variable.Name);

        }

        public bool VariableExists(string name)
        {
            return _variables.ContainsKey(name);
        }

        public CodeBlock Add(StatementSyntax statementSyntax)
        {
            _code = _code.Add(statementSyntax);
            return this;
        }

        public CodeBlock Add(ExpressionSyntax statementSyntax)
        {
            _code = _code.Add(statementSyntax.ToStatement());
            return this;
        }

        #endregion

        private Dictionary<string, Variable> _variables;
        internal Dictionary<object, Data> _datas;
        private SyntaxList<StatementSyntax> _code;
        //private readonly Stack<LevelBloc> _stack;


    }

    }
