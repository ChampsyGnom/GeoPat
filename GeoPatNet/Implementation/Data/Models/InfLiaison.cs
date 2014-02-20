using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Liaison")]
    [TableName("INF_LIAISON")]
    [SchemaName("INF")]
    public class InfLiaison : IInfLiaison
    {
    	
        [DisplayName("Chaussées")]
        public virtual ICollection<InfChaussee> InfChaussees
        {
            get;
            set;
        }
        [DisplayName("Type liaison")]
        [ColumnName("INF_CD_LIAISON__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_LIAISON__INF_LIAISON",null)]
        public virtual InfCodeLiaison InfCodeLiaison
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_LIAISON__CODE")]
        [UniqueKey("INF_LIAISON_UK_REF")]
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
        [ColumnName("INF_LIAISON__ID")]
        [PrimaryKey("INF_LIAISON_PK")]
        [ForeignKeyAttribute("INF_LIAISON__CHAUSSEE_INF","JOIN_o794")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant type liaison")]
        [ColumnName("INF_CD_LIAISON__ID")]
        [ForeignKey("INF_CD_LIAISON__INF_LIAISON","JOIN_o786")]
        [UniqueKey("INF_LIAISON_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeLiaisonId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_LIAISON__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
