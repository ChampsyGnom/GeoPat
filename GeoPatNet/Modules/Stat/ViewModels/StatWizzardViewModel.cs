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
            List<Symbology> symbologies = Symbology.CreateSymbologies(_selectedStatField.Field, _selectedStatType.StatType, null);
            foreach (Symbology symbology in symbologies)
            { this.Symbologies.Add(symbology); }
            
            
                     
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
            if (this._selectedStatType != null && _selectedStatType.StatType == StatType.Count)
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
            vmStateTypeCount.StatType = StatType.Count;
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
