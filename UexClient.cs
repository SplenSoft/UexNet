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
    private const string _uriStart = "https://uexcorp.space/api/2.0/";
    private const string _uriGetAllTerminalCommodities = $"{_uriStart}commodities_prices_all";
    private const string _uriGetAllTerminals = $"{_uriStart}terminals";
    private const string _uriGetAllCommodities = $"{_uriStart}commodities";

    private readonly HttpClient _httpClient = new();

    public UexClient(string apiToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", apiToken);
    }

    /// <summary>
    /// Gets all terminals from the UEX API
    /// </summary>
    public async Task<UexListResponse<UexTerminal>?> GetTerminals()
    {
        var task = ListRequest<UexTerminal>(
            _uriGetAllTerminals);

        await task;
        return task.Result;
    }

    /// <summary>
    /// Gets all terminals from the UEX API, casted to a derived 
    /// class of <see cref="UexTerminal"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetTerminals<T>() 
        where T: UexTerminal
    {
        var task = ListRequest<T>(
            _uriGetAllTerminals);

        await task;
        return task.Result;
    }

    /// <summary>
    /// Gets all individual commodity data
    /// </summary>
    public async Task<UexListResponse<UexCommodityData>?> GetCommoditiesData()
    {
        var task = ListRequest<UexCommodityData>(
            _uriGetAllCommodities);

        await task;
        return task.Result;
    }

    /// <summary>
    /// Gets all terminal commodities from the UEX API
    /// </summary>
    public async Task<UexListResponse<UexTerminalCommodity>?> GetCommodities()
    {
        var task = ListRequest<UexTerminalCommodity>(
            _uriGetAllTerminalCommodities);

        await task;
        return task.Result;
    }

    /// <summary>
    /// Gets all terminal commodities from the UEX API, casted 
    /// to a derived class of <see cref="UexTerminalCommodity"/>
    /// </summary>
    public async Task<UexListResponse<T>?> GetCommodities<T>() 
        where T : UexTerminalCommodity
    {
        var task = ListRequest<T>(
            _uriGetAllTerminalCommodities);

        await task;
        return task.Result;
    }

    /// <summary>
    /// Handles API calls that return an array of items
    /// </summary>
    /// <typeparam name="T">Should be a UEX data type</typeparam>
    private async Task<UexListResponse<T>?> ListRequest<T>(string uri)
    {
        var task = _httpClient.GetAsync(uri);
        await task;
        var httpResponse = task.Result;

        if (!httpResponse.IsSuccessStatusCode)
        {
            return new UexListResponse<T>(
                httpResponse, UexRequestResult.HttpError);
        }

        var task2 = httpResponse.Content.ReadAsStringAsync();
        await task2;

        var response = JsonConvert.DeserializeObject<UexListResponse<T>>(task2.Result) ??
            throw new Exception("Unable to deserialize UEX API response");

        return response;

        throw new Exception("Unhandled API response");
    }
}