namespace PBL3.ViewModels.Windows;

public sealed partial class PopupWindowViewModel : ViewModelBase, IPopupWindowViewModel
{
    private readonly Tab[] _tabs;

    [ObservableProperty]
    private ViewModelBase _content;

    [ObservableProperty]
    private string _title = "Login";

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public PopupWindowViewModel()
    {
        _tabs =
        [
            (new LoginPageViewModel(), "Login Page"),
            (new RegisterPageViewModel(), "Register Page")
        ];
        Content = _tabs[0].Content;
    }

    public bool? DialogResult => null;

    public void SwitchTab(int index)
    {
        Content = _tabs[index].Content;
        Title = _tabs[index].Title;
        Logger.Information("Switched to {Title}", Title);
    }
}