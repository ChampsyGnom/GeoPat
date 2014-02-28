using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emash.GeoPatNet.Generator.Models
{
    public class DbTable
    {
        public List<DbUniqueKey> UniqueKeys { get; set; }
        public List<DbForeignKey> ForeignKeys { get; set; }
        public DbPrimaryKey PrimaryKey { get; set; }
        public List<DbColumn> Columns { get; set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        [XmlElement(Type = typeof(DbRulePr), ElementName = "RulePr")]
        [XmlElement(Type = typeof(DbRuleEmprise), ElementName = "RuleEmprise")]
        [XmlElement(Type = typeof(DbRuleColor), ElementName = "RuleColor")]
        public List<DbRule> Rules { get; set; }
        public DbTable()
        {
            this.UniqueKeys = new List<DbUniqueKey>();
            this.ForeignKeys = new List<DbForeignKey>();
            this.PrimaryKey = null;
            this.Columns = new List<DbColumn>();
            this.Rules = new List<DbRule>();
        }
    }
}
