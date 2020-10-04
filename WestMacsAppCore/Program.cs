/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:26 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-04 10:50:14
 */
using System;

namespace custom2
{
    /// <summary>
    /// Welcome in :)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Model model = DataUtils.ReadDataFile();
                Controller controller = new Controller(model);
                DemoView demo = new DemoView(controller);
                demo.startDemo();
            }
            catch (Exception e)
            {
                Console.Write($"There has been a problem with the data file. Please submit a bug request to https://github.com/burntsugar {e.Message}");
            }

        }
    }

}
