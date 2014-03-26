using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Infrastructure.Symbol
{
    public class Symbology : INotifyPropertyChanged
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
        public SymbologyRule Rule { get; set; }
        public Symbolizer Symbolizer { get; set; }
        private String _displayName;

        public String DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; this.RaisePropertyChanged("DisplayName"); }
        }

        public static List<Symbology> CreateSymbologies(EntityFieldInfo fieldInfo, StatType statType,Nullable<StatFieldPart> fieldPart)
        {
            List<Symbology> symbologies = new List<Symbology>();
            Symbology symobology = null;
            SymbologyRuleEquals rule = null;
            Symbolizer symbolizer = null;
            if (statType == StatType.Count)
            {
                if (fieldInfo.ControlType == ControlType.Check)
                {

                    if (fieldInfo.ColumnInfo.AllowNull)
                    {
                        symobology = new Symbology();

                        rule = new SymbologyRuleEquals();
                        rule.Field = fieldInfo;
                        rule.Value = null;
                        symobology.DisplayName = "Non renseigné";
                        symobology.Rule = rule;
                        symbolizer = new Symbolizer();
                        symobology.Symbolizer = symbolizer;
                        symobology.Symbolizer.BaseColor = Colors.Gray;
                        symbologies.Add(symobology);
                    }

                    symobology = new Symbology();
                    rule = new SymbologyRuleEquals();
                    rule.Field = fieldInfo;
                    rule.Value = true;
                    symobology.DisplayName = "Oui";
                    symobology.Rule = rule;
                    symbolizer = new Symbolizer();
                    symobology.Symbolizer = symbolizer;
                    symobology.Symbolizer.BaseColor = Colors.Green;
                    symbologies.Add(symobology);


                    symobology = new Symbology();
                    rule = new SymbologyRuleEquals();
                    rule.Field = fieldInfo;
                    rule.Value = false;
                    symobology.DisplayName = "Non";
                    symobology.Rule = rule;
                    symbolizer = new Symbolizer();
                    symobology.Symbolizer = symbolizer;
                    symobology.Symbolizer.BaseColor = Colors.Red;
                    symbologies.Add(symobology);



                }
                else if (fieldInfo.ControlType == ControlType.Date)
                {
                    if (fieldPart == StatFieldPart.Year)
                    {
                        if (fieldInfo.ColumnInfo.AllowNull)
                        {
                            symobology = new Symbology();
                            rule = new SymbologyRuleEquals();
                            rule.Field = fieldInfo;
                            rule.Value = null;
                            symobology.DisplayName = "Non renseigné";
                            symobology.Rule = rule;
                            symbolizer = new Symbolizer();
                            symobology.Symbolizer = symbolizer;
                            symobology.Symbolizer.BaseColor = Colors.Gray;
                            symbologies.Add(symobology);
                        }
                        /*
                        List<DateTime> dates = new List<DateTime>();
                        DbSet dbSet = dataService.GetDbSet(_selectedStatField.Field.ColumnInfo.TableInfo.EntityType);
                        IQueryable queryable = dbSet.AsQueryable();
                        System.Reflection.PropertyInfo propertyDate = _selectedStatField.Field.ColumnInfo.TableInfo.EntityType.GetProperty(_selectedStatField.Field.Path);
                        foreach (Object obj in queryable)
                        {
                            Object objDate = propertyDate.GetValue(obj);
                            if (objDate != null && objDate is DateTime)
                            {
                                DateTime date = (DateTime)objDate;
                                dates.Add(date);
                            }

                        }
                        if (dates.Count > 0)
                        {
                            int minYear = (from d in dates select d.Year).Min();
                            int maxYear = (from d in dates select d.Year).Min();
                            for (int year = minYear; year <= maxYear; year++)
                            {
                                symobology = new Symbology();
                                rule = new SymbologyRuleEquals();
                                rule.Field = _selectedStatField.Field;
                                rule.Value = year;
                                symobology.DisplayName = year.ToString();
                                symobology.Rule = rule;
                                symbolizer = new Symbolizer();
                                symobology.Symbolizer = symbolizer;
                                symobology.Symbolizer.BaseColor = Colors.Gray;
                                this.Symbologies.Add(symobology);
                            }
                        }
                         * */
                        //System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(_selectedStatField.Field.ColumnInfo.TableInfo.EntityType, "item");
                        //MemberExpression exp = System.Linq.Expressions.Expression.Property(expressionBase, _selectedStatField.Field.Path);



                    }
                }
                else if (fieldInfo.ControlType == ControlType.Combo)
                {
                    List<Object> distinctValues = new List<object>();
                    IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                    DbSet dbSet = dataService.GetDbSet(fieldInfo.ParentColumnInfo.TableInfo.EntityType);
                    IQueryable queryable = dbSet.AsQueryable();
                    foreach (Object o in queryable)
                    {
                        distinctValues.Add(fieldInfo.ParentColumnInfo.Property.GetValue(o));
                    }
                    distinctValues = (from o in distinctValues orderby o select o).Distinct().ToList();
                    if (distinctValues.Count > 200)
                    {
                       
                    }
                    else
                    {
                        if (fieldInfo.ColumnInfo.AllowNull)
                        {
                            symobology = new Symbology();

                            rule = new SymbologyRuleEquals();
                            rule.Field = fieldInfo;
                            rule.Value = null;
                            symobology.DisplayName = "Non renseigné";
                            symobology.Rule = rule;
                            symbolizer = new Symbolizer();
                            symobology.Symbolizer = symbolizer;
                            symobology.Symbolizer.BaseColor = Colors.Gray;
                            symbologies.Add(symobology);
                        }
                        double hueStep = 360D / distinctValues.Count;
                        double hue = 0D;
                        foreach (Object obj in distinctValues)
                        {
                            Color color = Colors.AliceBlue.FromHsv(hue, 0.8, 0.8);
                            symobology = new Symbology();

                            rule = new SymbologyRuleEquals();
                            rule.Field = fieldInfo;
                            rule.Value = obj;
                            symobology.DisplayName = obj.ToString();
                            symobology.Rule = rule;
                            symbolizer = new Symbolizer();
                            symobology.Symbolizer = symbolizer;
                            symobology.Symbolizer.BaseColor = color;
                            symbologies.Add(symobology);
                            hue += hueStep;

                        }

                    }

                }



            }
            return symbologies;
        }
    }
}
