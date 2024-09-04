namespace Module02Exercise01.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login Success!", "Taking you to the Employee Page now.", "OK");


    }
}