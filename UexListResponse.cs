using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SplenSoft.UexNet;

public class UexListResponse<T> : UexApiResponse
{
    public UexListResponse() { }

    public UexListResponse(
        HttpResponseMessage httpResponse,
        UexRequestResult requestResult)
        : base(httpResponse, requestResult) { }

    public List<T> List { get; set; } = [];

    [JsonProperty("data")]
    private JArray? JArrayData { get; set; }

    public List<T>? Data { get; private set; }

    [OnDeserialized]
    protected new void OnDeserialized(StreamingContext context)
    {
        base.OnDeserialized(context);

        if (JArrayData == null)
        {
            throw new Exception(
                "API response data was null");
        }

        Data = JArrayData.ToObject<List<T>>() ??
            throw new Exception($"Couldn't deserialize Jarray");
    }
}