using System.Text.RegularExpressions;

namespace Figma_zadanie_z_zadaniami;

public partial class LoginPage : ContentPage
{
	private LoginFormModel LoginModel { get; set; }
	public LoginPage()
	{
		InitializeComponent();
		LoginModel = new LoginFormModel();
		BindingContext = LoginModel;
	}

	private async void LoginButtonClicked(object sender, EventArgs e)
	{
		string email = LoginModel.Email.Trim() ?? "";
        string password = LoginModel.Password ?? "";

		if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
		{
            await DisplayAlert("Error", "Wpisz login i has³o", "OK");
        }
		if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
		{
            await DisplayAlert("Error", "Wpisz poprawny email", "OK");
        }
		if (email == "x@gmail.com" && password == "x")
		{
			await Shell.Current.GoToAsync("//MainPage");
		}
		else
		{
			await DisplayAlert("Error", "Z³y login lub has³o", "OK");
		}
    }
}