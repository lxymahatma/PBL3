namespace PBL3.Contracts;

public interface IDialogService
{
    void HideCurrentDialog();
    Task ShowAsync(IDialogViewModel viewModel);
}