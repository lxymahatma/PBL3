namespace PBL3.ViewModels.Pages;

public sealed class AccountPageViewModel : ViewModelBase, IAccountPageViewModel
{
    [UsedImplicitly]
    public User User { get; init; } = null!;
    
    
}