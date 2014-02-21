using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Validations;
using Emash.GeoPatNet.Engine.Infrastructure.ComponentModel;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class GenericListItemViewModel<M> : INotifyPropertyChanged, IRowEditableItem,IDataErrorInfo
    {
        public GenericListSources<M> Lists { get; private set; }
        
        private Dictionary<String, String> _values;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public M Model { get; private set; }
        public IGenericListViewModel Manager { get; private set; }
        public GenericListItemViewModel(IGenericListViewModel manager, M model)
        {
            this.Model = model;
            this.Manager = manager;
            this._values = new Dictionary<string, string>();
            this.Lists = new GenericListSources<M>();
        }
        [IndexerName("Values")]
        public string this[String  fieldPath]
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

                if (fieldPath.IndexOf(".") != -1)
                {
                    this.UpdateDepedencyListFilter(fieldPath);
                    

                }

                if (this.Manager.State == Infrastructure.Enums.GenericDataListState.Display && !this.Manager.IsLocked)
                {this.Manager.BeginEdit(this);}

                this.RaisePropertyChanged("[" + fieldPath + "]");
            }
        }

        private void UpdateDepedencyListFilter(string fieldPath)
        {
            EntityColumnInfo bottomProp = this.Manager.DataService.GetBottomProperty(typeof(M), fieldPath);
            List<EntityColumnInfo> parentfkProperties = this.Manager.DataService.FindFkParentProperties(bottomProp);
            this.Lists.UpdateFilter(fieldPath, this._values);
            foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
            {
                String pathToChild = this.Manager.DataService.GetPath(parentfkProperty.TableInfo, bottomProp.TableInfo);
                String pathToProp = pathToChild + "." + parentfkProperty.PropertyName;
                Console.WriteLine("Path to prop " + pathToProp);

            }
        }

        

        public void LoadFromModel(List<String> fieldPaths)
        {
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopParentProperty(typeof(M), fieldPath);
                if (fieldPath.IndexOf(".") == -1)
                {
                    if (columnInfo.PropertyType.Equals(typeof(String)))
                    {
                        if (!this._values.ContainsKey(fieldPath))
                        { this._values.Add(fieldPath, null); }
                        Object value = this.Model.GetType().GetProperty(fieldPath).GetValue(this.Model);
                        if (value == null)
                        { this._values[fieldPath] = ""; }
                        else
                        { this._values[fieldPath] = value.ToString(); }
                       
                    }
                }
                else
                { 

                }
            }
        }

        public void SaveToModel(List<String> fieldPaths)
        {
            foreach (String fieldPath in fieldPaths)
            {
                EntityColumnInfo columnInfo = this.Manager.DataService.GetTopParentProperty(typeof(M), fieldPath);
                if (fieldPath.IndexOf(".") == -1)
                {
                    if (columnInfo.PropertyType.Equals(typeof(String)))
                    {
                        this.Model.GetType().GetProperty(fieldPath).SetValue(this.Model, this[fieldPath]);
                    }
                }
                else
                {
                    EntityColumnInfo bottomProp = this.Manager.DataService.GetBottomProperty(typeof(M), fieldPath);
                    EntityTableInfo parentTableInfo = this.Manager.DataService.GetEntityTableInfo(bottomProp.PropertyType);
                    DbSet set = this.Manager.DataService.GetDbSet(parentTableInfo.EntityType);
                    IQueryable queryable = set.AsQueryable();
                    List<EntityColumnInfo> parentfkProperties = this.Manager.DataService.FindFkParentProperties(bottomProp);
                    ParameterExpression expressionBase = Expression.Parameter(parentTableInfo.EntityType, "item");
                    List<Expression> expressions = new List<Expression> ();

                    foreach (EntityColumnInfo parentfkProperty in parentfkProperties)
                    {
                        String pathToChild = this.Manager.DataService.GetPath(parentfkProperty.TableInfo, parentTableInfo);
                        if (String.IsNullOrEmpty(pathToChild))
                        {
                            Expression propertyMember = Expression.Property(expressionBase, parentfkProperty.PropertyName);
                            Expression expression = Expression.Equal(propertyMember, Expression.Constant ( this._values[fieldPath]));
                            expressions.Add(expression);
                        }
                        else
                        {
                            String[] pathsToChild = pathToChild.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            Expression propertyMember = null;
                            for (int i = 0; i < pathsToChild.Length; i++)
                            {
                                if (propertyMember == null)
                                { propertyMember = Expression.Property(expressionBase, pathsToChild[i]); }
                                else
                                { propertyMember = Expression.Property(propertyMember, pathsToChild[i]); }
                            }
                            propertyMember = Expression.Property(propertyMember, parentfkProperty.PropertyName);
                            Expression expression = Expression.Equal(propertyMember, Expression.Constant(this._values[fieldPath]));
                            expressions.Add(expression);
                        }
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
                        this.Model.GetType().GetProperty(bottomProp.PropertyName).SetValue(this.Model, obj);
                    }

                }
            }
        }

        internal void RaiseValuesChanges()
        {
            foreach (String key in this._values.Keys)
            { this.RaisePropertyChanged("[" + key + "]"); }
           
        }

       
        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get {
                String message = null;
                Object result = null;
                if (this.Model != null)
                {
                    Console.WriteLine("Find Error for " + columnName);
                    if (columnName.StartsWith("[") && columnName.EndsWith("]"))
                    {
                        String path = columnName.Substring(1);
                        path = path.Substring(0, path.Length - 1);
                        EntityColumnInfo topColumn = this.Manager.DataService.GetTopParentProperty(typeof(M), path);
                        if (path.IndexOf(".") == -1)
                        {

                            if (!Validator.ValidateObject(this._values[path], topColumn, out message, out result))
                            {
                                return message;
                            }
                        }
                        else
                        {

                        }
                    }
                }
               
                return null;
            }
        }
    }
}
