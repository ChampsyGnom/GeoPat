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
	[DisplayName("Document")]
    [TableName("INF_DOC")]
    [SchemaName("INF")]
    public class InfDoc 
    {
    	
        [DisplayName("Document des classeurss")]
        public virtual ICollection<InfDocCls> InfDocClss
        {
            get;
            set;
        }
        [DisplayName("Code document")]
        [ColumnName("INF_CD_DOC__CODE")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_DOC__INF_DOC",null)]
        public virtual InfCodeDoc InfCodeDoc
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_DOC__CODE")]
        [ForeignKey("INF_CD_DOC__INF_DOC","JOIN_o966")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String InfCodeDocCode
        {
            get;
            set;
        }
        [DisplayName("Fichier")]
        [ColumnName("INF_DOC__FILENAME")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Filename
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_DOC__ID")]
        [PrimaryKey("INF_DOC_PK")]
        [ForeignKeyAttribute("ASSOCIATION_54","JOIN_o914")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("INF_CD_DOC__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeDocId
        {
            get;
            set;
        }
        [DisplayName("Informations")]
        [ColumnName("INF_DOC__INFO")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_DOC__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Répertoire")]
        [ColumnName("INF_CD_DOC__PATH")]
        [ForeignKey("INF_CD_DOC__INF_DOC","JOIN_o967")]
        [MaxCharLength(255)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String InfCodeDocPath
        {
            get;
            set;
        }


    }
}
