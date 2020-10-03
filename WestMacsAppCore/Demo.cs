using System;
using System.Collections.Generic;
public class Demo
{

    private static Controller _controller;

    public Demo(Controller controller)
    {
        _controller = controller;
    }
    public void startDemo()
    {

        printDemoHeadings("PLACES: Printing summary of all places (CampSite and TrailSite)");
        printAllPlaces();

        printDemoHeadings("PLACES: SORTED: EAST TO WEST: Printing summary of all places (CampSite and TrailSite) sorted by distance from the eastern starting point of the trail...");
        printAllPlacesSorted();

        printDemoHeadings("PLACES: SORTED: EAST TO WEST: WATER SOURCES: Printing summary of all places (CampSite and TrailSite) having a water source -  sorted by distance from the eastern starting point of the trail...");
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