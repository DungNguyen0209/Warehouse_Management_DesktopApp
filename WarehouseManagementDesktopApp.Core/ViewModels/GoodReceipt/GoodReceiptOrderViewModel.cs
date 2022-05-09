﻿using WarehouseManagementDesktopApp.Core.Domain.Model.API;
using MessageBox = WarehouseManagementDesktopApp.Core.ComponentUI.MessageBox;
using WarehouseManagementDesktopApp.Core.Domain.ViewModel;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
#pragma warning disable CS8618
    public class GoodReceiptOrderViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;
        private readonly IExcelExporter _excelExporter;
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;
        private string filePath;
        private bool ReadingFlag { get; set; }
        private ObservableCollection<GoodReceiptOrderForViewModel> _goodsReceiptList = new ObservableCollection<GoodReceiptOrderForViewModel>();
        public ChatMessageListDesignModel? ChatMessageList { get; set; }

        public ObservableCollection<GoodReceiptOrderForViewModel> GoodsReceiptList { get => _goodsReceiptList; set { _goodsReceiptList = value; } }
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NavigateGoodReceiptView { get; set; }
        public ICommand UploadFile { get; set; }
        public ICommand PostServerExcel { get; set; }
        private bool postExcelFlag { get; set; }
        public string FilePath { get=> filePath; set { filePath = value; OnPropertyChanged(); } }
        public GoodReceiptOrderViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService, IExcelExporter excelExporter, ChatMessageListDesignModel chatMessageListDesignModel, IApiService apiService, IMapper mapper)
        {
            _navigationStore = navigationStore;
            _excelExporter = excelExporter;
            ChatMessageList = chatMessageListDesignModel;
            _apiService = apiService;
            _mapper = mapper;
            NavigateGoodReceiptView = new NavigateCommand(_GoodReceiptOrdernavigationService);
            UploadFile = new RelayCommand(() => ReadExcel());
            PostServerExcel = new RelayCommand(async () => PostExcelFile());
        }

        private async void PostExcelFile()
        {
            await RunCommandAsync(postExcelFlag, async () =>
            {
                GoodReceiptEntry goodIssueEntry = new GoodReceiptEntry()
                {
                    entries = new List<Entry>(),
                };
                goodIssueEntry.goodsReceiptId = FilePath;
                goodIssueEntry.timestamp = DateTime.Now.ToString("yyyy-MM-dd");
                goodIssueEntry.approverId = "";
                foreach (var item in GoodsReceiptList)
                {
                    Entry miniitem = new Entry() { itemId = item.ProductId };
                    if (!String.IsNullOrEmpty(item.Mass))
                    {
                        miniitem.TotalQuantity = Convert.ToInt16(item.Mass);
                    }
                    else
                    {
                        miniitem.TotalQuantity = Convert.ToInt16(item.Quantity);
                    }
                    goodIssueEntry.entries.Add(miniitem);
                }
                var result = await _apiService.PostGoodsReceipts(goodIssueEntry);
                if (result.Success)
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        IsWarning = false,
                        ContentText = "Truy xuất thành công"
                    };
                    messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    messageBox.Show();
                    GoodsReceiptList.Clear();
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        IsWarning = true,
                        ContentText = "Lỗi Trong Qúa Trình Truy Xuất Server"
                    };
                    messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    messageBox.Show();
                }
            });
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
