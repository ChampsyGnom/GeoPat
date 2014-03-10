using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
                        if (ukFieldInfo.ControlType == Attributes.ControlType.Pr)
                        {
                            // On est jamais sur chaussé !!! :) ouf

                            // On récupère la colonne chausséé de l'entité
                            // Il faut récupérer la clé unique de la table chausséé
                            EntityColumnInfo columnInfoChaussee = (from c in tableInfo.ColumnInfos where 
                                                                       c.ControlType == Attributes.ControlType.Combo && 
                                                                       c.ColumnName.Equals("INF_CHAUSSEE__ID") select c).FirstOrDefault();

                            List<EntityColumnInfo> columnInfoChausseeUks = dataService.GetAllParentUniqueKeyColumnInfos(columnInfoChaussee);
                            Console.WriteLine(columnInfoChausseeUks);


                            List<EntityFieldInfo> ukFieldChausseeInfos = new List<EntityFieldInfo>();
                            Boolean allChausseeValuePresent = true;
                            foreach (EntityColumnInfo columnInfoChausseeUk in columnInfoChausseeUks)
                            {
                                EntityFieldInfo fieldInfo = (from f in tableInfo .FieldInfos
                                                             where
                                                                 f.ParentColumnInfo != null &&
                                                                 f.ParentColumnInfo.Equals(columnInfoChausseeUk)
                                                             select f).FirstOrDefault();
                                ukFieldChausseeInfos.Add(fieldInfo);
                                if (!valueStrings.ContainsKey(fieldInfo.Path))
                                { allChausseeValuePresent = false; }

                            }
                            if (allChausseeValuePresent == true)
                            {
                                EntityTableInfo tableInfoChaussee = dataService.GetEntityTableInfo("InfChaussee");
                                DbSet dbSetChaussee = dataService.GetDbSet(tableInfoChaussee.EntityType);
                                ParameterExpression expressionBaseChaussee = Expression.Parameter(tableInfoChaussee.EntityType, "item");
                                List<Expression> expressionsChaussees = new List<Expression>();
                                foreach (EntityFieldInfo ukFieldChausseeInfo in ukFieldChausseeInfos)
                                {
                                    if (ukFieldChausseeInfo.ValidateString(valueStrings[ukFieldChausseeInfo.Path], out messageString, out value))
                                    {
                                        String chausseePath = ukFieldChausseeInfo.Path.Substring("InfChaussee.".Length);
                                        String[] chausseePathItems = chausseePath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                        Expression expressionChaussee = null;
                                        foreach (String chausseePathItem in chausseePathItems)
                                        {
                                            if (expressionChaussee == null)
                                            { expressionChaussee = Expression.Property(expressionBaseChaussee, chausseePathItem); }
                                            else
                                            { expressionChaussee = Expression.Property(expressionChaussee, chausseePathItem); }
                                        }

                                        expressionChaussee = Expression.Equal(expressionChaussee, Expression.Constant(value));
                                        expressionsChaussees.Add(expressionChaussee);
                                    }
                                }

                                IQueryable queryableChaussee = dbSetChaussee;
                                if (expressionsChaussees.Count > 0)
                                {
                                    Expression expressionAnd = expressionsChaussees.First();
                                    for (int i = 1; i < expressionsChaussees.Count; i++)
                                    { expressionAnd = Expression.And(expressionAnd, expressionsChaussees[i]); }
                                    MethodCallExpression whereCallExpression = Expression.Call(
                                    typeof(Queryable),
                                    "Where",
                                    new Type[] { queryableChaussee.ElementType },
                                    queryableChaussee.Expression,
                                    Expression.Lambda(expressionAnd, expressionBaseChaussee));
                                    queryableChaussee = queryableChaussee.Provider.CreateQuery(whereCallExpression);
                                }
                                Object chausseeItem = null;
                                foreach (Object item in queryableChaussee)
                                {chausseeItem = item; break;}
                                if (chausseeItem != null)
                                {
                                    Int64 chausseId =(Int64) chausseeItem.GetType().GetProperty("Id").GetValue(chausseeItem);
                                    IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                                   Nullable<Int64> abs =   reperageService.PrToAbs(chausseId, valueStrings[ukFieldInfo.Path]);
                                   if (ukFieldInfo.ColumnInfo.AllowNull)
                                   {
                                       expression = Expression.Equal(expression, Expression.Constant(abs, typeof(Nullable<Int64>)));
                                       expressions.Add(expression);
                                   }
                                   else
                                   {
                                       expression = Expression.Equal(expression, Expression.Constant(abs.Value));
                                       expressions.Add(expression);
                                   }
                                }
                                // il faut créer la requete sur la table chaussée avec les values de l'entité

                            } else throw new Exception("Impossible de récupérer toutes les valeurs de la clé unique chaussé, veuillé vérifier le modèle de donnée");
                            /*
                             IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                             EntityColumnInfo columnChaussee = (from c in tableInfo.ColumnInfos
                                                                 where
                                                                     c.ColumnName.Equals("INF_CHAUSSEE__ID")
                                                                 select c).FirstOrDefault();
                              Int64 chausseeId = (Int64)columnChaussee.Property.GetValue(entityObject);
                              Nullable<Int64> abs = reperageService.PrToAbs(chausseeId, valueStrings[ukFieldInfo.Path]);
                              if (ukFieldInfo.ColumnInfo.AllowNull)
                              {
                                  expression = Expression.Equal(expression, Expression.Constant(abs,typeof(Nullable<Int64>)));
                                  expressions.Add(expression);
                              }
                              else
                              {
                                  expression = Expression.Equal(expression, Expression.Constant(abs.Value));
                                  expressions.Add(expression);
                              }
                            
                          */
                        }
                        else
                        {
                            expression = Expression.Equal(expression, Expression.Constant(value));
                            expressions.Add(expression);
                        }
                       

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
