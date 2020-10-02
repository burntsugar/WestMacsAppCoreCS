/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:56 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 08:28:26
 */
using NUnit.Framework;
using System.Collections.Generic;

namespace WestMacsAppCore.Tests
{
    public class PlaceTest
    {

        private static int NUM_OF_PLACES_WITH_WATER_SOURCE = 15;
        private static int NUM_OF_PLACES_WITH_WATER_TANK = 15;
        private static int NUM_OF_PLACES_WITH_SHELTER = 9;
        private static int NUM_OF_PLACES_WITH_TOILET = 15;
        private static int NUM_OF_PLACES_WITH_PARKING = 1;
        private static int DISTANCE_1 = 106;
        private static string[] PLACE_NAMES_NEAR_DISTANCE_1 = { "Ghost Gum Flat Campsite", "Rocky Gully Campsite" };

        private Controller controller;
        [SetUp]
        public void Setup()
        {
            Model model = DataUtils.ReadDataFile();
            controller = new Controller(model);
        }

        [Test]
        public void Get_Any_Place_Instance_With_Water_Source_Return_Any_Place_With_Water_Source()
        {
            List<Place> returned = controller.GetPlacesWithWaterSource();
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_WATER_SOURCE,returned.Count);
        }

        [Test]
        public void Get_Any_Place_Instance_By_Name_Return_Any_Place_Instance()
        {
            string expectedName = "Wallaby Gap Campsite";
            Place p = controller.GetPlaceByName(expectedName);
            Assert.IsNotNull(p);
            Assert.AreEqual(expectedName, p.Name);
        }

        [Test]
        public void Get_Any_Place_By_Name_Return_Null()
        {
            Place p = controller.GetPlaceByName("does not exist");
            Assert.IsNull(p);
        }

        [Test]
        public void Get_Any_Place_Instance_Types_By_Distance_East_Return_Any_Place_Instances_By_Distance()
        {
            List<Place> actual = controller.GetPlacesByDistanceEast(DISTANCE_1);
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1.Length, actual.Count);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1[0], actual[0].Name);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1[1], actual[1].Name);
        }

        [Test]
        public void Get_Any_Places_With_Water_Tank()
        {
            int expected = NUM_OF_PLACES_WITH_WATER_TANK;
            List<Place> places = controller.GetPlacesWithTankWater();
            Assert.IsNotEmpty(places);
            Assert.AreEqual(expected, places.Count);
        }

        [Test]
        public void Get_Any_Place_Instances_With_Shelter_Return_Place_Instances_With_Shelter()
        {
            var returned = controller.GetPlacesWithShelter();
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_SHELTER, returned.Count);
        }

        [Test]
        public void Get_Any_Place_Instances_With_Toilet_Return_Place_Instances_With_Toilet()
        {
            var returned = controller.GetPlacesWithToilet();
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_TOILET, returned.Count);
        }

        [Test]
        public void Get_Any_Places_With_Parking_Facilities()
        {
            int expected = NUM_OF_PLACES_WITH_PARKING;
            List<Place> places = controller.GetPlacesWithParking();
            Assert.IsNotEmpty(places);
            Assert.AreEqual(expected, places.Count);
        }

    }
}