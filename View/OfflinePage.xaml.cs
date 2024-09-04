using System.Diagnostics;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module02Exercise01.View;

public partial class OfflinePage : ContentPage
{
    private const string OnlineUrl = "https://google.com/";
    public OfflinePage()
	{
		InitializeComponent();
	}

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private async void OnRetryButtonClicked(object sender, EventArgs e)
    {
        var current = Connectivity.NetworkAccess;

        bool isWebsiteReachable = await IsWebsiteReachable(OnlineUrl);

        if (current == NetworkAccess.Internet && isWebsiteReachable)
        {
            await DisplayAlert("Connection Success!", "Taking you to the Login Page now.", "OK");
            Application.Current.MainPage = new LoginPage();
        }
        else
        {
            await DisplayAlert("You're currently offline!", "Please try again later.", "OK");
        }
    }

    private async Task<bool> IsWebsiteReachable(string url)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception in IsWebsiteReachable: {ex.Message}");
            return false;
        }
    }
}