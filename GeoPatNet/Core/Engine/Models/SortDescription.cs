using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Models
{
    public  class SortInfo
    {
        public Int32 Order { get; set; }
        public String FieldPath { get; set; }
        public ListSortDirection Direction { get; set; }
    }
}
