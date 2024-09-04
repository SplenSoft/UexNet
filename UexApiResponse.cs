using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SplenSoft.UexNet;

public class UexApiResponse
{
    public UexApiResponse() { }

    public UexApiResponse(
        HttpResponseMessage httpResponse, 
        UexRequestResult requestResult) 
    {
        HttpReponse = httpResponse;
        RequestResult = requestResult;
    }

    [JsonProperty("status")]
    protected string? Status { get; set; }

    [JsonProperty("http_code")]
    public int? HttpCode { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonIgnore]
    public bool Success => Status == "ok";

    [JsonIgnore]
    public HttpResponseMessage? HttpReponse { get; set; }

    [JsonIgnore]
    public UexRequestResult RequestResult { get; private set; }

    [OnDeserialized]
    protected void OnDeserialized(StreamingContext context)
    {
        if (Status == "error")
        {
            RequestResult = UexRequestResult.InternalServerError;
        }
        else if (Status == "example_code")
        {
            RequestResult = UexRequestResult.InvalidRequest;
        }
        else if (Status == "requests_limit_reached")
        {
            RequestResult = UexRequestResult.ApiLimitReached;
        }
    }
}