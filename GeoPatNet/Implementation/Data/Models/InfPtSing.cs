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
	[DisplayName("Point singulier")]
    [TableName("INF_PT_SING")]
    [SchemaName("INF")]
    public class InfPtSing : IInfPtSing
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code point singulier")]
        [ColumnName("INF_CD_PT_SING__ID")]
        public virtual InfCodePtSing InfCodePtSing
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_PT_SING__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_PT_SING__ABS_DEB")]
        [UniqueKey("INF_PT_SING_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PT_SING__ID")]
        [PrimaryKey("INF_PT_SING_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_PT_SING","JOIN_o753")]
        [UniqueKey("INF_PT_SING_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code point singulier")]
        [ColumnName("INF_CD_PT_SING__ID")]
        [ForeignKey("INF_CD_PT_SING__INF_PT_SING","JOIN_o772")]
        [UniqueKey("INF_PT_SING_UK_REF")]
        public Int64 InfCodePtSingId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_PT_SING__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Nom d'usage")]
        [ColumnName("INF_PT_SING__NOM")]
        public String Nom
        {
            get;
            set;
        }


    }
}
