using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code point singulier")]
    [TableName("INF_CD_PT_SING")]
    [SchemaName("INF")]
    public class InfCodePtSing : IInfCodePtSing
    {
    	
        [DisplayName("Point singuliers")]
        public virtual ICollection<InfPtSing> InfPtSings
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_PT_SING__CODE")]
        [UniqueKey("INF_CD_PT_SING_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_PT_SING__ID")]
        [PrimaryKey("INF_CD_PT_SING_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libelle")]
        [ColumnName("INF_CD_PT_SING__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
