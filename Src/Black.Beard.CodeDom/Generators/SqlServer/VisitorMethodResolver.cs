using System.CodeDom;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Generators.SqlServer
{
    public partial class VisitorMethodResolver
    {


        public VisitorMethodResolver(Type type)
        {

            _methods = ResolveMethods(type);

        }

        private Dictionary<string, Action<VisitorMethodResolver, object>> ResolveMethods(Type type)
        {

            if (!_resolvers.TryGetValue(type, out var result))
                lock (_lock)
                    if (!_resolvers.TryGetValue(type, out result))
                        _resolvers.Add(type, (result = GenerateMethods(type, new Dictionary<string, Action<VisitorMethodResolver, object>>())));

            return result;

        }

        private Dictionary<string, Action<VisitorMethodResolver, object>> GenerateMethods(Type type, Dictionary<string, Action<VisitorMethodResolver, object>> dic)
        {

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
                if (method.DeclaringType == type)
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1)
                    {

                        var parameter = parameters[0];
                        var paramType = parameter.ParameterType;
                        var key = paramType.Name;

                        if (!dic.ContainsKey(key))
                            if (typeof(CodeObject).IsAssignableFrom(paramType))
                            {

                                var instance = Expression.Parameter(typeof(VisitorMethodResolver), "visitor");
                                var argument = Expression.Parameter(typeof(object), key);
                                var call = Expression.Call(Expression.Convert(instance, type), method, Expression.Convert(argument, paramType));

                                var lbd = Expression.Lambda<Action<VisitorMethodResolver, object>>(call, instance, argument);

                                var methodToCall = lbd.Compile();

                                dic.Add(key, (Action<VisitorMethodResolver, object>)methodToCall);

                            }
                    }
                }

            if (type.BaseType != null && type.BaseType != typeof(VisitorMethodResolver))
                GenerateMethods(type.BaseType, dic);

            return dic;

        }

        public bool Visit<T>(T self)
        {

            if (self == null)
                throw new ArgumentNullException(nameof(self));

            return Visit<T>(self, self.GetType().Name);

        }

        public bool Visit<T>(T self, string key)
        {

            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (_methods.TryGetValue(key, out var result))
            {
                result(this, self);
                return true;
            }
            else
                NotAccepted(key, self);

            return false;

        }

        protected virtual void NotAccepted(string key, object item)
        {

        }

        private static Dictionary<Type, Dictionary<string, Action<VisitorMethodResolver, object>>> _resolvers = new Dictionary<Type, Dictionary<string, Action<VisitorMethodResolver, object>>>();
        private static object _lock = new object();
        private readonly Dictionary<string, Action<VisitorMethodResolver, object>> _methods;


    }
}
