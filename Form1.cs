using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Identity;
using Azure.Maps.Search;
using DotNetEnv;

namespace First_Windows_Form_CSharp_
{
    public partial class Form1 : Form
    {
        private const string WeatherApiUrl = "https://api.weather.gov/";
        private readonly HttpClient httpClient;

        private Dictionary<string, string> stateCapitals;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task GetWeatherData(double latitude, double longitude)
        {
            try
            {
                Uri uri = new Uri($"{WeatherApiUrl}points/{latitude},{longitude}");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

                // Set the User-Agent header to identify your application
                httpClient.DefaultRequestHeaders.Add("User-Agent", "First_Windows_Form_CSharp_ (rwdorrington@gmail.com)");

                HttpResponseMessage response = await httpClient.SendAsync(request);

                Debug.WriteLine("API URL: " + uri);  // Debugging output

                Debug.WriteLine("Response Status: " + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic jsonData = JsonConvert.DeserializeObject(content);
                    string forecastHourlyUrl = jsonData.properties.forecastHourly;


                    HttpResponseMessage hourlyForecastResponse = await httpClient.GetAsync(forecastHourlyUrl);

                    if (hourlyForecastResponse.IsSuccessStatusCode)
                    {
                        string hourlyForecastContent = await hourlyForecastResponse.Content.ReadAsStringAsync();
                        JObject hourlyForecastJson = JObject.Parse(hourlyForecastContent);
                        JArray periodsArray = (JArray)hourlyForecastJson["properties"]["periods"];

                        if (periodsArray.Count > 0)
                        {
                            JObject firstPeriod = (JObject)periodsArray[0];
                            int temperature = (int)firstPeriod["temperature"];
                            string weatherType = (string)firstPeriod["shortForecast"];

                            TestTextBox.Text = $"Temperature: {temperature}°F\r\nWeather Type: {weatherType}";

                            // get current directory
                            var root = Directory.GetCurrentDirectory();

                            Debug.WriteLine(root);

                            switch (weatherType)
                            {
                                case string s when s.Contains("Sunny"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\clear.png");
                                    break;
                                case string s when s.Contains("Thunderstorm"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\thunderstorms.png");
                                    break;
                                case string s when s.Contains("Rain"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\rain.png");
                                    break;
                                case string s when s.Contains("Snow"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\snow.png");
                                    break;
                                case string s when s.Contains("Cloudy"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\cloudy.png");
                                    break;
                                case string s when s.Contains("Fog"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\fog.png");
                                    break;
                                case string s when s.Contains("Partly Cloudy"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\partly-cloudy.png");
                                    break;
                                case string s when s.Contains("Haze"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\haze.png");
                                    break;
                                case string s when s.Contains("Windy"):
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\windy.png");
                                    break;
                                default:
                                    WeatherIcon.Image = Image.FromFile("weather-icons\\clear.png");
                                    break;
                            }
                        }
                        else
                        {
                            TestTextBox.Text = "No hourly forecast data available.";
                        }
                    }
                    else
                    {
                        string errorMessage = $"Failed to fetch hourly forecast data. Status Code: {hourlyForecastResponse.StatusCode}";
                        TestTextBox.Text = errorMessage;
                        Debug.WriteLine(errorMessage);
                    }
                }
                else
                {
                    string errorMessage = $"Failed to fetch weather data. Status Code: {response.StatusCode}";
                    TestTextBox.Text = errorMessage;
                    Debug.WriteLine(errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                TestTextBox.Text = $"HTTP request error: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                TestTextBox.Text = $"An error occurred: {ex.Message}";
            }
        }
        private async Task<(double, double)> GeocodeAsync(string state, string city)
        {
            try
            {

                var root = Directory.GetCurrentDirectory();
                var dotenv = Path.Combine(root, "stuff.env");

                Env.Load(dotenv);

                string subscriptionKey = System.Environment.GetEnvironmentVariable("SUBSCRIPTION_KEY");
                string clientId = System.Environment.GetEnvironmentVariable("CLIENT_ID");
                var credential = new DefaultAzureCredential();
                var client = new MapsSearchClient(credential, clientId);

                // Construct the Geocoding API U
                string apiUrl = $"https://atlas.microsoft.com/search/address/json?api-version=1.0&subscription-key={subscriptionKey}&query={city},{state}";

                Debug.WriteLine(apiUrl);


                using (HttpClient httpClient = new HttpClient())
                {
                    // Make the API request using HttpClient
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        Debug.WriteLine(jsonContent);

                        // Deserialize the JSON response
                        dynamic data = JsonConvert.DeserializeObject(jsonContent);

                        // Parse the response and extract the coordinates
                        double latitude = data.results[0].position.lat;
                        double longitude = data.results[0].position.lon;

                        // Use the coordinates for your application logic
                        Debug.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");

                        // return the coordinates
                        return (latitude, longitude);
                    }
                    else
                    {

                        Console.WriteLine($"Error: {response.ReasonPhrase}");

                        // return default coordinates
                        return (0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                // return default coordinates
                return (0, 0);
            }
        }
        private async void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                submitButton.Enabled = false;
                string city = comboBoxCities.Text;
                string state = comboBoxStates.Text;

                TestTextBox.Text = $"City: {city}\r\nState: {state}";
                TestTextBox.Refresh();

                (double latitude, double longitude) = await GeocodeAsync(state, city);

                if (latitude != 0 && longitude != 0)
                {
                    await GetWeatherData(latitude, longitude);
                }
                else
                {
                    TestTextBox.Text = "Failed to get coordinates for the specified location.";
                }

            }
            finally
            {
                submitButton.Enabled = true;
            }
        }
    }
}