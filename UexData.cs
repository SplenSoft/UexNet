using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SplenSoft.UexNet;

public abstract class UexData
{
    /// <summary>
    /// Presumably UTC
    /// </summary>
    [JsonIgnore]
    public DateTime DateAdded { get; set; }

    /// <summary>
    /// Presumably UTC
    /// </summary>
    [JsonIgnore]
    public DateTime DateModified { get; set; }

    /// <summary>
    /// Unix timestamp, presumably UTC
    /// </summary>
    [JsonProperty("date_modified")]
    protected int DateModifiedUnix { get; set; }

    /// <summary>
    /// Unix timestamp, presumably UTC
    /// </summary>
    [JsonProperty("date_added")]
    protected int DateAddedUnix { get; set; }

    [OnDeserialized]
    protected void OnDeserialized(StreamingContext context)
    {
        // Get DateTimes from unix timestamps
        DateModified = DateTimeOffset
            .FromUnixTimeSeconds(DateModifiedUnix).UtcDateTime;

        DateAdded = DateTimeOffset
            .FromUnixTimeSeconds(DateAddedUnix).UtcDateTime;
    }
}