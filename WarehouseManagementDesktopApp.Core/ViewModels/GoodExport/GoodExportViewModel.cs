using Persistence.SqliteDB.Domain.Model.GoodExport;

namespace WarehouseManagementDesktopApp.Core.ViewModels;
#pragma warning disable CS8618

public class GoodExportViewModel : BaseViewModel
{
    private readonly IProcessingGoodExportOrderDatabaseService _processingGoodExportOrderDatabaseService;
    private readonly IMapper _mapper;
    private bool _isDialogOpen = false;
    private string _sumActual = String.Empty;
    private string _choosenItemId = String.Empty;
    private bool _isMessageDialogOpen = false;
    private int _issueBasketSelectedIndex;
    private RangeObservableCollection<FormulaListInGoodIssueForViewModel> _formulaPlannedList = new RangeObservableCollection<FormulaListInGoodIssueForViewModel>();
    private RangeObservableCollection<IssueBasketForViewModel> _issueBasketList = new RangeObservableCollection<IssueBasketForViewModel>();
    private int _selectedIndexItem;
    public string ChoosenItemId { get => _choosenItemId; set { _choosenItemId = value; OnPropertyChanged(); } }
    public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(); } }
    public bool IsMessageDialogOpen { get => _isMessageDialogOpen; set { _isMessageDialogOpen = value; OnPropertyChanged(); } }
    public MessageBoxViewModel MessageBox { get; set; }

    public DialogGoodIssueViewModel DialogGoodIssue { get; set; }
    public ICommand ActualChanged { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand FinishCommand { get; set; }
    public string SumActual { get => _sumActual; set { _sumActual = value; OnPropertyChanged(); } }

    ProcessingGoodExportOrder ProcessingGoodExportOrder { get; set; }
    public RangeObservableCollection<FormulaListInGoodIssueForViewModel> FormulaPlannedList { get => _formulaPlannedList; set { _formulaPlannedList = value; OnPropertyChanged(); } }
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
            ChoosenItemId = FormulaPlannedList[_selectedIndexItem].ProductId;
            SortBasket();
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


    public GoodExportViewModel(DialogGoodIssueViewModel dialogGoodIssue,IProcessingGoodExportOrderDatabaseService processingGoodExportOrderDatabaseService, IMapper mapper)
    {
        DialogGoodIssue = dialogGoodIssue;
        _mapper = mapper;
        _processingGoodExportOrderDatabaseService = processingGoodExportOrderDatabaseService;
        MessageBox = new MessageBoxViewModel()
        {
            ContentText = "You are Confirm",
            Icon = PackIconKind.Warning,
        };
        this.ProcessingGoodExportOrder = new ProcessingGoodExportOrder()
        {
            orderId = ChoosenItemId,
            formulaListGoodIssues = new List<FormulaListGoodIssue>(),
            issueBasketLists = new List<IssueBasketList>(),
        };
        FormulaPlannedList.Add(new FormulaListInGoodIssueForViewModel() { ProductId = "111", PlannedMass = "100", PlannedQuantity = "20", ProductName = "AICHOOO", Actual = "0", IsFinished = false });
        FormulaPlannedList.Add(new FormulaListInGoodIssueForViewModel() { ProductId = "112", PlannedMass = "110", PlannedQuantity = "40", ProductName = "AICHOOO", Actual = "0", IsFinished = false });
        SearchCommand = new RelayCommand(async () => Search());
        FinishCommand = new RelayCommand(async () => FinishEntryIssue());
    }

    private void FinishEntryIssue()
    {
        if (SumActual == FormulaPlannedList[_selectedIndexItem].Actual)
        {
            FormulaPlannedList[_selectedIndexItem].IsFinished = true;
        }
        else
        {
            FormulaPlannedList[_selectedIndexItem].IsFinished = false;
            this.MessageBox.ContentText = "Thực xuất không tương thích  !";
            this.MessageBox.Icon = PackIconKind.Warning;
            IsMessageDialogOpen = true;
        }
        EditGoodIssueInDatabase();
        UpdateDatabase();

    }

    private void CaculateActual()
    {
        int sum = 0;
        foreach (var item in IssueBasketList)
        {
            if (item.IsChecked)
            {
                if(!String.IsNullOrEmpty(item.Actual) && int.TryParse(item.Actual, out _))
                sum += Convert.ToInt32(item.Actual);
            }
        }
        SumActual = Convert.ToString(sum);
    }



#pragma warning restore
    private void SortBasket()
    {
        this.IssueBasketList.Clear();
        RangeObservableCollection<IssueBasketForViewModel> issueBaskets = new RangeObservableCollection<IssueBasketForViewModel>();
        IssueBasketForViewModel item1 = new IssueBasketForViewModel()
        {
            BasketId = "LR123",
            ProductionDate = "22-2-2022",
            Quantity = "12",
            Mass = "20"
        };
        IssueBasketForViewModel item2 = new IssueBasketForViewModel()
        {
            BasketId = "LR1234",
            ProductionDate = "22-2-2022",
            Quantity = "23",
            Mass = "30"
        };
        IssueBasketForViewModel item3 = new IssueBasketForViewModel()
        {
            BasketId = "LR12345",
            ProductionDate = "22-2-2022",
            Quantity = "25",
            Mass = "50"
        };
        issueBaskets.AddRange(new List<IssueBasketForViewModel>() { item1, item2, item3 });
        IssueBasketList = issueBaskets;
    }

    private async void Search()
    {
        //IsDialogOpen = true;

        _processingGoodExportOrderDatabaseService.Delete();
    }
    private void EditFormulaInDatabase()
    {
        foreach(var item in FormulaPlannedList)
        {
            FormulaListGoodIssue miniitem = _mapper.Map<FormulaListInGoodIssueForViewModel,FormulaListGoodIssue>(item);
            this.ProcessingGoodExportOrder.formulaListGoodIssues.Add(miniitem);
        }
        // _processingGoodExportOrderDatabaseService.Update()
    }
    private void EditGoodIssueInDatabase()
    {
        ICollection<IssueBasket> issue  = new List<IssueBasket>();
        foreach(var item in IssueBasketList)
        {
            IssueBasket issueBasket = _mapper.Map<IssueBasketForViewModel, IssueBasket>(item);
            issue.Add(issueBasket);
        }

        this.ProcessingGoodExportOrder.issueBasketLists.Add(new IssueBasketList() { Baskets = issue, Id = _selectedIndexItem });
    }

    private async void UpdateDatabase()
    {
        this.ProcessingGoodExportOrder.orderId = ChoosenItemId;
        EditFormulaInDatabase();
        _processingGoodExportOrderDatabaseService.Update(this.ProcessingGoodExportOrder);
    }
}

