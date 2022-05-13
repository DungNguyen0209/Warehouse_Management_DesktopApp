
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class ProcessingGoodExportViewModel :BaseViewModel
    {
        private readonly IApiService _apiService;
        private ObservableCollection<ProcessingGoodIssue> _processingGoodIssues = new ObservableCollection<ProcessingGoodIssue>();
        public ObservableCollection<ProcessingGoodIssue> ProcessingGoodIssue { get => _processingGoodIssues; set { _processingGoodIssues = value; OnPropertyChanged(); }}
        public ICommand ReloadCommand { get; set; }
        public ProcessingGoodExportViewModel(IApiService apiService)
        {
            _apiService = apiService;
            ReloadCommand = new RelayCommand(async () => Reload());
            Reload();
        }

        private async void Reload()
        {
            var data = await _apiService.GetGoodsIssueByTime(DateTime.Now);
            if(data.Success)
            {
                ObservableCollection<ProcessingGoodIssue> list = new ObservableCollection<ProcessingGoodIssue>();
                foreach (var item in  data.Resource.items)
                {
                    if(item.confirmed == false)
                    { 
                     ProcessingGoodIssue itemprocess = new ProcessingGoodIssue()
                     {
                         Id = item.goodsIssueId,
                        DateTime = Convert.ToString(item.timestamp),
                     };
                        list.Add(itemprocess);
                    }
                }
                ProcessingGoodIssue = list;
            }
            else
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = data.Error.Message,
                    IsWarning = false
                };
                messageBox.Show();
            }
        }
    }
}
