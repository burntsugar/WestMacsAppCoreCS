/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:38:55 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 07:17:41
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Facility
{
    public static string FACILITY_NAME_TANK_WATER = "Tank water";
    public static string FACILITY_NAME_SHELTER = "Shelter";
    public static string FACILITY_NAME_TOILET = "Toilet";
    public static string FACILITY_NAME_PAPRKING = "Parking Area";
    public static string FACILITY_NAME_USB_CHARGER = "USB charging station";
    public static string FACILITY_NAME_TAP_WATER = "Tap water";
    public static string FACILITY_NAME_SHOWER = "Shower";



    private string _name;
    private string _description;
    private List<Observation> _observations;

    [JsonPropertyName("facility_name")]
    public string Name { get => _name; set => _name = value; }
    [JsonPropertyName("facility-description")]
    public string Description { get => _description; set => _description = value; }
    [JsonPropertyName("facility-observations")]
    public List<Observation> Observations { get => _observations; set => _observations = value; }
}