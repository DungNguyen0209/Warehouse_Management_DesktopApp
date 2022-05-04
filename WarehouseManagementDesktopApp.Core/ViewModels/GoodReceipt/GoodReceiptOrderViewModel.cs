using WarehouseManagementDesktopApp.Core.Domain.ViewModel;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
#pragma warning disable CS8618
    public class GoodReceiptOrderViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;
        private readonly IExcelExporter _excelExporter;
        private string filePath;
        private bool ReadingFlag { get; set; }
        private ObservableCollection<GoodReceiptOrderForViewModel> _goodsReceiptList = new ObservableCollection<GoodReceiptOrderForViewModel>();
        public ChatMessageListDesignModel? ChatMessageList { get; set; }

        public ObservableCollection<GoodReceiptOrderForViewModel> GoodsReceiptList { get => _goodsReceiptList; set { _goodsReceiptList = value; } }
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NavigateGoodReceiptView { get; set; }
        public ICommand UploadFile { get; set; }
        public string FilePath { get=> filePath; set { filePath = value; OnPropertyChanged(); } }
        public GoodReceiptOrderViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService,IExcelExporter excelExporter, ChatMessageListDesignModel chatMessageListDesignModel)
        {
            _navigationStore = navigationStore;
            _excelExporter = excelExporter;
            ChatMessageList = chatMessageListDesignModel;
            NavigateGoodReceiptView = new NavigateCommand(_GoodReceiptOrdernavigationService);
            UploadFile = new RelayCommand( () =>  ReadExcel());
        }

        private void ReadExcel()
        {
            ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> response = _excelExporter.ReadReceipt();
            foreach(var item in response.Resource)
            {
                GoodsReceiptList.Add(item);
            }
            FilePath = _excelExporter.FilePath;
        }
    }
#pragma warning restore
}
