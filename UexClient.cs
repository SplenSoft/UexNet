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
    /// Gets all terminals from the UEX API
    /// </summary>
    public async Task<UexListResponse<UexTerminal>?> GetTerminals()
        => await GetTerminals<UexTerminal>();

    /// <summary>
    /// Gets all terminals from the UEX API, casted to a derived 
    /// class of <see cref="UexTerminal"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetTerminals<T>() 
        where T : UexTerminal
        => await ListRequest<T>();

    /// <summary>
    /// Gets all individual commodity data
    /// </summary>
    public async Task<UexListResponse<UexCommodityData>?> GetCommoditiesData()
        => await GetCommoditiesData<UexCommodityData>();

    /// <summary>
    /// Gets all individual commodity data, casted to a derived 
    /// class of <see cref="UexCommodityData"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetCommoditiesData<T>() 
        where T : UexCommodityData
        => await ListRequest<T>();

    /// <summary>
    /// Gets all terminal commodities from the UEX API
    /// </summary>
    public async Task<UexListResponse<UexTerminalCommodity>?> GetCommodities()
        => await GetCommodities<UexTerminalCommodity>();

    /// <summary>
    /// Gets all terminal commodities from the UEX API, casted 
    /// to a derived class of <see cref="UexTerminalCommodity"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetCommodities<T>() 
        where T : UexTerminalCommodity
        => await ListRequest<T>();

    /// <summary>
    /// Gets all vehicles from the UEX API
    /// </summary>
    public async Task<UexListResponse<UexVehicle>?> GetVehicles()
        => await GetVehicles<UexVehicle>();

    /// <summary>
    /// Gets all vehicles from the UEX API, casted 
    /// to a derived class of <see cref="UexVehicle"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetVehicles<T>()
        where T : UexVehicle
        => await ListRequest<T>();

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
        if (!_urisByType.TryGetValue(typeof(T), out string uri)) 
        {
            throw new Exception($"Unhandled type {typeof(T)}");
        }

        return await ListRequest<T>(uri);
    }
}