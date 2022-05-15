namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;
        public ICommand GetProdcutCommand { get; set; }
        private DateTime _startDate = DateTime.Now;
        private RangeObservableCollection<Stockcardentries> _stockcardentries = new RangeObservableCollection<Stockcardentries>();
        public RangeObservableCollection<Stockcardentries> Stockcardentries { get => _stockcardentries; set { _stockcardentries = value; OnPropertyChanged(); } }

        private RangeObservableCollection<WarningStock> warningStockStockcardentries = new RangeObservableCollection<WarningStock>();
        public RangeObservableCollection<WarningStock> WarningStockStockcardentries { get => warningStockStockcardentries; set { warningStockStockcardentries = value; OnPropertyChanged(); } }
        private bool warningItemDataGrid = false;
        private bool stockCardDataGrid = true;
        public bool WarningItemDataGrid { get => warningItemDataGrid; set { warningItemDataGrid = value; OnPropertyChanged(); } }
        public bool StockCardDataGrid { get => stockCardDataGrid; set { stockCardDataGrid = value; OnPropertyChanged(); } }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }
        private DateTime _stopDate = DateTime.Now;
        public DateTime StopDate
        {
            get { return _stopDate; }
            set { _stopDate = value; OnPropertyChanged(); }
        }
        private string _productId = String.Empty;
        public string ProductId { get { return _productId; } set { _productId = value; OnPropertyChanged(); } }

        public bool Flag { get; private set; }
        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get => selectedIndex; set
            {
                selectedIndex = value;
                if (selectedIndex == 0)
                {
                    StockCardDataGrid = true;
                    WarningItemDataGrid = false;
                }
                else
                {
                    StockCardDataGrid = false;
                    WarningItemDataGrid = true;
                }
                OnPropertyChanged();
            }
        }


        public HistoryViewModel(IApiService apiService, IMapper mapper = null)
        {
            _apiService = apiService;
            _mapper = mapper;
            GetProdcutCommand = new RelayCommand(async () => GetProduct());
        }

        private async void GetProduct()
        {
            await RunCommandAsync(Flag, async () =>
            {
                switch (SelectedIndex)
                {
                    case 0:
                        {
                            var result = await _apiService.GetAllStockCard(StartDate, StopDate, ProductId);
                            if (result.Success)
                            {
                                RangeObservableCollection<Stockcardentries> stockcarlist = new RangeObservableCollection<Stockcardentries>();
                                stockcarlist.AddRange(result.Resource);
                                Stockcardentries = stockcarlist;
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Thành Công",
                                    IsWarning = false,
                                };
                                messageBox.Show();
                            }
                            else
                            {
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Truy xuất không thành Công",
                                    IsWarning = true,
                                };
                                messageBox.Show();
                            }
                            break;
                        }
                    case 1:
                        {
                            ProductId = "";
                            var result = await _apiService.GetUnderStockCards();
                            if (result.Success)
                            {
                                int i = 1;
                                RangeObservableCollection<WarningStock> stockcarlist = new RangeObservableCollection<WarningStock>();
                                foreach (var item in result.Resource)
                                {
                                    var stockcard = _mapper.Map<WarningStock>(item);
                                    stockcard.Id = Convert.ToString(i);
                                    if (item.item.unit == EUnit.Kilogram)
                                    {
                                        stockcard.unit = "Kg";
                                    }
                                    else
                                    {
                                        stockcard.unit = "Bộ/Cái";
                                    }
                                    stockcarlist.Add(stockcard);
                                    i++;
                                }
                                WarningStockStockcardentries = stockcarlist;
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Thành Công",
                                    IsWarning = false,
                                };
                                messageBox.Show();
                            }
                            else
                            {
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Truy xuất không thành Công",
                                    IsWarning = true,
                                };
                                messageBox.Show();
                            }
                            break;
                        }
                    case 2:
                        {
                            ProductId = "";
                            var result = await _apiService.GetOverStockCards();
                            if (result.Success)
                            {
                                RangeObservableCollection<WarningStock> stockcarlist = new RangeObservableCollection<WarningStock>();
                                int i = 1;
                                foreach (var item in result.Resource)
                                {
                                    var stockcard = _mapper.Map<WarningStock>(item);
                                    stockcard.Id = Convert.ToString(i);
                                    if (item.item.unit == EUnit.Kilogram)
                                    {
                                        stockcard.unit = "Kg";
                                    }
                                    else
                                    {
                                        stockcard.unit = "Bộ/Cái";
                                    }
                                    stockcarlist.Add(stockcard);
                                    i++;
                                }
                                WarningStockStockcardentries = stockcarlist;
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Thành Công",
                                    IsWarning = false,
                                };
                                messageBox.Show();
                            }
                            else
                            {
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Truy xuất không thành Công",
                                    IsWarning = true,
                                };
                                messageBox.Show();
                            }
                            break;
                        }
                }
            });

        }

    }
}
