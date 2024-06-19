using PBL3.ViewModels;

namespace PBL3.Models;

public sealed class Tab(ViewModelBase content, string title)
{
    public ViewModelBase Content { get; set; } = content;
    public string Title { get; set; } = title;

    public static implicit operator Tab(ValueTuple<ViewModelBase, string> tab)
        => new(tab.Item1, tab.Item2);
}