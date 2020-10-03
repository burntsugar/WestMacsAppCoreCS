/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:06 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 15:25:19
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

    private List<Place> cloneList(List<Place> l){
        var clone = new List<Place>();
        l.ForEach((p)=>{
            clone.Add((Place)p.Clone());
        });
        return clone;
    }

    private Place clonePlace(Place p){
        Place clone = (Place)p.Clone();
        return clone;
    }

    private List<CampSite> cloneList(List<CampSite> l){
        var clone = new List<CampSite>();
        l.ForEach((p)=>{
            clone.Add((CampSite)p.Clone());
        });
        return clone;
    }

    private CampSite cloneCampSite(CampSite p){
        CampSite clone = (CampSite)p.Clone();
        return clone;
    }

    private List<TrailSite> cloneList(List<TrailSite> l){
        var clone = new List<TrailSite>();
        l.ForEach((p)=>{
            clone.Add((TrailSite)p.Clone());
        });
        return clone;
    }

    private TrailSite cloneTrailSite(TrailSite p){
        TrailSite clone = (TrailSite)p.Clone();
        return clone;
    }

    // Place...

    public Place GetPlace(Predicate<Place> del)
    {
        List<Place> places = new List<Place>();
        places.AddRange(_campsites);
        places.AddRange(_trailSites);
        if (places.Find(del)is null)return null;
        return clonePlace(places.Find(del));
        //return places.Find(del);
    }

    public List<Place> GetPlaces(Predicate<Place> del)
    {
        List<Place> places = new List<Place>();
        places.AddRange(_campsites.FindAll(del));
        places.AddRange(_trailSites.FindAll(del));
        //return places;
        if (places is null)return null;
        return cloneList(places);
    }

    public List<Place> GetPlaces()
    {
        List<Place> places = new List<Place>();
        places.AddRange(_campsites);
        places.AddRange(_trailSites);
        if (places is null)return null;
        return cloneList(places);
        //return places;
    }

    // CampSite...

    public CampSite GetCampSite(Predicate<CampSite> del)
    {
        CampSite cs = _campsites.Find(del);
        if (cs is null)return null;
        return cloneCampSite(cs);
        //return _campsites.Find(del);
    }

    public List<CampSite> GetCampSites(Predicate<CampSite> del)
    {
        var campSites = _campsites.FindAll(del);
        if (campSites is null)return null;
        return cloneList(campSites);
        //return _campsites.FindAll(del);
    }

    // TrailSite

    public TrailSite GetTrailSite(Predicate<TrailSite> del)
    {
        TrailSite t = _trailSites.Find(del);
        if (t is null) return null;
        return cloneTrailSite(t);
        //return _trailSites.Find(del);
    }

    public List<TrailSite> GetTrailSites(Predicate<TrailSite> del)
    {
        return _trailSites.FindAll(del);
    }



    //TODO: Calculate distance to west

}

// /*
//  * @Author: rrr@burntsugar.rocks 
//  * @Date: 2020-10-02 19:39:06 
//  * @Last Modified by: rrr@burntsugar.rocks
//  * @Last Modified time: 2020-10-03 12:44:05
//  */
// using System.Collections.Generic;
// using System.Text.Json.Serialization;
// using System;

// public class Model
// {
//     private List<TrailSite> _trailSites;
//     private List<CampSite> _campsites;

//     [JsonPropertyName("campsites")]
//     public List<CampSite> Campsites { get => _campsites; set => _campsites = value; }

//     [JsonPropertyName("trailsites")]
//     public List<TrailSite> TrailSites { get => _trailSites; set => _trailSites = value; }

//     public override string ToString()
//     {
//         return $"Model >> Campsites: {_campsites.Count}, TrailSite: {_trailSites.Count}";
//     }

//     // Place...

//     public Place GetPlace(Predicate<Place> del)
//     {
//         List<Place> places = new List<Place>();
//         places.AddRange(_campsites);
//         places.AddRange(_trailSites);
//         return places.Find(del);
//     }

//     public List<Place> GetPlaces(Predicate<Place> del)
//     {
//         List<Place> places = new List<Place>();
//         places.AddRange(_campsites.FindAll(del));
//         places.AddRange(_trailSites.FindAll(del));
//         return places;
//     }

//     public List<Place> GetPlaces()
//     {
//         List<Place> places = new List<Place>();
//         places.AddRange(_campsites);
//         places.AddRange(_trailSites);
//         return places;
//     }

//     // CampSite...

//     public CampSite GetCampSite(Predicate<CampSite> del)
//     {
//         return _campsites.Find(del);
//     }

//     public List<CampSite> GetCampSites(Predicate<CampSite> del)
//     {
//         return _campsites.FindAll(del);
//     }

//     // TrailSite

//     public TrailSite GetTrailSite(Predicate<TrailSite> del)
//     {
//         return _trailSites.Find(del);
//     }

//     public List<TrailSite> GetTrailSites(Predicate<TrailSite> del)
//     {
//         return _trailSites.FindAll(del);
//     }



//     //TODO: Calculate distance to west

// }