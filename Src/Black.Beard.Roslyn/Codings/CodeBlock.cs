using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Bb.Codings
{

    public class CodeBlock : CodeLevelBlock
    {

        public CodeBlock(StatementList code = null) : base(null, null, code)
        {
            _root = this;

            _parent = this;
            _stack = new Stack<CodeLevelBlock>();

            _variables = new Dictionary<string, Variable>();
            _datas = new Dictionary<object, Data>();
            this.DefaultData = new Data();
        }


        public Data GetDataFor(object key)
        {

            if (!_datas.TryGetValue(key, out Data data))
                _datas.Add(key, data = new Data());

            return data;

        }

        #region variables

        public override Variable GetVariable(string name)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            return null;

        }

        public override bool VariableExists(string name)
        {
            return _variables.ContainsKey(name);
        }

        public override void RemoveVariable(string name)
        {

            if (_variables.ContainsKey(name))
                _variables.Remove(name);

        }

        public override void RemoveVariable(Variable variable)
        {

            if (_variables.ContainsValue(variable))
                _variables.Remove(variable.Name);

        }

        public override Variable CreateVariable(string name, Type type)
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

        public override Variable CreateVariable(string name, string type)
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

        public override Variable CreateOrGetVariable(string name, string type)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            variable = new Variable(name, type, null);
            _variables.Add(name, variable);

            return variable;
        }

        public override Variable CreateOrGetVariable(string name, Type type)
        {

            if (_variables.TryGetValue(name, out var variable))
                return variable;

            variable = new Variable(name, null, type);
            _variables.Add(name, variable);

            return variable;
        }

        #endregion


        public new CodeBlock Add(StatementSyntax statementSyntax)
        {
            base.Add(statementSyntax);
            return this;
        }

        public new CodeBlock Add(ExpressionSyntax statementSyntax)
        {
            base.Add(statementSyntax); base.Add(statementSyntax);
            return this;
        }


        internal Dictionary<string, Variable> _variables;
        private readonly Dictionary<object, Data> _datas;

        public Data DefaultData { get; }

        internal readonly Stack<CodeLevelBlock> _stack;


    }

}
