namespace PBL3.ViewModels.Windows;

public sealed partial class PopupWindowViewModel : ViewModelBase, IPopupWindowViewModel
{
    [ObservableProperty]
    private string? _title = "Login";

    public bool? DialogResult { get; } = null;
}