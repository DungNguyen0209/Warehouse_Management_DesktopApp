
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class ProcessingGoodExportViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;
        private readonly IExcelExporter _excelExporter;
        private readonly IMapper _mapper;
        private RangeObservableCollection<ProcessingGoodIssue> _processingGoodIssues = new RangeObservableCollection<ProcessingGoodIssue>();
        private RangeObservableCollection<ContainerIssueEntry> _containerSources = new RangeObservableCollection<ContainerIssueEntry>();
        private int _selectedIndexGoodIssue=0;
        public RangeObservableCollection<ProcessingGoodIssue> ProcessingGoodIssue { get => _processingGoodIssues; set { _processingGoodIssues = value;
                
                OnPropertyChanged(); } }
        public RangeObservableCollection<ContainerIssueEntry> IssueContainerSources { get => _containerSources; set { _containerSources = value; 
                OnPropertyChanged(); } }
        public int SelectedIndexGoodIssue
        {
            get => _selectedIndexGoodIssue;
            set
            {
                _selectedIndexGoodIssue = value;
                SortContainer();
                OnPropertyChanged();
            }
        }

        private async Task SortContainer()
        {
            var goodIssue = await _apiService.GetGoodsIssueById(ProcessingGoodIssue[SelectedIndexGoodIssue].Id);
            if (goodIssue.Success)
            {
                if (goodIssue.Resource != null && goodIssue.Resource.entries!=null)
                {
                    var containers = new RangeObservableCollection<ContainerIssueEntry>();
                    foreach (var item in goodIssue.Resource.entries)
                    {
                        foreach (var itemmini in item.containers)
                        {
                            var ContainerLocation = await _apiService.GetContainerById(itemmini.containerId);
                            var issuecontainer = _mapper.Map<ContainerIssueEntry>(ContainerLocation.Resource);
                            issuecontainer.Quantity = Convert.ToString(item.TotalQuantity);
                            if(item.item.unit == EUnit.Kilogram)
                            {
                                issuecontainer.Unit = "Kg";
                            }
                            else
                            {
                                issuecontainer.Unit = "Bộ/Cái";
                            }
                            containers.Add(issuecontainer);
                        }
                    }
                    IssueContainerSources = containers;
                }
            }
            else
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = "Vui lòng thử lại !",
                    IsWarning = false
                };
                messageBox.Show();
            }
        }

        public ICommand ReloadCommand { get; set; }
        public ICommand FinishCommand { get; set; }
        public ICommand ExcelExportCommand { get; set; }
        public bool ExcelExportFlag { get;  set; }

        public ProcessingGoodExportViewModel(IApiService apiService, IMapper mapper, IExcelExporter excelExporter)
        {
            _apiService = apiService;
            ReloadCommand = new RelayCommand(async () => Reload());
            FinishCommand = new RelayCommand(async () => Finish());
            ExcelExportCommand = new RelayCommand(async () => ExportExcel());
            _mapper = mapper;
            _excelExporter = excelExporter;
            Reload();
        }

        private async Task ExportExcel()
        {

                var result =await _excelExporter.ExportGoodIssue(IssueContainerSources);
                if(result.Success)
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Xuất thành công !",
                        IsWarning = false
                    };
                    messageBox.Show();
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Xuất thất bại !",
                        IsWarning = true
                    };
                    messageBox.Show();
                }
        }

        private async void Finish()
        {
            var goodIssueId = ProcessingGoodIssue[SelectedIndexGoodIssue].Id;
            if(goodIssueId != null)
            {
                List<string> containers = new List<string>();
                foreach(var item in IssueContainerSources)
                {
                    containers.Add(item.containerId);
                }
                var confirmResult = await _apiService.PatchConFirmGoodsIssue(goodIssueId, containers);
                if(confirmResult.Success)
                {
                    ProcessingGoodIssue.Clear();
                    IssueContainerSources.Clear();
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Xuất kho thành công !",
                        IsWarning = false
                    };
                    messageBox.Show();
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Xác nhận thất bại !",
                        IsWarning = false
                    };
                    messageBox.Show();
                }
            }
        }

        private async void Reload()
        {
            var data = await _apiService.GetGoodsIssueByTime(DateTime.Now);
            if (data.Success)
            {
                RangeObservableCollection<ProcessingGoodIssue> list = new RangeObservableCollection<ProcessingGoodIssue>();
                foreach (var item in data.Resource.items)
                {
                    if (item.confirmed == false)
                    {
                        ProcessingGoodIssue itemprocess = new ProcessingGoodIssue()
                        {
                            Id = item.goodsIssueId,
                            DateTime = Convert.ToString(item.timestamp),
                        };
                        list.Add(itemprocess);
                    }
                }
                ProcessingGoodIssue emptyitem = new ProcessingGoodIssue()
                {
                    Id = "",
                    DateTime = "",
                };
                list.Add(emptyitem);
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
