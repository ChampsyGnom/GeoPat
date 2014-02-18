using Emash.GeoPatNet.Generator.Models;
using Emash.GeoPatNet.Generator.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Boolean HasCurrentProject
        {
            get
            { return this.CurrentProject != null; }
        }
        public ProjectViewModel CurrentProject { get; set; }
        public DelegateCommand CreateProjectCommand { get; set; }
        public DelegateCommand OpenProjectCommand { get; set; }
        public DelegateCommand SaveProjectCommand { get; set; }
        public DelegateCommand SaveAsProjectCommand { get; set; }
        public DelegateCommand CloseProjectCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public MainViewModel()
        {
            this.CreateProjectCommand = new DelegateCommand(CreateProjectExecute, CanCreateProjectExecute);
            this.OpenProjectCommand = new DelegateCommand(OpenProjectExecute, CanOpenProjectExecute);
            this.SaveProjectCommand = new DelegateCommand(SaveProjectExecute, CanSaveProjectExecute);
            this.SaveAsProjectCommand = new DelegateCommand(SaveAsProjectExecute, CanSaveAsProjectExecute);
            this.CloseProjectCommand = new DelegateCommand(CloseProjectExecute, CanCloseProjectExecute);
            this.ExitCommand = new DelegateCommand(ExitExecute, CanExitExecute);
            
        }

        private void RaiseCommandChange()
        {
            this.OpenProjectCommand.RaiseCanExecuteChanged();
            this.CloseProjectCommand.RaiseCanExecuteChanged();
            this.CreateProjectCommand.RaiseCanExecuteChanged();
            this.SaveAsProjectCommand.RaiseCanExecuteChanged();
            this.SaveProjectCommand.RaiseCanExecuteChanged();
            this.ExitCommand.RaiseCanExecuteChanged();
        }

        public void CreateProjectExecute()
        {
            this.CurrentProject = new ProjectViewModel(new Project ());
            this.RaisePropertyChanged("CurrentProject");
            this.RaisePropertyChanged("HasCurrentProject");
            
        }

     
        public Boolean CanCreateProjectExecute()
        {
            return this.CurrentProject == null;
        }

        public void OpenProjectExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mpd";
            dlg.Filter = "Fichier Projet GeoPatNet (.gpn)|*.gpn";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                String fileName = dlg.FileName;
                Project model =  ServiceLocator.Current.GetInstance<SerializationService>().UnzipAndDeserialize<Project>(fileName);
                this.CurrentProject = new ProjectViewModel (model);
                this.CurrentProject.LastFileName = fileName;
                this.RaiseCommandChange();
                this.RaisePropertyChanged("CurrentProject");
                this.RaisePropertyChanged("HasCurrentProject");
            }
        }

        public Boolean CanOpenProjectExecute()
        {
            return this.CurrentProject == null;
        }

        public void SaveProjectExecute()
        {
            ServiceLocator.Current.GetInstance<SerializationService>().SerializeAndZip<Project>(this.CurrentProject.LastFileName, this.CurrentProject.Model);
            this.RaiseCommandChange();
            this.RaisePropertyChanged("CurrentProject");
            this.RaisePropertyChanged("HasCurrentProject");
        }

        public Boolean CanSaveProjectExecute()
        {
            return this.CurrentProject != null && this.CurrentProject.LastFileName != null;
        }

        public void SaveAsProjectExecute()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".mpd";
            dlg.Filter = "Fichier Projet GeoPatNet (.gpn)|*.gpn";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                String fileName = dlg.FileName;
                ServiceLocator.Current.GetInstance<SerializationService>().SerializeAndZip<Project>(fileName, this.CurrentProject.Model);
                this.CurrentProject.LastFileName = fileName;
                this.RaiseCommandChange();
                this.RaisePropertyChanged("CurrentProject");
                this.RaisePropertyChanged("HasCurrentProject");
            }
        }

        public Boolean CanSaveAsProjectExecute()
        {
            return this.CurrentProject != null;
        }

        public void CloseProjectExecute()
        {
            this.CurrentProject = null;
            this.RaisePropertyChanged("CurrentProject");
            this.RaisePropertyChanged("HasCurrentProject");
        }

        public Boolean CanCloseProjectExecute()
        {
            return this.CurrentProject != null;
        }

        public void ExitExecute()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public Boolean CanExitExecute()
        {
            return true;
        }
    }
}
