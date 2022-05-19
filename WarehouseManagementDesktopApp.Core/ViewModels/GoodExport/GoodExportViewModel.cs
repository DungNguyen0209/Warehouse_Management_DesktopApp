using Persistence.SqliteDB.Domain.Model.GoodExport;
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
    public ICommand UpdateContainerCommand { get; set; }
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
            if (FormulaPlannedList.Count() > 0 && _selectedIndexItem != -1)
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

    public bool searchFlag { get; private set; }
    public bool updateContainerFlag { get; private set; }

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
            orderId = GoodIssueId,
            formulaListGoodIssues = new List<FormulaListGoodIssue>(),
        };
        LoadData();
        SearchCommand = new RelayCommand(async () => Search());
        OnPropertyChanged("FormulaPlannedList");
        FinishCommand = new RelayCommand(async () => FinishEntryIssue());
        UploadFile = new RelayCommand(async () => ReadExcel());
        PostGoodReceiptToServer = new RelayCommand(async () => PostServerGoodIssue());
        UpdateContainerCommand = new RelayCommand(async () => InsertContainer());
    }

    private async void InsertContainer()
    {
        #region đã rào đk 
        if (FormulaPlannedList.Any(s => s.IsFinished == false))
        {
            MessageBox messageBox = new MessageBox()
            {
                ContentText = "Vui lòng hoàn thành đầy đủ đề xuất",
                IsWarning = true
            };
            messageBox.Show();
        }
        else
        {
            await RunCommandAsync(updateContainerFlag, async () =>
            {
                List<IssueEntryContainer> containerlist = new List<IssueEntryContainer>();
                foreach (var item in ProcessingGoodExportOrder.formulaListGoodIssues)
                {
                    foreach (var miniitem in item.Baskets)
                    {
                        if (miniitem.IsChecked == true)
                        {
                            IssueEntryContainer container = new IssueEntryContainer();
                            container.containerId = miniitem.BasketId;
                            container.quantity = Convert.ToDouble(miniitem.Actual);
                            containerlist.Add(container);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(GoodIssueId))
                {
                    var result = await _apiService.PatchGoodsIssueEntryContainer(containerlist, GoodIssueId);
                    if (result.Success)
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = "Hoàn thành",
                            IsWarning = false
                        };
                        messageBox.Show();
                        ClearAllView();
                    }
                    else
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = result.Error.Message,
                            IsWarning = true
                        };
                        messageBox.Show();
                    }
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Vui lòng điền thông tin đơn nhập kho",
                        IsWarning = true
                    };
                    messageBox.Show();
                }
            });
        }
        #endregion
        #region chưa rào ĐK
        //await RunCommandAsync(updateContainerFlag, async () =>
        //{
        //    List<IssueEntryContainer> containerlist = new List<IssueEntryContainer>();
        //    foreach (var item in ProcessingGoodExportOrder.formulaListGoodIssues)
        //    {
        //        foreach (var miniitem in item.Baskets)
        //        {
        //            if (miniitem.IsChecked == true)
        //            {
        //                IssueEntryContainer container = new IssueEntryContainer();
        //                container.containerId = miniitem.BasketId;
        //                container.quantity = Convert.ToDouble(miniitem.Actual);
        //                containerlist.Add(container);
        //            }
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(GoodIssueId))
        //    {
        //        var result = await _apiService.PatchGoodsIssueEntryContainer(containerlist, GoodIssueId);
        //        if (result.Success)
        //        {
        //            MessageBox messageBox = new MessageBox()
        //            {
        //                ContentText = "Hoàn thành",
        //                IsWarning = false
        //            };
        //            messageBox.Show();
        //            ClearAllView();
        //        }
        //        else
        //        {
        //            MessageBox messageBox = new MessageBox()
        //            {
        //                ContentText = result.Error.Message,
        //                IsWarning = true
        //            };
        //            messageBox.Show();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox messageBox = new MessageBox()
        //        {
        //            ContentText = "Vui lòng điền thông tin đơn nhập kho",
        //            IsWarning = true
        //        };
        //        messageBox.Show();
        //    }
        //});
        #endregion
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
    private async void PostServerGoodIssue()
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
            var check = String.IsNullOrEmpty(item.PlannedMass);
            if (String.IsNullOrEmpty(item.PlannedMass))
            {
                converitem.TotalQuantity = Convert.ToInt16(item.PlannedQuantity);
            }
            else
            {
                converitem.TotalQuantity = Convert.ToDouble(item.PlannedMass);
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
            ClearAllView();
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
            FormulaPlannedList.Clear();
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
    private async void SortBasket()
    {
        var apiresult = await _apiService.GetContainerByProductId(FormulaPlannedList[_selectedIndexItem].ProductId);
        if (apiresult.Success)
        {
            var dataapi = apiresult.Resource;
            this.IssueBasketList.Clear();
            int basketsum = 0;
            RangeObservableCollection<IssueBasketForViewModel> issueBaskets = new RangeObservableCollection<IssueBasketForViewModel>();

            foreach (var item in dataapi)
            {
                EUnit unit = item.item.unit;
                if (unit == EUnit.Kilogram)
                {

                    IssueBasketForViewModel issueitem = new IssueBasketForViewModel()
                    {
                        BasketId = item.containerId,
                        ProductionDate = item.productionDate,
                        Mass = Convert.ToString(item.actualQuantity),
                        Quantity = Convert.ToString(item.actualQuantity / item.item.piecesPerKilogram),
                        IsChecked = false,
                        Unit = "Kg"
                    };
                    issueBaskets.Add(issueitem);
                }
                else
                {
                    IssueBasketForViewModel issueitem = new IssueBasketForViewModel()
                    {
                        BasketId = item.containerId,
                        ProductionDate = item.productionDate,
                        Quantity = Convert.ToString(item.actualQuantity),
                        Mass = Convert.ToString(item.actualQuantity * (1 / item.item.piecesPerKilogram)),
                        Unit = "Bộ/Cái"
                    };
                    issueBaskets.Add(issueitem);
                }
            }

            // help for database
            //foreach (var item in this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets)
            //{
            //    var data = _mapper.Map<IssueBasketForViewModel>(item);
            //    if (data.IsChecked)
            //    {
            //        basketsum += Convert.ToInt32(data.Actual);
            //    }
            //    issueBaskets.Add(data);
            //}
            //SumActual = Convert.ToString(basketsum);
            //IssueBasketList = issueBaskets;
            var issuefollowingdays = issueBaskets.OrderBy(x => x.ProductionDate.Month).OrderBy(x => x.ProductionDate.Day).ToList();
            issueBaskets.Clear();
            issueBaskets.AddRange(issuefollowingdays);
            IssueBasketList = issueBaskets;
        }
    }

    private async void Search()
    {
        await RunCommandAsync(searchFlag, async () =>
        {

            _processingGoodExportOrderDatabaseService.Delete();
            var data = await _apiService.GetGoodsIssueById(GoodIssueId);
            if (data.Success)
            {
                if (data.Resource == null)
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Vui lòng kiểm tra lại đơn xuất kho",
                        IsWarning = false,
                    };
                    messageBox.Show();
                }
                else
                {

                    var result = data.Resource;
                    RangeObservableCollection<FormulaListInGoodIssueForViewModel> list = new RangeObservableCollection<FormulaListInGoodIssueForViewModel>();
                    if (result != null && result.entries.Count() > 0 && result.entries != null)
                    {

                        foreach (var item in result.entries)
                        {
                            EUnit unit = item.item.unit;
                            if (unit == EUnit.Kilogram)
                            {

                                FormulaListInGoodIssueForViewModel formulaitem = new FormulaListInGoodIssueForViewModel();
                                formulaitem.ProductId = item.item.itemId;
                                formulaitem.ProductName = item.item.name;
                                formulaitem.PlannedQuantity = "";
                                formulaitem.PlannedMass = Convert.ToString(item.TotalQuantity);
                                list.Add(formulaitem);
                            }
                            else
                            {
                                FormulaListInGoodIssueForViewModel formulaitem = new FormulaListInGoodIssueForViewModel();
                                formulaitem.ProductId = item.item.itemId;
                                formulaitem.ProductName = item.item.name;
                                formulaitem.PlannedQuantity = Convert.ToString(item.TotalQuantity);
                                formulaitem.PlannedMass = "";
                                list.Add(formulaitem);
                            }
                        }
                        FormulaPlannedList = list;
                        IssueBasketList.Clear();
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = "Truy xuất thành công",
                            IsWarning = false,
                        };
                        messageBox.Show();
                    }
                    else
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = data.Error.Message,
                            IsWarning = false,
                        };
                        messageBox.Show();
                    }
                }
            }
            else
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = "Mã đơn không tìm thấy !",
                    IsWarning = false,
                };
            }
        });
    }
    private void EditFormulaInDatabase()
    {
        int i = 1;
        ProcessingGoodExportOrder.formulaListGoodIssues.Clear();
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
        if (ProcessingGoodExportOrder.formulaListGoodIssues.Count()>0)
        {
            this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets.Clear();
            foreach (var item in IssueBasketList)
            {
                IssueBasket issueBasket = _mapper.Map<IssueBasketForViewModel, IssueBasket>(item);
                this.ProcessingGoodExportOrder.formulaListGoodIssues[_selectedIndexItem].Baskets.Add(issueBasket);
            }
        }
        else
        {
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
        if ((previousdata.Count() > 0) && (previousdata != null))
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
    //Use When finish the goodIssue
    private void ClearAllView()
    {
        this.ProcessingGoodExportOrder = new ProcessingGoodExportOrder()
        {
            formulaListGoodIssues = new List<FormulaListGoodIssue>(),
        };
        FormulaPlannedList.Clear();
        IssueBasketList.Clear();
        GoodIssueId = "";

    }
}

