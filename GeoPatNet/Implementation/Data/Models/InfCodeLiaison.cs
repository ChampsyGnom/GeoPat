using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Type liaison")]
    [TableName("INF_CD_LIAISON")]
    [SchemaName("INF")]
    public class InfCodeLiaison : IInfCodeLiaison
    {
    	
        [DisplayName("Liaisons")]
        public virtual ICollection<InfLiaison> InfLiaisons
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_LIAISON__CODE")]
        [UniqueKey("INF_CD_LIAISON_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [DisplayName("Couleur")]
        [ColumnName("INF_CD_LIAISON__COULEUR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Color)]
        [AllowNull(true)]
        public String Couleur
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_LIAISON__ID")]
        [PrimaryKey("INF_CD_LIAISON_PK")]
        [ForeignKeyAttribute("INF_CD_LIAISON__INF_LIAISON","JOIN_o865")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_LIAISON__LIBELLE")]
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
