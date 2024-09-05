namespace SplenSoft.UexNet;

/// <summary>
/// Status readout of a <see cref="UexApiResponse"/>
/// </summary>
public enum UexRequestResult
{
    Success,
    InternalServerError,
    InvalidRequest,
    ApiLimitReached,

    /// <summary>
    /// Something went wrong while attempting to contact the 
    /// server. Possible issues - invalid API key, no internet 
    /// connection. To debug, check the <see cref="UexApiResponse
    /// .HttpReponse"/> property
    /// </summary>
    HttpError,

    /// <summary>
    /// Something went wrong while deserializing the response 
    /// content with <see cref="Newtonsoft.Json.JsonConvert
    /// .DeserializeObject(string)"/>. To debug, check the 
    /// <see cref="UexApiResponse.Message"/> property of the 
    /// result object for the unserialized string
    /// </summary>
    DeserializationError
}