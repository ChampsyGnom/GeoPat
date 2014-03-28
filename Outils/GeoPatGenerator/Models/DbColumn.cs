using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.Models
{
    public  class DbColumn
    {
        public String DisplayName { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
        public String DataType { get; set; }
        public Boolean AllowNull { get; set; }
        public Nullable<Int32> Length { get; set; }

      
        public String ToPostgreSqlDefinition()
        {
            string result = null;
            if (this.DataType.StartsWith("VARCHAR"))
            {
                result = "character varying(" + Length.Value + ")";
            }
            else if (this.DataType.StartsWith("NUMBER"))
            {
                if (this.DataType.IndexOf(",") == -1)
                { result = "integer"; }
                else
                { result = "real"; }
               
            }
            else if (this.DataType.StartsWith("INTEGER"))
            { result = "integer"; }
            else if (this.DataType.StartsWith("SMALLINT"))
            { result = "boolean"; }
            else if (this.DataType.StartsWith("FLOAT"))
            { result = "real"; }
            else if (this.DataType.StartsWith("DATE"))
            { result = "date"; }
            else
            {
                Console.WriteLine(this.DataType);
            }
            if (!this.AllowNull && result != null)
            { result += " NOT NULL"; }
            return result;
        }
    }
}
