/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:38:46 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 16:25:19
 */
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Utility class for serialization of app data. Responsible for populating the model.
/// </summary>
public class DataUtils
{
    /// <summary>
    /// Read the default app data file in to a <c>Model</c> instance.
    /// </summary>
    /// <returns>Populated<c>Model</c></returns>
    /// <throws>System.Exception</throws>

    public static Model ReadDataFile()
    {
        try
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.json");
            return prepareModel(path);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    /// <summary>
    /// Read a given data file in to a <c>Model</c> instance.
    /// </summary>
    /// <returns>Populated<c>Model</c></returns>
    /// <throws>System.Exception</throws>
    public static Model ReadDataFile(string fileName)
    {
        try
        {
            Model m = prepareModel(fileName);
            return m;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private static Model prepareModel(string fileName)
    {
        try
        {
            using (var sr = new StreamReader(fileName))
            {
                string jsonString = sr.ReadToEnd();
                Model model = JsonSerializer.Deserialize<Model>(jsonString);
                return model;
            }
        }
        catch (IOException e)
        {
            throw e;
        }
        catch (ArgumentNullException ane)
        {
            throw ane;
        }
        catch (JsonException je)
        {
            throw je;
        }
    }
}

// TODO: serialize.
// TODO; persist.
