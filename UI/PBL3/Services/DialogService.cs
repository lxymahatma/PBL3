namespace PBL3.Services;

public sealed class DialogService : IDialogService
{
    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public async Task ShowAsync(IDialogViewModel viewModel)
    {
        Logger.Information("Showing dialog {Dialog}", viewModel.Settings.Title);
        await viewModel.Settings.ShowAsync();
    }
}