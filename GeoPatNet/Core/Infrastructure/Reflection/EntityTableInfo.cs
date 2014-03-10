using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;

using System.Reflection;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Validations;
using Emash.GeoPatNet.Infrastructure.Services;
using System.Linq.Expressions;


namespace Emash.GeoPatNet.Infrastructure.Reflection
{
    public class EntityTableInfo
    {
        public List<EntityValidationRule> ValidationRules { get; private set; }
        public Type EntityType { get; private set; }
        public String TableName { get; private set; }
        public String SchemaName { get; private set; }
        public String DisplayName { get; private set; }
        public Int32 Level { get; set; }
        public EntitySchemaInfo SchemaInfo { get;   set; }
        public List<EntityColumnInfo> ColumnInfos { get; private set; }
        public List<EntityFieldInfo> FieldInfos { get; private set; }

        public bool Validate(Object entityObject, Dictionary<String, String> valueStrings, out String message)
        {
            List<String> errors = new List<string>();
            foreach (EntityValidationRule validationRule in this.ValidationRules)
            {
                if (!validationRule.Validate(entityObject, valueStrings, this, out message))
                { errors.Add(message); }
            }
            if (errors.Count > 0)
            {
                message = String.Join ("\r\n",errors);
                return false ;
            }
            else
            {
                message = null;
                return true;
            }
            
        }
        public EntityTableInfo(Type entityType)
        {
            this.Level = -1;
            this.ValidationRules = new List<EntityValidationRule>();
            this.FieldInfos = new List<EntityFieldInfo>();
            this.EntityType = entityType;
            Object[] atts = this.EntityType.GetCustomAttributes(false);
            foreach (Attribute att in atts)
            {
                if (att is SchemaNameAttribute)
                {
                    this.SchemaName = (att as SchemaNameAttribute).SchemaName;
                }

                if (att is TableNameAttribute)
                {
                    this.TableName = (att as TableNameAttribute).TableName;
                }
                if (att is DisplayNameAttribute)
                {
                    this.DisplayName = (att as DisplayNameAttribute).DisplayName;
                }
            }
            this.ColumnInfos = new List<EntityColumnInfo>();
            PropertyInfo[] properties = entityType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ControlTypeAttribute att = property.GetCustomAttribute<ControlTypeAttribute>();
                if (att != null)
                {
                    EntityColumnInfo columnInfo = new EntityColumnInfo(this, property);

                    this.ColumnInfos.Add(columnInfo);
                }
                
            }

      
        }

        internal void CreateValidationRules()
        {
            this.ValidationRules.Clear();
            List<String> uniqueKeyNames = new List<string>();
            foreach (EntityColumnInfo columnInfo in this.ColumnInfos)
            {
                if (columnInfo.EmpriseChausseeColumnName != null)
                {
                    EntityValidationRuleEmpriseChaussee validationRule = new EntityValidationRuleEmpriseChaussee();
                    validationRule.ColumnLocation = columnInfo;
                    this.ValidationRules.Add(validationRule);

                }
                if (columnInfo.UniqueKeyNames != null && columnInfo.UniqueKeyNames.Count > 0)
                {uniqueKeyNames.AddRange(columnInfo.UniqueKeyNames);}
            }
            uniqueKeyNames = (from uk in uniqueKeyNames select uk).Distinct().ToList();
            foreach (String ukName in uniqueKeyNames)
            {
                EntityValidationRuleUniqueKey ukRule = new EntityValidationRuleUniqueKey();
                ukRule.UniqueKeyName = ukName;
                this.ValidationRules.Add(ukRule);
            }

        }

        public void SaveToModel(object entityObject, Dictionary<string, string> values)
        {
            String messageString = null;
            Object value = null;
            List<EntityColumnInfo> foreignColumnInfos = new List<EntityColumnInfo>();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            // On valorise les propriété de type native du modeles et on liste les propriété non native et on liste les PR
            List<EntityFieldInfo> fieldInfoPrs = new List<EntityFieldInfo>();
            foreach (EntityFieldInfo fieldInfo in this.FieldInfos)
            {
                if (fieldInfo.IsMainTableField || fieldInfo.IsNeeded)
                {
                    if (values.ContainsKey(fieldInfo.Path))
                    {
                        if (fieldInfo.ParentColumnInfo == null)
                        {
                            if (fieldInfo.ValidateString(values[fieldInfo.Path], out messageString, out value))
                            {
                                if (fieldInfo.ControlType == ControlType.Pr)
                                {fieldInfoPrs.Add(fieldInfo);}
                                else
                                {fieldInfo.ColumnInfo.Property.SetValue(entityObject, value);}
                            }
                        }
                        else
                        {foreignColumnInfos.Add(fieldInfo.ColumnInfo);}
                    }
                }
            }
           
           
            foreach (EntityColumnInfo foreignColumnInfo in foreignColumnInfos)
            {
                List<EntityFieldInfo> ukFieldInfos = new List<EntityFieldInfo>();
                List<EntityColumnInfo> parentUkColumnInfos = dataService.GetAllParentUniqueKeyColumnInfos(foreignColumnInfo);
                foreach (EntityColumnInfo parentUkColumnInfo in parentUkColumnInfos)
                {
                    EntityFieldInfo fieldInfo = (from f in this.FieldInfos
                                                 where
                                                     f.ParentColumnInfo != null &&
                                                     f.ParentColumnInfo.Equals(parentUkColumnInfo)
                                                 select f).FirstOrDefault();
                    ukFieldInfos.Add(fieldInfo);
                }
                List<Expression> expressions = new List<Expression>();
                ParameterExpression expressionBase = Expression.Parameter(foreignColumnInfo.PropertyType, "item");
                foreach (EntityFieldInfo ukFieldInfo in ukFieldInfos)
                {
                    if (values.ContainsKey(ukFieldInfo.Path))
                    {
                        if (ukFieldInfo.ValidateString(values[ukFieldInfo.Path], out messageString, out value))
                        {
                            List<String> items = ukFieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList ();
                            if (items.Count  > 1)
                            {
                                items.Remove(items.First());
                            }
                            Expression expression = expressionBase;
                            foreach (String item in items)
                            { expression = Expression.Property(expression, item); }
                            expression = Expression.Equal(expression, Expression.Constant(value));
                            expressions.Add(expression);

                        }
                    }
                }
                IQueryable queryable = dataService.GetDbSet(foreignColumnInfo.PropertyType);
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
                Object valueItem = null;
                foreach (Object o in queryable)
                { valueItem = o; break; }
                foreignColumnInfo.Property.SetValue(entityObject, valueItem);
            }

            foreach (EntityFieldInfo fieldInfoPr in fieldInfoPrs)
            {

            }
        }

        public Dictionary<string, string> LoadFromModel(object entityObject, List<string> fieldPaths)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (String fieldPath in fieldPaths)
            {               
                EntityFieldInfo fieldInfo = (from f in this.FieldInfos where f.Path.Equals(fieldPath) select f).FirstOrDefault();
                if (fieldInfo != null)
                { values.Add(fieldPath, fieldInfo.GetValueString(entityObject));}
            }
            return values;
        }
    }
}
