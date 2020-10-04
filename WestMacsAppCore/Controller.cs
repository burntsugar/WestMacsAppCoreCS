/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:56 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 12:32:28
 */
using System;
using System.Collections.Generic;

/// <summary>
/// Controller class for the app. All calls to the model are made through the controller.
/// Future versions of this project where a view is implemented, will interface with this class.
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
    /// Gets an unsorted list of all instances which implement Place. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of Place: Unsorted list of all Place instances, or null if none are found.</returns>
    public List<Place> GetAllPlaces()
    {
        return _model.GetPlaces();
    }

    /// <summary>
    /// Gets a sorted list of all instances which implement Place sorted by distance from east. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Returns a list of Observation instances of the given Facility name which belong to the given Place name, or null if none found. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Returns the list of Place Observation instances which belong to the given Place name, or null if none found. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Returns a sorted list of instances implementing Place which have any source of water; including Tank water, Tap water, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Returns an instance implementing Place, for a given name. The instance is a copy, modifications to the instance will not affect the original.
    /// </summary>
    /// <param name="name">string: Name of Place to match</param>
    /// <returns>Place: Instance implementing Place or null if not found.</returns>
    public Place GetPlaceByName(string name)
    {
        return _model.GetPlace(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Returns a list of instances implementing Place at the given distance with an offset of +/- 5KM (10KM range). The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <param name="distance">int: Distance from the east starting point of the trail.</param>
    /// <returns>List of Place: List of Place instances, or null if not found.</returns>
    public List<Place> GetPlacesAtDistanceEast(int distance)
    {
        return _model.GetPlaces(AppDelegates.placesIsAtDistanceEast(distance));
    }

    /// <summary>
    /// Gets a sorted list of instances implementing Place which contain water tank facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Gets the sorted list of Place instances containing shelter facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
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
    /// Gets the sorted list of Place instances containing toilet facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of Place: List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithToilet()
    {
        List<Place> places = _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
        if (places is null) return null;
        places.Sort();
        return places;
    }

    /// <summary>
    /// Gets a sorted list of Place instances having parking facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of Place :List of matching Place instances, or null if none found.</returns>
    public List<Place> GetPlacesWithParking()
    {
        List<Place> places = _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_PAPRKING));
        if (places is null) return null;
        places.Sort();
        return places;
    }

    // CampSite...

    /// <summary>
    /// Returns a sorted list of CampSite instances which have any source of water; including tank water, tap water, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>
    public List<CampSite> GetCampSitesWithWaterSource()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasWaterSource());
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Returns a CampSite instance for a given CampSite name. The instance is a copy, modifications to the instance will not affect the original.
    /// </summary>
    /// <param name="name">string: Name of CampSite</param>
    /// <returns>CampSite: Instance of CampSite or null if not found.</returns>
    public CampSite GetCampSiteByName(string name)
    {
        return _model.GetCampSite(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Returns a sorted list of CampSite instances for the given distance with an offset of +/- 5KM, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <param name="distance">int: The distance to query</param>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesByDistanceEast(int distance)
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placesIsAtDistanceEast(distance));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets a sorted list of CampSite instances containing water tank facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithTankWater()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets a sorted list of CampSite instances containing shelter facilities. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithShelter()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHELTER));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets a sorted list of CampSite facilities containing toilet facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite: List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithToilet()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets the sorted list of CampSite instances containing USB charging facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite: List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithUSBCharging()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_USB_CHARGER));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets the sorted list of CampSite instances containing tap water facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite: List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithTapWater()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TAP_WATER));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }

    /// <summary>
    /// Gets the sorted list of CampSite instances containing shower facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of CampSite :List of matching CampSite instances, or null if none found.</returns>    
    public List<CampSite> GetCampSitesWithShower()
    {
        List<CampSite> campSites = _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHOWER));
        if (campSites is null) return null;
        campSites.Sort();
        return campSites;
    }


    // TrailSites

    /// <summary>
    /// Returns a sorted list of TrailSite instances which have any source of water; including tank water, tap water, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of TrailSite: List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesWithWaterSource()
    {
        List<TrailSite> ts = _model.GetTrailSites(AppDelegates.placeHasWaterSource());
        if (ts is null) return null;
        ts.Sort();
        return ts;
    }

    /// <summary>
    /// Returns a TrailSite instance for a given name. The instance is a copy, modifications to the instance will not affect the original.
    /// </summary>
    /// <param name="name">String: Name of TrailSite</param>
    /// <returns>TrailSite: Instance of TrailSite or null if not found.</returns>
    public TrailSite GetTrailSiteByName(string name)
    {
        return _model.GetTrailSite(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Gets a sorted list of TrailSite instances containing water tank facilities, sorted from east to west. The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of TrailSite :List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesWithTankWater()
    {
        List<TrailSite> ts = _model.GetTrailSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
        if (ts is null) return null;
        ts.Sort();
        return ts;
    }

    /// <summary>
    /// Gets a list of TrailSite instances for the given distance with an offset of +/- 5KM (10KM range). The list is a copy, mofifications to the list have no affect on the original.
    /// </summary>
    /// <returns>List of TrailSite :List of matching TrailSite instances, or null if none found.</returns>    
    public List<TrailSite> GetTrailSitesAtDistanceEast(int distance)
    {
        return _model.GetTrailSites(AppDelegates.placesIsAtDistanceEast(distance));
    }

    // TODO: Remove...
    private void printx(Place pl)
    {
        Console.WriteLine(pl.Name);
    }

}