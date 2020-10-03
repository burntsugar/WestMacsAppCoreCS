/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:56 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 15:32:15
 */
using System;
using System.Collections.Generic;

/// <summary>
/// Controller class for the app.
/// </summary>
public class Controller
{
    private Model _model;

    /// <summary>
    /// Constructs instance of Controller initialised with the Model.
    /// </summary>
    /// <param name="model">Model: Instance of the app model.</param>
    public Controller(Model model)
    {
        _model = model;
    }

    // Place...

    /// <summary>
    /// Gets an unsorted list of all instances which implement Place.
    /// </summary>
    /// <returns>List of Place: Unsorted list of all Place instances, or null if none are found.</returns>
    public List<Place> GetAllPlaces()
    {
        return _model.GetPlaces();
    }

    /// <summary>
    /// Gets a sorted list of all instances which implement Place sorted by distance from east.
    /// </summary>
    /// <returns>List of Place: List of all sorted Place instances, or null if none found.</returns>
    public List<Place> GetAllPlacesSortedByDistanceEast()
    {
        List<Place> places = _model.GetPlaces();
        if (places == null) return null;
        places.Sort();
        return places;
    }

    /// <summary>
    /// Returns a list of Observation instances of the given Facility name which belong to the given Place name, or null if none found.
    /// </summary>
    /// <param name="placeName">string: Name of Place to match</param>
    /// <param name="facilityName">string: Name of Facility to match</param>
    /// <returns>List of Observation: List of matching Observation instances.</returns>
    public List<Observation> GetPlaceFacilityObservations(string placeName, string facilityName)
    {
        Facility returned = _model.GetPlace(AppDelegates.placeHasName(placeName)).Facilities.Find(AppDelegates.FacilityHasEntry(facilityName));
        return returned.Observations;
    }

    /// <summary>
    /// Returns the list of Place Observation instances which belong to the given Place name, or null if none found.
    /// </summary>
    /// <param name="placeName">string: Place name to match</param>
    /// <returns>List of Observation: List of matching Place Observation instances.</returns>
    public List<Observation> GetPlaceObservations(string placeName)
    {
        Place p = _model.GetPlace(AppDelegates.placeHasName(placeName));
        if (p is null) return null;
        return p.Observations;
    }

    /// <summary>
    /// Returns a sorted list of instances implementing Place which have any source of water; including Tank water, Tap water, sorted from east to west.
    /// </summary>
    /// <returns>List of Place: List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithWaterSource()
    {
        List<Place> places = _model.GetPlaces(AppDelegates.placeHasWaterSource());
        if (places == null) return null;
        places.Sort();
        return places;
    }

    /// <summary>
    /// Returns an instance implementing Place, for a given name.
    /// </summary>
    /// <param name="name">string: Name of Place to match</param>
    /// <returns>Place: Instance implementing Place or null if not found.</returns>
    public Place GetPlaceByName(string name)
    {
        return _model.GetPlace(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Returns a list of instances implementing Place at the given distance with an offset of +/- 5KM (10KM range). 
    /// </summary>
    /// <param name="distance">int: Distance from the east starting point of the trail.</param>
    /// <returns>List of Place: List of Place instances, or null if not found.</returns>
    public List<Place> GetPlacesAtDistanceEast(int distance)
    {
        return _model.GetPlaces(AppDelegates.placesIsAtDistanceEast(distance));
    }

    /// <summary>
    /// Gets a sorted list of instances implementing Place which contain water tank facilities, sorted from east to west.
    /// </summary>
    /// <returns>List of Place: List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithTankWater()
    {
        List<Place> places = _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
        if (places is null) return null;
        places.Sort();
        return places;
    }

    /// <summary>
    /// Gets the list of Place instances containing shelter facilities.
    /// </summary>
    /// <returns>List of Place :List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithShelter()
    {
        List<Place> places = _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHELTER));
        if (places is null) return null;
        places.Sort();
        return places;
    }

    /// <summary>
    /// Gets the list of Place instances containing toilet facilities.
    /// </summary>
    /// <returns>List of Place :List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithToilet()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
    }

    /// <summary>
    /// Gets a list of Place instances having parking facilities.
    /// </summary>
    /// <returns>List of Place :List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithParking()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_PAPRKING));
    }

    // CampSite...

    /// <summary>
    /// Returns a list of CampSite instances which have any source of water; including tank water, tap water,
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>
    public List<CampSite> GetCampSitesWithWaterSource()
    {
        return _model.GetCampSites(AppDelegates.placeHasWaterSource());
    }

    /// <summary>
    /// Returns a CampSite instance for a given CampSite name.
    /// </summary>
    /// <param name="name">string: Name of CampSite</param>
    /// <returns>CampSite: Instance of CampSite or null if not found.</returns>
    public CampSite GetCampSiteByName(string name)
    {
        return _model.GetCampSite(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Returns a list of CampSite instances for the given distance with an offset of +/- 5KM.
    /// </summary>
    /// <param name="distance">int: The distance to query</param>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesByDistanceEast(int distance)
    {
        return _model.GetCampSites(AppDelegates.placesIsAtDistanceEast(distance));
    }

    /// <summary>
    /// Gets a list of CampSite instances containing water tank facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithTankWater()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Gets a list of CampSite instances containing shelter facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithShelter()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHELTER));
    }

    /// <summary>
    /// Gets a list of CampSite facilities containing toilet facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithToilet()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing USB charging facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithUSBCharging()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_USB_CHARGER));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing tap water facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithTapWater()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TAP_WATER));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing shower facilities.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithShower()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHOWER));
    }


    // TrailSites

    /// <summary>
    /// Returns a list of TrailSite instances which have any source of water; including tank water, tap water.
    /// </summary>
    /// <returns>List of TrailSite :List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesWithWaterSource()
    {
        return _model.GetTrailSites(AppDelegates.placeHasWaterSource());
    }

    /// <summary>
    /// Returns a TrailSite instance for a given name.
    /// </summary>
    /// <param name="name">String: Name of TrailSite</param>
    /// <returns>TrailSite: Instance of TrailSite or null if not found.</returns>
    public TrailSite GetTrailSiteByName(string name)
    {
        return _model.GetTrailSite(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Gets a list of TrailSite instances containing water tank facilities.
    /// </summary>
    /// <returns>List of TrailSite :List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesWithTankWater()
    {
        return _model.GetTrailSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Gets a list of TrailSite instances for the given distance with an offset of +/- 5KM. 
    /// </summary>
    /// <returns>List of TrailSite :List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesByDistanceEast(int distance)
    {
        return _model.GetTrailSites(AppDelegates.placesIsAtDistanceEast(distance));
    }

    // TODO: Remove...
    private void printx(Place pl)
    {
        Console.WriteLine(pl.Name);
    }

}