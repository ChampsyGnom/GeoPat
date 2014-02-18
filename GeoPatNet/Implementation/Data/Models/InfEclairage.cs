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
	[DisplayName("Eclairage")]
    [TableName("INF_ECLAIRAGE")]
    [SchemaName("INF")]
    public class InfEclairage : IInfEclairage
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code éclairage")]
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        public virtual InfCodeEclairage InfCodeEclairage
        {
            get;
            set;
        }
        [DisplayName("Code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        public virtual InfCodePosit InfCodePosit
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_ECLAIRAGE__ABS_DEB")]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_ECLAIRAGE__ID")]
        [PrimaryKey("INF_ECLAIRAGE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_ECLAIRAGE","JOIN_o748")]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code éclairage")]
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [ForeignKey("INF_CD_ECLAIRAGE__INF_ECLAIRAGE","JOIN_o768")]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public Int64 InfCodeEclairageId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [ForeignKey("INF_CD_POSIT__INF_ECLAIRAGE","JOIN_o773")]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public Int64 InfCodePositId
        {
            get;
            set;
        }


    }
}
