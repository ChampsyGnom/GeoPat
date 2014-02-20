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
	[DisplayName("Code éclairage")]
    [TableName("INF_CD_ECLAIRAGE")]
    [SchemaName("INF")]
    public class InfCodeEclairage : IInfCodeEclairage
    {
    	
        [DisplayName("Eclairages")]
        public virtual ICollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_ECLAIRAGE__CODE")]
        [UniqueKey("INF_CD_ECLAIRAGE_UK_REF")]
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
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [PrimaryKey("INF_CD_ECLAIRAGE_PK")]
        [ForeignKeyAttribute("INF_CD_ECLAIRAGE__INF_ECLAIRAGE","JOIN_o792")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_ECLAIRAGE__LIBELLE")]
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
