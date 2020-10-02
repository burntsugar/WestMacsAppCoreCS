/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:26 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:26 
 */
using System;

namespace custom2
{
    class Program
    {
        static void Main(string[] args)
        {
            Model model = DataUtils.ReadDataFile();
            Controller controller = new Controller(model);

            // Console.WriteLine(model.ToString());
            // Console.WriteLine(controller.GetCampSiteByName("Wallaby Gap Campsite").Name);
            //Console.WriteLine(controller.GetPlaceByName("Telegraph Station").Name);
            // Console.WriteLine(controller.GetCampSitesByDistanceEast(16)[0].DistanceKmFromEast);
            // Console.WriteLine(controller.GetCampSitesByDistanceEast(16)[0].Name);
            // controller.GetPlacesByDistanceEast(100).ForEach((p) => printx(p.Name));
            // controller.GetPlacesWithWater().ForEach(p => printx(p.Name));

            controller.GetCampSitesWithTankWater().ForEach(p => printx(p.Name));



        }

        static void printx(string s)
        {
            Console.WriteLine(s);
        }
    }
}
