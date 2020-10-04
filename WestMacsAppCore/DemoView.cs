/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-04 10:47:09 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 10:49:32
 */

using System;

/// <summary>
/// Demonstration class which shows a select few methods for displaying data from the model.
/// </summary>
public class DemoView
{

    private static Controller _controller;

    /// <summary>
    /// Constructor is initialised with an instance of the app Controller.
    /// </summary>
    /// <param name="controller">Controller.</param>
    public DemoView(Controller controller)
    {
        _controller = controller;
    }

    /// <summary>
    /// Commence demo routine.
    /// </summary>
    public void startDemo()
    {
        printDemoHeadings("PLACES: Showing the summary of all places (CampSite and TrailSite) in the model");
        printAllPlaces();

        printDemoHeadings("PLACES: SORTED: EAST TO WEST: Showing a summary of all places (CampSite and TrailSite) in the model sorted by distance from the eastern starting point of the trail...");
        printAllPlacesSorted();

        printDemoHeadings("PLACES: SORTED: EAST TO WEST: WATER SOURCES: Showing a summary of all places (CampSite and TrailSite) in the model having a water source -  sorted by distance from the eastern starting point of the trail...");
        printAllWithAWaterSource();
    }

    private void printAllWithAWaterSource()
    {
        _controller.GetPlacesWithWaterSource().ForEach((p) =>
        {
            printDemoLines(truncateDescription(p.ToString()));
        });
    }

    private void printAllPlaces()
    {
        _controller.GetAllPlaces().ForEach((p) =>
        {
            printDemoLines(truncateDescription(p.ToString()));
        });
    }

    private void printAllPlacesSorted()
    {
        _controller.GetAllPlacesSortedByDistanceEast().ForEach((p) =>
        {
            printDemoLines(truncateDescription(p.ToString()));
        });
    }
    private string truncateDescription(string str)
    {
        int len = str.Length;
        return len > 100 ? (str.Substring(0, 99) + "...") : str;
    }
    private void printDemoHeadings(string str)
    {
        Console.WriteLine("\n\n*******************");
        Console.WriteLine("*******************");
        Console.WriteLine("*******************");
        Console.WriteLine($">>> {str}\n >>> \n");
    }
    private void printDemoLines(string str)
    {
        Console.WriteLine($"\t>>> {str}");
    }
}