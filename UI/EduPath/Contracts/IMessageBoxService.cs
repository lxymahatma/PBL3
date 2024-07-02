using MsBox.Avalonia.Enums;

namespace EduPath.Contracts;

public interface IMessageBoxService
{
    Task<ButtonResult> SuccessAsync(string content, Icon icon = Icon.Success);
    Task<ButtonResult> SuccessAsync(string title, string content, Icon icon = Icon.Success);

    Task<ButtonResult> ErrorAsync(string content, Icon icon = Icon.Error);
    Task<ButtonResult> ErrorAsync(string title, string content, Icon icon = Icon.Error);
    Task<ButtonResult> ErrorAsync(string title, Exception exception, Icon icon = Icon.Error);
}