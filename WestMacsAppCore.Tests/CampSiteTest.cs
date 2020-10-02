/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:53 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:53 
 */
using NUnit.Framework;

namespace WestMacsAppCore.Tests
{

    public class CampSiteTest
    {

        private static int DISTANCE_1 = 106;
        private static string[] CAMPSITE_NAMES_NEAR_DISTANCE_1 = { "Ghost Gum Flat Campsite", "Rocky Gully Campsite" };
        private static int NUM_OF_CAMPSITES_WITH_WATER_TANK = 14;
        private static int NUM_OF_CAMPSITES_WITH_SHELTER = 9;
        private static int NUM_OF_CAMPSITES_WITH_TOILET = 14;

        private Controller controller;
        [SetUp]
        public void Setup()
        {
            Model model = DataUtils.ReadDataFile();
            controller = new Controller(model);
        }

        [Test]
        public void Get_Campsite_Instance_By_Name_Return_CampSite_Instance()
        {
            string expectedName = "Wallaby Gap Campsite";
            Place actual = controller.GetCampSiteByName(expectedName);
            Assert.IsNotNull(actual);
            Assert.That(actual, Is.TypeOf(typeof(CampSite)));
            Assert.AreEqual(expectedName, actual.Name);
        }

        [Test]
        public void Get_CampSite_By_Name_Return_Null()
        {
            Place p = controller.GetCampSiteByName("does not exist");
            Assert.IsNull(p);
        }

        [Test]
        public void Get_All_CampSite_Instances_With_Water_Tank_Return_All_Campsite_Instances_With_Water_Tank()
        {
            int expected = NUM_OF_CAMPSITES_WITH_WATER_TANK;
            var returned = controller.GetCampSitesWithTankWater();
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(CampSite)));
            });
            Assert.AreEqual(expected, returned.Count);
        }

        [Test]
        public void Get_CampSite_Instance_Types_By_Distance_East_Return_CampSite_Instances_By_Distance()
        {
            var returned = controller.GetCampSitesByDistanceEast(DISTANCE_1);
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(CampSite)));
            });
            Assert.AreEqual(CAMPSITE_NAMES_NEAR_DISTANCE_1.Length, returned.Count);
            Assert.AreEqual(CAMPSITE_NAMES_NEAR_DISTANCE_1[0], returned[0].Name);
            Assert.AreEqual(CAMPSITE_NAMES_NEAR_DISTANCE_1[1], returned[1].Name);
        }

        [Test]
        public void Get_CampSite_Instances_With_Shelter_Return_CampSite_Instances_With_Shelter()
        {
            var returned = controller.GetCampSitesWithShelter();
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(CampSite)));
            });
            Assert.AreEqual(NUM_OF_CAMPSITES_WITH_SHELTER, returned.Count);
        }

        [Test]
        public void Get_CampSite_Instances_With_Toilet_Return_CampSite_Instances_With_Toilet()
        {
            var returned = controller.GetCampSitesWithToilet();
            Assert.IsNotEmpty(returned);
            returned.ForEach((p) =>
            {
                Assert.That(p, Is.TypeOf(typeof(CampSite)));
            });
            Assert.AreEqual(NUM_OF_CAMPSITES_WITH_TOILET, returned.Count);
        }

    }
}
