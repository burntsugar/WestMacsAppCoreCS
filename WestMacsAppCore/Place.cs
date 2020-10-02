/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:19 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:19 
 */
using System.Collections.Generic;

public interface Place
{
    string Name
    {
        get;
        set;
    }
    double DistanceKmFromEast
    {
        get;
        set;
    }

    List<string> OtherNames
    {
        get;
        set;
    }
    string Description
    {
        get;
        set;
    }
    double[] Coords
    {
        get;
        set;
    }
    int Elevation
    {
        get;
        set;
    }
    List<Facility> Facilities
    {
        get;
        set;
    }

    List<Observation> Observations
    {
        get;
        set;
    }
}