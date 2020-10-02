/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:06 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 07:48:10
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
    public static Predicate<Place> placeHasName(string name)
    {
        return (p) => p.Name.Equals(name);
    }

    /// <summary>
    /// Place distance from east matches given distance including a +/- offset of KMs.
    /// </summary>
    /// <param name="distance">Distance to match on.</param>
    /// <returns>True, if distance + offset matches in the comparison.</returns>
    public static Predicate<Place> placesIsAtDistanceEast(int distance)
    {
        return (cs) => cs.DistanceKmFromEast > (distance - 5) && cs.DistanceKmFromEast < (distance + 5);
    }

    /// <summary>
    /// Place has the Facility of the given name.
    /// </summary>
    /// <param name="facilityName"></param>
    /// <returns>True if the place has the given Facility name.</returns>
    public static Predicate<Place> placeHasFacility(string facilityName)
    {
        return (Place p) => p.Facilities.Exists(f => f.Name.Equals(facilityName));
    }

}


///// <summary>
    // /// Place has water.
    // /// </summary>
    // /// <returns>True, if a place in the comparison has water.</returns>
    // public static Predicate<Place> placesHasTankWater()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_TANK_WATER));
    // }

    // /// <summary>
    // /// Place has shelter facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has shelter.</returns>
    // public static Predicate<Place> placeHasShelter()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_SHELTER));
    // }

    // /// <summary>
    // /// Place has toilet facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has toilet.</returns>
    // public static Predicate<Place> placeHasToilet()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_TOILET));
    // }

    // /// <summary>
    // /// Place has parking area facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has parking area facilities.</returns>
    // public static Predicate<Place> placeHasParking()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_PAPRKING));
    // }

    // /// <summary>
    // /// Place has USB charging facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has USB charging facilities.</returns>
    // public static Predicate<Place> placeHasUSBCharging()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_USB_CHARGER));
    // }

    // /// <summary>
    // /// Place has tap water facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has tap water facilities.</returns>
    // public static Predicate<Place> placeHasTapWater()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_TAP_WATER));
    // }

    // /// <summary>
    // /// Place has shower facilities.
    // /// </summary>
    // /// <returns>True if place in the comparison has shower facilities.</returns>
    // public static Predicate<Place> placeHasShower()
    // {
    //     return (Place p) => p.Facilities.Exists(f => f.Name.Equals(Facility.FACILITY_NAME_SHOWER));
    // }