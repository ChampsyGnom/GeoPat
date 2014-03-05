using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using System.Windows.Data;
using Emash.GeoPatNet.Infrastructure.Enums;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.ComponentModel;
using System.Windows;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Infrastructure.Utils;
using Emash.GeoPatNet.Infrastructure.Behaviors;
using Emash.GeoPatNet.Infrastructure.Extensions;
using System.Windows.Input;
using System.Windows.Controls;
using Emash.GeoPatNet.Presentation.Views;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Capability;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class GenericListViewModel<M> : IGenericListViewModel, INotifyPropertyChanged, IRowEditableList, ICustomFilterable,ICustomSortable,ICustomDisplay
        where M : class, new()
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

        #region Propriétées

        private Dictionary<String, Nullable<ListSortDirection>> _sorters;



        public Nullable<ListSortDirection> GetSort(String filedPath)
        { 
            if (this._sorters == null)
            { this._sorters = new Dictionary<string, Nullable<ListSortDirection>>(); }
            if (this._sorters.ContainsKey(filedPath))
            {return this._sorters[filedPath];}
            else return null;
        }

        public void SetSort(String filedPath, Nullable<ListSortDirection> direction)
        {
            if (this._sorters == null)
            { this._sorters = new Dictionary<string, Nullable<ListSortDirection>>(); }
            if (!this._sorters.ContainsKey(filedPath))
            { this._sorters.Add(filedPath, direction); }
            else
            { this._sorters[filedPath] = direction; }
          
        }
        public Int32 SliderMinimum { get; set; }
        public Int32 SliderMaximum { get; set; }
        public Boolean CanSlide { get; set; }
        private Int32 _sliderValue;

        public Int32 SliderValue
        {
            get { return _sliderValue; }
            set { _sliderValue = value; this.RaisePropertyChanged("SliderValue"); this.ItemsView.MoveCurrentToPosition(_sliderValue); }
        }
        public DelegateCommand<DataGridContextMenuOpeningBehaviorEventArg> DataGridContextMenuOpeningCommand { get; private set; }
       
        
        /// <summary>
        /// Libellé de l'entité M
        /// </summary>
        public String DisplayName { get; private set; }
        /// <summary>
        /// Service de donnée
        /// </summary>
        public IDataService DataService { get; private set; }
        /// <summary>
        /// Information sur l'entité M
        /// </summary>
        public EntityTableInfo EntityTableInfo { get; private set; }
        /// <summary>
        /// Nombre d'enregistrement affiché
        /// </summary>
        public String DisplayRecordCount { get; private set; }
        /// <summary>
        /// N° de l'enregistrement courant ou * si on est en mode recherche
        /// </summary>
        public String DisplayRecordIndex { get; private set; }
        /// <summary>
        /// DsSet de l'entité M
        /// </summary>
        public DbSet<M> DbSet { get; private set; }
        /// <summary>
        /// Etat acutel du view Model
        /// </summary>
        public GenericDataListState   State { get; private set; }
        /// <summary>
        /// Command vérouiller/dévérouiller
        /// </summary>
        public DelegateCommand LockUnlockCommand { get; private set; }
        /// <summary>
        /// Command insérer
        /// </summary>
        public DelegateCommand InsertCommand { get; private set; }
        /// <summary>
        /// Command supprimer
        /// </summary>
        public DelegateCommand DeleteCommand { get; private set; }
        /// <summary>
        /// Command annuler
        /// </summary>
        public DelegateCommand CancelCommand { get; private set; }
        /// <summary>
        /// Command valider
        /// </summary>
        public DelegateCommand CommitCommand { get; private set; }
        /// <summary>
        /// Command vider
        /// </summary>
        public DelegateCommand ClearCommand { get; private set; }
        /// <summary>
        /// Commande chercher
        /// </summary>
        public DelegateCommand SearchCommand { get; private set; }
        /// <summary>
        /// Commande quitter
        /// </summary>
        public DelegateCommand QuitCommand { get; private set; }
        /// <summary>
        /// Liste des champs à afficher
        /// Si il s'agit d'une propriété de l'entité M c'est le nom de la propriété
        /// Si il s'agit d'une propriété d'une table parente c'est NomTableParent.NomPropriete 
        /// Il peut y avoir plusieurs niveaux par example le code laision de la table des aires auras comme fieldPath InfChaussee.InfLiaison.InfCodeLiaison.Code
        /// </summary>
        public ObservableCollection<String> FieldPaths { get; private set; }
        public ObservableCollection<String> BasicFieldPaths { get; private set; }
        public ObservableCollection<String> AvailableFieldPaths { get; private set; }
        /// <summary>
        /// Liste des éléments 
        /// </summary>
        public ObservableCollection<GenericListItemViewModel<M>> Items { get; private set; }
        /// <summary>
        /// Vue sur la liste des éléments
        /// </summary>
        public ListCollectionView ItemsView { get; private set; }
        /// <summary>
        /// Element de recherche
        /// </summary>
        public GenericListItemViewModel<M> SearchItem { get; private set; }
        /// <summary>
        /// Element en cours d'insertion
        /// </summary>
        public GenericListItemViewModel<M> InsertingItem { get; private set; }
        /// <summary>
        /// Element en cours de lise à jour
        /// </summary>
        public GenericListItemViewModel<M> UpdatingItem { get; private set; }
        /// <summary>
        /// Element en cours de supression
        /// </summary>
        public GenericListItemViewModel<M> DeletingItem { get; private set; }
        /// <summary>
        /// True si lecture seul
        /// </summary>
        public Boolean IsLocked { get; private set; }
        #endregion

        public GenericListViewModel()
        {
            // On récupères les informations de l'entité via le service de donnée
            DataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo = DataService.GetEntityTableInfo(typeof(M));
            DbSet = DataService.DataContext.Set<M>();

            // On initialise le nombre d'enregistrement et le libellé
            this.DisplayRecordCount = (from c in DbSet select c).Count().ToString();
            this.DisplayRecordIndex = "*";
            this.DisplayName = EntityTableInfo.DisplayName;

            // On instancie les commbndes
            this.LockUnlockCommand = new DelegateCommand(LockUnlockExecute, CanLockUnlockExecute);
            this.InsertCommand = new DelegateCommand(InsertExecute, CanInsertExecute);
            this.DeleteCommand = new DelegateCommand(DeleteExecute, CanDeleteExecute);
            this.CancelCommand = new DelegateCommand(CancelExecute, CanCancelExecute);
            this.CommitCommand = new DelegateCommand(CommitExecute, CanCommitExecute);
            this.ClearCommand = new DelegateCommand(ClearExecute, CanClearExecute);
            this.SearchCommand = new DelegateCommand(SearchExecute, CanSearchExecute);
            this.QuitCommand = new DelegateCommand(QuitExecute, CanQuitExecute);
            this.DataGridContextMenuOpeningCommand = new DelegateCommand<DataGridContextMenuOpeningBehaviorEventArg>(DataGridContextMenuOpeningExecute);
            
            // On instancie la liste d'élement et sa vue
            this.Items = new ObservableCollection<GenericListItemViewModel<M>>();
            this.ItemsView = new ListCollectionView(this.Items);

            // On instancie la lliste des champs à afficher
            this.FieldPaths = new ObservableCollection<string>();
            this.BasicFieldPaths = new ObservableCollection<string>();
            this.AvailableFieldPaths = new ObservableCollection<string>();

            List<String> fieldPaths = this.DataService.GetTableFieldPaths(EntityTableInfo);
            foreach (String fieldPath in fieldPaths)
            {
                this.FieldPaths.Add(fieldPath);
                this.BasicFieldPaths.Add(fieldPath);
            }

            // On cré l'élément de recherche et on initialise le mode de la table à recherche
            this.SearchItem = new GenericListItemViewModel<M>(this,null);
            this.Items.Add(this.SearchItem);
            this.State = GenericDataListState.Search;
            this.IsLocked = true;            

            // On ecoute le changement de l'élément courant pour mettre à jour l'enregistrement courant
            this.ItemsView.CurrentChanged += ItemsView_CurrentChanged;
            this._sorters = new Dictionary<string, ListSortDirection?>();
            this.CanSlide = false;
            this.SliderMinimum = 0;
            this.SliderMaximum = 0;
            this.SliderValue = 0;
        }

        //@TODO Finir les menus contextuel
        private void DataGridContextMenuOpeningExecute(DataGridContextMenuOpeningBehaviorEventArg arg)
        {
            if (this.State != GenericDataListState.Display)
            {
                arg.ContextMenuEventArgs.Handled = true;
                return;
            }
            Point pos = Mouse.GetPosition(arg.DataGrid);
            IInputElement hit = arg.DataGrid.InputHitTest(pos);
            DependencyObject hitDependencyObject = hit as DependencyObject;
            if (hitDependencyObject != null)
            {
                arg.ContextMenu.Items.Clear();
                MenuItem menuFilter = new MenuItem();
                menuFilter.Header = "Filtrer";

                MenuItem menuSorter = new MenuItem();
                menuSorter.Header = "Trier";

                MenuItem menuShow = new MenuItem();
                menuShow.Header = "Afficher";

                MenuItem menuShowMainTable = new MenuItem();
                menuShowMainTable.Header = this.EntityTableInfo.DisplayName;
                menuShow.Items.Add(menuShowMainTable);
                List<EntityTableInfo> parentTables = new List<EntityTableInfo>();
                List<String> fieldPaths = this.DataService.GetTableFieldPaths(EntityTableInfo);
                List<EntityColumnInfo> parentColumnInfos = new List<EntityColumnInfo>();
                foreach (String fieldPath in fieldPaths)
                {
                    if (fieldPath.IndexOf(".") == -1)
                    {
                        EntityColumnInfo columnInfo = (from c in this.EntityTableInfo.ColumnInfos where c.PropertyName.Equals (fieldPath ) select c).FirstOrDefault();
                        MenuItem menuShowColumn = new MenuItem();
                        menuShowColumn.Header = columnInfo.DisplayName;
                        menuShowColumn.IsEnabled = columnInfo.PrimaryKeyName == null && columnInfo.UniqueKeyNames.Count == 0;
                        menuShowColumn.IsCheckable = true;
                        menuShowColumn.IsChecked = this.FieldPaths.Contains(columnInfo.PropertyName);
                        menuShowMainTable.Items.Add(menuShowColumn);
                        menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                        {
                            if (menuShowColumn.IsChecked)
                            {
                                if (!this.FieldPaths.Contains(columnInfo.PropertyName))
                                {
                                    this.FieldPaths.Insert (0,columnInfo.PropertyName);
                                    foreach (GenericListItemViewModel<M> item in this.Items)
                                    { item.LoadFromModel(this.FieldPaths.ToArray().ToList()); }
                                }
                            }
                            else
                            { this.FieldPaths.Remove(columnInfo.PropertyName); }
                        }));
                    }
                    else
                    {
                        EntityColumnInfo columnInfoBottom = this.DataService.GetBottomColumnInfo(typeof(M), fieldPath);
                        EntityColumnInfo columnInfo = this.DataService.GetTopColumnInfo(typeof(M), fieldPath);
                        parentColumnInfos.Add(columnInfo);
                        parentTables.Add(columnInfo.TableInfo);
                        MenuItem menuShowColumn = new MenuItem();
                        menuShowColumn.Header = columnInfo.TableInfo.DisplayName;
                        menuShowColumn.IsEnabled = columnInfoBottom.PrimaryKeyName == null && columnInfoBottom.UniqueKeyNames.Count == 0;
                        menuShowColumn.IsCheckable = true;
                        menuShowColumn.IsChecked = this.FieldPaths.Contains(columnInfo.PropertyName);
                        menuShowMainTable.Items.Add(menuShowColumn);
                        menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                        {
                            if (menuShowColumn.IsChecked)
                            {
                                if (!this.FieldPaths.Contains(columnInfo.PropertyName))
                                { 
                                    this.FieldPaths.Insert(0,columnInfo.PropertyName);
                                    foreach (GenericListItemViewModel<M> item in this.Items)
                                    { item.LoadFromModel(this.FieldPaths.ToArray().ToList()); }
                                }
                            }
                            else
                            { this.FieldPaths.Remove(columnInfo.PropertyName); }
                        }));
                    }
                }
                parentTables = (from t in parentTables orderby t.DisplayName select t).ToList();

                foreach (EntityTableInfo parentTableInfo in parentTables)
                {
                    MenuItem menuShowParentTable = new MenuItem();
                    menuShowParentTable.Header = parentTableInfo.DisplayName;
                    menuShow.Items.Add(menuShowParentTable);
                    foreach (EntityColumnInfo columnInfo in parentTableInfo.ColumnInfos)
                    {
                        if (!parentColumnInfos.Contains(columnInfo) && columnInfo.PrimaryKeyName == null && columnInfo.ControlType != ControlType.None  )
                        {
                            String path = this.DataService.GetPath(parentTableInfo, this.EntityTableInfo) + "." + columnInfo.PropertyName;
                            MenuItem menuShowColumn = new MenuItem();
                            menuShowColumn.Header = columnInfo.DisplayName;
                            menuShowColumn.IsEnabled = true;
                            menuShowColumn.IsCheckable = true;
                            menuShowColumn.IsChecked = this.FieldPaths.Contains(path);

                            menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                            {
                                if (menuShowColumn.IsChecked)
                                {
                                    if (!this.FieldPaths.Contains(path))
                                    {
                                        this.FieldPaths.Insert(0,path);
                                        foreach (GenericListItemViewModel<M> item in this.Items)
                                        {item.LoadFromModel(this.FieldPaths.ToArray ().ToList ());}
                                    }
                                }
                                else
                                { this.FieldPaths.Remove(path); }
                            }));
                            menuShowParentTable.Items.Add(menuShowColumn);
                        }
                    }
                }

                arg.ContextMenu.Items.Add(menuFilter);
                arg.ContextMenu.Items.Add(menuSorter);
                arg.ContextMenu.Items.Add(menuShow);

                DataGridCell cell = hitDependencyObject.FindParentControl<DataGridCell>();
               
                if (cell != null)
                {
                    Console.WriteLine(cell);
                    if (cell.Column is GenericDataGridTemplateColumn)
                    {
                        GenericDataGridTemplateColumn column = (cell.Column as GenericDataGridTemplateColumn);
                        EntityColumnInfo columnInfo = this.DataService.GetTopColumnInfo(typeof(M),column.FieldPath);
                        String fieldDisplayName = columnInfo.DisplayName;
                        if (column.FieldPath.IndexOf(".") != -1)
                        { fieldDisplayName = columnInfo.TableInfo.DisplayName; }
                        MenuItem menuSorterAscending = new MenuItem();
                        menuSorterAscending.Header = "Trie croissant sur " + fieldDisplayName;
                        menuSorterAscending.Command = new DelegateCommand(new Action(delegate() {
                            this.SetSort(column.FieldPath, ListSortDirection.Ascending);
                            this.SearchExecute();
                        }));

                        
                        MenuItem menuSorterDescending= new MenuItem();
                        menuSorterDescending.Header = "Trie décroissant sur " + fieldDisplayName;
                        menuSorterDescending.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.SetSort(column.FieldPath, ListSortDirection.Descending);
                            this.SearchExecute();
                        }));

                        MenuItem menuSorterNone = new MenuItem();
                        menuSorterNone.Header = "Aucun trie";
                        menuSorterNone.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.SetSort(column.FieldPath, null);
                            this.SearchExecute();
                        }));

                        menuSorter.Items.Add(menuSorterAscending);
                        menuSorter.Items.Add(menuSorterDescending);
                        menuSorter.Items.Add(menuSorterNone);

                        if (cell.DataContext is GenericListItemViewModel<M>)
                        {
                            GenericListItemViewModel<M> vm = (cell.DataContext as GenericListItemViewModel<M>);
                            String valueString =  vm.Values[column.FieldPath];
                            
                            if (columnInfo.PropertyType.Equals(typeof(String)))
                            {
                                
                                MenuItem menuEquals = new MenuItem();
                                menuEquals.Header = fieldDisplayName + " égale à " + valueString;
                                menuEquals.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = valueString;
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuEquals);


                                MenuItem menuNotEquals = new MenuItem();
                                menuNotEquals.Header = fieldDisplayName + " différent de " + valueString;
                                menuNotEquals.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "<>"+valueString;
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuNotEquals);
                            }


                            if (columnInfo.AllowNull)
                            {
                                menuFilter.Items.Add(new Separator());
                                MenuItem menuNotNull = new MenuItem();
                                menuNotNull.Header = fieldDisplayName + " est renseigné";
                                menuNotNull.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "+";
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuNotNull);



                                MenuItem menuNull = new MenuItem();
                                menuNull.Header = fieldDisplayName + " n'est pas renseigné";
                                menuNull.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "-";
                                    this.SearchExecute();
                                }));

                                menuFilter.Items.Add(menuNull);
                               


                            }

                        }
                        

                        
                    }
                }
            }
        }

        void ItemsView_CurrentChanged(object sender, EventArgs e)
        {
            if (this.State == GenericDataListState.Search)
            { this.DisplayRecordIndex = "*"; }
            else
            { this.DisplayRecordIndex = (this.ItemsView.CurrentPosition+1).ToString(); }
            this.RaisePropertyChanged("DisplayRecordIndex");
            this._sliderValue = this.ItemsView.CurrentPosition;
            this.RaisePropertyChanged("SliderValue");
        }

        private void UpdateDisplayRecordCount()
        {
            IQueryable<M> queryable = this.DbSet.AsQueryable<M>();
            System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(typeof(M), "item");
            queryable = this.TryApplyFilter(queryable, expressionBase);
            int count = (from c in queryable select c).Count();
            this.DisplayRecordCount = count.ToString();
            this.RaisePropertyChanged("DisplayRecordCount");
            this.SliderMinimum = 0;
            this.SliderMaximum = count - 1;
            this.RaisePropertyChanged("SliderMinimum");
            this.RaisePropertyChanged("SliderMaximum");
            
        }

        public void BeginEdit(object obj)
        {
            if (this.ItemsView.CurrentItem != null && this.ItemsView.CurrentItem.Equals(obj))
            { 
                this.UpdatingItem = this.Items[this.ItemsView.IndexOf (obj)];
                this.State = GenericDataListState.Updating;
                this.RaiseCommandChange();
            }
        }


        private void QuitExecute()
        { }

        private Boolean CanQuitExecute()
        { return false; }

        private void SearchExecute()
        {
            this.Items.Clear();
            System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(typeof(M), "item");
            DbSet<M> dbSet = DataService.GetDbSet<M>();
            IQueryable<M> queryable = dbSet.AsQueryable<M>();
            queryable = this.TryApplyFilter(queryable, expressionBase);
            queryable = this.TryApplySort(queryable, expressionBase);
            if (queryable.Count() == 0)
            {
                MessageBox.Show("Aucune donnée à afficher, retour au mode recherche", "Plus de donnée à afficher", MessageBoxButton.OK, MessageBoxImage.Information);
                this.ClearExecute();
            }
            else
            {
                
                foreach (M model in queryable)
                {
                    GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this, model);
                    vm.LoadFromModel(this.FieldPaths.ToList());
                    this.Items.Add(vm);
                }
                this.State = GenericDataListState.Display;
                this.ItemsView.MoveCurrentToFirst();
                this.UpdateDisplayRecordCount();
                this.RaiseStateChange();
            }
          
        }

        private IQueryable<M> TryApplySort(IQueryable<M> queryable, System.Linq.Expressions.ParameterExpression expressionBase)
        {
            foreach (String fieldPath in this._sorters.Keys)
            {
                if (this._sorters[fieldPath].HasValue)
                {
                    var property = this.DataService.GetTopColumnInfo(typeof(M), fieldPath).Property;
                   
                    System.Linq.Expressions.Expression propertyAccess = null;
                    if (fieldPath.IndexOf(".") != -1)
                    {
                        String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        foreach (String item in items)
                        {
                            if (propertyAccess == null)
                            { propertyAccess = System.Linq.Expressions.Expression.Property(expressionBase,item); }
                            else
                            { propertyAccess = System.Linq.Expressions.Expression.Property(propertyAccess, item); }
                        }
                    }
                    else
                    {
                        propertyAccess = System.Linq.Expressions.Expression.Property(expressionBase, property);
                    }
                    var orderByExp = System.Linq.Expressions.Expression.Lambda(propertyAccess, expressionBase);
                    if (this._sorters[fieldPath].Value == ListSortDirection.Ascending)
                    {
                        System.Linq.Expressions.MethodCallExpression resultExp = System.Linq.Expressions.Expression.Call(typeof(Queryable), "OrderBy", new Type[] { queryable.ElementType, property.PropertyType }, queryable.Expression, System.Linq.Expressions.Expression.Quote(orderByExp));


                        queryable = queryable.Provider.CreateQuery<M>(resultExp);
                    }
                    else if (this._sorters[fieldPath].Value == ListSortDirection.Descending )
                    {
                        System.Linq.Expressions.MethodCallExpression resultExp = System.Linq.Expressions.Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { queryable.ElementType, property.PropertyType }, queryable.Expression, System.Linq.Expressions.Expression.Quote(orderByExp));


                        queryable = queryable.Provider.CreateQuery<M>(resultExp);
                        
                    }
                   
                }
            }
            return queryable;
        }

        private IQueryable<M> TryApplyFilter(IQueryable<M> queryable, System.Linq.Expressions.ParameterExpression expressionBase)
        {
            
            List<System.Linq.Expressions.Expression> expressions = new List<System.Linq.Expressions.Expression>();
            foreach (String key in this.SearchItem.Values.Keys)
            {
                if (!String.IsNullOrEmpty(SearchItem.Values[key]))
                {
                    System.Linq.Expressions.Expression expression = LinqHelper.CreateFilterExpression<M>(this.SearchItem.Values, key, expressionBase);
                   if (expression != null)
                   { expressions.Add(expression); }
                }
            }
            if (expressions.Count > 0)
            {
                System.Linq.Expressions.Expression expressionAnd = expressions.First();
                for (int i = 1; i < expressions.Count; i++)
                { expressionAnd = System.Linq.Expressions.Expression.And(expressionAnd, expressions[i]); }
                System.Linq.Expressions.MethodCallExpression whereCallExpression = System.Linq.Expressions.Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryable.ElementType },
                queryable.Expression,
                System.Linq.Expressions.Expression.Lambda(expressionAnd, expressionBase));
                queryable = queryable.Provider.CreateQuery<M>(whereCallExpression);
            }
            return queryable;
        }

        private Boolean CanSearchExecute()
        { return this.State == GenericDataListState.Search ; }

        private void ClearExecute()
        {
            if (this.State == GenericDataListState.Display)
            {
                this.Items.Clear();
                this.Items.Add(this.SearchItem);
                this.State = GenericDataListState.Search;
                this.RaiseStateChange();
                this.UpdateDisplayRecordCount();
                this.ItemsView.MoveCurrentToFirst();
            }
            else if (this.State == GenericDataListState.Search)
            {
                this.SearchItem.Reset();
                
                this.SearchItem.RaiseValuesChanges();
                this.RaiseStateChange();
            }
           
        }

        private Boolean CanClearExecute()
        {
            if (this.State == GenericDataListState.Display)
            {
                return true;
            }
            else if (this.State == GenericDataListState.Search)
            {
                bool hasCriteria = false;
                foreach (String key in this.SearchItem.Values.Keys)
                {
                    if (!String.IsNullOrEmpty(this.SearchItem.Values[key]))
                    {hasCriteria = true;}

                }
                return hasCriteria;
            }
            else return false;
            
        }


        private void CommitExecute()        
        {
            if (this.State == GenericDataListState.InsertingEmpty)
            {
                String message = null;
                if (!Validator.ValidateEntity<M>(this.InsertingItem.Model, this.InsertingItem.Values, this.DataService.GetEntityTableInfo(typeof(M)), out message))
                {
                    MessageBox.Show("Veuillez corriger les erreurs suivantes avant de valider la saisie : \r\n\r\n" + message, "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {

                    this.InsertingItem.SaveToModel(this.FieldPaths.ToList());
                    this.DbSet.Add(this.InsertingItem.Model);
                    this.DataService.DataContext.SaveChanges();
                    this.State = GenericDataListState.Search;
                    this.Items.Clear();
                    this.Items.Add(this.SearchItem);
                    this.InsertingItem = null;
                    this.RaiseStateChange();
                }
               


              

               
            }
            else if (this.State == GenericDataListState.Deleting)
            {

                this.DbSet.Remove(this.DeletingItem.Model);
                this.Items.Remove(this.DeletingItem);
                this.DataService.DataContext.SaveChanges();
                this.State = GenericDataListState.Display;
                this.DeletingItem = null;
                if (this.Items.Count == 0)
                {
                    MessageBox.Show("Aucune donnée à afficher, retour au mode recherche", "Plus de donnée à afficher", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.ClearExecute();
                }
                else { this.RaiseStateChange(); }
       
            }
            else if (this.State == GenericDataListState.Updating)
            {
                String message = null;
                if (!Validator.ValidateEntity<M>(this.UpdatingItem.Model, this.UpdatingItem.Values,this.DataService.GetEntityTableInfo (typeof(M)), out message))
                {
                    MessageBox.Show("Veuillez corriger les erreurs suivantes avant de valider la saisie : \r\n\r\n" + message, "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {                    
                    this.UpdatingItem.SaveToModel(this.FieldPaths.ToList());
                    this.DataService.DataContext.SaveChanges();
                    this.State = GenericDataListState.Display;
                    this.UpdatingItem = null;
                    this.RaiseStateChange();
                }
               
                  
               
            }
            else if (this.State == GenericDataListState.InsertingDisplay)
            {
                String message = null;
                if (!Validator.ValidateEntity<M>(this.UpdatingItem.Model, this.InsertingItem.Values, this.DataService.GetEntityTableInfo(typeof(M)), out message))
                {
                    MessageBox.Show("Veuillez corriger les erreurs suivantes avant de valider la saisie : \r\n\r\n" + message, "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    this.InsertingItem.SaveToModel(this.FieldPaths.ToList());
                    this.DbSet.Add(this.InsertingItem.Model);
                    this.DataService.DataContext.SaveChanges();
                    this.State = GenericDataListState.Display;
                    this.InsertingItem = null;
                    this.RaiseStateChange();
                }
             
               
            }
        }

        private Boolean CanCommitExecute()
        { return this.State == GenericDataListState.InsertingEmpty || this.State == GenericDataListState.Deleting || this.State == GenericDataListState.Updating || this.State == GenericDataListState.InsertingDisplay; }

        private void CancelExecute()
        {
            if (this.State == GenericDataListState.InsertingEmpty)
            {
                this.Items.Clear();
                this.Items.Add(this.SearchItem);
                this.State = GenericDataListState.Search;
                this.InsertingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.Deleting)
            {
                this.State = GenericDataListState.Display;
                this.DeletingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.Updating)
            {                
                this.UpdatingItem.LoadFromModel(this.FieldPaths.ToList ());
                this.State = GenericDataListState.Display;
                this.UpdatingItem.RaiseValuesChanges();
                this.UpdatingItem = null;
                this.RaiseStateChange();
            }
            else if (this.State == GenericDataListState.InsertingDisplay)
            {
                this.Items.Remove(this.InsertingItem);
                this.InsertingItem = null;               
                this.State = GenericDataListState.Display;
                this.RaiseStateChange();
            }
        }

        private Boolean CanCancelExecute()
        { return this.State == GenericDataListState.InsertingEmpty || this.State == GenericDataListState.Deleting || this.State == GenericDataListState.Updating || this.State == GenericDataListState.InsertingDisplay;  }


        private void DeleteExecute()
        {
            if (this.ItemsView.CurrentItem != null)
            {
                GenericListItemViewModel<M> vm = (GenericListItemViewModel<M>)this.ItemsView.CurrentItem;
                this.DeletingItem = vm;
                this.State = GenericDataListState.Deleting;
                this.RaiseStateChange();
            }
        }

        private Boolean CanDeleteExecute()
        { return this.State == GenericDataListState.Display && !this.IsLocked ; }


        private void LockUnlockExecute()
        {
            this.IsLocked =!this.IsLocked;
            this.RaiseStateChange();
        }

        private Boolean CanLockUnlockExecute()
        { return this.State == GenericDataListState.Search || this.State == GenericDataListState.Display; }

        public void RaiseStateChange()
        {
            if (this.State == GenericDataListState.Display)
            { this.CanSlide = true; }
            else this.CanSlide = false;
            this.RaiseCommandChange();
            this.RaisePropertyChanged("State");
            this.RaisePropertyChanged("CanSlide");
            this.RaisePropertyChanged("IsLocked");
            this.UpdateDisplayRecordCount();
     
        }

        private void RaiseCommandChange()
        {
            this.CancelCommand.RaiseCanExecuteChanged();
            this.CommitCommand.RaiseCanExecuteChanged();
            this.ClearCommand.RaiseCanExecuteChanged();
            this.DeleteCommand.RaiseCanExecuteChanged();
            this.InsertCommand.RaiseCanExecuteChanged();
            this.LockUnlockCommand.RaiseCanExecuteChanged();
            this.QuitCommand.RaiseCanExecuteChanged();
            this.SearchCommand.RaiseCanExecuteChanged();            
        }

        private void InsertExecute()
        {
            if (this.State == GenericDataListState.Search)
            {
                this.Items.Clear();
                M model = new M();
                GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this,model);               
                this.Items.Add(vm);
                this.State = GenericDataListState.InsertingEmpty;
                this.InsertingItem = vm;
                this.InsertingItem.RaiseValuesChanges();
                this.RaiseStateChange();
            } else if (this.State == GenericDataListState.Display)
            {
               
                M model = new M();
                GenericListItemViewModel<M> vm = new GenericListItemViewModel<M>(this, model);
                this.Items.Insert(0,vm);
                this.State = GenericDataListState.InsertingDisplay;
                this.InsertingItem = vm;
                this.ItemsView.MoveCurrentToFirst();
                this.InsertingItem.RaiseValuesChanges();
                this.RaiseStateChange();
            }
         
        }

        private Boolean CanInsertExecute()
        { return !this.IsLocked && (this.State == GenericDataListState.Search || this.State == GenericDataListState.Display); }



        public bool CanEdit(IRowEditableItem rowEditableItem)
        {
            if (this.State == GenericDataListState.Search) return true;
            if (this.State == GenericDataListState.Deleting) return false;
            if (this.State == GenericDataListState.Display && !this.IsLocked)
            {return true;   }
      
            if (this.State == GenericDataListState.InsertingEmpty) return !this.IsLocked;
            if (this.State == GenericDataListState.InsertingDisplay && !this.IsLocked)
            {
                if (this.InsertingItem.Equals(rowEditableItem))
                { return true; }
            }
            if (this.State == GenericDataListState.Updating && !this.IsLocked)
            {
                if (this.UpdatingItem != null && this.UpdatingItem.Equals(rowEditableItem))
                {
                   
                    return true;
                }
            }
            return false;
        }










        public void ShowCustomFilter()
        {
            IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            Window window =   dialogService.CreateDialog("CustomFilterRegion", "Filtre personalisé");
            CustomFilterViewModel<M> vm =  new CustomFilterViewModel<M>();
            window.DataContext = vm;
            window.ShowDialog();
        }

        public void ShowCustomSort()
        {
            IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            Window window = dialogService.CreateDialog("CustomSortRegion", "Tri personalisé");
            Dictionary<String, Nullable<ListSortDirection>> sorters = new Dictionary<string, ListSortDirection?>();
            foreach (String fieldpath in this.FieldPaths)
            {sorters.Add(fieldpath, this.GetSort(fieldpath));}
            CustomSortViewModel<M> vm = new CustomSortViewModel<M>(sorters);
            window.DataContext = vm;
            Nullable<Boolean> result =  window.ShowDialog();
            if (result.HasValue && result.Value == true)
            { 
                
            }
        }

        public void ShowCustomDisplay()
        {
            IDialogService dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            Window window = dialogService.CreateDialog("CustomDisplayRegion", "Affichage personalisé");
            CustomDisplayViewModel<M> vm = new CustomDisplayViewModel<M>();
            window.DataContext = vm;
            window.ShowDialog();
        }
    }
}
