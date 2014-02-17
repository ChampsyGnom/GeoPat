using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Emash.GeoPatNet.Generator.Models;
using Emash.GeoPatNet.Generator.Views;
using Microsoft.Practices.Prism.Commands;

namespace Emash.GeoPatNet.Generator.ViewModels
{
    public class GeneratorCSharpViewModel : ViewModelBase
    {
        private Project _model;
        public String DataNamespace { get; set; }
        public String DataPath { get; set; }
        public String BuisnessNamespace { get; set; }
        public String BuisnessPath { get; set; }


        public String DataInfraNamespace { get; set; }
        public String DataInfraPath { get; set; }
        public String BuisnessInfraNamespace { get; set; }
        public String BuisnessInfraPath { get; set; }
        public DelegateCommand ChangeDataInfraPathCommand { get; set; }
        public DelegateCommand ChangeBuisnessInfraPathCommand { get; set; }
        public DelegateCommand ChangeDataPathCommand { get; set; }
        public DelegateCommand ChangeBuisnessPathCommand { get; set; }
        public DelegateCommand GenerateCommand { get; set; }

        

        public GeneratorCSharpViewModel(Project model)
        {
            this._model = model;
            this.DataNamespace = model.GeneratorCSharpDataNamespace;
            this.DataPath = model.GeneratorCSharpDataPath;
            this.BuisnessNamespace = model.GeneratorCSharpBuisnessNamespace;
            this.BuisnessPath = model.GeneratorCSharpBuisnessPath;
            this.ChangeBuisnessPathCommand = new DelegateCommand(ChangeBuisnessPathExecute);
            this.ChangeDataPathCommand = new DelegateCommand(ChangeDataPathExecute);
            this.ChangeBuisnessInfraPathCommand = new DelegateCommand(ChangeBuisnessInfraPathExecute);
            this.ChangeDataInfraPathCommand = new DelegateCommand(ChangeDataInfraPathExecute);

            this.GenerateCommand = new DelegateCommand(GenerateExecute);
        }

        private void GenerateExecute()
        { 
        

        }

        private void ChangeDataPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; 
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.DataPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.DataPath = dialog.SelectedPath;
                this.RaisePropertyChanged("DataPath");
            }

        }
       

        private void ChangeBuisnessPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; // 'this' means WPF Window
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.BuisnessPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.BuisnessPath = dialog.SelectedPath;
                this.RaisePropertyChanged("BuisnessPath");
            }
        }


        private void ChangeDataInfraPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.DataPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.DataInfraPath = dialog.SelectedPath;
                this.RaisePropertyChanged("DataInfraPath");
            }

        }


        private void ChangeBuisnessInfraPathExecute()
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(System.Windows.Application.Current.MainWindow).Handle; // 'this' means WPF Window
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.BuisnessPath;
            if (dialog.ShowDialog(new Win32Window(mainWindowPtr)) == DialogResult.OK)
            {
                this.BuisnessInfraPath = dialog.SelectedPath;
                this.RaisePropertyChanged("BuisnessInfraPath");
            }
        }

    }
}
