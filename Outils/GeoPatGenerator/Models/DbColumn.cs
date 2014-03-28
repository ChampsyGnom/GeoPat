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
    }
}
