using Persistence.SqliteDB.Domain.Interfaces;

namespace WarehouseManagementDesktopApp.Core.ViewModels;
public delegate void TextChanged();
public class AutoCompleteTextBoxViewModel : BaseViewModel
{
    public static AutoCompleteTextBoxViewModel Instance => new AutoCompleteTextBoxViewModel();
    private string _text = "";
    private string _hinttext = "Items";
    private int _selectedIndexItem;
    private bool dropDown = false;
    public bool DropDown { get => dropDown; set { dropDown = value; OnPropertyChanged(); } }
    private ObservableCollection<string>? _suggestionSource = new ObservableCollection<string>();
    //public bool TabEvent
    //{
    //    get { return _tabenter; }
    //    set
    //    {
    //        _tabenter = value;
    //        OnPropertyChanged();
    //        if (_tabenter == true)
    //        {
    //            TextChanged?.Invoke();
    //        }
    //    }
    //}
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged();
            if (!String.IsNullOrEmpty(_text))
            {
                if (String.IsNullOrWhiteSpace(Convert.ToString(_text.Last())))
                {
                    TextChanged?.Invoke();
                }
            }
        }
    }
    public string HintText { get => _hinttext; set { _hinttext = value; OnPropertyChanged(); } }
    public ObservableCollection<string>? SuggestionSource
    {
        get => _suggestionSource;
        set
        {
            _suggestionSource = value;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (_suggestionSource.Count == 0)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            {
                DropDown = false;
            }    
            else
            {
                DropDown = true;
            }    
            OnPropertyChanged("SuggestionSource");
        }
    }
    public event TextChanged TextChanged;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public AutoCompleteTextBoxViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }


}
