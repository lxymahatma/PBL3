using Avalonia.Controls.ApplicationLifetimes;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;

namespace EduPath.Services;

public sealed class MessageBoxService : IMessageBoxService
{
    public Task<ButtonResult> SuccessAsync(string content, Icon icon = Icon.Success) => MessageBoxAsync("Success", content, icon);
    public Task<ButtonResult> SuccessAsync(string title, string content, Icon icon = Icon.Success) => MessageBoxAsync(title, content, icon);
    public Task<ButtonResult> ErrorAsync(string content, Icon icon = Icon.Error) => MessageBoxAsync("Error", content, icon);
    public Task<ButtonResult> ErrorAsync(string title, string content, Icon icon = Icon.Error) => MessageBoxAsync(title, content, icon);
    public Task<ButtonResult> ErrorAsync(string title, Exception exception, Icon icon = Icon.Error) => MessageBoxAsync(title, exception.Message, icon);

    private static Task<ButtonResult> MessageBoxAsync(string title, string content, Icon icon, ButtonEnum button = ButtonEnum.Ok)
    {
        var desktop = Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        var isMainWindow = desktop?.MainWindow is not null;
        var messageBox = MessageBoxManager
            .GetMessageBoxStandard(new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = content,
                ButtonDefinitions = button,
                Icon = icon,
                Topmost = true,
                WindowStartupLocation = isMainWindow ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            });
        return isMainWindow ? messageBox.ShowWindowDialogAsync(desktop!.MainWindow) : messageBox.ShowAsync();
    }
}