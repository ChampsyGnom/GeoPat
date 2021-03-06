using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CONTACT_OH",Schema="OH")]
    public partial class OhContact
    {
        [Key]
        [Description("Id document")]
        [Column("DOC_OH__ID",Order=0)]
        [Required()]
        public Int64 DocOhId { get; set; }
        
        [Description("Prénom")]
        [Column("GIVENNAME",Order=1)]
        [MaxLength(60)] 
        public String Givenname { get; set; }
        
        [Description("Nom")]
        [Column("SN",Order=2)]
        [MaxLength(60)] 
        public String Sn { get; set; }
        
        [Description("Nom complet")]
        [Column("CN",Order=3)]
        [MaxLength(125)] 
        public String Cn { get; set; }
        
        [Description("Organisation")]
        [Column("O",Order=4)]
        [MaxLength(60)] 
        public String O { get; set; }
        
        [Description("Email")]
        [Column("MAIL",Order=5)]
        [MaxLength(60)] 
        public String Mail { get; set; }
        
        [Description("Téléphone fixe")]
        [Column("TELEPHONENUMBER",Order=6)]
        [MaxLength(20)] 
        public String Telephonenumber { get; set; }
        
        [Description("Téléphone mobile")]
        [Column("MOBILE",Order=7)]
        [MaxLength(20)] 
        public String Mobile { get; set; }
        
        [Description("Fax")]
        [Column("FACSIMILETELEPHONENUMBER",Order=8)]
        [MaxLength(20)] 
        public String Facsimiletelephonenumber { get; set; }
        
        [Description("Adresse")]
        [Column("STREET",Order=9)]
        [MaxLength(60)] 
        public String Street { get; set; }
        
        [Description("Adresse complémentaire")]
        [Column("MOZILLAWORKSTREET2",Order=10)]
        [MaxLength(60)] 
        public String Mozillaworkstreet2 { get; set; }
        
        [Description("Ville")]
        [Column("L",Order=11)]
        [MaxLength(60)] 
        public String L { get; set; }
        
        [Description("Code Postal")]
        [Column("POSTALCODE",Order=12)]
        [MaxLength(12)] 
        public String Postalcode { get; set; }
        
        [Description("Date MAJ")]
        [Column("MODIFYTIMESTAMP",Order=13)]
        public Nullable<DateTime> Modifytimestamp { get; set; }
        
    }
}
