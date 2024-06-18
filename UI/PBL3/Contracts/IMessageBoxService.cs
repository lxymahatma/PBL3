using MsBox.Avalonia.Enums;

namespace PBL3.Contracts;

public interface IMessageBoxService
{
    Task<ButtonResult> SuccessMessageBox(string title, string content, Icon icon = Icon.Success);

    Task<ButtonResult> ErrorMessageBox(string title, string content, Icon icon = Icon.Error);
    Task<ButtonResult> ErrorMessageBox(string title, Exception exception, Icon icon = Icon.Error);
}