namespace EduPath.Contracts;

public interface IDialogService
{
    void CloseCurrentDialog();
    Task ShowAsync(IDialogViewModel viewModel);
    Task ShowAsync(IDialogViewModel viewModel, Func<bool> closingCondition);
    Task SwitchDialogAsync(IDialogViewModel viewModel);
    Task SwitchDialogAsync(IDialogViewModel viewModel, Func<bool> closingCondition);
}