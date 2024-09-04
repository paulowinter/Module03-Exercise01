using System.Diagnostics;
using Module02Exercise01.View;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using System.Net.Http;


namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://reqbin.com/";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = new LoginPage();
                Debug.WriteLine("Application Started");
            }
            else
            {
                MainPage = new OfflinePage();
                Debug.WriteLine("No internet connection or website unreachable");
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
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
}
