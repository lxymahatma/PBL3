namespace EduPath.Services;

public sealed class DialogService : IDialogService
{
    private Func<bool>? _currentClosingCondition;
    private ContentDialog? _currentDialog;

    private Dictionary<Type, Func<bool>> ClosingConditionsDict => new()
    {
        { typeof(LoginDialogViewModel), () => UserService.IsLoggedIn },
        { typeof(RegisterDialogViewModel), () => UserService.IsRegistered }
    };

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    public Task ShowAsync(IDialogViewModel viewModel)
    {
        _currentDialog = viewModel.DialogSettings;
        _currentClosingCondition = ClosingConditionsDict[viewModel.GetType()];

        _currentDialog.Closing += OnCurrentDialogClosing;
        Logger.Information("Showing Dialog: {Dialog}", _currentDialog.Content!.GetType().Name[..^15]);
        return _currentDialog.ShowAsync();
    }

    public Task ShowAsync(IDialogViewModel viewModel, Func<bool> closingCondition)
    {
        _currentDialog = viewModel.DialogSettings;
        _currentClosingCondition = closingCondition;

        _currentDialog.Closing += OnCurrentDialogClosing;
        Logger.Information("Showing Dialog: {Dialog}", _currentDialog.Content!.GetType().Name[..^15]);
        return _currentDialog.ShowAsync();
    }

    public async Task SwitchDialogAsync(IDialogViewModel viewModel)
    {
        if (_currentDialog is null)
        {
            return;
        }

        _currentDialog.Closing -= OnCurrentDialogClosing;
        CloseCurrentDialog();
        await ShowAsync(viewModel).ConfigureAwait(false);
    }

    public async Task SwitchDialogAsync(IDialogViewModel viewModel, Func<bool> closingCondition)
    {
        if (_currentDialog is null)
        {
            return;
        }

        _currentDialog.Closing -= OnCurrentDialogClosing;
        CloseCurrentDialog();
        await ShowAsync(viewModel, closingCondition).ConfigureAwait(false);
    }

    public void CloseCurrentDialog()
    {
        Logger.Information("Closing Dialog: {Dialog}", _currentDialog!.Content!.GetType().Name[..^15]);
        _currentDialog.Hide();
    }

    private void OnCurrentDialogClosing(ContentDialog sender, ContentDialogClosingEventArgs args) =>
        args.Cancel = !_currentClosingCondition!();
}