/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:38:46 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:38:46 
 */
using System.IO;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Utility for reading app data from .json and persisting app data to .json.
/// </summary>
public class DataUtils
{
    /// <summary>
    /// Read the default app data file in to a <c>Model</c> instance.
    /// </summary>
    /// <returns>Populated<c>Model</c></returns>
    public static Model ReadDataFile()
    {
        // TODO: exception handling.
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.json");
        return prepareModel(path);
    }
    /// <summary>
    /// Read a given data file in to a <c>Model</c> instance.
    /// </summary>
    /// <returns>Populated<c>Model</c></returns>
    public static Model ReadDataFile(string fileName)
    {
        return prepareModel(fileName);
    }

    private static Model prepareModel(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        Model model = JsonSerializer.Deserialize<Model>(jsonString);
        return model;
    }
}