using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Regex_Bushuev.Windows;

public partial class Add : Window
{
    public Classes.Passport EditPassports;
    public Add()
    {
        InitializeComponent();
    }
    public Add(Classes.Passport EditPassports)
    {
        InitializeComponent();

        if (EditPassports != null)
        {
            Name.Text = EditPassports.Name;
            FirstName.Text = EditPassports.FirstName;
            LastName.Text = EditPassports.LastName;
            Issued.Text = EditPassports.Issued;
            DateOfIssued.Text = EditPassports.DateOfIssued;
            DepartmentCode.Text = EditPassports.DepartmentCode;
            SeriesAndNumber.Text = EditPassports.SeriesAndNumber;
            DateOfBirth.Text = EditPassports.DateOfBirth;
            PlaceOfBirth.Text = EditPassports.PlaceOfBirth;

            this.EditPassports = EditPassports;
            BthAdd.Content = "Изменить";
        }
    }
    private async void AddPassport(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Name.Text) || !Regex_Bushuev.Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", Name.Text))
        {
            await MessageBox.Show(this, "Не правильно указано имя пользователя");
            return;
        }

        if (string.IsNullOrEmpty(FirstName.Text) || !Regex_Bushuev.Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", FirstName.Text))
        {
            await MessageBox.Show(this, "Не правильно указано фамилия пользователя");
            return;
        }

        if (string.IsNullOrEmpty(LastName.Text) || !Regex_Bushuev.Classes.Common.CheckRegex.Match("^[а-яА-Я]*$", LastName.Text))
        {
            await MessageBox.Show(this, "Не правильно указано отчество пользователя");
            return;
        }

        if (EditPassports == null)
        {
            EditPassports = new Classes.Passport();
            MainWindow.init.Passports.Add(EditPassports);
        }
        EditPassports.Name = Name.Text;
        EditPassports.FirstName = FirstName.Text;
        EditPassports.LastName = LastName.Text;
        EditPassports.Issued = Issued.Text;
        EditPassports.DateOfIssued = DateOfIssued.Text;
        EditPassports.DepartmentCode = DepartmentCode.Text;
        EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
        EditPassports.DateOfBirth = DateOfBirth.Text;
        EditPassports.PlaceOfBirth = PlaceOfBirth.Text;
        MainWindow.init.LoadPassport();
        this.Close();
    }
}