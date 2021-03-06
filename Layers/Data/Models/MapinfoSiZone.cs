using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SI_ZONE",Schema="MAPINFO")]
    public partial class MapinfoSiZone
    {
        [Key]
        [Description("Si Model  Nom Model")]
        [Column("SI_MODEL__NOM_MODEL",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String SiModelNomModel { get; set; }
        
        [Key]
        [Description("Si Zone  Nom Zone")]
        [Column("NOM_ZONE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String NomZone { get; set; }
        
        [Description("Si Zone  Schema Zone")]
        [Column("SCHEMA_ZONE",Order=2)]
        [MaxLength(100)] 
        public String SchemaZone { get; set; }
        
        [Description("Si Zone  Table Zone")]
        [Column("TABLE_ZONE",Order=3)]
        [MaxLength(100)] 
        public String TableZone { get; set; }
        
        [Description("Si Zone  Field Zone")]
        [Column("FIELD_ZONE",Order=4)]
        [MaxLength(100)] 
        public String FieldZone { get; set; }
        
        [Description("Si Zone  Type Zone")]
        [Column("TYPE_ZONE",Order=5)]
        [MaxLength(25)] 
        public String TypeZone { get; set; }
        
        [Description("Si Zone  Position")]
        [Column("POSITION",Order=6)]
        public Nullable<Int64> Position { get; set; }
        
        [Description("Si Zone  Hauteur")]
        [Column("HAUTEUR",Order=7)]
        public Nullable<Int64> Hauteur { get; set; }
        
        [Description("Si Zone  Valeur")]
        [Column("VALEUR",Order=8)]
        [MaxLength(100)] 
        public String Valeur { get; set; }
        
        [Description("Si Zone  Valeur Sub")]
        [Column("VALEUR_SUB",Order=9)]
        [MaxLength(100)] 
        public String ValeurSub { get; set; }
        
        [Description("Si Zone  Annee Mesure")]
        [Column("ANNEE_MESURE",Order=10)]
        public Nullable<Int64> AnneeMesure { get; set; }
        
        [Description("Si Zone  Position Etiquette")]
        [Column("POSITION_ETIQUETTE",Order=11)]
        [MaxLength(20)] 
        public String PositionEtiquette { get; set; }
        
        [Description("Si Zone  Champ Etiquette")]
        [Column("CHAMP_ETIQUETTE",Order=12)]
        [MaxLength(50)] 
        public String ChampEtiquette { get; set; }
        
        [Description("Si Zone  WithCote")]
        [Column("WITHCOTE",Order=13)]
        public Nullable<Int64> Withcote { get; set; }
        
    }
}
