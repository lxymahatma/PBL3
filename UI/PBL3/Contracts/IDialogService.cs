namespace PBL3.Contracts;

public interface IDialogService
{
    Task ShowAsync(IDialogViewModel viewModel);
}