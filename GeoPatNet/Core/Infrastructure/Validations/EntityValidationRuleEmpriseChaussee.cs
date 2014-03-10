using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    public class EntityValidationRuleEmpriseChaussee : EntityValidationRule 
    {
        // @TODO Validation emprise chaussée
        public EntityColumnInfo ColumnLocation { get; set; }
        public override  Boolean Validate(Object entityObject, Dictionary<String, String> valueStrings, EntityTableInfo tableInfo, out String message)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();

            EntityColumnInfo columnChaussee = (from c in tableInfo.ColumnInfos
                                               where c.ControlType == ControlType.Combo &&
                                                   c.ColumnName.Equals("INF_CHAUSSEE__ID")
                                               select c).FirstOrDefault();
            Object chausseeObj = columnChaussee.Property.GetValue(entityObject);
            Int64 chausseeId = (Int64)chausseeObj.GetType().GetProperty("Id").GetValue(chausseeObj);
            Int64 chausseeAbsDeb = (Int64)chausseeObj.GetType().GetProperty("AbsDeb").GetValue(chausseeObj);
            Int64 chausseeAbsFin = (Int64)chausseeObj.GetType().GetProperty("AbsFin").GetValue(chausseeObj);
            EntityFieldInfo fieldInfo = (from f in tableInfo.FieldInfos where  f.ColumnInfo.Equals (ColumnLocation ) select f).FirstOrDefault();
            Nullable<Int64> abs = reperageService.PrToAbs(chausseeId, valueStrings[fieldInfo.Path]);
            if (abs.HasValue)
            {
                if (abs.Value > chausseeAbsFin || abs.Value < chausseeAbsDeb)
                {
                    message = fieldInfo.DisplayName + " ne peut pas être en dehors des bornes de la chaussée ( " + reperageService.AbsToPr(chausseeId, chausseeAbsDeb) + " <-> " + reperageService.AbsToPr(chausseeId, chausseeAbsFin);
                    return false;
                }
            }
            else
            {
                message = null;
                return true;
            }

            /*
             * // Regle emprise
                    EntityColumnInfo columnInfo = ServiceLocator.Current.GetInstance<IDataService>().GetTopColumnInfo(tableInfo.EntityType, path);

                    if (columnInfo.ControlType ==ControlType.Pr && columnInfo.HasChausseeEmpriseRule)
                    {
                        EntityColumnInfo chausseeNavigationProperty = (from c in columnInfo.TableInfo.ColumnInfos where c.ColumnName.Equals (columnInfo.EmpriseChausseeColumnName ) && c.ControlType == ControlType.Combo select c).FirstOrDefault();
                        EntityTableInfo parentTableInfo = dataService.GetEntityTableInfo(chausseeNavigationProperty.PropertyType);
                        DbSet set = dataService.GetDbSet(parentTableInfo.EntityType);
                        IQueryable queryable = set.AsQueryable();
                        List<EntityColumnInfo> parentNavProps = dataService.FindParentForeignColumnInfos(chausseeNavigationProperty);
                        List<String> parentNavPropsPaths = new List<string>();
                        foreach (EntityColumnInfo column in parentNavProps)
                        {
                            String pathToChild = dataService.GetPath(column.TableInfo, parentTableInfo);
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

                        ParameterExpression expressionBase = Expression.Parameter(parentTableInfo.EntityType, "item");
                        List<Expression> expressions = new List<Expression>();

                        foreach (String parentNavPropsPath in parentNavPropsPaths)
                        {
                           
                            String[] items = parentNavPropsPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            EntityTableInfo navPropEntity = null;

                            if (items.Length > 1)
                            { navPropEntity = dataService.GetEntityTableInfo(items[items.Length - 2]); }
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
                            String pathTo = dataService.GetPath(navPropEntity, tableInfo);
                            String valuePath = pathTo + "." + items[items.Length - 1];
                            if (String.IsNullOrEmpty(pathTo))
                            { pathTo = items[items.Length - 1]; }


                            Object value = valueStrings[valuePath];
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
                        Int64 chausseeId = -1;
                        Int64 chausseeDeb = 0;
                        Int64 chausseeFin = 0;
                        foreach (Object obj in queryable)
                        {
                            PropertyInfo idProp = obj.GetType().GetProperty("Id");
                            PropertyInfo debProp = obj.GetType().GetProperty("AbsDeb");
                            PropertyInfo finProp = obj.GetType().GetProperty("AbsFin");
                            chausseeId = (Int64)idProp.GetValue(obj);
                            chausseeDeb = (Int64)debProp.GetValue(obj);
                            chausseeFin = (Int64)finProp.GetValue(obj);
                        }
                        IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                        Nullable<Int64> absValue = reperageService.PrToAbs(chausseeId, valueStrings[path]);
                        String prDebChaussee = reperageService.AbsToPr(chausseeId, chausseeDeb);
                        String prFinChaussee = reperageService.AbsToPr(chausseeId, chausseeFin);
                        if (absValue.HasValue)
                        {
                            if (absValue.Value > chausseeFin)
                            { errors.Add(columnInfo.DisplayName + " : "+valueStrings[path]+" est supérieur à la fin de la chaussée ( " + prDebChaussee+" <-> "+prFinChaussee +" )"); }

                            if (absValue.Value < chausseeDeb)
                            { errors.Add(columnInfo.DisplayName + " : " + valueStrings[path] + " est inférieur au début de la chaussée ( " + prDebChaussee + " <-> " + prFinChaussee + " )"); }
                        }
             * */
            message = null;
            return true;
        }
    }
}
