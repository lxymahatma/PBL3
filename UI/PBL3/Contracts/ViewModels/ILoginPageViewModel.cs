namespace PBL3.Contracts.ViewModels;

public interface ILoginPageViewModel
{
    ContentDialogSettings Settings { get; }
    Task<bool> Login();
}