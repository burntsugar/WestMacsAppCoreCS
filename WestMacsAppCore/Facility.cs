/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:38:55 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:38:55 
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Facility
{
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