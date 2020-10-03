/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:31 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:31 
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;


public class TrailSite : Place
{
    private bool _isTrailHead;
    private int section;
    private string _name;
    private double _distanceKmFromEast;
    private List<string> _otherNames;
    private string _description;
    private double[] _coords;
    private int _elevation;
    private List<Facility> _facilities;
    private List<Observation> _observations;

    [JsonPropertyName("name")]
    public string Name { get => _name; set => _name = value; }

    [JsonPropertyName("distance_km_from_east")]
    public double DistanceKmFromEast { get => _distanceKmFromEast; set => _distanceKmFromEast = value; }

    [JsonPropertyName("other_names")]
    public List<string> OtherNames { get => _otherNames; set => _otherNames = value; }

    [JsonPropertyName("description")]
    public string Description { get => _description; set => _description = value; }

    [JsonPropertyName("coords")]
    public double[] Coords { get => _coords; set => _coords = value; }

    [JsonPropertyName("elevation")]
    public int Elevation { get => _elevation; set => _elevation = value; }

    [JsonPropertyName("facilities")]
    public List<Facility> Facilities { get => _facilities; set => _facilities = value; }

    [JsonPropertyName("observations")]
    public List<Observation> Observations { get => _observations; set => _observations = value; }

    [JsonPropertyName("is_trail_head")]
    public bool IsTrailHead { get => _isTrailHead; set => _isTrailHead = value; }
    
    [JsonPropertyName("section")]
    public int Section { get => section; set => section = value; }
}