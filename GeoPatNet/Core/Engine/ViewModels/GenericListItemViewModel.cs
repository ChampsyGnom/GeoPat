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
                {this.Manager.BeginEdit(this);}

                // Si il n'y as pas de point dans le path c'est une propriété normal
                if (fieldPath.IndexOf(".") == -1)
                {
                    this.RaisePropertyChanged("[" + fieldPath + "]");
                    this.RaisePropertyChanged("Item[]");
                    
                }
                else
                {
                    
                    
                        // Sinon c'est une propriété de navigation

                        // On récupère la propriété de navigation de l'entité M
                        EntityColumnInfo currentEntityNavigationProperty = this.Manager.DataService.GetBottomColumnInfo(typeof(M), fieldPath);
                        // On récupères les informations de colonne parente
                        List<EntityColumnInfo> currentEntityNavigationPropertyParentForeignColumnInfos = this.Manager.DataService.FindParentForeignColumnInfos(currentEntityNavigationProperty);
                        List<String> pathToProps = new List<string>();
                        foreach (EntityColumnInfo currentEntityPropertyFkProperty in currentEntityNavigationPropertyParentForeignColumnInfos)
                        {
                            String pathToCurrentEntity = this.Manager.DataService.GetPath(currentEntityPropertyFkProperty.TableInfo, currentEntityNavigationProperty.TableInfo);
                            String pathToCurrentEntityProperty = pathToCurrentEntity + "." + currentEntityPropertyFkProperty.PropertyName;
                            pathToProps.Add(pathToCurrentEntityProperty);
                        }
                        String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        String itemSourceName = items[items.Length - 2] + "." + items[items.Length - 1] + ".ItemsSource";
                        int nextPropIndex = pathToProps.IndexOf(fieldPath) + 1;
                        this._comboItemsSource.Values = this._values;
                        for (int i = nextPropIndex; i < pathToProps.Count; i++)
                        {
                            String pathToProp = pathToProps[nextPropIndex];
                            String[] subItems = pathToProp.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            String subItemSourceName = subItems[subItems.Length - 2] + "." + subItems[subItems.Length - 1];
                            this._comboItemsSource[subItemSourceName].Clear();
                            this._comboItemsSource.LoadList(subItemSourceName);
                            if (this.Manager.State != Infrastructure.Enums.GenericDataListState.Search)
                            { this._values[pathToProp] = CultureConfiguration.ListNullString; }
                            

                            this.RaisePropertyChanged("[" + pathToProp + "]");
                        }
                        this.RaisePropertyChanged("[" + fieldPath + "]");
                        this.RaisePropertyChanged("Item[]");
                    
                    
                }
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
            IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopColumnInfo(typeof(M), fieldPath);
                if (fieldPath.IndexOf(".") == -1)
                {
                    
                        if (!this._values.ContainsKey(fieldPath))
                        { this._values.Add(fieldPath, null); }
                        Object value = this.Model.GetType().GetProperty(fieldPath).GetValue(this.Model);
                        if (value == null)
                        { this._values[fieldPath] = null; }
                        else
                        {
                            if (columnInfo.ControlType == ControlType.Pr && columnInfo.PrChausseeColumnName != null)
                            {
                                EntityColumnInfo columnChausseeIdInfo = (from c in columnInfo.TableInfo.ColumnInfos where c.ColumnName .Equals( columnInfo.PrChausseeColumnName) && c.ControlType == ControlType.None select c).FirstOrDefault();
                                Int64 valueIdChaussee = (Int64)columnChausseeIdInfo.Property.GetValue(this.Model);
                                Nullable<Int64> valueAbs = (Nullable<Int64>) value;
                                String pr = reperageService.AbsToPr(valueIdChaussee, valueAbs);
                                this._values[fieldPath] = pr;
                            }
                            else
                            {
                                String formattedValue = Formatter.FormatValue(columnInfo.PropertyType, value);
                                this._values[fieldPath] = formattedValue;
                            }
                            
                        }
                }
                else
                {
                    
                    String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Type baseType = typeof(M);
                    object baseValue = this.Model;
                    PropertyInfo baseProp = null;
                    for(int i = 0 ; i < items .Length ;i++)
                    {
                        PropertyInfo prop = baseType.GetProperty(items[i]);
                        baseProp = prop;
                        baseValue = prop.GetValue(baseValue);
                        if (baseValue == null)
                        {break;}
                        baseType = baseValue.GetType();
                    }
                    if (baseValue != null)
                    { this._values[fieldPath] = Formatter.FormatValue(baseProp.PropertyType, baseValue); }
                    else
                    { this._values[fieldPath] = CultureConfiguration.ListNullString; }
                    
                }
            }
            this._comboItemsSource.Values = this._values;
        }



        public void SaveToModel(List<String> fieldPaths)
        {
            EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo (typeof(M));
            List<EntityColumnInfo> navigationProperties = new List<EntityColumnInfo>();
            String message = null;
            Object valueValidated = null;
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopColumnInfo(typeof(M), fieldPath);

                if (fieldPath.IndexOf(".") == -1)
                {
                    if (columnInfo.ControlType != ControlType.Pr)
                    {

                        if (Validator.ValidateEntityColumn(this[fieldPath], columnInfo, out message, out valueValidated))
                        { 
                            this.Model.GetType().GetProperty(fieldPath).SetValue(this.Model, valueValidated); 
                        }

                    }
                    else
                    {
                        EntityColumnInfo chausseeNavigationProperty = (from c in tableInfo.ColumnInfos where c.ColumnName.Equals(columnInfo.PrChausseeColumnName) && c.ControlType ==ControlType.Combo select c).FirstOrDefault();
                        EntityTableInfo parentTableInfo = this.Manager.DataService.GetEntityTableInfo(chausseeNavigationProperty.PropertyType);
                        DbSet parentTableSet = this.Manager.DataService.GetDbSet(parentTableInfo.EntityType);
                        IQueryable parentQueryable = parentTableSet.AsQueryable();
                        List<EntityColumnInfo> parentNavProps = this.Manager.DataService.FindParentForeignColumnInfos(chausseeNavigationProperty);
                        List<String> parentNavPropsPaths = new List<string>();
                        foreach (EntityColumnInfo column in parentNavProps)
                        {
                            String pathToChild = this.Manager.DataService.GetPath(column.TableInfo, parentTableInfo);
                            if (String.IsNullOrEmpty(pathToChild))
                            {
                                String pathToProp = column.PropertyName;
                                parentNavPropsPaths.Add(pathToProp);
                            }
                            else
                            {
                                String pathToProp = pathToChild + "." + column.PropertyName;
                                parentNavPropsPaths.Add(pathToProp);
                            }
                        }

                        ParameterExpression parentExpressionBase = Expression.Parameter(parentTableInfo.EntityType, "item");
                        List<Expression> parentExpressions = new List<Expression>();

                        foreach (String parentNavPropsPath in parentNavPropsPaths)
                        {

                            String[] items = parentNavPropsPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            EntityTableInfo navPropEntity = null;

                            if (items.Length > 1)
                            { navPropEntity = this.Manager.DataService.GetEntityTableInfo(items[items.Length - 2]); }
                            else
                            { navPropEntity = parentTableInfo; }

                            Expression propertyMember = null;
                            for (int i = 0; i < items.Length; i++)
                            {
                                if (propertyMember == null)
                                { propertyMember = Expression.Property(parentExpressionBase, items[i]); }
                                else
                                { propertyMember = Expression.Property(propertyMember, items[i]); }
                            }
                            String pathTo = this.Manager.DataService.GetPath(navPropEntity, tableInfo);
                            String valuePath = pathTo + "." + items[items.Length - 1];
                            if (String.IsNullOrEmpty(pathTo))
                            { pathTo = items[items.Length - 1]; }


                            Object value = this._values[valuePath];
                            Expression expressionParent = Expression.Equal(propertyMember, Expression.Constant(value));
                            parentExpressions.Add(expressionParent);
                        }




                        if (parentExpressions.Count > 0)
                        {
                            Expression expressionAnd = parentExpressions.First();
                            for (int i = 1; i < parentExpressions.Count; i++)
                            { expressionAnd = Expression.And(expressionAnd, parentExpressions[i]); }
                            MethodCallExpression whereCallExpression = Expression.Call(
                            typeof(Queryable),
                            "Where",
                            new Type[] { parentQueryable.ElementType },
                            parentQueryable.Expression,
                            Expression.Lambda(expressionAnd, parentExpressionBase));
                            parentQueryable = parentQueryable.Provider.CreateQuery(whereCallExpression);
                        }

                        List<Object> values = new List<object>();
                        Int64 chausseeId = -1;
                        Int64 chausseeDeb = 0;
                        Int64 chausseeFin = 0;
                        foreach (Object obj in parentQueryable)
                        {
                            PropertyInfo idProp = obj.GetType().GetProperty("Id");
                            PropertyInfo debProp = obj.GetType().GetProperty("AbsDeb");
                            PropertyInfo finProp = obj.GetType().GetProperty("AbsFin");
                            chausseeId = (Int64)idProp.GetValue(obj);
                            chausseeDeb = (Int64)debProp.GetValue(obj);
                            chausseeFin = (Int64)finProp.GetValue(obj);
                        }
                        IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                        Int64 abs = reperageService.PrToAbs(chausseeId, this._values[columnInfo.PropertyName]).Value;
                        this.Model.GetType().GetProperty(fieldPath).SetValue(this.Model, abs);
                    }
                }
                else
                {
                 
                    String[] fieldPathItems = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    EntityColumnInfo bottomProp = (from p in tableInfo.ColumnInfos where p.PropertyName.Equals (fieldPathItems[0]) select p).FirstOrDefault();                 
                    navigationProperties.Add(bottomProp);
                }
            }
            navigationProperties = (from p in navigationProperties select p).Distinct().ToList();
            foreach (EntityColumnInfo navigationProperty in navigationProperties)
            {
                EntityTableInfo parentTableInfo = this.Manager.DataService.GetEntityTableInfo(navigationProperty.PropertyType);
                DbSet set = this.Manager.DataService.GetDbSet(parentTableInfo.EntityType);
                IQueryable queryable = set.AsQueryable();
                List<EntityColumnInfo> parentNavProps =  this.Manager.DataService.FindParentForeignColumnInfos(navigationProperty);
                List<String> parentNavPropsPaths = new List<string>();
                foreach (EntityColumnInfo column in parentNavProps)
                {
                    String pathToChild = this.Manager.DataService.GetPath(column.TableInfo, parentTableInfo);
                    if (String.IsNullOrEmpty(pathToChild))
                    {
                        String pathToProp =  column.PropertyName;
                        parentNavPropsPaths.Add(pathToProp);
                    }
                    else
                    {
                        String pathToProp = pathToChild + "." + column.PropertyName;
                        parentNavPropsPaths.Add(pathToProp);
                    }
                   
                   
                }

                ParameterExpression expressionBase = Expression.Parameter(parentTableInfo.EntityType, "item");
                List<Expression> expressions = new List<Expression>();

                foreach (String parentNavPropsPath in parentNavPropsPaths)
                {
                    String[] items = parentNavPropsPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    EntityTableInfo navPropEntity = null;

                    if (items.Length > 1)
                    { navPropEntity = this.Manager.DataService.GetEntityTableInfo(items[items.Length - 2]); }
                    else
                    { navPropEntity = parentTableInfo; }
                    Expression propertyMember = null;
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (propertyMember == null)
                        { propertyMember = Expression.Property(expressionBase, items[i]); }
                        else
                        { propertyMember = Expression.Property(propertyMember, items[i]); }
                    }
                    String pathTo = this.Manager.DataService.GetPath(navPropEntity, tableInfo);
                    String valuePath = pathTo + "." + items[items.Length - 1];
                    if (String.IsNullOrEmpty(pathTo))
                    { pathTo = items[items.Length - 1]; }
                 
            
                    Object value = this._values[valuePath];
                    Expression expression = Expression.Equal(propertyMember, Expression.Constant(value));
                    expressions.Add(expression);
                }


                if (expressions.Count > 0)
                {
                    Expression expressionAnd = expressions.First();
                    for (int i = 1; i < expressions.Count; i++)
                    { expressionAnd = Expression.And(expressionAnd, expressions[i]); }
                    MethodCallExpression whereCallExpression = Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { queryable.ElementType },
                    queryable.Expression,
                    Expression.Lambda(expressionAnd, expressionBase));
                    queryable = queryable.Provider.CreateQuery(whereCallExpression);
                }
              
                List<Object> values = new List<object>();
                foreach (Object obj in queryable)
                {

                    this.Model.GetType().GetProperty(navigationProperty.PropertyName).SetValue(this.Model, obj);
                }
            }
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
                    if (((IDataErrorInfo ) this)["["+key+"]"] != null)
                    {
                      
                        EntityColumnInfo columnInfo = this.Manager.DataService.GetTopColumnInfo(typeof(M), key);
                        String displayName = columnInfo.DisplayName;
                        if (key.IndexOf(".") != -1)
                        {displayName = columnInfo.TableInfo.DisplayName + " " + columnInfo.DisplayName;}
                        String error = displayName + " : " + ((IDataErrorInfo)this)["[" + key + "]"];
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
                if (this.Manager.State == Infrastructure.Enums.GenericDataListState.Search) return null;
                String message = null;
                Object result = null;
                
               
                if (columnName.StartsWith("[") && columnName.EndsWith("]"))
                {
                    String path = columnName.Substring(1);
                    path = path.Substring(0, path.Length - 1);
                    EntityColumnInfo topColumn = this.Manager.DataService.GetTopColumnInfo(typeof(M), path);
                    if (path.IndexOf(".") == -1)
                    {

                        if (!Validator.ValidateEntityColumn(this._values[path], topColumn, out message, out result))
                        {return message;}
                    }
                    else
                    {
                        String[] items = path.Split (".".ToCharArray (),StringSplitOptions .RemoveEmptyEntries );
                        EntityTableInfo tableInfo = this.Manager.DataService.GetEntityTableInfo(typeof(M));
                        EntityColumnInfo topProperty = this.Manager.DataService.GetTopColumnInfo(typeof(M), path);
                        EntityColumnInfo bottomProp = (from c in tableInfo.ColumnInfos where c.PropertyName.Equals (items[0]) select c).FirstOrDefault();
                        Object valueObject = this._values[path];
                        if (!bottomProp.AllowNull && (this._values[path] == null || String.IsNullOrEmpty(this._values[path].ToString ()) || this._values[path].Equals(CultureConfiguration.ListNullString)))
                        {return "valeur vide non autorisée";}
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
