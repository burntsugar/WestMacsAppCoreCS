/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:26 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 09:25:30
 */
using System;
using System.Collections.Generic;

namespace custom2
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
            Model model = DataUtils.ReadDataFile();
            Controller controller = new Controller(model);

            // List<Place> returned = controller.GetAllPlaces();
            // Console.WriteLine(returned[0].Name);

            Place p = controller.GetPlaceByName("Telegraph Station");
            Console.WriteLine(p.GetType());

            Console.WriteLine(p.Name);
            Console.WriteLine(p.Facilities[0].Name);
            
            Console.WriteLine(p.Observations.Count);

            //Console.WriteLine(p.Observations[0].AuthorName);

            } catch (Exception exception) {
                Console.WriteLine("STOP HAMMER TIME " + exception.Message);
            }

            // Console.WriteLine(model.ToString());
            // Console.WriteLine(controller.GetCampSiteByName("Wallaby Gap Campsite").Name);
            //Console.WriteLine(controller.GetPlaceByName("Telegraph Station").Name);
            // Console.WriteLine(controller.GetCampSitesByDistanceEast(16)[0].DistanceKmFromEast);
            // Console.WriteLine(controller.GetCampSitesByDistanceEast(16)[0].Name);
            // controller.GetPlacesByDistanceEast(100).ForEach((p) => printx(p.Name));
            // controller.GetPlacesWithWater().ForEach(p => printx(p.Name));

            // controller.GetCampSitesWithTankWater().ForEach(p => printx(p.Name));



        }

        static void printx(string s)
        {
            Console.WriteLine(s);
        }
    }
}
