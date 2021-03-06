using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("STYLE_WEB",Schema="WEB")]
    public partial class WebStyle
    {
        [Key]
        [Description("Identifiant du style")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Nom du schéma (optionel)")]
        [Column("SCHEMA_NAME",Order=1)]
        [MaxLength(255)] 
        public String SchemaName { get; set; }
        
        [Description("Nom de la table (optionel)")]
        [Column("TABLE_NAME",Order=2)]
        [MaxLength(255)] 
        public String TableName { get; set; }
        
        [Description("Nom de la colonne (optionel)")]
        [Column("COLUMN_NAME",Order=3)]
        [MaxLength(255)] 
        public String ColumnName { get; set; }
        
        [Description("Libellé du style")]
        [Column("LIBELLE",Order=4)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
        [Description("Style par défaut")]
        [Column("DEFAUT",Order=5)]
        [Required()]
        public Boolean Defaut { get; set; }
        
    }
}
