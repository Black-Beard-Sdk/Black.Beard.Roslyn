using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bb.Schemas.DataSets;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System.Text;
using Bb.Schemas.Database;
using System.IO;
using Bb.DacPacs;

namespace Bb.Beard.Schemas.NUnitTests
{

    [TestClass]
    public class DataSetUnitTest
    {

        public DataSetUnitTest()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            this._dir = new System.IO.FileInfo(ass.Location).Directory;
        }

        [TestMethod]
        public void TestMethod1()
        {

            string testName = "test_"; // + Guid.NewGuid().ToString("N");
            var d = Path.Combine(this._dir.FullName, testName);
            var dir = new DirectoryInfo(d);
            if (!dir.Exists)
                dir.Create();

            var payload = Resources.laposte_poincont2;
            JToken datas = Encoding.UTF8.GetString(payload).ConvertToJson();

            var options = new CreateDatasetOptions();

            var generator = new CreateDataSet(options);
            generator.Visit(datas as JArray, "LaPoste");

            var package = new DacPackage()
            {
                Name = "DbTest"
            };

            var visitor = new DacpacToDataSetVisitor();
            visitor.Visit(generator.DataSet);

            #region Test

            //var dac = package.Schema

            //    .PrimaryKey("dbo", "LaPoste", "_$id")
            //    .PrimaryKey("dbo", "geometry_coordinates", "_$id")
            //    .PrimaryKey("dbo", "fields_latlong", "_$id")

            //    .Table("dbo", "fields_latlong", table =>
            //    {
            //        table.ColumnUniqueIdentifier("dbo", "fields_latlong", "_$id", false);
            //        table.ColumnUniqueIdentifier("dbo", "fields_latlong", "LaPoste_$id", false);
            //        table.ColumnFloat("dbo", "fields_latlong", "value", true);
            //    })

            //    .Table("dbo", "geometry_coordinates", table =>
            //    {
            //        table.ColumnUniqueIdentifier("dbo", "geometry_coordinates", "_$id", false);
            //        table.ColumnUniqueIdentifier("dbo", "geometry_coordinates", "LaPoste_$id", false);
            //        table.ColumnFloat("dbo", "geometry_coordinates", "value", true);
            //    })

            //    .Table("dbo", "LaPoste", table =>
            //    {
            //        table.ColumnUniqueIdentifier("dbo", "LaPoste", "_$id", false);
            //        table.ColumnVarchar("dbo", "LaPoste", "datasetid", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "recordid", true, 1);
            //        table.ColumnDatetime("dbo", "LaPoste", "record_timestamp", true);
            //        table.ColumnFloat("dbo", "LaPoste", "fields_longitude", true);
            //        table.ColumnFloat("dbo", "LaPoste", "fields_latitude", true);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_libelle_du_site", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_site_acores_de_rattachement", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_identifiant_a", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_localite", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_adresse", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_code_insee", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_precision_du_geocodage", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_numero_de_telephone", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_pays", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_complement_d_adresse", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_code_postal", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_caracteristique_du_site", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "fields_lieu_dit", true, 1);
            //        table.ColumnVarchar("dbo", "LaPoste", "geometry_type", true, 1);
            //    })

            //    .ForeignKey("dbo", "rel_LaPoste_tofields_latlong"
            //        , "fields_latlong", new string[] { "LaPoste_$id" }
            //        , "LaPoste", new string[] { "_$id" }
            //    )

            //    .ForeignKey("dbo", "rel_LaPoste_togeometry_coordinates"
            //        , "geometry_coordinates", new string[] { "LaPoste_$id" }
            //        , "LaPoste", new string[] { "_$id" }
            //    )
            //    ;

            #endregion Test

            var file = Path.Combine(this._dir.FullName, testName + ".dacpac");
            if (File.Exists(file))
                File.Delete(file);

            package.Write(file);
           

            //var opt = new DataSetToCodeDomOption(new SqlserverTargetServer());
            //var visitor2 = new DataSetToCodeDomVisitor(opt);

            //var code = visitor2.Visit(generator.DataSet);
            //LocalCodeGenerator.GenerateSqlServerCodeToDirectory(visitor2.CodeCompileUnit, dir.FullName);

        }

        private void Save(string testName, DacDataSchemaModel dac)
        {

            var txtDac = dac.GetToString();

            var file = Path.Combine(this._dir.FullName, testName + ".txt");
            if (File.Exists(file))
                File.Delete(file);

            File.WriteAllText(file, txtDac);
        }

        private static JsonSchema GetSchema(JToken datas)
        {
            JsonSchema schema = null;
            string jsonpath = string.Empty;
            JArray tokens;

            if (!string.IsNullOrEmpty(jsonpath))
                tokens = new JArray(datas.SelectTokens(jsonpath));

            else
            {
                if (datas is JArray a)
                    tokens = a;
                else
                    tokens = new JArray(datas);
            }

            if (tokens.Count > 0)
            {

                var type = tokens[0].Type;

                switch (type)
                {

                    case JTokenType.Array:
                        break;

                    case JTokenType.Object:
                        JObject first1 = null;
                        foreach (var item in tokens)
                        {
                            if (first1 == null)
                                first1 = item as JObject;
                            else
                                first1.Merge(item);
                        }
                        schema = JsonSchema.FromSampleJson(first1.ToString());
                        break;

                    case JTokenType.Integer:
                    case JTokenType.Float:
                    case JTokenType.String:
                    case JTokenType.Boolean:
                    case JTokenType.Date:
                    case JTokenType.Bytes:
                    case JTokenType.Guid:
                    case JTokenType.Uri:
                    case JTokenType.TimeSpan:
                        //JValue first2 = null;
                        //foreach (var item in tokens)
                        //{
                        //    if (first2 == null)
                        //        first2 = item as JValue;
                        //    else
                        //        first2.Merge(item);
                        //}
                        //schema = JsonSchema.FromSampleJson(first2.ToString());
                        break;


                    case JTokenType.Comment:
                        break;
                    case JTokenType.Null:
                    case JTokenType.Undefined:
                    case JTokenType.Raw:
                    case JTokenType.None:
                    case JTokenType.Constructor:
                    case JTokenType.Property:
                    default:
                        break;
                }


            }

            return schema;

        }

        private readonly System.IO.DirectoryInfo? _dir;

    }
}