using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ForeignKeyAttribute : Attribute 
    {
        public String ForeignKeyName { get; private set; }
        public String JoinName { get; private set; }

        public ForeignKeyAttribute(string foreignKeyName, String joinName)
        {
            this.ForeignKeyName = foreignKeyName;
            this.JoinName = joinName;
        }
    }
}
