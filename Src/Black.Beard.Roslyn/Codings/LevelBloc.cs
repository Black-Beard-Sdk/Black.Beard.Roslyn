using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Bb.Codings
{



    public class LevelBloc : IDisposable
    {

        internal LevelBloc(CodeBlock root, LevelBloc parent, SyntaxList<StatementSyntax> collection, object sourceItem)
        {
            Code = collection;
            _root = root;
            _parent = parent;
            _source = sourceItem;
        }

        public void Dispose()
        {
            foreach (var item in _variables)
                _root.RemoveVariable(item);
            _root.Remove(this);
        }

        #region datas

        public T GetRecursiveData<T>(string key)
        {
            var result = GetRecursiveData(key);
            if (result == null)
                return default;

            return (T)result;
        }

        public T GetData<T>(string key)
        {
            var result = GetData(key);
            if (result == null)
                return default;

            return (T)result;
        }

        public object GetRecursiveData(string key)
        {

            if (_root._datas.TryGetValue(_source, out Data data))
            {

                var result = data.GetData(key);

                if (result != null)
                    return result;

            }

            if (_parent != null)
                return _parent.GetRecursiveData(key);

            return null;

        }

        public object GetData(string key)
        {

            if (_root._datas.TryGetValue(_source, out Data data))
            {

                var result = data.GetData(key);

                if (result != null)
                    return result;

            }

            return null;

        }

        public LevelBloc GetLevelFromData(string key)
        {

            if (_root._datas.TryGetValue(_source, out var data))
                if (data.DataExist(key))
                    return this;

            if (_parent != null)
                return _parent.GetLevelFromData(key);

            return null;

        }

        public bool DataExists(string key)
        {

            if (_root._datas.TryGetValue(_source, out var data))
                if (data.DataExist(key))
                    return true;

            if (_parent != null)
                return _parent.DataExists(key);

            return false;

        }

        public void SetData(string key, object value)
        {

            if (!_root._datas.TryGetValue(_source, out Data data))
                _root._datas.Add(_source, data = new Data());

            data.SetData(key, value);

        }

        #endregion datas

        public Variable GetVariable(string name) => _root.GetVariable(name);
        public bool VariableExists(string name) => _root.VariableExists(name);

        public Variable CreateVariable(string name, string type)
        {
            var result = _root.CreateVariable(name, type);
            _variables.Add(result);
            return result;
        }

        public Variable CreateVariable(string name, Type type)
        {
            var result = _root.CreateVariable(name, type);
            _variables.Add(result);
            return result;
        }

        public Variable CreateOrGetVariable(string name, string type)
        {

            var variable = _root.GetVariable(name);
            if (variable != null)
                return variable;

            variable = CreateOrGetVariable(name, type);
            _variables.Add(variable);

            return variable;

        }

        public Variable CreateOrGetVariable(string name, Type type)
        {

            var variable = _root.GetVariable(name);
            if (variable != null)
                return variable;

            variable = CreateOrGetVariable(name, type);
            _variables.Add(variable);

            return variable;

        }



        public CodeMarker GetMarker()
        {
            return new CodeMarker(this);
        }


        public SyntaxList<StatementSyntax> Code { get; }

        private readonly CodeBlock _root;
        private readonly LevelBloc _parent;
        internal readonly object _source;
        private HashSet<Variable> _variables = new HashSet<Variable>();

    }


}
