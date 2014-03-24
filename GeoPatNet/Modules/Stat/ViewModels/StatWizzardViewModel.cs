using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Utils;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Windows;
using Emash.GeoPatNet.Infrastructure.Symbol;
using System.Windows.Media;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Modules.Stat.ViewModels
{
    public enum StateType
    {
        Count,
        None
    }
    public  class StatWizzardViewModel : INotifyPropertyChanged
    {
        //

        public Visibility VisibilityAera
        {
            get
            {
                if (_selectedDisplayType == StatDisplayType.Aera) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }

        public Visibility VisibilityLine
        {
            get
            {
                if (_selectedDisplayType == StatDisplayType.Line) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }


        public Visibility VisibilityBar
        {
            get
            {
                if (_selectedDisplayType == StatDisplayType.Bar) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }

        public Visibility VisibilityColumn
        {
            get
            {
                if (_selectedDisplayType == StatDisplayType.Column) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }

        public Visibility VisibilityPie
        {
            get {
                if (_selectedDisplayType == StatDisplayType.Pie) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }
        private StatDisplayType _selectedDisplayType;


        public StatDisplayType SelectedDisplayType
        {
            get { return _selectedDisplayType; }
            set 
            { 
                _selectedDisplayType = value; 
                this.RaisePropertyChanged("SelectedDisplayType");
                this.RaisePropertyChanged("VisibilityPie");
                this.RaisePropertyChanged("VisibilityColumn");
                this.RaisePropertyChanged("VisibilityLine");
                this.RaisePropertyChanged("VisibilityBar");
                this.RaisePropertyChanged("VisibilityAera"); 
            }
        }
        public List<StatDisplayType> DisplayTypes { get; private set; }
            
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
        public ObservableCollection<StatValueViewModel> StatValues { get; private set; }
        private System.Windows.Visibility _stepConfigurationVisiblity;
        private System.Windows.Visibility _stepPreviewVisiblity;
        private StatFieldViewModel _selectedStatField;
        public ObservableCollection<Symbology> Symbologies { get; private set; }

        public StatFieldViewModel SelectedStatField
        {
            get { return _selectedStatField; }
            set 
            {
                _selectedStatField = value;
                this.RaisePropertyChanged("SelectedStatField");
                this.CreateSymbology();
                this.CreateStatValues();
              
            }
        }

        private void CreateSymbology()
        {
            this.StatValues.Clear();
            this.Symbologies.Clear();
            Symbology symobology;
            SymbologyRuleEquals rule;
            Symbolizer symbolizer;
            if (_selectedStatType != null && _selectedStatField != null)
            {
                IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                if (_selectedStatType.StateType == StateType.Count)
                {
                    if (_selectedStatField.Field.ControlType == ControlType.Check )
                    {
                      
                        if (_selectedStatField.Field.ColumnInfo.AllowNull)
                        {
                            symobology = new Symbology();

                            rule = new SymbologyRuleEquals();
                            rule.Field = _selectedStatField.Field;
                            rule.Value = null;
                            symobology.DisplayName = "Non renseigné";
                            symobology.Rule = rule;
                            symbolizer = new Symbolizer();
                            symobology.Symbolizer = symbolizer;
                            symobology.Symbolizer.BaseColor = Colors.Gray;
                            this.Symbologies.Add(symobology);
                        }

                        symobology = new Symbology();
                        rule = new SymbologyRuleEquals();
                        rule.Field = _selectedStatField.Field;
                        rule.Value = true;
                        symobology.DisplayName = "Oui";
                        symobology.Rule = rule;
                        symbolizer = new Symbolizer();
                        symobology.Symbolizer = symbolizer;
                        symobology.Symbolizer.BaseColor = Colors.Green ;
                        this.Symbologies.Add(symobology);


                        symobology = new Symbology();
                        rule = new SymbologyRuleEquals();
                        rule.Field = _selectedStatField.Field;
                        rule.Value = false;
                        symobology.DisplayName = "Non";
                        symobology.Rule = rule;
                        symbolizer = new Symbolizer();
                        symobology.Symbolizer = symbolizer;
                        symobology.Symbolizer.BaseColor = Colors.Red;
                        this.Symbologies.Add(symobology);



                    }
                    else if (_selectedStatField.Field.ControlType == ControlType.Date)
                    {
                        if (_selectedStatField.Part == StatFieldPart.Year)
                        {
                            if (_selectedStatField.Field.ColumnInfo.AllowNull)
                            {
                                symobology = new Symbology();
                                rule = new SymbologyRuleEquals();
                                rule.Field = _selectedStatField.Field;
                                rule.Value = null;
                                symobology.DisplayName = "Non renseigné";
                                symobology.Rule = rule;
                                symbolizer = new Symbolizer();
                                symobology.Symbolizer = symbolizer;
                                symobology.Symbolizer.BaseColor = Colors.Gray;
                                this.Symbologies.Add(symobology);
                            }
                            List<DateTime> dates = new List<DateTime>();
                            DbSet dbSet = dataService.GetDbSet(_selectedStatField.Field.ColumnInfo.TableInfo.EntityType);
                            IQueryable queryable = dbSet.AsQueryable();
                            System.Reflection.PropertyInfo propertyDate = _selectedStatField.Field.ColumnInfo.TableInfo.EntityType.GetProperty (_selectedStatField.Field.Path);
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
                                    symobology.DisplayName = year.ToString ();
                                    symobology.Rule = rule;
                                    symbolizer = new Symbolizer();
                                    symobology.Symbolizer = symbolizer;
                                    symobology.Symbolizer.BaseColor = Colors.Gray;
                                    this.Symbologies.Add(symobology);
                                }
                            }
                            //System.Linq.Expressions.ParameterExpression expressionBase = System.Linq.Expressions.Expression.Parameter(_selectedStatField.Field.ColumnInfo.TableInfo.EntityType, "item");
                            //MemberExpression exp = System.Linq.Expressions.Expression.Property(expressionBase, _selectedStatField.Field.Path);

           
                           
                        }
                    }
                    else if (_selectedStatField.Field.ControlType == ControlType.Combo)
                    {
                        List<Object> distinctValues = new List<object>();
                        DbSet dbSet = dataService.GetDbSet(_selectedStatField.Field.ParentColumnInfo.TableInfo.EntityType);
                        IQueryable queryable = dbSet.AsQueryable();
                        foreach (Object o in queryable)
                        {
                            distinctValues.Add(_selectedStatField.Field.ParentColumnInfo.Property.GetValue(o));
                        }
                        distinctValues = (from o in distinctValues orderby o select o).Distinct().ToList();
                        if (distinctValues.Count > 200)
                        {
                            MessageBox.Show(distinctValues.Count + " valeurs différentes pour ce champ, au dessus de 200 valeurs les statistiques sont illisible", "Trop de valeurs", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            if (_selectedStatField.Field.ColumnInfo.AllowNull)
                            {
                                symobology = new Symbology();

                                rule = new SymbologyRuleEquals();
                                rule.Field = _selectedStatField.Field;
                                rule.Value = null;
                                symobology.DisplayName = "Non renseigné";
                                symobology.Rule = rule;
                                symbolizer = new Symbolizer();
                                symobology.Symbolizer = symbolizer;
                                symobology.Symbolizer.BaseColor = Colors.Gray;
                                this.Symbologies.Add(symobology);
                            }
                            double hueStep = 360D / distinctValues.Count;
                            double hue = 0D;
                            foreach (Object obj in distinctValues)
                            {
                                Color color = Colors.AliceBlue.FromHsv(hue, 0.8, 0.8);
                                symobology = new Symbology();

                                rule = new SymbologyRuleEquals();
                                rule.Field = _selectedStatField.Field;
                                rule.Value = obj;
                                symobology.DisplayName = obj.ToString();
                                symobology.Rule = rule;
                                symbolizer = new Symbolizer();
                                symobology.Symbolizer = symbolizer;
                                symobology.Symbolizer.BaseColor = color;
                                this.Symbologies.Add(symobology);
                                hue += hueStep;

                            }

                        }

                    }
                   
                  

                }
                    
            }
                     
        }

        private void CreateStatValues()
        {
            this.StatValues.Clear();
            if (this._selectedStatField != null)
            {
                double total = 0;
                foreach (Symbology symbology in this.Symbologies)
                {
                    StatValueViewModel valueVm = new StatValueViewModel();
                    valueVm.Symbology = symbology;
                    this.StatValues.Add(valueVm);
                    valueVm.Compute();
                    total += valueVm.DependentValue;
                }
                foreach (StatValueViewModel valueVm in this.StatValues)
                {
                    valueVm.ComputePercent(total);
                }
            }
        }
        private StatTypeViewModel _selectedStatType;


        public StatTypeViewModel SelectedStatType
        {
            get { return _selectedStatType; }
            set { _selectedStatType = value; this.RaisePropertyChanged("SelectedStatType"); this.UpdateStatFields(); }
        }

        private void UpdateStatFields()
        {
            this.StatFields.Clear();
            if (this._selectedStatType != null && _selectedStatType.StateType == StateType.Count)
            {
                foreach (StatFieldViewModel statField in AllFields)
                {   
                        this.StatFields.Add(statField);
                    
                }
            }
        }
        public ObservableCollection<StatTypeViewModel> StatTypes  { get; private set; }
        public List<StatFieldViewModel> AllFields { get; private set; }
        public ObservableCollection<StatFieldViewModel> StatFields { get; private set; }
        public System.Windows.Visibility StepPreviewVisiblity
        {
            get { return _stepPreviewVisiblity; }
            set { _stepPreviewVisiblity = value; this.RaisePropertyChanged("StepPreviewVisiblity"); }
        }

        public System.Windows.Visibility StepConfigurationVisiblity
        {
            get { return _stepConfigurationVisiblity; }
            set { _stepConfigurationVisiblity = value; this.RaisePropertyChanged("StepConfigurationVisiblity"); }
        }
        public EntityTableInfo EntityTableInfo { get; private set; }

        public StatWizzardViewModel(EntityTableInfo entityTableInfo, List<String> fieldPaths)
        {
            this.DisplayTypes = new List<StatDisplayType>();
            this.DisplayTypes.Add(StatDisplayType.Column);
            this.DisplayTypes.Add(StatDisplayType.Pie);
            this.DisplayTypes.Add(StatDisplayType.Line);
            this.DisplayTypes.Add(StatDisplayType.Bar);
            this.DisplayTypes.Add(StatDisplayType.Aera);
           
            this.StatValues = new ObservableCollection<StatValueViewModel>();
            this.EntityTableInfo = entityTableInfo;
            this.AllFields = new List<StatFieldViewModel>();
            this.StepConfigurationVisiblity = System.Windows.Visibility.Visible;
            this.StepPreviewVisiblity = System.Windows.Visibility.Hidden;
            this.StatTypes = new ObservableCollection<StatTypeViewModel>();
            StatTypeViewModel vmStateTypeCount = new StatTypeViewModel();
            vmStateTypeCount.DisplayName = "Nombre de " + entityTableInfo.DisplayName;
            vmStateTypeCount.StateType = StateType.Count;
            this.StatTypes.Add(vmStateTypeCount);
            this.StatFields = new ObservableCollection<StatFieldViewModel>();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();

            foreach (EntityFieldInfo field in entityTableInfo.FieldInfos)
            {
                if (field.ParentColumnInfo == null)
                {
                    if (field.ColumnInfo.ControlType == ControlType.Check)
                    {
                        StatFieldViewModel statField = new StatFieldViewModel();
                        statField.Field = field;
                        this.AllFields.Add(statField);
                    }
                    else if (field.ColumnInfo.ControlType == ControlType.Date)
                    {
                        StatFieldViewModel statField = new StatFieldViewModel();
                        statField.Part = StatFieldPart.Year;
                        statField.Field = field;
                        this.AllFields.Add(statField);
                    }
                    else if (field.ColumnInfo.ControlType == ControlType.Decimal)
                    {
                        StatFieldViewModel statField = new StatFieldViewModel();
                        statField.Field = field;
                        this.AllFields.Add(statField);
                    }
                    else if (field.ColumnInfo.ControlType == ControlType.Integer)
                    {
                        StatFieldViewModel statField = new StatFieldViewModel();
                        statField.Field = field;
                        this.AllFields.Add(statField);
                    }

                }
                else
                {
                    if (field.ColumnInfo != null && field.ColumnInfo.ControlType == ControlType.Combo)
                    {
                        StatFieldViewModel statField = new StatFieldViewModel();
                        statField.Field = field;
                        this.AllFields.Add(statField);
                    }
                    else {
                        
                    }
                }
            }
            this.Symbologies = new System.Collections.ObjectModel.ObservableCollection<Symbology>();
           

            
        }
    }
}
