using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnNameAttribute : Attribute
    {
        public String ColumnName { get; private set; }

        public ColumnNameAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
    }
}
