using BlazorLogin.Service;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace BlazorLogin.Shared
{
    public class FormModel
    {
        public long Value { get; set; }
    }
   
    public partial class TableGrid<TItem> where TItem : class
    {
        [CascadingParameter]
        protected Notification Notification { get; set; }

        public List<TItem> Data { get; set; }
        DataService<TItem> Service { get; set; }
        //public TItem CurrentlyInEdit { get; set; }
        List<GridViewModel<TItem>> Columns { get; set; }
        List<PropertyInfo> FKColumns { get; set; }
        //public Dictionary<string, FormModel> PropertyVars { get; set; } = new Dictionary<string, FormModel>();
        public TItem Edit { get; set; }
        private GridFormEditMode EditMode { get; set; } = GridFormEditMode.None;
        protected override async Task OnInitializedAsync()
        {

            Service = ServiceFactory.Get<TItem>();
            Columns = new PropertyList<TItem>().GetColumn();
            FKColumns = new List<PropertyInfo>();
            foreach (var item in Columns)
            {
                if (item.ForeignKey != null)
                {
                    FKColumns.Add(item.ForeignKey);
                }
            }
            await GetData();
            //return base.OnInitializedAsync();

        }
        public async Task DeleteHandler(GridCommandEventArgs args)
        {
            TItem currItem = (TItem)args.Item;
            try
            {
                Service.Delete(currItem);

            }
            catch (Exception ex)
            {
                //await ShowAlert(ex.Message);
            }
            await GetData();
        }

        public async Task CreateHandler(TItem currItem)
        {
            Service.Insert(currItem);
            //try
            //{

            //    foreach (var item in PropertyVars)
            //    {
            //        currItem.GetType().GetProperty(item.Key + "Id").SetValue(currItem, item.Value.Value);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //await ShowAlert(ex.Message);
            //}
            await GetData();

        }

        public async Task UpdateHandler(TItem currItem)
        {
            //TItem currItem = args.Item as TItem;

            //foreach (var item in PropertyVars)
            //{
            //    currItem.GetType().GetProperty(item.Key + "Id").SetValue(currItem, item.Value.Value);
            //}
            EditMode = GridFormEditMode.None;
            try
            {
                Service.Update(currItem);
            }
            catch (Exception ex)
            {
                //await ShowAlert(ex.Message);
            }
            await GetData();


        }
        public void EditOnClick(GridCommandEventArgs args)
        {
            TItem currItem = (TItem)args.Item;
            Edit = currItem;
            EditMode = GridFormEditMode.Edit;

            //PropertyVars = new Dictionary<string, FormModel>();
            //foreach (var key in FKColumns)
            //{
            //    var id = (typeof(TItem).GetProperty(key.Name + "Id").GetValue(currItem));
            //    if (id != null)
            //    {
            //        var propertyInfo = typeof(TItem).GetProperty(key.Name);
            //        PropertyVars.Add(key.Name, new FormModel { Value = (long)id });
            //    }
            //    else
            //    {
            //        var propertyInfo = typeof(TItem).GetProperty(key.Name);
            //        PropertyVars.Add(key.Name, new FormModel { Value = 0 });
            //    }

            //}
        }
        public void AddOnClick()
        {
            var currItem = (TItem)Activator.CreateInstance(typeof(TItem));
            Edit = currItem;
            EditMode = GridFormEditMode.Create;


        }
        public async Task GetData()
        {
            Data = Service.GetAll().ToList();

            Notification.Instance.Show(new NotificationModel()
            {
                Text = "資料已更新",
                ThemeColor = ThemeColors.Info,
                CloseAfter = 2000,
                Closable = true,

            });
        }
        public async Task ForeignKeyFliter(List<long> fliterText, string columnName, FilterCellTemplateContext context)
        {
            var filterDescriptor = context.FilterDescriptor;
            if (fliterText.Count > 0)
            {
                filterDescriptor.FilterDescriptors.Clear();
                filterDescriptor.LogicalOperator = FilterCompositionLogicalOperator.Or;
                foreach (int item in fliterText)
                {
                    var descr = new FilterDescriptor(columnName, FilterOperator.IsEqualTo, item);
                    descr.MemberType = typeof(long);
                    filterDescriptor.FilterDescriptors.Add(descr);
                }
                await context.FilterAsync();

            }
            else
            {
                await context.ClearFilterAsync();
            }

        }
        public async Task OnFormReturn(TItem returnItem)
        {
            Edit = null;
            if (returnItem != null && EditMode==GridFormEditMode.Edit)
            {
                await UpdateHandler(returnItem);
            }else if(returnItem !=null && EditMode == GridFormEditMode.Create)
            {
                await CreateHandler(returnItem);
            }
            else
            {
                //Error!
            }
            EditMode = GridFormEditMode.None;
        }
        //public void Add()
        //{
        //    PropertyVars = new Dictionary<string, FormModel>();
        //    foreach (var key in FKColumns)
        //    {
        //        //long id = (long)(typeof(TItem).GetProperty(key.Name + "Id").GetValue(currItem));
        //        var propertyInfo = typeof(TItem).GetProperty(key.Name);
        //        PropertyVars.Add(key.Name, new FormModel());
        //    }
        //}
    }
}
