using Emash.GeoPat.Generator.IO;
using Emash.GeoPat.Generator.Models;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public DelegateCommand ProjectCreateCommand { get; private set; }
        public DelegateCommand ProjectOpenCommand { get; private set; }      
        public DelegateCommand ProjectSaveCommand { get; private set; }
        public DelegateCommand ProjectSaveAsCommand { get; private set; }
        public DelegateCommand ProjectCloseCommand { get; private set; }

        public ProjectViewModel CurrentProject { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.ProjectCreateCommand = new DelegateCommand(ProjectCreateCommandExecute, CanProjectCreateCommandExecute);
            this.ProjectOpenCommand = new DelegateCommand(ProjectOpenCommandExecute, CanProjectOpenCommandExecute);
            this.ProjectSaveCommand = new DelegateCommand(ProjectSaveCommandExecute, CanProjectSaveCommandExecute);
            this.ProjectSaveAsCommand = new DelegateCommand(ProjectSaveAsCommandExecute, CanProjectSaveAsCommandExecute);
            this.ProjectCloseCommand = new DelegateCommand(ProjectCloseCommandExecute, CanProjectCloseCommandExecute);
        }

        protected void RaisePropertyChange(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void RaiseChanges()
        {
            this.RaisePropertyChange("CurrentProject");
            this.ProjectCreateCommand.RaiseCanExecuteChanged();
            this.ProjectOpenCommand.RaiseCanExecuteChanged();
            this.ProjectSaveCommand.RaiseCanExecuteChanged();
            this.ProjectSaveAsCommand.RaiseCanExecuteChanged();
            this.ProjectCloseCommand.RaiseCanExecuteChanged();

        }

        private bool CanProjectCreateCommandExecute()
        {
            return this.CurrentProject == null;
        }

        private void ProjectCreateCommandExecute()
        {
            this.CurrentProject = new ProjectViewModel(new Project()); 
            this.RaiseChanges();
        }

       

        private bool CanProjectOpenCommandExecute()
        {
            return this.CurrentProject == null;
        }

        private void ProjectOpenCommandExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".pgp";
            dlg.Filter = "Fichier Projet GeoPat(.pgp)|*.pgp";
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ProjectReader reader = new ProjectReader(dlg.FileName);
                Project project = reader.Read();
                if (project != null)
                {
                    this.CurrentProject = new ProjectViewModel(project);
                    this.CurrentProject.LastFileName = dlg.FileName;
                    this.RaiseChanges();
                }
                
              
            }
        }

        private bool CanProjectSaveCommandExecute()
        {
            return this.CurrentProject != null && this.CurrentProject.LastFileName != null;
        }

        private void ProjectSaveCommandExecute()
        {
            ProjectWriter writer = new ProjectWriter(this.CurrentProject.LastFileName, this.CurrentProject.Model);
            writer.Write();
        }


        private bool CanProjectSaveAsCommandExecute()
        {
            return this.CurrentProject != null;
        }

        private void ProjectSaveAsCommandExecute()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".pgp";
            dlg.Filter = "Fichier Projet GeoPat(.pgp)|*.pgp";
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                ProjectWriter writer = new ProjectWriter(dlg.FileName, this.CurrentProject.Model);
                writer.Write();
                this.CurrentProject.LastFileName = dlg.FileName;
                this.RaiseChanges();
            }
        }


        private bool CanProjectCloseCommandExecute()
        {
            return this.CurrentProject != null;
        }

        private void ProjectCloseCommandExecute()
        {
            this.CurrentProject = null;
            this.RaiseChanges();

        }
    }
}
