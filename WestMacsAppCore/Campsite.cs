/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:45 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 11:14:39
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;

/// <summary>
/// Defines state and behaviour for a CampSite along the trail.
/// </summary>
public class CampSite : Place
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

    /// <value>Get or set the Campsite name</value>
    [JsonPropertyName("name")]
    public string Name { get => _name; set => _name = value; }

    /// <value>Get or set the distance of this campsite, along the trail, from the eastern start point of the trail.</value>
    [JsonPropertyName("distance_km_from_east")]
    public double DistanceKmFromEast { get => _distanceKmFromEast; set => _distanceKmFromEast = value; }

    /// <value>Get or set the list of other names that this campsite is known by. This list is intented primarily for traditional names but may also include colloquialisms.</value>
    [JsonPropertyName("other_names")]
    public List<string> OtherNames { get => _otherNames; set => _otherNames = value; }

    /// <value>Get or set the description of the campsite.</value>
    [JsonPropertyName("description")]
    public string Description { get => _description; set => _description = value; }

    /// <value>Get or set the latitude and longitude for this campsite.</value>
    [JsonPropertyName("coords")]
    public double[] Coords { get => _coords; set => _coords = value; }

    /// <value>Get or set the elevation in meters of this campsite.</value>
    [JsonPropertyName("elevation")]
    public int Elevation { get => _elevation; set => _elevation = value; }

    /// <value>Get or set the list of facilities contained by this campsite.</value>
    [JsonPropertyName("facilities")]
    public List<Facility> Facilities { get => _facilities; set => _facilities = value; }

    /// <value>Get or set the observations made by visitors to this campsite.</value>
    [JsonPropertyName("observations")]
    public List<Observation> Observations { get => _observations; set => _observations = value; }

    /// <value>Get or set the trailhead status for this campsite.</value>
    [JsonPropertyName("is_trail_head")]
    public bool IsTrailHead { get => _isTrailHead; set => _isTrailHead = value; }

    /// <value>Get or set the section number that this campsite belongs to.</value>
    [JsonPropertyName("section")]
    public int Section { get => section; set => section = value; }

    /// <summary>
    /// Implementation of ToString().
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{DistanceKmFromEast}: CampSite: {Name} {Description}";
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
    /// <returns>CampSite: A complete deep copy of the current instance state.</returns>
    public object Clone()
    {
        return new CampSite
        {
            Coords = Coords.ToArray(),
            Description = this.Description,
            DistanceKmFromEast = this.DistanceKmFromEast,
            Elevation = this.Elevation,
            Facilities = this.Facilities.Select(i => (Facility)i.Clone()).ToList(),
            IsTrailHead = this.IsTrailHead,
            Name = this.Name,
            Observations = this.Observations.Select(i => (Observation)i.Clone()).ToList(),
            OtherNames = this.OtherNames.Select(i => (string)i.Clone()).ToList(),
            Section = this.Section
        };
    }
}