using Emash.GeoPat.Generator.IO;
using Emash.GeoPat.Generator.Models;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPat.Generator.ViewModel
{
    public class ProjectViewModel
    {
        public String LastFileName { get;  set; }
        public DelegateCommand AddDbSchemaCommand { get; private set; }
        public DelegateCommand GenerateCodeDataCommand { get; private set; }
        public DelegateCommand GenerateSqlPostgreCommand { get; private set; }
        public Project Model { get; private set; }
        public ObservableCollection<DbSchemaViewModel> Schemas { get; private set; }
        public ProjectViewModel(Project model)
        {
            this.Model = model;
            this.AddDbSchemaCommand = new DelegateCommand(AddDbSchemaCommandExecute);
            this.GenerateCodeDataCommand = new DelegateCommand(GenerateCodeDataCommandExecute);
            this.GenerateSqlPostgreCommand = new DelegateCommand(GenerateSqlPostgreCommandExecute);
            this.Schemas = new ObservableCollection<DbSchemaViewModel>();
            foreach (DbSchema schema in model.Schemas)
            {this.Schemas.Add(new DbSchemaViewModel(schema));}
        }
        private void GenerateSqlPostgreCommandExecute()
        {
            SqlPostgreWriter writer = new SqlPostgreWriter(this.Model);
            writer.Write();
        }
        private void GenerateCodeDataCommandExecute()
        {
            foreach (DbSchema schema in this.Model.Schemas)
            {
                foreach (DbTable table in schema.Tables)
                {
                    CodeDataEntityWriter writerEntities = new CodeDataEntityWriter(this.Model, schema,table);
                    writerEntities.Write();

                    CodeDataContextWriter writerContext = new CodeDataContextWriter(this.Model);
                    writerContext.Write();
                }
            }
        }

        private void AddDbSchemaCommandExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mpd";
            dlg.Filter = "Fichier MPD PowerAMC (.mpd)|*.mpd";
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                PowerAmcMpdReader reader = new PowerAmcMpdReader(dlg.FileName);
                DbSchema schema = reader.Read();
                if (schema != null)
                {
                    this.Model.Schemas.Add(schema);
                    DbSchemaViewModel vm = new DbSchemaViewModel(schema);
                    this.Schemas.Add(vm);
                    vm.IsSelected = true;
                }
            }
        }
    }
}
