using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplenSoft.UexNet;

/// <summary>
/// A good that can be bought and sold. Exists at a 
/// <see cref="UexTerminal"/>
/// </summary>
internal class UexTerminalCommodity : UexData
{
    [JsonProperty("id_commodity")]
    public int CommodityId { get; set; }

    [JsonProperty("id_terminal")]
    public int TerminalId { get; set; }

    [JsonProperty("price_buy")]
    public double BuyPriceLastReported { get; set; }

    [JsonProperty("price_buy_avg")]
    public double BuyPriceAverage { get; set; }

    [JsonProperty("price_sell")]
    public double SellPriceLastReported { get; set; }

    [JsonProperty("price_sell_avg")]
    public double SellPriceAverage { get; set; }

    [JsonProperty("scu_sell_stock")]
    public double SupplyLastReported { get; set; }

    [JsonProperty("scu_sell_stock_avg")]
    public double SupplyAverage { get; set; }

    [JsonProperty("scu_sell")]
    public double DemandLastReported { get; set; }

    [JsonProperty("scu_sell_avg")]
    public double DemandAverage { get; set; }

    [JsonProperty("status_buy")]
    public int StatusBuy { get; set; }

    [JsonProperty("status_sell")]
    public int StatusSell { get; set; }

    [JsonProperty("commodity_name")]
    public string? Name { get; set; }

    [JsonProperty("terminal_name")]
    public string? TerminalName { get; set; }

    [JsonProperty("terminal_code")]
    public string? TerminalCode { get; set; }

    [JsonProperty("terminal_slug")]
    public string? TerminalSlug { get; set; }

    /// <summary>
    /// UEX commodity code
    /// </summary>
    [JsonProperty("commodity_code")]
    public string? Code { get; set; }

    /// <summary>
    /// UEX URL slug
    /// </summary>
    [JsonProperty("commodity_slug")]
    public string? Slug { get; set; }
}