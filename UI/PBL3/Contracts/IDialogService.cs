namespace PBL3.Contracts;

public interface IDialogService
{
    Task SwitchDialogAsync(IDialogViewModel viewModel, Func<bool> closingCondition);
    Task ShowAsync(IDialogViewModel viewModel, Func<bool> closingCondition);
}