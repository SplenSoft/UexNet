using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace SplenSoft.UexNet;

public class UexClient
{
    public UexClient(string apiToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", apiToken);
    }

    private const string _uriStart = "https://uexcorp.space/api/2.0/";

    private static Dictionary<Type, string> _urisByType = new()
    {
        {typeof(UexTerminalCommodity), $"{_uriStart}commodities_prices_all" },
        {typeof(UexCommodityData), $"{_uriStart}commodities" },
        {typeof(UexTerminal), $"{_uriStart}terminals" },
        {typeof(UexVehicle), $"{_uriStart}vehicles" },
    };

    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Handles API calls that return an array of items
    /// </summary>
    /// <typeparam name="T">Should be a UEX data type</typeparam>
    private async Task<UexListResponse<T>?> ListRequest<T>(string uri) 
        where T : UexData
    {
        var httpResponse = await _httpClient.GetAsync(uri);

        if (!httpResponse.IsSuccessStatusCode)
        {
            // Likely bad internet connection or bad API key
            return new UexListResponse<T>(
                httpResponse, UexRequestResult.HttpError);
        }

        string content = await httpResponse.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<UexListResponse<T>>(
            content) ?? new UexListResponse<T>() 
            { 
                Message = content,
                RequestResult = UexRequestResult.DeserializationError
            };
    }

    /// <summary>
    /// Handles API calls that return an array of items. 
    /// Automatically supplies a URI based on type / parent type
    /// </summary>
    /// <typeparam name="T">Should be a UEX data type</typeparam>
    public async Task<UexListResponse<T>?> ListRequest<T>()
        where T : UexData
    {
        List<Type> typesToTest = [];
        typesToTest.Add(typeof(T));
        Type? curentBase = typeof(T).BaseType;
        while (curentBase != null) 
        {
            typesToTest.Add(curentBase);
            curentBase = curentBase.BaseType;
        }

        foreach (var type in typesToTest)
        {
            if (_urisByType.TryGetValue(type, out string uri))
            {
                return await ListRequest<T>(uri);
            }
        }
        
        throw new Exception($"Unhandled type {typeof(T)}");
    }
}