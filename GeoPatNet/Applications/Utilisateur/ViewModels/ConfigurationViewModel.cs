using Emash.GeoPatNet.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Models;
using System.Data.Entity;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private LangViewModel _selectedLang;


        public LangViewModel SelectedLang
        {
            get { return _selectedLang; }
            set { _selectedLang = value; this.ChangeCurrentLang(); }
        }

        private void ChangeCurrentLang()
        {
            DbSet<PrfParam> parameters = this.DataService.GetDbSet<PrfParam>();

            List<PrfParam> itemToRemoves = (from p in parameters where p.Code.Equals("LANG") select p).ToList ();
            foreach (PrfParam itemToRemove in itemToRemoves)
            {parameters.Remove(itemToRemove);}
            this.DataService.DataContext.SaveChanges();           
            PrfParam param = new PrfParam();
            param.Code = "LANG";
            param.Valeur = this._selectedLang.CodeIso;
            parameters.Add(param);
            this.DataService.DataContext.SaveChanges();
            ServiceLocator.Current.GetInstance<ITranslateService>().LoadCurrentLang();
        }
        public ObservableCollection<LangViewModel> Langs  { get; private set; }
        public DelegateCommand AddLangCommand { get; private set; }
        public IDataService  DataService {get;private set;}
        public ObservableCollection<ConfigurationSchemaViewModel> Schemas { get; private set; }
        public ConfigurationViewModel(IDataService dataService)
        {
            this.DataService = dataService;
            this.Schemas = new ObservableCollection<ConfigurationSchemaViewModel>();
            this.Langs = new ObservableCollection<LangViewModel>();
            DbSet<PrfSchema> schemas = dataService.GetDbSet<PrfSchema>();
            foreach (PrfSchema schema in schemas)
            { this.Schemas.Add(new ConfigurationSchemaViewModel(schema )); }

            this.AddLangCommand = new DelegateCommand(AddLangExecute);


            this.LoadLangs();
           
           

        }

        private void LoadLangs()
        {
            this.Langs.Clear();
            DbSet<PrfLang> langs = this.DataService.GetDbSet<PrfLang>();
       
        
            List<String> codeIsos = (from l in langs select l.CodeIso).Distinct().ToList();


            String defaultCodeIso = "fra";
            DbSet<PrfParam> parameters = this.DataService.GetDbSet<PrfParam>();
            PrfParam paramDefaultLang = (from p in parameters where p.Code.Equals("LANG") select p).FirstOrDefault();
            if (paramDefaultLang == null)
            {
                PrfParam param = new PrfParam();
                param.Code = "LANG";
                param.Valeur = "fra";
                parameters.Add(param);
                this.DataService.DataContext.SaveChanges();
            }
            else
            { defaultCodeIso = paramDefaultLang.Valeur; }

            foreach (String codeIso in codeIsos)
            {
                LangViewModel vm = new LangViewModel();
                vm.CodeIso = codeIso;
                vm.DisplayName = codeIso;
                this.Langs.Add(vm);
                if (codeIso.Equals(defaultCodeIso))
                { 
                    this._selectedLang = vm;
                    this.RaisePropertyChanged("SelectedLang");
                }
            }
        }

        private void AddLangExecute()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choix du fichier de langue";
            dialog.Filter = "Fichier langue (*.lang)|*.lang";
            Nullable<Boolean> result = dialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                Dictionary<String, String> values = new Dictionary<string, string>();
                FileStream stream = new FileStream(dialog.FileName, FileMode.Open);
                StreamReader reader = new StreamReader(stream,System.Text.Encoding.Unicode );
                String header = reader.ReadLine();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] lineItems = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    values.Add (lineItems[0],lineItems[1]);
                }
                reader.Close();
                reader.Dispose();
                stream.Close();
                stream.Dispose();
                FileInfo fileInfo = new FileInfo(dialog.FileName);
                String[] items = fileInfo.Name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string codeIso = items[0].ToLower ();
                DbSet<PrfLang> langs = this.DataService.GetDbSet<PrfLang>();
                List<PrfLang> itemToRemoves = (from l in langs where l.CodeIso.Equals (codeIso ) select l).ToList();
                foreach (PrfLang lang in itemToRemoves)
                {langs.Remove(lang);}
                this.DataService.DataContext.SaveChanges();

                foreach (String key in values.Keys)
                {
                    PrfLang lang = new PrfLang();
                    lang.CodeIso = codeIso;
                    lang.Key = key;
                    lang.Valeur = values[key];
                    langs.Add(lang);
                }
                this.DataService.DataContext.SaveChanges();
                this.LoadLangs();
            }

        }
    }
}
