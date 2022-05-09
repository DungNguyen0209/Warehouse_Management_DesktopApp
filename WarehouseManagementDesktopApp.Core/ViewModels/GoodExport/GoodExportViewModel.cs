using Persistence.SqliteDB.Domain.Model.GoodExport;
using MessageBox = WarehouseManagementDesktopApp.Core.ComponentUI.MessageBox;
namespace WarehouseManagementDesktopApp.Core.ViewModels;
#pragma warning disable CS8618

public class GoodExportViewModel : BaseViewModel
{
    private readonly IProcessingGoodExportOrderDatabaseService _processingGoodExportOrderDatabaseService;
    private readonly IMapper _mapper;
    private readonly IExcelExporter _excelExporter;
    private readonly IApiService _apiService;
    private bool _isDialogOpen = false;
    private string _sumActual = String.Empty;
    private string _choosenItemId = String.Empty;
    private string _goodIssueId = String.Empty;
    private bool _isMessageDialogOpen = false;
    private int _issueBasketSelectedIndex;
    private RangeObservableCollection<FormulaListInGoodIssueForViewModel> _formulaPlannedList = new RangeObservableCollection<FormulaListInGoodIssueForViewModel>();
    private RangeObservableCollection<IssueBasketForViewModel> _issueBasketList = new RangeObservableCollection<IssueBasketForViewModel>();
    private int _selectedIndexItem;
    private bool loadExcelFlag { get; set; }
    private bool postExcelFlag { get; set; }
    public string ChoosenItemId { get => _choosenItemId; set { _choosenItemId = value; OnPropertyChanged(); } }
    public string GoodIssueId { get => _goodIssueId; set { _goodIssueId = value; OnPropertyChanged(); } }
    public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(); } }
    public bool IsMessageDialogOpen { get => _isMessageDialogOpen; set { _isMessageDialogOpen = value; OnPropertyChanged(); } }
    public MessageBoxViewModel MessageBox { get; set; }
    public DialogGoodIssueViewModel DialogGoodIssue { get; set; }
    public ICommand ActualChanged { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand FinishCommand { get; set; }
    public ICommand UploadFile { get; set; }
    public ICommand PostGoodReceiptToServer { get; set; }
    public string SumActual { get => _sumActual; set { _sumActual = value; OnPropertyChanged(); } }

    ProcessingGoodExportOrder ProcessingGoodExportOrder { get; set; }
    public RangeObservableCollection<FormulaListInGoodIssueForViewModel> FormulaPlannedList
    {
        get => _formulaPlannedList;
        set
        {
            _formulaPlannedList = value;
            if (this.ProcessingGoodExportOrder.orderId != GoodIssueId)
            {
                EditFormulaInDatabase();
            }
            OnPropertyChanged();
        }
    }
    public RangeObservableCollection<IssueBasketForViewModel> IssueBasketList
    {
        get => _issueBasketList;
        set
        {
            _issueBasketList = value;
            OnPropertyChanged();
            foreach (var item in _issueBasketList)
            {
                item.ActualChanged += CaculateActual;
            }
        }
    }

    public int SelectedIndexItem
    {
        get => _selectedIndexItem;
        set
        {
            _selectedIndexItem = value;
            OnPropertyChanged();
            if(FormulaPlannedList.Count()>0)
            {
            ChoosenItemId = FormulaPlannedList[_selectedIndexItem].ProductId;
            SortBasket();
            }
        }
    }

    public int IssueBasketSelectedIndex
    {
        get => _issueBasketSelectedIndex;
        set
        {
            if (_issueBasketSelectedIndex != value)
            {
                _issueBasketSelectedIndex = value;
                OnPropertyChanged();
            }
        }
    }


    public GoodExportViewModel(DialogGoodIssueViewModel dialogGoodIssue, IProcessingGoodExportOrderDatabaseService processingGoodExportOrderDatabaseService, IExcelExporter excelExporter, IMapper mapper, IApiService apiService)
    {
        DialogGoodIssue = dialogGoodIssue;
        _excelExporter = excelExporter;
        _mapper = mapper;
        _processingGoodExportOrderDatabaseService = processingGoodExportOrderDatabaseService;
        _apiService = apiService;
        MessageBox = new MessageBoxViewModel()
        {
            ContentText = "You are Confirm",
            Icon = PackIconKind.Warning,
        };
        this.ProcessingGoodExportOrder = new ProcessingGoodExportOrder()
        {
            orderId = ChoosenItemId,
            formulaListGoodIssues = new List<FormulaListGoodIssue>(),
        };
        LoadData();
        SearchCommand = new RelayCommand(async () => Search());
        OnPropertyChanged("FormulaPlannedList");
        FinishCommand = new RelayCommand(async () => FinishEntryIssue());
        UploadFile = new RelayCommand(async () => ReadExcel());
        PostGoodReceiptToServer = new RelayCommand(async () => PostServerGoodReceipt());
    }

    //private async void PostServerGoodReceipt()
    //{
    //    await RunCommandAsync(postExcelFlag, async () =>
    //    {
    //        GoodIssueEntry goodIssueEntry = new GoodIssueEntry()
    //        {
    //            entries = new List<ProductEntry>(),
    //        };
    //        goodIssueEntry.goodsReceiptId = GoodIssueId;
    //        goodIssueEntry.timestamp = DateTime.Now.ToString("yyyy-MM-dd");
    //        goodIssueEntry.approverId = "";
    //        foreach(var item in FormulaPlannedList)
    //        {
    //            var converitem = _mapper.Map<ProductEntry>(item);
    //            if(String.IsNullOrEmpty(item.PlannedMass))
    //            { 
    //                converitem.TotalQuantity = Convert.ToInt16(item.PlannedQuantity);
    //            }
    //            else
    //            {
    //                converitem.TotalQuantity = Convert.ToInt16(item.PlannedMass);
    //            }    
    //            goodIssueEntry.entries.Add(converitem);
    //        }
    //        var result =await _apiService.PostGoodsReceipts(goodIssueEntry);
    //        if(result.Success)
    //        {
    //            FormulaPlannedList.Clear();
    //        }    
    //        else
    //        {
    //            MessageBox messageBox = new MessageBox()
    //            {
    //                IsWarning = false,
    //                ContentText = "Lỗi Trong Qúa Trình Truy Xuất Server"
    //            };
    //            messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    //            messageBox.Show();
    //        }    
    //    });
    //}
    private async void PostServerGoodReceipt()
    {
        await RunCommandAsync(postExcelFlag, async () =>
        {
            GoodIssueEntry goodIssueEntry = new GoodIssueEntry()
            {
                entries = new List<ProductEntry>(),
            };
            goodIssueEntry.goodsIssueId = GoodIssueId;
            goodIssueEntry.timestamp = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (var item in FormulaPlannedList)
            {
                var converitem = _mapper.Map<ProductEntry>(item);
                if (!String.IsNullOrEmpty(item.PlannedMass))
                {
                    converitem.TotalQuantity = Convert.ToInt16(item.PlannedQuantity);
                }
                else
                {
                    converitem.TotalQuantity = Convert.ToInt16(item.PlannedMass);
                }
                goodIssueEntry.entries.Add(converitem);
            }
            var result = await _apiService.PostGoodsIssue(goodIssueEntry);
            if (result.Success)
            {
                MessageBox messageBox = new MessageBox()
                {
                    IsWarning = false,
                    ContentText = "Truy xuất thành công"
                };
                messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                messageBox.Show();
                FormulaPlannedList.Clear();
            }
            else
            {
                MessageBox messageBox = new MessageBox()
                {
                    IsWarning = false,
                    ContentText = result.Error.Message
                };
                messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                messageBox.Show();
            }
        });
    }
    #region testing
    private void Testing()
    {
        RangeObservableCollection<FormulaListInGoodIssueForViewModel> test = new RangeObservableCollection<FormulaListInGoodIssueForViewModel>();
        test.Add(new FormulaListInGoodIssueForViewModel() { ProductId = "111", PlannedMass = "100", PlannedQuantity = "20", ProductName = "AICHOOO", Actual = "0", IsFinished = false });
        test.Add(new FormulaListInGoodIssueForViewModel() { ProductId = "112", PlannedMass = "110", PlannedQuantity = "40", ProductName = "AICHOOO", Actual = "0", IsFinished = false });
        this.FormulaPlannedList = test;
    }
    private async void ReadExcel()
    {
        await RunCommandAsync(loadExcelFlag, async () =>
        {
            ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> response = _excelExporter.ReadReceipt();
        foreach (var item in response.Resource)
        {
            var convertitem = _mapper.Map<FormulaListInGoodIssueForViewModel>(item);
            FormulaPlannedList.Add(convertitem);
        }
        GoodIssueId = _excelExporter.FilePath;
        });
    }
    #endregion
    private void FinishEntryIssue()
    {
        if (SumActual == FormulaPlannedList[_selectedIndexItem].Actual)
        {
            FormulaPlannedList[_selectedIndexItem].IsFinished = true;
        }
        else
        {
            FormulaPlannedList[_selectedIndexItem].IsFinished = false;
            this.MessageBox.ContentText = "Thực xuất không tương thích !";
            this.MessageBox.Icon = PackIconKind.Warning;
            IsMessageDialogOpen = true;
        }
        UpdateDatabase();

    }

    private void CaculateActual()
    {
        int sum = 0;
        foreach (var item in IssueBasketList)
        {
            if (item.IsChecked)
            {
                if (!String.IsNullOrEmpty(item.Actual) && int.TryParse(item.Actual, out _))
                    sum += Convert.ToInt32(item.Actual);
            }
        }
        SumActual = Convert.ToString(sum);
    }



#pragma warning restore
    private void SortBasket()
    {
        this.IssueBasketList.Clear();
        int basketsum = 0;
        RangeObservableCollection<IssueBasketForViewModel> issueBaskets = new RangeObservableCollection<IssueBasketForViewModel>();
        #region Testing data
        //RangeObservableCollection<IssueBasketForViewModel> issueBaskets = new RangeObservableCollection<IssueBasketForViewModel>();
        //IssueBasketForViewModel item1 = new IssueBasketForViewModel()
        //{
        //    BasketId = "LR123",
        //    ProductionDate = "22-2-2022",
        //    Quantity = "12",
        //    Mass = "20"
        //};
        //IssueBasketForViewModel item2 = new IssueBasketForViewModel()
        //{
        //    BasketId = "LR1234",
        //    ProductionDate = "22-2-2022",
        //    Quantity = "23",
        //    Mass = "30"
        //};
        //IssueBasketForViewModel item3 = new IssueBasketForViewModel()
        //{
        //    BasketId = "LR12345",
        //    ProductionDate = "22-2-2022",
        //    Quantity = "25",
        //    Mass = "50"
        //};
        //issueBaskets.AddRange(new List<IssueBasketForViewModel>() { item1, item2, item3 });
        #endregion
        foreach (var item in this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets)
        {
            var data = _mapper.Map<IssueBasketForViewModel>(item);
            if(data.IsChecked)
            {
                basketsum += Convert.ToInt32(data.Actual);
            }
            issueBaskets.Add(data);
        }
        SumActual = Convert.ToString(basketsum);
        IssueBasketList = issueBaskets;
    }

    private async void Search()
    {
        //IsDialogOpen = true;

        _processingGoodExportOrderDatabaseService.Delete();
    }
    private void EditFormulaInDatabase()
    {
        int i = 1;
        foreach (var item in FormulaPlannedList)
        {
            FormulaListGoodIssue miniitem = _mapper.Map<FormulaListInGoodIssueForViewModel, FormulaListGoodIssue>(item);
            miniitem.Id = i;
            this.ProcessingGoodExportOrder.formulaListGoodIssues.Add(miniitem);
            i++;
        }
        foreach (var item in this.ProcessingGoodExportOrder.formulaListGoodIssues)
        {
            item.Baskets = new List<IssueBasket>();
        }
    }
    private void EditGoodIssueInDatabase()
    {
        this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets.Clear();
        foreach (var item in IssueBasketList)
        {
            IssueBasket issueBasket = _mapper.Map<IssueBasketForViewModel, IssueBasket>(item);
            this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets.Add(issueBasket);
        }

    }

    private async void UpdateDatabase()
    {
        this.ProcessingGoodExportOrder.orderId = GoodIssueId;
        EditGoodIssueInDatabase();
        _processingGoodExportOrderDatabaseService.Update(this.ProcessingGoodExportOrder);
    }
    private async void LoadData()
    {
        var previousdata = await _processingGoodExportOrderDatabaseService.GetAll();
        if ((previousdata.Count() > 0 ) && (previousdata != null ))
        {
            var data = previousdata.Last();
            this.ProcessingGoodExportOrder = data;
            GoodIssueId = data.orderId;
            RangeObservableCollection<FormulaListInGoodIssueForViewModel> formulaListGoodIssuesprevious = new RangeObservableCollection<FormulaListInGoodIssueForViewModel>();
            foreach (var item in data.formulaListGoodIssues)
            {
                formulaListGoodIssuesprevious.Add(_mapper.Map<FormulaListGoodIssue, FormulaListInGoodIssueForViewModel>(item));
            }
            this.FormulaPlannedList = formulaListGoodIssuesprevious;
            //foreach (var item in data.issueBasketLists)
            //{
            //    ObservableCollection<IssueBasketForViewModel> entry = new ObservableCollection<IssueBasketForViewModel>();
            //    foreach (var miniitem in item.Baskets)
            //    {
            //        IssueBasketForViewModel issueBasket = _mapper.Map<IssueBasket, IssueBasketForViewModel>(miniitem);
            //        entry.Add(issueBasket);
            //    }
            //    issueBasketForViewModelsprevious.Add(entry);
            //}
        }

    }
}

