using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Validations
{
    public enum DatePart
    {
        Day,
        Month,
        Year,
        None
    }
    public class Validator
    {
        public static Boolean ValidateEntity(Dictionary<String, String> valueStrings, EntityTableInfo tableInfo, out String message)
        {
            List<String> errors = new List<string>();
            String messageColumn = null;
            Object result = null;
            foreach (String path in valueStrings.Keys)
            {
                EntityColumnInfo columnInfo = ServiceLocator.Current.GetInstance<IDataService>().GetTopParentProperty(tableInfo.EntityType, path);
                if (!ValidateEntityColumn(valueStrings[path], columnInfo, out messageColumn, out result))
                {
                    if (path.IndexOf (".") == -1)
                    { errors.Add(columnInfo.DisplayName+" : "+ messageColumn);}
                    else
                    { errors.Add(columnInfo.TableInfo.DisplayName+ " "+ columnInfo.DisplayName+" : "+ messageColumn);}
                   
                }
            }
            if (errors.Count > 0)
            {
                message = String.Join("\r\n", errors);
                return false;
            }
            else
            {
                IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                foreach (String path in valueStrings.Keys)
                {
                    EntityColumnInfo columnInfo = ServiceLocator.Current.GetInstance<IDataService>().GetTopParentProperty(tableInfo.EntityType, path);
                    if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr && columnInfo.HasChausseeEmpriseRule)
                    {
                        EntityColumnInfo chausseeNavigationProperty = (from c in columnInfo.TableInfo.ColumnInfos where c.ColumnName.Equals (columnInfo.EmpriseChausseeColumnName ) && c.ControlType == Presentation.Infrastructure.Attributes.ControlType.Combo select c).FirstOrDefault();

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
                        
                    }
                
                }

               
            }
            if (errors.Count > 0)
            {
                message = String.Join("\r\n", errors);
                return false;
            }
            else
            {
                // validé les uk rules
                message = null;
                return true;
            }
          
        }
        public static Boolean ValidateEntityColumn(String valueString, EntityColumnInfo columnInfo, out String message, out Object value)
        {
            Int64 valueInt32 = 0;
            Double valueDouble = 0;         
            DateTime valueDateTime = DateTime.Now;
            
           
            if (!ValidateDataType(valueString, columnInfo.PropertyType, out message, out value) && columnInfo.ControlType != Presentation.Infrastructure.Attributes.ControlType.Pr)
            { return false; }
            else
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    if (!columnInfo.AllowNull)
                    {
                        value = null;
                        message = "valeur vide non autorisée";
                        return false;
                    }
                    else if (columnInfo.AllowNull)
                    {
                        value = null;
                        message = null;
                        return true;
                    }
                }
                else
                {
                    if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Text)
                    {
                        if (valueString.Length > columnInfo.MaxCharLength)
                        {
                            value = null;
                            message = "le texte de doit pas dépasser " + columnInfo.MaxCharLength+" caractères";
                            return false;
                        }
                        else
                        {
                            value = valueString;
                            message = null;
                            return true;
                        }
                       
                    }
                    else if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Integer)
                    {
                        valueInt32 = Int64.Parse(valueString);
                        if (valueInt32 > columnInfo.MaxNumericValue)
                        {
                            message = "la valeur doit être inférieur à  " + columnInfo.MaxNumericValue;
                            return false;
                        }
                        else if (valueInt32 < columnInfo.MinNumericValue)
                        {
                            message = "la valeur doit être supérieur à  " + columnInfo.MaxNumericValue;
                            return false;
                        }
                        else
                        {
                            value = valueInt32;
                            message = null;
                            return true;
                        }
                       

                    }
                    else if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Decimal)
                    {
                        valueDouble = Double.Parse(valueString.Replace (",","."),NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture);
                        if (valueDouble > columnInfo.MaxNumericValue)
                        {
                            message = "la valeur doit être inférieur à  " + columnInfo.MaxNumericValue;
                            return false;
                        }
                        else if (valueDouble < columnInfo.MinNumericValue)
                        {
                            message = "la valeur doit être supérieur à  " + columnInfo.MaxNumericValue;
                            return false;
                        }
                        else
                        {
                            value = valueDouble;
                            message = null;
                            return true;
                        }
                       

                    }
                    else if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Date)
                    { 
                        
                    }
                    else if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr)
                    {
                        Int64 dplt = 10;
                        Int64 num = 0;
                        if (valueString.IndexOf("+") != -1)
                        {
                            String[] prItems = valueString.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (prItems.Length == 2)
                            {
                                if (!Int64.TryParse(prItems[0].Trim(), out num) || !Int64.TryParse(prItems[1].Trim(), out dplt))
                                {
                                    value = null;
                                    message = valueString + " n'est pas un PR au format 12+852";
                                    return false;
                                }
                                else
                                {
                                    value = num.ToString() + " +" + dplt.ToString("0000");
                                    message = null;
                                    return true;
                                }
                            }
                            else
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                        }
                        else
                        {
                            if (!Int64.TryParse(valueString.Trim(), out num))
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                            else
                            {
                                value = num.ToString() + " +0000";
                                message = null;
                                return true;
                            }
                        } 
                    }
                }
               
            }
            message = "erreur non définit";
            value = null;
            return false;
        }


        public static Boolean ValidateDataType(String valueString, Type dataType, out String message, out Object value)
        {
            message = null;
            value = null;
            Int64 valueInt32 = 0;
            Double valueDouble = 0;
            Boolean valueBoolean = false;
            DateTime valueDateTime = DateTime.Now;
            



            if (dataType.Equals (typeof (String)))
            {
                message = null;
                return true;
            }
            else if (dataType.Equals(typeof(Int64)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (Int64.TryParse(valueString, out valueInt32))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString+" n'est pas un nombre entier valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Double)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (Double.TryParse(valueString.Replace(",", "."),System.Globalization.NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre à virgule flottante valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Boolean)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (valueString.Equals(CultureConfiguration.BooleanTrueString))
                    { valueString = "True"; }
                    else if (valueString.Equals(CultureConfiguration.BooleanFalseString))
                    { valueString = "False"; }
                    if (Boolean.TryParse(valueString, out valueBoolean))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une valeur oui/non valide";
                        return false;
                    }
                }
            }           
            else if (dataType.Equals(typeof(DateTime)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = "valeur vide non autoriséeé";
                    return false;
                }
                else
                {
                    if (DateTime.TryParseExact(valueString,CultureConfiguration.DateFormatString,System.Globalization.CultureInfo.InvariantCulture ,System.Globalization.DateTimeStyles.None ,out valueDateTime ))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une date au format "+CultureConfiguration.DateFormatString;
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<Int64>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (Int64.TryParse(valueString, out valueInt32))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre entier valide";
                        return false;
                    }
                }
                
            }
            else if (dataType.Equals(typeof(Nullable<Double>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (Double.TryParse(valueString.Replace(",", "."),System.Globalization.NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas un nombre à virgule flottante valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<Boolean>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (valueString.Equals(CultureConfiguration.BooleanTrueString))
                    { valueString = "True"; }
                    else if (valueString.Equals(CultureConfiguration.BooleanFalseString))
                    { valueString = "False"; }
                    if (Boolean.TryParse(valueString, out valueBoolean))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une valeur oui/non valide";
                        return false;
                    }
                }
            }
            else if (dataType.Equals(typeof(Nullable<DateTime>)))
            {
                if (String.IsNullOrEmpty(valueString))
                {
                    message = null;
                    return true;
                }
                else
                {
                    if (DateTime.TryParseExact(valueString, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out valueDateTime))
                    {
                        message = null;
                        return true;
                    }
                    else
                    {
                        message = valueString + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                        return false;
                    }
                }
            }
            return false;
        }
        /*
        public static Boolean ValidateDataRule(String valueObject, EntityColumnInfo dbProp, out String message, out Object value)
        {
            String valueString = "";
            if (valueObject != null)
            { valueString = valueObject.ToString(); }
            message = null;
            value = null;
            if ((!dbProp.AllowNull && valueObject == null) || (!dbProp.AllowNull && valueObject != null && String.IsNullOrEmpty(valueObject.ToString())))
            {
                value = null;
                message = "valeur vide non autorisée";
                return false;
            }
            else if ((dbProp.AllowNull && valueObject == null) || (dbProp.AllowNull && valueObject != null && !String.IsNullOrEmpty(valueObject.ToString())))
            {
                value = null;
                message = null;
                return true;
            }
            Type dataType = dbProp.Property.PropertyType;
            if (dataType.Equals(typeof(String)))
            {
                value = valueString;
                message = null;
                return true;
            }
            else if (dataType.Equals(typeof(Boolean)))
            {
                bool valBool = false;
                if (Validator.ValidateBoolean(valueString, out message, out valBool))
                {
                    value = valBool;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Double)))
            {
                Double valDouble = 0;
                if (Validator.ValidateDouble(valueString, out message, out valDouble))
                {
                    value = valDouble;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Int64)))
            {
                if (dbProp.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr)
                {
                    Int32 dplt = 10;
                    Int32 num = 0;
                    if (valueString.IndexOf("+") != -1)
                    {
                        String[] prItems = valueString.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (prItems.Length == 2)
                        {
                            if (!Int32.TryParse(prItems[0].Trim(), out num) || !Int32.TryParse(prItems[1].Trim(), out dplt))
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                            else
                            {
                                value = num.ToString ()+" +"+dplt.ToString ("0000");
                                message = null;
                                return true;
                            }
                        }
                        else
                        {
                            value = null;
                            message = valueString + " n'est pas un PR au format 12+852";
                            return false;
                        }
                    }
                    else
                    {
                        if (!Int32.TryParse(valueString.Trim(), out num))
                        {
                            value = null;
                            message = valueString + " n'est pas un PR au format 12+852";
                            return false;
                        }
                        else
                        {
                            value = num.ToString() + " +0000";
                            message = null;
                            return true;
                        }
                    }                  
                }
                else
                {
                    Int64 valInt64 = 0;
                    if (Validator.ValidateInt64(valueString, out message, out valInt64))
                    {
                        value = valInt64;
                        message = null;
                        return true;
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }
                
            }
            else if (dataType.Equals(typeof(DateTime)))
            {
                DateTime valDateTime = DateTime.Now;
                if (Validator.ValidateDateTime(valueString, out message, out valDateTime))
                {
                    value = valDateTime;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Boolean>)))
            {
                Nullable<bool> valBool = false;
                if (Validator.ValidateNullableBoolean(valueString, out message, out valBool))
                {
                    value = valBool;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Double>)))
            {
                Nullable<Double> valDouble = 0;
                if (Validator.ValidateNullableDouble(valueString, out message, out valDouble))
                {
                    value = valDouble;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            else if (dataType.Equals(typeof(Nullable<Int64>)))
            {
                if (dbProp.ControlType == Presentation.Infrastructure.Attributes.ControlType.Pr)
                {
                    Int32 dplt = 10;
                    Int32 num = 0;
                    if (valueString.IndexOf("+") != -1)
                    {
                        String[] prItems = valueString.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (prItems.Length == 2)
                        {
                            if (!Int32.TryParse(prItems[0].Trim(), out num) || !Int32.TryParse(prItems[1].Trim(), out dplt))
                            {
                                value = null;
                                message = valueString + " n'est pas un PR au format 12+852";
                                return false;
                            }
                            else
                            {
                                value = num.ToString() + " +" + dplt.ToString("0000");
                                message = null;
                                return true;
                            }
                        }
                        else
                        {
                            value = null;
                            message = valueString + " n'est pas un PR au format 12+852";
                            return false;
                        }
                    }
                    else
                    {
                        if (!Int32.TryParse(valueString.Trim(), out num))
                        {
                            value = null;
                            message = valueString + " n'est pas un PR au format 12+852";
                            return false;
                        }
                        else
                        {
                            value = num.ToString() + " +0000";
                            message = null;
                            return true;
                        }
                    }  
                }
                else
                {
                    Nullable<Int64> valInt64 = 0;
                    if (Validator.ValidateNullableInt64(valueString, out message, out valInt64))
                    {
                        value = valInt64;
                        message = null;
                        return true;
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }
               
            }
            else if (dataType.Equals(typeof(Nullable<DateTime>)))
            {
                Nullable<DateTime> valDateTime = DateTime.Now;
                if (Validator.ValidateNullableDateTime(valueString, out message, out valDateTime))
                {
                    value = valDateTime;
                    message = null;
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            value = null;
            message = "Type de donnée non gérée";
            return false;
        }
         * */

        public static bool ValidateInt64(String str, out string message, out Int64 valueInt64)
        {
            valueInt64 = -1;
            if (!Int64.TryParse(str, out valueInt64))
            {
                message = str + " n'est pas un entier valide";
                return false;
            }
            message = null;
            return true;
        }

        public static bool ValidateDouble(String str, out string message, out Double valueDouble)
        {
            valueDouble = -1;
            if (!Double.TryParse(str.Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
            {
                message = str + " n'est pas un nombre à virgule valide";
                return false;
            }
            message = null;
            return true;
        }

        public static bool ValidateNullableInt64(string str, out string message, out long? valueNullableInt64)
        {
            valueNullableInt64 = null;
            Int64 valueInt64 = 0;
            if (!String.IsNullOrEmpty(str))
            {
                if (!Int64.TryParse(str, out valueInt64))
                {
                    message = str + " n'est pas un entier valide";

                    return false;
                }
                else
                {
                    valueNullableInt64 = valueInt64;
                }
            }
            message = null;
            return true;
        }
        /// <summary>
        /// Alors la le parsing des parties de date suivant la langue c'est pas évident ....
        /// On peut considéré que seul des / et des - sont utilisé pour séparé les parties
        /// On peut considérer que l'année est toujours supérieur à 31 (pas de patrimoine en 31 après jesus christ :) )
        /// Si on as aucun séparateur  c'est une année , c'est sur
        /// Si on as un séparateur , l'anné c'est celui qui est supérieur à 31, le mois est l'autre
        /// Si on as deux séparateur, on tente un parsing de date normal avec CultureConfiguration.DateTimeFormat
        /// Du coup sa marche dans tout les cas :)
        /// Pour les test on prend pas 31 mais 1000 c'est plus lisible
        /// </summary>
        /// <param name="str"></param>
        /// <param name="message"></param>
        /// <param name="date"></param>
        /// <param name="datePart"></param>
        /// <returns></returns>
        public static bool ValidateDatePart(string str, out string message, out DateTime date, out DatePart datePart)
        {
            date = DateTime.Now;
            datePart = DatePart.None;
            message = null;
            if (!String.IsNullOrEmpty(str))
            {
                int countSeparator = str.Count(f => f == '/' || f == '-');
                if (countSeparator == 0)
                {
                    Int64 year = -1;
                    if (ValidateInt64(str, out message, out  year))
                    {
                        datePart = DatePart.Year;
                        date = new DateTime((int)year, 1, 1);
                        return true;
                    }
                }
                else if (countSeparator == 1)
                {
                    // on traite tous les séparateur ...
                    String[] itemsSplash = str.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    String[] itemsTiret = str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    List<String> items = new List<string>();
                    items.AddRange(itemsSplash);
                    items.AddRange(itemsTiret);
                    Int64 value1 = -1;
                    Int64 value2 = -1;
                    Int64 valueMonth = -1;
                    Int64 valueYear = -1;
                    if (ValidateInt64(items[0], out message, out  value1) && ValidateInt64(items[1], out message, out  value2))
                    {
                        if (value1 > 1000 && value2 <= 12 && value2 > 0)
                        {
                            valueYear = value1;
                            valueMonth = value2;
                        }
                        else if (value2 > 1000 && value1 <= 12 && value2 > 0)
                        {
                            valueYear = value2;
                            valueMonth = value2;
                        }
                        datePart = DatePart.Month;
                        date = new DateTime((int)valueYear, (int)valueMonth, 1);
                        return true;

                    }
                }
                else if (countSeparator == 2)
                {
                    if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                    {
                        datePart = DatePart.Day;
                        return true;
                    }
                }

            }

            return false;
        }
        public static bool ValidateDateTime(string str, out string message, out DateTime valueDateTime)
        {
            message = null;
            valueDateTime = DateTime.Now;
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }
            else if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out valueDateTime))
            {

                return true;
            }
            else
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }

        }

        public static bool ValidateBoolean(string str, out string message, out bool valueBoolean)
        {

            valueBoolean = false;
            message = "";
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanTrueString.ToLower()))
            {
                message = null;
                valueBoolean = true;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanFalseString.ToLower()))
            {
                message = null;
                valueBoolean = false;
                return true;
            }
            else
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
        }

        public static bool ValidateNullableBoolean(string str, out string message, out bool? valueBoolean)
        {

            valueBoolean = null;
            if (String.IsNullOrEmpty(str))
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanNullString.ToLower()))
            {
                message = null;
                valueBoolean = null;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanTrueString.ToLower()))
            {
                message = null;
                valueBoolean = true;
                return true;
            }
            else if (str.ToLower().Equals(CultureConfiguration.BooleanFalseString.ToLower()))
            {
                message = null;
                valueBoolean = false;
                return true;
            }
            else
            {
                message = str + " n'est pas une valeur Oui/Non";
                return false;
            }

        }

        public static bool ValidateNullableDateTime(string str, out string message, out DateTime? valueDateTime)
        {
            message = null;
            valueDateTime = DateTime.Now;
            DateTime parsedDate = DateTime.Now;
            if (String.IsNullOrEmpty(str))
            {
                valueDateTime = null;
                return true;
            }
            else if (DateTime.TryParseExact(str, CultureConfiguration.DateFormatString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                valueDateTime = parsedDate;
                return true;
            }
            else
            {
                message = str + " n'est pas une date au format " + CultureConfiguration.DateFormatString;
                return false;
            }
        }

        public static bool ValidateNullableDouble(string str, out string message, out double? valueNullableDouble)
        {
            valueNullableDouble = null;
            double valueDouble = 0;
            if (!String.IsNullOrEmpty(str))
            {
                if (!Double.TryParse(str.Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out valueDouble))
                {
                    message = str + " n'est pas un nombre à virgule valide";
                    return false;
                }
                else
                {
                    valueNullableDouble = valueDouble;
                }

            }
            message = null;
            return true;
        }
    }
}
