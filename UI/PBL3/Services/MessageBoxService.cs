using Avalonia.Controls.ApplicationLifetimes;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;

namespace PBL3.Services;

public sealed class MessageBoxService : IMessageBoxService
{
    public Task<ButtonResult> SuccessMessageBox(string title, string content, Icon icon = Icon.Success) => MessageBox(title, content, icon);

    public Task<ButtonResult> ErrorMessageBox(string title, string content, Icon icon = Icon.Error) => MessageBox(title, content, icon);

    public Task<ButtonResult> ErrorMessageBox(string title, Exception exception, Icon icon = Icon.Error) => MessageBox(title, exception.Message, icon);

    private async Task<ButtonResult> MessageBox(string title, string content, Icon icon, ButtonEnum button = ButtonEnum.Ok)
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
        return isMainWindow ? await messageBox.ShowWindowDialogAsync(desktop!.MainWindow) : await messageBox.ShowAsync();
    }
}