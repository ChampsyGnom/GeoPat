using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Privilèges")]
    [TableName("PRF_RIGHT")]
    [SchemaName("PRF")]
    public class PrfRight 
    {
    	
        [DisplayName("Privilège des profilss")]
        public virtual ICollection<PrfProfilRight> PrfProfilRights
        {
            get;
            set;
        }
        [DisplayName("Schémas")]
        [ColumnName("PRF_SCHEMA__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_SCHEMA__PRF_RIGHT",null)]
        public virtual PrfSchema PrfSchema
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("PRF_RIGHT__CODE")]
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
        [ColumnName("PRF_RIGHT__ID")]
        [PrimaryKey("PRF_RIGHT_PK")]
        [ForeignKeyAttribute("PRF_RIGHT__PRF_PROFIL_RIGHT","JOIN_o140")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("PRF_SCHEMA__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfSchemaId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("PRF_RIGHT__LIBELLE")]
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
