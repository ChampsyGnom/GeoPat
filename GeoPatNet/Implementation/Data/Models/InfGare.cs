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
	[DisplayName("Gare")]
    [TableName("INF_GARE")]
    [SchemaName("INF")]
    public class InfGare : IInfGare
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code gare")]
        [ColumnName("INF_CD_GARE__ID")]
        public virtual InfCodeGare InfCodeGare
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_GARE__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_GARE__DATE_MS")]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_GARE__ABS_DEB")]
        [UniqueKey("INF_GARE_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_GARE__ID")]
        [PrimaryKey("INF_GARE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_GARE","JOIN_o749")]
        [UniqueKey("INF_GARE_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code gare")]
        [ColumnName("INF_CD_GARE__ID")]
        [ForeignKey("INF_CD_GARE__INF_GARE","JOIN_o769")]
        [UniqueKey("INF_GARE_UK_REF")]
        public Int64 InfCodeGareId
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        [ColumnName("INF_GARE__NUM_EXPLOIT")]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nb de voie de sortie")]
        [ColumnName("INF_GARE__NB_SORTIE")]
        public Nullable<Int64> NbSortie
        {
            get;
            set;
        }
        [DisplayName("Nb de voie d'entrée")]
        [ColumnName("INF_GARE__NB_ENTREE")]
        public Nullable<Int64> NbEntree
        {
            get;
            set;
        }
        [DisplayName("Nb de voie mixte")]
        [ColumnName("INF_GARE__NB_MIXTE")]
        public Nullable<Int64> NbMixte
        {
            get;
            set;
        }
        [DisplayName("Nb de voie TSA")]
        [ColumnName("INF_GARE__NB_TSA")]
        public Nullable<Int64> NbTsa
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("INF_GARE__NOM")]
        public String Nom
        {
            get;
            set;
        }


    }
}
