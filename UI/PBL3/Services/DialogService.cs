namespace PBL3.Services;

public sealed class DialogService : IDialogService
{
    private Func<bool>? _currentClosingCondition;
    private ContentDialog? _currentDialog;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public async Task SwitchDialogAsync(IDialogViewModel viewModel, Func<bool> closingCondition)
    {
        if (_currentDialog is null)
        {
            return;
        }

        _currentDialog.Closing -= OnDialogClosing;
        CloseCurrentDialog();
        await ShowAsync(viewModel, closingCondition).ConfigureAwait(false);
    }

    public Task ShowAsync(IDialogViewModel viewModel, Func<bool> closingCondition)
    {
        _currentDialog = viewModel.DialogSettings;
        _currentClosingCondition = closingCondition;

        _currentDialog.Closing += OnDialogClosing;
        Logger.Information("Showing Dialog: {Dialog}", _currentDialog.Title);
        return _currentDialog.ShowAsync();
    }

    public void CloseCurrentDialog()
    {
        Logger.Information("Closing Dialog: {Dialog}", _currentDialog!.Title);
        _currentDialog.Hide();
    }

    private void OnDialogClosing(ContentDialog sender, ContentDialogClosingEventArgs args) =>
        args.Cancel = !_currentClosingCondition!();
}