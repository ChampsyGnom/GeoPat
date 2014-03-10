using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Infrastructure.ComponentModel;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Attributes;



namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class GenericListItemViewModel<M> : INotifyPropertyChanged, IRowEditableItem, IDataErrorInfo
    {

        private Dictionary<String, String> _values;
        /// <summary>
        /// Liste des valeurs des champs
        /// </summary>
        public Dictionary<String, String> Values
        {
            get { return _values; }

        }

        private GenericItemsSource<M> _comboItemsSource;
        /// <summary>
        /// Liste des sources des combo
        /// </summary>
        public GenericItemsSource<M> ComboItemsSource
        {
            get { return _comboItemsSource; }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
            
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public EntityTableInfo TableInfo { get; private set; }
        public IDataService DataService { get; private set; }
        /// <summary>
        /// Modèle sous-jacent , entité
        /// </summary>
        public M Model { get; private set; }

        /// <summary>
        /// Manager de la liste ... (on pourais s'en passer ...)
        /// </summary>
        public IGenericListViewModel Manager { get; private set; }

        public String Name
        {
            get {
                return this.Manager.DataService.GetEntityTableInfo(typeof(M)).DisplayName;
            }
        }

        public GenericListItemViewModel(IGenericListViewModel manager, M model)
        {
            this.Model = model;
            this.Manager = manager;
            this._values = new Dictionary<string, String>();            
            this._comboItemsSource = new GenericItemsSource<M>();
            this.DataService = manager.DataService;
            this.TableInfo = this.DataService.GetEntityTableInfo(typeof(M));
          
        }
     
        /// <summary>
        /// Accès aux valeurs des champs
        /// </summary>
        /// <param name="fieldPath">
        /// /// <summary>
        /// Path du champ
        /// Si il s'agit d'une propriété de l'entité M c'est le nom de la propriété
        /// Si il s'agit d'une propriété d'une table parente c'est NomTableParent.NomPropriete 
        /// Il peut y avoir plusieurs niveaux par example le code laision de la table des aires auras comme fieldPath InfChaussee.InfLiaison.InfCodeLiaison.Code
        /// </summary>
        /// </param>
        /// <returns></returns>
        public String this[String fieldPath]
        {
            get 
            {
                
                if (!this._values.ContainsKey(fieldPath))
                { this._values.Add(fieldPath, null); }
                return this._values[fieldPath];
            }
            set
            {
                if (!this._values.ContainsKey(fieldPath))
                { this._values.Add(fieldPath, null); }
                this._values[fieldPath] = value;

                if (this.Manager.State == Infrastructure.Enums.GenericDataListState.Display && !this.Manager.IsLocked)
                { this.Manager.BeginEdit(this); }

                EntityFieldInfo fieldInfo = (from f in this.TableInfo.FieldInfos where f.Path.Equals(fieldPath) select f).FirstOrDefault();
                // Dans le cas des combo lié il faut remettre à null les combo qui sont après dans la hiérarchie et recharge leur liste
                if (fieldInfo.ParentColumnInfo != null && fieldInfo.ColumnInfo != null && fieldInfo.ColumnInfo.ControlType == ControlType.Combo)
                {
                     List<EntityFieldInfo> fieldInfoUks = new List<EntityFieldInfo>();
                     List<EntityColumnInfo> columnInfoUks = DataService.GetAllParentUniqueKeyColumnInfos(fieldInfo.ColumnInfo);
                     foreach (EntityColumnInfo columnInfoUk in columnInfoUks)
                     {
                         EntityFieldInfo fieldInfoUk = (from f in TableInfo.FieldInfos where f.ParentColumnInfo .Equals (columnInfoUk) select f).FirstOrDefault();
                         fieldInfoUks.Add(fieldInfoUk);
                     }
                     fieldInfoUks = (from f in fieldInfoUks orderby f.ParentColumnInfo.TableInfo.Level  select f).ToList();
                     foreach (EntityFieldInfo fieldInfoUk in fieldInfoUks)
                     {
                         if (fieldInfoUks.IndexOf(fieldInfo) < fieldInfoUks.IndexOf(fieldInfoUk))
                         {                           
                             this._comboItemsSource.Values = this._values;                         
                             String[] ukPathItems = fieldInfoUk.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                             String itemSourceName = ukPathItems[ukPathItems.Length - 2] + "." + ukPathItems[ukPathItems.Length - 1];
                             this._comboItemsSource.LoadList(itemSourceName);
                             this._values[fieldInfoUk.Path] = CultureConfiguration.ListNullString;
                         }
                     }                    
                     this.RaisePropertyChanged("ComboItemsSource");
                }
                this.RaisePropertyChanged("[" + fieldPath + "]");
                this.RaisePropertyChanged( fieldPath);
                this.RaisePropertyChanged("Item[]");
                this.RaisePropertyChanged("Error");
                

            }
        }

        private Object GetComboItemsSource(string fieldPath)
        {
            // Si la clé n'est pas encore dans le dico des source de combo on l'y ajoute
            if (!this._comboItemsSource.ContainsKey(fieldPath))
            {
                this._comboItemsSource.Add(fieldPath, new ObservableCollection<object>());
                // On lance le premier chargemement
                this._comboItemsSource.LoadList(fieldPath);
            }
            return this._comboItemsSource[fieldPath];
        }

       


      

        public void LoadFromModel(List<String> fieldPaths)
        {
            this._values = TableInfo.LoadFromModel(this.Model, fieldPaths);
           
            this._comboItemsSource.Values = this._values;
            
        }

        public void SetModel(M model)
        {
            
            this.Model = model;
            EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo (typeof(M));
            List<String> fieldPaths = (from f in tableInfo.FieldInfos select f.Path).ToList();     
            this.LoadFromModel(fieldPaths);
       
            
        }

        public void SaveToModel(List<String> fieldPaths)
        {
            TableInfo.SaveToModel(this.Model ,this.Values);            
        }

        internal void RaiseValuesChanges()
        {
            foreach (String key in this._values.Keys)
            {
                this.RaisePropertyChanged("Item["+key+"]");
                this.RaisePropertyChanged("[" + key + "]"); 
            }
            this.RaisePropertyChanged("Item[]");
           
        }

       
        string IDataErrorInfo.Error
        {
            get {
              
                List<String> errors = new List<string>();
                EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo(typeof(M));
                foreach (String key in this._values.Keys)
                { 
                    String error = ((IDataErrorInfo ) this)["["+key+"]"] ;
                    if (error != null)
                    {

                        EntityFieldInfo fieldInfo = (from f in this.TableInfo.FieldInfos where f.Path.Equals (key) select f).FirstOrDefault();                       
                        errors.Add(error);
                    }
                }
                if (errors.Count > 0)
                { return String.Join("\r\n", errors); }
                else
                { return null; }                
           
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get {
                // @TODO Erreur sur validation des critères
                if (this.Manager.State == Infrastructure.Enums.GenericDataListState.Search) return null;
                String message = null;
                Object result = null;

                if (columnName.StartsWith("[") && columnName.EndsWith("]"))
                {
                    String path = columnName.Substring(1);
                    path = path.Substring(0, path.Length - 1);
                    EntityFieldInfo fieldInfo = (from f in TableInfo.FieldInfos where f.Path.Equals (path) select f).FirstOrDefault();
                    if (fieldInfo != null  )
                    {
                        if (fieldInfo.IsMainTableField || fieldInfo.IsNeeded)
                        {
                            if (!fieldInfo.ValidateString(this._values[path], out message, out result))
                            {  return message;  }                           
                        }                       
                    }
                }
               
                return null;
            }
        }

        internal void Reset()
        {
            List<String> keys = (from k in this._values.Keys select k).ToList ();
            this._values = new Dictionary<string, string>();
            foreach (String key in keys)
            {this._values.Add (key,"");}
           
        }

       
    }
}
