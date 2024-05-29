namespace PBL3.ViewModels;

public partial class RegisterWindowViewModel : ViewModelBase, IRegisterWindowViewModel
{
    [ObservableProperty]
    [Required]
    [EmailAddress]
    private string? _email;

    [ObservableProperty]
    [Required]
    [Range(10, 20)]
    private string? _password;


    [ObservableProperty]
    [Required]
    private string? _userName;
}