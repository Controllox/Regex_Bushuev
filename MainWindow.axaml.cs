using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace Regex_Bushuev;

public partial class MainWindow : Window
{
    public List<Classes.Passport> Passports = new List<Classes.Passport>();
    public static MainWindow init;
    public MainWindow()
    {
        InitializeComponent();
        init = this;
    }
    public void LoadPassport()
    {
        lv_passport.ItemsSource = null;
        lv_passport.ItemsSource = Passports;
    }
    private void Add(object? sender, RoutedEventArgs e) =>
        new Windows.Add(null).ShowDialog(this);
    private async void Update(object? sender, RoutedEventArgs e)
    {
        if (lv_passport.SelectedIndex > -1)
            await new Windows.Add(lv_passport.SelectedItem as Classes.Passport).ShowDialog(this);
        else
            await MessageBox.Show(this, "Выберите элемент для изменения");
    }
    private async void Delete(object? sender, RoutedEventArgs e)
    {
        if (lv_passport.SelectedIndex > -1)
        {
            Passports.Remove(lv_passport.SelectedItem as Classes.Passport);
            LoadPassport();
        }
        else
            await MessageBox.Show(this, "Выберите элемент для удаления");
    }
}