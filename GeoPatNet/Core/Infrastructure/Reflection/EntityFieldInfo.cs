using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Validations;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Reflection
{
    /// <summary>
    /// Information du un champ d'une entity
    /// On as un niveau champs car certaines colonnes de la base de donnée vont généré en fait plusieur control
    /// C'est le cas des clé étrangère, si une table A est lié as une table B (B est parent de A) qui est lié a une table C (C est parent de B)
    /// 1 On commence par la table A, on regarde sur ces colonnes
    ///     2 - si la colonne n'est pas une clé étrangères on ajoute un champ pour cette colonne
    ///     3 - si la colonne est une clé étrangères
    ///         4 - si la table parente n'as pas de clé unique, on ajoute un champ pour cette colonne
    ///         5 - si la table as une clé unique ou plus, on prend de préférence celle qui finit par REF, on liste les colonne de cette cles unique
    ///             -  On reprend en 2
    ///           
    /// </summary>
    public class EntityFieldInfo
    {
        public List<EntityFieldValidationRule> ValidationRules { get; set; }
        public Boolean IsNeeded { get; set; }
        public Boolean IsMainTableField { get; set; }
        public String DisplayName
        {
            get {
                if (ParentColumnInfo == null) return ColumnInfo.DisplayName;
                else return ParentColumnInfo.TableInfo.DisplayName;
            }
        }
        public ControlType ControlType { get; set; }
        public EntityTableInfo  TableInfo { get; set; }
        public EntityColumnInfo ColumnInfo { get; set; }
        public EntityColumnInfo ParentColumnInfo { get; set; }
        public String Path { get; set; }

        public EntityFieldInfo()
        {
            this.ValidationRules = new List<EntityFieldValidationRule>();
        }

        public string GetValueString(object entityObject)
        {
            if (this.ParentColumnInfo == null)
            {
                if (this.ControlType == Attributes.ControlType.Pr)
                {
                    if (this.ColumnInfo != null && this.ParentColumnInfo == null)
                    {

                        Object value = this.ColumnInfo.Property.GetValue(entityObject);
                        IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                        EntityColumnInfo columnChausseeIdInfo = (from c in this.ColumnInfo.TableInfo.ColumnInfos where c.ColumnName.Equals(this.ColumnInfo.PrChausseeColumnName) && c.ControlType == ControlType.None select c).FirstOrDefault();
                        Int64 valueIdChaussee = (Int64)columnChausseeIdInfo.Property.GetValue(entityObject);
                        Nullable<Int64> valueAbs = (Nullable<Int64>)value;
                        String pr = reperageService.AbsToPr(valueIdChaussee, valueAbs);
                        return pr;
                       
                    }
                    else
                    { 
                        /* @TODO Gestion de l'affichage PR des colonnes de parent
                        IReperageService reperageService = ServiceLocator.Current.GetInstance<IReperageService>();
                        EntityColumnInfo columnChausseeIdInfo = (from c in this.ColumnInfo.TableInfo.ColumnInfos where c.ColumnName.Equals(columnInfo.PrChausseeColumnName) && c.ControlType == ControlType.None select c).FirstOrDefault();
                        Int64 valueIdChaussee = (Int64)columnChausseeIdInfo.Property.GetValue(this.Model);
                        Nullable<Int64> valueAbs = (Nullable<Int64>)value;
                        String pr = reperageService.AbsToPr(valueIdChaussee, valueAbs);
                         * */
                       
                    }
                 
                }
                else
                {
                    Object value = this.ColumnInfo.Property.GetValue(entityObject);
                    return Formatter.FormatValue(this.ColumnInfo.PropertyType, value);
                }
                
            }
            else
            {
                String[] items = this.Path.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Object value = entityObject;
                foreach (String item in items)
                {
                    PropertyInfo property = value.GetType().GetProperty(item);
                    value = property.GetValue(value);
                }
                return Formatter.FormatValue(this.ColumnInfo.PropertyType, value);
            }
            return null;

        }

        public bool ValidateString(string valueString, out string message, out object result)
        {
            List<String> errors = new List<string>();
            Object subResult = null;
            foreach (EntityFieldValidationRule validationRule in this.ValidationRules)
            {
                if (!validationRule.ValidateString(this, valueString, out  message, out subResult))
                { errors.Add(message); break; }
            }
            if (errors.Count > 0)
            {
                message = String.Join ("\r\n",errors);
                result = null;
                return false;
            }
            else
            {
                message = null;
                result = subResult;
                return true ;
            }
                
           
        }

        internal void CreateValidationRules()
        {
            // champ de la table
            if (this.ParentColumnInfo == null)
            {
                if (!this.ColumnInfo.AllowNull)
                {this.ValidationRules.Add(new EntityFieldValidationRuleNotEmpty());}
                this.ValidationRules.Add(new EntityFieldValidationRuleDataType());
                this.ValidationRules.Add(new EntityFieldValidationRuleControlType());
            }
            else
            {
                // champ d'une autre table mais lié
                if (this.ColumnInfo != null)
                {
                    if (!this.ColumnInfo.AllowNull)
                    {this.ValidationRules.Add(new EntityFieldValidationRuleNotEmpty());}
                    this.ValidationRules.Add(new EntityFieldValidationRuleDataType());
                }
               
            }
        }
    }
}
