using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using System.Collections .ObjectModel;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using Emash.GeoPatNet.Infrastructure.Services;
using System.Data.Entity;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Symbology;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoViewModel
    {
        public String DisplayName 
        { 
            get 
            {return "Cartographie";} 
        }
        public DelegateCommand CreateTemplateCommand { get;private  set; }
        private ObservableCollection<TemplateViewModel> Templates { get; set; }
        public ListCollectionView TemplatesView { get; private set; }
        public DotSpatial.Controls.Map Map { get; set; }     
        public IDataService DataService { get; private set; }
        public IEngineService EngineService { get; private set; }
        public ICartoService CartoService { get; private set; }
        public CartoViewModel(IDataService dataService, IEngineService engineService, ICartoService cartoService)
        {
            this.CartoService = cartoService;
            this.DataService = dataService;
            this.EngineService = engineService;
            this.Templates = new ObservableCollection<TemplateViewModel>();
            this.TemplatesView = new ListCollectionView(this.Templates);
            this.TemplatesView.CurrentChanged += TemplatesView_CurrentChanged;
            this.CreateTemplateCommand = new DelegateCommand(CreateTemplateExecute);
            this.LoadTemplates();

        }

        private void LoadTemplates()
        {
            DbSet<SigTemplate> templateSet = this.DataService.GetDbSet<SigTemplate>();
            foreach (SigTemplate templateItem in templateSet)
            {
                TemplateViewModel vm = new TemplateViewModel(templateItem);
                this.Templates.Add(vm);
            }
        }

        private void CreateTemplateExecute()
        {
            DbSet<SigTemplate> templateSet = this.DataService.GetDbSet<SigTemplate>();
            SigTemplate template = this.EngineService.ShowAddDialog<SigTemplate>();
            if (template != null)
            {                      
                TemplateViewModel vm = new TemplateViewModel(template);
                this.Templates.Add(vm);
                this.TemplatesView.MoveCurrentTo(vm);
            }
        }

        void TemplatesView_CurrentChanged(object sender, EventArgs e)
        {
            this.ClearLayers();
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel template = (this.TemplatesView.CurrentItem as TemplateViewModel);
                this.AddTemplateLayers(template);
            }
        }

        private void AddTemplateLayers(TemplateViewModel template)
        {
            MapLineLayer layer = new MapLineLayer(this.CartoService.CreateReferentielFeatureSet());
            this.Map.Layers.Add(layer);
         
            
           
        }

        private void ClearLayers()
        {

            this.Map.Layers.Clear();
        }


       
    }
}
