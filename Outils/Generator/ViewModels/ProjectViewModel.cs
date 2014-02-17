using Emash.GeoPatNet.Generator.Models;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Generator.IO;
using Emash.GeoPatNet.Generator.Views;
namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {

        public String LastFileName { get; set; }
        private Project _model;

        public Project Model
        {
            get { return _model; }
           
        }
        public DelegateCommand AddMpdCommand { get; set; }
        public DelegateCommand ShowGenerateCSharpCommand { get; set; }

       
        public ObservableCollection<DbSchemaViewModel> Schemas { get; set; }
        public ProjectViewModel(Project model)
        {
            // TODO: Complete member initialization
            this._model = model;
            this.Schemas = new ObservableCollection<DbSchemaViewModel>();
           

            model.Schemas = (from s in model.Schemas orderby s.DisplayName select s).ToList();
            foreach (DbSchema schema in model.Schemas)
            {
                DbSchemaViewModel vm = new DbSchemaViewModel(schema);
                this.Schemas.Add(vm);
            }
            this.AddMpdCommand = new DelegateCommand(AddMpdExecute, CanAddMpdExecute);
            this.ShowGenerateCSharpCommand = new DelegateCommand(ShowGenerateCSharpExecute, CanShowGenerateCSharpExecute);
        }

        private void ShowGenerateCSharpExecute()
        { 
            GeneratorCSharpViewModel vm = new GeneratorCSharpViewModel (this.Model);
            GeneratorCSharpView view = new GeneratorCSharpView(vm);
            view.Owner = System.Windows.Application.Current.MainWindow;
            view.ShowDialog();
        }

        private Boolean CanShowGenerateCSharpExecute()
        { return true; }

        private void AddMpdExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mpd";
            dlg.Filter = "Fichier MPD Power AMC (.mpd)|*.mpd";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {

                string filename = dlg.FileName;
                MpdReader reader = new MpdReader(filename);
                DbSchemaViewModel vm = new DbSchemaViewModel(reader.DbSchema);
                this.Model.Schemas.Add(reader.DbSchema);
                this.Schemas.Add(vm);

            }

        }

        private Boolean CanAddMpdExecute()
        { return true; }
    }
}
