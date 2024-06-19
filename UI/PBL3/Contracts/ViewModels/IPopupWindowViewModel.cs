namespace PBL3.Contracts.ViewModels;

public interface IPopupWindowViewModel : IModalDialogViewModel
{
    void SwitchTab(int index);
}