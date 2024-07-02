namespace EduPath.ViewModels.Pages;

public sealed class AccountPageViewModel : ViewModelBase, IAccountPageViewModel
{
    [UsedImplicitly]
    public User User { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;
}