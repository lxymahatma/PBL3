namespace PBL3.Contracts.ViewModels;

public interface ILoginPageViewModel
{
    ContentDialogSettings Settings { get; }
    bool Login();
}