using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SplenSoft.UexNet;

public class UexCommodityData : UexData
{
    // Regex for substitution: ^(\w)([A-Za-z0-9]+)(_)?(\w)?([A-Za-z0-9]+)?\s*(\w+)(?:\(\d+\))?\s*(\/\/.*)?$
    // substitution: [JsonProperty("$1$2$3$4$5")] $7\npublic $6 \U$1\E$2\U$4\E$5 { get; set; }
    // https://regex101.com/r/BlSvyx/1

    [JsonProperty("id_parent")]
    public int IdParent { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("code")] // UEX commodity code
    public string? Code { get; set; }

    [JsonProperty("slug")] // UEX URL slug
    public string? Slug { get; set; }

    [JsonProperty("kind")]
    public string? Kind { get; set; }

    [JsonProperty("price_buy")] // average market price per SCU
    public float PriceBuy { get; set; }

    [JsonProperty("price_sell")] // average market price per SCU
    public float PriceSell { get; set; }

    [JsonProperty("is_available")] // available in-game
    public bool IsAvailable { get; set; }

    /// <summary>
    /// Visible on the UEX website
    /// </summary>
    [JsonProperty("is_visible")]
    public bool IsVisible { get; set; }

    [JsonProperty("is_raw")]
    public bool IsRaw { get; set; }

    [JsonProperty("is_refined")]
    public bool IsRefined { get; set; }

    [JsonProperty("is_mineral")]
    public bool IsMineral { get; set; }

    [JsonProperty("is_harvestable")]
    public bool IsHarvestable { get; set; }

    [JsonProperty("is_buyable")]
    public bool IsBuyable { get; set; }

    [JsonProperty("is_sellable")]
    public bool IsSellable { get; set; }

    [JsonProperty("is_temporary")]
    public bool IsTemporary { get; set; }

    /// <summary>
    /// If the commodity is restricted in one or more jurisdictions
    /// </summary>
    [JsonProperty("is_illegal")]
    public bool IsIllegal { get; set; }

    [JsonProperty("wiki")]
    public string? Wiki { get; set; }
}
