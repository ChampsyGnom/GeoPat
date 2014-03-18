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
	[DisplayName("Schémas")]
    [TableName("PRF_SCHEMA")]
    [SchemaName("PRF")]
    public class PrfSchema 
    {
    	
        [DisplayName("Paramètress")]
        public virtual ICollection<PrfParam> PrfParams
        {
            get;
            set;
        }
        [DisplayName("Privilègess")]
        public virtual ICollection<PrfRight> PrfRights
        {
            get;
            set;
        }
        [DisplayName("Profilss")]
        public virtual ICollection<PrfProfil> PrfProfils
        {
            get;
            set;
        }
        [DisplayName("Tabless")]
        public virtual ICollection<PrfTable> PrfTables
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_SCHEMA__ID")]
        [PrimaryKey("PRF_SCHEMA_PK")]
        [ForeignKeyAttribute("PRF_SCHEMA__PRF_PARAM","JOIN_o154")]
        [ForeignKeyAttribute("PRF_SCHEMA__PRF_RIGHT","JOIN_o155")]
        [ForeignKeyAttribute("ASSOCIATION_2","JOIN_o153")]
        [ForeignKeyAttribute("PRF_SCHEMA__PRF_TABLE","JOIN_o152")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("PRF_SCHEMA__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("PRF_SCHEMA__NAME")]
        [UniqueKey("PRF_SCHEMA_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Name
        {
            get;
            set;
        }


    }
}
