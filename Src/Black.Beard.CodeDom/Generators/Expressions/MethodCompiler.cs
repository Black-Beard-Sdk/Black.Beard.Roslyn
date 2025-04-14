
using Bb.Generators;
using Bb.Generators.Csharp;
using System.Linq.Expressions;

namespace Bb.Expressions
{
    /// <summary>
    /// Provides functionality to compile methods from expression trees and generate source code.
    /// </summary>
    /// <remarks>
    /// This class allows adding parameters, generating lambda expressions, and compiling them into delegates.
    /// It also supports generating C# source code for debugging purposes.
    /// </remarks>
    public class MethodCompiler : SourceCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCompiler"/> class.
        /// </summary>
        public MethodCompiler()
        {
        }

        /// <summary>
        /// Gets or sets the output path for generated files.
        /// </summary>
        /// <remarks>
        /// This property is used to specify the directory where generated files will be saved.
        /// </remarks>
        public string OutputPath { get; set; }

        #region parameters

        /// <summary>
        /// Adds a new parameter to the method being compiled.
        /// </summary>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="name">The name of the parameter. If null, a unique name will be generated.</param>
        /// <returns>A <see cref="ParameterExpression"/> representing the added parameter.</returns>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown if a parameter with the same name already exists.
        /// </exception>
        /// <remarks>
        /// This method creates a new parameter and adds it to the internal parameter list.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var compiler = new MethodCompiler();
        /// var parameter = compiler.AddParameter(typeof(int), "myParam");
        /// </code>
        /// </example>
        public ParameterExpression AddParameter(Type type, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = SourceCodeExtension.GetNewName(type);

            var vari = this._parameters.GetByName(name);
            if (vari != null)
                throw new Exceptions.DuplicatedArgumentNameException($"parameter {name} already exists");

            else
            {
                var instance = Expression.Parameter(type, name);

                var variable = new Variable() { Name = instance.Name, Instance = instance };
                this._parameters.Add(variable);
                this.LastParameter = instance;

                return instance;
            }
        }

        /// <summary>
        /// Retrieves a parameter by its name.
        /// </summary>
        /// <param name="name">The name of the parameter to retrieve.</param>
        /// <returns>
        /// A <see cref="ParameterExpression"/> representing the parameter, or null if no parameter with the specified name exists.
        /// </returns>
        /// <remarks>
        /// This method searches the internal parameter list for a parameter with the specified name.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var compiler = new MethodCompiler();
        /// var parameter = compiler.GetParameter("myParam");
        /// </code>
        /// </example>
        public ParameterExpression GetParameter(string name)
        {
            var variable = _parameters.GetByName(name);
            return variable?.Instance;
        }

        /// <summary>
        /// Gets the list of all parameters added to the method.
        /// </summary>
        /// <remarks>
        /// This property provides access to all parameters currently defined in the method.
        /// </remarks>
        public IEnumerable<ParameterExpression> Parameters { get => this._parameters.Items.Select(c => c.Instance); }

        /// <summary>
        /// Gets the last parameter added to the method.
        /// </summary>
        /// <remarks>
        /// This property is useful for accessing the most recently added parameter.
        /// </remarks>
        public ParameterExpression LastParameter { get; private set; }

        #endregion parameters

        /// <summary>
        /// Retrieves a variable or parameter by its name.
        /// </summary>
        /// <param name="name">The name of the variable or parameter to retrieve.</param>
        /// <returns>
        /// A <see cref="ParameterExpression"/> representing the variable or parameter, or null if no match is found.
        /// </returns>
        /// <remarks>
        /// This method first searches for variables in the base class, then checks the parameters defined in this class.
        /// </remarks>
        public override ParameterExpression GetVar(string name)
        {
            var variable = base.GetVar(name);

            if (variable == null)
                variable = this.GetParameter(name);

            return variable;
        }

        #region Compiler

        /// <summary>
        /// Compiles the method into a delegate of the specified type and generates source code for debugging.
        /// </summary>
        /// <typeparam name="TDelegate">The type of the delegate to compile.</typeparam>
        /// <param name="filepathCode">The file path for the generated source code.</param>
        /// <returns>A delegate of type <typeparamref name="TDelegate"/> representing the compiled method.</returns>
        /// <remarks>
        /// This method generates a lambda expression, compiles it into a delegate, and optionally generates C# source code for debugging.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var compiler = new MethodCompiler();
        /// var result = compiler.Compile&lt;Func&lt;int, int&gt;&gt;("MyCode.cs");
        /// </code>
        /// </example>
        public virtual TDelegate Compile<TDelegate>(string filepathCode)
        {
            var lbd = GenerateLambda<TDelegate>(filepathCode);

            if (System.Diagnostics.Debugger.IsAttached)
            {
                var _u = new string[] { "Newtonsoft.Json.Linq", "Bb.ComponentModel.Factories", "Bb.Jslt.Services" };
                //var sb = SourceGenerator.GetCode(result, _u);
                //System.Diagnostics.Debug.WriteLine(sb.ToString());

                var code = SourceCodeDomGenerator.GetCode(lbd, "n_" + Path.GetFileNameWithoutExtension(filepathCode), "Myclass", "MyMethod", false, _u);
                System.CodeDom.CodeCompileUnit compileUnit = new System.CodeDom.CodeCompileUnit()
                {
                };

                string path = Path.Combine(this.OutputPath, "_temps");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string file = Path.Combine(path, filepathCode);
                compileUnit.Namespaces.Add(code);
                LocalCodeGenerator.GenerateCsharpCode(compileUnit, file);
            }

            return lbd.Compile();
        }

        /// <summary>
        /// Generates a lambda expression of the specified delegate type.
        /// </summary>
        /// <param name="delegateType">The type of the delegate to generate.</param>
        /// <returns>A <see cref="LambdaExpression"/> representing the generated lambda.</returns>
        /// <remarks>
        /// This method creates a lambda expression using the defined parameters and the main expression body.
        /// </remarks>
        public LambdaExpression GenerateLambda(Type delegateType)
        {
            var parameters = this._parameters.Items.Select(c => c.Instance).ToArray();
            HashSet<string> variableParent = new HashSet<string>(parameters.Select(c => c.Name));

            var expression = this.GetExpression(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            var result = Expression.Lambda(delegateType, expression, parameters.ToArray());

            return result;
        }

        /// <summary>
        /// Generates a lambda expression of the specified delegate type and saves the source code to a file.
        /// </summary>
        /// <typeparam name="TDelegate">The type of the delegate to generate.</typeparam>
        /// <param name="filepathCode">The file path for the generated source code.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> representing the generated lambda.</returns>
        /// <remarks>
        /// This method creates a lambda expression using the defined parameters and the main expression body.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var compiler = new MethodCompiler();
        /// var lambda = compiler.GenerateLambda&lt;Func&lt;int, int&gt;&gt;("MyCode.cs");
        /// </code>
        /// </example>
        public Expression<TDelegate> GenerateLambda<TDelegate>(string filepathCode)
        {
            var parameters = this._parameters.Items.Select(c => c.Instance).ToArray();
            HashSet<string> variableParent = new HashSet<string>(parameters.Select(c => c.Name));

            var expression = this.GetExpression(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            var result = Expression.Lambda<TDelegate>(expression, parameters.ToArray());

            return result;
        }

        #endregion compiler

        private Variables _parameters = new Variables();
    }
}
