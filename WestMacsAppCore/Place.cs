/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:19 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 11:25:45
 */
using System.Collections.Generic;
using System;

/// <summary>
/// Interface for all Place types in the model.
/// Implements IComparable T, ICloneable.
/// Place instances are comparable by distance from east.
/// Places allow for deep copy cloning.
/// </summary>
public interface Place : IComparable<Place>, ICloneable
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