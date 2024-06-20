namespace PBL3.Contracts.ViewModels;

public interface IRegisterPageViewModel
{
    ContentDialogSettings Settings { get; }
    Task<bool> Register();
}