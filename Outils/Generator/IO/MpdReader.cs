using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Emash.GeoPatNet.Generator.Models;
namespace Emash.GeoPatNet.Generator.IO
{
    public class MpdReader 
    {
        public DbSchema DbSchema { get; set; }
        public MpdReader(String fileName)
        {
            FileStream stream = new FileStream(fileName,FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            XmlDocument doc = new XmlDocument();
            String txt = reader.ReadToEnd();
            txt = txt.Replace("a:", "");
            txt = txt.Replace("o:", "");
            txt = txt.Replace("c:", "");
            StringReader readerString = new StringReader(txt);
            doc.Load(readerString);
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            DbSchema schema = this.LoadSchema(doc);
            this.LoadConstraints(schema, doc);
            this.DbSchema = schema;
            
        }

        private void LoadConstraints(DbSchema schema, XmlDocument doc)
        {
            XmlNode nodeModel = doc.SelectSingleNode("/Model/RootObject/Children/Model");          
            XmlNodeList nodes = doc.SelectNodes("/Model/RootObject/Children/Model/Tables/Table");

          

            XmlNodeList nodeReferences = nodeModel.SelectNodes("References/Reference");
            foreach (XmlNode nodeReference in nodeReferences)
            {
                
                if (nodeReference.SelectSingleNode("Cardinality").InnerText.Equals("0..*"))
                {
                    DbForeignKey fk = new DbForeignKey();
                    fk.Id = nodeReference.Attributes["Id"].Value;
                    fk.Name = nodeReference.SelectSingleNode("Code").InnerText;
                    fk.DisplayName = nodeReference.SelectSingleNode("Name").InnerText;
                    DbTable parentTable = (from t in schema.Tables where t.Id.Equals (nodeReference.SelectSingleNode ("ParentTable/Table").Attributes["Ref"].Value) select t).FirstOrDefault();
                    DbTable childTable = (from t in schema.Tables where t.Id.Equals(nodeReference.SelectSingleNode("ChildTable/Table").Attributes["Ref"].Value) select t).FirstOrDefault();
                    fk.ParentTableId = parentTable.Id;
                    fk.ChildTableId = childTable.Id;
                    childTable.ForeignKeys.Add(fk);
                    fk.UpdateOnCascade = nodeReference.SelectSingleNode("UpdateConstraint").InnerXml.Equals("1");
                    fk.DeleteOnCascade = nodeReference.SelectSingleNode("DeleteConstraint").InnerXml.Equals("1");
                    XmlNodeList nodeJoins = nodeReference.SelectNodes("Joins/ReferenceJoin");
                    foreach (XmlNode nodeJoin in nodeJoins)
                    {
                        DbForeignKeyJoin join = new DbForeignKeyJoin();
                        join.Id = nodeJoin.Attributes["Id"].Value;
                        String parentRef = nodeJoin.SelectSingleNode("Object1/Column").Attributes["Ref"].Value;
                        String childRef = nodeJoin.SelectSingleNode("Object2/Column").Attributes["Ref"].Value;
                        DbColumn parentColumn = (from c in parentTable.Columns where c.Id.Equals(parentRef) select c).FirstOrDefault();
                        DbColumn childColumn = (from c in childTable.Columns where c.Id.Equals(childRef) select c).FirstOrDefault();
                        if (parentColumn == null) throw new Exception ("Colonne parent null");
                        if (childColumn == null) throw new Exception("Colonne fille null");
                        join.ParentColumnId = parentColumn.Id;
                        join.ChildColumnId = childColumn.Id;
                       
                        fk.Joins.Add(join);
                    }
                }
            }

            foreach (XmlNode nodeTable in nodes)
            {
                String id = nodeTable.Attributes["Id"].Value;
                DbTable table = (from t in schema.Tables where t.Id.Equals(id) select t).FirstOrDefault();
                XmlNode nodePk = nodeTable.SelectSingleNode("Keys/Key");
                if (nodePk != null)
                {
                    DbPrimaryKey pk = new DbPrimaryKey();
                    pk.Id = nodePk.Attributes["Id"].Value;
                    pk.Name = nodePk.SelectSingleNode("Code").InnerText;
                    pk.DisplayName = nodePk.SelectSingleNode("Name").InnerText;
                    XmlNodeList pkColumnNodeList = nodePk.SelectNodes("Key.Columns/Column");
                    foreach (XmlNode pkColumnNode in pkColumnNodeList)
                    { pk.ColumnIds.Add(pkColumnNode.Attributes["Ref"].Value); }

                    table.PrimaryKey = pk;
                }
                if (table.PrimaryKey == null)
                {
                    throw new Exception("Table " + table.Name + " sans clé primaire");
                }
                XmlNodeList nodeIndexes = nodeTable.SelectNodes("Indexes/Index");
                foreach (XmlNode nodeIndex in nodeIndexes)
                {
                    if (nodeIndex.SelectSingleNode("Code") != null)
                    {
                        String name = nodeIndex.SelectSingleNode("Code").InnerText;
                        if ((table.PrimaryKey != null && !table.PrimaryKey.Name.Equals(name)) || table.PrimaryKey == null)
                        {
                            if (nodeIndex.SelectSingleNode("Unique") != null && nodeIndex.SelectSingleNode("Unique").InnerText.Equals("1"))
                            {
                                DbUniqueKey uk = new DbUniqueKey();
                                uk.Id = nodeIndex.Attributes["Id"].Value;
                                uk.Name = nodeIndex.SelectSingleNode("Code").InnerText;
                                uk.DisplayName = nodeIndex.SelectSingleNode("Name").InnerText;
                                XmlNodeList pkColumnNodeList = nodeIndex.SelectNodes("IndexColumns/IndexColumn");
                                foreach (XmlNode pkColumnNode in pkColumnNodeList)
                                {
                                    XmlNode nodCol = pkColumnNode.SelectSingleNode("IndexColumn.Expression");
                                    if (nodCol != null)
                                    {
                                        String expression = nodCol.InnerText;
                                        expression = expression.Replace(" ", "");
                                        expression = expression.Replace("(", "");
                                        expression = expression.Replace(")", "");
                                        DbColumn column = (from c in table.Columns where c.Name.Equals(expression) select c).FirstOrDefault();
                                        uk.ColumnIds.Add(column.Id);
                                    }

                                }
                                if (uk.ColumnIds.Count > 0)
                                {
                                    table.UniqueKeys.Add(uk);
                                }

                            }
                        }
                    }

                }

            

            }
            
        }

        private DbSchema LoadSchema(XmlDocument doc)
        {
            XmlNode nodeModel = doc.SelectSingleNode("/Model/RootObject/Children/Model");
            DbSchema schema = new DbSchema();
            schema.Id = nodeModel.Attributes["Id"].Value;
            schema.Name = nodeModel.SelectSingleNode("Code").InnerText;
            schema.DisplayName = nodeModel.SelectSingleNode("Name").InnerText;

            XmlNodeList nodeRules = doc.SelectNodes("/Model/RootObject/Children/Model/BusinessRules/BusinessRule");
            

            foreach (XmlNode nodeRule in nodeRules)
            {
                String serverExpression = nodeRule.SelectSingleNode("ServerExpression").InnerText;
                if (serverExpression.StartsWith("@PR"))
                {
                    DbRulePr rulePr = new DbRulePr();
                    rulePr.Id = nodeRule.Attributes["Id"].Value;
                    rulePr.ChausseIdColumnName = serverExpression.Replace("@PR", "").Replace("(", "").Replace(")", "");
                    schema.Rules.Add(rulePr);
                }

                if (serverExpression.StartsWith("@EMPRISE_CHAUSSEE"))
                {
                    DbRuleEmprise ruleEmprise = new DbRuleEmprise();
                    ruleEmprise.Id = nodeRule.Attributes["Id"].Value;
                    ruleEmprise.ChausseIdColumnName = serverExpression.Replace("@EMPRISE_CHAUSSEE", "").Replace("(", "").Replace(")", "");
                    schema.Rules.Add(ruleEmprise);
                }

                if (serverExpression.StartsWith("@COLOR"))
                {
                    DbRuleColor ruleColor = new DbRuleColor();
                    ruleColor.Id = nodeRule.Attributes["Id"].Value;
                    schema.Rules.Add(ruleColor);
                }
                if (serverExpression.StartsWith("@LOCATION_REF"))
                {
                    DbRuleLocationRef ruleLocation = new DbRuleLocationRef();
                 
                    ruleLocation.Id = nodeRule.Attributes["Id"].Value;
                    schema.Rules.Add(ruleLocation);
                }
                if (serverExpression.StartsWith("@LOCATION_REF_GEOM"))
                {
                    DbRuleLocationRefGeom ruleLocation = new DbRuleLocationRefGeom();
                     ruleLocation.Id = nodeRule.Attributes["Id"].Value;
                    schema.Rules.Add(ruleLocation);
                }
                if (serverExpression.StartsWith("@LOCATION_DEB"))
                {
                    DbRuleLocationDeb ruleLocation = new DbRuleLocationDeb();
                    ruleLocation.Id = nodeRule.Attributes["Id"].Value;
                    schema.Rules.Add(ruleLocation);
                }
                if (serverExpression.StartsWith("@LOCATION_FIN"))
                {
                    DbRuleLocationFin ruleLocation = new DbRuleLocationFin();
                   ruleLocation.Id = nodeRule.Attributes["Id"].Value;
                    schema.Rules.Add(ruleLocation);
                }
            }


            XmlNodeList nodes = doc.SelectNodes("/Model/RootObject/Children/Model/Tables/Table");
            foreach (XmlNode nodeTable in nodes)
            {

                String id = nodeTable.Attributes["Id"].Value;
                DbTable table = new DbTable();
                table.Id = id;
                table.Name = nodeTable.SelectSingleNode("Code").InnerText;
                if (table.Name.Equals("INF_CD_SERVICE"))
                {
                    Console.WriteLine("Toto");
                }
                table.DisplayName = nodeTable.SelectSingleNode("Name").InnerText;

                XmlNodeList nodeTableRules = nodeTable.SelectNodes("AttachedRules/BusinessRule");
                foreach (XmlNode nodeTableRule in nodeTableRules)
                {
                    String ruleId = nodeTableRule.Attributes["Ref"].Value;
                    DbRule rule = (from s in schema.Rules where s.Id.Equals(ruleId) select s).FirstOrDefault();
                    if (rule != null)
                    {
                        table.Rules.Add(rule);
                    }
                }


                XmlNodeList nodeColumns = nodeTable.SelectNodes("Columns/Column");
                foreach (XmlNode nodeColumn in nodeColumns)
                {
                    DbColumn column = new DbColumn();
                    column.Id = nodeColumn.Attributes["Id"].Value;
                    column.Name = nodeColumn.SelectSingleNode("Code").InnerText;
                    column.DisplayName = nodeColumn.SelectSingleNode("Name").InnerText;
                    column.DataType = nodeColumn.SelectSingleNode("DataType").InnerText;
                    column.Length = null;
                    if (nodeColumn.SelectSingleNode("Length") != null)
                    { column.Length = Int32.Parse(nodeColumn.SelectSingleNode("Length").InnerText); }

                    column.AllowNull = true;
                    if (nodeColumn.SelectSingleNode("Mandatory") != null)
                    {
                        if (nodeColumn.SelectSingleNode("Mandatory").InnerText.Equals("1"))
                        { column.AllowNull = false; }

                    }
                    XmlNodeList nodeColumnRules = nodeColumn.SelectNodes("AttachedRules/BusinessRule");
                    foreach (XmlNode nodeColumnRule in nodeColumnRules)
                    {
                        String ruleId = nodeColumnRule.Attributes["Ref"].Value;
                        DbRule rule = (from s in schema.Rules where s.Id.Equals (ruleId ) select s).FirstOrDefault();
                        if (rule != null)
                        {
                             column.Rules.Add(rule);
                        }


                    }
                    table.Columns.Add(column);
                }




                schema.Tables.Add(table);

           
            }
            
            return schema;
        }

       
    }
}
