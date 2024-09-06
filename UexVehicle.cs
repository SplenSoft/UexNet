using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplenSoft.UexNet;

public class UexVehicle : UexData
{
    // vehicle manufacturer
    [JsonProperty("id_company")]
    public int CompanyId { get; set; }

    // parent ship series
    [JsonProperty("id_parent")]
    public int ParentCompany { get; set; }

    // vehicles loaned, comma separated
    [JsonProperty("ids_vehicles_loaners")]
    public string? LoanerVehicles { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("name_full")]
    public string? NameFull { get; set; }

    [JsonProperty("scu")]
    public int CargoCapacityScu { get; set; }

    [JsonProperty("crew")]
    public string? CrewSize { get; set; }

    /// <summary>
    /// e.g. RSI Galaxy Refinery Module
    /// </summary>
    [JsonProperty("is_addon")]
    public bool IsAddon { get; set; }

    [JsonProperty("is_concept")]
    public bool IsConcept { get; set; }

    [JsonProperty("is_civilian")]
    public bool IsCivilian { get; set; }

    [JsonProperty("is_military")]
    public bool IsMilitary { get; set; }

    [JsonProperty("is_exploration")]
    public bool IsExploration { get; set; }

    [JsonProperty("is_passenger")]
    public bool IsPassenger { get; set; }

    [JsonProperty("is_industrial")]
    public bool IsIndustrial { get; set; }

    [JsonProperty("is_mining")]
    public bool IsMining { get; set; }

    [JsonProperty("is_salvage")]
    public bool IsSalvage { get; set; }

    [JsonProperty("is_refinery")]
    public bool IsRefinery { get; set; }

    [JsonProperty("is_scanning")]
    public bool IsScanning { get; set; }

    [JsonProperty("is_cargo")]
    public bool IsCargo { get; set; }

    [JsonProperty("is_medical")]
    public bool IsMedical { get; set; }

    [JsonProperty("is_racing")]
    public bool IsRacing { get; set; }

    [JsonProperty("is_repair")]
    public bool IsRepair { get; set; }

    [JsonProperty("is_refuel")]
    public bool IsRefuel { get; set; }

    [JsonProperty("is_interdiction")]
    public bool IsInterdiction { get; set; }

    [JsonProperty("is_bomber")]
    public bool IsBomber { get; set; }

    [JsonProperty("is_tractor_beam")]
    public bool IsTractorBeam { get; set; }

    [JsonProperty("is_qed")]
    public bool IsQed { get; set; }

    [JsonProperty("is_emp")]
    public bool IsEmp { get; set; }

    [JsonProperty("is_construction")]
    public bool IsConstruction { get; set; }

    [JsonProperty("is_datarunner")]
    public bool IsDatarunner { get; set; }

    [JsonProperty("is_science")]
    public bool IsScience { get; set; }

    [JsonProperty("is_boarding")]
    public bool IsBoarding { get; set; }

    [JsonProperty("is_stealth")]
    public bool IsStealth { get; set; }

    [JsonProperty("is_research")]
    public bool IsResearch { get; set; }

    [JsonProperty("is_carrier")]
    public bool IsCarrier { get; set; }

    [JsonProperty("is_ground_vehicle")]
    public bool IsGroundVehicle { get; set; }

    [JsonProperty("is_spaceship")]
    public bool IsSpaceship { get; set; }

    /// <summary>
    /// Contains docking port
    /// </summary>
    [JsonProperty("is_docking")]
    public bool IsDocking { get; set; }

    /// <summary>
    /// Cargo can be loaded/unloaded via docking
    /// </summary>
    [JsonProperty("is_loading_dock")]
    public bool IsLoadingDock { get; set; }

    [JsonProperty("is_showdown_winner")]
    public bool IsShowdownWinner { get; set; }

    [JsonProperty("url_store")]
    public string? UrlRsiStorePage { get; set; }

    [JsonProperty("url_brochure")]
    public string? UrlBrochure { get; set; }

    [JsonProperty("url_hotsite")]
    public string? UrlHotsite { get; set; }

    [JsonProperty("url_video")]
    public string? UrlVideo { get; set; }

    /// <summary>
    /// A string representing a json array. 
    /// Will need further deserialized to be read
    /// </summary>
    [JsonProperty("url_photos")]
    public string? UrlsPhotos { get; set; }

    /// <summary>
    /// Star Citizen Version it was announced or updated
    /// </summary>
    [JsonProperty("game_version")]
    public string? GameVersion { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    [JsonProperty("company_name")]
    public string? CompanyName { get; set; }
}
