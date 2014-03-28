using Emash.GeoPat.Generator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Emash.GeoPat.Generator.IO
{
    public class PowerAmcMpdReader
    {
        public String FileName { get; private set; }
        public PowerAmcMpdReader(String fileName)
        {
            this.FileName = fileName;
        }

        public DbSchema Read()
        {
            XmlDocument document = new XmlDocument();
            using (FileStream stream = new FileStream(this.FileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    String txt = reader.ReadToEnd();
                    txt = txt.Replace("a:", "");
                    txt = txt.Replace("o:", "");
                    txt = txt.Replace("c:", "");
                    using (StringReader readerString = new StringReader(txt))
                    { document.Load(readerString); }
                }
            }
            XmlNode nodeModel = document.SelectSingleNode("/Model/RootObject/Children/Model");
            if (nodeModel != null)
            {
                DbSchema schema = new DbSchema();
                schema.Id = nodeModel.Attributes["Id"].Value;
                schema.Name = nodeModel.SelectSingleNode("Code").InnerText;
                schema.DisplayName = nodeModel.SelectSingleNode("Name").InnerText;


                XmlNodeList nodeReferences = nodeModel.SelectNodes("References/Reference");
                foreach (XmlNode nodeReference in nodeReferences)
                {

                    if (nodeReference.SelectSingleNode("Cardinality").InnerText.Equals("0..*"))
                    {
                        DbKeyForeign fk = new DbKeyForeign();
                        fk.Id = nodeReference.Attributes["Id"].Value;
                        fk.Name = nodeReference.SelectSingleNode("Code").InnerText;
                        fk.DisplayName = nodeReference.SelectSingleNode("Name").InnerText;
                        fk.TableIdParent = nodeReference.SelectSingleNode("ParentTable/Table").Attributes["Ref"].Value;
                        fk.TableIdChild = nodeReference.SelectSingleNode("ChildTable/Table").Attributes["Ref"].Value;
                        
                        fk.UpdateOnCascade = nodeReference.SelectSingleNode("UpdateConstraint").InnerXml.Equals("1");
                        fk.DeleteOnCascade = nodeReference.SelectSingleNode("DeleteConstraint").InnerXml.Equals("1");
                        XmlNodeList nodeJoins = nodeReference.SelectNodes("Joins/ReferenceJoin");
                        foreach (XmlNode nodeJoin in nodeJoins)
                        {
                            DbKeyForeignJoin join = new DbKeyForeignJoin();
                            join.Id = nodeJoin.Attributes["Id"].Value;
                            join.ColumnIdParent = nodeJoin.SelectSingleNode("Object1/Column").Attributes["Ref"].Value;
                            join.ColumnIdChild = nodeJoin.SelectSingleNode("Object2/Column").Attributes["Ref"].Value;
                          

                            fk.Joins.Add(join);
                        }
                        schema.ForeignKeys.Add (fk);
                    }
                }

                XmlNodeList nodes = document.SelectNodes("/Model/RootObject/Children/Model/Tables/Table");
                foreach (XmlNode nodeTable in nodes)
                {
                    DbTable table = new DbTable();
                    table.Id =  nodeTable.Attributes["Id"].Value;
                    table.Name = nodeTable.SelectSingleNode("Code").InnerText;
                    table.DisplayName = nodeTable.SelectSingleNode("Name").InnerText;                   
                    XmlNodeList nodeColumns = nodeTable.SelectNodes("Columns/Column");

                    XmlNode nodePk = nodeTable.SelectSingleNode("Keys/Key");
                    if (nodePk != null)
                    {
                        DbKeyPrimary pk = new DbKeyPrimary();
                        pk.Id = nodePk.Attributes["Id"].Value;
                        pk.Name = nodePk.SelectSingleNode("Code").InnerText;
                        pk.DisplayName = nodePk.SelectSingleNode("Name").InnerText;
                        XmlNodeList pkColumnNodeList = nodePk.SelectNodes("Key.Columns/Column");
                        foreach (XmlNode pkColumnNode in pkColumnNodeList)
                        { pk.ColumnIds.Add(pkColumnNode.Attributes["Ref"].Value); }
                        pk.TableId = table.Id;
                        schema.PrimaryKeys.Add(pk);
                    }


                    XmlNodeList nodeIndexes = nodeTable.SelectNodes("Indexes/Index");
                    foreach (XmlNode nodeIndex in nodeIndexes)
                    {
                        if (nodeIndex.SelectSingleNode("Code") != null)
                        {
                            String name = nodeIndex.SelectSingleNode("Code").InnerText;
                            
                            if (nodeIndex.SelectSingleNode("Unique") != null && nodeIndex.SelectSingleNode("Unique").InnerText.Equals("1"))
                            {
                                DbKeyUnique uk = new DbKeyUnique();
                                uk.Id = nodeIndex.Attributes["Id"].Value;
                                uk.Name = nodeIndex.SelectSingleNode("Code").InnerText;
                                uk.DisplayName = nodeIndex.SelectSingleNode("Name").InnerText;
                                uk.TableId = table.Id;
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
                                schema.UniqueKeys.Add(uk);
                            }
                        }
                    }



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
                        table.Columns.Add(column);
                    }
                    schema.Tables.Add(table);

                }
                return schema;
            }
            return null;
        }
    }
}
