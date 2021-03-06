using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CONTACT_INF",Schema="INF")]
    public partial class InfContact
    {
        [Key]
        [Description("Identificant(cpt)")]
        [Column("DOC_INF__ID",Order=0)]
        [Required()]
        public Int64 DocInfId { get; set; }
        
        [Description("Prénom")]
        [Column("givenName",Order=1)]
        [MaxLength(60)] 
        public String Givenname { get; set; }
        
        [Description("Nom")]
        [Column("sn",Order=2)]
        [MaxLength(60)] 
        public String Sn { get; set; }
        
        [Description("Nom complet")]
        [Column("cn",Order=3)]
        [MaxLength(125)] 
        public String Cn { get; set; }
        
        [Description("Organisation")]
        [Column("o",Order=4)]
        [MaxLength(60)] 
        public String O { get; set; }
        
        [Description("Email")]
        [Column("mail",Order=5)]
        [MaxLength(60)] 
        public String Mail { get; set; }
        
        [Description("Téléphone fixe")]
        [Column("telephoneNumber",Order=6)]
        [MaxLength(20)] 
        public String Telephonenumber { get; set; }
        
        [Description("Téléphone mobile")]
        [Column("mobile",Order=7)]
        [MaxLength(20)] 
        public String Mobile { get; set; }
        
        [Description("Fax")]
        [Column("facsimiletelephonenumber",Order=8)]
        [MaxLength(20)] 
        public String Facsimiletelephonenumber { get; set; }
        
        [Description("Adresse")]
        [Column("street",Order=9)]
        [MaxLength(60)] 
        public String Street { get; set; }
        
        [Description("Adresse complémentaire")]
        [Column("mozillaWorkStreet2",Order=10)]
        [MaxLength(60)] 
        public String Mozillaworkstreet2 { get; set; }
        
        [Description("Ville")]
        [Column("l",Order=11)]
        [MaxLength(60)] 
        public String L { get; set; }
        
        [Description("Code Postal")]
        [Column("postalCode",Order=12)]
        [MaxLength(12)] 
        public String Postalcode { get; set; }
        
        [Description("Date MAJ")]
        [Column("modifytimestamp",Order=13)]
        public Nullable<DateTime> Modifytimestamp { get; set; }
        
    }
}
