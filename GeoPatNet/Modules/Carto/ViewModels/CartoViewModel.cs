using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Services;
using System.Data.Entity;
using Emash.GeoPatNet.Data.Models;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Data;
using System.Windows.Threading;
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
        public DelegateCommand<Object> AddLayerCommand { get; private set; }
        public DelegateCommand  DeleteTemplateCommand  { get; private set; }
        public IDataService DataService { get; private set; }
        public IEngineService EngineService { get; private set; }
        public Dispatcher Dispatcher { get; private set; }
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
            this.CreateTemplateCommand = new DelegateCommand(CreateTemplateExecute);
            this.EditTemplateCommand = new DelegateCommand(EditTemplateExecute,CanEditTemplate );
            this.DeleteTemplateCommand = new DelegateCommand(DeleteTemplateExecute, CanDeleteTemplate);
            this.PublishTemplateCommand = new DelegateCommand(PublishTemplateExecute, CanPublishTemplate);
            this.AddFolderCommand = new DelegateCommand<object>(AddFolderExecute);
            this.AddLayerCommand = new DelegateCommand<object>(AddLayerExecute);
           
            this.TemplatesView.CurrentChanged += TemplatesView_CurrentChanged;
        }
        public void AddLayerExecute(Object parent)
        { 

        }

        public void AddFolderExecute(Object parent)
        {
            TemplateViewModel tpl = this.TemplatesView.CurrentItem as TemplateViewModel;
            DbSet<SigCodeNode> codeNodes = this.DataService.GetDbSet<SigCodeNode>();
            SigNode node = new SigNode();
            if (parent == null)
            {node.ParentId = null;}
            node.Libelle = "Nouveau dossier";
            node.SigCodeNode = (from c in codeNodes where c.Code.Equals("Folder") select c).FirstOrDefault();
            node.SigLayer = null;
            node.SigTemplateId = tpl.Model.Id;
            SigNode addedNode =  this.EngineService.ShowAddDialog<SigNode>(node,new String[] {"Libelle"});
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
