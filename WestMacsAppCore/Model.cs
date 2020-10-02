/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:06 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 07:19:18
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

public class Model
{

    private List<TrailSite> _trailSites;
    private List<CampSite> _campsites;

    [JsonPropertyName("campsites")]
    public List<CampSite> Campsites { get => _campsites; set => _campsites = value; }
    [JsonPropertyName("trailsites")]
    public List<TrailSite> TrailSites { get => _trailSites; set => _trailSites = value; }

    public override string ToString()
    {
        return $"Model >> Campsites: {_campsites.Count}, TrailSite: {_trailSites.Count}";
    }

    // Place...

    public Place GetPlace(Predicate<Place> del)
    {
        List<Place> places = new List<Place>();
        places.AddRange(_campsites);
        places.AddRange(_trailSites);
        return places.Find(del);
    }

    public List<Place> GetPlaces(Predicate<Place> del)
    {
        List<Place> places = new List<Place>();
        places.AddRange(_campsites.FindAll(del));
        places.AddRange(_trailSites.FindAll(del));
        return places;
    }

    // CampSite...

    public CampSite GetCampSite(Predicate<CampSite> del)
    {
        return _campsites.Find(del);
    }

    public List<CampSite> GetCampSites(Predicate<CampSite> del)
    {
        return _campsites.FindAll(del);
    }

    // TrailSite

    public TrailSite GetTrailSite(Predicate<TrailSite> del)
    {
        return _trailSites.Find(del);
    }

    public List<TrailSite> GetTrailSites(Predicate<TrailSite> del)
    {
        return _trailSites.FindAll(del);
    }



    //TODO: Calculate distance to west

}