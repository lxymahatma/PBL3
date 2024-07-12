using System.Diagnostics;

namespace EduPath.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private const string AcademicCalendarLink =
        "https://ct.ritsumei.ac.jp/ct/page_4654056c1728174_270491135_2151375553/%E3%80%90%E5%AD%A6%E4%BF%AE%E8%A6%81%E8%A6%A7%E3%80%91%E6%83%85%E5%A0%B1%E7%90%86%E5%B7%A5%E5%AD%A6%E9%83%A8%E3%83%BB%E8%8B%B1%E8%AA%9E%EF%BC%882024%EF%BC%89.pdf";

    [ObservableProperty]
    private NavigationViewItem _selected = null!;

    public NavigationViewItem[] MenuItems { get; } =
    [
        new NavigationViewItem { Content = "Home", IconSource = new SymbolIconSource { Symbol = Symbol.Home } },
        new NavigationViewItem { Content = "Account", IconSource = new SymbolIconSource { Symbol = Symbol.OtherUser } },
        new NavigationViewItem { Content = "Open Academic Calendar", IconSource = new SymbolIconSource { Symbol = Symbol.Calendar } }
    ];

    public Frame ContentFrame => NavigationService.ContentFrame;

    public void SwitchItem(int index) => Selected = MenuItems[index];

    [RelayCommand]
    private Task OpenLoginPageAsync() => DialogService.ShowAsync(LoginDialogViewModel);

    partial void OnSelectedChanged(NavigationViewItem value)
    {
        switch (value.Content)
        {
            case "Home":
                NavigationService.NavigateToWithoutNotify<HomePage>();
                break;
            case "Account":
                NavigationService.NavigateToWithoutNotify<AccountPage>();
                break;
            case "Open Academic Calendar":
                Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = AcademicCalendarLink
                });
                NavigationService.NavigateTo<HomePage>();
                break;
        }
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    [UsedImplicitly]
    public INavigationService NavigationService { get; init; } = null!;

    #endregion
}