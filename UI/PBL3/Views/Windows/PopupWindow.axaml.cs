namespace PBL3.Views.Windows;

public sealed partial class PopupWindow : Window
{
    public PopupWindow()
    {
        Closing += (sender, e) => e.Cancel = true;
        InitializeComponent();
    }
}