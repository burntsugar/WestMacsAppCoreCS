/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:06 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:37:06 
 */
using System;



/// <summary>
/// Defines delegate methods for querying the model.
/// </summary>
public class AppDelegates
{
    private static string FACILITY_NAME_TANK_WATER = "Tank water";
    private static string FACILITY_NAME_SHELTER = "Shelter";
    private static string FACILITY_NAME_TOILET = "Toilet";
    private static string FACILITY_NAME_PAPRKING = "Parking Area";

    /// <summary>
    /// Equality of a given Place instance name.
    /// </summary>
    /// <param name="name">Name to match</param>
    /// <returns>True if the name in the comparison matches the given name.</returns>
    public static Predicate<Place> placesByNameQuery(string name)
    {
        return (p) => p.Name.Equals(name);
    }

    /// <summary>
    /// Place distance from east matches given distance including a +/- offset of KMs.
    /// </summary>
    /// <param name="distance">Distance to match on.</param>
    /// <returns>True, if distance + offset matches in the comparison.</returns>
    public static Predicate<Place> placesByDistanceEastQuery(int distance)
    {
        return (cs) => cs.DistanceKmFromEast > (distance - 5) && cs.DistanceKmFromEast < (distance + 5);
    }

    /// <summary>
    /// Place has water.
    /// </summary>
    /// <returns>True, if a place in the comparison has water.</returns>
    public static Predicate<Place> placesWithWaterTanksQuery()
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Place has shelter facilities.
    /// </summary>
    /// <returns>True if place in the comparison has shelter.</returns>
    public static Predicate<Place> placesWithShelterQuery()
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(FACILITY_NAME_SHELTER));
    }

    /// <summary>
    /// Place has toilet facilities.
    /// </summary>
    /// <returns>True if place in the comparison has toilet.</returns>
    public static Predicate<Place> placesWithToiletQuery()
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(FACILITY_NAME_TOILET));
    }

    /// <summary>
    /// Place has parking area facilities.
    /// </summary>
    /// <returns>True if place in the comparison has parking area facilities.</returns>
    public static Predicate<Place> placesWithParkingQuery()
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(FACILITY_NAME_PAPRKING));
    }
}