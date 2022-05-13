namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class HistoryViewModel:BaseViewModel
    {
        private readonly IApiService _apiService;
        public ICommand GetProdcutCommand { get; set; }
        private DateTime _startDate = DateTime.Now;
        private RangeObservableCollection<Stockcardentries> _stockcardentries = new RangeObservableCollection<Stockcardentries>();
        public RangeObservableCollection<Stockcardentries> Stockcardentries { get => _stockcardentries; set { _stockcardentries = value; OnPropertyChanged(); }}
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
        public string ProductId { get { return _productId; } set { _productId = value;OnPropertyChanged(); } }

        public bool Flag { get; private set; }


        public HistoryViewModel(IApiService apiService)
        {
            _apiService = apiService;
            GetProdcutCommand = new RelayCommand(async() => GetProduct());
        }

        private async void GetProduct()
        {
            await RunCommandAsync(Flag, async () =>
            {            
                var result = await _apiService.GetAllStockCard(StartDate, StopDate, ProductId);
                if(result.Success)
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
            });
        }

    }
}
