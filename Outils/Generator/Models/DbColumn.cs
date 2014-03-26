using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbColumn
    {

        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public String DataType { get; set; }
        public Boolean AllowNull { get; set; }
        public Nullable<Int32> Length { get; set; }
        [XmlElement(Type = typeof(DbRulePr), ElementName = "RulePr")]
        [XmlElement(Type = typeof(DbRuleEmprise), ElementName = "RuleEmprise")]
        [XmlElement(Type = typeof(DbRuleColor), ElementName = "RuleColor")]
        [XmlElement(Type = typeof(DbRuleLocationRef), ElementName = "RuleLocationRef")]
        [XmlElement(Type = typeof(DbRuleLocationRefGeom), ElementName = "RuleLocationRefGeom")]
        [XmlElement(Type = typeof(DbRuleLocationDeb), ElementName = "RuleLocationDeb")]
        [XmlElement(Type = typeof(DbRuleLocationFin), ElementName = "RuleLocationFin")]  

        public List<DbRule> Rules { get; set; }

        public DbColumn()
        {
            this.Rules = new List<DbRule>();
        }
        internal string GetSqlPostgreDefinition()
        {
            if (DataType.Equals("SERIAL"))
            { return this.Name + " serial NOT NULL"; }
            else if (DataType.StartsWith("VARCHAR"))
            {
                if (AllowNull)
                { return this.Name + " character varying("+this.Length+")"; }
                else
                { return this.Name + " character varying(" + this.Length + ") NOT NULL"; }

            }
            else if (DataType.Equals("VBIN"))
            {
                if (AllowNull)
                { return this.Name + " text"; }
                else
                { return this.Name + " text NOT NULL"; }
            }
            else if (DataType.Equals("INT4"))
            {
                if (AllowNull)
                { return this.Name + " integer"; }
                else
                { return this.Name + " integer NOT NULL"; }

            }
            else if (DataType.Equals("DATE"))
            {
                if (AllowNull)
                { return this.Name + " date"; }
                else
                { return this.Name + " date NOT NULL"; }

            }
            else if (DataType.Equals("BOOL"))
            {
                if (AllowNull)
                { return this.Name + " boolean"; }
                else
                { return this.Name + " boolean NOT NULL"; }

            }
            else if (DataType.Equals("BOOL"))
            {
                if (AllowNull)
                { return this.Name + " boolean"; }
                else
                { return this.Name + " boolean NOT NULL"; }

            }
            else if (DataType.Equals("FLOAT8"))
            {
                if (AllowNull)
                { return this.Name + " real"; }
                else
                { return this.Name + " real NOT NULL"; }

            }

            else Console.WriteLine(DataType);

     
            return null;
        }
    }
}
