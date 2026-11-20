using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Regex_Bushuev;

public static class MessageBox
{
    public static Task Show(Window parent, string text, string title = "Ошибка")
    {
        var dialog = new Window
        {
            Title = title,
            Width = 300,
            Height = 130,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        var button = new Button
        {
            Content = "ОК",
            HorizontalAlignment = HorizontalAlignment.Center,
            Width = 80
        };
        button.Click += (_, _) => dialog.Close();

        dialog.Content = new StackPanel
        {
            Margin = new Thickness(15),
            Spacing = 15,
            VerticalAlignment = VerticalAlignment.Center,
            Children =
            {
                new TextBlock { Text = text, HorizontalAlignment = HorizontalAlignment.Center, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                button
            }
        };

        return dialog.ShowDialog(parent);
    }
}