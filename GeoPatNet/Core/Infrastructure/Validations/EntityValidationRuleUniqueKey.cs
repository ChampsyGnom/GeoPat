using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Validations
{
    
    public class EntityValidationRuleUniqueKey : EntityValidationRule 
    {
        public String UniqueKeyName { get; set; }
        public override  Boolean Validate(Object entityObject, Dictionary<String, String> valueStrings, EntityTableInfo tableInfo, out String message)
        {
            List<EntityFieldInfo> ukFieldInfos = new List<EntityFieldInfo>();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            // On recherche les colonnes faisant parti de la clé unique
            foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
            {
                if (columnInfo.UniqueKeyNames.Contains(UniqueKeyName))
                {
                    // Si il s'agit d'un clé étrangère on récupère la liste des champs coresspondant au clé unique des parent
                    if (columnInfo.ForeignKeyNames.Count > 0)
                    {
                        List<EntityColumnInfo> parentUkColumnInfos = dataService.GetAllParentUniqueKeyColumnInfos(columnInfo);
                        foreach (EntityColumnInfo parentUkColumnInfo in parentUkColumnInfos)
                        {
                            EntityFieldInfo fieldInfo = (from f in tableInfo.FieldInfos where  
                                                             f.ParentColumnInfo != null && 
                                                             f.ParentColumnInfo.Equals(parentUkColumnInfo)
                                                            select f).FirstOrDefault();
                            ukFieldInfos.Add(fieldInfo);
                        }
                      
                    }
                    // Sinon on ajoute le champ coresspondant
                    else
                    {
                        EntityFieldInfo fieldInfo = (from f in tableInfo.FieldInfos where f.ColumnInfo.Equals (columnInfo ) select f).FirstOrDefault();
                        ukFieldInfos.Add(fieldInfo);
                    }
                }
            }
            String messageString = null;
            Object value = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression expressionBase = Expression.Parameter(tableInfo.EntityType, "item");
            foreach (EntityFieldInfo ukFieldInfo in ukFieldInfos)
            {
                if (valueStrings.ContainsKey(ukFieldInfo.Path))
                {
                    if (ukFieldInfo.ValidateString(valueStrings[ukFieldInfo.Path], out messageString, out value))
                    {
                        String[] items = ukFieldInfo.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        Expression expression = expressionBase;
                        foreach (String item in items)
                        { expression = Expression.Property(expression, item); }
                        expression = Expression.Equal(expression, Expression.Constant(value));
                        expressions.Add(expression);

                    }
                }
                else throw new Exception("Impossible de créer les critères pour la règle de validation clé unique " + UniqueKeyName);
                
            }
            IQueryable queryable = dataService.GetDbSet(tableInfo.EntityType);
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
            else throw new Exception("Impossible de créer les critères pour la règle de validation clé unique " + UniqueKeyName);
            bool hasSomeRow = false;
            foreach (Object o in queryable)
            { hasSomeRow = true; break; }

            Console.WriteLine("uk fields " + ukFieldInfos);
            if (hasSomeRow)
            {
                message = "il existe déja un enregistrement avec les mêmes "+String.Join (",", (from f in ukFieldInfos select f.DisplayName ));
                return false;
            }
            else
            {
                message = null;
                return true;
            }
        }
    }
}
