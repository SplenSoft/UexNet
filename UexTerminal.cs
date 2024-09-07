using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SplenSoft.UexNet;

public class UexTerminal : UexData
{
    [JsonProperty("id_star_system")]
    public int? StarSystemId { get; set; }

    [JsonProperty("id_planet")]
    public int? PlanetId { get; set; }

    [JsonProperty("id_orbit")]
    public int? OrbitId { get; set; }

    [JsonProperty("id_moon")]
    public int? MoonId { get; set; }

    [JsonProperty("id_space_station")]
    public int? SpaceStationId { get; set; }

    [JsonProperty("id_outpost")]
    public int? OutpostId { get; set; }

    [JsonProperty("id_poi")]
    public int? PointOfInterestId { get; set; }

    [JsonProperty("id_city")]
    public int? CityId { get; set; }

    [JsonProperty("id_faction")]
    public int? FactionId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("nickname")]
    public string? NickName { get; set; }

    /// <summary>
    /// UEX code
    /// </summary>
    [JsonProperty("code")]
    public string? Code { get; set; }

    /// <summary>
    /// UEX type
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("screenshot")]
    public string? ScreenShotUrl { get; set; }

    [JsonProperty("screenshot_thumbnail")]
    public string? ScreenShotThumbnailUrl { get; set; }

    [JsonProperty("screenshot_author")]
    public string? ScreenShotAuthor { get; set; }

    /// <summary>
    /// Maximum container size operated by freight elevator (in SCU)
    /// </summary>
    [JsonProperty("mcs")]
    public int? MaxContainerSizeFreightElevatorScu { get; set; }

    [JsonProperty("is_available")] // is available in-game
    public bool IsAvailable { get; set; }

    [JsonProperty("is_visible")] // is visible in the UEX website
    public bool IsVisible { get; set; }

    [JsonProperty("is_default_system")] // is the default terminal in a star system
    public bool IsDefaultForStarSystem { get; set; }

    /// <summary>
    /// If terminal data is faction affinity influenced
    /// </summary>
    [JsonProperty("is_affinity_influenceable")]
    public bool IsAffinityInfluenced { get; set; }

    [JsonProperty("is_habitation")]
    public bool IsHabitation { get; set; }

    [JsonProperty("is_refinery")]
    public bool IsRefinery { get; set; }

    [JsonProperty("is_cargo_center")]
    public bool IsCargoCenter { get; set; }

    [JsonProperty("is_medical")]
    public bool IsMedical { get; set; }

    [JsonProperty("is_food")]
    public bool IsFood { get; set; }

    [JsonProperty("is_shop_fps")] // shop trading FPS items
    public bool IsShopFps { get; set; }

    [JsonProperty("is_shop_vehicle")] // shop trading vehicle components
    public bool IsShopVehicle { get; set; }

    [JsonProperty("is_refuel")]
    public bool IsRefuel { get; set; }

    [JsonProperty("is_repair")]
    public bool IsRepair { get; set; }

    [JsonProperty("is_nqa")]
    public bool NoQuestionsAsked { get; set; }

    [JsonProperty("has_loading_dock")]
    public bool HasLoadingDock { get; set; }

    [JsonProperty("has_docking_port")]
    public bool HasDockingPort { get; set; }

    [JsonProperty("has_freight_elevator")]
    public bool HasFreightElevator { get; set; }

    [JsonProperty("star_system_name")]
    public string? StarSystem { get; set; }

    [JsonProperty("planet_name")]
    public string? Planet { get; set; }

    [JsonProperty("orbit_name")]
    public string? Orbit { get; set; }

    [JsonProperty("moon_name")]
    public string? Moon { get; set; }

    [JsonProperty("space_station_name")]
    public string? SpaceStation { get; set; }

    [JsonProperty("outpost_name")]
    public string? Outpost { get; set; }

    [JsonProperty("city_name")]
    public string? City { get; set; }
}
