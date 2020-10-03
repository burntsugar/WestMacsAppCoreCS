/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:59 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 10:38:12
 */
using NUnit.Framework;

namespace WestMacsAppCore.Tests
{
    public class TailSiteTest
    {
        private static int NUM_OF_TRAILSITES_WITH_WATER_SOURCE = 1;
        private static int NUM_OF_TRAILSITES_WITH_WATER_TANK = 1;
        private static int DISTANCE_1 = 140;
        private static string[] TRAILSITE_NAMES_NEAR_DISTANCE_1 = { "Serpentine Gorge Car Park" };

        private Controller controller;
        [SetUp]
        public void Setup()
        {
            Model model = DataUtils.ReadDataFile();
            controller = new Controller(model);
        }

        [Test]
        public void Get_All_TrailSite_Instances_With_Water_Source_Return_All_TrailSite_Instances_With_Water_Source()
        {
            int expected = NUM_OF_TRAILSITES_WITH_WATER_SOURCE;
            var returned = controller.GetTrailSitesWithWaterSource();
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(TrailSite)));
            });
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(expected, returned.Count);
        }

        [Test]
        public void Get_TrailSite_Instance_By_Name_Return_TrailSite_Instance_By_Name()
        {
            string expectedName = "Serpentine Gorge Car Park";
            TrailSite ts = controller.GetTrailSiteByName(expectedName);
            Assert.IsNotNull(ts);
            Assert.AreEqual(expectedName, ts.Name);
        }

        [Test]
        public void Get_TrailSite_By_Name_Return_Null()
        {
            TrailSite ts = controller.GetTrailSiteByName("does not exist");
            Assert.IsNull(ts);
        }

        [Test]
        public void Get_TrailSite_Instances_By_Distance_East_Return_TrailSite_Instances_By_Distance_East()
        {
            var returned = controller.GetTrailSitesAtDistanceEast(DISTANCE_1);
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(TrailSite)));
            });
            Assert.AreEqual(TRAILSITE_NAMES_NEAR_DISTANCE_1.Length, returned.Count);
            int i = 0;
            returned.ForEach((p) =>
            {
                Assert.AreEqual(p.Name, TRAILSITE_NAMES_NEAR_DISTANCE_1[i++]);
            });
        }

        [Test]
        public void Get_All_TrailSite_Instances_With_Water_Tank_Return_All_TrailSite_Instances_With_Water_Tank()
        {
            int expected = NUM_OF_TRAILSITES_WITH_WATER_TANK;
            var returned = controller.GetTrailSitesWithTankWater();
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(TrailSite)));
            });
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(expected, returned.Count);
        }

    }
}