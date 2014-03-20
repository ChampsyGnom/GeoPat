using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Infrastructure.Behaviors;
using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Microsoft.Practices.Prism.Commands;
using Emash.GeoPatNet.Presentation.Views;
namespace Emash.GeoPatNet.Engine.Builders
{
    /// <summary>
    /// Constructeur de menu contextuel des tableau généric
    /// Comme i l y as trop long de code on l'isole
    /// @TODO Afficher les tables parent , c'est tout prévu faut juste revoie lre code pour les field a la place colonnes
    /// </summary>
    public  class GenericDataGridContextMenuBuilder
    {
        public static void CreateContextMenu<M>(DataGridContextMenuOpeningBehaviorEventArg arg, GenericListViewModel<M> genericListViewModel)
            where M : class, new()
         
        {
            // Ne marche que si l'on est en mode on consulte des donnée
            if (genericListViewModel.State != GenericDataListState.Display)
            {
                arg.ContextMenuEventArgs.Handled = true;
                return;
            }
            // On récupérer la position , la cellule , la colonne , la valeur pour avoir un vrai menu contextuel
            Point pos = Mouse.GetPosition(arg.DataGrid);
            IInputElement hit = arg.DataGrid.InputHitTest(pos);
            DependencyObject hitDependencyObject = hit as DependencyObject;
            DataGridCell cell = hitDependencyObject.FindParentControl<DataGridCell>();
            GenericDataGridTemplateColumn genericDataGridTemplateColumn = cell.Column as GenericDataGridTemplateColumn;
            // Si on trouve qualque chose on cré les menus , Filtrer , Trier , Afficher , ...
            if (hitDependencyObject != null)
            {
                arg.ContextMenu.Items.Clear();
                MenuItem menuFilter = new MenuItem();
                menuFilter.Header = "Filtrer";
                arg.ContextMenu.Items.Add(menuFilter);
                if (cell.DataContext is GenericListItemViewModel<M>)
                {
                    GenericListItemViewModel<M> vm = (cell.DataContext as GenericListItemViewModel<M>);
                    Type propertyType = null;
                    if (genericDataGridTemplateColumn.FieldInfo.ParentColumnInfo != null)
                    {
                        propertyType = genericDataGridTemplateColumn.FieldInfo.ParentColumnInfo.PropertyType;
                    }
                    else
                    {
                        propertyType = genericDataGridTemplateColumn.FieldInfo.ColumnInfo.PropertyType;
                    }
                    String valueString = vm.Values[genericDataGridTemplateColumn.FieldInfo.Path];

                    if (propertyType.Equals(typeof(String)))
                    {

                        MenuItem menuEquals = new MenuItem();
                        menuEquals.Header = genericDataGridTemplateColumn.FieldInfo.DisplayName  + " égale à " + valueString;
                        menuEquals.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SearchItem.Values[genericDataGridTemplateColumn.FieldInfo.Path] = valueString;
                            genericListViewModel.SearchExecute();
                        }));
                        menuFilter.Items.Add(menuEquals);


                        MenuItem menuNotEquals = new MenuItem();
                        menuNotEquals.Header = genericDataGridTemplateColumn.FieldInfo.DisplayName + " différent de " + valueString;
                        menuNotEquals.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SearchItem.Values[genericDataGridTemplateColumn.FieldInfo.Path] = "<>" + valueString;
                            genericListViewModel.SearchExecute();
                        }));
                        menuFilter.Items.Add(menuNotEquals);
                    }


                    if (genericDataGridTemplateColumn.FieldInfo.ColumnInfo.AllowNull)
                    {
                        menuFilter.Items.Add(new Separator());
                        MenuItem menuNotNull = new MenuItem();
                        menuNotNull.Header = genericDataGridTemplateColumn.FieldInfo.DisplayName + " est renseigné";
                        menuNotNull.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SearchItem.Values[genericDataGridTemplateColumn.FieldInfo.Path] = "+";
                            genericListViewModel.SearchExecute();
                        }));
                        menuFilter.Items.Add(menuNotNull);



                        MenuItem menuNull = new MenuItem();
                        menuNull.Header = genericDataGridTemplateColumn.FieldInfo.DisplayName + " n'est pas renseigné";
                        menuNull.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SearchItem.Values[genericDataGridTemplateColumn.FieldInfo.Path] = "-";
                            genericListViewModel.SearchExecute();
                        }));

                        menuFilter.Items.Add(menuNull);



                    }

                }

                MenuItem menuSorter = new MenuItem();
                menuSorter.Header = "Trier";
                arg.ContextMenu.Items.Add(menuSorter);
             
                if (cell != null)
                {
                    Console.WriteLine(cell);
                    if (cell.Column is GenericDataGridTemplateColumn)
                    {
                       
                        EntityFieldInfo fieldInfo = genericDataGridTemplateColumn.FieldInfo;
                        Nullable<ListSortDirection> currentSort = genericListViewModel.GetSort(fieldInfo.Path);
                        MenuItem menuSorterAscending = new MenuItem();
                        menuSorterAscending.Header = "Trie croissant sur " + fieldInfo.DisplayName;
                        menuSorterAscending.IsCheckable = true;
                        menuSorterAscending.IsChecked = (currentSort.HasValue && currentSort.Value == ListSortDirection.Ascending);
                        menuSorterAscending.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SetSort(fieldInfo.Path, ListSortDirection.Ascending);
                            genericListViewModel.SearchExecute();
                        }));


                        MenuItem menuSorterDescending = new MenuItem();
                        menuSorterDescending.Header = "Trie décroissant sur " + fieldInfo.DisplayName;
                        menuSorterDescending.IsCheckable = true;
                        menuSorterDescending.IsChecked = (currentSort.HasValue && currentSort.Value == ListSortDirection.Descending);
                        menuSorterDescending.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SetSort(fieldInfo.Path, ListSortDirection.Descending);
                            genericListViewModel.SearchExecute();
                        }));

                        MenuItem menuSorterNone = new MenuItem();
                        menuSorterNone.Header = "Aucun trie sur " + fieldInfo.DisplayName;
                        menuSorterNone.IsCheckable = true;
                        menuSorterNone.IsChecked = (!currentSort.HasValue);
                        menuSorterNone.Command = new DelegateCommand(new Action(delegate()
                        {
                            genericListViewModel.SetSort(fieldInfo.Path, null);
                            genericListViewModel.SearchExecute();
                        }));

                        menuSorter.Items.Add(menuSorterAscending);
                        menuSorter.Items.Add(menuSorterDescending);
                        menuSorter.Items.Add(menuSorterNone);
                    }
                 }
              

                MenuItem menuShow = new MenuItem();
                menuShow.Header = "Afficher";
                arg.ContextMenu.Items.Add(menuShow);

                MenuItem menuShowMainTable = new MenuItem();
                menuShowMainTable.Header = genericListViewModel.EntityTableInfo.DisplayName;
                menuShow.Items.Add(menuShowMainTable);
                List<EntityTableInfo> parentTables = new List<EntityTableInfo>();
               

                /*
                List<EntityColumnInfo> parentColumnInfos = new List<EntityColumnInfo>();
                foreach (String fieldPath in fieldPaths)
                {
                    if (fieldPath.IndexOf(".") == -1)
                    {
                        EntityColumnInfo columnInfo = (from c in this.EntityTableInfo.ColumnInfos where c.PropertyName.Equals(fieldPath) select c).FirstOrDefault();
                        MenuItem menuShowColumn = new MenuItem();
                        menuShowColumn.Header = columnInfo.DisplayName;
                        menuShowColumn.IsEnabled = columnInfo.PrimaryKeyName == null && columnInfo.UniqueKeyNames.Count == 0;
                        menuShowColumn.IsCheckable = true;
                        menuShowColumn.IsChecked = this.FieldPaths.Contains(columnInfo.PropertyName);
                        menuShowMainTable.Items.Add(menuShowColumn);
                        menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                        {
                            if (menuShowColumn.IsChecked)
                            {
                                if (!this.FieldPaths.Contains(columnInfo.PropertyName))
                                {
                                    this.FieldPaths.Insert(0, columnInfo.PropertyName);
                                    foreach (GenericListItemViewModel<M> item in this.Items)
                                    { item.LoadFromModel(this.FieldPaths.ToArray().ToList()); }
                                }
                            }
                            else
                            { this.FieldPaths.Remove(columnInfo.PropertyName); }
                        }));
                    }
                    else
                    {
                        EntityColumnInfo columnInfoBottom = this.DataService.GetBottomColumnInfo(typeof(M), fieldPath);
                        EntityColumnInfo columnInfo = this.DataService.GetTopColumnInfo(typeof(M), fieldPath);
                        parentColumnInfos.Add(columnInfo);
                        parentTables.Add(columnInfo.TableInfo);
                        MenuItem menuShowColumn = new MenuItem();
                        menuShowColumn.Header = columnInfo.TableInfo.DisplayName;
                        menuShowColumn.IsEnabled = columnInfoBottom.PrimaryKeyName == null && columnInfoBottom.UniqueKeyNames.Count == 0;
                        menuShowColumn.IsCheckable = true;
                        menuShowColumn.IsChecked = this.FieldPaths.Contains(columnInfo.PropertyName);
                        menuShowMainTable.Items.Add(menuShowColumn);
                        menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                        {
                            if (menuShowColumn.IsChecked)
                            {
                                if (!this.FieldPaths.Contains(columnInfo.PropertyName))
                                {
                                    this.FieldPaths.Insert(0, columnInfo.PropertyName);
                                    foreach (GenericListItemViewModel<M> item in this.Items)
                                    { item.LoadFromModel(this.FieldPaths.ToArray().ToList()); }
                                }
                            }
                            else
                            { this.FieldPaths.Remove(columnInfo.PropertyName); }
                        }));
                    }
                }
                parentTables = (from t in parentTables orderby t.DisplayName select t).ToList();

                foreach (EntityTableInfo parentTableInfo in parentTables)
                {
                    MenuItem menuShowParentTable = new MenuItem();
                    menuShowParentTable.Header = parentTableInfo.DisplayName;
                    menuShow.Items.Add(menuShowParentTable);
                    foreach (EntityColumnInfo columnInfo in parentTableInfo.ColumnInfos)
                    {
                        if (!parentColumnInfos.Contains(columnInfo) && columnInfo.PrimaryKeyName == null && columnInfo.ControlType != ControlType.None)
                        {
                            String path = this.DataService.GetPath(parentTableInfo, this.EntityTableInfo) + "." + columnInfo.PropertyName;
                            MenuItem menuShowColumn = new MenuItem();
                            menuShowColumn.Header = columnInfo.DisplayName;
                            menuShowColumn.IsEnabled = true;
                            menuShowColumn.IsCheckable = true;
                            menuShowColumn.IsChecked = this.FieldPaths.Contains(path);

                            menuShowColumn.Command = new DelegateCommand(new Action(delegate()
                            {
                                if (menuShowColumn.IsChecked)
                                {
                                    if (!this.FieldPaths.Contains(path))
                                    {
                                        this.FieldPaths.Insert(0, path);
                                        foreach (GenericListItemViewModel<M> item in this.Items)
                                        { item.LoadFromModel(this.FieldPaths.ToArray().ToList()); }
                                    }
                                }
                                else
                                { this.FieldPaths.Remove(path); }
                            }));
                            menuShowParentTable.Items.Add(menuShowColumn);
                        }
                    }
                }

                arg.ContextMenu.Items.Add(menuFilter);
                arg.ContextMenu.Items.Add(menuSorter);
                arg.ContextMenu.Items.Add(menuShow);

                DataGridCell cell = hitDependencyObject.FindParentControl<DataGridCell>();

                if (cell != null)
                {
                    Console.WriteLine(cell);
                    if (cell.Column is GenericDataGridTemplateColumn)
                    {
                        GenericDataGridTemplateColumn column = (cell.Column as GenericDataGridTemplateColumn);
                        EntityColumnInfo columnInfo = this.DataService.GetTopColumnInfo(typeof(M), column.FieldPath);
                        String fieldDisplayName = columnInfo.DisplayName;
                        if (column.FieldPath.IndexOf(".") != -1)
                        { fieldDisplayName = columnInfo.TableInfo.DisplayName; }
                        MenuItem menuSorterAscending = new MenuItem();
                        menuSorterAscending.Header = "Trie croissant sur " + fieldDisplayName;
                        menuSorterAscending.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.SetSort(column.FieldPath, ListSortDirection.Ascending);
                            this.SearchExecute();
                        }));


                        MenuItem menuSorterDescending = new MenuItem();
                        menuSorterDescending.Header = "Trie décroissant sur " + fieldDisplayName;
                        menuSorterDescending.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.SetSort(column.FieldPath, ListSortDirection.Descending);
                            this.SearchExecute();
                        }));

                        MenuItem menuSorterNone = new MenuItem();
                        menuSorterNone.Header = "Aucun trie";
                        menuSorterNone.Command = new DelegateCommand(new Action(delegate()
                        {
                            this.SetSort(column.FieldPath, null);
                            this.SearchExecute();
                        }));

                        menuSorter.Items.Add(menuSorterAscending);
                        menuSorter.Items.Add(menuSorterDescending);
                        menuSorter.Items.Add(menuSorterNone);

                        if (cell.DataContext is GenericListItemViewModel<M>)
                        {
                            GenericListItemViewModel<M> vm = (cell.DataContext as GenericListItemViewModel<M>);
                            String valueString = vm.Values[column.FieldPath];

                            if (columnInfo.PropertyType.Equals(typeof(String)))
                            {

                                MenuItem menuEquals = new MenuItem();
                                menuEquals.Header = fieldDisplayName + " égale à " + valueString;
                                menuEquals.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = valueString;
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuEquals);


                                MenuItem menuNotEquals = new MenuItem();
                                menuNotEquals.Header = fieldDisplayName + " différent de " + valueString;
                                menuNotEquals.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "<>" + valueString;
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuNotEquals);
                            }


                            if (columnInfo.AllowNull)
                            {
                                menuFilter.Items.Add(new Separator());
                                MenuItem menuNotNull = new MenuItem();
                                menuNotNull.Header = fieldDisplayName + " est renseigné";
                                menuNotNull.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "+";
                                    this.SearchExecute();
                                }));
                                menuFilter.Items.Add(menuNotNull);



                                MenuItem menuNull = new MenuItem();
                                menuNull.Header = fieldDisplayName + " n'est pas renseigné";
                                menuNull.Command = new DelegateCommand(new Action(delegate()
                                {
                                    this.SearchItem.Values[column.FieldPath] = "-";
                                    this.SearchExecute();
                                }));

                                menuFilter.Items.Add(menuNull);



                            }

                        }



                    }
                }
                 * */
            }
        }
    }
}
