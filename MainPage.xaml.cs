using Newtonsoft.Json;
using Octokit.Internal;
using Refit;
using System.Text.Json.Serialization;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void rollAnimal(object sender, EventArgs e)
        {
            string url = "https://some-random-api.com/animal/cat";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Fact newFact = JsonConvert.DeserializeObject<Fact>(json);

                animalImage.Source = newFact.image;
                factLabel.Text = newFact.fact;
            }

        }

    }
    internal class Fact
    {
        public string image { get; set; }
        public string fact { get; set; }
    }
}
