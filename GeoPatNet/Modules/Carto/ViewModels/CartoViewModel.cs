using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;

using Emash.GeoPatNet.Data.Models;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Data;
using System.Windows.Threading;
using System.Data.Entity;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoViewModel
    {

        public ListCollectionView TemplatesView { get; private set; }
        public ObservableCollection<TemplateViewModel> Templates { get; private set; }
        public DelegateCommand CreateTemplateCommand { get; private set; }
        public DelegateCommand EditTemplateCommand { get; private set; }
        public DelegateCommand PublishTemplateCommand { get; private set; }
        public DelegateCommand<Object> AddFolderCommand { get; private set; }
        public DelegateCommand<Object> RemoveFolderCommand { get; private set; }
        public DelegateCommand<Object> RemoveLayerCommand { get; private set; }
        public DelegateCommand<Object> AddLayerGoogleCommand { get; private set; }
        public DelegateCommand  DeleteTemplateCommand  { get; private set; }
        public IDataService DataService { get; private set; }
        public IEngineService EngineService { get; private set; }
        public Dispatcher Dispatcher { get; private set; }
        public ObservableCollection<MapLayerViewModel> Layers { get; private set; }
        public CartoViewModel(IDataService dataService,IEngineService engineService)
        {
            this.DataService = dataService;
            this.Dispatcher = System.Windows.Application.Current.Dispatcher;
            this.EngineService = engineService;
            this.Templates = new ObservableCollection<TemplateViewModel>();
            this.TemplatesView = new ListCollectionView(this.Templates);
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
            foreach (SigTemplate tpl in set)
            {
                TemplateViewModel vm = new TemplateViewModel(tpl);
                this.Templates.Add(vm);
                    
            }
            foreach (TemplateViewModel vm in this.Templates)
            {
                DbSet<SigNode> setNodes = this.DataService.GetDbSet<SigNode>();
                List<SigNode> templateNodes = (from n in setNodes where n.SigTemplateId == vm.Model.Id select n).ToList();
                this.RecurseBuildTemplateNodes(-1, vm.Nodes, templateNodes);
            }
            this.CreateTemplateCommand = new DelegateCommand(CreateTemplateExecute);
            this.EditTemplateCommand = new DelegateCommand(EditTemplateExecute,CanEditTemplate );
            this.DeleteTemplateCommand = new DelegateCommand(DeleteTemplateExecute, CanDeleteTemplate);
            this.PublishTemplateCommand = new DelegateCommand(PublishTemplateExecute, CanPublishTemplate);
            this.AddFolderCommand = new DelegateCommand<object>(AddFolderExecute);
            this.AddLayerGoogleCommand = new DelegateCommand<object>(AddLayerGoogleExecute);
            this.Layers = new ObservableCollection<MapLayerViewModel>();
           
            this.TemplatesView.CurrentChanged += TemplatesView_CurrentChanged;
        }

        private void RecurseBuildTemplateNodes(long parentId, ObservableCollection<CartoNodeViewModel> parent, List<SigNode> allNodes)
        {
            List<SigNode> nodes = (from n in allNodes where n.ParentId == parentId orderby n.Order select n).ToList();
            foreach (SigNode node in nodes)
            {
                if (node.SigCodeNode.Code.Equals("Folder"))
                {
                    CartoNodeFolderViewModel vm = new CartoNodeFolderViewModel(node);    
                    parent.Add(vm);
                    this.RecurseBuildTemplateNodes(node.Id, vm.Nodes, allNodes);

                }
                if (node.SigCodeNode.Code.Equals("Layer"))
                {
                    CartoNodeLayerViewModel vm = new CartoNodeLayerViewModel(node);
                    parent.Add(vm);
                }

            }
        }
        public void AddLayerGoogleExecute(Object parent)
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            DbSet<SigCodeLayer> codeLayers = this.DataService.GetDbSet<SigCodeLayer>();

            DbSet<SigLayer> layers = this.DataService.GetDbSet<SigLayer>();
           

            SigNode node = new SigNode();
            if (parent != null && parent is CartoNodeFolderViewModel)
            { node.ParentId = (parent as CartoNodeFolderViewModel).Model.Id; }
            else { node.ParentId = -1; }
            node.Libelle = "Google Map";
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Layer") select c).FirstOrDefault();
            node.SigLayer = null;
            node.SigTemplateId = tpl.Model.Id;
            SigNode addedNode = this.EngineService.ShowAddDialog<SigNode>(node, new String[] { "Libelle" });
            if (addedNode != null)
            {
                SigLayer layer = new SigLayer();
                layer.Libelle = "Google Map";
                layer.MapOrder = 0;
                layer.SigCodeLayer = (from c in codeLayers where c.Code.Equals("Google") select c).FirstOrDefault();
                layers.Add(layer);
                this.DataService.DataContext.SaveChanges();
                node.SigLayer = layer;
                this.DataService.DataContext.SaveChanges();
                CartoNodeLayerViewModel vm = new CartoNodeLayerViewModel(addedNode);
                if (parent != null && parent is CartoNodeFolderViewModel)
                {
                    (parent as CartoNodeFolderViewModel).Nodes.Add(vm);
                    (parent as CartoNodeFolderViewModel).IsExpanded = true;
                }
                else
                {
                    (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes.Add(vm);
                }
            }
        }

        public void AddFolderExecute(Object parent)
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            SigNode node = new SigNode();
            if (parent != null && parent is CartoNodeFolderViewModel)
            { node.ParentId = (parent as CartoNodeFolderViewModel).Model.Id; }
            else { node.ParentId = -1; }
            node.Libelle = "Nouveau dossier";
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Folder") select c).FirstOrDefault();
            node.SigLayer = null;
            node.SigTemplateId = tpl.Model.Id;
            SigNode addedNode =  this.EngineService.ShowAddDialog<SigNode>(node,new String[] {"Libelle"});
            if (addedNode != null)
            {
                CartoNodeFolderViewModel vm = new CartoNodeFolderViewModel(addedNode);
                if (parent != null && parent is CartoNodeFolderViewModel)
                {
                    (parent as CartoNodeFolderViewModel).Nodes.Add(vm);
                    (parent as CartoNodeFolderViewModel).IsExpanded = true;
                }
                else
                { 
                    (this.TemplatesView.CurrentItem as TemplateViewModel).Nodes.Add(vm);                   
                }
            }
           
        }

        private void PublishTemplateExecute()
        {

        }

        private Boolean CanPublishTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }


        private void DeleteTemplateExecute()
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
            set.Remove(tpl.Model);
            this.DataService.DataContext.SaveChanges();
            this.Templates.Remove(tpl);
        }

        private Boolean CanDeleteTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }

        void TemplatesView_CurrentChanged(object sender, EventArgs e)
        {
            this.EditTemplateCommand.RaiseCanExecuteChanged();
            this.DeleteTemplateCommand.RaiseCanExecuteChanged();
            this.PublishTemplateCommand.RaiseCanExecuteChanged();
            this.LoadMap();
        }

        private void LoadMap()
        {
           
            this.Layers.Clear();
            List<CartoNodeLayerViewModel> layers = new List<CartoNodeLayerViewModel>();
            if (this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel)
            {
                TemplateViewModel templateViewModel = (this.TemplatesView.CurrentItem as TemplateViewModel);
                RecurseGetLayers(layers, templateViewModel.Nodes);
                layers = (from l in layers orderby l.Model.SigLayer.MapOrder select l).ToList();
                foreach (CartoNodeLayerViewModel layer in layers)
                {
                    MapLayerViewModel vm = new MapLayerViewModel(layer);
                    this.Layers.Add(vm);
                }
            }
           //
            /*
           
          
           */
        }

        private void RecurseGetLayers(List<CartoNodeLayerViewModel> layers, ObservableCollection<CartoNodeViewModel> list)
        {
            foreach (CartoNodeViewModel n in list)
            {
                if (n is CartoNodeFolderViewModel)
                {
                    RecurseGetLayers(layers, (n as CartoNodeFolderViewModel).Nodes);
                }
                if (n is CartoNodeLayerViewModel)
                {
                    layers.Add((n as CartoNodeLayerViewModel));
                }
            }
        }

        private Boolean CanEditTemplate()
        {
            return this.TemplatesView.CurrentItem != null && this.TemplatesView.CurrentItem is TemplateViewModel;
        }
        private void EditTemplateExecute()
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            SigTemplate template = this.EngineService.ShowEditDialog<SigTemplate>(tpl.Model);
            if (template != null)
            {
               
                tpl.SetModel(template);
               
               
            }
            else 
            {
                Console.WriteLine("pas oki");
            }
        }
        private void CreateTemplateExecute()
        {
            SigTemplate template = this.EngineService.ShowAddDialog<SigTemplate>();
            if (template != null)
            {
                    TemplateViewModel vm = new TemplateViewModel(template);
                    this.Templates.Add(vm);
                    this.TemplatesView.MoveCurrentTo(vm);
               
              
            }
            else
            {
                Console.WriteLine("pas oki");
            }
            /*
            DbSet<SigTemplate> set = this.DataService.GetDbSet<SigTemplate>();
             DbSet<SigCodeTemplate> setCode = this.DataService.GetDbSet<SigCodeTemplate>();
            SigTemplate template = new SigTemplate();
            template.Libelle = "Nouveau modèle";
            template.SigCodeTemplate = (from i in setCode where i.Code.Equals ("Detail") select i).FirstOrDefault();
            set.Add(template);
            this.DataService.DataContext.SaveChanges();
            TemplateViewModel vm = new TemplateViewModel(template);
            this.Templates.Add(vm);
            this.TemplatesView.MoveCurrentTo(vm);
             * */
        }

        public String DisplayName 
        {
            
            get
            {
                return "Carte";
            }
            
        }
    }
}
