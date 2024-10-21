using Microsoft.Extensions.Configuration;
using StockAssignment.ServiceContracts;
using System.Text.Json;

namespace StockAssignment.Service;
public class FinnhubService : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string? stockSymbol)
    {
        if (string.IsNullOrEmpty(stockSymbol))
            stockSymbol = _configuration.GetValue<string>("DefaultStockSymbol");
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration.GetValue<string>("SecretToken")}"
           );

        return new Dictionary<string, object>
            {
               {"country", "US" },
               {"currency", "USD" },
               {"estimateCurrency", "USD" },
               {"exchange", "NASDAQ NMS - GLOBAL MARKET" },
               {"finnhubIndustry", "Technology" },
               {"ipo", "1980-12-12" },
               {"logo", "https://static2.finnhub.io/file/publicdatany/finnhubimage/stock_logo/AAPL.png" },
               {"marketCapitalization", 3441760.3551107626 },
               {"name", "Apple Inc" },
               {"phone", "14089961010" },
               {"shareOutstanding", 15204.14 },
               {"ticker", "AAPL" },
               {"weburl", "https://www.apple.com/" }
            };
        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(contentStream);
            string responseValue = reader.ReadToEnd();
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseValue)))
            {
               return await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stream);
            }
        }
        else
        {
            return new Dictionary<string, object>
            {
               {"country", "US" },
               {"currency", "USD" },
               {"estimateCurrency", "USD" },
               {"exchange", "NASDAQ NMS - GLOBAL MARKET" },
               {"finnhubIndustry", "Technology" },
               {"ipo", "1980-12-12" },
               {"logo", "https://static2.finnhub.io/file/publicdatany/finnhubimage/stock_logo/AAPL.png" },
               {"marketCapitalization", 3441760.3551107626 },
               {"name", "Apple Inc" },
               {"phone", "14089961010" },
               {"shareOutstanding", 15204.14 },
               {"ticker", "AAPL" },
               {"weburl", "https://www.apple.com/" }
            };
        }
        return null;
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string? stockSymbol)
    {
        if (string.IsNullOrEmpty(stockSymbol))
            stockSymbol = _configuration.GetValue<string>("DefaultStockSymbol");
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration.GetValue<string>("SecretToken")}"
           );

        return new Dictionary<string, object>
            {
                { "c", 226.37 },
                { "d", -1 },
                { "dp", -0.4398 },
                { "h", 227.29 },
                { "l", 224.02 },
                { "o", 224.93 },
                { "pc", 227.37 },
                { "t", 1727308800 }
            };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            var quotes = await JsonSerializer.DeserializeAsync<object>(contentStream);
        }
        else
        {
            return new Dictionary<string, object>
            {
                { "c", 226.37 },
                { "d", -1 },
                { "dp", -0.4398 },
                { "h", 227.29 },
                { "l", 224.02 },
                { "o", 224.93 },
                { "pc", 227.37 },
                { "t", 1727308800 }
            };
        }
        return null;
    }
}
