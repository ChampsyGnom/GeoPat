using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Clé étrangères")]    
    public class DbConstraintFkViewModel : DbConstraintViewModel
    {
        private DbForeignKey _fk;

        [Browsable(false)]
        public ObservableCollection<DbConstraintFkJoinViewModel> Joins { get; set; }


        [Category("Table parente")]
        [DisplayName("Identifiant")]
        [ReadOnly(true)]
        public String ParentTableId { get; set; }


        [Category ("Table parente")]
        [DisplayName("Nom")]    
        [ReadOnly(true)]
        public String ParentTableName { get; set; }

        [Category("Table parente")]
        [DisplayName("Libellé")]
        [ReadOnly(true)]
        public String ParentTableDisplayName { get; set; }


        [Category("Table fille")]
        [DisplayName("Identifiant")]
        [ReadOnly(true)]
        public String ChildTableId { get; set; }

        [Category ("Table fille")]
        [DisplayName("Nom")]
        [ReadOnly(true)]
        public String ChildTableName { get; set; }

        [Category("Table fille")]
        [DisplayName("Libellé")]
        [ReadOnly(true)]
        public String ChildTableDisplayName { get; set; }

        public DbConstraintFkViewModel(DbSchema schema, DbForeignKey fk)
        {
            // TODO: Complete member initialization
            this._fk = fk;
            this.Id = fk.Id;
            DbTable parentTable = (from t in schema.Tables where t.Id.Equals (fk.ParentTableId) select t).FirstOrDefault();
            DbTable childTable = (from t in schema.Tables where t.Id.Equals(fk.ChildTableId) select t).FirstOrDefault();
            this.ParentTableName = parentTable.Name;
            this.ParentTableDisplayName = parentTable.DisplayName;
            this.ChildTableName = childTable.Name;
            this.ChildTableDisplayName = childTable.DisplayName;
            this.ParentTableId = parentTable.Id;
            this.ChildTableId = childTable.Id;

            this.DisplayName = "Fk " + this.ParentTableDisplayName + " > " + this.ChildTableDisplayName;
            this.Name = fk.Name;
            this.Joins = new ObservableCollection<DbConstraintFkJoinViewModel>();
            foreach (DbForeignKeyJoin j in fk.Joins)
            {
                DbConstraintFkJoinViewModel vm = new DbConstraintFkJoinViewModel(j);
                DbColumn parentColumn = (from t in parentTable.Columns where t.Id.Equals(j.ParentColumnId) select t).FirstOrDefault();
                DbColumn childColumn = (from t in childTable.Columns where t.Id.Equals(j.ChildColumnId) select t).FirstOrDefault();
                vm.ParentColumnDisplayName = parentColumn.DisplayName;
                vm.ParentColumnName = parentColumn.Name;
                vm.ChildColumnDisplayName = childColumn.DisplayName;
                vm.ParentColumnId = parentColumn.Id;
                vm.ChildColumnId = childColumn.Id;
                vm.ChildColumnName = childColumn.Name;
                vm.DisplayName = parentTable.DisplayName+"."+ parentColumn.DisplayName + " -> " + childTable.DisplayName+"."+ childColumn.DisplayName;
                vm.Id = j.Id;
                this.Joins.Add(vm);
            }
        }
    }
}
