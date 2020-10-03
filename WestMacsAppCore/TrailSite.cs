/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:31 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 16:37:39
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Defines the state and behaviour for a TrailSite.
/// A TrailSite is any place along the trail which is NOT a campsite.
/// </summary>
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

    /// <value>Get or set the name of the TrailSite.</value>
    [JsonPropertyName("name")]
    public string Name { get => _name; set => _name = value; }

    /// <value>Get or set distance_km_from_east of the TrailSite.</value>
    [JsonPropertyName("distance_km_from_east")]
    public double DistanceKmFromEast { get => _distanceKmFromEast; set => _distanceKmFromEast = value; }

    /// <value>Get or set other names that this TrailSite is known by.</value>
    [JsonPropertyName("other_names")]
    public List<string> OtherNames { get => _otherNames; set => _otherNames = value; }

    /// <value>Get or set description of the TrailSite.</value>
    [JsonPropertyName("description")]
    public string Description { get => _description; set => _description = value; }

    /// <value>Get or set latitude or longitude of the TrailSite.</value>
    [JsonPropertyName("coords")]
    public double[] Coords { get => _coords; set => _coords = value; }

    /// <value>Get or set the elevation of the TrailSite.</value>
    [JsonPropertyName("elevation")]
    public int Elevation { get => _elevation; set => _elevation = value; }

    /// <value>Get or set facilities collection of this TrailSite.</value>
    [JsonPropertyName("facilities")]
    public List<Facility> Facilities { get => _facilities; set => _facilities = value; }

    /// <value>Get or set observations collection of this TrailSite.</value>
    [JsonPropertyName("observations")]
    public List<Observation> Observations { get => _observations; set => _observations = value; }

    /// <value>Get or set the trailhead status of the TrailSite.</value>
    [JsonPropertyName("is_trail_head")]
    public bool IsTrailHead { get => _isTrailHead; set => _isTrailHead = value; }

    /// <value>Get or set the section number of the TrailSite.</value>
    [JsonPropertyName("section")]
    public int Section { get => section; set => section = value; }

    /// <summary>
    /// Implementation of ToString().
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{DistanceKmFromEast}: TrailSite: {Name} {Description}";
    }
    /// <summary>
    /// Implementation of IComparable interface is based upon distance from the trail start to the east.
    /// </summary>
    /// <param name="other">Place: Other place in the comparison.</param>
    /// <returns>int: representing lesser, equal or greater.</returns>
    public int CompareTo(Place other)
    {
        double diff = DistanceKmFromEast - other.DistanceKmFromEast;
        return diff > 0 ? 1 : diff == 0.0 ? 0 : -1;
    }

    /// <summary>
    /// Implementation of IClonable interface.
    /// </summary>
    /// <returns>TrailSite: A complete deep copy of the current instance state.</returns>
    public object Clone()
    {
        return new TrailSite
        {
            Coords = this.Coords,
            Description = this.Description,
            DistanceKmFromEast = this.DistanceKmFromEast,
            Elevation = this.Elevation,
            Facilities = this.Facilities,
            IsTrailHead = this.IsTrailHead,
            Name = this.Name,
            Observations = this.Observations,
            OtherNames = this.OtherNames,
            Section = this.Section
        };
    }
}