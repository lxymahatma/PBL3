using MsBox.Avalonia.Enums;

namespace PBL3.Contracts;

public interface IMessageBoxService
{
    Task<ButtonResult> Success(string content, Icon icon = Icon.Success);
    Task<ButtonResult> Success(string title, string content, Icon icon = Icon.Success);

    Task<ButtonResult> Error(string content, Icon icon = Icon.Error);
    Task<ButtonResult> Error(string title, string content, Icon icon = Icon.Error);
    Task<ButtonResult> Error(string title, Exception exception, Icon icon = Icon.Error);
}