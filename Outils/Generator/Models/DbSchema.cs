using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Emash.GeoPatNet.Generator.Models
{
    public class DbSchema
    {
        public List<DbTable> Tables { get; set; }
        public List<DbView> Views { get; set; }
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        [XmlElement(Type=typeof(DbRulePr),ElementName="RulePr")]
        public List<DbRule> Rules { get; set; }
        public DbSchema()
        {
            this.Tables = new List<DbTable>();
            this.Rules = new List<DbRule>();
            this.Views = new List<DbView>();
        }
    }
}
