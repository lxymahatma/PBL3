namespace PBL3.Services;

public sealed class DialogService : IDialogService
{
    private ContentDialog _currentDialog = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public void HideCurrentDialog()
    {
        Logger.Information("Hiding Dialog: {Dialog}", _currentDialog.Title);
        _currentDialog.Hide();
    }

    public async Task ShowAsync(IDialogViewModel viewModel)
    {
        _currentDialog = viewModel.GetDialogSettings();
        Logger.Information("Showing Dialog: {Dialog}", _currentDialog.Title);
        await _currentDialog.ShowAsync();
    }
}