using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code document")]
    [TableName("INF_CD_DOC")]
    [SchemaName("INF")]
    public class InfCodeDoc 
    {
    	
        [DisplayName("Documents")]
        public virtual ObservableCollection<InfDoc> InfDocs
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_DOC__CODE")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_DOC__ID")]
        [PrimaryKey("INF_CD_DOC_PK")]
        [ForeignKeyAttribute("INF_CD_DOC__INF_DOC","JOIN_o962")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_DOC__LIBELLE")]
        [MaxCharLength(255)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Répertoire")]
        [ColumnName("INF_CD_DOC__PATH")]
        [MaxCharLength(255)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Path
        {
            get;
            set;
        }


		public InfCodeDoc ()
		{
            this.InfDocs = new ObservableCollection<InfDoc>();
		}

    }
}
