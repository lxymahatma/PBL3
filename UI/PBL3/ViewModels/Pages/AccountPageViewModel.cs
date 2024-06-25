namespace PBL3.ViewModels.Pages;

public sealed partial class AccountPageViewModel : ViewModelBase, IAccountPageViewModel
{
    [UsedImplicitly]
    public User User { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;
}