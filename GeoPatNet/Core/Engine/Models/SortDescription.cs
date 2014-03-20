using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Models
{
    /// <summary>
    /// Description d'un trie
    /// @TODO : voir si on peut pas utiliser quelque chose qui existe deja dans ComponentModel à la place
    /// </summary>
    public  class SortInfo
    {
        /// <summary>
        /// Ordre du trie
        /// </summary>
        public Int32 Order { get; set; }
        /// <summary>
        /// FieldPath
        /// </summary>
        public String FieldPath { get; set; }
        /// <summary>
        /// Direction du trie
        /// </summary>
        public ListSortDirection Direction { get; set; }
    }
}
