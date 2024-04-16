using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JetBrains.Annotations;
using PBL3.Contracts;
using Serilog;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace PBL3.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [UsedImplicitly]
    public ILogger Logger { get; init; }

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }
}