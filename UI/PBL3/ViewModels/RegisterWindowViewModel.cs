namespace PBL3.ViewModels;

public partial class RegisterWindowViewModel : ViewModelBase, IRegisterWindowViewModel
{
    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private string? _password;

    [ObservableProperty]
    private string? _userName;
}