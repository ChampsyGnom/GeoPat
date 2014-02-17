using Emash.GeoPatNet.Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Emash.GeoPatNet.Generator.Utils;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    [DisplayName("Table")]
    public class DbTableViewModel
    {
        [Browsable(false)]
        public DbTable Model { get; set; }

        [Browsable(false)]
        public ObservableCollection<ViewModelBase> Items { get; set; }

        [Category("Identification")]
        [ReadOnly(true)]
        [DisplayName("Identifiant")]
        public String Id { get; set; }

        [Category("Identification")]
        [ReadOnly(true)]   
        [DisplayName("Libellé")]
        public String DisplayName { get; set; }

        [Category("Identification")]
        [ReadOnly(true)]      
        [DisplayName("Nom")]
        public String Name { get; set; }

        [Category("Code source")]
        [ReadOnly(true)]
        [DisplayName("Nom de l'entitée")]
        public String EntityName { get; set; }



        public DbTableViewModel(DbSchema schema,DbTable model)
        {
            this.Id = model.Id;
            this.DisplayName = model.DisplayName;
            this.Name = model.Name;
            this.Items = new ObservableCollection<ViewModelBase>();
            this.EntityName = NameConverter.TableNameToEntityName(model.Name);
            DbColumnsViewModel vms = new DbColumnsViewModel();
            model.Columns = (from c in model.Columns orderby c.DisplayName select c).ToList();
            foreach (DbColumn column in model.Columns)
            {
                DbColumnViewModel vm = new DbColumnViewModel(column);
                vms.Items.Add(vm);
            }
            this.Items.Add(vms);
           
            DbConstraintsViewModel vmsC = new DbConstraintsViewModel();          
            if (model.PrimaryKey != null)
            {
                DbConstraintViewModel pkVm = new DbConstraintPkViewModel(model,model.PrimaryKey);
                vmsC.Items.Add(pkVm);

            }

            foreach (DbUniqueKey uk in model.UniqueKeys)
            {
                DbConstraintUkViewModel ukVm = new DbConstraintUkViewModel(model,uk);
                vmsC.Items.Add(ukVm);
            }
            foreach (DbForeignKey fk in model.ForeignKeys)
            {
                DbConstraintFkViewModel fkVm = new DbConstraintFkViewModel(schema,fk);
                vmsC.Items.Add(fkVm);
            }
            this.Items.Add(vmsC);
            
      
            this.Model = model;
        }
    }
}
