using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Generator.Models;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class DbConstraintFkJoinViewModel : DbItemViewModel
    {
        private DbForeignKeyJoin _model;

        [Category("Colonne parente")]
        [DisplayName("Identifiant")]
        [ReadOnly(true)]
        public String ParentColumnId { get; set; }
        [Category("Colonne parente")]
        [DisplayName("Nom")]
        [ReadOnly(true)]
        public String ParentColumnName { get; set; }

        [Category("Colonne parente")]
        [DisplayName("Libellé")]
        [ReadOnly(true)]
        public String ParentColumnDisplayName { get; set; }


        [Category("Colonne fille")]
        [DisplayName("Identifiant")]
        [ReadOnly(true)]
        public String ChildColumnId { get; set; }

        [Category("Colonne fille")]
        [DisplayName("Nom")]
        [ReadOnly(true)]
        public String ChildColumnName { get; set; }

        [Category("Colonne fille")]
        [DisplayName("Libellé")]
        [ReadOnly(true)]
        public String ChildColumnDisplayName { get; set; }


      
       

        public DbConstraintFkJoinViewModel( DbForeignKeyJoin model)
        {
            // TODO: Complete member initialization
            this._model = model;



        }
    }
}
