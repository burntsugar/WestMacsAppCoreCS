/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:06 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 16:49:02
 */
using System;

/// <summary>
/// Defines delegate methods for querying the model.
/// </summary>
public class AppDelegates
{
    /// <summary>
    /// Equality of a given Place instance name.
    /// </summary>
    /// <param name="name">Name to match</param>
    /// <returns>True if the name in the comparison matches the given name.</returns>
    public static Predicate<Place> PlaceHasName(string name)
    {
        return (p) => p.Name.Equals(name);
    }

    /// <summary>
    /// Place distance from east matches given distance including a +/- offset of KMs.
    /// </summary>
    /// <param name="distance">Distance to match on.</param>
    /// <returns>True, if distance + offset matches in the comparison.</returns>
    public static Predicate<Place> PlacesIsAtDistanceEast(int distance)
    {
        return (cs) => cs.DistanceKmFromEast > (distance - 5) && cs.DistanceKmFromEast < (distance + 5);
    }

    /// <summary>
    /// Place has the Facility of the given name.
    /// </summary>
    /// <param name="facilityName"></param>
    /// <returns>True if the place has the given Facility name.</returns>
    public static Predicate<Place> PlaceHasFacility(string facilityName)
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(facilityName));
    }

    /// <summary>
    /// Facility has an entry of the given name.
    /// </summary>
    /// <param name="facilityName"></param>
    /// <returns>True if the Facility has the given entry name.</returns>
    public static Predicate<Facility> FacilityHasEntry(string facilityName)
    {
        return (Facility f) => f.Name.Equals(facilityName);
    }

    /// <summary>
    /// Place has a source of water.
    /// </summary>
    /// <returns>True if the place has a source of water.</returns>
    public static Predicate<Place> PlaceHasWaterSource()
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_TANK_WATER) | f.Name.Equals(Facility.FACILITY_NAME_TAP_WATER));
    }

}