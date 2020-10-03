/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:37:56 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 11:27:54
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
    /// Returns a list of Place instances which have any source of water.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetAllPlaces()
    {
        return _model.GetPlaces();
    }

    /// <summary>
    /// Returns a list of Facility Observation instances which belong to the given named place.
    /// </summary>
    /// <returns>List of matching Observation instances.</returns>
    public List<Observation> GetPlaceFacilityObservations(string placeName, string facilityName)
    {
        Facility returned = _model.GetPlace(AppDelegates.placeHasName(placeName)).Facilities.Find(AppDelegates.FacilityHasEntry(facilityName));
        return returned.Observations;
    }

    /// <summary>
    /// Returns a list of Observation instances which belong to the given named place.
    /// </summary>
    /// <returns>List of matching Observation instances.</returns>
    public List<Observation> GetPlaceObservations(string placeName)
    {
        Place p = _model.GetPlace(AppDelegates.placeHasName(placeName));
        if (p is null) return null;
        return p.Observations;
    }

    /// <summary>
    /// Returns a list of Place instances which have any source of water.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetPlacesWithWaterSource()
    {
        return _model.GetPlaces(AppDelegates.placeHasWaterSource());
    }

    /// <summary>
    /// Returns a Place instance for a given name.
    /// </summary>
    /// <param name="name">Name of Place to match</param>
    /// <returns>Place: Instance of Place or null if not found.</returns>
    public Place GetPlaceByName(string name)
    {
        return _model.GetPlace(AppDelegates.placeHasName(name));
    }

    /// <summary>
    /// Returns a list of Place instances for the given distance with an offset of +/- 5KM. 
    /// </summary>
    /// <param name="distance">int: Distance from the east starting point of the trail.</param>
    /// <returns>List of Place instances.</returns>
    public List<Place> GetPlacesByDistanceEast(int distance)
    {
        return _model.GetPlaces(AppDelegates.placesIsAtDistanceEast(distance));
    }

    /// <summary>
    /// Gets a list of Place instances containing water tank facilities.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetPlacesWithTankWater()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Gets the list of Place instances containing shelter facilities.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetPlacesWithShelter()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHELTER));
    }

    /// <summary>
    /// Gets the list of Place instances containing toilet facilities.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetPlacesWithToilet()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
    }

    /// <summary>
    /// Gets a list of Place instances having parking facilities.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<Place> GetPlacesWithParking()
    {
        return _model.GetPlaces(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_PAPRKING));
    }

    // CampSite...

    /// <summary>
    /// Returns a list of CampSite instances which have any source of water.
    /// </summary>
    /// <returns>List of matching Place instances.</returns>
    public List<CampSite> GetCampSitesWithWaterSource()
    {
        return _model.GetCampSites(AppDelegates.placeHasWaterSource());
    }

    /// <summary>
    /// Returns a CampSite instance for a given name.
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
    /// <param name="distance">The distance to query</param>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesByDistanceEast(int distance)
    {
        return _model.GetCampSites(AppDelegates.placesIsAtDistanceEast(distance));
    }

    /// <summary>
    /// Gets the list of camp sites containing water tank facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithTankWater()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Gets the list of camp sites containing shelter facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithShelter()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHELTER));
    }

    /// <summary>
    /// Gets the list of camp sites containing shelter facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithToilet()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TOILET));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing USB charging facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithUSBCharging()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_USB_CHARGER));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing tap water facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithTapWater()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TAP_WATER));
    }

    /// <summary>
    /// Gets the list of CampSite instances containing shower facilities.
    /// </summary>
    /// <returns>List of matching CampSite instances.</returns>
    public List<CampSite> GetCampSitesWithShower()
    {
        return _model.GetCampSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_SHOWER));
    }


    // TrailSites

    /// <summary>
    /// Returns a list of TrailSite instances which have any source of water.
    /// </summary>
    /// <returns>List of matching TrailSite instances.</returns>
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
    /// <returns>List of matching TrailSite instances.</returns>
    public List<TrailSite> GetTrailSitesWithTankWater()
    {
        return _model.GetTrailSites(AppDelegates.placeHasFacility(Facility.FACILITY_NAME_TANK_WATER));
    }

    /// <summary>
    /// Gets a list of TrailSite instances containing water tank facilities.
    /// </summary>
    /// <returns>List of matching TrailSite instances.</returns>
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